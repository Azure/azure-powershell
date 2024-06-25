---
external help file: Az.Support-help.xml
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/test-azsupportcommunicationsnosubscriptionnameavailability
schema: 2.0.0
---

# Test-AzSupportCommunicationsNoSubscriptionNameAvailability

## SYNOPSIS
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -SupportTicketName <String> -Name <String>
 -Type <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -SupportTicketName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -SupportTicketName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Check
```
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -SupportTicketName <String>
 -CheckNameAvailabilityInput <ICheckNameAvailabilityInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -InputObject <ISupportIdentity> -Name <String>
 -Type <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -InputObject <ISupportIdentity>
 -CheckNameAvailabilityInput <ICheckNameAvailabilityInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.

## EXAMPLES

### Example 1: Check friendly name availability of a communication for a support ticket
```powershell
Test-AzSupportCommunicationsNoSubscriptionNameAvailability -Name "testCommunication" -SupportTicketName "2402084010005835" -Type "Microsoft.Support/communications"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Check the availability of a resource name.
This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.

## PARAMETERS

### -CheckNameAvailabilityInput
Input of CheckNameAvailability API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICheckNameAvailabilityInput
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: CheckViaIdentityExpanded, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name to validate.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTicketName
Support ticket name.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath, Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of resource.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICheckNameAvailabilityInput

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICheckNameAvailabilityOutput

## NOTES

## RELATED LINKS
