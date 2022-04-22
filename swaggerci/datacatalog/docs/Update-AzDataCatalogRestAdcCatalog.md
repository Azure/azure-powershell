---
external help file:
Module Name: Az.DataCatalogRest
online version: https://docs.microsoft.com/en-us/powershell/module/az.datacatalogrest/update-azdatacatalogrestadccatalog
schema: 2.0.0
---

# Update-AzDataCatalogRestAdcCatalog

## SYNOPSIS
The Update Azure Data Catalog Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataCatalogRestAdcCatalog -CatalogName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Admin <IPrincipals[]>] [-EnableAutomaticUnitAdjustment] [-Etag <String>]
 [-Location <String>] [-Sku <SkuType>] [-SuccessfullyProvisioned] [-Tag <Hashtable>] [-Unit <Int32>]
 [-User <IPrincipals[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataCatalogRestAdcCatalog -InputObject <IDataCatalogRestIdentity> [-Admin <IPrincipals[]>]
 [-EnableAutomaticUnitAdjustment] [-Etag <String>] [-Location <String>] [-Sku <SkuType>]
 [-SuccessfullyProvisioned] [-Tag <Hashtable>] [-Unit <Int32>] [-User <IPrincipals[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Update Azure Data Catalog Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Admin
Azure data catalog admin list.
To construct, see NOTES section for ADMIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataCatalogRest.Models.Api20160330.IPrincipals[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CatalogName
The name of the data catalog in the specified subscription and resource group.

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

### -EnableAutomaticUnitAdjustment
Automatic unit adjustment enabled or not.

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

### -Etag
Resource etag

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
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataCatalogRest.Models.IDataCatalogRestIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Resource location

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

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

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

### -Sku
Azure data catalog SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataCatalogRest.Support.SkuType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -SuccessfullyProvisioned
Azure data catalog provision status.

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

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Unit
Azure data catalog units.

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

### -User
Azure data catalog user list.
To construct, see NOTES section for USER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataCatalogRest.Models.Api20160330.IPrincipals[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.DataCatalogRest.Models.IDataCatalogRestIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataCatalogRest.Models.Api20160330.IAdcCatalog

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ADMIN <IPrincipals[]>: Azure data catalog admin list.
  - `[ObjectId <String>]`: Object Id for the user
  - `[Upn <String>]`: UPN of the user.

INPUTOBJECT <IDataCatalogRestIdentity>: Identity Parameter
  - `[CatalogName <String>]`: The name of the data catalog in the specified subscription and resource group.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group within the user's subscription. The name is case insensitive.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

USER <IPrincipals[]>: Azure data catalog user list.
  - `[ObjectId <String>]`: Object Id for the user
  - `[Upn <String>]`: UPN of the user.

## RELATED LINKS

