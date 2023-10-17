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
                    switch (Escrit)
                    {
                        case 4:
                            int msgI = sr.ReadInt32();
                            Console.WriteLine("Dani envia un int: " + msgI);
                            break;
                        case 1:
                            byte msgB = sr.ReadByte();
                            Console.WriteLine("Dani envia un byte: " + msgB);
                            break;
                        case 2:
                            short msgS = sr.ReadInt16();
                            Console.WriteLine("Dani envia un short: " + msgS);
                            break;
                    }

                    string Escrit2 = Console.ReadLine();

                    switch (Escrit2)
                    {
                        default:
                            Console.WriteLine();
                            break;
                        case "int":
                            byte sizei = 4;
                            sw.Write(sizei);
                            int msgi = 69;
                            sw.Write(msgi);
                            break;
                        case "byte":
                            byte sizeb = 1;
                            sw.Write(sizeb);
                            byte msgb = 255;
                            sw.Write(msgb);
                            break;
                        case "short":
                            byte sizes = 2;
                            sw.Write(sizes);
                            short msgs = 33;
                            sw.Write(msgs);
                            break;
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
