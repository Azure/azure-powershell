---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/update-azquotagroupquota
schema: 2.0.0
---

# Update-AzQuotaGroupQuota

## SYNOPSIS
Update the GroupQuotas for the name passed.
A GroupQuotas RequestId will be returned by the Service.
The status can be polled periodically.
The status Async polling is using standards defined at - https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/async-api-reference.md#asynchronous-operations.
Use the OperationsStatus URI provided in Azure-AsyncOperation header, the duration will be specified in retry-after header.
Once the operation gets to terminal state - Succeeded | Failed, then the URI will change to Get URI and full details can be checked.
\n Any change in the filters will be applicable to the future quota assignments, existing quota allocated to subscriptions from the GroupQuotas remains unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzQuotaGroupQuota -ManagementGroupId <String> -Name <String> [-DisplayName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzQuotaGroupQuota -InputObject <IQuotaIdentity> [-DisplayName <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroupExpanded
```
Update-AzQuotaGroupQuota -ManagementGroupInputObject <IQuotaIdentity> -Name <String> [-DisplayName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzQuotaGroupQuota -ManagementGroupId <String> -Name <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzQuotaGroupQuota -ManagementGroupId <String> -Name <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the GroupQuotas for the name passed.
A GroupQuotas RequestId will be returned by the Service.
The status can be polled periodically.
The status Async polling is using standards defined at - https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/async-api-reference.md#asynchronous-operations.
Use the OperationsStatus URI provided in Azure-AsyncOperation header, the duration will be specified in retry-after header.
Once the operation gets to terminal state - Succeeded | Failed, then the URI will change to Get URI and full details can be checked.
\n Any change in the filters will be applicable to the future quota assignments, existing quota allocated to subscriptions from the GroupQuotas remains unchanged.

## EXAMPLES

### Example 1: Update the display name of a GroupQuota
```powershell
Update-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota01" -DisplayName "Updated Compute Quota"
```

```output
RequestId   Status     Name                 DisplayName
---------   ------     ----                 -----------
<guid>      Succeeded  ComputeGroupQuota01  Updated Compute Quota
```

This example updates the display name of the GroupQuota "ComputeGroupQuota01" in the management group "mg-demo".

### Example 2: Update a GroupQuota using a JSON file
```powershell
Update-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota02" -JsonFilePath "../docs-data/update-groupquota.json"
```

```output
RequestId   Status     Name                 DisplayName
---------   ------     ----                 -----------
<guid>      Succeeded  ComputeGroupQuota02  Quota Updated via JSON
```

This example updates the GroupQuota "ComputeGroupQuota02" in the management group "mg-demo" using the configuration specified in the JSON file.

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

### -DisplayName
Display name of the GroupQuota entity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityManagementGroupExpanded
Aliases:

Required: False
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

### -Name
The GroupQuota name.
The name should be unique for the provided context tenantId/MgId.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityManagementGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: GroupQuotaName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotasEntity

## NOTES

## RELATED LINKS

