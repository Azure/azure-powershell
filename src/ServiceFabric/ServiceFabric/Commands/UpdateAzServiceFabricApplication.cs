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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzurePrefix + "ServiceFabricApplication", DefaultParameterSetName = ByResourceGroup, SupportsShouldProcess = true), OutputType(typeof(PSApplication))]
    public class UpdateAzServiceFabricApplication : ProxyResourceCmdletBase
    {
        private const string ByResourceGroup = "ByResourceGroup";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceGroup, Position = 2,
            HelpMessage = "Specify the name of the application")]
        [ValidateNotNullOrEmpty()]
        [Alias("ApplicationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, Position = 3, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specify the application type version")]
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = ByResourceId,
            HelpMessage = "Specify the application type version")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationTypeVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = ByResourceId,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [ValidateNotNullOrEmpty()]
        public Hashtable ApplicationParameter { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the minimum number of nodes where Service Fabric will reserve capacity for this application")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the minimum number of nodes where Service Fabric will reserve capacity for this application")]
        public long MinimumNodeCount { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum number of nodes on which to place an application")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum number of nodes on which to place an application")]
        public long MaximumNodeCount { get; set; }

        #region upgrade policy params

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Indicates that the service host restarts even if the upgrade is a configuration-only change.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Indicates that the service host restarts even if the upgrade is a configuration-only change.")]
        public SwitchParameter ForceRestart { get; set;}

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum time that Service Fabric waits for a service to reconfigure into a safe state, if not already in a safe state, before Service Fabric proceeds with the upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum time that Service Fabric waits for a service to reconfigure into a safe state, if not already in a safe state, before Service Fabric proceeds with the upgrade.")]
        [ValidateRange(0, int.MaxValue)]
        public int UpgradeReplicaSetCheckTimeoutSec { get; set;}

        #region RollingUpgradeMonitoringPolicy

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the action to take if the monitored upgrade fails. The acceptable values for this parameter are Rollback or Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the action to take if the monitored upgrade fails. The acceptable values for this parameter are Rollback or Manual.")]
        public FailureAction FailureAction { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration, in seconds, after which Service Fabric retries the health check if the previous health check fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration, in seconds, after which Service Fabric retries the health check if the previous health check fails.")]
        [ValidateRange(0, int.MaxValue)]
        public int HealthCheckRetryTimeoutSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits before it performs the initial health check after it finishes the upgrade on the upgrade domain.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits before it performs the initial health check after it finishes the upgrade on the upgrade domain.")]
        [ValidateRange(0, int.MaxValue)]
        public int HealthCheckWaitDurationSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits in order to verify that the application is stable before moving to the next upgrade domain or completing the upgrade. This wait duration prevents undetected changes of health right after the health check is performed.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits in order to verify that the application is stable before moving to the next upgrade domain or completing the upgrade. This wait duration prevents undetected changes of health right after the health check is performed.")]
        [ValidateRange(0, int.MaxValue)]
        public int HealthCheckStableDurationSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes to upgrade a single upgrade domain. After this period, the upgrade fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes to upgrade a single upgrade domain. After this period, the upgrade fails.")]
        [ValidateRange(0, int.MaxValue)]
        public int UpgradeDomainTimeoutSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes for the entire upgrade. After this period, the upgrade fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes for the entire upgrade. After this period, the upgrade fails.")]
        [ValidateRange(0, int.MaxValue)]
        public int UpgradeTimeoutSec { get; set;}

        #endregion

        #region ApplicationHealthPolicy

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Indicates whether to treat a warning health event as an error event during health evaluation.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Indicates whether to treat a warning health event as an error event during health evaluation.")]
        public SwitchParameter ConsiderWarningAsError { get; set; }
        
        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percent of unhelthy partitions per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percent of unhelthy partitions per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [ValidateRange(0, 100)]
        public int DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService { get; set; }
        
        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percent of unhelthy replicas per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percent of unhelthy replicas per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [ValidateRange(0, 100)]
        public int DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition { get; set; }
        
        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percent of unhelthy services allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percent of unhelthy services allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [ValidateRange(0, 100)]
        public int DefaultServiceTypeUnhealthyServicesMaxPercent { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percentage of the application instances deployed on the nodes in the cluster that have a health state of error before the application health state for the cluster is error.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percentage of the application instances deployed on the nodes in the cluster that have a health state of error before the application health state for the cluster is error.")]
        [ValidateRange(0, 100)]
        public int UnhealthyDeployedApplicationsMaxPercent { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the map of the health policy to use for different service types as a hash table in the following format: @ {\"ServiceTypeName\" : \"MaxPercentUnhealthyPartitionsPerService,MaxPercentUnhealthyReplicasPerPartition,MaxPercentUnhealthyServices\"}. For example: @{ \"ServiceTypeName01\" = \"5,10,5\"; \"ServiceTypeName02\" = \"5,5,5\" }")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the map of the health policy to use for different service types as a hash table in the following format: @ {\"ServiceTypeName\" : \"MaxPercentUnhealthyPartitionsPerService,MaxPercentUnhealthyReplicasPerPartition,MaxPercentUnhealthyServices\"}. For example: @{ \"ServiceTypeName01\" = \"5,10,5\"; \"ServiceTypeName02\" = \"5,5,5\" }")]
        public Hashtable ServiceTypeHealthPolicyMap { get; set; }

        #endregion

        #endregion

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the application.")]
        [ResourceIdCompleter("Microsoft.ServiceFabric/clusters")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true, HelpMessage = "The application resource.")]
        public PSApplication InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ByInputObject:
                    this.ResourceId = InputObject.Id;
                    SetParametersByResourceId();
                    break;
                case ByResourceId:
                    SetParametersByResourceId();
                    break;
                case ByResourceGroup:
                    // intentionally left empty
                    break;
                default:
                    throw new PSArgumentException("Invalid ParameterSetName");
            }

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
            WriteVerbose(string.Format("Updating application '{0}'", this.Name));
            if (ParameterSetName == ByInputObject)
            {
                return StartUpdate(this.InputObject);
            }
            else
            {
                var currentApp = this.SFRPClient.Applications.Get(this.ResourceGroupName, this.ClusterName, this.Name);
                var currentUpgradePolicy = currentApp.UpgradePolicy;

                if (!string.IsNullOrEmpty(this.ApplicationTypeVersion))
                {
                    currentApp.TypeVersion = this.ApplicationTypeVersion;
                }

                if (this.ApplicationParameter != null)
                {
                    currentApp.Parameters = this.ApplicationParameter?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
                }

                if (this.IsParameterBound(c => c.MinimumNodeCount))
                {
                    currentApp.MinimumNodes = this.MinimumNodeCount;
                }

                if (this.IsParameterBound(c => c.MaximumNodeCount))
                {
                    currentApp.MaximumNodes = this.MaximumNodeCount;
                }

                currentApp.UpgradePolicy = SetUpgradePolicy(currentApp.UpgradePolicy);
                return StartUpdate(currentApp);
            }
        }

        private ApplicationResource StartUpdate(ApplicationResource appResource)
        {
            //TODO: use BeginUpdateWithHttpMessagesAsync (Patch) once fix is deployed in SFRP
            return StartRequestAndWait<ApplicationResource>(
                () => this.SFRPClient.Applications.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, appResource),
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

            if (this.IsParameterBound(c => c.UpgradeReplicaSetCheckTimeoutSec))
            {
                currentPolicy.UpgradeReplicaSetCheckTimeout = TimeSpan.FromSeconds(UpgradeReplicaSetCheckTimeoutSec).ToString("");
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

            if (this.IsParameterBound(c => c.FailureAction))
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.FailureAction = FailureAction.ToString();
            }

            if (this.IsParameterBound(c => c.HealthCheckRetryTimeoutSec))
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckRetryTimeout = TimeSpan.FromSeconds(HealthCheckRetryTimeoutSec).ToString("c");
            }

            if (this.IsParameterBound(c => c.HealthCheckWaitDurationSec))
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckWaitDuration = TimeSpan.FromSeconds(HealthCheckWaitDurationSec).ToString("c");
            }

            if (this.IsParameterBound(c => c.HealthCheckStableDurationSec))
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckStableDuration = TimeSpan.FromSeconds(HealthCheckStableDurationSec).ToString("c");
            }

            if (this.IsParameterBound(c => c.UpgradeDomainTimeoutSec))
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.UpgradeDomainTimeout = TimeSpan.FromSeconds(UpgradeDomainTimeoutSec).ToString("c");
            }

            if (this.IsParameterBound(c => c.UpgradeTimeoutSec))
            {
                currentPolicy.RollingUpgradeMonitoringPolicy.UpgradeTimeout = TimeSpan.FromSeconds(UpgradeTimeoutSec).ToString("c");
            }

            //ApplicationHealthPolicy
            if (currentPolicy.ApplicationHealthPolicy == null)
            {
                currentPolicy.ApplicationHealthPolicy = new ArmApplicationHealthPolicy();
            }

            if (ConsiderWarningAsError.IsPresent)
            {
                currentPolicy.ApplicationHealthPolicy.ConsiderWarningAsError = true;
            }

            if (currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy == null)
            {
                currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy = new ArmServiceTypeHealthPolicy(
                    maxPercentUnhealthyPartitionsPerService: DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService,
                    maxPercentUnhealthyReplicasPerPartition: DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition,
                    maxPercentUnhealthyServices: DefaultServiceTypeUnhealthyServicesMaxPercent);
            }
            else
            {
                if (this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService))
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyPartitionsPerService = DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService;
                }

                if (this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition))
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyReplicasPerPartition = DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition;
                }

                if (this.IsParameterBound(c => c.DefaultServiceTypeUnhealthyServicesMaxPercent))
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyServices = DefaultServiceTypeUnhealthyServicesMaxPercent;
                }

                if (this.IsParameterBound(c => c.UnhealthyDeployedApplicationsMaxPercent))
                {
                    currentPolicy.ApplicationHealthPolicy.MaxPercentUnhealthyDeployedApplications = UnhealthyDeployedApplicationsMaxPercent;
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

        private void SetParametersByResourceId()
        {
            ResourceIdentifier appRId = new ResourceIdentifier(this.ResourceId);
            this.ResourceGroupName = appRId.ResourceGroupName;
            string subscription = appRId.Subscription;
            ResourceIdentifier clusterRId = new ResourceIdentifier($"/subscriptions/{subscription}/resourceGroups/{this.ResourceGroupName}/providers/Microsoft.ServiceFabric/{appRId.ParentResource}");
            if (!appRId.ResourceType.EndsWith(Constants.applicationProvider)
                || !clusterRId.ResourceType.EndsWith(Constants.clusterProvider))
            {
                throw new PSArgumentException(string.Format("invalid resource id {0}", this.ResourceId));
            }

            this.ClusterName = clusterRId.ResourceName;
            this.Name = appRId.ResourceName;
        }
    }
}
