using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance : System_Object
    {
        //Name:        System.ServiceModel.Activities.Dispatcher.WorkflowServiceInstance
        //MethodTable: 01d79410
        //EEClass:     01de693c
        //Size:        220(0xdc) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Ac
        //tivities.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //01d789fc  400030a       30 ...owInstanceControl  1 instance 021dbc9c controller
        //04e27e1c  400030b        4 ....TrackingProvider  0 instance 00000000 trackingProvider
        //7055dbdc  400030c        8 ...ronizationContext  0 instance 02139798 syncContext
        //01c1d0c0  400030d        c ...erenceEnvironment  0 instance 00000000 hostEnvironment
        //01d787ec  400030e       10 ....ActivityExecutor  0 instance 021dc2fc executor
        //705563a8  400030f       24         System.Int32  1 instance        0 isPerformingOperation
        //7055a434  4000310       28       System.Boolean  1 instance        1 isInitialized
        //01ea6648  4000311       14 ...tensionCollection  0 instance 021dbdf0 extensions
        //7055a434  4000312       29       System.Boolean  1 instance        1 hasTrackedResumed
        //7055a434  4000313       2a       System.Boolean  1 instance        0 hasTrackedCompletion
        //7055a434  4000314       2b       System.Boolean  1 instance        0 isAborted
        //70554e0c  4000315       18     System.Exception  0 instance 00000000 abortedException
        //00000000  4000316       1c                       0 instance 00000000 abortStack
        //7055a434  4000317       2c       System.Boolean  1 instance        0 <HasTrackingParticipant>k__BackingField
        //7055a434  4000318       2d       System.Boolean  1 instance        0 <HasTrackedStarted>k__BackingField
        //7055a434  4000319       2e       System.Boolean  1 instance        1 <HasPersistenceModule>k__BackingField
        //0076947c  400031a       20 ...tivities.Activity  0 instance 01ffb74c <WorkflowDefinition>k__BackingField
        //01ea6230  4000309      1c4 ...stem.Activities]]  0   static 02048d04 EmptyMappedVariablesDictionary
        //04e26fe4  4000033       38 ...flowExecutionLock  0 instance 021dbd8c executorLock
        //01ea9d28  4000034       3c ...ersistenceContext  0 instance 021d76b0 persistenceContext
        //6ea4305c  4000035       40 ...rsistencePipeline  0 instance 00000000 persistencePipelineInUse
        //7055a434  4000036       a4       System.Boolean  1 instance        0 abortingExtensions
        //705563a8  4000037       8c         System.Int32  1 instance        0 activeOperations
        //705545a8  4000038       44        System.Object  0 instance 021dbdb4 activeOperationsLock
        //705563a8  4000039       90         System.Int32  1 instance        3 handlerThreadId
        //7055a434  400003a       a5       System.Boolean  1 instance        0 isInHandler
        //04e2a51c  400003b       48 ... System.Runtime]]  0 instance 021ec870 idleWaiters
        //04e2a51c  400003c       4c ... System.Runtime]]  0 instance 00000000 nextIdleWaiters
        //00000000  400003d       50                       0 instance 00000000 checkCanPersistWaiters
        //6ea41fbc  400003e       54 ...e.AsyncWaitHandle  0 instance 00000000 workflowServiceInstanceReadyWaitHandle
        //7055a434  400003f       a6       System.Boolean  1 instance        1 isWorkflowServiceInstanceReady
        //7055a434  4000040       a7       System.Boolean  1 instance        0 hasRaisedCompleted
        //7055a434  4000041       a8       System.Boolean  1 instance        0 hasPersistedDeleted
        //7055a434  4000042       a9       System.Boolean  1 instance        1 isRunnable
        //01ea3d68  4000043       58 ...redReceiveManager  0 instance 00000000 bufferedReceiveManager
        //01d79348  4000044       94         System.Int32  1 instance        0 state
        //705545a8  4000045       5c        System.Object  0 instance 021dbd68 thisLock
        //00000000  4000046       60 ...ransactionContext  0 instance 00000000 transactionContext
        //7055a434  4000047       aa       System.Boolean  1 instance        0 isInTransaction
        //7055a434  4000048       ab       System.Boolean  1 instance        0 isTransactedCancelled
        //00000000  4000049       64                       0 instance 00000000 pendingOperations
        //705563a8  400004a       98         System.Int32  1 instance        0 pendingOperationCount
        //7055b1c4  400004b       b0          System.Guid  1 instance 021dbd1c instanceId
        //04e26c84  400004c       68 ...odel.Activities]]  0 instance 021dbd74 pendingRequests
        //04e29c40  400004d       6c ...tancePolicyHelper  0 instance 021dc808 unloadInstancePolicy
        //00000000  400004e       70 ...ptionPolicyHelper  0 instance 00000000 unhandledExceptionPolicy
        //705563a8  400004f       9c         System.Int32  1 instance        1 referenceCount
        //6ea436a8  4000050       74 ...dNeutralSemaphore  0 instance 021dbdc0 acquireReferenceSemaphore
        //0076c29c  4000051       78 ...rkflowServiceHost  0 instance 02002c70 serviceHost
        //04e26380  4000052       7c ...owCreationContext  0 instance 00000000 creationContext
        //7055a434  4000053       ac       System.Boolean  1 instance        0 creationContextAborted
        //7054e0cc  4000054       80 ...bject, mscorlib]]  0 instance 00000000 workflowOutputs
        //70554e0c  4000055       84     System.Exception  0 instance 00000000 terminationException
        //01d78734  4000056       a0         System.Int32  1 instance        0 completionState
        //7055b120  4000057       c0      System.TimeSpan  1 instance 021dbd2c persistTimeout
        //7055b120  4000058       c8      System.TimeSpan  1 instance 021dbd34 trackTimeout
        //7055b120  4000059       d0      System.TimeSpan  1 instance 021dbd3c acquireLockTimeout
        //7055a434  400005a       ad       System.Boolean  1 instance        1 hasIncrementedBusyCount
        //04e2707c  400005b       88 ... System.Runtime]]  0 instance 021dc244 <PipelineModules>k__BackingField
        //7055c000  400002d       10 System.AsyncCallback  0   static 00000000 handleEndReleaseInstance
        //6ea42624  400002e       14 ...FastAsyncCallback  0   static 02048c78 lockAcquiredAsyncCallback
        //7055c000  400002f       18 System.AsyncCallback  0   static 00000000 trackCompleteDoneCallback
        //7055c000  4000030       1c System.AsyncCallback  0   static 00000000 trackIdleDoneCallback
        //7055c000  4000031       20 System.AsyncCallback  0   static 00000000 trackUnhandledExceptionDoneCallback
        //01ea5e2c  4000032       24 ...stem.Activities]]  0   static 02048cc0 emptyBookmarkInfoCollection
        //6ea3b1ec  400005c       28 ...olean, mscorlib]]  0   static 020491ec CS$<>9__CachedAnonymousMethodDelegate1

        static EEClass workflowServiceInstanceClass = null;

        System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            InstanceId = ((System_Guid)Fields["instanceId"].ToObject()).Guid;
            WSIState = (State)Int32.Parse(Fields["state"].Value);
            IsAborted = Fields["isAborted"].Value != "0";
            IsExecutorLocked = Fields["executorLock"].Fields["owned"].Value != "0";

            EEField executor = Fields["executor"];
            if (!executor.IsNull)
            {
                ExecutorState = (ActivityInstanceState)Int32.Parse(executor.Fields["executionState"].Value);
                SchedulerIsIdle = executor.Fields["scheduler"].IsNull || (executor.Fields["scheduler"].Fields["firstWorkItem"].ToObject() == null);

                if (!executor.Fields["rootInstance"].IsNull)
                {
                    EEField activity = executor.Fields["rootInstance"].Fields["activity"];
                    System_String displayName = (System_String)activity.Fields["displayName"].ToObject();
                    RootActivity = displayName != null ? displayName.String : activity.Type;
                }

                if (!executor.Fields["bookmarkManager"].IsNull)
                {
                    Bookmarks = (System_Collections_Generic_Dictionary)executor.Fields["bookmarkManager"].Fields["bookmarks"].ToObject();
                }
            }
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.ServiceModel.Activities.Dispatcher.WorkflowServiceInstance")
            {
                return new System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance(address, properties, fields, output);
            }
            return null;
        }

        public Guid InstanceId { get; private set; }
        public bool IsAborted { get; private set; }
        public State WSIState { get; private set; }
        public ActivityInstanceState ExecutorState { get; private set; }
        public bool SchedulerIsIdle { get; private set; }
        public EEField PersistenceContext { get { return Fields["persistenceContext"]; }  }
        public string RootActivity { get; private set; }
        public bool IsExecutorLocked { get; private set; }
        public System_Collections_Generic_Dictionary Bookmarks { get; private set; }
        //public string ExecutingActivity { get; private set; }

        public static EEClass WorkflowServiceInstanceClass
        {
            get
            {
                if (workflowServiceInstanceClass == null)
                {
                    //if (ExtensionApis.IsModuleLoaded("System_ServiceModel_Activities"))
                    {
                        try
                        {
                            EEMethodTable mt = EEMethodTable.Dump("System.ServiceModel.Activities.dll", "System.ServiceModel.Activities.Dispatcher.WorkflowServiceInstance");
                            workflowServiceInstanceClass = cfexts.EEClass.Dump(mt.EEClass);
                        }
                        catch (ExtensionApis.NotLoadedYetException)
                        {
                        }
                    }
                }
                return workflowServiceInstanceClass;
            }
        }

        public static List<System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance> DumpWorkflowServiceInstances()
        {
            List<System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance> wsis = new List<System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance>();
            if (WorkflowServiceInstanceClass != null)
            {
                EEHeap heap = EEHeap.Dump("-type System.ServiceModel.Activities.Dispatcher.WorkflowServiceInstance");
                foreach (KeyValuePair<string, List<string>> pair in heap.Objects)
                {
                    EEMethodTable mt = cfexts.EEMethodTable.Dump(pair.Key);
                    EEClass cls = cfexts.EEClass.Dump(mt.EEClass);
                    if (WorkflowServiceInstanceClass.IsAssignableFrom(cls))
                    {
                        foreach (string address in pair.Value)
                        {
                            wsis.Add((System_ServiceModel_Activities_Dispatcher_WorkflowServiceInstance)System_Object.Dump(address));
                        }
                    }
                }
            }
            return wsis;
        }

        protected override string ToOutputString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(String.Format("TypeName:            {0}", TypeName));
            strb.AppendLine(String.Format("Address:             {0}", Address));
            strb.AppendLine(String.Format("InstanceId:          {0}", InstanceId));
            strb.AppendLine(String.Format("State:               {0}", WSIState));
            strb.AppendLine(String.Format("PersistenceContext:  {0}", PersistenceContext.Value));
            strb.AppendLine(String.Format("ExecutorState:       {0}", ExecutorState));
            strb.AppendLine(String.Format("SchedulerIsIdle:     {0}", SchedulerIsIdle));
            strb.AppendLine(String.Format("IsAborted:           {0}", IsAborted));
            strb.AppendLine(String.Format("IsExecutorLocked:    {0}", IsExecutorLocked));
            strb.AppendLine(String.Format("RootActivity:        {0}", RootActivity));
            //strb.AppendLine(String.Format("ExecutingActivity:   {0}", ExecutingActivity));
            if (Bookmarks != null)
            {
                for (int i = 0; i < Bookmarks.Count; ++i)
                {
                    System_Object bookmark = Bookmarks.Entries[i].Key.ToObject();
                    if (bookmark.Fields["id"].Value != "0")
                    {
                        strb.AppendLine(String.Format("Bookmark[{0}]:         {1}", i, bookmark.Fields["id"].Value));
                    }
                    else
                    {
                        strb.AppendLine(String.Format("Bookmark[{0}]:         {1}", i, bookmark.Fields["externalName"].ToObject()));
                    }
                }
            }
            return strb.ToString();
        }

        public enum State
        {
            Active,
            Aborted,
            Suspended,
            Completed,
            Unloaded
        }

        public enum ActivityInstanceState
        {
            Executing = 0,
            Closed = 1,
            Canceled = 2,
            Faulted = 3
        }
    }
}
