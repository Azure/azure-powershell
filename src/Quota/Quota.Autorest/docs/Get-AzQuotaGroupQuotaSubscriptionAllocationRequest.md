---
external help file:
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

### GetViaIdentity
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGroupQuota
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String>
 -GroupQuotaInputObject <IQuotaIdentity> -ResourceProviderName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String> -GroupQuotaName <String>
 -ManagementGroupInputObject <IQuotaIdentity> -ResourceProviderName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityResourceProvider
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -AllocationId <String>
 -ResourceProviderInputObject <IQuotaIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -Filter <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the quota allocation request status for the subscriptionId by allocationId.

## EXAMPLES

### Example 1: List GroupQuotasSubscriptionAllocationRequest for a GroupQuota and Subscription
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -SubscriptionId "<subscription>"
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Succeeded         75
11111111-1111-1111-1111-111111111111 InProgress        100
```

List all GroupQuotasSubscriptionAllocationRequests for a specified GroupQuota, resource provider, resource, and subscription.

### Example 2: Get a specific GroupQuotasSubscriptionAllocationRequest by RequestId
```powershell
Get-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -SubscriptionId "<subscription>" -RequestId "00000000-0000-0000-0000-000000000000"
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Succeeded         75
```

Get details of a specific GroupQuotasSubscriptionAllocationRequest by its request ID.

## PARAMETERS

### -AllocationId
Request Id.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityGroupQuota, GetViaIdentityManagementGroup, GetViaIdentityResourceProvider
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
Parameter Sets: Get, GetViaIdentityGroupQuota, GetViaIdentityManagementGroup, List
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

