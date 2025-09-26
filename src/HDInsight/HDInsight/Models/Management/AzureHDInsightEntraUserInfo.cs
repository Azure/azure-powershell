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

using Microsoft.Azure.Management.HDInsight.Models;
using Newtonsoft.Json;
namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightEntraUserInfo
    {

        public AzureHDInsightEntraUserInfo(EntraUserInfo user)
        {
            this.ObjectId = user.ObjectId;
            this.DisplayName = user.DisplayName;
            this.Upn = user.Upn;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Gets or sets the unique object ID of the Entra user or client ID of the
        /// enterprise applications.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "objectId")]
        public string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the Entra user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the User Principal Name (UPN) of the Entra user. It may be
        /// empty in certain cases, such as for enterprise applications.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "upn")]
        public string Upn { get; set; }
    }
}
