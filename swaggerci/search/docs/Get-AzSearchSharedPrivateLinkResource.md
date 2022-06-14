---
external help file:
Module Name: Az.Search
online version: https://docs.microsoft.com/en-us/powershell/module/az.search/get-azsearchsharedprivatelinkresource
schema: 2.0.0
---

# Get-AzSearchSharedPrivateLinkResource

## SYNOPSIS
Gets the details of the shared private link resource managed by the search service in the given resource group.

## SYNTAX

### List (Default)
```
Get-AzSearchSharedPrivateLinkResource -ResourceGroupName <String> -SearchServiceName <String>
 [-SubscriptionId <String[]>] [-ClientRequestId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSearchSharedPrivateLinkResource -Name <String> -ResourceGroupName <String> -SearchServiceName <String>
 [-SubscriptionId <String[]>] [-ClientRequestId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSearchSharedPrivateLinkResource -InputObject <ISearchIdentity> [-ClientRequestId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the details of the shared private link resource managed by the search service in the given resource group.

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

### -ClientRequestId
A client-generated GUID value that identifies this request.
If specified, this will be included in response information as a way to track the request.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Search.Models.ISearchIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the shared private link resource managed by the Azure Cognitive Search service within the specified resource group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SharedPrivateLinkResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the current subscription.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -SearchServiceName
The name of the Azure Cognitive Search service associated with the specified resource group.

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
The unique identifier for a Microsoft Azure subscription.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.ISearchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Search.Models.Api20200801.ISharedPrivateLinkResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ISearchIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[Key <String>]`: The query key to be deleted. Query keys are identified by value, not by name.
  - `[KeyKind <AdminKeyKind?>]`: Specifies which key to regenerate. Valid values include 'primary' and 'secondary'.
  - `[Name <String>]`: The name of the new query API key.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection to the Azure Cognitive Search service with the specified resource group.
  - `[ResourceGroupName <String>]`: The name of the resource group within the current subscription. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[SearchServiceName <String>]`: The name of the Azure Cognitive Search service associated with the specified resource group.
  - `[SharedPrivateLinkResourceName <String>]`: The name of the shared private link resource managed by the Azure Cognitive Search service within the specified resource group.
  - `[SubscriptionId <String>]`: The unique identifier for a Microsoft Azure subscription. You can obtain this value from the Azure Resource Manager API or the portal.

## RELATED LINKS

