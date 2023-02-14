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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataFactoryV2Pipeline", DefaultParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, SupportsShouldProcess = true), OutputType(typeof(string))]
    public class InvokeAzureDataFactoryPipelineCommand : DataFactoryBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterFile, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterObject, Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = Constants.HelpFactoryObject)]
        [ValidateNotNull]
        public PSPipeline InputObject { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpResourceGroup)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpFactoryName)]
        [ValidateNotNullOrEmpty]
        public string DataFactoryName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineName)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPipelineName)]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpParametersForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterObject, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpParametersForRun)]
        [ValidateNotNullOrEmpty]
        public Hashtable Parameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpParameterFileForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterFile, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpParameterFileForRun)]
        [ValidateNotNullOrEmpty]
        public string ParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpReferencePipelineRunIdForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpReferencePipelineRunIdForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterObject, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpReferencePipelineRunIdForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterFile, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpReferencePipelineRunIdForRun)]
        [ValidateNotNullOrEmpty]
        public string ReferencePipelineRunId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIsRecoveryForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIsRecoveryForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterObject, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIsRecoveryForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterFile, Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpIsRecoveryForRun)]
        public SwitchParameter IsRecovery { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartActivityNameForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartActivityNameForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterObject, Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartActivityNameForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterFile, Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartActivityNameForRun)]
        [ValidateNotNullOrEmpty]
        public string StartActivityName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterFile, Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartFromFailureForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByFactoryNameByParameterObject, Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartFromFailureForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterObject, Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartFromFailureForRun)]
        [Parameter(ParameterSetName = ParameterSetNames.ByPipelineObjectByParameterFile, Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpStartFromFailureForRun)]
        public SwitchParameter StartFromFailure { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParameterSetNames.ByPipelineObjectByParameterFile, StringComparison.OrdinalIgnoreCase)
                || ParameterSetName.Equals(ParameterSetNames.ByPipelineObjectByParameterObject, StringComparison.OrdinalIgnoreCase))
            {
                DataFactoryName = InputObject.DataFactoryName;
                ResourceGroupName = InputObject.ResourceGroupName;
                PipelineName = InputObject.Name;
            }

            Dictionary<string, object> paramDictionary = null;
            if (Parameter == null && string.IsNullOrWhiteSpace(ParameterFile))
            {
                paramDictionary = new Dictionary<string, object>();
            }
            else if (Parameter != null)
            {
                try
                {
                    paramDictionary = Parameter.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => kvp.Value);
                }
                catch (InvalidCastException ex)
                {
                    throw new InvalidCastException(Resources.InvalidCastParameterKeyExceptionMessage, ex);
                }
            }
            else
            {
                paramDictionary = ReadParametersFromJson();
            }

            bool? isRecovery = null;
            bool? startFromFailure = null;
            if (IsRecovery.IsPresent)
            {
                isRecovery = true;

                if (StartFromFailure.IsPresent)
                {
                    startFromFailure = true;
                }
            }

            if (ShouldProcess(this.ResourceGroupName, string.Format(Constants.ActionDescriptionForInvokePipeline, this.PipelineName, this.DataFactoryName)))
            {
                WriteObject(DataFactoryClient.CreatePipelineRun(ResourceGroupName, DataFactoryName, PipelineName, paramDictionary, ReferencePipelineRunId, isRecovery, StartActivityName, startFromFailure));
            }
        }

        private Dictionary<string, object> ReadParametersFromJson()
        {
            var parameters = new Dictionary<string, object>();
            string rawJsonContent = DataFactoryClient.ReadJsonFileContent(this.TryResolvePath(ParameterFile));
            if (!string.IsNullOrWhiteSpace(rawJsonContent))
            {
                parameters = SafeJsonConvert.DeserializeObject<Dictionary<string, object>>(rawJsonContent, DataFactoryClient.DataFactoryManagementClient.DeserializationSettings);
            }
            return parameters;
        }
    }
}
