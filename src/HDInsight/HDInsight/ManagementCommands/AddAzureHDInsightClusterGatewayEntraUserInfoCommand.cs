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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Week = Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightDaysOfWeek;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterGatewayEntraUserInfo"), OutputType(typeof(EntraUserInfo))]
    public class AddAzureHDInsightClusterGatewayEntraUserInfoCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Alias("Id")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the unique object ID of the Entra user or client ID of the enterprise applications.")]
        public string ObjectId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the display name of the Entra user.")]
        public string DisplayName { get; set; }

        [Alias("UserPrincipalName")]
        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the User Principal Name (UPN) of the Entra user. It may be empty in certain cases, such as for enterprise applications.")]
        public string Upn { get; set; }

        #endregion


        public override void ExecuteCmdlet()
        {
            var entraUser = new EntraUserInfo();
            entraUser.ObjectId = ObjectId;
            entraUser.DisplayName = DisplayName;
            entraUser.Upn = Upn;
            WriteObject(entraUser);
        }
    }
}
