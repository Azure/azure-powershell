---
external help file: Az.ComputeFleet-help.xml
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/get-azcomputefleet
schema: 2.0.0
---

# Get-AzComputeFleet

## SYNOPSIS
Get a Fleet

## SYNTAX

### List1 (Default)
```
Get-AzComputeFleet [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzComputeFleet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzComputeFleet -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzComputeFleet -InputObject <IComputeFleetIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Fleet

## EXAMPLES

### Example 1: Get a specific Compute Fleet by name
```powershell
Get-AzComputeFleet -Name "fleet1" -ResourceGroupName "fleet-ps-tst" | Select-Object Name, Location, ProvisioningState, Mode, RegularPriorityProfileCapacity, RegularPriorityProfileAllocationStrategy
```

```output
Name                                     : fleet1
Location                                 : EastUS2EUAP
ProvisioningState                        : Succeeded
Mode                                     : Launch
RegularPriorityProfileCapacity           : 5
RegularPriorityProfileAllocationStrategy : LowestPrice
```

Retrieves a specific Compute Fleet by name and resource group, returning its full configuration including compute profile, VM sizes, priority settings, and provisioning state.

### Example 2: List all Compute Fleets in a resource group
```powershell
Get-AzComputeFleet -ResourceGroupName "fleet-ps-tst" | Select-Object Name, Location, ProvisioningState, Mode
```

```output
Name              : fleet1
Location          : EastUS2EUAP
ProvisioningState : Succeeded
Mode              : Launch
```

Lists all Compute Fleets within the specified resource group.

### Example 3: List all Compute Fleets in the current subscription
```powershell
Get-AzComputeFleet | Select-Object Name, Location, ResourceGroupName, ProvisioningState, Mode
```

```output
Name              : fleet1
Location          : EastUS2EUAP
ResourceGroupName : FLEET-PS-TST
ProvisioningState : Succeeded
Mode              : Launch

Name              : fleet5-001
Location          : eastus2euap
ResourceGroupName : MY-FLEET-RG-001
ProvisioningState : Succeeded
Mode              : Managed
```

Lists all Compute Fleets across all resource groups in the current subscription.

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
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
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
