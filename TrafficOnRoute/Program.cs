using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrafficOnRoute
{
    class Program
    {

        static void Main(string[] args)
        {
            var time = 5;

            var customRoute = new Route();

            customRoute.MapRoute = new Node[] {
                new Node(new Point(0, 0), 3.0),
                new Node(new Point(5, 7), 5.0),
                new Node(new Point(7, 5), 2.0),
                new Node(new Point(11, 13), 7.0),
                new Node(new Point(15, 6), 0)
            };


            var res = customRoute.GetDistance(5);

        }
    }
}
