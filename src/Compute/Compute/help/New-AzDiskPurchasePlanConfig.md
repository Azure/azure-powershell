---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azdiskpurchaseplanconfig
schema: 2.0.0
---

# New-AzDiskPurchasePlanConfig

## SYNOPSIS
Creates a PurchasePlan Object

## SYNTAX

```
New-AzDiskPurchasePlanConfig -Publisher <String> -Name <String> -Product <String> [-PromotionCode <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a PurchasePlan Object

## EXAMPLES

### Example 1
```powershell
$diskPurchasePlan = New-AzDiskPurchasePlanConfig -Name "planName" -Publisher "planPublisher" -Product "planPorduct" -PromotionCode "planPromotionCode"
$diskConfig = New-AzDiskConfig -Location 'eastus2euap' -AccountType 'Premium_LRS' -CreateOption 'Empty' -DiskSizeGB 32 -PurchasePlan $diskPurchasePlan
New-AzDisk -ResourceGroupName 'ResourceGroup02' -DiskName 'Disk02' -Disk $diskConfig
$disk = Get-AzDisk -ResourceGroupName 'ResourceGroup02' -DiskName 'Disk02'
```

Customers can set the PurchasePlan on the Managed Disks.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Config

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Product
Name of Product

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PromotionCode
PromotionCode for Purchase Plan

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Publisher
Name of Publisher

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSPurchasePlan

### Microsoft.Azure.Commands.Compute.Automation.Models.PSPurchasePlan

## NOTES

## RELATED LINKS
