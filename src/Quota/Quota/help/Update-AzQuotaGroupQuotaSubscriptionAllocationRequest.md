---
external help file: Az.Quota-help.xml
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
 [-Value <ISubscriptionQuotaAllocations[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityManagementGroupExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -GroupQuotaName <String> -Location <String>
 -ResourceProviderName <String> -ManagementGroupInputObject <IQuotaIdentity>
 [-Value <ISubscriptionQuotaAllocations[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityResourceProviderExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -Location <String>
 -ResourceProviderInputObject <IQuotaIdentity> [-Value <ISubscriptionQuotaAllocations[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityGroupQuotaExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -Location <String> -ResourceProviderName <String>
 -GroupQuotaInputObject <IQuotaIdentity> [-Value <ISubscriptionQuotaAllocations[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzQuotaGroupQuotaSubscriptionAllocationRequest -InputObject <IQuotaIdentity>
 [-Value <ISubscriptionQuotaAllocations[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Request to assign quota from group quota to a specific Subscription.
The assign GroupQuota to subscriptions or reduce the quota allocated to subscription to give back the unused quota ( quota \>= usages) to the groupQuota.
So, this API can be used to assign Quota to subscriptions and assign back unused quota to group quota, which can be assigned to another subscriptions in the GroupQuota.
User can collect unused quotas from multiple subscriptions within the groupQuota and assign the groupQuota to the subscription, where it's needed.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

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
Parameter Sets: UpdateViaIdentityGroupQuotaExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityManagementGroupExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityResourceProviderExpanded, UpdateViaIdentityGroupQuotaExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateViaIdentityManagementGroupExpanded
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
Parameter Sets: UpdateViaIdentityResourceProviderExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityGroupQuotaExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityResourceProviderExpanded, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubscriptionQuotaAllocationsList

## NOTES

## RELATED LINKS
