---
external help file:
Module Name: Az.QuotaExtensionApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.quotaextensionapi/get-azquotaextensionapiusage
schema: 2.0.0
---

# Get-AzQuotaExtensionApiUsage

## SYNOPSIS
Get the current usage of a resource.

## SYNTAX

### List (Default)
```
Get-AzQuotaExtensionApiUsage -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzQuotaExtensionApiUsage -ResourceName <String> -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaExtensionApiUsage -InputObject <IQuotaExtensionApiIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the current usage of a resource.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.IQuotaExtensionApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceName
Resource name for a given resource provider.
For example:
- SKU name for Microsoft.Compute
- SKU or TotalLowPriorityCores for Microsoft.MachineLearningServices
 For Microsoft.Network PublicIPAddresses.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The target Azure resource URI.
For example, `/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/qms-test/providers/Microsoft.Batch/batchAccounts/testAccount/`.
This is the target Azure resource URI for the List GET operation.
If a `{resourceName}` is added after `/quotas`, then it's the target Azure resource URI in the GET operation for the specific resource.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.IQuotaExtensionApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.QuotaExtensionApi.Models.Api20210315Preview.ICurrentUsagesBase

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IQuotaExtensionApiIdentity>: Identity Parameter
  - `[Id <String>]`: Quota request ID.
  - `[Id1 <String>]`: Resource identity path
  - `[ResourceName <String>]`: Resource name for a given resource provider. For example:         - SKU name for Microsoft.Compute         - SKU or TotalLowPriorityCores for Microsoft.MachineLearningServices          For Microsoft.Network PublicIPAddresses.
  - `[Scope <String>]`: The target Azure resource URI. For example, `/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/qms-test/providers/Microsoft.Batch/batchAccounts/testAccount/`. This is the target Azure resource URI for the List GET operation. If a `{resourceName}` is added after `/quotas`, then it's the target Azure resource URI in the GET operation for the specific resource.

## RELATED LINKS

