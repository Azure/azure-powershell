---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquota
schema: 2.0.0
---

# Get-AzQuota

## SYNOPSIS
Get the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.

## SYNTAX

### List (Default)
```
Get-AzQuota -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzQuota -ResourceName <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuota -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.

## EXAMPLES

### Example 1: List the quota limits of a scope
```powershell
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus"
```

```output
Name              NameLocalizedValue  Unit  ETag
----              ------------------  ----  ----
VirtualNetworks   Virtual Networks    Count
CustomIpPrefixes  Custom Ip Prefixes  Count
PublicIpPrefixes  Public Ip Prefixes  Count
PublicIPAddresses Public IP Addresses Count
......
```

This command lists the quota limits of a scope.

### Example 2: Get the quota limit of a resource
```powershell
Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus" -ResourceName VirtualNetworks
```

```output
Name            NameLocalizedValue Unit  ETag
----            ------------------ ----  ----
VirtualNetworks Virtual Networks   Count
```

This command gets the quota limit of a resource.
The response can be used to determine the remaining quota to calculate a new quota limit that can be submitted with a PUT request.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ICurrentQuotaLimitBase

## NOTES

## RELATED LINKS

