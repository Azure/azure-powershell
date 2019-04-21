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
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Blueprint.Models;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Blueprint", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.CreateBlueprintBySubscription), OutputType(typeof(PSBlueprint))]
    public class NewAzureRmBlueprint : BlueprintCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidatePattern("^[0-9a-zA-Z_-]*$", Options = RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string BlueprintFile { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            try
            {
                // Resolve path and check if the file exists
                var filePath = ResolveUserPath(BlueprintFile);
                if (filePath == null || new FileInfo(filePath).Exists)
                {
                    throw new FileNotFoundException(string.Format("Add here the path"));
                }
                // To-Do: In good case the JSON file will be deserialized, though it might throw 
                var bp = JsonConvert.DeserializeObject<BlueprintModel>(File.ReadAllText(filePath), DefaultJsonSettings.DeserializerSettings);

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateBlueprintBySubscription:
                        var subScope = Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);
                        RegisterBlueprintRp(SubscriptionId ?? DefaultContext.Subscription.Id); //To-Do: how do we register BP RP if it's MG scope?

                        WriteObject(BlueprintClient.CreateOrUpdateBlueprint(subScope, Name, bp));

                        break;
                    case ParameterSetNames.CreateBlueprintByManagementGroup:
                        var mgScope = Utils.GetScopeForManagementGroup(ManagementGroupId);

                        WriteObject(BlueprintClient.CreateOrUpdateBlueprint(mgScope, Name, bp));
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        #endregion
    }
}
