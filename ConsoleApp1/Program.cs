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

            BinaryReader sr = new BinaryReader(ns1);
            BinaryWriter sw = new BinaryWriter(ns1);
            bool repet = false;
            bool end = false;
 
            while (end == false)
            {
                try
                {
                    do
                    {
                        repet = false;
                        string escritura2 = Console.ReadLine();
                        switch (escritura2)
                        {
                            case "int":
                                byte size = 4;
                                sw.Write(size);
                                int msg = 2147483647;
                                sw.Write(msg);
                                break;

                            case "byte":
                                size = 1;
                                sw.Write(size);
                                byte msgbb = 255;
                                sw.Write(msgbb);
                                break;
                            case "short":
                                size = 2;
                                sw.Write(size);
                                short msgss = 33;
                                sw.Write(msgss);
                                break;
                            default:
                                Console.WriteLine("eureueruer error de escritura");
                                repet = false;
                                break;
                        }
                    } while (repet == true);
 
                    

                    sw.Flush();
                    Console.WriteLine("Daniel: " + escritura2);

                    byte pe = sr.ReadByte();
                    if (pe == 1)
                    {
                        byte msgb = sr.ReadByte();
                        Console.WriteLine("Xavi byte: " + msgb);

                    }
                    if (pe == 2)
                    {
                        short msgs = sr.ReadInt16();
                        Console.WriteLine("Xavi byte: " + msgs);

                    }
                    if (pe == 4)
                    {
                        int msgi = sr.ReadInt32();
                        Console.WriteLine("Xavi int: " + msgi);
                    }
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
