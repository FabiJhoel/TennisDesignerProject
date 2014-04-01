using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;
using TennisLibrary;

namespace DataAccess
{
    class ParseDataAcces
    {
        ParseObject objectDownloaded;
        
        public ParseDataAcces()
        {
            initializeService();
        }

        public void initializeService()
        {
            ParseClient.Initialize("gP8GuldBPgMRplqDnnJaJ6KJgsH92Zh5vZKmukxS", "IHJqchPq13I8m3vWw8B2tbKYyavLpQxvQWHAqQeV");
        }
        public async void uploadDesign(Design pDesign)
        {
            ParseObject bond = new ParseObject("Design")
            {
                {"Name",pDesign.getName()},{"Date",pDesign.getCreationDate()},
                {"Points",getBasePointsFromDesign(pDesign)}
            };
            await bond.SaveAsync();
        }
        private List<ParseObject> getBasePointsFromDesign(Design pDesign)
        {
            List<ParseObject> basePointList = new List<ParseObject>();
            ParseObject point;
            foreach (BasePoint bPoint in pDesign.getBasePoints())
            {
                point = new ParseObject("BasePoint")
                {
                    {"AxisX",bPoint.getAxisX()},
                    {"AxisY",bPoint.getAxisY()}
                };
                basePointList.Add(point);
            }
            return basePointList;
        }

        public async void getDesignList()
        {
            var query = ParseObject.GetQuery("Design");
            IEnumerable<ParseObject> results = await query.FindAsync();
            //objectDownloaded = results.First();
        }
    }
}
