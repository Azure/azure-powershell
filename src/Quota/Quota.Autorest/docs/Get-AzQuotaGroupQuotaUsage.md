---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotausage
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaUsage

## SYNOPSIS
Gets the GroupQuotas usages and limits(quota).
Location is required paramter.

## SYNTAX

```
Get-AzQuotaGroupQuotaUsage -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the GroupQuotas usages and limits(quota).
Location is required paramter.

## EXAMPLES


### Example 1: Get GroupQuota usage for a specific quota group in eastus
```powershell
$groupQuotaName = "ComputeGroupQuota01"
$location = "eastus"
$mgId = "mg-demo"
$resourceProvider = "Microsoft.Compute"
Get-AzQuotaGroupQuotaUsage -GroupQuotaName $groupQuotaName -Location $location -ManagementGroupId $mgId -ResourceProviderName $resourceProvider
```

```output
ResourceName         CurrentValue   Limit   Unit
------------         ------------   -----   ----
standardDSv3Family   8              10      Count
```

This example gets the usage and limits for the group quota "$groupQuotaName" in the "$location" region for the "$resourceProvider" resource provider.

### Example 2: Get GroupQuota usage for a different quota group in westus
```powershell
$groupQuotaName = "ComputeGroupQuota02"
$location = "westus"
$mgId = "mg-demo"
$resourceProvider = "Microsoft.Compute"
Get-AzQuotaGroupQuotaUsage -GroupQuotaName $groupQuotaName -Location $location -ManagementGroupId $mgId -ResourceProviderName $resourceProvider
```

```output
ResourceName         CurrentValue   Limit   Unit
------------         ------------   -----   ----
standardDSv3Family   5              8       Count
```

This example gets the usage and limits for the group quota "$groupQuotaName" in the "$location" region for the "$resourceProvider" resource provider.

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

### -GroupQuotaName
The GroupQuota name.
The name should be unique for the provided context tenantId/MgId.

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

### -Location
The name of the Azure region.

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

### -ManagementGroupId
Management Group Id.

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

### -ResourceProviderName
The resource provider name, such as - Microsoft.Compute.
Currently only Microsoft.Compute resource provider supports this API.

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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IResourceUsages

## NOTES

## RELATED LINKS

