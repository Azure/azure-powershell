---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# Update-AzSupportTicket

## SYNOPSIS
Updates support ticket.

## SYNTAX

### UpdateByNameParameterSet (Default)
```
Update-AzSupportTicket -Name <String> [-Severity <String>] [-ContactDetails <PSContactProfile>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByInputObjectParameterSet
```
Update-AzSupportTicket -InputObject <PSSupportTicket> [-Severity <String>] [-ContactDetails <PSContactProfile>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateByResourceIdParameterSet
```
Update-AzSupportTicket -ResourceId <String> [-Severity <String>] [-ContactDetails <PSContactProfile>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates support ticket. Use this cmdlet to update Severity and/or ContactDetails of a support ticket.

## EXAMPLES

### Example 1: Updating severity of support ticket.
```powershell
PS C:\> Update-AzSupportTicket -Name test -Severity moderate

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test
Name                             : test
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName :
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               :
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 4:17:49 AM
TechnicalTicketDetails           :
QuotaTicketDetails               :
```

### Example 2: Updating contact details of support ticket.
```powershell
PS C:\> $contactDetails = new-object Microsoft.Azure.Commands.Support.Models.PSContactProfile
PS C:\> $contactDetails.FirstName = "first updated"
PS C:\> $contactDetails.LastName = "last updated"
PS C:\> Update-AzSupportTicket -Name testticketpowershell2 -ContactDetails $contactDetails 

Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.Support/supportTickets/test
Name                             : test
Type                             : Microsoft.Support/supportTickets
Title                            : Test
SupportTicketId                  : 170010221000050
Description                      : Test
ProblemClassificationId          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
ProblemClassificationDisplayName :
Severity                         : Moderate
EnrollmentId                     :
ProductionOutage                 : False
Require24X7Response              : False
ContactDetails                   : Microsoft.Azure.Commands.Support.Models.PSContactProfile
ServiceLevelAgreement            : Microsoft.Azure.Commands.Support.Models.PSServiceLevelAgreement
SupportEngineer                  : Microsoft.Azure.Commands.Support.Models.PSSupportEngineer
SupportPlanType                  : Premier
ProblemStartTime                 :
ServiceId                        : /providers/Microsoft.Support/services/{service_guid}
ServiceDisplayName               :
Status                           : Open
CreatedDate                      : 1/2/2020 3:09:28 AM
ModifiedDate                     : 1/2/2020 4:17:49 AM
TechnicalTicketDetails           :
QuotaTicketDetails               :

PS C:\> $a.ContactDetails

FirstName                : first updated
LastName                 : last updated
PreferredContactMethod   : Email
PrimaryEmailAddress      : user@contoso.com
AdditionalEmailAddresses :
PhoneNumber              :
PreferredTimeZone        : Pacific Standard Time
Country                  : USA
PreferredSupportLanguage : en-us
```

## PARAMETERS

### -ContactDetails
Update Contact details on SupportTicket.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSContactProfile
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
SupportTicket resource object that this cmdlet updates.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSSupportTicket
Parameter Sets: UpdateByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of SupportTicket resource that this cmdlet updates.

```yaml
Type: System.String
Parameter Sets: UpdateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of SupportTicket resource that this cmdlet updates.

```yaml
Type: System.String
Parameter Sets: UpdateByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
Update Severity of SupportTicket.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.Support.Models.PSSupportTicket

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportTicket

## NOTES

## RELATED LINKS
