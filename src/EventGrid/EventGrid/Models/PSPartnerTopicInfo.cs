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

using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSPartnerTopicInfo
    {
        public PSPartnerTopicInfo(PartnerTopicInfo partnerTopicInfo)
        {
            this.ResourceGroupName = partnerTopicInfo.ResourceGroupName;
            this.PartnerTopicInfoName = partnerTopicInfo.Name;
            this.AzureSubscriptionId = partnerTopicInfo.AzureSubscriptionId;
            this.Name = partnerTopicInfo.Name;
            this.EventTypeInfo = new PSEventTypeInfo(partnerTopicInfo.EventTypeInfo);
            this.Source = partnerTopicInfo.Source;

        }

        public string ResourceGroupName { get; set; }

        public string PartnerTopicInfoName { get; set; }

        public string AzureSubscriptionId { get; set; }

        public string Name { get; set; }

        public PSEventTypeInfo EventTypeInfo { get; set; }

        public string Source { get; set; }

        /// <summary>
        /// Return a string representation of this partner Namespace
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
