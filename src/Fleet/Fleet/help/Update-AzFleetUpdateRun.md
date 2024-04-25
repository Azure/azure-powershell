---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/update-azfleetupdaterun
schema: 2.0.0
---

# Update-AzFleetUpdateRun

## SYNOPSIS
Update a UpdateRun

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFleetUpdateRun -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-NodeImageSelectionType <String>]
 [-StrategyStage <IUpdateStage[]>] [-UpdateStrategyId <String>] [-UpgradeKubernetesVersion <String>]
 [-UpgradeType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityFleetExpanded
```
Update-AzFleetUpdateRun -Name <String> -FleetInputObject <IFleetIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-NodeImageSelectionType <String>] [-StrategyStage <IUpdateStage[]>]
 [-UpdateStrategyId <String>] [-UpgradeKubernetesVersion <String>] [-UpgradeType <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFleetUpdateRun -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-NodeImageSelectionType <String>] [-StrategyStage <IUpdateStage[]>] [-UpdateStrategyId <String>]
 [-UpgradeKubernetesVersion <String>] [-UpgradeType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a UpdateRun

## EXAMPLES

### Example 1: Update a fleet update run
```powershell
Update-AzFleetUpdateRun -FleetName testfleet01 -Name run1 -ResourceGroupName K8sFleet-Test -UpgradeKubernetesVersion "1.28.3"
```

```output
AdditionalInfo                             : 
Code                                       : 
Detail                                     : 
ETag                                       : "cb067c64-0000-0100-0000-655c808d0000"
Id                                         : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateRuns/run1
Message                                    : 
Name                                       : run1
NodeImageSelectionSelectedNodeImageVersion : 
NodeImageSelectionType                     : Latest
ProvisioningState                          : Succeeded
ResourceGroupName                          : K8sFleet-Test
StatusCompletedTime                        : 
StatusStage                                : {{
                                               "status": {
                                                 "state": "NotStarted"
                                               },
                                               "name": "default",
                                               "groups": [
                                                 {
                                                   "status": {
                                                     "state": "NotStarted"
                                                   },
                                                   "name": "default",
                                                   "members": [
                                                     {
                                                       "status": {
                                                         "state": "NotStarted"
                                                       },
                                                       "name": "testmember",
                                                       "clusterResourceId":
                                             "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/TestCluster01"
                                                     },
                                                     {
                                                       "status": {
                                                         "state": "NotStarted"
                                                       },
                                                       "name": "testmember2",
                                                       "clusterResourceId":
                                             "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/testCluster02"
                                                     }
                                                   ]
                                                 }
                                               ]
                                             }}
StatusStartTime                            : 
StatusState                                : NotStarted
StrategyStage                              : 
SystemDataCreatedAt                        : 11/21/2023 10:03:56 AM
SystemDataCreatedBy                        : user1@example.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 11/21/2023 10:03:56 AM
SystemDataLastModifiedBy                   : user1@example.com
SystemDataLastModifiedByType               : User
Target                                     : 
Type                                       : Microsoft.ContainerService/fleets/updateRuns
UpdateStrategyId                           : 
UpgradeKubernetesVersion                   : 1.28.3
UpgradeType                                : Full
```

This command updates specified fleet update run.

## PARAMETERS

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
The name of the UpdateRun resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityFleetExpanded
Aliases: UpdateRunName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeImageSelectionType
The node image upgrade type.

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
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateStrategyId
The resource id of the FleetUpdateStrategy resource to reference.When creating a new run, there are three ways to define a strategy for the run:1.
Define a new strategy in place: Set the "strategy" field.2.
Use an existing strategy: Set the "updateStrategyId" field.
(since 2023-08-15-preview)3.
Use the default strategy to update all the members one by one: Leave both "updateStrategyId" and "strategy" unset.
(since 2023-08-15-preview)Setting both "updateStrategyId" and "strategy" is invalid.UpdateRuns created by "updateStrategyId" snapshot the referenced UpdateStrategy at the time of creation and store it in the "strategy" field.
Subsequent changes to the referenced FleetUpdateStrategy resource do not propagate.
UpdateRunStrategy changes can be made directly on the "strategy" field before launching the UpdateRun.

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

### -UpgradeKubernetesVersion
The Kubernetes version to upgrade the member clusters to.

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

### -UpgradeType
The upgrade type.Full requires the KubernetesVersion property to be set.NodeImageOnly requires the KubernetesVersion property not to be set.

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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateRun

## NOTES

## RELATED LINKS
