using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class EEClass
    {
        //Class Name:      System.ServiceModel.Channels.CommunicationObject
        //mdToken:         0200001a
        //File:            C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll
        //Parent Class:    6f642398
        //Module:          6a8d1000
        //Method Table:    6b9d67a4
        //Vtable Slots:    2d
        //Total Method Slots:  2e
        //Class Attributes:    100081  Abstract,
        //Transparency:        Transparent
        //NumInstanceFields:   15
        //NumStaticFields:     0
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6f92a434  4000072       30       System.Boolean  1 instance           aborted
        //6f92a434  4000073       31       System.Boolean  1 instance           closeCalled
        //6f92f374  4000074        4 ...ostics.StackTrace  0 instance           closeStack
        //6f92f374  4000075        8 ...ostics.StackTrace  0 instance           faultedStack
        //6b9dc720  4000076        c ...ct+ExceptionQueue  0 instance           exceptionQueue
        //6f9245a8  4000077       10        System.Object  0 instance           mutex
        //6f92a434  4000078       32       System.Boolean  1 instance           onClosingCalled
        //6f92a434  4000079       33       System.Boolean  1 instance           onClosedCalled
        //6f92a434  400007a       34       System.Boolean  1 instance           onOpeningCalled
        //6f92a434  400007b       35       System.Boolean  1 instance           onOpenedCalled
        //6f92a434  400007c       36       System.Boolean  1 instance           raisedClosed
        //6f92a434  400007d       37       System.Boolean  1 instance           raisedClosing
        //6f92a434  400007e       38       System.Boolean  1 instance           raisedFaulted
        //6f92a434  400007f       39       System.Boolean  1 instance           traceOpenAndClose
        //6f9245a8  4000080       14        System.Object  0 instance           eventSender
        //6b93193c  4000081       2c         System.Int32  1 instance           state
        //6f92d52c  4000082       18  System.EventHandler  0 instance           Closed
        //6f92d52c  4000083       1c  System.EventHandler  0 instance           Closing
        //6f92d52c  4000084       20  System.EventHandler  0 instance           Faulted
        //6f92d52c  4000085       24  System.EventHandler  0 instance           Opened
        //6f92d52c  4000086       28  System.EventHandler  0 instance           Opening

        const string header1RegExPattern = " +MT +Field +Offset +Type +VT +Attr +Value +Name";
        static Dictionary<string, EEClass> classes = new Dictionary<string, EEClass>();

        string raw;
        string address;
        Dictionary<string, string> properties;
        Dictionary<string, EEField> fields;

        EEClass(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            this.address = address;
            this.properties = properties;
            this.fields = fields;
            this.raw = ExtensionApis.StreamToString(output);
        }

        public string Address { get { return this.address; } }
        public string Class_Name { get { return this.properties["Class Name"]; } }
        public string Method_Table { get { return this.properties["Method Table"]; } }
        public string Parent_Class { get { return this.properties["Parent Class"]; } }
        public Dictionary<string, EEField> Fields { get { return this.fields; } }

        public override string ToString()
        {
            return this.raw;
        }

        public bool IsAssignableFrom(EEClass c)
        {
            EEClass cur = c;
            while (!System_Object.IsNullAddress(cur.Parent_Class))
            {
                if (this.Address == cur.Address)
                {
                    return true;
                }
                cur = EEClass.Dump(cur.Parent_Class);
            }
            return false;
        }

        public static EEClass Dump(string address)
        {
            EEClass cls = null;
            if (!classes.TryGetValue(address, out cls))
            {
                StreamReader output = ExtensionApis.Execute("!dumpclass {0}", address);
                Dictionary<string, string> properties = null;
                while (!output.EndOfStream)
                {
                    string key;
                    string value;
                    string line = output.ReadLine();
                    if (ExtensionApis.MatchRegex(header1RegExPattern, line))
                    {
                        break;
                    }
                    if (!ExtensionApis.ParseKeyValuePair(line, out key, out value))
                    {
                        throw ExtensionApis.ThrowKeyValueExceptionHelper(line, output);
                    }
                    if (properties == null)
                    {
                        properties = new Dictionary<string, string>();
                    }
                    properties.Add(key, value);
                }
                if (properties == null)
                {
                    throw ExtensionApis.ThrowExceptionHelper(null, null, output);
                }

                Dictionary<string, EEField> fields = new Dictionary<string, EEField>();
                while (!output.EndOfStream)
                {
                    string line = output.ReadLine();
                    //    >> Domain:Value dynamic statics NYI 003a3960:NotInit  <<
                    if (line.Contains(">> Domain:Value") || line.StartsWith("None") || line.Contains(">> Thread"))
                    {
                        continue;
                    }
                    EEField field = EEField.Parse(line);
                    if (!fields.ContainsKey(field.Name))
                    {
                        fields.Add(field.Name, field);
                    }
                    else
                    {
                        fields.Add(field.Name + "_" + field.Offset, field);
                    }
                }
                cls = new EEClass(address, properties, fields, output);
                classes[address] = cls;
            }
            return cls;
        }
    }
}
