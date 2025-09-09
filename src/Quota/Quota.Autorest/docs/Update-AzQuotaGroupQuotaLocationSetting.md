---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/update-azquotagroupquotalocationsetting
schema: 2.0.0
---

# Update-AzQuotaGroupQuotaLocationSetting

## SYNOPSIS
Enables the GroupQuotas enforcement for the resource provider and the location specified.
The resource provider will start using the group quotas as the overall quota for the subscriptions included in the GroupQuota.
The subscriptions cannot request quota at subscription level since it is now part of an enforced group.\nThe subscriptions share the GroupQuotaLimits assigned to the GroupQuota.
If the GroupQuotaLimits is used, then submit a groupQuotaLimit request for the specific resource - provider/location/resource.\nOnce the GroupQuota Enforcement is enabled then, it cannot be deleted or reverted back.
To disable GroupQuota Enforcement -\n 1.
Remove all the subscriptions from the groupQuota using the delete API for Subscriptions (Check the example - GroupQuotaSubscriptions_Delete).\n 2.
Ten delete the GroupQuota (Check the example - GroupQuotas_Delete).

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> [-EnforcementEnabled <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzQuotaGroupQuotaLocationSetting -InputObject <IQuotaIdentity> [-EnforcementEnabled <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityGroupQuotaExpanded
```
Update-AzQuotaGroupQuotaLocationSetting -GroupQuotaInputObject <IQuotaIdentity> -Location <String>
 -ResourceProviderName <String> [-EnforcementEnabled <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroupExpanded
```
Update-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String>
 -ManagementGroupInputObject <IQuotaIdentity> -ResourceProviderName <String> [-EnforcementEnabled <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityResourceProviderExpanded
```
Update-AzQuotaGroupQuotaLocationSetting -Location <String> -ResourceProviderInputObject <IQuotaIdentity>
 [-EnforcementEnabled <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzQuotaGroupQuotaLocationSetting -GroupQuotaName <String> -Location <String>
 -ManagementGroupId <String> -ResourceProviderName <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enables the GroupQuotas enforcement for the resource provider and the location specified.
The resource provider will start using the group quotas as the overall quota for the subscriptions included in the GroupQuota.
The subscriptions cannot request quota at subscription level since it is now part of an enforced group.\nThe subscriptions share the GroupQuotaLimits assigned to the GroupQuota.
If the GroupQuotaLimits is used, then submit a groupQuotaLimit request for the specific resource - provider/location/resource.\nOnce the GroupQuota Enforcement is enabled then, it cannot be deleted or reverted back.
To disable GroupQuota Enforcement -\n 1.
Remove all the subscriptions from the groupQuota using the delete API for Subscriptions (Check the example - GroupQuotaSubscriptions_Delete).\n 2.
Ten delete the GroupQuota (Check the example - GroupQuotas_Delete).

## EXAMPLES

### Example 1: Update GroupQuota enforcement for Compute in eastus
```powershell
Update-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota01" -Location "eastus" -ResourceProviderName "Microsoft.Compute" -EnforcementEnabled "Enabled"
```

```output
Name                 Location   ResourceProviderName   EnforcementEnabled   Status
----                 --------   -------------------   -------------------  ------
ComputeGroupQuota01  eastus     Microsoft.Compute     Enabled              Succeeded
```

This example updates GroupQuota enforcement for the group quota "ComputeGroupQuota01" in the "eastus" region for the Microsoft.Compute resource provider.

### Example 2: Update GroupQuota enforcement using a JSON file
```powershell
Update-AzQuotaGroupQuotaLocationSetting -ManagementGroupId "mg-demo" -GroupQuotaName "ComputeGroupQuota02" -Location "westus" -ResourceProviderName "Microsoft.Compute" -JsonFilePath "../docs-data/update-groupquota-location.json"
```

```output
Name                 Location   ResourceProviderName   EnforcementEnabled   Status
----                 --------   -------------------   -------------------  ------
ComputeGroupQuota02  westus     Microsoft.Compute     Enabled              Succeeded
```

This example updates GroupQuota enforcement for the group quota "ComputeGroupQuota02" in the "westus" region for the Microsoft.Compute resource provider using the configuration specified in the JSON file.

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityResourceProviderExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaIdentityResourceProviderExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityGroupQuotaExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

