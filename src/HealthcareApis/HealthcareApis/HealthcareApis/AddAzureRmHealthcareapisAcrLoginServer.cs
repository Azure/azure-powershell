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
// 

using Microsoft.Azure.Commands.HealthcareApis.Common;
using Microsoft.Azure.Commands.HealthcareApis.Models;
using Microsoft.Azure.Commands.HealthcareApis.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HealthcareApis;
using Microsoft.Azure.Management.HealthcareApis.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HealthcareApis.Commands
{

    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisAcrLoginServer", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSHealthcareApisService))]
    public class AddAzureRmHealthcareapisAcrLoginServer : HealthcareApisBaseCmdlet
    {
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
           Mandatory = true,
           ParameterSetName = ServiceNameParameterSet,
           HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
          Mandatory = true,
          ParameterSetName = ServiceNameParameterSet,
          HelpMessage = "HealthcareApis Service Name.")]
        [Alias(HealthcareApisAccountNameAlias, FhirServiceNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-z0-9][a-z0-9-]{1,21}[a-z0-9]$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }


        [Parameter(
           Mandatory = true,
           ParameterSetName = ResourceIdParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource Id Name.")]
        [ResourceIdCompleter("Microsoft.HealthcareApis/services")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ServiceNameParameterSet,
            HelpMessage = "List of Login Server That Will Be Added.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "List of Login Server That Will Be Added.")]
        [ValidateNotNullOrEmpty]
        public string[] AcrLoginServer { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                base.ExecuteCmdlet();

                RunCmdLet(() =>
                {                
                    string rgName = null;
                    string name = null;

                    if (ParameterSetName.Equals(ResourceIdParameterSet))
                    {
                        ValidateAndExtractName(this.ResourceId, out rgName, out name);
                    }
                    else if (ParameterSetName.Equals(ServiceNameParameterSet))
                    {
                        rgName = this.ResourceGroupName;
                        name = this.Name;
                    }

                    var healthcareApisAccount = this.HealthcareApisClient.Services.Get(rgName, name);

                    var mergedLoginServers = MergeLoginServers(healthcareApisAccount);
                    healthcareApisAccount.Properties.AcrConfiguration = new ServiceAcrConfigurationInfo
                    {
                        LoginServers = mergedLoginServers
                    };

                    try
                    {
                        var healthcareApisFhirServiceUpdateAccount = this.HealthcareApisClient.Services.CreateOrUpdate(
                                        rgName,
                                        name,
                                        healthcareApisAccount);
                        var healthCareFhirService = this.HealthcareApisClient.Services.Get(rgName, name);
                        WriteHealthcareApisAccount(healthCareFhirService);
                    }
                    catch (ErrorDetailsException wex)
                    {
                        WriteError(WriteErrorforBadrequest(wex));
                    }

                });
            }
            catch (KeyNotFoundException ex)
            {
                WriteError(new ErrorRecord(ex, Resources.keyNotFoundExceptionMessage, ErrorCategory.OpenError, ex));
            }
            catch (NullReferenceException ex)
            {
                WriteError(new ErrorRecord(ex, Resources.nullPointerExceptionMessage, ErrorCategory.OpenError, ex));
            }
        }

        private IList<string> MergeLoginServers(ServicesDescription healthcareApisAccount)
        {
            var mergedLoginServers = healthcareApisAccount.
                                Properties.
                                AcrConfiguration?.
                                LoginServers ?? new List<string>();

            foreach (string loginServer in AcrLoginServer)
            {
                if (!mergedLoginServers.Contains(loginServer))
                {
                    mergedLoginServers.Add(loginServer);
                }
            }

            return mergedLoginServers;
        }
    }
}
