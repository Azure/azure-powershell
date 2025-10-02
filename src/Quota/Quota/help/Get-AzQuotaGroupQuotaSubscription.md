---
external help file: Az.Quota-help.xml
Module Name: Az.Quota
online version: https://learn.microsoft.com/powershell/module/az.quota/get-azquotagroupquotasubscription
schema: 2.0.0
---

# Get-AzQuotaGroupQuotaSubscription

## SYNOPSIS
Returns the subscriptionIds along with its provisioning state for being associated with the GroupQuota.
If the subscription is not a member of GroupQuota, it will return 404, else 200.

## SYNTAX

### Get (Default)
```
Get-AzQuotaGroupQuotaSubscription -GroupQuotaName <String> -ManagementGroupId <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzQuotaGroupQuotaSubscription -GroupQuotaName <String> -ManagementGroupId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityManagementGroup
```
Get-AzQuotaGroupQuotaSubscription -GroupQuotaName <String> -ManagementGroupInputObject <IQuotaIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuotaGroupQuotaSubscription -InputObject <IQuotaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the subscriptionIds along with its provisioning state for being associated with the GroupQuota.
If the subscription is not a member of GroupQuota, it will return 404, else 200.

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

### -GroupQuotaName
The GroupQuota name.
The name should be unique for the provided context tenantId/MgId.

```yaml
Type: System.String
Parameter Sets: Get, List, GetViaIdentityManagementGroup
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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.IGroupQuotaSubscriptionId

## NOTES

## RELATED LINKS
