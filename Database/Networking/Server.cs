using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Database.Model;
using Database.DataModel;

namespace Server
{
    class Server{

        private DataModel data = new DataModel();
        public void start(){
            Console.WriteLine("Starting server...");

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 2920);
            listener.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    byte[] dataFromClient = new byte[1024];
                    int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }
                    Request request = (Request)Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                    if("Username".Equals(request.getType())) {
                        String result = data.getUsername();
                        byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {new Request("Username", result)}");
                        stream.Write(dataToClient, 0, dataToClient.Length);
                    }
                }
                client.Close();
            }
        }
             
    }
}