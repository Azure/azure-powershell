---
external help file: Microsoft.Azure.Commands.ResourceManager.Automation.dll-Help.xml
ms.assetid: B1897EFC-0184-4A8B-B8E4-203CC8E3B179
online version:
schema: 2.0.0
---

# Set-AzureRmAutomationAccount

## SYNOPSIS
Modifies an Automation account.

## SYNTAX

```
Set-AzureRmAutomationAccount [-ResourceGroupName] <String> [-Name] <String> [-Plan <String>]
 [-Tags <IDictionary>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmAutomationAccount** cmdlet modifies an Azure Automation account.

For more information about Automation accounts, see the New-AzureRmAutomationAccount cmdlet.

## EXAMPLES

### Example 1: Set the tags for an Automation account
```
PS C:\>$Tags = @{"tag01"="value01";"tag02"="value02"}
PS C:\> Set-AzureRmAutomationAccount -Name "AutomationAccount01" -ResourceGroupName "ResourceGroup01" -Tags $Tags
```

The first command assigns two key/value pairs to the $Tags variable.

The second command sets tags in $Tags for the Automation account named AutomationAccount01.

### Example 2: Change the plan for an Automation account
```
PS C:\>Set-AzureRmAutomationAccount -Name "AutomationAccount01" -ResourceGroupName "ResourceGroup01" -Plan Basic
```

This command changes the plan to Basic for the Automation account named AutomationAccount01.

## PARAMETERS

### -Name
Specifies the name of the Automation account that this cmdlet modifies.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AutomationAccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Plan
Specifies the plan for the Automation account.
Valid values are:

- Basic
- Free

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Free, Basic

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group that contains the Automation account that this cmdlet modifies.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tags
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: IDictionary
Parameter Sets: (All)
Aliases: Tag

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmAutomationAccount](./Get-AzureRmAutomationAccount.md)

[New-AzureRmAutomationAccount](./New-AzureRmAutomationAccount.md)

[Remove-AzureRmAutomationAccount](./Remove-AzureRmAutomationAccount.md)