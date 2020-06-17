using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficOnRoute
{
    public class Node
    {
        public Point node { get; set; }
        public double speed { get; set; }
        public Node(Point _point, double _speed)
        {
            node = _point;
            speed = _speed;
        }
    }
}
