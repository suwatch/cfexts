using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory : System_Object
    {
        //Name:        System.ServiceModel.Activities.Dispatcher.PersistenceProviderDirectory
        //MethodTable: 558bc638
        //EEClass:     5576d394
        //Size:        56(0x38) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //00000000  400010f        4                       0 instance 021ad2fc workflowDefinition
        //558bc81c  4000110        8 ...rkflowServiceHost  0 instance 021ad98c serviceHost
        //00000000  4000111        c                       0 instance 0220a80c store
        //00000000  4000112       10                       0 instance 0234b900 owner
        //00000000  4000113       14                       0 instance 02365b28 keyMap
        //558bd8f0  4000114       18 ...+InstanceThrottle  0 instance 02365a3c throttle
        //00000000  4000115       1c                       0 instance 02365b5c instanceCache
        //00000000  4000116       20                       0 instance 02365ac4 pipelinesInUse
        //6f92a434  4000117       30       System.Boolean  1 instance        0 aborted
        //00000000  4000118       24                       0 instance 021c0390 <InstanceMetadataChanges>k__BackingField
        //558aff08  4000119       28         System.Int32  1 instance        0 <ConsistencyScope>k__BackingField

        static EEClass persistenceProviderDirectoryClass;

        System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        public EEField ServiceHost { get { return Fields["serviceHost"]; } }
        public EEField WorkflowDefinition { get { return Fields["workflowDefinition"]; } }

        public System_Collections_Generic_Dictionary InstanceCache { get; private set; }
        public System_Collections_Generic_Dictionary KeyMap { get; private set; }

        void Init()
        {
            InstanceCache = (System_Collections_Generic_Dictionary)Fields["instanceCache"].ToObject();
            KeyMap = (System_Collections_Generic_Dictionary)Fields["keyMap"].ToObject();
        }

        public static EEClass PersistenceProviderDirectoryClass
        {
            get
            {
                if (persistenceProviderDirectoryClass == null)
                {
                    //if (ExtensionApis.IsModuleLoaded("System_ServiceModel"))
                    {
                        try
                        {
                            EEMethodTable mt = EEMethodTable.Dump("System.ServiceModel.Activities.dll", "System.ServiceModel.Activities.Dispatcher.PersistenceProviderDirectory");
                            persistenceProviderDirectoryClass = cfexts.EEClass.Dump(mt.EEClass);
                        }
                        catch (ExtensionApis.NotLoadedYetException)
                        {
                        }
                    }
                }
                return persistenceProviderDirectoryClass;
            }
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.ServiceModel.Activities.Dispatcher.PersistenceProviderDirectory")
            {
                return new System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory(address, properties, fields, output);
            }
            return null;
        }

        public static List<System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory> DumpPPDs()
        {
            List<System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory> ppds = new List<System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory>();
            if (PersistenceProviderDirectoryClass != null)
            {
                EEHeap heap = EEHeap.Dump("-type System.ServiceModel.Activities.Dispatcher.PersistenceProviderDirectory");
                foreach (KeyValuePair<string, List<string>> pair in heap.Objects)
                {
                    EEMethodTable mt = cfexts.EEMethodTable.Dump(pair.Key);
                    EEClass cls = cfexts.EEClass.Dump(mt.EEClass);
                    if (PersistenceProviderDirectoryClass.IsAssignableFrom(cls))
                    {
                        foreach (string address in pair.Value)
                        {
                            ppds.Add((System_ServiceModel_Activities_Dispatcher_PersistenceProviderDirectory)System_Object.Dump(address));
                        }
                    }
                }
            }
            return ppds;
        }

        protected override string ToOutputString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(String.Format("TypeName:        {0}", TypeName));
            strb.AppendLine(String.Format("Address:         {0}", Address));
            strb.AppendLine();
            strb.AppendLine(String.Format("InstanceCache:"));
            strb.AppendLine(String.Format("=============="));
            for (int i = 0 ; i < this.InstanceCache.Entries.Count ; ++i)
            {
                System_Collections_Generic_Dictionary.Entry entry = this.InstanceCache.Entries[i];
                strb.AppendLine(String.Format("Instance[{0}]", i));
                strb.AppendLine(String.Format("InstanceId:      {0}", entry.Key.ToObject()));
                strb.AppendLine(entry.Value.ToObject().ToString(false));
            }
            strb.AppendLine(String.Format("Total: {0} instances.", this.InstanceCache.Entries.Count));
            strb.AppendLine(String.Format("KeyMap:"));
            strb.AppendLine(String.Format("======="));
            for (int i = 0 ; i < this.KeyMap.Entries.Count ; ++i)
            {
                System_Collections_Generic_Dictionary.Entry entry = this.KeyMap.Entries[i];
                strb.AppendLine(String.Format("Key[{0}]", i));
                strb.AppendLine(String.Format("InstanceKey:     {0}", entry.Key.ToObject()));
                strb.AppendLine(entry.Value.ToObject().ToString(false));
            }
            strb.AppendLine(String.Format("Total: {0} keys.", this.KeyMap.Entries.Count));
            return strb.ToString();
        }
    }
}
