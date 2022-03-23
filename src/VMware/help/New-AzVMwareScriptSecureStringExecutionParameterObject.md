---
external help file:
Module Name: Az.VMware
online version: https://docs.microsoft.com/powershell/module/az.VMware/new-AzVMwareScriptSecureStringExecutionParameterObject
schema: 2.0.0
---

# New-AzVMwareScriptSecureStringExecutionParameterObject

## SYNOPSIS
Create a in-memory object for ScriptSecureStringExecutionParameter

## SYNTAX

```
New-AzVMwareScriptSecureStringExecutionParameterObject -Name <String> [-SecureValue <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for ScriptSecureStringExecutionParameter

## EXAMPLES

### Example 1: Create a local Script Secure String Execution object
```powershell
New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue "passwordValue"
```
```output
Name                  Type        SecureValue
----                  ----        -----------
azps_test_securevalue SecureValue passwordValue
```

Create a local Script Secure String Execution object

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

### -SecureValue
A secure value for the passed parameter, not to be stored in logs.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.ScriptSecureStringExecutionParameter

## NOTES

ALIASES

## RELATED LINKS

