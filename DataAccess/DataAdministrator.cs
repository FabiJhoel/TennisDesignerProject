using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLibrary;
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
            parseConnection.uploadDesign(pDesign);
        }

        public List<string> getDesignList()
        {
            parseConnection.getDesignList();
            return parseConnection.getNameList();
        }
    }
}
