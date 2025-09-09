---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotasubscriptionallocation
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaSubscriptionAllocation

## SYNOPSIS
Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.
This will include the GroupQuota and total quota allocated to the subscription.
Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.

## SYNTAX

```
Get-AzQuotaGroupQuotaSubscriptionAllocation -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.
This will include the GroupQuota and total quota allocated to the subscription.
Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.

## EXAMPLES


### Example 1: Get all quota allocations for a subscription in a GroupQuota
```powershell
$subscriptionId = "0e745469-49f8-48c9-873b-24ca87143db1"
Get-AzQuotaGroupQuotaSubscriptionAllocation -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -SubscriptionId $subscriptionId
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------
eastus
```

This example gets all quota allocations for the subscription "$subscriptionId" in the group quota "ComputeGroupQuota01" for the "eastus" region and Microsoft.Compute resource provider.

### Example 2: Get all quota allocations for all subscriptions in a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocation -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute"
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   ------------------- ------------------- ----------------------- ------------------------ ------------------------
eastus
```

This example gets all quota allocations for all subscriptions in the group quota "ComputeGroupQuota01" for the "eastus" region and Microsoft.Compute resource provider.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubscriptionQuotaAllocationsList

## NOTES

## RELATED LINKS

