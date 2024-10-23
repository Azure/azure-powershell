---
external help file: Az.VMware-help.xml
Module Name: Az.VMware
online version: https://learn.microsoft.com/powershell/module/Az.VMware/new-azvmwarepscredentialexecutionparameterobject
schema: 2.0.0
---

# New-AzVMwarePSCredentialExecutionParameterObject

## SYNOPSIS
Create an in-memory object for PSCredentialExecutionParameter.

## SYNTAX

```
New-AzVMwarePSCredentialExecutionParameterObject -Name <String> [-Password <SecureString>] [-Username <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PSCredentialExecutionParameter.

## EXAMPLES

### Example 1: Create a local PS Credential Execution object
```powershell
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzVMwarePSCredentialExecutionParameterObject -Name azps_test_credentialvalue -Password $mypwd -Username "usernameValue"
```

```output
Name                                          Password Type       Username
----                                          -------- ----       --------
azps_test_credentialvalue System.Security.SecureString Credential usernameValue
```

Create a local PS Credential Execution object

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

### -Password
password for login.

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

### -Username
username for login.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.PsCredentialExecutionParameter

## NOTES

## RELATED LINKS
