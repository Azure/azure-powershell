---
external help file:
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/get-azcomputefleet
schema: 2.0.0
---

# Get-AzComputeFleet

## SYNOPSIS
Get a Fleet

## SYNTAX

### ListBySubscriptionId (Default)
```
Get-AzComputeFleet [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzComputeFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzComputeFleet -InputObject <IComputeFleetIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByResourceGroup
```
Get-AzComputeFleet -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Fleet

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
Get-AzComputeFleet -ResourceGroupName "test-fleet" -FleetName "testFleet"
```

### -------------------------- EXAMPLE 2 --------------------------
```powershell
Get-AzComputeFleet -SubscriptionId "ca8520e1-3c83-4b64-bb99-60a64673daa3"
```

### -------------------------- EXAMPLE 3 --------------------------
```powershell
Get-AzComputeFleet -ResourceGroupName "test-fleet"
```

### -------------------------- EXAMPLE 4 --------------------------
```powershell
$fleet = Get-AzComputeFleet -SubscriptionId "ca8520e1-3c83-4b64-bb99-60a64673daa3" -ResourceGroupName "test-fleet" -FleetName "testFleet"
Get-AzComputeFleet -InputObject $fleet
```



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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Compute Fleet

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FleetName

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
Parameter Sets: Get, ListByResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, ListByResourceGroup, ListBySubscriptionId
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

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet

## NOTES

## RELATED LINKS

