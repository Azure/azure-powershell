using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSTable
    {
        public PSTable()
        {

        }

        public PSTable(Table table)
        {            
            this.Name = table.Name;
            this.Id = table.Id;
            this.RetentionInDays = table.RetentionInDays;
            //this.IsTroubleshootEnabled = table.IsTroubleshootEnabled; //in the next API version i.e 2020-10-01
            //this.IsTroubleshootingAllowed = table.IsTroubleshootingAllowed; //in the next API version i.e 2020-10-01
            //this.LastTroubleshootDate = table.LastTroubleshootDate; //in the next API version i.e 2020-10-01
        }
        public Table GetTable(PSTable psTable)
        {
            return new Table();
        }

        public string Name { set; get; }

        public string Id { set; get; }

        public int? RetentionInDays { set; get; }

        public bool IsTroubleshootEnabled { set; get; } //in the next API version i.e 2020-10-01

        public bool IsTroubleshootingAllowed { set; get; } //in the next API version i.e 2020-10-01

        public string LastTroubleshootDate { set; get; } //in the next API version i.e 2020-10-01
    }
}
