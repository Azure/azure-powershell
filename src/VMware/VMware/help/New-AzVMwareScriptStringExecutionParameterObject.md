---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/az.VMware/new-AzVMwareScriptStringExecutionParameterObject
schema: 2.0.0
---

# New-AzVMwareScriptStringExecutionParameterObject

## SYNOPSIS
Create a in-memory object for ScriptStringExecutionParameter

## SYNTAX

```
New-AzVMwareScriptStringExecutionParameterObject -Name <String> [-Value <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for ScriptStringExecutionParameter

## EXAMPLES

### Example 1: Create a local Script String Execution object
```powershell
New-AzVMwareScriptStringExecutionParameterObject -Name azps_test_value -Value "passwordValue"
```

```output
Name                  Value
----                  -----------
azps_test_value passwordValue
```

Create a local Script String Execution object

## PARAMETERS

### -Name
The parameter name.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The value for the passed parameter.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ScriptStringExecutionParameter

## NOTES

## RELATED LINKS
