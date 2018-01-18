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

using Microsoft.Azure.Management.LocationBasedServices;
using Microsoft.Azure.Management.LocationBasedServices.Models;
using System;
using System.Collections.Generic;
using LocationBasedServicesModels = Microsoft.Azure.Management.LocationBasedServices.Models;

namespace Microsoft.Azure.Commands.LocationBasedServices.Models
{
    public class PSLocationBasedServicesAccountSku
    {
        public PSLocationBasedServicesAccountSku(LocationBasedServicesModels.Sku sku)
        {
            this.Name = sku.Name;
            this.Tier = sku.Tier;
        }

        public string Name { get; private set; }
        public string Tier { get; private set; }
   }
}
