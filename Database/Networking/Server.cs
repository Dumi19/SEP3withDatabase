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

                new Thread(() => HandleClientRequest(client)).Start();
                client.Close();
            }
        }

        private static void HandleClientRequest(TcpClient client) {
                NetworkStream stream = client.GetStream();

                Request req = GetObject(stream);
                switch(req.Action){
                    case "Username":{
                        GetUsername(req, stream);
                        break;
                    }
                }
        }

        private static void GetUsername(Request req, NetworkStream stream) {
        User user = new User();
        user.Username = data.getUsername();
        req.Arg = user;
        
        byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {req}");
        stream.Write(dataToClient, 0, dataToClient.Length);
        }

        private static Request GetObject(NetworkStream stream) {
        byte[] dataFromClient = new byte[1024];
        int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
        string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
        Request req = JsonSerializer.Deserialize<Request>(s);
        return req;
        }

    }
}