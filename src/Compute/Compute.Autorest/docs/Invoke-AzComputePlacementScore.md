---
external help file:
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/invoke-azcomputeplacementscore
schema: 2.0.0
---

# Invoke-AzComputePlacementScore

## SYNOPSIS
Generates placement scores for Compute VM SKUs.

## SYNTAX
```
Invoke-AzComputePlacementScore -Location <String> -DesiredSize <IResourceSize[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AvailabilityZone] [-DesiredCount <Int32>] [-DesiredLocation <String[]>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Generates placement scores for regular Compute VM SKUs in the requested regions and availability zones.

## EXAMPLES

### Example 1: Get regional placement scores
```powershell
$desiredSizes = @(@{ sku = 'Standard_D2_v3' }, @{ sku = 'Standard_D4_v3' })
Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredLocation @('eastus2', 'westus')
```

### Example 2: Get zonal placement scores
```powershell
$desiredSizes = @(@{ sku = 'Standard_D2_v3' })
Invoke-AzComputePlacementScore -Location eastus -DesiredSize $desiredSizes -DesiredCount 2 -AvailabilityZone
```

## PARAMETERS

### -AvailabilityZone
Defines if the scope is zonal or regional.

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
The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -DesiredCount
Desired instance count per region or zone based on the scope.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DesiredLocation
The desired regions. If not set, the location from the request URI is used.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DesiredSize
The desired virtual machine SKU sizes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IResourceSize[]
Parameter Sets: (All)
Aliases:
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IResourceSize[]

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
