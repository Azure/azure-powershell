---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/new-azfleetupdatestrategy
schema: 2.0.0
---

# New-AzFleetUpdateStrategy

## SYNOPSIS
Create a FleetUpdateStrategy

## SYNTAX

### CreateViaIdentityExpanded (Default)
```
New-AzFleetUpdateStrategy -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 -StrategyStage <IUpdateStage[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFleetUpdateStrategy -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFleetUpdateStrategy -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzFleetUpdateStrategy -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -StrategyStage <IUpdateStage[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityFleetExpanded
```
New-AzFleetUpdateStrategy -Name <String> -FleetInputObject <IFleetIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -StrategyStage <IUpdateStage[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a FleetUpdateStrategy

## EXAMPLES

### Example 1: Create a fleet update strategy
```powershell
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600
New-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1 -StrategyStage $stage
```

```output
ETag                         : "fd057996-0000-0100-0000-65572da20000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateStrategies/strategy1
Name                         : strategy1
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
StrategyStage                : {{
                                 "name": "stag1",
                                 "groups": [
                                   {
                                     "name": "group-a"
                                   }
                                 ],
                                 "afterStageWaitInSeconds": 3600
                               }}
SystemDataCreatedAt          : 11/17/2023 9:08:49 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/17/2023 9:08:49 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

The first command creates a fleet update stage object.
The second command creates a fleet update strategy.

### Example 2: Create a fleet update strategy with a fleet object
```powershell
$f = Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
$stage2 = New-AzFleetUpdateStageObject -Name stag2 -Group @{name='group-b'} -AfterStageWaitInSecond 3600
New-AzFleetUpdateStrategy -FleetInputObject $f -Name strategy3 -StrategyStage $stage2
```

```output
ETag                         : "88067ac6-0000-0100-0000-655b29860000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateStrategies/strategy3
Name                         : strategy3
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
StrategyStage                : {{
                                 "name": "stag2",
                                 "groups": [
                                   {
                                     "name": "group-b"
                                   }
                                 ],
                                 "afterStageWaitInSeconds": 3600
                               }}
SystemDataCreatedAt          : 11/20/2023 9:40:21 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/20/2023 9:40:21 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

The first command get a fleet.
The second command creates a fleet update stage object.
The third command uses fleet resource to create a fleet update strategy.

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
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
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
ThenameoftheUpdateStrategyresource.

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded, CreateViaIdentityFleetExpanded
Aliases:

Required: True
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
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
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
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded, CreateViaIdentityFleetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
TheIDofthetargetsubscription.

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString, CreateViaJsonFilePath, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## RELATED LINKS
