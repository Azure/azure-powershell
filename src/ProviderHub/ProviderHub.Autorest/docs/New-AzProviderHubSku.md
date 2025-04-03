---
external help file:
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubsku
schema: 2.0.0
---

# New-AzProviderHubSku

## SYNOPSIS
Creates or updates the resource type skus in the given resource type.

## SYNTAX

```
New-AzProviderHubSku -ProviderNamespace <String> -ResourceType <String> -Sku <String>
 -SkuSetting <ISkuSetting[]> [-SubscriptionId <String>] [-ProvisioningState <ProvisioningState>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the resource type skus in the given resource type.

## EXAMPLES

### Example 1: Create/Update a resource SKU definition.
```powershell
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}
$skuSetting2 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku2"; Tier = "Tier1"; Kind = "Standard"}

New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default" -SkuSetting $skuSetting1, $skuSetting2
```

```output
Name      Type
----      ----
default   Microsoft.ProviderHub/providerRegistrations/skus
```

Create/Update a resource SKU definition.

### Example 2: Create/Update a nested resource type SKU definition.
```powershell
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default" -SkuSetting $skuSetting1
```

```output
Name      Type
----      ----
default   Microsoft.ProviderHub/providerRegistrations/skus
```

Create/Update a nested resource type SKU definition.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

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

### -ProvisioningState
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type.

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

### -Sku
The SKU.

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

### -SkuSetting
.
To construct, see NOTES section for SKUSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource

## NOTES

## RELATED LINKS

