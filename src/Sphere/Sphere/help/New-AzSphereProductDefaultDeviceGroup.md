---
external help file: Az.Sphere-help.xml
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/new-azsphereproductdefaultdevicegroup
schema: 2.0.0
---

# New-AzSphereProductDefaultDeviceGroup

## SYNOPSIS
Generates default device groups for the product.
'.default' and '.unassigned' are system defined values and cannot be used for product name.

## SYNTAX

### Generate (Default)
```
New-AzSphereProductDefaultDeviceGroup -CatalogName <String> -ProductName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### GenerateViaIdentityCatalog
```
New-AzSphereProductDefaultDeviceGroup -ProductName <String> -CatalogInputObject <ISphereIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzSphereProductDefaultDeviceGroup -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Generates default device groups for the product.
'.default' and '.unassigned' are system defined values and cannot be used for product name.

## EXAMPLES

### Example 1: Generate default device groups for the product
```powershell
New-AzSphereProductDefaultDeviceGroup -CatalogName test2024 -ProductName product0207 -ResourceGroupName group-test
```

```output
Name                     SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                     ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
Development                                                                                                                                                             group-test
Field Test                                                                                                                                                              group-test
Production                                                                                                                                                              group-test
Production OS Evaluation                                                                                                                                                group-test
Field Test OS Evaluation                                                                                                                                                group-test
```

This command generates default device groups for the product.

## PARAMETERS

### -CatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GenerateViaIdentityCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

```yaml
Type: System.String
Parameter Sets: Generate
Aliases:

Required: True
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProductName
Name of product.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateViaIdentityCatalog
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
Parameter Sets: Generate
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
Type: System.String
Parameter Sets: Generate
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IDeviceGroup

## NOTES

## RELATED LINKS
