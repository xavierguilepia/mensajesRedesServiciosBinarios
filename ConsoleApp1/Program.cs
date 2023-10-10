using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(49149);
            listener.Start();
            TcpClient client1 = listener.AcceptTcpClient();
            NetworkStream ns1 = client1.GetStream();

            StreamReader sr = new StreamReader(ns1);
            StreamWriter sw = new StreamWriter(ns1);

            bool end = false;
 
            while (end == false)
            {
                try
                {
                    string escritura2 = Console.ReadLine();
                    sw.WriteLine(escritura2);
                    sw.Flush();
                    Console.WriteLine("Daniel: " + escritura2);


                    string escritura = sr.ReadLine();
                    Console.WriteLine("Xavi: " + escritura);
                }
                catch(Exception e)
                {
                    end = true;
                }
            }

            listener.Stop();
        }
    }
}
