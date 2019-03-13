using System.Threading.Tasks;
using Microsoft.Azure.Commands.Kusto.Utilities;
using Microsoft.Azure.Management.Kusto.Models;

namespace Microsoft.Azure.Commands.Kusto.Models
{
    public class PSKustoDatabase
    {
        private readonly Database _database;

        public string Name
        {
            get
            {
                return _database.Name;
            }
        }

        public int SoftDeletePeriodInDays
        {
            get
            {
                return _database.SoftDeletePeriodInDays;
            }
        }

        public int? HotCachePeriodInDays
        {
            get
            {
                return _database.HotCachePeriodInDays;
            }
        }

        public DatabaseStatistics Statistic
        {
            get
            {
                return _database.Statistics;
            }
        }

        public string Id
        {
            get
            {
                return _database.Id;
            }
        }

        public string Location
        {
            get
            {
                return _database.Location;
            }
        }

        public string Type
        {
            get
            {
                return _database.Type;
            }
        }

        public PSKustoDatabase(Database database)
        {
            _database = database;
        }
    }
}
