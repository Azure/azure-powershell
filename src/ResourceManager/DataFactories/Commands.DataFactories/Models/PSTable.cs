// ----------------------------------------------------------------------------------
//
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

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSTable
    {
        private Table table;

        public PSTable()
        {
            table = new Table() {Properties = new TableProperties()};
        }

        public PSTable(Table table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            if (table.Properties == null)
            {
                table.Properties = new TableProperties();
            }

            this.table = table;
        }

        public string TableName
        {
            get
            {
                return table.Name;
            }
            set
            {
                table.Name = value;
            }
        }
        
        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }
        
        public Availability Availability
        {
            get
            {
                return table.Properties.Availability;
            }
            set
            {
                table.Properties.Availability = value;
            }
        }

        public TableLocation Location
        {
            get
            {
                return table.Properties.Location;
            }
            set
            {
                table.Properties.Location = value;
            }
        }

        public Policy Policy
        {
            get
            {
                return table.Properties.Policy;
            }
            set
            {
                table.Properties.Policy = value;
            }
        }

        public IList<DataElement> Structure
        {
            get
            {
                return table.Properties.Structure;
            }
            set
            {
                table.Properties.Structure = value;
            }
        }

        public bool? Published
        {
            get
            {
                return table.Properties.Published;
            }
            set
            {
                table.Properties.Published = value;
            }
        }

        public TableProperties Properties
        {
            get
            {
                return table.Properties;
            }
            set
            {
                table.Properties = value;
            }
        }
    }
}
