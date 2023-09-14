---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/update-azhdinsightonakscluster
schema: 2.0.0
---

# Update-AzHdInsightOnAksCluster

## SYNOPSIS
Updates an existing Cluster.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled]
 [-AuthorizationProfileGroupId <String[]>] [-AuthorizationProfileUserId <String[]>]
 [-AutoscaleProfileAutoscaleType <AutoscaleType>] [-AutoscaleProfileEnabled]
 [-AutoscaleProfileGracefulDecommissionTimeout <Int32>]
 [-ClusterProfileScriptActionProfile <IScriptActionProfile[]>]
 [-ClusterProfileServiceConfigsProfile <IClusterServiceConfigsProfile[]>]
 [-LoadBasedConfigCooldownPeriod <Int32>] [-LoadBasedConfigMaxNode <Int32>] [-LoadBasedConfigMinNode <Int32>]
 [-LoadBasedConfigPollInterval <Int32>] [-LoadBasedConfigScalingRule <IScalingRule[]>]
 [-LogAnalyticProfileEnabled] [-LogAnalyticProfileMetricsEnabled] [-PrometheuProfileEnabled]
 [-ScheduleBasedConfigDefaultCount <Int32>] [-ScheduleBasedConfigSchedule <ISchedule[]>]
 [-ScheduleBasedConfigTimeZone <String>] [-SshProfileCount <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 -ClusterPatchRequest <IClusterPatch> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -ClusterPatchRequest <IClusterPatch>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -Location <String>
 [-ApplicationLogStdErrorEnabled] [-ApplicationLogStdOutEnabled] [-AuthorizationProfileGroupId <String[]>]
 [-AuthorizationProfileUserId <String[]>] [-AutoscaleProfileAutoscaleType <AutoscaleType>]
 [-AutoscaleProfileEnabled] [-AutoscaleProfileGracefulDecommissionTimeout <Int32>]
 [-ClusterProfileScriptActionProfile <IScriptActionProfile[]>]
 [-ClusterProfileServiceConfigsProfile <IClusterServiceConfigsProfile[]>]
 [-LoadBasedConfigCooldownPeriod <Int32>] [-LoadBasedConfigMaxNode <Int32>] [-LoadBasedConfigMinNode <Int32>]
 [-LoadBasedConfigPollInterval <Int32>] [-LoadBasedConfigScalingRule <IScalingRule[]>]
 [-LogAnalyticProfileEnabled] [-LogAnalyticProfileMetricsEnabled] [-PrometheuProfileEnabled]
 [-ScheduleBasedConfigDefaultCount <Int32>] [-ScheduleBasedConfigSchedule <ISchedule[]>]
 [-ScheduleBasedConfigTimeZone <String>] [-SshProfileCount <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing Cluster.

## EXAMPLES

### Example 1: Update a cluster service config.
```powershell
$coreSiteConfigFile = New-AzHdInsightOnAksClusterConfigFile -FileName "core-site.xml" -Value @{"testvalue1"="111"}
$yarnComponentConfig = New-AzHdInsightAksClusterServiceConfig -ComponentName "hadoop-config" -File $coreSiteConfigFile
$yarnServiceConfigProfile = New-AzHdInsightAksClusterServiceConfigsProfile -ServiceName "yarn-service" -Config $yarnComponentConfig

Update-AzHdInsightOnAksCluster -ResourceGroupName $clusterResourceGroupName -Location $location -PoolName $clusterpoolName -Name $clusterName -ClusterProfileServiceConfigsProfile $yarnServiceConfigProfile
```

```output
ApplicationLogStdErrorEnabled               : False
ApplicationLogStdOutEnabled                 : False
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  : {00000000-0000-0000-0000-000000000000}
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 : Spark
ComputeProfileNode                          : {Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.NodeProfile, Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.NodeProfile}
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
...
```

Add a key-value `"testvalue1"="111"` to the cluster config file `core-site.xml`.

## PARAMETERS

### -ApplicationLogStdErrorEnabled
True if stderror is enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationLogStdOutEnabled
True if stdout is enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -AuthorizationProfileGroupId
AAD group Ids authorized for data plane access.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationProfileUserId
AAD user Ids authorized for data plane access.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscaleProfileAutoscaleType
User to specify which type of Autoscale to be implemented - Scheduled Based or Load Based.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Support.AutoscaleType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscaleProfileEnabled
This indicates whether auto scale is enabled on HDInsight on AKS cluster.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoscaleProfileGracefulDecommissionTimeout
This property is for graceful decommission timeout; It has a default setting of 3600 seconds before forced shutdown takes place.
This is the maximal time to wait for running containers and applications to complete before transition a DECOMMISSIONING node into DECOMMISSIONED.
The default value is 3600 seconds.
Negative value (like -1) is handled as infinite timeout.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterPatchRequest
The patch for a cluster.
To construct, see NOTES section for CLUSTERPATCHREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterPatch
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterProfileScriptActionProfile
The script action profile list.
To construct, see NOTES section for CLUSTERPROFILESCRIPTACTIONPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IScriptActionProfile[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterProfileServiceConfigsProfile
The service configs profiles.
To construct, see NOTES section for CLUSTERPROFILESERVICECONFIGSPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterServiceConfigsProfile[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LoadBasedConfigCooldownPeriod
This is a cool down period, this is a time period in seconds, which determines the amount of time that must elapse between a scaling activity started by a rule and the start of the next scaling activity, regardless of the rule that triggers it.
The default value is 300 seconds.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigMaxNode
User needs to set the maximum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigMinNode
User needs to set the minimum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigPollInterval
User can specify the poll interval, this is the time period (in seconds) after which scaling metrics are polled for triggering a scaling operation.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBasedConfigScalingRule
The scaling rules.
To construct, see NOTES section for LOADBASEDCONFIGSCALINGRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IScalingRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticProfileEnabled
True if log analytics is enabled for the cluster, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticProfileMetricsEnabled
True if metrics are enabled, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ClusterName

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

### -PoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ClusterPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrometheuProfileEnabled
Enable Prometheus for cluster or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigDefaultCount
Setting default node count of current schedule configuration.
Default node count specifies the number of nodes which are default when an specified scaling operation is executed (scale up/scale down)

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigSchedule
This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).
To construct, see NOTES section for SCHEDULEBASEDCONFIGSCHEDULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ISchedule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleBasedConfigTimeZone
User has to specify the timezone on which the schedule has to be set for schedule based autoscale configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SshProfileCount
Number of ssh pods per cluster.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterPatch

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ICluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CLUSTERPATCHREQUEST <IClusterPatch>`: The patch for a cluster.
  - `Location <String>`: The geo-location where the resource lives
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[ApplicationLogStdErrorEnabled <Boolean?>]`: True if stderror is enabled, otherwise false.
  - `[ApplicationLogStdOutEnabled <Boolean?>]`: True if stdout is enabled, otherwise false.
  - `[AuthorizationProfileGroupId <String[]>]`: AAD group Ids authorized for data plane access.
  - `[AuthorizationProfileUserId <String[]>]`: AAD user Ids authorized for data plane access.
  - `[AutoscaleProfileAutoscaleType <AutoscaleType?>]`: User to specify which type of Autoscale to be implemented - Scheduled Based or Load Based.
  - `[AutoscaleProfileEnabled <Boolean?>]`: This indicates whether auto scale is enabled on HDInsight on AKS cluster.
  - `[AutoscaleProfileGracefulDecommissionTimeout <Int32?>]`: This property is for graceful decommission timeout; It has a default setting of 3600 seconds before forced shutdown takes place. This is the maximal time to wait for running containers and applications to complete before transition a DECOMMISSIONING node into DECOMMISSIONED. The default value is 3600 seconds. Negative value (like -1) is handled as infinite timeout.
  - `[ClusterProfileScriptActionProfile <IScriptActionProfile[]>]`: The script action profile list.
    - `Name <String>`: Script name.
    - `Service <String[]>`: List of services to apply the script action.
    - `Type <String>`: Type of the script action. Supported type is bash scripts.
    - `Url <String>`: Url of the script file.
    - `[Parameter <String>]`: Additional parameters for the script action. It should be space-separated list of arguments required for script execution.
    - `[ShouldPersist <Boolean?>]`: Specify if the script should persist on the cluster.
    - `[TimeoutInMinute <Int32?>]`: Timeout duration for the script action in minutes.
  - `[ClusterProfileServiceConfigsProfile <IClusterServiceConfigsProfile[]>]`: The service configs profiles.
    - `Config <IClusterServiceConfig[]>`: List of service configs.
      - `Component <String>`: Name of the component the config files should apply to.
      - `File <IClusterConfigFile[]>`: List of Config Files.
        - `FileName <String>`: Configuration file name.
        - `[Content <String>]`: Free form content of the entire configuration file.
        - `[Encoding <ContentEncoding?>]`: This property indicates if the content is encoded and is case-insensitive. Please set the value to base64 if the content is base64 encoded. Set it to none or skip it if the content is plain text.
        - `[Path <String>]`: Path of the config file if content is specified.
        - `[Value <IClusterConfigFileValues>]`: List of key value pairs         where key represents a valid service configuration name and value represents the value of the config.
          - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `ServiceName <String>`: Name of the service the configurations should apply to.
  - `[LoadBasedConfigCooldownPeriod <Int32?>]`: This is a cool down period, this is a time period in seconds, which determines the amount of time that must elapse between a scaling activity started by a rule and the start of the next scaling activity, regardless of the rule that triggers it. The default value is 300 seconds.
  - `[LoadBasedConfigMaxNode <Int32?>]`: User needs to set the maximum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.
  - `[LoadBasedConfigMinNode <Int32?>]`: User needs to set the minimum number of nodes for load based scaling, the load based scaling will use this to scale up and scale down between minimum and maximum number of nodes.
  - `[LoadBasedConfigPollInterval <Int32?>]`: User can specify the poll interval, this is the time period (in seconds) after which scaling metrics are polled for triggering a scaling operation.
  - `[LoadBasedConfigScalingRule <IScalingRule[]>]`: The scaling rules.
    - `ActionType <ScaleActionType>`: The action type.
    - `ComparisonRuleOperator <ComparisonOperator>`: The comparison operator.
    - `ComparisonRuleThreshold <Single>`: Threshold setting.
    - `EvaluationCount <Int32>`: This is an evaluation count for a scaling condition, the number of times a trigger condition should be successful, before scaling activity is triggered.
    - `ScalingMetric <String>`: Metrics name for individual workloads. For example: cpu
  - `[LogAnalyticProfileEnabled <Boolean?>]`: True if log analytics is enabled for the cluster, otherwise false.
  - `[LogAnalyticProfileMetricsEnabled <Boolean?>]`: True if metrics are enabled, otherwise false.
  - `[PrometheuProfileEnabled <Boolean?>]`: Enable Prometheus for cluster or not.
  - `[ScheduleBasedConfigDefaultCount <Int32?>]`: Setting default node count of current schedule configuration. Default node count specifies the number of nodes which are default when an specified scaling operation is executed (scale up/scale down)
  - `[ScheduleBasedConfigSchedule <ISchedule[]>]`: This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).
    - `Count <Int32>`: User has to set the node count anticipated at end of the scaling operation of the set current schedule configuration, format is integer.
    - `Day <ScheduleDay[]>`: User has to set the days where schedule has to be set for autoscale operation.
    - `EndTime <String>`: User has to set the end time of current schedule configuration, format like 10:30 (HH:MM).
    - `StartTime <String>`: User has to set the start time of current schedule configuration, format like 10:30 (HH:MM).
  - `[ScheduleBasedConfigTimeZone <String>]`: User has to specify the timezone on which the schedule has to be set for schedule based autoscale configuration.
  - `[SshProfileCount <Int32?>]`: Number of ssh pods per cluster.

`CLUSTERPROFILESCRIPTACTIONPROFILE <IScriptActionProfile[]>`: The script action profile list.
  - `Name <String>`: Script name.
  - `Service <String[]>`: List of services to apply the script action.
  - `Type <String>`: Type of the script action. Supported type is bash scripts.
  - `Url <String>`: Url of the script file.
  - `[Parameter <String>]`: Additional parameters for the script action. It should be space-separated list of arguments required for script execution.
  - `[ShouldPersist <Boolean?>]`: Specify if the script should persist on the cluster.
  - `[TimeoutInMinute <Int32?>]`: Timeout duration for the script action in minutes.

`CLUSTERPROFILESERVICECONFIGSPROFILE <IClusterServiceConfigsProfile[]>`: The service configs profiles.
  - `Config <IClusterServiceConfig[]>`: List of service configs.
    - `Component <String>`: Name of the component the config files should apply to.
    - `File <IClusterConfigFile[]>`: List of Config Files.
      - `FileName <String>`: Configuration file name.
      - `[Content <String>]`: Free form content of the entire configuration file.
      - `[Encoding <ContentEncoding?>]`: This property indicates if the content is encoded and is case-insensitive. Please set the value to base64 if the content is base64 encoded. Set it to none or skip it if the content is plain text.
      - `[Path <String>]`: Path of the config file if content is specified.
      - `[Value <IClusterConfigFileValues>]`: List of key value pairs         where key represents a valid service configuration name and value represents the value of the config.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `ServiceName <String>`: Name of the service the configurations should apply to.

`INPUTOBJECT <IHdInsightOnAksIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the HDInsight cluster.
  - `[ClusterPoolName <String>]`: The name of the cluster pool.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of the Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

`LOADBASEDCONFIGSCALINGRULE <IScalingRule[]>`: The scaling rules.
  - `ActionType <ScaleActionType>`: The action type.
  - `ComparisonRuleOperator <ComparisonOperator>`: The comparison operator.
  - `ComparisonRuleThreshold <Single>`: Threshold setting.
  - `EvaluationCount <Int32>`: This is an evaluation count for a scaling condition, the number of times a trigger condition should be successful, before scaling activity is triggered.
  - `ScalingMetric <String>`: Metrics name for individual workloads. For example: cpu

`SCHEDULEBASEDCONFIGSCHEDULE <ISchedule[]>`: This specifies the schedules where scheduled based Autoscale to be enabled, the user has a choice to set multiple rules within the schedule across days and times (start/end).
  - `Count <Int32>`: User has to set the node count anticipated at end of the scaling operation of the set current schedule configuration, format is integer.
  - `Day <ScheduleDay[]>`: User has to set the days where schedule has to be set for autoscale operation.
  - `EndTime <String>`: User has to set the end time of current schedule configuration, format like 10:30 (HH:MM).
  - `StartTime <String>`: User has to set the start time of current schedule configuration, format like 10:30 (HH:MM).

## RELATED LINKS

