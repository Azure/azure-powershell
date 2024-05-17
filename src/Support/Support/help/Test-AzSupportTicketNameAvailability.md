---
external help file: Az.Support-help.xml
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/test-azsupportticketnameavailability
schema: 2.0.0
---

# Test-AzSupportTicketNameAvailability

## SYNOPSIS
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzSupportTicketNameAvailability [-SubscriptionId <String>] -Name <String> -Type <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Check
```
Test-AzSupportTicketNameAvailability [-SubscriptionId <String>]
 -CheckNameAvailabilityInput <ICheckNameAvailabilityInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzSupportTicketNameAvailability [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzSupportTicketNameAvailability [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.

## EXAMPLES

### Example 1: Check support ticket friendly name availability
```powershell
Test-AzSupportTicketNameAvailability -Name "testSupportTicketName" -Type "Microsoft.Support/supportTickets"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Check the availability of a resource name.
This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.
If the provided type is neither Microsoft.Support/supportTickets nor Microsoft.Support/fileWorkspaces, then it will default to Microsoft.Support/supportTickets.

### Example 2: Check file workspace friendly name availability
```powershell
Test-AzSupportTicketNameAvailability -Name "testFileWorkspaceName" -Type "Microsoft.Support/fileWorkspaces"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Check the availability of a resource name.
This API should be used to check the uniqueness of the name for file workspace creation for the selected subscription.
If the provided type is neither Microsoft.Support/supportTickets nor Microsoft.Support/fileWorkspaces, then it will default to Microsoft.Support/supportTickets.

## PARAMETERS

### -CheckNameAvailabilityInput
Input of CheckNameAvailability API.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICheckNameAvailabilityInput
Parameter Sets: Check
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
Parameter Sets: CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -Type
The type of resource.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ICheckNameAvailabilityOutput

## NOTES

## RELATED LINKS
