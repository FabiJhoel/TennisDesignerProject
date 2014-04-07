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
            parseConnection.uploadDesign(pDesign);
        }

        public async Task<List<string>> getDesignList()
        {
            return await parseConnection.getDesignList();
        }

        public async Task<Design> getDesign(string pName)
        {
            return await parseConnection.getDesign(pName);
        }
    }
}
