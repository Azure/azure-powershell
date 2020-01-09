﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.DeploymentManager.Commands
{
    using System.Collections;
    using System.IO;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Commands.DeploymentManager.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Newtonsoft.Json;

    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzurePrefix + "DeploymentManagerStep",
        DefaultParameterSetName = WaitParamSet,
        SupportsShouldProcess = true),
     OutputType(typeof(PSStepResource))]
    public class NewStep : DeploymentManagerBaseCmdlet
    {
        /// <summary>
        /// The parameter set for the wait step.
        /// </summary>
        private const string WaitParamSet = "Wait";

        /// <summary>
        /// The parameter set for specifying health check step payload as a file.
        /// </summary>
        private const string HealthCheckFileParamSet = "HealthCheckFile";

        /// <summary>
        /// The parameter set for specifying health check step as an object.
        /// </summary>
        private const string HealthCheckObjectParamSet = "HealthCheckObject";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the step.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of the resource.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The duration to wait in ISO 8601 format. E.g.: PT30M, PT1H", ParameterSetName = NewStep.WaitParamSet)]
        [ValidateNotNullOrEmpty]
        public string Duration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The path to the file where health check properties are defined.", ParameterSetName = NewStep.HealthCheckFileParamSet)]
        [ValidateNotNullOrEmpty]
        public string HealthCheckPropertiesFile { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The health check properties.", ParameterSetName = NewStep.HealthCheckObjectParamSet)]
        [ValidateNotNullOrEmpty]
        public PSHealthCheckStepProperties HealthCheckProperties { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.Name, Messages.CreateStep))
            {
                var psStepResource = new PSStepResource()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    Name = this.Name,
                    Location = this.Location,
                    Tags = this.Tag,
                    StepProperties = this.GetProperties()
                };

                if (this.DeploymentManagerClient.StepExists(psStepResource))
                {
                    throw new PSArgumentException(Messages.StepAlreadyExists);
                }

                psStepResource = this.DeploymentManagerClient.PutStep(psStepResource);
                this.WriteObject(psStepResource);
            }
        }

        private PSStepProperties GetProperties()
        {
            switch (this.ParameterSetName)
            {
                case WaitParamSet:
                    return new PSWaitStepProperties()
                    {
                        Duration = this.Duration
                    };

                case HealthCheckObjectParamSet:
                    return this.HealthCheckProperties;

                case HealthCheckFileParamSet:
                    var healthCheckFileContent = FileUtilities.GetHealthCheckPropertiesFromFile(
                        this.SessionState.Path.CurrentFileSystemLocation.Path,
                        this.HealthCheckPropertiesFile);

                    var psHealthCheckStepProperties = JsonConvert.DeserializeObject<PSHealthCheckStepProperties>(
                        healthCheckFileContent,
                        new HealthCheckAttributesConverter(),
                        new RestRequestAuthenticationConverter());

                    return psHealthCheckStepProperties;
                default:
                    return null;
            }
        }
    }
}
