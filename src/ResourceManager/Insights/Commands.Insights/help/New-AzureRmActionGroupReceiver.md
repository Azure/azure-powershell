---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 9830CD16-D797-47EB-BEF5-6CFE3454BCAA
online version: 
schema: 2.0.0
---

# New-AzureRmActionGroupReceiver

## SYNOPSIS
Creates an new action group receiver.

## SYNTAX

```
New-AzureRmActionGroupReceiver -Name <String> [-EmailReceiver] [-EmailAddress <String>] [-SmsReceiver] [-CountryCode <String>] [-PhoneNumber <String>] [-WebhookReceiver] [-ServiceUri <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmActionGroupReceiver** cmdlet creates new action group receiver in memory.

## EXAMPLES

### Example 1: Create a new Email receiver in memory.
```
PS C:\>$emailReceiver = New-AzureRmActionGroupReceiver -Name 'emailReceiver1' -EmailReceiver -EmailAddress 'user1@example.com'
```

This command creates a new Email receiver in memory.

### Example 2: Create a new SMS receiver in memory.
```
PS C:\>$smsReceiver = New-AzureRmActionGroupReceiver -Name 'smsReceiver1' -SmsReceiver -CountryCode '1' -PhoneNumber '5555555555'
```

This command creates a new SMS receiver in memory.

### Example 3: Create a new webhook receiver in memory.
```
PS C:\>$webhookReceiver = New-AzureRmActionGroupReceiver -Name 'webhookReceiver1' -SMSReceiver -ServiceUri 'http://test.com'
```

This command creates a new webhook receiver in memory.

## PARAMETERS

### -Name
Specifies the name for the receiver.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EmailReceiver
Specifies to create an Email receiver

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EmailAddress
Specifies the address for the Email receiver.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SmsReceiver
Specifies to create a SMS receiver

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CountryCode
Specifies the country code for the SMS receiver.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PhoneNumber
Specifies the phone number for the SMS receiver.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WebhookReceiver
Specifies to create a webhook receiver

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceUri
Specifies the URI for the webhook receiver.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupReceiverBase

## NOTES

## RELATED LINKS

[Set-AzureRmActionGroup](./Set-AzureRmActionGroup.md)
[Get-AzureRmActionGroup](./Get-AzureRmActionGroup.md)
[Remove-AzureRmActionGroup](./Remove-AzureRmActionGroup.md)