using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ValutaOmregner;
namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opret server
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //Opret adresse eller port
            TcpListener serverSocket = new TcpListener(ip, 7000);
            //starter Server listener
            serverSocket.Start();
            Console.WriteLine("Server Started");

            //While loekke der holder serveren koerende, og ventende paa clienter
            while (true)
            {
                //threading der tillader flere clienter at forbinde
                Task.Run(() =>
                {
                    //Venter på client forbindelse
                    TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                    Console.WriteLine("Client Connected");
                    //kalder metoden DoClient ved forbindelses oprettelse
                    DoClient(connectionSocket);

                });

            }

        }
        //TCP client til modsvar fra server til client
        public static void DoClient(TcpClient socket)
        {
            Stream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            string message = sr.ReadLine();

            while (message != null && message != "")
            {
                //Laver clientens besked om til et array
                string[] messageArray = message.Split(' ');

                //opdeler kommando og parametre
                string param = message.Substring(message.IndexOf(' ') + 1);
                string command = messageArray[0];

                switch (command)
                {
                    case "DKKSEK":
                        
                        sw.WriteLine(param + " DKK omregnet til SEK er: " + Omregn.TilSvenskeKroner(double.Parse(param)));

                        break;
                    case "SEKDKK":

                        sw.WriteLine(param + " SEK omregnet til DKK er: " + Omregn.TilDanskeKroner(double.Parse(param)));

                        break;

                    default:

                        sw.WriteLine("Ugyldig kommando");
                        break;
                }
                message = sr.ReadLine();
            }


            ns.Close();
            socket.Close();


        }
    }
}
