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

using System.Collections.Generic;
using Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    class PsDeliveryAttribute
    {
        public PsDeliveryAttribute(DeliveryAttributeListResult deliveryAttributeListResult)
        {
            this.DeliveryAttribute = new List<string>();
            if(deliveryAttributeListResult != null && deliveryAttributeListResult.Value != null)
            {
                foreach (DeliveryAttributeMapping deliveryAttributeMapping in deliveryAttributeListResult.Value)
                {
                    this.DeliveryAttribute.Add(deliveryAttributeMapping.Name);
                }
            }
            
        }

        public IList<string> DeliveryAttribute { get; set; }
    }
}
