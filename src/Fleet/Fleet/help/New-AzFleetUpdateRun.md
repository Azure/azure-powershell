---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/new-azfleetupdaterun
schema: 2.0.0
---

# New-AzFleetUpdateRun

## SYNOPSIS
Create a UpdateRun

## SYNTAX

### CreateExpanded (Default)
```
New-AzFleetUpdateRun -FleetName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -UpgradeType <String> [-NodeImageSelectionType <String>]
 [-StrategyStage <IUpdateStage[]>] [-UpdateStrategyId <String>] [-UpgradeKubernetesVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFleetUpdateRun -FleetName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFleetUpdateRun -FleetName <String> -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityFleetExpanded
```
New-AzFleetUpdateRun -Name <String> -FleetInputObject <IFleetIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -UpgradeType <String> [-NodeImageSelectionType <String>]
 [-StrategyStage <IUpdateStage[]>] [-UpdateStrategyId <String>] [-UpgradeKubernetesVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzFleetUpdateRun -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 -UpgradeType <String> [-NodeImageSelectionType <String>] [-StrategyStage <IUpdateStage[]>]
 [-UpdateStrategyId <String>] [-UpgradeKubernetesVersion <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a UpdateRun

## EXAMPLES

### Example 1: Create a fleet update run
```powershell
New-AzFleetUpdateRun -FleetName testfleet01 -Name run1 -ResourceGroupName K8sFleet-Test -UpgradeType Full -UpgradeKubernetesVersion "1.26.1" -NodeImageSelectionType Latest
```

```output
AdditionalInfo                             : 
Code                                       : 
Detail                                     : 
ETag                                       : "cb06884a-0000-0100-0000-655c7fcf0000"
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
SystemDataCreatedAt                        : 11/21/2023 10:00:46 AM
SystemDataCreatedBy                        : user1@example.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 11/21/2023 10:00:46 AM
SystemDataLastModifiedBy                   : user1@example.com
SystemDataLastModifiedByType               : User
Target                                     : 
Type                                       : Microsoft.ContainerService/fleets/updateRuns
UpdateStrategyId                           : 
UpgradeKubernetesVersion                   : 1.28.1
UpgradeType                                : Full
```

This command create a fleet update run.

## PARAMETERS

### -AsJob
Runthecommandasajob

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
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: CreateViaIdentityFleetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FleetName
ThenameoftheFleetresource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
Therequestshouldonlyproceedifanentitymatchesthisstring.

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
Therequestshouldonlyproceedifnoentitymatchesthisstring.

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
IdentityParameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
PathofJsonfilesuppliedtotheCreateoperation

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
JsonstringsuppliedtotheCreateoperation

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

### -Name
ThenameoftheUpdateRunresource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityFleetExpanded
Aliases: UpdateRunName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeImageSelectionType
Thenodeimageupgradetype.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Runthecommandasynchronously

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StrategyStage
Thelistofstagesthatcomposethisupdaterun.Minsize:1.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateStage[]
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
TheIDofthetargetsubscription.

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

### -UpdateStrategyId
TheresourceidoftheFleetUpdateStrategyresourcetoreference.Whencreatinganewrun,therearethreewaystodefineastrategyfortherun:1.Defineanewstrategyinplace:Setthe"strategy"field.2.Useanexistingstrategy:Setthe"updateStrategyId"field.(since2023-08-15-preview)3.Usethedefaultstrategytoupdateallthemembersonebyone:Leaveboth"updateStrategyId"and"strategy"unset.(since2023-08-15-preview)Settingboth"updateStrategyId"and"strategy"isinvalid.UpdateRunscreatedby"updateStrategyId"snapshotthereferencedUpdateStrategyatthetimeofcreationandstoreitinthe"strategy"field.SubsequentchangestothereferencedFleetUpdateStrategyresourcedonotpropagate.UpdateRunStrategychangescanbemadedirectlyonthe"strategy"fieldbeforelaunchingtheUpdateRun.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeKubernetesVersion
TheKubernetesversiontoupgradethememberclustersto.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeType
Theupgradetype.FullrequirestheKubernetesVersionpropertytobeset.NodeImageOnlyrequirestheKubernetesVersionpropertynottobeset.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityFleetExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
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
