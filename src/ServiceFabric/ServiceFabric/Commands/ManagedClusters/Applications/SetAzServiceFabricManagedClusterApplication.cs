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
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Azure.Management.ServiceFabricManagedClusters.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + Constants.ServiceFabricPrefix + "ManagedClusterApplication", DefaultParameterSetName = ByResourceGroup, SupportsShouldProcess = true), OutputType(typeof(PSManagedApplication))]
    public class SetAzServiceFabricManagedClusterApplication : ManagedApplicationCmdletBase
    {
        private const string ByResourceGroup = "ByResourceGroup";
        private const string ByInputObject = "ByInputObject";
        private const string ByResourceId = "ByResourceId";

        private const string ArmResourceIdDelimeter = "/";
        // Default Runtime Values
        private Models.FailureAction FailureActionDefault = Models.FailureAction.Manual;
        private string HealthCheckStableDurationDefault = TimeSpan.FromSeconds(120).ToString("c");
        private string HealthCheckRetryTimeoutDefault = TimeSpan.FromSeconds(600).ToString("c");
        private string HealthCheckWaitDurationDefault = TimeSpan.FromSeconds(0).ToString("c");
        private string UpgradeTimeoutDefault = TimeSpan.FromHours(12).ToString("c");
        private string UpgradeDomainTimeoutDefault = TimeSpan.FromHours(12).ToString("c");
        private int ServiceTypeUnhealthyServicesMaxPercentDefault = 0;
        private int ServiceTypeMaxPercentUnhealthyReplicasPerPartitionDefault = 0;
        private int ServiceTypeMaxPercentUnhealthyPartitionsPerServiceDefault = 0;

        #region Parameters
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByResourceGroup, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.ServiceFabric/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public override string ClusterName { get; set; }

        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specify the name of the application")]
        [ValidateNotNullOrEmpty]
        [Alias("ApplicationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, Position = 3, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specify the application type version")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specify the application type version")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specify the application type version")]
        [ValidateNotNullOrEmpty]
        public string ApplicationTypeVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specify the application parameters as key/value pairs. These parameters must exist in the application manifest.")]
        [ValidateNotNullOrEmpty]
        public Hashtable ApplicationParameter { get; set; }

        #region upgrade policy params

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Indicates that the service host restarts even if the upgrade is a configuration-only change.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Indicates that the service host restarts even if the upgrade is a configuration-only change.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Indicates that the service host restarts even if the upgrade is a configuration-only change.")]
        public SwitchParameter ForceRestart { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Determines whether the application should be recreated on update. If value=true, the rest of the upgrade policy parameters are not allowed.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Determines whether the application should be recreated on update. If value=true, the rest of the upgrade policy parameters are not allowed.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Determines whether the application should be recreated on update. If value=true, the rest of the upgrade policy parameters are not allowed.")]
        public SwitchParameter RecreateApplication { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum time that Service Fabric waits for a service to reconfigure into a safe state, if not already in a safe state, before Service Fabric proceeds with the upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum time that Service Fabric waits for a service to reconfigure into a safe state, if not already in a safe state, before Service Fabric proceeds with the upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum time that Service Fabric waits for a service to reconfigure into a safe state, if not already in a safe state, before Service Fabric proceeds with the upgrade.")]
        [ValidateRange(0, int.MaxValue)]
        public int UpgradeReplicaSetCheckTimeoutSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration in seconds, to wait before a stateless instance is closed, to allow the active requests to drain gracefully.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration in seconds, to wait before a stateless instance is closed, to allow the active requests to drain gracefully.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the duration in seconds, to wait before a stateless instance is closed, to allow the active requests to drain gracefully.")]
        [ValidateRange(0, int.MaxValue)]
        public int InstanceCloseDelayDurationSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "The mode used to monitor health during a rolling upgrade. The values are Monitored, and UnmonitoredAuto.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "The mode used to monitor health during a rolling upgrade. The values are Monitored, and UnmonitoredAuto.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "The mode used to monitor health during a rolling upgrade. The values are Monitored, and UnmonitoredAuto.")]
        public ApplicationUpgradeMode UpgradeMode { get; set; }

        #region RollingUpgradeMonitoringPolicy

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the action to take if the monitored upgrade fails. The acceptable values for this parameter are Rollback or Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the action to take if the monitored upgrade fails. The acceptable values for this parameter are Rollback or Manual.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the action to take if the monitored upgrade fails. The acceptable values for this parameter are Rollback or Manual.")]
        public Models.FailureAction FailureAction { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration, in seconds, after which Service Fabric retries the health check if the previous health check fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration, in seconds, after which Service Fabric retries the health check if the previous health check fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the duration, in seconds, after which Service Fabric retries the health check if the previous health check fails.")]
        [ValidateRange(0, int.MaxValue)]
        public int HealthCheckRetryTimeoutSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits before it performs the initial health check after it finishes the upgrade on the upgrade domain.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits before it performs the initial health check after it finishes the upgrade on the upgrade domain.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits before it performs the initial health check after it finishes the upgrade on the upgrade domain.")]
        [ValidateRange(0, int.MaxValue)]
        public int HealthCheckWaitDurationSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits in order to verify that the application is stable before moving to the next upgrade domain or completing the upgrade. This wait duration prevents undetected changes of health right after the health check is performed.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits in order to verify that the application is stable before moving to the next upgrade domain or completing the upgrade. This wait duration prevents undetected changes of health right after the health check is performed.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the duration, in seconds, that Service Fabric waits in order to verify that the application is stable before moving to the next upgrade domain or completing the upgrade. This wait duration prevents undetected changes of health right after the health check is performed.")]
        [ValidateRange(0, int.MaxValue)]
        public int HealthCheckStableDurationSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes to upgrade a single upgrade domain. After this period, the upgrade fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes to upgrade a single upgrade domain. After this period, the upgrade fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes to upgrade a single upgrade domain. After this period, the upgrade fails.")]
        [ValidateRange(0, int.MaxValue)]
        public int UpgradeDomainTimeoutSec { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes for the entire upgrade. After this period, the upgrade fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes for the entire upgrade. After this period, the upgrade fails.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum time, in seconds, that Service Fabric takes for the entire upgrade. After this period, the upgrade fails.")]
        [ValidateRange(0, int.MaxValue)]
        public int UpgradeTimeoutSec { get; set; }

        #endregion

        #region ApplicationHealthPolicy

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Indicates whether to treat a warning health event as an error event during health evaluation.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Indicates whether to treat a warning health event as an error event during health evaluation.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Indicates whether to treat a warning health event as an error event during health evaluation.")]
        public SwitchParameter ConsiderWarningAsError { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percent of unhelthy partitions per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percent of unhelthy partitions per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum percent of unhelthy partitions per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [ValidateRange(0, 100)]
        public int DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percent of unhelthy replicas per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percent of unhelthy replicas per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum percent of unhelthy replicas per service allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [ValidateRange(0, 100)]
        public int DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percent of unhelthy services allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percent of unhelthy services allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum percent of unhelthy services allowed by the health policy for the default service type to use for the monitored upgrade.")]
        [ValidateRange(0, 100)]
        public int DefaultServiceTypeUnhealthyServicesMaxPercent { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the maximum percentage of the application instances deployed on the nodes in the cluster that have a health state of error before the application health state for the cluster is error.")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the maximum percentage of the application instances deployed on the nodes in the cluster that have a health state of error before the application health state for the cluster is error.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the maximum percentage of the application instances deployed on the nodes in the cluster that have a health state of error before the application health state for the cluster is error.")]
        [ValidateRange(0, 100)]
        public int UnhealthyDeployedApplicationsMaxPercent { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ByResourceGroup,
            HelpMessage = "Specifies the map of the health policy to use for different service types as a hash table in the following format: @ {\"ServiceTypeName\" : \"MaxPercentUnhealthyPartitionsPerService,MaxPercentUnhealthyReplicasPerPartition,MaxPercentUnhealthyServices\"}. For example: @{ \"ServiceTypeName01\" = \"5,10,5\"; \"ServiceTypeName02\" = \"5,5,5\" }")]
        [Parameter(Mandatory = false, ParameterSetName = ByResourceId,
            HelpMessage = "Specifies the map of the health policy to use for different service types as a hash table in the following format: @ {\"ServiceTypeName\" : \"MaxPercentUnhealthyPartitionsPerService,MaxPercentUnhealthyReplicasPerPartition,MaxPercentUnhealthyServices\"}. For example: @{ \"ServiceTypeName01\" = \"5,10,5\"; \"ServiceTypeName02\" = \"5,5,5\" }")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "Specifies the map of the health policy to use for different service types as a hash table in the following format: @ {\"ServiceTypeName\" : \"MaxPercentUnhealthyPartitionsPerService,MaxPercentUnhealthyReplicasPerPartition,MaxPercentUnhealthyServices\"}. For example: @{ \"ServiceTypeName01\" = \"5,10,5\"; \"ServiceTypeName02\" = \"5,5,5\" }")]
        public Hashtable ServiceTypeHealthPolicyMap { get; set; }

        #endregion

        #endregion

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Specify the tags as key/value pairs.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByResourceId, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Arm ResourceId of the managed application.")]
        [ResourceIdCompleter(Constants.ManagedClustersFullType)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ByInputObject, ValueFromPipeline = true,
            HelpMessage = "The managed application resource.")]
        public PSManagedApplication InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Continue without prompts")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background and return a Job to track progress.")]
        public SwitchParameter AsJob { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                this.SetParams();
                ApplicationResource updatedAppParams = null;
                switch (ParameterSetName)
                {
                    case ByResourceGroup:
                    case ByResourceId:
                        updatedAppParams = this.GetUpdatedAppParams();
                        break;
                    case ByInputObject:
                        updatedAppParams = this.GetUpdatedAppParams(this.InputObject);
                        break;
                    default:
                        throw new ArgumentException("Invalid parameter set", ParameterSetName);
                }
                if (updatedAppParams != null && ShouldProcess(target: this.Name, action: $"Update managed application name {this.Name}, cluster: {this.ClusterName} in resource group {this.ResourceGroupName}"))
                {
                    var beginRequestResponse = this.SfrpMcClient.Applications.BeginCreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.ClusterName, this.Name, updatedAppParams)
                        .GetAwaiter().GetResult();

                    var managedApp = this.PollLongRunningOperation(beginRequestResponse);

                    WriteObject(new PSManagedApplication(managedApp), false);
                }
            }
            catch (Exception ex)
            {
                PrintSdkExceptionDetail(ex);
                throw;
            }
        }

        private ApplicationResource GetUpdatedAppParams(ApplicationResource inputObject = null)
        {
            ApplicationResource currentApp;
            if (inputObject == null)
            {
                currentApp = SafeGetResource(() =>
                    this.SfrpMcClient.Applications.Get(
                        this.ResourceGroupName,
                        this.ClusterName,
                        this.Name),
                    false);

                if (currentApp == null)
                {
                    WriteError(new ErrorRecord(new InvalidOperationException($"Managed application '{this.Name}' does not exist."),
                        "ResourceDoesNotExist", ErrorCategory.InvalidOperation, null));
                    return currentApp;
                }
            }
            else
            {
                currentApp = inputObject;
            }

            WriteVerbose($"Updating managed application '{this.Name}'");

            if (!string.IsNullOrEmpty(this.ApplicationTypeVersion))
            {
                currentApp.Version = SetAppTypeVersion(currentApp.Version, this.ApplicationTypeVersion);
            }

            if (this.IsParameterBound(c => c.ApplicationParameter))
            {
                currentApp.Parameters = this.ApplicationParameter?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            if (this.IsParameterBound(c => c.Tag))
            {
                currentApp.Tags = this.Tag?.Cast<DictionaryEntry>().ToDictionary(d => d.Key as string, d => d.Value as string);
            }

            currentApp.UpgradePolicy = SetUpgradePolicy(currentApp.UpgradePolicy);

            return currentApp;
        }

        private ApplicationUpgradePolicy SetUpgradePolicy(ApplicationUpgradePolicy currentPolicy)
        {
            if (currentPolicy == null)
            {
                currentPolicy = new ApplicationUpgradePolicy();
            }

            if (this.IsParameterBound(c => c.ForceRestart))
            {
                currentPolicy.ForceRestart = this.ForceRestart.ToBool();
            }

            if (this.IsParameterBound(c => c.RecreateApplication))
            {
                currentPolicy.RecreateApplication = this.RecreateApplication.ToBool();
            }

            if (this.IsParameterBound(c => c.UpgradeReplicaSetCheckTimeoutSec))
            {
                currentPolicy.UpgradeReplicaSetCheckTimeout = this.UpgradeReplicaSetCheckTimeoutSec;
            }
            
            if (this.IsParameterBound(c => c.InstanceCloseDelayDurationSec))
            {
                currentPolicy.InstanceCloseDelayDuration = this.InstanceCloseDelayDurationSec;
            }

            if (this.IsParameterBound(c => c.UpgradeMode))
            {
                currentPolicy.UpgradeMode = this.UpgradeMode.ToString();
            }

            if (this.RecreateApplication.ToBool())
            {
                if (
                    this.IsParameterBound(c => c.UpgradeReplicaSetCheckTimeoutSec) || this.IsParameterBound(c => c.InstanceCloseDelayDurationSec) || 
                    this.IsParameterBound(c => c.UpgradeMode) ||this.IsParameterBound(c => c.ForceRestart) ||
                    // RollingUpgradeMonitoringPolicy
                    this.IsParameterBound(c => c.UpgradeDomainTimeoutSec) || this.IsParameterBound(c => c.UpgradeTimeoutSec) ||
                    this.IsParameterBound(c => c.HealthCheckWaitDurationSec) || this.IsParameterBound(c => c.HealthCheckRetryTimeoutSec) ||
                    this.IsParameterBound(c => c.HealthCheckStableDurationSec) || this.IsParameterBound(c => c.FailureAction) ||
                    // ApplicationHealthPolicy
                    this.IsParameterBound(c => c.ServiceTypeHealthPolicyMap) || this.IsParameterBound(c => c.UnhealthyDeployedApplicationsMaxPercent) ||
                    this.IsParameterBound(c => c.DefaultServiceTypeUnhealthyServicesMaxPercent) ||
                    this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition) ||
                    this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService) ||
                    this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService)
                )
                {
                    throw new InvalidOperationException("If RecreateApplication=True, no other parameters are accepted.");
                }
            }
            else
            {
                // RollingUpgradeMonitoringPolicy
                if (currentPolicy.RollingUpgradeMonitoringPolicy == null)
                {
                    // initialize with defaults
                    currentPolicy.RollingUpgradeMonitoringPolicy = new RollingUpgradeMonitoringPolicy(
                        failureAction: FailureActionDefault.ToString(),
                        healthCheckStableDuration: HealthCheckStableDurationDefault,
                        healthCheckRetryTimeout: HealthCheckRetryTimeoutDefault,
                        healthCheckWaitDuration: HealthCheckWaitDurationDefault,
                        upgradeTimeout: UpgradeTimeoutDefault,
                        upgradeDomainTimeout: UpgradeDomainTimeoutDefault);
                }

                if (this.IsParameterBound(c => c.FailureAction))
                {
                    currentPolicy.RollingUpgradeMonitoringPolicy.FailureAction = this.FailureAction.ToString();
                }

                if (this.IsParameterBound(c => c.HealthCheckRetryTimeoutSec))
                {
                    currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckRetryTimeout = TimeSpan.FromSeconds(this.HealthCheckRetryTimeoutSec).ToString("c");
                }

                if (this.IsParameterBound(c => c.HealthCheckWaitDurationSec))
                {
                    currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckWaitDuration = TimeSpan.FromSeconds(this.HealthCheckWaitDurationSec).ToString("c");
                }

                if (this.IsParameterBound(c => c.HealthCheckStableDurationSec))
                {
                    currentPolicy.RollingUpgradeMonitoringPolicy.HealthCheckStableDuration = TimeSpan.FromSeconds(this.HealthCheckStableDurationSec).ToString("c");
                }

                if (this.IsParameterBound(c => c.UpgradeDomainTimeoutSec))
                {
                    currentPolicy.RollingUpgradeMonitoringPolicy.UpgradeDomainTimeout = TimeSpan.FromSeconds(this.UpgradeDomainTimeoutSec).ToString("c");
                }

                if (this.IsParameterBound(c => c.UpgradeTimeoutSec))
                {
                    currentPolicy.RollingUpgradeMonitoringPolicy.UpgradeTimeout = TimeSpan.FromSeconds(this.UpgradeTimeoutSec).ToString("c");
                }

                //ApplicationHealthPolicy
                if (currentPolicy.ApplicationHealthPolicy == null)
                {
                    currentPolicy.ApplicationHealthPolicy = new ApplicationHealthPolicy();
                }

                if (this.IsParameterBound(c => c.ConsiderWarningAsError))
                {
                    currentPolicy.ApplicationHealthPolicy.ConsiderWarningAsError = this.ConsiderWarningAsError.ToBool();
                }

                if (currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy == null)
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy = new ServiceTypeHealthPolicy(
                        maxPercentUnhealthyPartitionsPerService: ServiceTypeMaxPercentUnhealthyPartitionsPerServiceDefault,
                        maxPercentUnhealthyReplicasPerPartition: ServiceTypeMaxPercentUnhealthyReplicasPerPartitionDefault,
                        maxPercentUnhealthyServices: ServiceTypeUnhealthyServicesMaxPercentDefault);
                }

                if (this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService))
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyPartitionsPerService =
                        this.DefaultServiceTypeMaxPercentUnhealthyPartitionsPerService;
                }

                if (this.IsParameterBound(c => c.DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition))
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyReplicasPerPartition =
                        this.DefaultServiceTypeMaxPercentUnhealthyReplicasPerPartition;
                }

                if (this.IsParameterBound(c => c.DefaultServiceTypeUnhealthyServicesMaxPercent))
                {
                    currentPolicy.ApplicationHealthPolicy.DefaultServiceTypeHealthPolicy.MaxPercentUnhealthyServices = this.DefaultServiceTypeUnhealthyServicesMaxPercent;
                }

                if (this.IsParameterBound(c => c.UnhealthyDeployedApplicationsMaxPercent))
                {
                    currentPolicy.ApplicationHealthPolicy.MaxPercentUnhealthyDeployedApplications = this.UnhealthyDeployedApplicationsMaxPercent;
                }

                if (this.IsParameterBound(c => c.ServiceTypeHealthPolicyMap))
                {
                    if (this.ServiceTypeHealthPolicyMap == null)
                    {
                        currentPolicy.ApplicationHealthPolicy.ServiceTypeHealthPolicyMap = null;
                    }
                    else
                    {
                        if (currentPolicy.ApplicationHealthPolicy.ServiceTypeHealthPolicyMap == null)
                        {
                            currentPolicy.ApplicationHealthPolicy.ServiceTypeHealthPolicyMap = new Dictionary<string, ServiceTypeHealthPolicy>();
                        }

                        foreach (DictionaryEntry entry in this.ServiceTypeHealthPolicyMap)
                        {
                            currentPolicy.ApplicationHealthPolicy.ServiceTypeHealthPolicyMap.Add(entry.Key as string, this.ParseServiceTypeHealthPolicy(entry.Value as string));
                        }
                    }
                }
            }

            return currentPolicy;
        }

        private ServiceTypeHealthPolicy ParseServiceTypeHealthPolicy(string serviceTypeHealthPolicy)
        {
            if (string.IsNullOrEmpty(serviceTypeHealthPolicy))
            {
                return new ServiceTypeHealthPolicy();
            }

            string[] policyFields = serviceTypeHealthPolicy.Split(',', ' ');

            if (policyFields.Length != 3)
            {
                throw new ArgumentException("Invalid Service Type health policy, the input should follow the pattern & quot; &lt; MaxPercentUnhealthyPartitionsPerService & gt;,&lt; MaxPercentUnhealthyReplicasPerPartition & gt;,&lt; MaxPercentUnhealthyServices & gt; &quot;. And each value is byte.One example is “5,10,5”.");
            }

            return new ServiceTypeHealthPolicy
            {
                MaxPercentUnhealthyPartitionsPerService = int.Parse(policyFields[0]),
                MaxPercentUnhealthyReplicasPerPartition = int.Parse(policyFields[1]),
                MaxPercentUnhealthyServices = int.Parse(policyFields[2])
            };
        }

        private void SetParams()
        {
            switch (ParameterSetName)
            {
                case ByResourceGroup:
                    break;
                case ByInputObject:
                    if (string.IsNullOrEmpty(this.InputObject?.Id))
                    {
                        throw new ArgumentException("ResourceId is null.");
                    }
                    SetParametersByResourceId(this.InputObject.Id);
                    break;
                case ByResourceId:
                    SetParametersByResourceId(this.ResourceId);
                    break;
            }
        }

        private void SetParametersByResourceId(string resourceId)
        {
            this.GetParametersByResourceId(resourceId, Constants.applicationProvider, out string resourceGroup, out string resourceName, out string parentResourceName);
            this.ResourceGroupName = resourceGroup;
            this.Name = resourceName;
            this.ClusterName = parentResourceName;
        }

        private string SetAppTypeVersion(string oldVersion, string newVersionName)
        {
            var tokens = oldVersion.Split(new string[] { ArmResourceIdDelimeter }, StringSplitOptions.RemoveEmptyEntries);
            tokens[tokens.Length - 1] = newVersionName;
            return string.Join(ArmResourceIdDelimeter, tokens);
        }
    }
}
