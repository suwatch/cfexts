using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class EEField
    {
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6ef8d0e8  4002492      65c           System.Uri  0   static 00000000 EmptyUri
        //558bda2c  40000db       84 ...iceHostExtensions  0 instance           workflowExtensions
        //558bc5fc  40000dc       88 ...leInstanceManager  0 instance           durableInstanceManager
        //00000000  40000dd       8c                       0 instance           activity
        const string noValueRegExPattern = "(?<MT>[0-9a-f]+)"
            + " (?<Field>.{8})"
            + " (?<Offset>.{8})"
            + " (?<Type>.{20})"
            + "  (?<VT>[01])"
            + " (?<Attr>.{8})"
            + " +(?<Name>.+)";

        const string regExPattern = "(?<MT>[0-9a-f]+)"
            + " (?<Field>.{8})"
            + " (?<Offset>.{8})"
            + " (?<Type>.{20})"
            + "  (?<VT>[01])"
            + " (?<Attr>.{8})"
            + " +(?<Value>[^ ]*)"
            + " (?<Name>.+)";

        //<InstanceMetadataChanges>k__BackingField
        const string backingFieldNameRegExPattern = "[<](?<Name>[^>]+)[>]k__BackingField";

        Match match;
        System_Object obj;

        EEField(Match match)
        {
            this.match = match;
            Init();
        }

        void Init()
        {
            string name = this.match.Groups["Name"].Value.Trim();
            Match m = ExtensionApis.NewRegex(backingFieldNameRegExPattern).Match(name);
            if (m.Success)
            {
                name = m.Groups["Name"].Value;
            }
            this.Name = name;
        }

        public string MethodTable { get { return this.match.Groups["MT"].Value.Trim(); } }
        public string Field { get { return this.match.Groups["Field"].Value.Trim(); } }
        public string Offset { get { return this.match.Groups["Offset"].Value.Trim(); } }
        public string VT { get { return this.match.Groups["VT"].Value.Trim(); } }
        public string Type { get { return this.match.Groups["Type"].Value.Trim(); } }
        public string Attr { get { return this.match.Groups["Attr"].Value.Trim(); } }
        public string Name { get; private set; }
        public string Value { get { return this.match.Groups["Value"].Value.Trim(); } }

        public bool IsNull { get { return System_Object.IsNullAddress(Value); } }
        public bool HasValue { get { return !String.IsNullOrEmpty(Value); } }

        public Dictionary<string, EEField> Fields
        {
            get
            {
                if (IsNull)
                {
                    Console.WriteLine("Field " + Name + " has a null value!");
                }
                else if (!HasValue)
                {
                    Console.WriteLine("Field " + Name + " has no value!");
                }

                if (this.obj == null)
                {
                    this.obj = ToObject();
                }
                return this.obj.Fields;
            }
        }

        public static EEField Parse(string text)
        {
            string valueAndName = text.Substring(text.IndexOf(" instance ") + 10).Trim();
            string pattern = !valueAndName.Contains(" ") ? noValueRegExPattern : regExPattern;
            Match match = ExtensionApis.NewRegex(pattern).Match(text);
            if (!match.Success)
            {
                throw ExtensionApis.ThrowExceptionHelper(pattern, text, (string)null);
            }
            return new EEField(match);
        }

        public System_Object ToObject()
        {
            if (this.VT == "1")
            {
                return System_Object.DumpVC(this.Value, this.MethodTable);
            }
            else
            {
                return System_Object.Dump(this.Value);
            }
        }
    }
}
