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

            JsonTextReader reader = new JsonTextReader(new StringReader(Policy));
            List<string> allIds = ExtractDictionaryIds(reader);
            allIds.AddRange(ExtractDictionaryIds(reader));
            VerifyElementsAreUnique(allIds, Resources.SqlInformationProtectionPolicyDuplicatedIdsError);

            IEnumerable<string> allDisplayNames =
                policy.Labels.Select(kvp => kvp.Value.DisplayName).
                Concat(policy.InformationTypes.Select(kvp => kvp.Value.DisplayName));
            VerifyElementsAreUnique(allDisplayNames, Resources.SqlInformationProtectionPolicyDuplicatedDisplayNamesError);

            SetInformationProtectionPolicy(policy);
            WriteObject(policy);
        }

        private static List<string> ExtractDictionaryIds(JsonTextReader reader)
        {
            // Search for an instance of "Labels" or "InformationTypes".
            //
            while (reader.Read())
            {
                if (reader.Value != null &&
                    (reader.Value.ToString().Equals("Labels") || reader.Value.ToString().Equals("InformationTypes")))
                {
                    break;
                }
            }

            // We found a desired instance, read the '{' Token.
            //
            reader.Read();

            List<string> dictionaryIds = new List<string>();

            // Iterate the dictionary, and collect the ids.
            //
            while (reader.Read())
            {
                // Break if '}' token was read.
                //
                if (reader.TokenType == JsonToken.EndObject)
                {
                    break;
                }

                // The value should hold an id.
                //
                if (reader.Value == null)
                {
                    throw new Exception(Resources.SqlInformationProtectionPolicyDeserializationError);
                }

                dictionaryIds.Add(reader.Value.ToString());

                // Search for the next entry in the Labels or InformationTypes dictionary.
                //
                while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                {
                    // If '[' token appears, search for ']' token.
                    //
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        while (reader.Read() && reader.TokenType != JsonToken.EndArray) ;
                    }
                }
            }

            return dictionaryIds;
        }

        private static void VerifyElementsAreUnique(IEnumerable<string> allElements, string exceptionMessage)
        {
            IEnumerable<string> elementsAppearingMoreThanOnce =
                allElements.
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
