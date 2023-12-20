---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/update-azfleetupdatestrategy
schema: 2.0.0
---

# Update-AzFleetUpdateStrategy

## SYNOPSIS
Create a FleetUpdateStrategy

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFleetUpdateStrategy -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-StrategyStage <IUpdateStage[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityFleetExpanded
```
Update-AzFleetUpdateStrategy -Name <String> -FleetInputObject <IFleetIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-StrategyStage <IUpdateStage[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFleetUpdateStrategy -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-StrategyStage <IUpdateStage[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a FleetUpdateStrategy

## EXAMPLES

### EXAMPLE 1
```
$f = Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600
Update-AzFleetUpdateStrategy -FleetInputObject $f -Name strategy3 -StrategyStage $stage
```

### EXAMPLE 2
```
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 360
Update-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1 -StrategyStage $stage
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

### -FleetInputObject
Identity Parameter
To construct, see NOTES section for FLEETINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: UpdateViaIdentityFleetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FleetName
The name of the Fleet resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The request should only proceed if an entity matches this string.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfNoneMatch
The request should only proceed if no entity matches this string.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the UpdateStrategy resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityFleetExpanded
Aliases:

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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StrategyStage
The list of stages that compose this update run.
Min size: 1.
To construct, see NOTES section for STRATEGYSTAGE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateStage[]
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetUpdateStrategy
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

FLEETINPUTOBJECT \<IFleetIdentity\>: Identity Parameter
  \[FleetMemberName \<String\>\]: The name of the Fleet member resource.
  \[FleetName \<String\>\]: The name of the Fleet resource.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[UpdateRunName \<String\>\]: The name of the UpdateRun resource.
  \[UpdateStrategyName \<String\>\]: The name of the UpdateStrategy resource.

INPUTOBJECT \<IFleetIdentity\>: Identity Parameter
  \[FleetMemberName \<String\>\]: The name of the Fleet member resource.
  \[FleetName \<String\>\]: The name of the Fleet resource.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[UpdateRunName \<String\>\]: The name of the UpdateRun resource.
  \[UpdateStrategyName \<String\>\]: The name of the UpdateStrategy resource.

STRATEGYSTAGE \<IUpdateStage\[\]\>: The list of stages that compose this update run.
Min size: 1.
  Name \<String\>: The name of the stage.
Must be unique within the UpdateRun.
  \[AfterStageWaitInSecond \<Int32?\>\]: The time in seconds to wait at the end of this stage before starting the next one.
Defaults to 0 seconds if unspecified.
  \[Group \<List\<IUpdateGroup\>\>\]: Defines the groups to be executed in parallel in this stage.
Duplicate groups are not allowed.
Min size: 1.
    Name \<String\>: Name of the group. 
It must match a group name of an existing fleet member.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.fleet/update-azfleetupdatestrategy](https://learn.microsoft.com/powershell/module/az.fleet/update-azfleetupdatestrategy)

