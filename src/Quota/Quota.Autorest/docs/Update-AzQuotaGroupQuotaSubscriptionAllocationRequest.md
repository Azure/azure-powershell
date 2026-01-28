---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/update-azquotagroupquotasubscriptionallocationrequest
schema: 2.0.0
---

# Update-AzQuotaGroupQuotaSubscriptionAllocationRequest

## SYNOPSIS
Request to assign quota from group quota to a specific Subscription.
The assign GroupQuota to subscriptions or reduce the quota allocated to subscription to give back the unused quota ( quota \>= usages) to the groupQuota.
So, this API can be used to assign Quota to subscriptions and assign back unused quota to group quota, which can be assigned to another subscriptions in the GroupQuota.
User can collect unused quotas from multiple subscriptions within the groupQuota and assign the groupQuota to the subscription, where it's needed.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> [-SubscriptionId <String>]
 [-Value <ISubscriptionQuotaAllocations[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String>
 -AllocateQuotaRequest <ISubscriptionQuotaAllocationsList> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -InputObject <IQuotaIdentity>
 -AllocateQuotaRequest <ISubscriptionQuotaAllocationsList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -InputObject <IQuotaIdentity>
 [-Value <ISubscriptionQuotaAllocations[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityGroupQuota
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaInputObject <IQuotaIdentity>
 -Location <String> -ResourceProviderName <String> -AllocateQuotaRequest <ISubscriptionQuotaAllocationsList>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityGroupQuotaExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaInputObject <IQuotaIdentity>
 -Location <String> -ResourceProviderName <String> [-Value <ISubscriptionQuotaAllocations[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroup
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupInputObject <IQuotaIdentity> -ResourceProviderName <String>
 -AllocateQuotaRequest <ISubscriptionQuotaAllocationsList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroupExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupInputObject <IQuotaIdentity> -ResourceProviderName <String>
 [-Value <ISubscriptionQuotaAllocations[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityResourceProvider
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -Location <String>
 -ResourceProviderInputObject <IQuotaIdentity> -AllocateQuotaRequest <ISubscriptionQuotaAllocationsList>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityResourceProviderExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -Location <String>
 -ResourceProviderInputObject <IQuotaIdentity> [-Value <ISubscriptionQuotaAllocations[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Request to assign quota from group quota to a specific Subscription.
The assign GroupQuota to subscriptions or reduce the quota allocated to subscription to give back the unused quota ( quota \>= usages) to the groupQuota.
So, this API can be used to assign Quota to subscriptions and assign back unused quota to group quota, which can be assigned to another subscriptions in the GroupQuota.
User can collect unused quotas from multiple subscriptions within the groupQuota and assign the groupQuota to the subscription, where it's needed.

## EXAMPLES

### Example 1: Update GroupQuotasSubscriptionAllocationRequest for a GroupQuota and Subscription
```powershell
$allocation = @{
    ResourceName = "standardav2family"
    Limit = 50
}
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mgId" -ResourceProviderName "Microsoft.Compute" -SubscriptionId "<subscription>" -Location "eastus" -Value $allocation
```

```output
RequestId                            ProvisioningState RequestedLimit
---------                            ----------------- --------------
00000000-0000-0000-0000-000000000000 Accepted          50
```

Updates a GroupQuotasSubscriptionAllocationRequest for a specified GroupQuota, resource provider, resource, subscription, and region with new quota allocation limits.

## PARAMETERS

### -AllocateQuotaRequest
Subscription quota list.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubscriptionQuotaAllocationsList
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityGroupQuota, UpdateViaIdentityManagementGroup, UpdateViaIdentityResourceProvider
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -GroupQuotaInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity
Parameter Sets: UpdateViaIdentityGroupQuota, UpdateViaIdentityGroupQuotaExpanded
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
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityManagementGroup, UpdateViaIdentityManagementGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityGroupQuota, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityManagementGroup, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityResourceProvider, UpdateViaIdentityResourceProviderExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupId
The management group ID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateViaIdentityManagementGroup, UpdateViaIdentityManagementGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity
Parameter Sets: UpdateViaIdentityResourceProvider, UpdateViaIdentityResourceProviderExpanded
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
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityGroupQuota, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityManagementGroup, UpdateViaIdentityManagementGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Subscription quota list.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubscriptionQuotaAllocations[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityResourceProviderExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubscriptionQuotaAllocationsList

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubscriptionQuotaAllocationsList

## NOTES

## RELATED LINKS

