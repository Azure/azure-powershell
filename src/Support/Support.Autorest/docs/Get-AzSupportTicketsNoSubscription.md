---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportticketsnosubscription
schema: 2.0.0
---

# Get-AzSupportTicketsNoSubscription

## SYNOPSIS
Gets details for a specific support ticket.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.

## SYNTAX

### List (Default)
```
Get-AzSupportTicketsNoSubscription [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSupportTicketsNoSubscription -SupportTicketName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportTicketsNoSubscription -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets details for a specific support ticket.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
Name                                      Title                                 SupportTicketId  Severity ServiceDisplayName CreatedDate
----                                      -----                                 ---------------  -------- ------------------ -----------
2403110040009092                          test ticket please ignore and close   2403110040009092 Minimal  Billing            3/11/2024 3:46:20 PM
test-41b4ec72-8634-4e03-978e-15bde625be00 test ticket - please ignore and close 2403070040010395 Minimal  Billing            3/7/2024 5:35:55 PM
test-270a8ba4-7083-4b02-8b32-b5c2cdc55e78 test ticket - please ignore and close 2403070040010346 Minimal  Billing            3/7/2024 5:32:40 PM
test-8dad4b97-5ff5-4a1e-bb6e-d323348db3f2 test ticket - please ignore and close 2403070040009816 Minimal  Billing            3/7/2024 5:04:36 PM
test-0d8ee1f2-89d6-4078-8c1a-5845673966a1 test ticket - please ignore and close 2403070040009769 Minimal  Billing            3/7/2024 5:02:44 PM
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Gets details of a support ticket

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
The filter to apply on the operation.
We support 'odata v4.0' filter semantics.
\<a target='_blank' href='https://docs.microsoft.com/odata/concepts/queryoptions-overview'\>Learn more\</a\> \<br/\>\<i\>Status\</i\> , \<i\>ServiceId\</i\>, and \<i\>ProblemClassificationId\</i\> filters can only be used with 'eq' operator.
For \<i\>CreatedDate\</i\> filter, the supported operators are 'gt' and 'ge'.
When using both filters, combine them using the logical 'AND'.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SupportTicketName
Support ticket name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of values to return in the collection.
Default is 25 and max is 100.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportTicketDetails

## NOTES

## RELATED LINKS

