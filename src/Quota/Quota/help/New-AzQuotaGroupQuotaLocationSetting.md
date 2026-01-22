---
external help file: Az.Quota-help.xml
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/new-azquotagroupquotalocationsetting
schema: 2.0.0
---

# New-AzQuotaGroupQuotaLocationSetting

## SYNOPSIS
Enables the GroupQuotas enforcement for the resource provider and the location specified.
The resource provider will start using the group quotas as the overall quota for the subscriptions included in the GroupQuota.
The subscriptions cannot request quota at subscription level since it is now part of an enforced group.\nThe subscriptions share the GroupQuotaLimits assigned to the GroupQuota.
If the GroupQuotaLimits is used, then submit a groupQuotaLimit request for the specific resource - provider/location/resource.\nOnce the GroupQuota Enforcement is enabled then, it cannot be deleted or reverted back.
To disable GroupQuota Enforcement -\n1.
Remove all the subscriptions from the groupQuota using the delete API for Subscriptions (Check the example - GroupQuotaSubscriptions_Delete).\n2.
Then delete the GroupQuota (Check the example - GroupQuotas_Delete).

## SYNTAX

### CreateExpanded (Default)
```
New-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> [-EnforcementEnabled <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityManagementGroupExpanded
```
New-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String> -ResourceProviderName <String>
 -ManagementGroupInputObject <IQuotaIdentity> [-EnforcementEnabled <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityResourceProviderExpanded
```
New-AzQuotaGroupQuotaLocationSetting -Location <String> -ResourceProviderInputObject <IQuotaIdentity>
 [-EnforcementEnabled <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityGroupQuotaExpanded
```
New-AzQuotaGroupQuotaLocationSetting -Location <String> -ResourceProviderName <String>
 -GroupQuotaInputObject <IQuotaIdentity> [-EnforcementEnabled <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzQuotaGroupQuotaLocationSetting -InputObject <IQuotaIdentity> [-EnforcementEnabled <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Enables the GroupQuotas enforcement for the resource provider and the location specified.
The resource provider will start using the group quotas as the overall quota for the subscriptions included in the GroupQuota.
The subscriptions cannot request quota at subscription level since it is now part of an enforced group.\nThe subscriptions share the GroupQuotaLimits assigned to the GroupQuota.
If the GroupQuotaLimits is used, then submit a groupQuotaLimit request for the specific resource - provider/location/resource.\nOnce the GroupQuota Enforcement is enabled then, it cannot be deleted or reverted back.
To disable GroupQuota Enforcement -\n1.
Remove all the subscriptions from the groupQuota using the delete API for Subscriptions (Check the example - GroupQuotaSubscriptions_Delete).\n2.
Then delete the GroupQuota (Check the example - GroupQuotas_Delete).

## EXAMPLES

### Example 1: Create a new GroupQuota location setting
```powershell
$jsonBody = @{
    properties = @{
        enforcementEnabled = "Enabled"
    }
} | ConvertTo-Json

New-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mgId" -GroupQuotaName "groupquota1" -ResourceProviderName "Microsoft.Compute" -Location "eastus" -JsonString $jsonBody -NoWait
```

```output
Name   EnforcementEnabled ProvisioningState
----   ------------------ -----------------
eastus Enabled            Succeeded
```

Create or configure a location setting for a specified GroupQuota, resource provider, and location.
The JsonString parameter specifies whether enforcement is enabled for this location.

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

### -EnforcementEnabled
Is the GroupQuota Enforcement enabled for the Azure region.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityManagementGroupExpanded, CreateViaIdentityResourceProviderExpanded, CreateViaIdentityGroupQuotaExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: CreateViaIdentityGroupQuotaExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityManagementGroupExpanded
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityManagementGroupExpanded, CreateViaIdentityResourceProviderExpanded, CreateViaIdentityGroupQuotaExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateViaIdentityManagementGroupExpanded
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: CreateViaIdentityResourceProviderExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityManagementGroupExpanded, CreateViaIdentityGroupQuotaExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotasEnforcementStatus

## NOTES

## RELATED LINKS
