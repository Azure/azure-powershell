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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    [CmdletOutputBreakingChange(
        typeof(DatabaseBlobAuditingSettingsModel),
        ReplacementCmdletOutputTypeName = "Microsoft.Azure.Commands.Sql.Auditing.Model.ServerAuditingSettingsModel")]
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + DefinitionsCommon.ServerAuditingCmdletsSuffix,
        DefaultParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
        SupportsShouldProcess = true),
        OutputType(typeof(ServerBlobAuditingSettingsModel))]
    public class GetAzSqlServerAuditing : SqlServerAuditingSettingsCmdletBase
    {
        protected override ServerBlobAuditingSettingsModel GetEntity()
        {
            TraceWarningIfParameterAreUsed(
                $"{VerbsCommon.Get}-{ResourceManager.Common.AzureRMConstants.AzureRMPrefix}{DefinitionsCommon.ServerAuditingCmdletsSuffix}",
                DefinitionsCommon.WhatIfParameterName,
                DefinitionsCommon.ConfirmParameterName);

            return base.GetEntity();
        }

        /// <summary>
        /// No sending is needed as this is a Get cmdlet
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override ServerBlobAuditingSettingsModel PersistChanges(ServerBlobAuditingSettingsModel model)
        {
            return null;
        }

        private void TraceWarningIfParameterAreUsed(string cmdletName, params string[] parametersNames)
        {
            bool wasHeaderWritten = false;
            foreach (string parameterName in parametersNames)
            {
                if (MyInvocation.BoundParameters.ContainsKey(parameterName))
                {
                    if (!wasHeaderWritten)
                    {
                        WriteWarning($"Breaking changes in the cmdlet '{cmdletName}' :");
                        wasHeaderWritten = true;
                    }

                    WriteWarning($" - The parameter '{parameterName}' is changing");
                    WriteWarning("   Change description: Parameter is being deprecated without being replaced");
                }
            }
        }
    }
}