---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotalimit
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaLimit

## SYNOPSIS
Gets the GroupQuotaLimits for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.

## SYNTAX

```
Get-AzQuotaGroupQuotaLimit -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the GroupQuotaLimits for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}.

## EXAMPLES

### Example 1: Get GroupQuota limits for a specific quota group in eastus
```powershell
Get-AzQuotaGroupQuotaLimit -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------
<guid> ... ... ... ... ... ...
```

This example gets the quota limits for the group quota "ComputeGroupQuota01" in the "eastus" region for the Microsoft.Compute resource provider.

### Example 2: Get GroupQuota limits for a different quota group in westus
```powershell
Get-AzQuotaGroupQuotaLimit -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota02" -Location "westus" -ResourceProviderName "Microsoft.Compute"
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------
<guid> ... ... ... ... ... ...
```

This example gets the quota limits for the group quota "ComputeGroupQuota02" in the "westus" region for the Microsoft.Compute resource provider.

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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaLimitList

## NOTES

## RELATED LINKS

