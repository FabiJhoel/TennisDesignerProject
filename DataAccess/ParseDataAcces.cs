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
            };
            await bond.SaveAsync();
        }
        public async void getDesign(string pName)
        {
            var query = from design in ParseObject.GetQuery("Design")
                        where design.Get<string>("Name") == pName
                        select design;
            IEnumerable<ParseObject> results = await query.FindAsync();
            objectDownloaded = results.First();
        }
    }
}
