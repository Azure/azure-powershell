---
external help file:
Module Name: Az.EdgeOrderPartnerApiS
online version: https://docs.microsoft.com/en-us/powershell/module/az.edgeorderpartnerapis/search-azedgeorderpartnerapisinventory
schema: 2.0.0
---

# Search-AzEdgeOrderPartnerApiSInventory

## SYNOPSIS
API for Search inventories

## SYNTAX

### SearchExpanded (Default)
```
Search-AzEdgeOrderPartnerApiSInventory -FamilyIdentifier <String> -SerialNumber <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Search
```
Search-AzEdgeOrderPartnerApiSInventory -SearchInventoriesRequest <ISearchInventoriesRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SearchViaIdentity
```
Search-AzEdgeOrderPartnerApiSInventory -InputObject <IEdgeOrderPartnerApiSIdentity>
 -SearchInventoriesRequest <ISearchInventoriesRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SearchViaIdentityExpanded
```
Search-AzEdgeOrderPartnerApiSInventory -InputObject <IEdgeOrderPartnerApiSIdentity> -FamilyIdentifier <String>
 -SerialNumber <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API for Search inventories

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

### -FamilyIdentifier
Family identifier for inventory

```yaml
Type: System.String
Parameter Sets: SearchExpanded, SearchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.IEdgeOrderPartnerApiSIdentity
Parameter Sets: SearchViaIdentity, SearchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SearchInventoriesRequest
Request body for SearchInventories call
To construct, see NOTES section for SEARCHINVENTORIESREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.ISearchInventoriesRequest
Parameter Sets: Search, SearchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SerialNumber
Serial number of the inventory

```yaml
Type: System.String
Parameter Sets: SearchExpanded, SearchViaIdentityExpanded
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
Parameter Sets: Search, SearchExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.ISearchInventoriesRequest

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.IEdgeOrderPartnerApiSIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.IPartnerInventory

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IEdgeOrderPartnerApiSIdentity>: Identity Parameter
  - `[FamilyIdentifier <String>]`: Unique identifier for the product family
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the resource
  - `[SerialNumber <String>]`: The serial number of the device
  - `[SubscriptionId <String>]`: The ID of the target subscription.

SEARCHINVENTORIESREQUEST <ISearchInventoriesRequest>: Request body for SearchInventories call
  - `FamilyIdentifier <String>`: Family identifier for inventory
  - `SerialNumber <String>`: Serial number of the inventory

## RELATED LINKS

