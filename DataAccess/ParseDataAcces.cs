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
                {"Name",pDesign.getName()},{"Date",pDesign.getCreationDate()}
            };
            await bond.SaveAsync();
        }
    }
}
