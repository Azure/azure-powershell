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
using System.Management.Automation;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Blueprint.Common;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Blueprint", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.CreateBlueprintBySubscription), OutputType(typeof(PSBlueprint))]
    public class NewAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidatePattern("^[0-9a-zA-Z_-]*$", Options = RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintBySubscription, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintByManagementGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

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
                var bp = CreateBlueprint(GetResolvedFilePath());

                RegisterBlueprintRp(SubscriptionId ?? DefaultContext.Subscription.Id);

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateBlueprintBySubscription:
                        var subScope = Utils.GetScopeForSubscription(SubscriptionId ?? DefaultContext.Subscription.Id);

                        ThrowIfBlueprintExits(subScope, Name);

                        WriteObject(BlueprintClient.CreateOrUpdateBlueprint(subScope, Name, bp));
                        break;
                    case ParameterSetNames.CreateBlueprintByManagementGroup:
                        var mgScope = Utils.GetScopeForManagementGroup(ManagementGroupId);

                        ThrowIfBlueprintExits(mgScope, Name);

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

        private BlueprintModel CreateBlueprint(string filePath)
        {
            // To-Do: In good case the JSON file will be deserialized, though it might throw 
            return JsonConvert.DeserializeObject<BlueprintModel>(File.ReadAllText(filePath),
                DefaultJsonSettings.DeserializerSettings);
        }

        private string GetResolvedFilePath()
        {
            // To-Do: work with relative paths?
            var filePath = ResolveUserPath(BlueprintFile);
            if (filePath == null || !new FileInfo(filePath).Exists)
            {
                throw new FileNotFoundException(string.Format("Cannot find path: " + BlueprintFile));
            }

            return filePath;
        }

        // To-Do: Update exception messages

        protected void ThrowIfBlueprintExits(string scope, string name)
        {
            PSBlueprint blueprint = null;

            try
            {
                blueprint = BlueprintClient.GetBlueprint(scope, name);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (blueprint != null)
            {
                throw new Exception(string.Format(Resources.BlueprintExists, name, scope));
            }
        }
    }
}
