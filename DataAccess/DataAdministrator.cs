using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisBusiness;
using Parse;

namespace DataAccess
{
    public class DataAdministrator
    {
        private ParseDataAcces parseConnection;

        public DataAdministrator()
        {
            parseConnection = new ParseDataAcces();
        }

        public void saveDesign(Design pDesign)
        {
            ParseObject parseObject = new ParseObject("Design")
            {
                {"Name",pDesign.getName()},{"Date",pDesign.getCreationDate()},
                {"Points",getBasePointsFromDesign(pDesign)}, {"SegmentA",getSegmentFromDesign(pDesign.getSegmentA())}, 
                {"SegmentB",getSegmentFromDesign(pDesign.getSegmentB())}
            };
            parseConnection.uploadDesign(parseObject);
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
            IEnumerable<ParseObject> results = await parseConnection.getDesignList();

            List<string> nameList = new List<string>();
            foreach (ParseObject tempObject in results)
            {
                nameList.Add(tempObject.Get<string>("Name"));
            }

            return nameList;
        }

        public async Task<Design> getDesign(string pName)
        {
            return await parseConnection.getDesign(pName);
        }
    }
}
