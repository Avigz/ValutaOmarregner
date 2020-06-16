using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPserver
{
        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("press enter to start broadcaster on port 11111");
                Console.ReadLine();
             


                UdpClient udpSender = new UdpClient(0);
                udpSender.EnableBroadcast = true;
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 11111);
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("ready to start press enter again");
                Console.ReadLine();
            string message = "";

                while (true)
                {
                  while(message == null || message == "") {
                    message = udpSender.Receive( ref RemoteIpEndPoint);
                    
                    byte[] sendBytes = Encoding.ASCII.GetBytes();
                    try
                    {
                        Console.WriteLine("sending :");
                        udpSender.Send(sendBytes, sendBytes.Length, endPoint);
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            }
        }
    
}
