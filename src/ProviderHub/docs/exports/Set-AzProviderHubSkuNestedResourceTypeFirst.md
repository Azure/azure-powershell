---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/set-azproviderhubskunestedresourcetypefirst
schema: 2.0.0
---

# Set-AzProviderHubSkuNestedResourceTypeFirst

## SYNOPSIS
Creates or updates the resource type skus in the given resource type.

## SYNTAX

### Update (Default)
```
Set-AzProviderHubSkuNestedResourceTypeFirst -NestedResourceTypeFirst <String> -ProviderNamespace <String>
 -ResourceType <String> -Sku <String> -Property <IResourceTypeSku> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzProviderHubSkuNestedResourceTypeFirst -NestedResourceTypeFirst <String> -ProviderNamespace <String>
 -ResourceType <String> -Sku <String> -SkuSetting <ISkuSetting[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the resource type skus in the given resource type.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

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

### -NestedResourceTypeFirst
The first child resource type.

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

### -Property
.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSku
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeSku

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PROPERTY <IResourceTypeSku>: .
  - `SkuSetting <ISkuSetting[]>`: 
    - `Name <String>`: 
    - `[Capability <ISkuCapability[]>]`: 
      - `Name <String>`: 
      - `Value <String>`: 
    - `[CapacityDefault <Int32?>]`: 
    - `[CapacityMaximum <Int32?>]`: 
    - `[CapacityMinimum <Int32?>]`: 
    - `[CapacityScaleType <SkuScaleType?>]`: 
    - `[Cost <ISkuCost[]>]`: 
      - `MeterId <String>`: 
      - `[ExtendedUnit <String>]`: 
      - `[Quantity <Int32?>]`: 
    - `[Family <String>]`: 
    - `[Kind <String>]`: 
    - `[Location <String[]>]`: 
    - `[LocationInfo <ISkuLocationInfo[]>]`: 
      - `Location <String>`: 
      - `[ExtendedLocation <String[]>]`: 
      - `[Type <String>]`: 
      - `[Zone <String[]>]`: 
      - `[ZoneDetail <ISkuZoneDetail[]>]`: 
        - `[Capability <ISkuCapability[]>]`: 
        - `[Name <String[]>]`: 
    - `[RequiredFeature <String[]>]`: 
    - `[RequiredQuotaId <String[]>]`: 
    - `[Size <String>]`: 
    - `[Tier <String>]`: 

SKUSETTING <ISkuSetting[]>: .
  - `Name <String>`: 
  - `[Capability <ISkuCapability[]>]`: 
    - `Name <String>`: 
    - `Value <String>`: 
  - `[CapacityDefault <Int32?>]`: 
  - `[CapacityMaximum <Int32?>]`: 
  - `[CapacityMinimum <Int32?>]`: 
  - `[CapacityScaleType <SkuScaleType?>]`: 
  - `[Cost <ISkuCost[]>]`: 
    - `MeterId <String>`: 
    - `[ExtendedUnit <String>]`: 
    - `[Quantity <Int32?>]`: 
  - `[Family <String>]`: 
  - `[Kind <String>]`: 
  - `[Location <String[]>]`: 
  - `[LocationInfo <ISkuLocationInfo[]>]`: 
    - `Location <String>`: 
    - `[ExtendedLocation <String[]>]`: 
    - `[Type <String>]`: 
    - `[Zone <String[]>]`: 
    - `[ZoneDetail <ISkuZoneDetail[]>]`: 
      - `[Capability <ISkuCapability[]>]`: 
      - `[Name <String[]>]`: 
  - `[RequiredFeature <String[]>]`: 
  - `[RequiredQuotaId <String[]>]`: 
  - `[Size <String>]`: 
  - `[Tier <String>]`: 

## RELATED LINKS

