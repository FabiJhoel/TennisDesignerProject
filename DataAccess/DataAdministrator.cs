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
        private static DataAdministrator dataAdminInstance = null;

        protected DataAdministrator()
        {
            parseConnection = ParseDataAcces.getInstance();
        }

        public static DataAdministrator getInstance() //SingleTon Implementation
        {
            if (dataAdminInstance == null)
                dataAdminInstance = new DataAdministrator();
            return dataAdminInstance;
        }

        public async void saveDesign(Design pDesign)
        {
            ParseObject parseObject = await parseConnection.getDesign(pDesign.getName());
            if (parseObject == null)
            {
                parseObject = new ParseObject("Design")
                {
                    {"Name",pDesign.getName()},{"Date",pDesign.getCreationDate()},
                    {"Points",getBasePointsFromDesign(pDesign)}, {"SegmentA",getSegmentFromDesign(pDesign.getSegmentA())}, 
                    {"SegmentB",getSegmentFromDesign(pDesign.getSegmentB())},
                    {"ShoeSole",getDecorationFromDesign(pDesign.getShoeSole())},
                    {"OutLine", getDecorationFromDesign(pDesign.getOutline())},
                    {"Circles", getCirclesFromDesign(pDesign)}
                };
            }
            else
            {
                parseConnection.deleteColletion(parseObject.Get<IList<ParseObject>>("Points"));
                parseObject["Points"] = getBasePointsFromDesign(pDesign);
                
                parseConnection.deleteObject(parseObject.Get<ParseObject>("SegmentA"));
                parseObject["SegmentA"] = getSegmentFromDesign(pDesign.getSegmentA());
                
                parseConnection.deleteObject(parseObject.Get<ParseObject>("SegmentB"));
                parseObject["SegmentB"] = getSegmentFromDesign(pDesign.getSegmentB());

                parseConnection.deleteObject(parseObject.Get<ParseObject>("ShoeSole"));
                parseObject["ShoeSole"] = getDecorationFromDesign(pDesign.getShoeSole());

                parseConnection.deleteObject(parseObject.Get<ParseObject>("OutLine"));
                parseObject["OutLine"] = getDecorationFromDesign(pDesign.getOutline());

                parseConnection.deleteColletion(parseObject.Get<IList<ParseObject>>("Circles"));
                parseObject["Circles"] = getCirclesFromDesign(pDesign);
            }

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

        private ParseObject getDecorationFromDesign(Decoration pDecoration)
        {
            ParseObject decoration = new ParseObject("Decoration")
            {
                {"Color", pDecoration.getColor().ToString()},
                {"Thickness", pDecoration.getThickness()},
                {"Type", pDecoration.getType()}
            };

            return decoration;
        }

        private List<ParseObject> getCirclesFromDesign(Design pDesign)
        {
            List<ParseObject> circleList = new List<ParseObject>();
            ParseObject circle;
            foreach (Circle dCircle in pDesign.getCircleDecorations())
            {
                circle = new ParseObject("Circle")
                {
                    {"Color", dCircle.getColor().ToString()},
                    {"Thickness", dCircle.getThickness()},
                    {"Size", dCircle.getSize()}, {"Filled", dCircle.getFilled()}, 
                    {"AxisX", dCircle.getAxisX()}, {"AxisY", dCircle.getAxisY()}
                };
                circleList.Add(circle);
            }
            return circleList;
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
            ParseObject result = await parseConnection.getDesign(pName);

            if (result == null)
                return null;
            else
                return await parseConnection.parseObjectToDesign(result);
        }
    }
}
