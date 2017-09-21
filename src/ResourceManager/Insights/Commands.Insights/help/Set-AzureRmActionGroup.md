---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 4A6816DB-0E46-44F0-8AE9-180B1C4AAB22
online version: 
schema: 2.0.0
---

# Set-AzureRmActionGroup

## SYNOPSIS
Creates a new or updates an existing action group.

## SYNTAX

```
Set-AzureRmActionGroup -Name <String> -ResourceGroup <String> -ShortName <string>
 -Receiver <System.Collections.Generic.List`1[PSActionGroupReceiverBase]>
 [-DisableGroup] [-Tags <System.Collections.Generic.Dictionary`1[<string>, <string>]>]
```

## DESCRIPTION
The **Set-AzureRmActionGroup** cmdlet creates a new or updates an existing action group

## EXAMPLES

### Example 1: Create an Action Group
```
PS C:\>$email1 = New-AzureRmActionGroupReceiver -Type 'email' -Name 'user1' -EmailAddress 'user1@example.com'
PS C:\>$sms1 = New-AzureRmActionGroupReceiver -Type 'sms' -Name 'user2'  -CountryCode '1' -PhoneNumber '5555555555'
PS C:\>Set-AzureRmActionGroup -Name $actionGroupName -ResourceGroup $resourceGroupName -ShortName $shortName -Receiver $email1,$sms1

```

The first two commands create two receivers.
The final command creates an Action Group including the two receivers.

## PARAMETERS

### -Name
The name of the action group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
The name of the resource group where the action group is going to exist.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ShortName
The short name of the action group.

```yaml
Type: <System.Collections.Generic.List`1[System.String]>
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Receiver
The list of receivers of the action group.

```yaml
Type: <System.Collections.Generic.List`1[PSActionGroupReceiverBase]>
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableGroup
Disables the action group.

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

### -Tags
Sets the tags property of the activity log alert resource.

```yaml
Type: System.Collections.Generic.Dictionary`1[<string>, <string>]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Force, -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupResource

## NOTES

## RELATED LINKS

[Get-AzureRmActionGroup](./Get-AzureRmActionGroup.md)
[Remove-AzureRmActionGroup](./Remove-AzureRmActionGroup.md)
[New-AzureRmActionGroupReceiver](./AzureRmActionGroupReceiver.md)