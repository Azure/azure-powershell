---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/update-azquotagroupquotalimitsrequest
schema: 2.0.0
---

# Update-AzQuotaGroupQuotaLimitsRequest

## SYNOPSIS
Update the GroupQuota requests for a specific ResourceProvider/Location/Resource.
The resourceName properties are specified in the request body.
Only 1 resource quota can be requested.
Please note that patch request update a new groupQuota request.\nUse the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> [-Value <IGroupQuotaLimit[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -GroupQuotaRequest <IGroupQuotaLimitList> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzQuotaGroupQuotaLimitsRequest -InputObject <IQuotaIdentity> -GroupQuotaRequest <IGroupQuotaLimitList>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzQuotaGroupQuotaLimitsRequest -InputObject <IQuotaIdentity> [-Value <IGroupQuotaLimit[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityGroupQuota
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaInputObject <IQuotaIdentity> -Location <String>
 -ResourceProviderName <String> -GroupQuotaRequest <IGroupQuotaLimitList> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityGroupQuotaExpanded
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaInputObject <IQuotaIdentity> -Location <String>
 -ResourceProviderName <String> [-Value <IGroupQuotaLimit[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroup
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupInputObject <IQuotaIdentity> -ResourceProviderName <String>
 -GroupQuotaRequest <IGroupQuotaLimitList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityManagementGroupExpanded
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -Location <String>
 -ManagementGroupInputObject <IQuotaIdentity> -ResourceProviderName <String> [-Value <IGroupQuotaLimit[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityResourceProvider
```
Update-AzQuotaGroupQuotaLimitsRequest -Location <String> -ResourceProviderInputObject <IQuotaIdentity>
 -GroupQuotaRequest <IGroupQuotaLimitList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityResourceProviderExpanded
```
Update-AzQuotaGroupQuotaLimitsRequest -Location <String> -ResourceProviderInputObject <IQuotaIdentity>
 [-Value <IGroupQuotaLimit[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -Location <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the GroupQuota requests for a specific ResourceProvider/Location/Resource.
The resourceName properties are specified in the request body.
Only 1 resource quota can be requested.
Please note that patch request update a new groupQuota request.\nUse the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

## EXAMPLES

### Example 1: Update GroupQuotasLimitsRequest for a GroupQuota
```powershell
$limitObject = New-AzQuotaLimitObject -Value 100
Update-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName "groupquota1" -ManagementGroupId "mg-demo" -ResourceProviderName "Microsoft.Compute" -ResourceName "standardav2family" -Region "eastus" -Limit $limitObject
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----                                 ------------------- ------------------- -----------------------
{guid}
```

Updates a GroupQuotasLimitsRequest for a specified GroupQuota, resource provider, resource, and region with new quota limits.

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

### -GroupQuotaRequest
List of Group Quota Limit details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaLimitList
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityGroupQuota, UpdateViaIdentityManagementGroup, UpdateViaIdentityResourceProvider
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Value
List of Group Quota Limit details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaLimit[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaLimitList

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaLimitList

## NOTES

## RELATED LINKS

