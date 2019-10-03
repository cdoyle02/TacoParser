namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("Length less than three.", null);
            }
            double test;
            var testLat = double.TryParse(cells[0], out test);
            var testLong = double.TryParse(cells[1], out test);


            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];



            TacoBell tacobell = new TacoBell();
            tacobell.Name = name;
            Point num1 = new Point();
            num1.Longitude = longitude;
            num1.Latitude = latitude;
            if((testLat == false) || (testLong == false))
            {
                logger.LogError("Couldnt Parse.", null);
            }
            tacobell.Location = num1;
            
            return tacobell;
            // Do not fail if one record parsing fails, return null
            //return null; // TODO Implement
            
        }
    }
}