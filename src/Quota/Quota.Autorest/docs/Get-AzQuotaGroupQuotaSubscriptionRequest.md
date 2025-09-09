---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotasubscriptionrequest
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaSubscriptionRequest

## SYNOPSIS
Get API to check the status of a subscriptionIds request by requestId.
Use the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

## SYNTAX

### List (Default)
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName <String> -ManagementGroupId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName <String> -ManagementGroupId <String>
 -RequestId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaGroupQuotaSubscriptionRequest -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGroupQuota
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaInputObject <IQuotaIdentity> -RequestId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName <String> -ManagementGroupInputObject <IQuotaIdentity>
 -RequestId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get API to check the status of a subscriptionIds request by requestId.
Use the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

## EXAMPLES


### Example 1: Get the status of a subscription request by requestId
```powershell
$requestId = "abcd1234-5678-90ef-ghij-1234567890ab"
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "ComputeGroupQuota01" -ManagementGroupId "mg-demo" -RequestId $requestId
```

```output
RequestId                                Status     Subscriptions
---------                                ------     -------------
abcd1234-5678-90ef-ghij-1234567890ab     Succeeded  0e745469-49f8-48c9-873b-24ca87143db1
```

This example gets the status of a subscription request using the request ID stored in `$requestId` for the group quota "ComputeGroupQuota01".

### Example 2: List all subscription requests for a GroupQuota
```powershell
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName "ComputeGroupQuota01" -ManagementGroupId "mg-demo"
```

```output
RequestId                                Status     Subscriptions
---------                                ------     -------------
abcd1234-5678-90ef-ghij-1234567890ab     Succeeded  0e745469-49f8-48c9-873b-24ca87143db1
bcde2345-6789-01fg-hijk-2345678901bc     Failed     1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d
```

This example lists all subscription requests for the group quota "ComputeGroupQuota01" in the management group "mg-demo".

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

### -GroupQuotaInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity
Parameter Sets: GetViaIdentityGroupQuota
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GroupQuotaName
The GroupQuota name.
The name should be unique for the provided context tenantId/MgId.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityManagementGroup, List
Aliases:

Required: True
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

### -ManagementGroupId
Management Group Id.

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

### -ManagementGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity
Parameter Sets: GetViaIdentityManagementGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RequestId
Request Id.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityGroupQuota, GetViaIdentityManagementGroup
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaSubscriptionRequestStatus

## NOTES

## RELATED LINKS

