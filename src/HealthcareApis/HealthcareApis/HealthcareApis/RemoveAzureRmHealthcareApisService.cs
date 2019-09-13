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

using Microsoft.Azure.Commands.HealthcareApis.Properties;
using Microsoft.Azure.Commands.HealthcareApis.Common;
using Microsoft.Azure.Commands.HealthcareApis.Models;
using Microsoft.Azure.Management.HealthcareApis;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HealthcareApis.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HealthcareApis.Commands
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HealthcareApisService", DefaultParameterSetName = ServiceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmHealthcareApisService : HealthcareApisBaseCmdlet
    {
        protected const string ServiceNameParameterSet = "ServiceNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
          ParameterSetName = ServiceNameParameterSet,
          Mandatory = true,
          HelpMessage = "HealthcareApis Service Name.")]
        [Alias(HealthcareApisAccountNameAlias, FhirServiceNameAlias)]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^[a-z0-9][a-z0-9-]{1,21}[a-z0-9]$")]
        [ValidateLength(2, 64)]
        public string Name { get; set; }

        [Parameter(
           ParameterSetName = ServiceNameParameterSet,
           Mandatory = true,
           HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
          ParameterSetName = InputObjectParameterSet,
          Mandatory = true,
          HelpMessage = "HealthcareApis service object",
          ValueFromPipeline = true)]
        public PSHealthcareApisService InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "HealthcareApis Service ResourceId.")]
        [ResourceIdCompleter("Microsoft.HealthcareApis/services")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet as a job in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                base.ExecuteCmdlet();

                RunCmdLet(() =>
                {
                    string rgName = null;
                    string name = null;

                    switch (ParameterSetName)
                    {
                        case InputObjectParameterSet:
                            {
                                rgName = InputObject.ResourceGroupName;
                                name = InputObject.Name;
                                break;
                            }
                        case ServiceNameParameterSet:
                            {
                                rgName = this.ResourceGroupName;
                                name = this.Name;
                                break;
                            }
                        case ResourceIdParameterSet:
                            {
                                ValidateAndExtractName(this.ResourceId, out rgName, out name);
                                break;
                            }
                    }

                    if (!string.IsNullOrEmpty(rgName)
                        && !string.IsNullOrEmpty(name)
                        && ShouldProcess(name, string.Format(CultureInfo.CurrentCulture, Resources.RemoveService_ProcessMessage, name)))
                    {
                        try
                        {
                            this.HealthcareApisClient.Services.Delete(rgName, name);
                            if (PassThru.IsPresent)
                            {
                                WriteObject(true);
                            }
                        }
                        catch (ErrorDetailsException wex)
                        {
                            WriteError(WriteErrorforBadrequest(wex));
                        }
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

    }
}
