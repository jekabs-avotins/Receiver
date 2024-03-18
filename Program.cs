using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11001);
            UdpClient udpClient = new UdpClient(endPoint);

            Console.WriteLine("Receiver is running. Waiting for a message.");

            
            while (true)
            {
                byte[] receivedBytes = udpClient.Receive(ref endPoint);
                string receivedText = Encoding.ASCII.GetString(receivedBytes);
                Console.WriteLine($"Received message: {receivedText}");

                if (receivedText.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Receiver closed.");
                    break;
                }

            }
            
            
            
        }
    }
}




