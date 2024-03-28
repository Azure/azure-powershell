---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/validate-all
schema: 2.0.0
---

# Validate-All

## SYNOPSIS
Given a VM, check if it's eligible for Azure AD authentication

## SYNTAX

```
Validate-All [-VmName] <Object> [-ResourceGroup] <Object> [[-MsiClientId] <String>] [<CommonParameters>]
```

## DESCRIPTION
Given a VM, check if it's eligible for Azure AD authentication

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -MsiClientId


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
Name of the resource group

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmName
Name of the VM

```yaml
Type: System.Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### bool if the validation passed or not

## NOTES

## RELATED LINKS

