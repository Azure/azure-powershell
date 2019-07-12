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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSDataFactory
    {
        private Factory dataFactory;

        public PSDataFactory()
        {
            dataFactory = new Factory();
        }

        public PSDataFactory(Factory dataFactory, string resourceGroupName)
        {
            if (dataFactory == null)
            {
                throw new ArgumentNullException("dataFactory");
            }

            this.dataFactory = dataFactory;
            this.ResourceGroupName = resourceGroupName;
        }

        public string DataFactoryName
        {
            get
            {
                return dataFactory.Name;
            }
        }

        public string DataFactoryId
        {
            get
            {
                return dataFactory.Id;
            }
        }

        public string ResourceGroupName { get; private set; }

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

        public FactoryIdentity Identity
        {
            get
            {
                return dataFactory.Identity;
            }
            set
            {
                dataFactory.Identity = value;
            }
        }

        public string ProvisioningState
        {
            get { return dataFactory.ProvisioningState; }
        }

        public FactoryRepoConfiguration RepoConfiguration
        {
            get
            {
                return dataFactory.RepoConfiguration;
            }
            set
            {
                dataFactory.RepoConfiguration = value;
            }
        }
    }
}
