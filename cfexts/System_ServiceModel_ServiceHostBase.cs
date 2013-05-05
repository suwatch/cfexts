using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_ServiceModel_ServiceHostBase : System_Object
    {
        //Name:        System.ServiceModel.Activities.WorkflowServiceHost
        //MethodTable: 558bc81c
        //EEClass:     5576d454
        //Size:        204(0xcc) bytes
        //File:        C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Ac
        //tivities.dll
        //Fields:
        //      MT    Field   Offset                 Type VT     Attr    Value Name
        //6f92a434  4000072       30       System.Boolean  1 instance        0 aborted
        //6f92a434  4000073       31       System.Boolean  1 instance        0 closeCalled
        //6f92f374  4000074        4 ...ostics.StackTrace  0 instance 00000000 closeStack
        //6f92f374  4000075        8 ...ostics.StackTrace  0 instance 00000000 faultedStack
        //6b9dc720  4000076        c ...ct+ExceptionQueue  0 instance 00000000 exceptionQueue
        //6f9245a8  4000077       10        System.Object  0 instance 01fc0930 mutex
        //6f92a434  4000078       32       System.Boolean  1 instance        0 onClosingCalled
        //6f92a434  4000079       33       System.Boolean  1 instance        0 onClosedCalled
        //6f92a434  400007a       34       System.Boolean  1 instance        1 onOpeningCalled
        //6f92a434  400007b       35       System.Boolean  1 instance        1 onOpenedCalled
        //6f92a434  400007c       36       System.Boolean  1 instance        0 raisedClosed
        //6f92a434  400007d       37       System.Boolean  1 instance        0 raisedClosing
        //6f92a434  400007e       38       System.Boolean  1 instance        0 raisedFaulted
        //6f92a434  400007f       39       System.Boolean  1 instance        0 traceOpenAndClose
        //6f9245a8  4000080       14        System.Object  0 instance 01fc0844 eventSender
        //6b93193c  4000081       2c         System.Int32  1 instance        2 state
        //6f92d52c  4000082       18  System.EventHandler  0 instance 00000000 Closed
        //6f92d52c  4000083       1c  System.EventHandler  0 instance 00000000 Closing
        //6f92d52c  4000084       20  System.EventHandler  0 instance 01fdaa7c Faulted
        //6f92d52c  4000085       24  System.EventHandler  0 instance 00000000 Opened
        //6f92d52c  4000086       28  System.EventHandler  0 instance 00000000 Opening
        //6f92a434  4002493       3a       System.Boolean  1 instance        1 initializeDescriptionHasFinished
        //6b9da74c  4002494       3c ...meKeyedCollection  0 instance 01fda778 baseAddresses
        //6b9da830  4002495       40 ...patcherCollection  0 instance 01fda7c0 channelDispatchers
        //6f92b120  4002496       74      System.TimeSpan  1 instance 01fc08b8 closeTimeout
        //6b9d5744  4002497       44 ...erviceDescription  0 instance 01ff4568 description
        //6ba32ac0  4002498       48 ...em.ServiceModel]]  0 instance 01fda7fc extensions
        //00000000  4002499       4c                       0 instance 02006934 externalBaseAddresses
        //6b98b084  400249a       50 ...em.ServiceModel]]  0 instance 01fdaffc implementedContracts
        //6b96db18  400249b       54 ...nceContextManager  0 instance 01fda838 instances
        //6f92b120  400249c       7c      System.TimeSpan  1 instance 01fc08c0 openTimeout
        //6b9ebcc0  400249d       58 ...manceCountersBase  0 instance 0200685c servicePerformanceCounters
        //6b9e2fdc  400249e       5c ...rformanceCounters  0 instance 00000000 defaultPerformanceCounters
        //6b9da91c  400249f       60 ...r.ServiceThrottle  0 instance 01fda860 serviceThrottle
        //6b9dab94  40024a0       64 ...erviceCredentials  0 instance 00000000 readOnlyCredentials
        //6b9dac0c  40024a1       68 ...orizationBehavior  0 instance 0205b550 readOnlyAuthorization
        //6b9dac6c  40024a2       6c ...nticationBehavior  0 instance 0205b56c readOnlyAuthentication
        //6b94a2bc  40024a3       70 ...em.ServiceModel]]  0 instance 00000000 UnknownMessageReceived
        //6ef8d0e8  4002492      65c           System.Uri  0   static 00000000 EmptyUri
        //558bda2c  40000db       84 ...iceHostExtensions  0 instance 01fdaadc workflowExtensions
        //558bc5fc  40000dc       88 ...leInstanceManager  0 instance 01ff5cbc durableInstanceManager
        //00000000  40000dd       8c                       0 instance 01fbd2f4 activity
        //558ba33c  40000de       90 ...s.WorkflowService  0 instance 01fc0698 serviceDefinition
        //00000000  40000df       94                       0 instance 01ff2434 inferredContracts
        //00000000  40000e0       98                       0 instance 01ff23dc correlationQueries
        //558b3924  40000e1       a0         System.Int32  1 instance        0 unhandledExceptionAction
        //6f92b120  40000e2       a8      System.TimeSpan  1 instance 01fc08ec idleTimeToPersist
        //6f92b120  40000e3       b0      System.TimeSpan  1 instance 01fc08f4 idleTimeToUnload
        //6f92b120  40000e4       b8      System.TimeSpan  1 instance 01fc08fc <PersistTimeout>k__BackingField
        //6f92b120  40000e5       c0      System.TimeSpan  1 instance 01fc0904 <TrackTimeout>k__BackingField
        //5005b114  40000e6       9c ...em.Xml.Linq.XName  0 instance 01fc07f4 <ServiceName>k__BackingField
        //6f92a434  40000e7       a4       System.Boolean  1 instance        0 <IsLoadTransactionRequired>k__BackingField
        //5005b114  40000d4       84 ...em.Xml.Linq.XName  0   static 01ff5c78 mexContractXName
        //6f9275ac  40000d5       88          System.Type  0   static 01ff4674 mexBehaviorType
        //6f92b120  40000d6       7c      System.TimeSpan  1   static 02fb47d0 defaultPersistTimeout
        //6f92b120  40000d7       80      System.TimeSpan  1   static 02fb47d4 defaultTrackTimeout
        //6f9275ac  40000d8       8c          System.Type  0   static 01fbcfe4 baseActivityType
        //6f9275ac  40000d9       90          System.Type  0   static 01ff5c8c correlationQueryBehaviorType
        //6f9275ac  40000da       94          System.Type  0   static 01ff5ca4 bufferedReceiveServiceBehaviorType

        static EEClass serviceHostBaseClass = null;

        System_ServiceModel_ServiceHostBase(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
            : base(address, properties, fields, output)
        {
            Init();
        }

        void Init()
        {
            State = (System_ServiceModel_CommunicationState)Int32.Parse(Fields["state"].Value);
            Aborted = Fields["aborted"].Value != "0";
            System_Object uriCollection = Fields["baseAddresses"].ToObject();
            BaseAddresses = (System_Collections_Generic_List)uriCollection.Fields["items"].ToObject();
            Description = (System_ServiceModel_Description_ServiceDescription)Fields["description"].ToObject();
        }

        static EEClass BaseEEClass
        {
            get
            {
                if (serviceHostBaseClass == null)
                {
                    //if (ExtensionApis.IsModuleLoaded("System_ServiceModel"))
                    {
                        try
                        {
                            EEMethodTable mt = EEMethodTable.Dump("System.ServiceModel.dll", "System.ServiceModel.ServiceHostBase");
                            serviceHostBaseClass = cfexts.EEClass.Dump(mt.EEClass);
                        }
                        catch (ExtensionApis.NotLoadedYetException)
                        {
                        }
                    }
                }
                return serviceHostBaseClass;
            }
        }

        public System_ServiceModel_CommunicationState State { get; private set; }
        public bool Aborted { get; private set; }
        public System_Collections_Generic_List BaseAddresses { get; private set; }
        public System_ServiceModel_Description_ServiceDescription Description { get; private set; }

        public static System_Object TryCreate(string address, Dictionary<string, string> properties, Dictionary<string, EEField> fields, StreamReader output)
        {
            if (BaseEEClass != null && BaseEEClass.IsAssignableFrom(cfexts.EEClass.Dump(properties["EEClass"])))
            {
                return new System_ServiceModel_ServiceHostBase(address, properties, fields, output);
            }
            return null;
        }


        public static List<System_ServiceModel_ServiceHostBase> DumpServiceHosts()
        {
            List<System_ServiceModel_ServiceHostBase> serviceHosts = new List<System_ServiceModel_ServiceHostBase>();
            if (BaseEEClass != null)
            {
                // Assumption is all derived classes named with ServiceHost token.
                EEHeap heap = EEHeap.Dump("-type ServiceHost");
                foreach (KeyValuePair<string, List<string>> pair in heap.Objects)
                {
                    EEMethodTable mt = cfexts.EEMethodTable.Dump(pair.Key);
                    EEClass cls = cfexts.EEClass.Dump(mt.EEClass);
                    if (BaseEEClass.IsAssignableFrom(cls))
                    {
                        foreach (string address in pair.Value)
                        {
                            serviceHosts.Add((System_ServiceModel_ServiceHostBase)System_Object.Dump(address));
                        }
                    }
                }
            }
            return serviceHosts;
        }

        protected override string ToOutputString()
        {
            StringBuilder strb = new StringBuilder();
            strb.AppendLine(String.Format("TypeName:        {0}", TypeName));
            strb.AppendLine(String.Format("Address:         {0}", Address));
            strb.AppendLine(String.Format("State:           {0}", State));
            strb.AppendLine(String.Format("Aborted:         {0}", Aborted));
            for (int i = 0; i < BaseAddresses.Count; ++i)
            {
                System_Uri uri = (System_Uri)BaseAddresses.Items.GetObject(i.ToString());
                strb.AppendLine(String.Format("BaseUris[{0}]:     {1}", i, uri));
            }
            strb.AppendLine(String.Format("ServiceName:     {{{0}}}{1}", Description.ServiceNamespace, Description.ServiceName));
            for (int i = 0; i < Description.Endpoints.Count; ++i)
            {
                System_ServiceModel_Description_ServiceEndpoint endpoint = (System_ServiceModel_Description_ServiceEndpoint)Description.Endpoints.Items.GetObject(i.ToString());
                strb.AppendLine(String.Format("EP[{0}].Uri:       {1}", i, endpoint.Uri));
                strb.AppendLine(String.Format("EP[{0}].Binding:   {1}", i, endpoint.Binding));
                strb.AppendLine(String.Format("EP[{0}].Contract:  {1}", i, endpoint.Contract));
            }
            return strb.ToString();
        }
    }
}
