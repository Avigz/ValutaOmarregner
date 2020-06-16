using System;
using System.IO;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            TcpClient socket = new TcpClient("localhost", 7000);
            while (true)
            {


                Stream ns = socket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string message = Console.ReadLine();
                sw.WriteLine(message);
                string line = sr.ReadLine();

                Console.WriteLine(line);
            }


        }
    }
}
