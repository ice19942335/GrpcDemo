﻿using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClientName" });

            //Console.WriteLine("Greeting: " + reply.Message);

            using var customersChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var customersClient = new Customer.CustomerClient(customersChannel);

            var clientRequested = new CustomerLookupModel { UserId = 2 };
            var customer = await customersClient.GetCustomerInfoAsync(clientRequested);

            Console.WriteLine($"{customer.FirstName} {customer.LastName}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
