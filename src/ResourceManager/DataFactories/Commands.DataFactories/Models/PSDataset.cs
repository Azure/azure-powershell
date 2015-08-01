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
using Microsoft.Azure.Management.DataFactories.Common.Models;
using Microsoft.Azure.Management.DataFactories.Models;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSDataset
    {
        private Table dataset;

        public PSDataset()
        {
            this.dataset = new Table() {Properties = new TableProperties()};
        }

        public PSDataset(Table dataset)
        {
            if (dataset == null)
            {
                throw new ArgumentNullException("dataset");
            }

            if (dataset.Properties == null)
            {
                dataset.Properties = new TableProperties();
            }

            this.dataset = dataset;
        }

        public string DatasetName
        {
            get
            {
                return this.dataset.Name;
            }
            set
            {
                this.dataset.Name = value;
            }
        }
        
        public string ResourceGroupName { get; set; }

        public string DataFactoryName { get; set; }

        public Availability Availability
        {
            get
            {
                return this.dataset.Properties.Availability;
            }
            set
            {
                this.dataset.Properties.Availability = value;
            }
        }

        public TableTypeProperties Location
        {
            get
            {
                return this.dataset.Properties.TypeProperties;
            }
            set
            {
                this.dataset.Properties.TypeProperties = value;
            }
        }

        public Policy Policy
        {
            get
            {
                return this.dataset.Properties.Policy;
            }
            set
            {
                this.dataset.Properties.Policy = value;
            }
        }

        public IList<DataElement> Structure
        {
            get
            {
                return this.dataset.Properties.Structure;
            }
            set
            {
                this.dataset.Properties.Structure = value;
            }
        }

        public TableProperties Properties
        {
            get
            {
                return this.dataset.Properties;
            }
            set
            {
                this.dataset.Properties = value;
            }
        }

        public string ProvisioningState
        {
            get { return Properties == null ? string.Empty : Properties.ProvisioningState; }
        }
    }
}
