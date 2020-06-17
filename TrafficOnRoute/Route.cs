using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficOnRoute.Program;

namespace TrafficOnRoute
{
    public class Route
    {
        public Node[] MapRoute { get; set; }

        private List<(double, double)> FillData()
        {
            var routeDataDistanceTime = new List<(double, double)>();
            var distance = .0;
            var distanceTime = .0;

            for (int i = 1; i < MapRoute.Length; i++)
            {
                var xLength = Math.Pow((MapRoute[i].node.X - MapRoute[i - 1].node.X), 2);
                var yLength = Math.Pow((MapRoute[i].node.Y - MapRoute[i - 1].node.Y), 2);
                var tempDistance = Math.Sqrt(xLength + yLength);
                distance += tempDistance;
                distanceTime += tempDistance / MapRoute[i - 1].speed;

                routeDataDistanceTime.Add((distance, distanceTime));
            }

            return routeDataDistanceTime;
        }

        public (int FromPoint, int ToPoint, double Distance) GetDistance(int _time)
        {
            var _distanceTimaData = FillData();

            if (_time > _distanceTimaData[_distanceTimaData.Count - 1].Item2)
                return (FromPoint: _distanceTimaData.Count + 1, ToPoint: _distanceTimaData.Count + 1, Distance: _distanceTimaData[_distanceTimaData.Count - 1].Item1);

            if (_time == 0)
                return (FromPoint: 1, ToPoint: 1, Distance: 0);

            for (int i = 0; i < _distanceTimaData.Count; i++)
            {
                if (_time < _distanceTimaData[i].Item2)
                {
                    var dist = _distanceTimaData[i].Item1 - _distanceTimaData[i - 1].Item1;
                    var deltaTime = _time - _distanceTimaData[i - 1].Item2;
                    var distSpeed = dist / (_distanceTimaData[i].Item2 - _distanceTimaData[i - 1].Item2);
                    var sumDist = deltaTime * distSpeed + _distanceTimaData[i - 1].Item1;
                    return (FromPoint: i + 1, ToPoint: i + 2, Distance: sumDist);
                }
            }

            return (FromPoint: -1, ToPoint: -1, Distance: -1);
        }
    }

}
