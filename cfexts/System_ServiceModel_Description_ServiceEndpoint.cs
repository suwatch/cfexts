using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_ServiceModel_Description_ServiceEndpoint : System_Object
    {
        //Name:        System.ServiceModel.Description.ServiceEndpoint
        //MethodTable: 0032e540
        //EEClass:     003380bc
        //Size:        52(0x34) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //0032fc10  4002bab        4 ...l.EndpointAddress  0 instance 01f36bc8 address
        //00328cf8  4002bac        8 ....Channels.Binding  0 instance 01ef9c5c binding
        //00a47718  4002bad        c ...ntractDescription  0 instance 01f327cc contract
        //6fbbd0e8  4002bae       10           System.Uri  0 instance 00000000 listenUri
        //0032e488  4002baf       28         System.Int32  1 instance        0 listenUriMode
        //01bed198  4002bb0       14 ...em.ServiceModel]]  0 instance 01f37f84 behaviors
        //70554be8  4002bb1       18        System.String  0 instance 01f4c16c id
        //01afbec8  4002bb2       1c ...scription.XmlName  0 instance 00000000 name
        //7055a434  4002bb3       2c       System.Boolean  1 instance        0 isEndpointFullyConfigured
        //7055a434  4002bb4       2d       System.Boolean  1 instance        0 <IsSystemEndpoint>k__BackingField
        //6fbbd0e8  4002bb5       20           System.Uri  0 instance 00000000 <UnresolvedAddress>k__BackingField
        //6fbbd0e8  4002bb6       24           System.Uri  0 instance 00000000 <UnresolvedListenUri>k__BackingField
        //0:014> !do 01f36bc8
        //Name:        System.ServiceModel.EndpointAddress
        //MethodTable: 0032fc10
        //EEClass:     003388b8
        //Size:        40(0x28) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //01becca0  4002f20        4 ...sHeaderCollection  0 instance 01f4787c headers
        //01beca28  4002f21        8 ....EndpointIdentity  0 instance 00000000 identity
        //6fbbd0e8  4002f22        c           System.Uri  0 instance 01f36aac uri
        //01bef838  4002f23       10 ...ceModel.XmlBuffer  0 instance 00000000 buffer
        //705563a8  4002f24       14         System.Int32  1 instance       -1 extensionSection
        //705563a8  4002f25       18         System.Int32  1 instance       -1 metadataSection
        //705563a8  4002f26       1c         System.Int32  1 instance       -1 pspSection
        //7055a434  4002f27       20       System.Boolean  1 instance        0 isAnonymous
        //7055a434  4002f28       21       System.Boolean  1 instance        0 isNone
        //6fbbd0e8  4002f1d      91c           System.Uri  0   static 01f36c8c anonymousUri
        //6fbbd0e8  4002f1e      920           System.Uri  0   static 01f36d9c noneUri
        //0032fc10  4002f1f      924 ...l.EndpointAddress  0   static 00000000 anonymousAddress
        //0:014> !do 01ef9c5c
        //Name:        System.ServiceModel.WSHttpContextBinding
        //MethodTable: 00329454
        //EEClass:     00336780
        //Size:        96(0x60) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //7055b120  4000063        c      System.TimeSpan  1 instance 01ef9c68 closeTimeout
        //70554be8  4000064        4        System.String  0 instance 01f381fc name
        //70554be8  4000065        8        System.String  0 instance 01ef9d2c namespaceIdentifier
        //7055b120  4000066       14      System.TimeSpan  1 instance 01ef9c70 openTimeout
        //7055b120  4000067       1c      System.TimeSpan  1 instance 01ef9c78 receiveTimeout
        //7055b120  4000068       24      System.TimeSpan  1 instance 01ef9c80 sendTimeout
        //00329080  4000271       48         System.Int32  1 instance        0 messageEncoding
        //00a11d20  4000272       2c ...alReliableSession  0 instance 01efc990 reliableSession
        //00a12988  4000273       30 ...ortBindingElement  0 instance 01efa1b0 httpTransport
        //00a12bc8  4000274       34 ...ortBindingElement  0 instance 01efa200 httpsTransport
        //00a13528  4000275       38 ...ingBindingElement  0 instance 01efafb4 textEncoding
        //00a13934  4000276       3c ...ingBindingElement  0 instance 01efc950 mtomEncoding
        //00a12f0c  4000277       40 ...lowBindingElement  0 instance 01efa254 txFlow
        //00a131e8  4000278       44 ...ionBindingElement  0 instance 01efa280 session
        //00a10ba4  400027a       4c ...el.WSHttpSecurity  0 instance 01ef9cc8 security
        //00a10994  4000279       84 ...geSecurityVersion  0   static 01ef9cbc WSMessageSecurityVersion
        //6fbb39e4  400027b       54         System.Int32  1 instance        1 contextProtectionLevel
        //7055a434  400027c       58       System.Boolean  1 instance        1 contextManagementEnabled
        //6fbbd0e8  400027d       50           System.Uri  0 instance 00000000 <ClientCallbackAddress>k__BackingField
        //0:014> !do 01f327cc
        //Name:        System.ServiceModel.Description.ContractDescription
        //MethodTable: 00a47718
        //EEClass:     00a2c62c
        //Size:        48(0x30) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //705575ac  4002815        4          System.Type  0 instance 00000000 callbackContractType
        //70554be8  4002816        8        System.String  0 instance 01efce24 configurationName
        //705575ac  4002817        c          System.Type  0 instance 00000000 contractType
        //01afbec8  4002818       10 ...scription.XmlName  0 instance 01f32858 name
        //70554be8  4002819       14        System.String  0 instance 01efccf0 ns
        //00a4994c  400281a       18 ...riptionCollection  0 instance 01f32868 operations
        //00a47660  400281b       20         System.Int32  1 instance        0 sessionMode
        //01afb778  400281c       1c ...em.ServiceModel]]  0 instance 01f32810 behaviors
        //6fbb39e4  400281d       24         System.Int32  1 instance        0 protectionLevel
        //7055a434  400281e       28       System.Boolean  1 instance        0 hasProtectionLevel

        static EEClass serviceEndpointClass = null;

        System_ServiceModel_Description_ServiceEndpoint(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            Uri = ((System_String)Fields["address"].Fields["uri"].Fields["m_String"].ToObject()).String;
            System_Object binding = Fields["binding"].ToObject();
            Binding = String.Format("{{{0}}}{1}", binding.Fields["namespaceIdentifier"].ToObject(), binding.Fields["name"].ToObject());
            System_Object contract = Fields["contract"].ToObject();
            Contract = String.Format("{{{0}}}{1}", contract.Fields["ns"].ToObject(), contract.Fields["name"].ToObject());
        }

        static EEClass BaseEEClass
        {
            get
            {
                if (serviceEndpointClass == null)
                {
                    //if (ExtensionApis.IsModuleLoaded("System_ServiceModel"))
                    {
                        try
                        {
                            EEMethodTable mt = EEMethodTable.Dump("System.ServiceModel.dll", "System.ServiceModel.Description.ServiceEndpoint");
                            serviceEndpointClass = cfexts.EEClass.Dump(mt.EEClass);
                        }
                        catch (ExtensionApis.NotLoadedYetException)
                        {
                        }
                    }
                }
                return serviceEndpointClass;
            }
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (BaseEEClass != null && BaseEEClass.IsAssignableFrom(cfexts.EEClass.Dump(properties["EEClass"])))
            {
                return new System_ServiceModel_Description_ServiceEndpoint(address, properties, fields, output);
            }
            return null;
        }

        public string Uri { get; private set; }
        public string Binding { get; private set; }
        public string Contract { get; private set; }
    }
}
