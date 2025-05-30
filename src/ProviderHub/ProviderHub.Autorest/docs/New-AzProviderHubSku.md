---
external help file:
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubsku
schema: 2.0.0
---

# New-AzProviderHubSku

## SYNOPSIS
Create the resource type skus in the given resource type.

## SYNTAX

### CreateExpanded (Default)
```
New-AzProviderHubSku -ProviderNamespace <String> -ResourceType <String> -Sku <String>
 [-SubscriptionId <String>] [-ProvisioningState <String>] [-SkuSetting <ISkuSetting[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProviderRegistrationExpanded
```
New-AzProviderHubSku -ProviderRegistrationInputObject <IProviderHubIdentity> -ResourceType <String>
 -Sku <String> [-ProvisioningState <String>] [-SkuSetting <ISkuSetting[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityResourcetypeRegistrationExpanded
```
New-AzProviderHubSku -ResourcetypeRegistrationInputObject <IProviderHubIdentity> -Sku <String>
 [-ProvisioningState <String>] [-SkuSetting <ISkuSetting[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzProviderHubSku -ProviderNamespace <String> -ResourceType <String> -Sku <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzProviderHubSku -ProviderNamespace <String> -ResourceType <String> -Sku <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the resource type skus in the given resource type.

## EXAMPLES

### Example 1: Create/Update a resource SKU definition.
```powershell
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}
$skuSetting2 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.SkuSetting" -Property @{Name = "freeSku2"; Tier = "Tier1"; Kind = "Standard"}

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
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

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

### -JsonFilePath
Path of Json file supplied to the Create operation

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
Json string supplied to the Create operation

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

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderRegistrationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProvisioningState
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded, CreateViaIdentityResourcetypeRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourcetypeRegistrationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: CreateViaIdentityResourcetypeRegistrationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded, CreateViaIdentityResourcetypeRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuResource

## NOTES

## RELATED LINKS

