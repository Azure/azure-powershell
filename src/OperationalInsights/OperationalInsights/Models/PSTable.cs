// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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

        //public bool IsTroubleshootEnabled { set; get; } //in the next API version i.e 2020-10-01

        //public bool IsTroubleshootingAllowed { set; get; } //in the next API version i.e 2020-10-01

        //public string LastTroubleshootDate { set; get; } //in the next API version i.e 2020-10-01
    }
}
