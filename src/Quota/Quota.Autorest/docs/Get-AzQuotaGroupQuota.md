---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquota
schema: 2.0.0
---

# Get-AzQuotaGroupQuota

## SYNOPSIS
Gets the GroupQuotas for the name passed.
It will return the GroupQuotas properties only.
The details on group quota can be access from the group quota APIs.

## SYNTAX

### List (Default)
```
Get-AzQuotaGroupQuota -ManagementGroupId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzQuotaGroupQuota -ManagementGroupId <String> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaGroupQuota -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuota -ManagementGroupInputObject <IQuotaIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the GroupQuotas for the name passed.
It will return the GroupQuotas properties only.
The details on group quota can be access from the group quota APIs.

## EXAMPLES

### Example 1: Get a specific GroupQuota by name
```powershell
Get-AzQuotaGroupQuota -ManagementGroupId "mg-demo" -Name "ComputeGroupQuota01"
```

```output
Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----                ------------------- ------------------- ----------------------- ------------------------ -----------
ComputeGroupQuota01  
```

This example retrieves the GroupQuota named "ComputeGroupQuota01" for the management group "mg-demo".

### Example 2: List all GroupQuotas in a management group
```powershell
Get-AzQuotaGroupQuota -ManagementGroupId "mg-demo"
```

```output
Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----                ------------------- ------------------- ----------------------- ------------------------ -----------
premiumgroup                                                                                          jsonquota                                                                                             jsonstringquota                                                                                       standardgroup                                                                                         computegroupquota01                                                                                   computegroupquota02  
```

This example lists all GroupQuotas for the management group "mg-demo".

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

### -Name
The GroupQuota name.
The name should be unique for the provided context tenantId/MgId.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityManagementGroup
Aliases: GroupQuotaName

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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotasEntity

## NOTES

## RELATED LINKS

