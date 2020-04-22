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

using Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy;
using Newtonsoft.Json;
using System.Management.Automation;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.SqlInformationProtectionPolicy
{
    [Cmdlet(VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SqlInformationProtectionPolicyCmdletSuffix,
        DefaultParameterSetName = SqlInformationProtectionPolicyParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(PSSqlInformationProtectionPolicy))]
    public class SetSqlInformationProtectionPolicy : SqlInformationProtectionPolicyCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = SqlInformationProtectionPolicyParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = PolicyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = SqlInformationProtectionPolicyFilePathParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = FilePathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == SqlInformationProtectionPolicyFilePathParameterSet)
            {
                string filePath = ResolveUserPath(FilePath);
                if (!File.Exists(filePath))
                {
                    throw new PSArgumentException(
                        string.Format(Resources.SqlInformationProtectionPolicyFileDoesNotExistError, FilePath),
                        FilePathParameterName);
                }

                Policy = File.ReadAllText(filePath);
            }

            if (string.IsNullOrEmpty(Policy))
            {
                throw new Exception(Resources.SqlInformationProtectionPolicyEmptyError);
            }

            PSSqlInformationProtectionPolicy policy = JsonConvert.DeserializeObject<PSSqlInformationProtectionPolicy>(Policy,
                new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                });
            if (policy == null)
            {
                throw new Exception(Resources.SqlInformationProtectionPolicyDeserializationError);
            }

            VerifyElementsAreUnique(policy,
                kvp => kvp.Key,
                kvp => kvp.Key,
                Resources.SqlInformationProtectionPolicyDuplicatedIdsError);

            VerifyElementsAreUnique(policy,
                kvp => kvp.Value.DisplayName,
                kvp => kvp.Value.DisplayName,
                Resources.SqlInformationProtectionPolicyDuplicatedDisplayNamesError);

            SetInformationProtectionPolicy(policy);
            WriteObject(policy);
        }

        private static void VerifyElementsAreUnique(
            PSSqlInformationProtectionPolicy policy,
            Func<KeyValuePair<string, PSSqlInformationProtectionSensitivityLabel>, string> sensitivityLabelSelector,
            Func<KeyValuePair<string, PSSqlInformationProtectionInformationType>, string> informationTypeSelector,
            string exceptionMessage)
        {
            IEnumerable<string> elementsAppearingMoreThanOnce =
                policy.Labels.Select(sensitivityLabelSelector).
                Concat(policy.InformationTypes.Select(informationTypeSelector)).
                GroupBy(s => s).
                Where(group => group.Count() > 1).
                Select(group => group.Key);
            if (elementsAppearingMoreThanOnce.Any())
            {
                throw new Exception(string.Format(
                    exceptionMessage,
                    string.Join(",", elementsAppearingMoreThanOnce.Select(e => $"'{e}'"))));
            }
        }

        private void SetInformationProtectionPolicy(PSSqlInformationProtectionPolicy policy)
        {
            var sdkPolicy = policy.ConverToSDKType();
            var response = SecurityCenterClient.InformationProtectionPolicies.CreateOrUpdateWithHttpMessagesAsync(
                Scope, SqlInformationProtectionPolicyName,
                sdkPolicy.Labels, sdkPolicy.InformationTypes).Result.Response;
            response.EnsureSuccessStatusCode();
        }

        private const string FilePathParameterName = "FilePath";
        private const string FilePathHelpMessage = "Specifies a path of a .json file containing SQL Information Protection Policy definition.";
        private const string PolicyHelpMessage = "Specifies a JSON format string that defines the SQL Information Protection Policy.";
        private const string SqlInformationProtectionPolicyFilePathParameterSet = "SQL Information Protection Policy File Path";
        private const string SqlInformationProtectionPolicyName = "custom";
    }
}
