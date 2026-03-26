---
external help file: Az.Quota-help.xml
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotasubscriptionallocationrequest
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaSubscriptionAllocationRequest

## SYNOPSIS
Get the quota allocation request status for the subscriptionId by allocationId.

## SYNTAX

### Get (Default)
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String> -GroupQuotaName <String>
 -ManagementGroupId <String> -ResourceProviderName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityResourceProvider
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String>
 -ResourceProviderInputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String> -GroupQuotaName <String>
 -ResourceProviderName <String> -ManagementGroupInputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGroupQuota
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String> -ResourceProviderName <String>
 -GroupQuotaInputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -ManagementGroupId <String>
 -ResourceProviderName <String> [-SubscriptionId <String[]>] -Filter <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the quota allocation request status for the subscriptionId by allocationId.

## EXAMPLES

### Example 1: List GroupQuotasSubscriptionAllocationRequest for a GroupQuota and Subscription
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -SubscriptionId "{subId}" -Filter "location eq eastus"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- ------------------------
af428d0f-52e8-4c47-ba83-534a27f2d9bb
e5a41235-6a37-4466-b744-306c4873237d
9187e498-dea8-43e1-98a8-3f90a9cc1653
```

List all GroupQuotasSubscriptionAllocationRequests for a specified GroupQuota, resource provider, and subscription filtered by location.

### Example 2: Get a specific GroupQuotasSubscriptionAllocationRequest by AllocationId
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "testlocation" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -SubscriptionId "{subId}" -AllocationId "af428d0f-52e8-4c47-ba83-534a27f2d9bb"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt
----                                 ------------------- ------------------- ----------------------- ------------------------
af428d0f-52e8-4c47-ba83-534a27f2d9bb
```

Get details of a specific GroupQuotasSubscriptionAllocationRequest by its allocation ID.

## PARAMETERS

### -AllocationId
Request Id.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityResourceProvider, GetViaIdentityManagementGroup, GetViaIdentityGroupQuota
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Filter
| Field | Supported operators
|---------------------|------------------------

location eq {location}
Example: $filter=location eq eastus

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
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
The management group ID.

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

### -ResourceProviderInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity
Parameter Sets: GetViaIdentityResourceProvider
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceProviderName
The resource provider name, such as - Microsoft.Compute.
Currently only Microsoft.Compute resource provider supports this API.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityManagementGroup, GetViaIdentityGroupQuota, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaAllocationRequestStatus

## NOTES

## RELATED LINKS
