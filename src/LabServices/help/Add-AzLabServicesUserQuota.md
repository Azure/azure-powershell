---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.labservices/add-azlabservicesuserquota
schema: 2.0.0
---

# Add-AzLabServicesUserQuota

## SYNOPSIS
API to add additional user quota.

## SYNTAX

### User (Default)
```
Add-AzLabServicesUserQuota -UsageQuotaToAddToExisting <TimeSpan> -User <User> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Email
```
Add-AzLabServicesUserQuota -Email <String> -LabName <String> -ResourceGroupName <String>
 -UsageQuotaToAddToExisting <TimeSpan> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API to add additional user quota.

## EXAMPLES

### Example 1: Increase student usage quota.
```powershell
Add-AzLabServicesUserQuota -ResourceGroupName "group name" -LabName "lab name" -Email 'student@contoso.com' -UsageQuotaToAddToExisting $(New-Timespan -Hours 4)
```

```output
Name           Type
----           ----
testuser       Microsoft.LabServices/labs/users
```

This command increase the students quota by 4 hours.

### Example 2: Increase student usage quota with User object.
```powershell
$user = Get-AzLabServicesUser -ResourceGroupName "group name" -LabName "lab name" -UserName 'ContosoUser12345'
$user | Add-AzLabServicesUserQuota -UsageQuotaToAddToExisting $(New-Timespan -Hours 5)
```

```output
Name                 Type
----                 ----
ContosoUser12345     Microsoft.LabServices/labs/users
```

Increase the student quota by 5 hours.

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Email
The name of the user that uniqely identifies it within containing lab.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: Email
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabName


```yaml
Type: System.String
Parameter Sets: Email
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName


```yaml
Type: System.String
Parameter Sets: Email
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsageQuotaToAddToExisting
The amount of usage quota time the user gets in addition to the current user quota.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -User
To construct, see NOTES section for USER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.User
Parameter Sets: User
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.User

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


USER `<User>`: 
  - `Email <String>`: Email address of the user.
  - `[AdditionalUsageQuota <TimeSpan?>]`: The amount of usage quota time the user gets in addition to the lab usage quota.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

