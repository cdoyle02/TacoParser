using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");
            if(lines.Length == 0)
            {
                logger.LogError("There are 0 lines.", null);
            }
            if(lines.Length == 1)
            {
                logger.LogWarning("There is only 1 line.");
            }

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tb1 = new TacoBell();
            ITrackable tb2 = new TacoBell();

            double distance1 = 0.00;
            

            for(int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = locA.Location;
                GeoCoordinate loc1 = new GeoCoordinate(corA.Latitude, corA.Longitude);
                for(int j = locations.Length - 1; j >= 1; j--)
                {
                    var locB = locations[j];
                    var corB = locB.Location;
                    GeoCoordinate loc2 = new GeoCoordinate(corB.Latitude, corB.Longitude);
                    double distance = loc2.GetDistanceTo(loc1);
                    if(distance1 < distance)
                    {
                        distance1 = distance;
                        tb1 = locA;
                        tb2 = locB;
                    }
                }

            }
            Console.WriteLine($"The distance between {tb1.Name} and {tb2.Name} is {distance1}"); 
        }
    }
}