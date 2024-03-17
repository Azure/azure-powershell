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
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityFleetExpanded
```
Update-AzFleetUpdateStrategy -Name <String> -FleetInputObject <IFleetIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFleetUpdateStrategy -InputObject <IFleetIdentity> [-IfMatch <String>] [-IfNoneMatch <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a FleetUpdateStrategy

## EXAMPLES

### Example 1: Update a fleet update strategy with a fleet object
```powershell
$f = Get-AzFleet -Name testfleet01 -ResourceGroupName K8sFleet-Test
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600
Update-AzFleetUpdateStrategy -FleetInputObject $f -Name strategy3 -StrategyStage $stage
```

```output
ETag                         : "8906612a-0000-0100-0000-655b2c330000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/updateStrategies/strategy3
Name                         : strategy3
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
SystemDataCreatedAt          : 11/20/2023 9:51:46 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/20/2023 9:51:46 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

The first command get a fleet.
The second command creates a new fleet update stage object.
The third command updates stage for specified fleet update strategy with a fleet object.

### Example 2: Update a fleet update strategy
```powershell
$stage = New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 360
Update-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1 -StrategyStage $stage
```

```output
ETag                         : "c9064db3-0000-0100-0000-655c75350000"
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
                                 "afterStageWaitInSeconds": 360
                               }}
SystemDataCreatedAt          : 11/21/2023 9:15:33 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/21/2023 9:15:33 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/updateStrategies
```

This command updates stage for specified fleet update strategy.

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
Parameter Sets: UpdateViaIdentityFleetExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
ThenameoftheUpdateStrategyresource.

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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
