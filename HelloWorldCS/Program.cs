using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;

namespace HelloWorldCS
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyService), new Uri("http://localhost:8080/demo"), new Uri("net.tcp://localhost:8081/demo"));
            sh.AddServiceEndpoint(typeof(IHelloService), new BasicHttpBinding(), "HelloService");
            sh.AddServiceEndpoint(typeof(IPurchaseService), new NetTcpBinding(), "PurchaseService");
            sh.Open();
            Console.WriteLine("Service opened!");

            Thread.Sleep(-1);
        }
    }

    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        void Hello(string msg);
    }

    [ServiceContract]
    public interface IPurchaseService
    {
        [OperationContract]
        void Checkout(string msg);
    }

    [ServiceBehavior]
    public class MyService : IHelloService, IPurchaseService
    {
        public void Hello(string msg)
        {
        }

        public void Checkout(string msg)
        {
        }
    }
}
