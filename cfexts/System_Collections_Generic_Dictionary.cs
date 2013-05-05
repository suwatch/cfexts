using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Collections_Generic_Dictionary : System_Object
    {
        //Name:        System.Collections.Generic.Dictionary`2[[System.Guid, mscorlib],[System.ServiceModel.Activities.Dispatcher.PersistenceContext, System.Ser
        //viceModel.Activities]]
        //MethodTable: 000007ff006a3220
        //EEClass:     000007fef7b8a288
        //Size:        88(0x58) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_64\mscorlib\v4.0_4.0.0.0__b77a5c561934e089\mscorlib.dll
        //Fields:
        //              MT    Field   Offset                 Type VT     Attr            Value Name
        //000007fef7fae038  4000be5        8       System.Int32[]  0 instance 0000000002973010 buckets
        //000007fef88d6758  4000be6       10 ...non, mscorlib]][]  0 instance 0000000002973038 entries
        //000007fef7fae0a8  4000be7       40         System.Int32  1 instance                1 count
        //000007fef7fae0a8  4000be8       44         System.Int32  1 instance              161 version
        //000007fef7fae0a8  4000be9       48         System.Int32  1 instance               -1 freeList
        //000007fef7fae0a8  4000bea       4c         System.Int32  1 instance                0 freeCount
        //000007fef88f41c8  4000beb       18 ....Guid, mscorlib]]  0 instance 00000000027990c0 comparer
        //000007fef8954e38  4000bec       20 ...Canon, mscorlib]]  0 instance 0000000000000000 keys
        //000007fef8957a70  4000bed       28 ...Canon, mscorlib]]  0 instance 0000000000000000 values
        //000007fef7faac48  4000bee       30        System.Object  0 instance 0000000000000000 _syncRoot
        //000007fef7fa9300  4000bef       38 ...SerializationInfo  0 instance 0000000000000000 m_siInfo

        System_Collections_Generic_Dictionary(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        public int Count { get; private set; }
        public List<Entry> Entries { get; private set; }
        public EEField Buckets { get { return Fields["buckets"]; } }

        void Init()
        {
            Count = Int32.Parse(Fields["count"].Value) - Int32.Parse(Fields["freeCount"].Value);
            this.Entries = new List<Entry>(Count);
            if (Count > 0)
            {
                System_Array array = (System_Array)Fields["entries"].ToObject();
                foreach (string index in array.Elements.Keys)
                {
                    Entry entry = (Entry)array.GetObject(index);
                    if (entry.IsValid())
                    {
                        this.Entries.Add(entry);
                    }
                }
            }
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"].StartsWith("System.Collections.Generic.Dictionary`2[["))
            {
                return new System_Collections_Generic_Dictionary(address, properties, fields, output);
            }
            return null;
        }

        //public override string ToString()
        //{
        //    StringBuilder strb = new StringBuilder();
        //    strb.AppendLine(String.Format("TypeName:        {0}", TypeName));
        //    strb.AppendLine(String.Format("Address:         {0}", Address));
        //    strb.AppendLine(String.Format("Count:           {0}", Count));
        //    strb.AppendLine();
        //    strb.AppendLine(String.Format("Entries:"));
        //    for (int i = 0 ; i < Entries.Count ; ++i)
        //    {
        //        strb.AppendLine(String.Format("Key{{0}}:          {1}", i, Entries[i].Key.Value));
        //        strb.AppendLine(String.Format("Value{{0}}:        {1}", i, Entries[i].Value.Value));
        //        strb.AppendLine(String.Format("IsValid{{0}}:      {1}", i, Entries[i].IsValid()));
        //    }
        //    return strb.ToString();
        //}

        public class Entry : System_Object
        {
            Entry(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
                : base(address, properties, fields, output)
            {
            }

            public EEField HashCode { get { return Fields["hashCode"]; } }
            public EEField Next { get { return Fields["next"]; } }
            public EEField Key { get { return Fields["key"]; } }
            public EEField Value { get { return Fields["value"]; } }
            public bool IsValid() { return HashCode.Value != "0" && HashCode.Value != "-1"; }


            public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            {
                if (properties["Name"].StartsWith("System.Collections.Generic.Dictionary`2+Entry[["))
                {
                    return new Entry(address, properties, fields, output);
                }
                return null;
            }
        }
    }
}
