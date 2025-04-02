---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwarescriptsecurestringexecutionparameterobject
schema: 2.0.0
---

# New-AzVMwareScriptSecureStringExecutionParameterObject

## SYNOPSIS
Create an in-memory object for ScriptSecureStringExecutionParameter.

## SYNTAX

```
New-AzVMwareScriptSecureStringExecutionParameterObject -Name <String> [-SecureValue <SecureString>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScriptSecureStringExecutionParameter.

## EXAMPLES

### Example 1: Create a local Script Secure String Execution object
```powershell
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzVMwareScriptSecureStringExecutionParameterObject -Name azps_test_securevalue -SecureValue $mypwd
```

```output
Name                                   SecureValue Type
----                                   ----------- ----
azps_test_securevalue System.Security.SecureString SecureValue
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
Type: System.Security.SecureString
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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ScriptSecureStringExecutionParameter

## NOTES

## RELATED LINKS
