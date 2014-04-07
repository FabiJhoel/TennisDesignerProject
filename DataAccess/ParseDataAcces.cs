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

        public async Task<List<string>> getDesignList()
        {
            var query = ParseObject.GetQuery("Design");
            IEnumerable<ParseObject> results = await query.FindAsync();

            List<string> nameList = new List<string>();
            foreach (ParseObject tempObject in results)
            {
                nameList.Add(tempObject.Get<string>("Name"));
            }

            return nameList;
        }

        public async Task<Design> getDesign(string pName)
        {
            var query = from search in ParseObject.GetQuery("Design")
                        where search.Get<string>("Name") == pName
                        select search;

            IEnumerable<ParseObject> resultDesign = await query.FindAsync();

            return parseObjectToDesign(resultDesign.First());
        }

        public Design parseObjectToDesign(ParseObject pParseObject)
        {
            Design design = new Design(pParseObject.Get<string>("Name"));
            design.setCreationDate(pParseObject.Get<string>("Date"));

            /*List<ParseObject> pointsList = pParseObject.Get<List<ParseObject>>("Points");
            BasePoint point;

            foreach (ParseObject tempBasePoint in pointsList)
            {
                point = new BasePoint(tempBasePoint.Get<int>("AxisX"), tempBasePoint.Get<int>("AxisY"), " ");
                design.addPoint(point);
            }*/

            return design;
        }
    }
}
