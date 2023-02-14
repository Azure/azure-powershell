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

using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataFactories.Models
{
    public class PSDataFactory
    {
        private DataFactory dataFactory;

        public PSDataFactory()
        {
            dataFactory = new DataFactory();
        }

        public PSDataFactory(DataFactory dataFactory)
        {
            if (dataFactory == null)
            {
                throw new ArgumentNullException("dataFactory");
            }

            this.dataFactory = dataFactory;
        }

        public string DataFactoryName
        {
            get
            {
                return dataFactory.Name;
            }
            set
            {
                dataFactory.Name = value;
            }
        }

        public string DataFactoryId
        {
            get
            {
                return dataFactory.Properties == null ? String.Empty : dataFactory.Properties.DataFactoryId;
            }
            internal set
            {
                if (dataFactory.Properties != null)
                {
                    dataFactory.Properties.DataFactoryId = value;
                }
            }
        }

        public string ResourceGroupName { get; set; }

        public string Location
        {
            get
            {
                return dataFactory.Location;
            }
            set
            {
                dataFactory.Location = value;
            }
        }

        public IDictionary<string, string> Tags
        {
            get
            {
                return dataFactory.Tags;
            }
            set
            {
                dataFactory.Tags = value;
            }
        }

        public DataFactoryProperties Properties
        {
            get
            {
                return dataFactory.Properties;
            }
            set
            {
                dataFactory.Properties = value;
            }
        }

        public string ProvisioningState
        {
            get { return Properties == null ? string.Empty : Properties.ProvisioningState; }
        }
    }
}
