---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: AzureRM.RecoveryServices.SiteRecovery
online version: 
schema: 2.0.0
---

# Set-AzureRmRecoveryServicesAsrAlertSetting

## SYNOPSIS
Configure Azure Site Recovery notification settings (email notification) for the vault.

## SYNTAX

### Set (Default)
```
Set-AzureRmRecoveryServicesAsrAlertSetting [-EmailSubscriptionOwner] [-CustomEmailAddress <String[]>]
 [-LocaleID <String>] [<CommonParameters>]
```

### Disable
```
Set-AzureRmRecoveryServicesAsrAlertSetting [-DisableNotification] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmRecoveryServicesAsrNotificationSetting** cmdlet configures Azure Site Recovery notification settings (email notification) for the vault.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmRecoveryServicesAsrAlertSetting -DisableNotification

CustomEmailAddress EmailSubscriptionOwner Locale
------------------ ---------------------- ------
{}                 Off                    en-US
```

Disable notification.

### Example 2
```
PS C:\> Set-AzureRmRecoveryServicesAsrAlertSetting -CustomEmailAddress "abcxxxx@xxxx.com" -EmailSubscriptionOwner

CustomEmailAddress     EmailSubscriptionOwner Locale
------------------     ---------------------- ------
{abcxxxx@xxxx.com} On                     en-US
```

Set notification for custom email address(s) and for subscription owner.

## PARAMETERS

### -CustomEmailAddress
Alert / Notification sent to emails.

```yaml
Type: String[]
Parameter Sets: Set
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableNotification
Flag to disable all notification.

```yaml
Type: SwitchParameter
Parameter Sets: Disable
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EmailSubscriptionOwner
Send alert /notification email to subscription owner.

```yaml
Type: SwitchParameter
Parameter Sets: Set
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocaleID
Email language of alert /notifcation to user(supported culture codes from microsoft). 

```yaml
Type: String
Parameter Sets: Set
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRAlertSetting, Microsoft.Azure.Commands.RecoveryServices.SiteRecovery, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

