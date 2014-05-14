using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElmahTestClient.client;

namespace ElmahTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new Service1Client();
            try
            {
                proxy.GetData(4);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
            finally
            {
                proxy.Abort();
            }
            Console.Read();
            
        }
    }
}
