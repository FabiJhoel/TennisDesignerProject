using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;
using TennisBusiness;
using System.Windows;

namespace DataAccess
{
    class ParseDataAcces
    {
        private static ParseDataAcces parseDataInstance = null;

        protected ParseDataAcces()
        {
            initializeService();
        }

        public static ParseDataAcces getInstance() //SingleTone Implementation
        {
            if (parseDataInstance == null)
                parseDataInstance = new ParseDataAcces();
            return parseDataInstance; 
        }
        
        public void initializeService()
        {
            ParseClient.Initialize("gP8GuldBPgMRplqDnnJaJ6KJgsH92Zh5vZKmukxS", "IHJqchPq13I8m3vWw8B2tbKYyavLpQxvQWHAqQeV");
        }

        public async void uploadDesign(ParseObject bond)
        {
            await bond.SaveAsync();
        }

        public async Task<IEnumerable<ParseObject>> getDesignList()
        {
            var query = ParseObject.GetQuery("Design");
            return await query.FindAsync();
        }

        public async Task<ParseObject> getDesign(string pName)
        {
            var query = from search in ParseObject.GetQuery("Design")
                        where search.Get<string>("Name") == pName
                        select search;

            IEnumerable<ParseObject> resultDesign = await query.FindAsync();

            if (resultDesign.Count() == 0)
                return null;
            else
                return resultDesign.First();
        }

        public async Task<Design> parseObjectToDesign(ParseObject pParseObject)
        {
            Design design = new Design(pParseObject.Get<string>("Name"));
            design.setCreationDate(pParseObject.Get<string>("Date"));

            //Get BasePoints from the object
            design.setBasePoints(await getBasePointsFromParse(pParseObject.Get<IList<ParseObject>>("Points")));

            //Get SegmentA from the object
            design.setSegmentA(await getSegmentFromParse(pParseObject, "SegmentA"));

            //Get SegmentB fromm the object
            design.setSegmentB(await getSegmentFromParse(pParseObject, "SegmentB"));

            return design;
        }

        private async Task<Arc> getSegmentFromParse(ParseObject pParseObject, string key)
        {
            ParseObject parseSegment = await ParseObject.GetQuery("Arc").GetAsync(pParseObject.Get<ParseObject>(key).ObjectId);
            Arc segment = new Arc(parseSegment.Get<double>("AxisX"), parseSegment.Get<double>("AxisY"),
                parseSegment.Get<double>("GridWidth"), parseSegment.Get<double>("GridHeight"));

            return segment;
        }

        private async Task<List<BasePoint>> getBasePointsFromParse(IList<ParseObject> parseBasePoints)
        {
            //Get BasePoints from the object
            ParseQuery<ParseObject> queryBP = ParseObject.GetQuery("BasePoint");
            ParseObject basePoint;
            List<BasePoint> basePoints = new List<BasePoint>();

            foreach (ParseObject tempBasePoint in parseBasePoints)
            {
                basePoint = await queryBP.GetAsync(tempBasePoint.ObjectId);
                basePoints.Add(new BasePoint(basePoint.Get<double>("AxisX"), basePoint.Get<double>("AxisY"), " "));
            }

            return basePoints;
        }

        public void deleteBasePoints(ParseObject pParseObject)
        {
            IList<ParseObject> parseBasePoints = pParseObject.Get<IList<ParseObject>>("Points");

            foreach (ParseObject tempBasePoint in parseBasePoints)
            {
                tempBasePoint.DeleteAsync();
            }
        }

        public void deleteSegment(ParseObject pParseObject)
        {
            pParseObject.DeleteAsync();
        }
    }
}
