using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Runtime_AsyncResult : System_Object
    {
        //Name:        System.ServiceModel.Activities.Dispatcher.TransactionWaitAsyncResult
        //MethodTable: 000007ff00ac7348
        //EEClass:     000007ff00b32f50
        //Size:        160(0xa0) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.d
        //ll
        //Fields:
        //              MT    Field   Offset                 Type VT     Attr            Value Name
        //000007fef7fa6570  4000005        8 System.AsyncCallback  0 instance 00000000028d1ef8 callback
        //000007fef7faeea8  4000006       70       System.Boolean  1 instance                0 completedSynchronously
        //000007fef7faeea8  4000007       71       System.Boolean  1 instance                0 endCalled
        //000007fef7fab6f8  4000008       10     System.Exception  0 instance 0000000000000000 exception
        //000007fef7faeea8  4000009       72       System.Boolean  1 instance                0 isCompleted
        //000007ff0081dc78  400000a       18 ...t+AsyncCompletion  0 instance 0000000000000000 nextAsyncCompletion
        //000007fef7f9d548  400000b       20  System.IAsyncResult  0 instance 0000000000000000 deferredTransactionalResult
        //000007ff008c11d0  400000c       28 ...actionSignalScope  0 instance 0000000000000000 transactionContext
        //000007fef7faac48  400000d       30        System.Object  0 instance 00000000030035e0 state
        //000007fef7f99150  400000e       38 ....ManualResetEvent  0 instance 0000000000000000 manualResetEvent
        //000007fef7faac48  400000f       40        System.Object  0 instance 000000000310c9d8 thisLock
        //000007fef7f9c378  4000010       48 ...ostics.StackTrace  0 instance 0000000000000000 endStack
        //000007fef7f9c378  4000011       50 ...ostics.StackTrace  0 instance 0000000000000000 completeStack
        //000007ff006c0e20  4000012       58 ...AsyncResultMarker  0 instance 000000000310c9f0 marker
        //000007ff0081dd98  4000013       60 ...ption, mscorlib]]  0 instance 0000000000000000 <OnCompleting>k__BackingField
        //000007ff00016ea8  4000014       68 ...esult, mscorlib]]  0 instance 0000000000000000 <VirtualCallback>k__BackingField
        //000007fef7fa6570  4000004        8 System.AsyncCallback  0   static 00000000028d1ef8 asyncCompletionWrapperCallback
        //000007fef16b8e70  400011e       78 ...endentTransaction  0 instance 000000000310ca20 dependentTransaction
        //000007ff00727e90  400011f       80 ...ime.IOThreadTimer  0 instance 000000000310caf0 timer
        //000007fef7faac48  4000120       88        System.Object  0 instance 000000000310ca08 thisLock
        //000007ff006a2ff0  4000121       90 ...ersistenceContext  0 instance 00000000031cda48 <PersistenceContext>k__BackingField
        //000007fef7f7c6c8  400011d      168 ...bject, mscorlib]]  0   static 0000000002c10570 timerCallback

        static EEClass asyncResultClass = null;

        System_Runtime_AsyncResult(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            CompletedSynchronously = Fields["completedSynchronously"].Value != "0";
            IsCompleted = Fields["isCompleted"].Value != "0";
        }

        public bool CompletedSynchronously { get; private set; }
        public bool IsCompleted { get; private set; }
        public EEField Exception { get { return Fields["exception"]; } }
        public EEField AsyncState { get { return Fields["state"]; } }

        static EEClass BaseEEClass
        {
            get
            {
                if (asyncResultClass == null)
                {
                    //if (ExtensionApis.IsModuleLoaded("System_Runtime_DurableInstancing"))
                    {
                        try
                        {
                            EEMethodTable mt = EEMethodTable.Dump("System.Runtime.DurableInstancing.dll", "System.Runtime.AsyncResult");
                            asyncResultClass = cfexts.EEClass.Dump(mt.EEClass);
                        }
                        catch (ExtensionApis.NotLoadedYetException)
                        {
                        }
                    }
                }
                return asyncResultClass;
            }
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (BaseEEClass != null && BaseEEClass.IsAssignableFrom(cfexts.EEClass.Dump(properties["EEClass"])))
            {
                return new System_Runtime_AsyncResult(address, properties, fields, output);
            }
            return null;
        }

        //public override string ToString()
        //{
        //    StringBuilder strb = new StringBuilder();
        //    strb.AppendLine(String.Format("TypeName:    {0}", TypeName));
        //    strb.AppendLine(String.Format("Address:     {0}", Address));
        //    strb.AppendLine(String.Format("AsyncState:  {0}", AsyncState.Value));
        //    strb.AppendLine(String.Format("IsCompleted: {0}", IsCompleted));
        //    if (IsCompleted)
        //    {
        //        strb.AppendLine(String.Format("CompletedSyn:{0}", IsCompleted));
        //        strb.AppendLine(String.Format("Exception:   {0}", Exception.Value));
        //    }
        //    return strb.ToString();
        //}

        public static Dictionary<System_Object, List<System_Object>> DumpAsyncResults(bool verbose)
        {
            Dictionary<System_Object, List<System_Object>> chain = new Dictionary<System_Object, List<System_Object>>();
            if (BaseEEClass != null)
            {
                // Assumption is all derived classes named with AsyncResult token.
                EEHeap heap = EEHeap.Dump("-type AsyncResult");
                foreach (KeyValuePair<string, List<string>> pair in heap.Objects)
                {
                    EEMethodTable mt = cfexts.EEMethodTable.Dump(pair.Key);
                    EEClass cls = cfexts.EEClass.Dump(mt.EEClass);
                    if (BaseEEClass.IsAssignableFrom(cls))
                    {
                        if (cls.Class_Name.StartsWith("System.Runtime.CompletedAsyncResult"))
                        {
                            continue;
                        }
                        foreach (string address in pair.Value)
                        {
                            System_Runtime_AsyncResult asyncResult = (System_Runtime_AsyncResult)System_Object.Dump(address);
                            if (chain.ContainsKey(asyncResult))
                            {
                                continue;
                            }
                            if (!verbose && asyncResult.IsCompleted)
                            {
                                continue;
                            }
                            List<System_Object> items = new List<System_Object>();
                            System_Object cur = asyncResult;
                            while (cur != null)
                            {
                                if (ExtensionApis.IsInterrupt())
                                {
                                    return chain;
                                }
                                // found existing chain
                                if (chain.ContainsKey(cur))
                                {
                                    List<System_Object> prev = chain[cur];
                                    bool found = false;
                                    for (int i = 0; i < prev.Count; ++i)
                                    {
                                        if (!found)
                                        {
                                            if (prev[i].Address != cur.Address)
                                            {
                                                continue;
                                            }
                                            found = true;
                                        }
                                        items.Add(prev[i]);
                                    }
                                    break;
                                }
                                items.Add(cur);
                                cur = cur is System_Runtime_AsyncResult ? ((System_Runtime_AsyncResult)cur).AsyncState.ToObject() : null;
                            }
                            foreach (System_Object obj in items)
                            {
                                chain[obj] = items;
                            }
                        }
                    }
                }
            }
            return chain;
        }
    }
}
