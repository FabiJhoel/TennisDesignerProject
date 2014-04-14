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
                {"Points",getBasePointsFromDesign(pDesign)}, {"SegmentA",getSegmentFromDesign(pDesign.getSegmentA())}, 
                {"SegmentB",getSegmentFromDesign(pDesign.getSegmentB())}
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

        private ParseObject getSegmentFromDesign(Arc pArc)
        {
            ParseObject arc = new ParseObject("Arc")
            {
                {"AxisX", pArc.getAxisX()}, {"AxisY", pArc.getAxisY()},
                {"GridWidth", pArc.getSegmentContainerWidth()},
                {"GridHeight", pArc.getSegmentContainerHeight()}
            };

            return arc;
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

            Design design = await parseObjectToDesign(resultDesign.First());
            return design;
        }

        public async Task<Design> parseObjectToDesign(ParseObject pParseObject)
        {
            Design design = new Design(pParseObject.Get<string>("Name"));
            design.setCreationDate(pParseObject.Get<string>("Date"));

            //Get BasePoints from the object
            BasePoint point;
            IList<ParseObject> pointsList = pParseObject.Get<IList<ParseObject>>("Points");
            ParseQuery<ParseObject> queryBP = ParseObject.GetQuery("BasePoint");
            ParseObject basePoint;

            foreach (ParseObject tempBasePoint in pointsList)
            {
                basePoint = await queryBP.GetAsync(tempBasePoint.ObjectId);
                point = new BasePoint(basePoint.Get<double>("AxisX"), basePoint.Get<double>("AxisY"), " ");
                design.addPoint(point);
            }

            //Get SegmentA fromm the object
            Arc segmentA;
            ParseQuery<ParseObject> queryS = ParseObject.GetQuery("Arc");
            ParseObject objectA = await queryS.GetAsync(pParseObject.Get<ParseObject>("SegmentA").ObjectId);
            segmentA = new Arc(objectA.Get<double>("AxisX"), objectA.Get<double>("AxisY"));
            segmentA.setSegmentContainerHeight(objectA.Get<double>("GridHeight"));
            segmentA.setSegmentContainerWidth(objectA.Get<double>("GridWidth"));
            //MessageBox.Show("" + objectA.Get<double>("GridWidth"));
            //MessageBox.Show("" + segmentA.getSegmentContainerWidth());
            design.setSegmentA(segmentA);

            //Get SegmentB fromm the object
            Arc segmentB;
            ParseObject objectB = await queryS.GetAsync(pParseObject.Get<ParseObject>("SegmentB").ObjectId);
            segmentB = new Arc(objectB.Get<double>("AxisX"), objectB.Get<double>("AxisY"));
            segmentB.setSegmentContainerHeight(objectB.Get<double>("GridHeight"));
            segmentB.setSegmentContainerWidth(objectB.Get<double>("GridWidth"));
            design.setSegmentB(segmentB);

            return design;
        }
    }
}
