using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLibrary;

namespace DataAccess
{
    class DataAdministrator
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
        public void getDesign
    }
}
