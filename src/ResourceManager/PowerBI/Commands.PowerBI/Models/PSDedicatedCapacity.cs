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
using Microsoft.Azure.Management.PowerBIDedicated.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.PowerBI.Models
{
    public class PSDedicatedCapacity
    {
        private readonly DedicatedCapacity _capacity;

        public PSDedicatedCapacity(DedicatedCapacity capacity)
        {
            _capacity = capacity;
        }

        public List<string> Administrator
        {
            get
            {
                return _capacity.Administration == null
                    ? new List<string>()
                    : new List<string>(_capacity.Administration.Members);
            }
        }
         
        public string State
        {
            get
            {
                return _capacity.State;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return _capacity.ProvisioningState;
            }
        }

        public string Id
        {
            get
            {
                return _capacity.Id;
            }
        }

        public string Name
        {
            get
            {
                return _capacity.Name;
            }
        }

        public string Type
        {
            get
            {
                return _capacity.Type;
            }
        }

        public string Location
        {
            get
            {
                return _capacity.Location;
            }
        }

        public string Sku
        {
            get
            {
                return _capacity.Sku.Name;
            }
        }

        public string Tier
        {
            get
            {
                return _capacity.Sku.Tier;
            }
        }

        public System.Collections.Generic.IDictionary<string, string> Tag
        {
            get
            {
                return _capacity.Tags != null ? new Dictionary<string, string>(_capacity.Tags) : new Dictionary<string, string>();
            }
        }
    }
}
