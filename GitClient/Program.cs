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

                    byte Escrit = sr.ReadByte();
                    if (Escrit == 4)
                    {
                        int msg = sr.ReadInt32();
                        Console.WriteLine("Dani envia un int: " + msg);
                    }
                    if (Escrit == 1)
                    {
                        byte msg = sr.ReadByte();
                        Console.WriteLine("Dani envia un byte: " + msg);
                    }
                    if (Escrit == 2)
                    {
                        short msg = sr.ReadInt16();
                        Console.WriteLine("Dani envia un short: " + msg);
                    }

                    string Escrit2 = Console.ReadLine();

                    if (Escrit2 == "int")
                    {
                        byte size = 4;
                        sw.Write(size);
                        int msg = 69;
                        sw.Write(msg);
                    }
                    if (Escrit2 == "byte")
                    {
                        byte size = 1;
                        sw.Write(size);
                        byte msg = 255;
                        sw.Write(msg);
                    }
                    if (Escrit2 == "short")
                    {
                        byte size = 2;
                        sw.Write(size);
                        short msg = 33;
                        sw.Write(msg);
                    }

                    sw.Flush();

                }
                catch (Exception e)
                {
                    end = true;
                }

            }

        }
    }
}
