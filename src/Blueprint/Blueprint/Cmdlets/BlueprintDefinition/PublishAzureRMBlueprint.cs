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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Publish", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Blueprint", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.PublishBlueprint), OutputType(typeof(PSPublishedBlueprint))]
    public class PublishAzureRmBlueprint : BlueprintDefinitionCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.PublishBlueprint, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintDefinitionVersionToPublish)]
        [ValidatePattern("([A-Za-z0-9-_]+)", Options = RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.PublishBlueprint, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ChangeNotes)]
        [ValidateLength(0,500)]
        [ValidateNotNullOrEmpty]
        public string ChangeNote { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.PublishBlueprint, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [ValidateNotNullOrEmpty]
        public PSBlueprint Blueprint { get; set; }
        #endregion

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Utils.GetDefinitionLocationId(Blueprint.Scope), string.Format(Resources.PublishBlueprintShouldProcessString, Blueprint.Name)))
            {
                try
                {
                    // parameters property is placeholder here, backend strips this information and publishes the latest master. It is needed in the payload since swagger calls it required.
                    var publishedBlueprintObjForChangeNotes = new PublishedBlueprint(
                        parameters: new Dictionary<string, ParameterDefinition>(), changeNotes: ChangeNote);

                    WriteObject(BlueprintClient.CreatePublishedBlueprint(Blueprint.Scope, Blueprint.Name, Version, publishedBlueprintObjForChangeNotes));
                }
                catch (Exception ex)
                {
                    WriteExceptionError(ex);
                }
            }
        }
        #endregion
    }
}
