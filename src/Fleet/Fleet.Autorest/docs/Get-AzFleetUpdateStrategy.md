---
external help file:
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/az.fleet/get-azfleetupdatestrategy
schema: 2.0.0
---

# Get-AzFleetUpdateStrategy

## SYNOPSIS
Get a FleetUpdateStrategy

## SYNTAX

### List (Default)
```
Get-AzFleetUpdateStrategy -FleetName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFleetUpdateStrategy -FleetName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFleetUpdateStrategy -InputObject <IFleetIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFleet
```
Get-AzFleetUpdateStrategy -FleetInputObject <IFleetIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a FleetUpdateStrategy

## EXAMPLES

### Example 1: Get a list of fleet update strategy with specified fleet
```powershell
Get-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test
```

```output
Name       SystemDataCreatedAt   SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ETag                                   ResourceG 
                                                                                                                                                                                                     roupName  
----       -------------------   -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----                                   --------- 
strategy1  11/17/2023 9:08:49 AM user1@example.com     User                    11/17/2023 9:08:49 AM    user1@example.com        User                         "fd057996-0000-0100-0000-65572da20000" K8sFleet… 
strategy2  11/20/2023 9:36:32 AM user1@example.com     User                    11/20/2023 9:36:32 AM    user1@example.com        User                         "88066ba5-0000-0100-0000-655b28a00000" K8sFleet… 
strategy3  11/20/2023 9:40:21 AM user1@example.com     User                    11/20/2023 9:40:21 AM    user1@example.com        User                         "88067ac6-0000-0100-0000-655b29860000" K8sFleet… 
```

This command get a list of fleet update strategy.

### Example 2: Get a fleet update strategy with specified name
```powershell
Get-AzFleetUpdateStrategy -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name strategy1
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

This command gets specific a fleet update strategy with specified update strategy name.

## PARAMETERS

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
Parameter Sets: GetViaIdentityFleet
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IFleetIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, GetViaIdentityFleet
Aliases:

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

