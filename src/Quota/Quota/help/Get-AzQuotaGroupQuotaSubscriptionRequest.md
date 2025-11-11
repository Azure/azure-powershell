---
external help file: Az.Quota-help.xml
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

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName <String> -RequestId <String>
 -ManagementGroupInputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzQuotaGroupQuotaSubscriptionRequest -GroupQuotaName <String> -ManagementGroupId <String>
 -RequestId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityGroupQuota
```
Get-AzQuotaGroupQuotaSubscriptionRequest -RequestId <String> -GroupQuotaInputObject <IQuotaIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaGroupQuotaSubscriptionRequest -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get API to check the status of a subscriptionIds request by requestId.
Use the polling API - OperationsStatus URI specified in Azure-AsyncOperation header field, with retry-after duration in seconds to check the intermediate status.
This API provides the finals status with the request details and status.

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
Parameter Sets: List, GetViaIdentityManagementGroup, Get
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
Parameter Sets: List, Get
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
Parameter Sets: GetViaIdentityManagementGroup, Get, GetViaIdentityGroupQuota
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
