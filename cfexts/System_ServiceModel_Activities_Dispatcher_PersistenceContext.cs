using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_ServiceModel_Activities_Dispatcher_PersistenceContext : System_Object
    {
        //Name:        System.ServiceModel.Activities.Dispatcher.PersistenceContext
        //MethodTable: 558bcb68
        //EEClass:     5576d65c
        //Size:        136(0x88) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Ac
        //tivities.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6f92a434  4000072       30       System.Boolean  1 instance        0 aborted
        //6f92a434  4000073       31       System.Boolean  1 instance        0 closeCalled
        //6f92f374  4000074        4 ...ostics.StackTrace  0 instance 00000000 closeStack
        //6f92f374  4000075        8 ...ostics.StackTrace  0 instance 00000000 faultedStack
        //6b9dc720  4000076        c ...ct+ExceptionQueue  0 instance 00000000 exceptionQueue
        //6f9245a8  4000077       10        System.Object  0 instance 023e6cac mutex
        //6f92a434  4000078       32       System.Boolean  1 instance        0 onClosingCalled
        //6f92a434  4000079       33       System.Boolean  1 instance        0 onClosedCalled
        //6f92a434  400007a       34       System.Boolean  1 instance        1 onOpeningCalled
        //6f92a434  400007b       35       System.Boolean  1 instance        1 onOpenedCalled
        //6f92a434  400007c       36       System.Boolean  1 instance        0 raisedClosed
        //6f92a434  400007d       37       System.Boolean  1 instance        0 raisedClosing
        //6f92a434  400007e       38       System.Boolean  1 instance        0 raisedFaulted
        //6f92a434  400007f       39       System.Boolean  1 instance        0 traceOpenAndClose
        //6f9245a8  4000080       14        System.Object  0 instance 023e6a38 eventSender
        //6b93193c  4000081       2c         System.Int32  1 instance        2 state
        //6f92d52c  4000082       18  System.EventHandler  0 instance 023eb9e8 Closed
        //6f92d52c  4000083       1c  System.EventHandler  0 instance 00000000 Closing
        //6f92d52c  4000084       20  System.EventHandler  0 instance 00000000 Faulted
        //6f92d52c  4000085       24  System.EventHandler  0 instance 00000000 Opened
        //6f92d52c  4000086       28  System.EventHandler  0 instance 00000000 Opening
        //558bc638  40000ee       3c ...ProviderDirectory  0 instance 022c8708 directory
        //00000000  40000ef       40                       0 instance 0216a80c store
        //00000000  40000f0       44                       0 instance 023d486c handle
        //00000000  40000f1       48                       0 instance 023e6d7c keysToAssociate
        //00000000  40000f2       4c                       0 instance 023e6e04 keysToDisassociate
        //6f92a434  40000f5       3a       System.Boolean  1 instance        0 operationInProgress
        //558bbd5c  40000f6       50 ...owServiceInstance  0 instance 023eb90c workflowInstance
        //6f9263a8  40000f7       68         System.Int32  1 instance        0 lockingTransaction
        //00000000  40000f8       54                       0 instance 00000000 lockingTransactionObject
        //00000000  40000f9       58                       0 instance 023e6e2c transactionWaiterQueue
        //6f92b1c4  40000fa       74          System.Guid  1 instance 023e6aac <InstanceId>k__BackingField
        //6f92a434  40000fb       3b       System.Boolean  1 instance        1 <IsLocked>k__BackingField
        //6f92a434  40000fc       6c       System.Boolean  1 instance        0 <IsInitialized>k__BackingField
        //6f92a434  40000fd       6d       System.Boolean  1 instance        0 <IsCompleted>k__BackingField
        //6f92a434  40000fe       6e       System.Boolean  1 instance        1 <IsVisible>k__BackingField
        //6f92a434  40000ff       6f       System.Boolean  1 instance        1 <IsSuspended>k__BackingField
        //6f924be8  4000100       5c        System.String  0 instance 02404cc0 <SuspendedReason>k__BackingField
        //6f92a434  4000101       70       System.Boolean  1 instance        0 <Detaching>k__BackingField
        //6f92a434  4000102       71       System.Boolean  1 instance        0 <IsPermanentlyRemoved>k__BackingField
        //00000000  4000103       60                       0 instance 023e6cb8 <AssociatedKeys>k__BackingField
        //00000000  4000104       64                       0 instance 00000000 <Bookmarks>k__BackingField
        //00000000  40000ed       a0                       0   static 00000000 Enlistments
        //6f92b120  40000f3       98      System.TimeSpan  1   static 00000000 defaultOpenTimeout
        //6f92b120  40000f4       9c      System.TimeSpan  1   static 00000000 defaultCloseTimeout
        System_ServiceModel_Activities_Dispatcher_PersistenceContext(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        public void Init()
        {
            InstanceId = ((System_Guid)Fields["InstanceId"].ToObject()).Guid;
            IsVisible = Fields["IsVisible"].Value != "0";
        }

        public Guid InstanceId { get; private set; }
        public EEField WorkflowInstance { get { return Fields["workflowInstance"]; } }
        public System_ServiceModel_CommunicationState State { get { return (System_ServiceModel_CommunicationState)Int32.Parse(Fields["state"].Value); } }
        public bool IsVisible { get; private set; }

        protected override string ToOutputString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(String.Format("TypeName:        {0}", TypeName));
            strb.AppendLine(String.Format("Address:         {0}", Address));
            strb.AppendLine(String.Format("InstanceId:      {0}", InstanceId));
            strb.AppendLine(String.Format("WSI:             {0}", WorkflowInstance.Value));
            strb.AppendLine(String.Format("State:           {0}", State));
            return strb.ToString();
        }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (properties["Name"] == "System.ServiceModel.Activities.Dispatcher.PersistenceContext")
            {
                return new System_ServiceModel_Activities_Dispatcher_PersistenceContext(address, properties, fields, output);
            }
            return null;
        }
    }
}
