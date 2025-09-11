---
external help file: Az.DataBox-help.xml
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-azdataboxcontactdetailsobject
schema: 2.0.0
---

# New-AzDataBoxContactDetailsObject

## SYNOPSIS
Create an in-memory object for ContactDetails.

## SYNTAX

```
New-AzDataBoxContactDetailsObject -ContactName <String> -EmailList <String[]> -Phone <String>
 [-Mobile <String>] [-NotificationPreference <INotificationPreference[]>] [-PhoneExtension <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContactDetails.

## EXAMPLES

### Example 1: Create a in-memory object for ContactDetails
```powershell
New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
```

```output
ContactName            : random
EmailList              : {emailId}
Mobile                 :
NotificationPreference :
Phone                  : 1234567891
PhoneExtension         :
```

Create a in-memory object for ContactDetails

## PARAMETERS

### -ContactName
Contact name of the person.

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

### -EmailList
List of Email-ids to be notified about job progress.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mobile
Mobile number of the contact person.

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

### -NotificationPreference
Notification preference for a job stage.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.INotificationPreference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Phone
Phone number of the contact person.

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

### -PhoneExtension
Phone extension number of the contact person.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.ContactDetails

## NOTES

## RELATED LINKS
