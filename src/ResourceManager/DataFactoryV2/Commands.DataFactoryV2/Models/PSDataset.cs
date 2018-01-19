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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSDataset : AdfSubResource
    {
        private DatasetResource dataset;

        public PSDataset()
        {
            this.dataset = new DatasetResource() { Properties = new Dataset() };
        }

        public PSDataset(DatasetResource dataset, string resourceGroupName, string factoryName)
        {
            if (dataset == null)
            {
                throw new ArgumentNullException("dataset");
            }

            if (dataset.Properties == null)
            {
                dataset.Properties = new Dataset();
            }

            this.dataset = dataset;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public override string Name
        {
            get
            {
                return this.dataset.Name;
            }
        }

        public object Structure
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

        public Dataset Properties
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

        public override string Id
        {
            get
            {
                return this.dataset.Id;
            }
        }

        public override string ETag
        {
            get
            {
                return this.dataset.Etag;
            }
        }
    }
}
