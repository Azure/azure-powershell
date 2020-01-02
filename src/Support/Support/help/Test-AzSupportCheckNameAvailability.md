---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# Test-AzSupportCheckNameAvailability

## SYNOPSIS
Test name availability for support ticket and support ticket communication resource types.

## SYNTAX

### SupportTicketCheckNameAvailabilityParameterSet (Default)
```
Test-AzSupportCheckNameAvailability -Name <String> [-SupportTicket] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### CommunicationCheckNameAvailabilityParameterSet
```
Test-AzSupportCheckNameAvailability -Name <String> -SupportTicketName <String> [-Communication]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Test name availability for support ticket and support ticket communication resource types. Before creating a support ticket or support ticket communication with a name, you can call this cmdlet to test if that name is valid and is available.

## EXAMPLES

### Example 1: Test availability of name for support ticket. This example shows the result when the name is available. 
```powershell
PS C:\> Test-AzSupportCheckNameAvailability -Name test -SupportTicket

NameAvailable Reason Message
------------- ------ -------
         True

```

### Example 2: Test availability of name for support ticket. This example shows the result when the name is not available because it already exists.
```powershell
PS C:\> Test-AzSupportCheckNameAvailability -Name test -SupportTicket

NameAvailable Reason        Message
------------- ------        -------
        False AlreadyExists Name already exists. Please select a different name.

```

### Example 1: Test availability of name for support ticket communication. 
```powershell
PS C:\> Test-AzSupportCheckNameAvailability -Name testmessage -SupportTicketName testticket -Communication

NameAvailable Reason Message
------------- ------ -------
         True

```

## PARAMETERS

### -Communication
Use this switch when doing availability test for Communication resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CommunicationCheckNameAvailabilityParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource for which availability test will be done.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTicket
Use this switch when doing availability test for SupportTicket resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SupportTicketCheckNameAvailabilityParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportTicketName
SupportTicket resource name that must be specified when doing availability test for Communication resource name.

```yaml
Type: System.String
Parameter Sets: CommunicationCheckNameAvailabilityParameterSet
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

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
