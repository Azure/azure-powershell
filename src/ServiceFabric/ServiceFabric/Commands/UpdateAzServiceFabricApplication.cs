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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplication", SupportsShouldProcess = true), OutputType(typeof(PSApplication))]
    public class UpdateAzServiceFabricApplication : ProxyResourceCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = true,
                   HelpMessage = "Specify the name of the application")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = true,
                   HelpMessage = "Specify the application type version")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationTypeVersion { get; set; }

        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = true,
                   HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [ValidateNotNullOrEmpty()]
        public Hashtable ApplicationParameter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Specifies the minimum number of nodes where Service Fabric will reserve capacity for this application")]
        public long? MinimumNodes { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Specifies the maximum number of nodes on which to place an application")]
        public long? MaximumNodes { get; set; }

        #region upgrade policy params

        [Parameter(Mandatory = false)]
        public SwitchParameter ForceRestart { get; set;}

        [Parameter(Mandatory = false)]
        public int? UpgradeReplicaSetCheckTimeoutSec { get; set;}

        #region RollingUpgradeMonitoringPolicy

        [Parameter(Mandatory = false)]
        public FailureAction? FailureAction { get; set; }

        [Parameter(Mandatory = false)]
        public int? HealthCheckRetryTimeoutSec { get; set; }

        [Parameter(Mandatory = false)]
        public int? HealthCheckWaitDurationSec { get; set; }

        [Parameter(Mandatory = false)]
        public int? HealthCheckStableDurationSec { get; set; }

        [Parameter(Mandatory = false)]
        public int? UpgradeDomainTimeoutSec { get; set; }

        [Parameter(Mandatory = false)]
        public int? UpgradeTimeoutSec { get; set;}

        #endregion

        #region ApplicationHealthPolicy

        [Parameter(Mandatory = false)]
        public bool? ConsiderWarningAsError { get; set; }
        
        [Parameter(Mandatory = false)]
        [ValidateRange(0, 100)]
        public int? DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService { get; set; }
        
        [Parameter(Mandatory = false)]
        [ValidateRange(0, 100)]
        public int? DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition { get; set; }
        
        [Parameter(Mandatory = false)]
        [ValidateRange(0, 100)]
        public int? DefaultServiceTypeMaxPercentUnhealthyServices { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateRange(0, 100)]
        public byte? MaxPercentUnhealthyDeployedApplications { get; set; }

        [Parameter(Mandatory = false)]
        public Hashtable ServiceTypeHealthPolicyMap { get; set; }

        #endregion

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(target: this.ResourceGroupName, action: string.Format("Update application '{0}'" , this.Name)))
            {
                try
                {
                    if (this.ApplicationTypeVersion != null)
                    {
                        var currentApp = this.SFRPClient.Applications.Get(this.ResourceGroupName, this.ClusterName, this.Name);

                        if (currentApp.TypeVersion.Equals(this.ApplicationTypeVersion))
                        {
                            throw new PSInvalidOperationException(string.Format("The application '{0}' is alrady running with type version '{1}'.", currentApp.Name, currentApp.TypeVersion));
                        }

                        var appTypeVersion = SafeGetResource(() =>
                            this.SFRPClient.ApplicationTypeVersions.Get(
                                this.ResourceGroupName,
                                this.ClusterName,
                                currentApp.TypeName,
                                this.ApplicationTypeVersion),
                            false);

                        if (appTypeVersion == null)
                        {
                            throw new PSArgumentException(
                                string.Format("Application type version {0}:{1} not found. Create the type version before runnig this command.",
                                currentApp.TypeName,
                                this.ApplicationTypeVersion));
                        }

                        WriteVerbose(string.Format("Updating application to version {0}", this.ApplicationTypeVersion));
                    }

                    var app = UpdateApplication();
                    WriteObject(app);
                }
                catch (ErrorModelException ex)
                {
                    PrintSdkExceptionDetail(ex);
                    throw;
                }
            }
        }

        private ApplicationResource UpdateApplication()
        {
            var currentApp = this.SFRPClient.Applications.Get(this.ResourceGroupName, this.ClusterName, this.Name);
            var currentUpgradePolicy = currentApp.UpgradePolicy;

            WriteVerbose(string.Format("Updating application '{0}'", this.Name));
            ApplicationResourceUpdate upgradeParams = new ApplicationResourceUpdate();

            if (!string.IsNullOrEmpty(this.ApplicationTypeVersion))
            {
                currentApp.TypeVersion = this.ApplicationTypeVersion;
            }
            
            if (this.ApplicationParameter != null)
            {
                currentApp.Parameters = this.ApplicationParameter?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }
            
            if (this.MinimumNodes.HasValue)
            {
                currentApp.MinimumNodes = this.MinimumNodes;
            }
            
            if (this.MaximumNodes.HasValue)
            {
                currentApp.MaximumNodes = this.MaximumNodes;
            }

            currentApp.UpgradePolicy = SetUpgradePolicy(currentApp.UpgradePolicy);

            //TODO: use BeginUpdateWithHttpMessagesAsync (Patch) once fix is deployed in SFRP
            return StartRequestAndWait<ApplicationResource>(
                () => this.SFRPClient.Applications.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, currentApp),
                () => string.Format("Provisioning state: {0}", GetAppProvisioningStatus() ?? "Not found"));
        }

        private ApplicationUpgradePolicy SetUpgradePolicy(ApplicationUpgradePolicy currentPolicy)
        {
            if (currentPolicy == null)
            {
                currentPolicy = new ApplicationUpgradePolicy();
            }

            if (ForceRestart.IsPresent)
            {
                currentPolicy.ForceRestart = true;
            }

            if (UpgradeReplicaSetCheckTimeoutSec.HasValue)
            {
                currentPolicy.UpgradeReplicaSetCheckTimeout = TimeSpan.FromSeconds(UpgradeReplicaSetCheckTimeoutSec.Value).ToString("");
            }

            //RollingUpgradeMonitoringPolicy
            if (currentPolicy.RollingUpgradeMonitoringPolicy == null)
            {
                //initialize with defaults
                currentPolicy.RollingUpgradeMonitoringPolicy = new ArmRollingUpgradeMonitoringPolicy(
                    failureAction: "Manual",
                    healthCheckStableDuration: TimeSpan.FromSeconds(120).ToString("c"),
                    healthCheckRetryTimeout: TimeSpan.FromSeconds(600).ToString("c"),
                    healthCheckWaitDuration: TimeSpan.FromSeconds(0).ToString("c"),
                    upgradeTimeout: TimeSpan.MaxValue.ToString("c"),
                    upgradeDomainTimeout: TimeSpan.MaxValue.ToString("c"));
            }

            if (FailureAction.HasValue)
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.FailureAction = FailureAction.Value.ToString();
            }

            if (HealthCheckRetryTimeoutSec.HasValue)
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckRetryTimeout = TimeSpan.FromSeconds(HealthCheckRetryTimeoutSec.Value).ToString("c");
            }

            if (HealthCheckWaitDurationSec.HasValue)
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckWaitDuration = TimeSpan.FromSeconds(HealthCheckWaitDurationSec.Value).ToString("c");
            }

            if (HealthCheckStableDurationSec.HasValue)
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckStableDuration = TimeSpan.FromSeconds(HealthCheckStableDurationSec.Value).ToString("c");
            }

            if (UpgradeDomainTimeoutSec.HasValue)
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.UpgradeDomainTimeout = TimeSpan.FromSeconds(UpgradeDomainTimeoutSec.Value).ToString("c");
            }

            if (UpgradeTimeoutSec.HasValue)
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.UpgradeTimeout = TimeSpan.FromSeconds(UpgradeTimeoutSec.Value).ToString("c");
            }

            //ApplicationHealthPolicy
            if (currentPolicy.ApplicationHealthPolicy == null)
            {
                currentPolicy.ApplicationHealthPolicy = new ArmApplicationHealthPolicy();
            }

            if (ConsiderWarningAsError.HasValue)
            {
                currentPolicy.ApplicationHealthPolicy.ConsiderWarningAsError = ConsiderWarningAsError.Value;
            }

            if (currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy == null)
            {
                currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy = new ArmServiceTypeHealthPolicy(
                    maxPercentUnhealthyPartitionsPerService: DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService,
                    maxPercentUnhealthyReplicasPerPartition: DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition,
                    maxPercentUnhealthyServices: DefaultServiceTypeMaxPercentUnhealthyServices);
            }
            else
            {
                if (DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService.HasValue)
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyPartitionsPerService = DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService.Value;
                }

                if (DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition.HasValue)
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyReplicasPerPartition = DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition.Value;
                }

                if (DefaultServiceTypeMaxPercentUnhealthyServices.HasValue)
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyServices = DefaultServiceTypeMaxPercentUnhealthyServices.Value;
                }

                if (MaxPercentUnhealthyDeployedApplications.HasValue)
                {
                    currentPolicy.ApplicationHealthPolicy.MaxPercentUnhealthyDeployedApplications = MaxPercentUnhealthyDeployedApplications.Value;
                }
            }

            if (ServiceTypeHealthPolicyMap != null)
            {
                foreach (DictionaryEntry entry in this.ServiceTypeHealthPolicyMap)
                {
                    currentPolicy.ApplicationHealthPolicy.ServiceTypeHealthPolicyMap.Add(entry.Key as string, this.ParseServiceTypeHealthPolicy(entry.Value as string));
                }
            }

            return currentPolicy;
        }

        private ArmServiceTypeHealthPolicy ParseServiceTypeHealthPolicy(string serviceTypeHealthPolicy)
        {
            if (string.IsNullOrEmpty(serviceTypeHealthPolicy))
            {
                return new ArmServiceTypeHealthPolicy();
            }

            string[] policyFields = serviceTypeHealthPolicy.Split(',', ' ');

            if (policyFields.Length != 3)
            {
                throw new ArgumentException("Invalid Service Type health policy, the input should follow the pattern & quot; &lt; MaxPercentUnhealthyPartitionsPerService & gt;,&lt; MaxPercentUnhealthyReplicasPerPartition & gt;,&lt; MaxPercentUnhealthyServices & gt; &quot;. And each value is byte.One example is “5,10,5”.");
            }

            return new ArmServiceTypeHealthPolicy
            {
                MaxPercentUnhealthyPartitionsPerService = int.Parse(policyFields[0]),
                MaxPercentUnhealthyReplicasPerPartition = int.Parse(policyFields[1]),
                MaxPercentUnhealthyServices = int.Parse(policyFields[2])
            };
        }

        protected string GetAppProvisioningStatus()
        {
            var resource = SafeGetResource(() =>
                this.SFRPClient.Applications.Get(
                    this.ResourceGroupName,
                    this.ClusterName,
                    this.Name),
                true);

            if (resource != null)
            {
                return resource.ProvisioningState;
            }

            return null;
        }
    }
}
