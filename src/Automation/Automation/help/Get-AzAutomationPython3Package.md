---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Automation.dll-Help.xml
Module Name: Az.Automation
online version:
schema: 2.0.0
---

# Get-AzAutomationPython3Package

## SYNOPSIS
Gets a Python3 Package.

## SYNTAX

### ByAll (Default)
```
Get-AzAutomationPython3Package [-ResourceGroupName] <String> [-AutomationAccountName] <String>
```

### ByName
```
Get-AzAutomationPython3Package [-Name] <String> [-ResourceGroupName] <String> [-AutomationAccountName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAutomationPython3Package** cmdlet gets a Python3 Package or list of Python3 Packages in Automation Account.

## EXAMPLES

### Example 1
```powershell
New-AzAutomationPython3Package -AutomationAccountName "Contoso17" -Name "RunbookWorkerName" -ResourceGroupName "ResourceGroup01"  -ErrorAction SilentlyContinue
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

### -Name
The Python3 Package name.

```yaml
Type: String
Parameter Sets: ByName
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
