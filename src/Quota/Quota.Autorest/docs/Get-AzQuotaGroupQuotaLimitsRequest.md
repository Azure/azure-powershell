---
external help file:
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotalimitsrequest
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaLimitsRequest

## SYNOPSIS
Get API to check the status of a GroupQuota request by requestId.

## SYNTAX

### Get (Default)
```
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -ManagementGroupId <String> -RequestId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaGroupQuotaLimitsRequest -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGroupQuota
```
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaInputObject <IQuotaIdentity> -RequestId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -ManagementGroupInputObject <IQuotaIdentity>
 -RequestId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzQuotaGroupQuotaLimitsRequest -GroupQuotaName <String> -ManagementGroupId <String>
 -ResourceProviderName <String> -Filter <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get API to check the status of a GroupQuota request by requestId.

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

### -Filter
| Field | Supported operators 
|---------------------|------------------------

 location eq {location} and resource eq {resourceName}
 Example: $filter=location eq eastus and resourceName eq cores

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

### -RequestId
Request Id.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityGroupQuota, GetViaIdentityManagementGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderName
The resource provider name, such as - Microsoft.Compute.
Currently only Microsoft.Compute resource provider supports this API.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IQuotaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.ISubmittedResourceRequestStatus

## NOTES

## RELATED LINKS

