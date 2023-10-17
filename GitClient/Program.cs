using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitClient
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpClient client2 = new TcpClient();

            client2.Connect("127.0.0.1", 49149);

            NetworkStream stream = client2.GetStream();

            BinaryReader sr = new BinaryReader(stream);

            BinaryWriter sw = new BinaryWriter(stream);

            bool end = false;

            while (end == false)
            {

                try
                {

                    string Escrit = sr.ReadLine();
                    Console.WriteLine("Dani: " + Escrit);

                    string Escrit2 = Console.ReadLine();
                    sw.WriteLine(Escrit2);
                    sw.Flush();
                    Console.WriteLine("Xavi: " + Escrit2);

                }
                catch (Exception e)
                {
                    end = true;
                }

            }

        }
    }
}
