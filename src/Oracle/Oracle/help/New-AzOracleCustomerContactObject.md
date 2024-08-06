---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/Az.Oracle/new-azoraclecustomercontactobject
schema: 2.0.0
---

# New-AzOracleCustomerContactObject

## SYNOPSIS
Create an in-memory object for CustomerContact.

## SYNTAX

```
New-AzOracleCustomerContactObject -Email <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomerContact.

## EXAMPLES

### Example 1: Create an in-memory object for CustomerContact
```powershell
New-AzOracleCustomerContactObject -Email "example@oracle.com"
```

Create an in-memory object for CustomerContact.
For more information, execute `Get-Help New-AzOracleNsgCidrObject`.

## PARAMETERS

### -Email
The email address used by Oracle to send notifications regarding databases and infrastructure.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.CustomerContact

## NOTES

## RELATED LINKS
