---
external help file: Az.Quota-help.xml
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotausage
schema: 2.0.0
---

# Get-AzQuotaUsage

## SYNOPSIS
Get the current usage of a resource.

## SYNTAX

### List (Default)
```
Get-AzQuotaUsage -Scope <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzQuotaUsage -Scope <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the current usage of a resource.

## EXAMPLES

### Example 1: List the currents usage of a resource
```powershell
Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"
```

```output
Name              NameLocalizedValue  UsageUsagesType UsageValue ETag
----              ------------------  --------------- ---------- ----
VirtualNetworks   Virtual Networks    Individual      2
CustomIpPrefixes  Custom Ip Prefixes  Individual      0
PublicIpPrefixes  Public Ip Prefixes  Individual      0
PublicIPAddresses Public IP Addresses Individual      4
......
```

This command lists the currents usage of a resource

### Example 2: Get the current usage of a resource
```powershell
Get-AzQuotaUsage -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -Name "MinPublicIpInterNetworkPrefixLength"
```

```output
Name                                NameLocalizedValue        UsageUsagesType UsageValue ETag
----                                ------------------        --------------- ---------- ----
MinPublicIpInterNetworkPrefixLength Public IPv4 Prefix Length Individual      0
```

This command lists the currents usage of a resource.

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

### -Name
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ICurrentUsagesBase

## NOTES

## RELATED LINKS
