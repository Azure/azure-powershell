---
external help file:
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwarescriptstringexecutionparameterobject
schema: 2.0.0
---

# New-AzVMwareScriptStringExecutionParameterObject

## SYNOPSIS
Create an in-memory object for ScriptStringExecutionParameter.

## SYNTAX

```
New-AzVMwareScriptStringExecutionParameterObject -Name <String> [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScriptStringExecutionParameter.

## EXAMPLES

### Example 1: Create a local Script String Execution object
```powershell
New-AzVMwareScriptStringExecutionParameterObject -Name azps_test_value -Value "passwordValue"
```

```output
Name            Type  Value
----            ----  -----
azps_test_value Value passwordValue
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

