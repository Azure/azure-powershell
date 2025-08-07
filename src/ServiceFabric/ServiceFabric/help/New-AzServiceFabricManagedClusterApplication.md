---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/new-azservicefabricmanagedclusterapplication
schema: 2.0.0
---

# New-AzServiceFabricManagedClusterApplication

## SYNOPSIS
Create a Service Fabric managed application resource with the specified name.

## SYNTAX

### CreateExpanded (Default)
```
New-AzServiceFabricManagedClusterApplication -Name <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [-SubscriptionId <String>] [-ApplicationHealthPolicyConsiderWarningAsError]
 [-ApplicationHealthPolicyMaxPercentUnhealthyDeployedApplication <Int32>]
 [-ApplicationHealthPolicyServiceTypeHealthPolicyMap <Hashtable>]
 [-DefaultServiceTypeHealthPolicyMaxPercentUnhealthyPartitionsPerService <Int32>]
 [-DefaultServiceTypeHealthPolicyMaxPercentUnhealthyReplicasPerPartition <Int32>]
 [-DefaultServiceTypeHealthPolicyMaxPercentUnhealthyService <Int32>] [-EnableSystemAssignedIdentity]
 [-Location <String>] [-ManagedIdentity <IApplicationUserAssignedIdentity[]>] [-Parameter <Hashtable>]
 [-RollingUpgradeMonitoringPolicyFailureAction <String>]
 [-RollingUpgradeMonitoringPolicyHealthCheckRetryTimeout <String>]
 [-RollingUpgradeMonitoringPolicyHealthCheckStableDuration <String>]
 [-RollingUpgradeMonitoringPolicyHealthCheckWaitDuration <String>]
 [-RollingUpgradeMonitoringPolicyUpgradeDomainTimeout <String>]
 [-RollingUpgradeMonitoringPolicyUpgradeTimeout <String>] [-Tag <Hashtable>] [-UpgradePolicyForceRestart]
 [-UpgradePolicyInstanceCloseDelayDuration <Int64>] [-UpgradePolicyRecreateApplication]
 [-UpgradePolicyUpgradeMode <String>] [-UpgradePolicyUpgradeReplicaSetCheckTimeout <Int64>]
 [-UserAssignedIdentity <String[]>] [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzServiceFabricManagedClusterApplication -Name <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzServiceFabricManagedClusterApplication -Name <String> [-ClusterName] <String>
 [-ResourceGroupName] <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityManagedClusterExpanded
```
New-AzServiceFabricManagedClusterApplication -Name <String> -ManagedClusterInputObject <IServiceFabricIdentity>
 [-ApplicationHealthPolicyConsiderWarningAsError]
 [-ApplicationHealthPolicyMaxPercentUnhealthyDeployedApplication <Int32>]
 [-ApplicationHealthPolicyServiceTypeHealthPolicyMap <Hashtable>]
 [-DefaultServiceTypeHealthPolicyMaxPercentUnhealthyPartitionsPerService <Int32>]
 [-DefaultServiceTypeHealthPolicyMaxPercentUnhealthyReplicasPerPartition <Int32>]
 [-DefaultServiceTypeHealthPolicyMaxPercentUnhealthyService <Int32>] [-EnableSystemAssignedIdentity]
 [-Location <String>] [-ManagedIdentity <IApplicationUserAssignedIdentity[]>] [-Parameter <Hashtable>]
 [-RollingUpgradeMonitoringPolicyFailureAction <String>]
 [-RollingUpgradeMonitoringPolicyHealthCheckRetryTimeout <String>]
 [-RollingUpgradeMonitoringPolicyHealthCheckStableDuration <String>]
 [-RollingUpgradeMonitoringPolicyHealthCheckWaitDuration <String>]
 [-RollingUpgradeMonitoringPolicyUpgradeDomainTimeout <String>]
 [-RollingUpgradeMonitoringPolicyUpgradeTimeout <String>] [-Tag <Hashtable>] [-UpgradePolicyForceRestart]
 [-UpgradePolicyInstanceCloseDelayDuration <Int64>] [-UpgradePolicyRecreateApplication]
 [-UpgradePolicyUpgradeMode <String>] [-UpgradePolicyUpgradeReplicaSetCheckTimeout <Int64>]
 [-UserAssignedIdentity <String[]>] [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Service Fabric managed application resource with the specified name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ApplicationHealthPolicyConsiderWarningAsError
Indicates whether warnings are treated with the same severity as errors.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationHealthPolicyMaxPercentUnhealthyDeployedApplication
The maximum allowed percentage of unhealthy deployed applications.
Allowed values are Byte values from zero to 100.The percentage represents the maximum tolerated percentage of deployed applications that can be unhealthy before the application is considered in error.This is calculated by dividing the number of unhealthy deployed applications over the number of nodes where the application is currently deployed on in the cluster.The computation rounds up to tolerate one failure on small numbers of nodes.
Default percentage is zero.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationHealthPolicyServiceTypeHealthPolicyMap
The map with service type health policy per service type name.
The map is empty by default.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the cluster resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultServiceTypeHealthPolicyMaxPercentUnhealthyPartitionsPerService
The maximum allowed percentage of unhealthy partitions per service.The percentage represents the maximum tolerated percentage of partitions that can be unhealthy before the service is considered in error.If the percentage is respected but there is at least one unhealthy partition, the health is evaluated as Warning.The percentage is calculated by dividing the number of unhealthy partitions over the total number of partitions in the service.The computation rounds up to tolerate one failure on small numbers of partitions.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultServiceTypeHealthPolicyMaxPercentUnhealthyReplicasPerPartition
The maximum allowed percentage of unhealthy replicas per partition.The percentage represents the maximum tolerated percentage of replicas that can be unhealthy before the partition is considered in error.If the percentage is respected but there is at least one unhealthy replica, the health is evaluated as Warning.The percentage is calculated by dividing the number of unhealthy replicas over the total number of replicas in the partition.The computation rounds up to tolerate one failure on small numbers of replicas.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultServiceTypeHealthPolicyMaxPercentUnhealthyService
The maximum allowed percentage of unhealthy services.The percentage represents the maximum tolerated percentage of services that can be unhealthy before the application is considered in error.If the percentage is respected but there is at least one unhealthy service, the health is evaluated as Warning.This is calculated by dividing the number of unhealthy services of the specific service type over the total number of services of the specific service type.The computation rounds up to tolerate one failure on small numbers of services.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: CreateViaIdentityManagedClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedIdentity
List of user assigned identities for the application, each mapped to a friendly name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IApplicationUserAssignedIdentity[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the application resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
List of application parameters with overridden values from their default values specified in the application manifest.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradeMonitoringPolicyFailureAction
The compensating action to perform when a Monitored upgrade encounters monitoring policy or health policy violations.
Invalid indicates the failure action is invalid.
Rollback specifies that the upgrade will start rolling back automatically.
Manual indicates that the upgrade will switch to UnmonitoredManual upgrade mode.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradeMonitoringPolicyHealthCheckRetryTimeout
The amount of time to retry health evaluation when the application or cluster is unhealthy before FailureAction is executed.
It is interpreted as a string representing an ISO 8601 duration with following format "hh:mm:ss.fff".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradeMonitoringPolicyHealthCheckStableDuration
The amount of time that the application or cluster must remain healthy before the upgrade proceeds to the next upgrade domain.
It is interpreted as a string representing an ISO 8601 duration with following format "hh:mm:ss.fff".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradeMonitoringPolicyHealthCheckWaitDuration
The amount of time to wait after completing an upgrade domain before applying health policies.
It is interpreted as a string representing an ISO 8601 duration with following format "hh:mm:ss.fff".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradeMonitoringPolicyUpgradeDomainTimeout
The amount of time each upgrade domain has to complete before FailureAction is executed.
Cannot be larger than 12 hours.
It is interpreted as a string representing an ISO 8601 duration with following format "hh:mm:ss.fff".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollingUpgradeMonitoringPolicyUpgradeTimeout
The amount of time the overall upgrade has to complete before FailureAction is executed.
Cannot be larger than 12 hours.
It is interpreted as a string representing an ISO 8601 duration with following format "hh:mm:ss.fff".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradePolicyForceRestart
If true, then processes are forcefully restarted during upgrade even when the code version has not changed (the upgrade only changes configuration or data).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradePolicyInstanceCloseDelayDuration
Duration in seconds, to wait before a stateless instance is closed, to allow the active requests to drain gracefully.
This would be effective when the instance is closing during the application/cluster upgrade, only for those instances which have a non-zero delay duration configured in the service description.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradePolicyRecreateApplication
Determines whether the application should be recreated on update.
If value=true, the rest of the upgrade policy parameters are not allowed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradePolicyUpgradeMode
The mode used to monitor health during a rolling upgrade.
The values are Monitored, and UnmonitoredAuto.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradePolicyUpgradeReplicaSetCheckTimeout
The maximum amount of time to block processing of an upgrade domain and prevent loss of availability when there are unexpected issues.
When this timeout expires, processing of the upgrade domain will proceed regardless of availability loss issues.
The timeout is reset at the start of each upgrade domain.
Valid values are between 0 and 42949672925 inclusive.
(unsigned 32-bit integer).
Unit is in seconds.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The version of the application type as defined in the application manifest.This name must be the full Arm Resource ID for the referenced application type version.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagedClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IApplicationResource

## NOTES

## RELATED LINKS
