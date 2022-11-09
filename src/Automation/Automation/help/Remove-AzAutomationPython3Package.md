---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version:
schema: 2.0.0
---

# Remove-AzAutomationPython3Package

## SYNOPSIS
Remove a Python3 Package from Automation Account

## SYNTAX

```
Remove-AzAutomationPython3Package [-Name] <String> [-Force] [-ResourceGroupName] <String>
 [-AutomationAccountName] <String>
```

## DESCRIPTION
The **Remove-AzAutomationPython3Package** cmdlet removes a Python3 Package from Automation Account.

## EXAMPLES

### Example 1
```powershell
Remove-AzAutomationPython3Package -AutomationAccountName "Contoso17"  -ResourceGroupName "ResourceGroup01" -Name "Python3PackageName"
```


## PARAMETERS

### -AutomationAccountName
The automation account name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Confirm the removal of Python 3 package

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Python 3 package name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Automation.Model.Module

## NOTES

## RELATED LINKS
