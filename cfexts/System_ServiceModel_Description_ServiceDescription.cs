using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_ServiceModel_Description_ServiceDescription : System_Object
    {
        //Name:        System.ServiceModel.Description.ServiceDescription
        //MethodTable: 0177e6e0
        //EEClass:     017881a0
        //Size:        32(0x20) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //0177f334  40028c3        4 ...em.ServiceModel]]  0 instance 01f148f0 behaviors
        //6fc84be8  40028c4        8        System.String  0 instance 01ed93a4 configurationName
        //018485d0  40028c5        c ...ndpointCollection  0 instance 01f14938 endpoints
        //6fc875ac  40028c6       10          System.Type  0 instance 00000000 serviceType
        //0180bec8  40028c7       14 ...scription.XmlName  0 instance 01f149a8 serviceName
        //6fc84be8  40028c8       18        System.String  0 instance 01ee07d0 serviceNamespace

        System_ServiceModel_Description_ServiceDescription(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            ServiceName = (System_String)Fields["serviceName"].ToObject();
            ServiceNamespace = (System_String)Fields["serviceNamespace"].ToObject();
            Endpoints = (System_Collections_Generic_List)Fields["endpoints"].Fields["items"].ToObject();
        }

        public System_String ServiceName { get; private set; }
        public System_String ServiceNamespace { get; private set; }
        public System_Collections_Generic_List Endpoints { get; private set; }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.ServiceModel.Description.ServiceDescription")
            {
                return new System_ServiceModel_Description_ServiceDescription(address, properties, fields, output);
            }
            return null;
        }
    }
}
