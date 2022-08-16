---
external help file:
Module Name: Az.ConfidentialLedger
online version: https://docs.microsoft.com/powershell/module/az.ConfidentialLedger/new-AzConfidentialLedgerAADBasedSecurityPrincipalObject
schema: 2.0.0
---

# New-AzConfidentialLedgerAADBasedSecurityPrincipalObject

## SYNOPSIS
Create an in-memory object for AADBasedSecurityPrincipal.

## SYNTAX

```
New-AzConfidentialLedgerAADBasedSecurityPrincipalObject [-LedgerRoleName <LedgerRoleName>]
 [-PrincipalId <String>] [-TenantId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AADBasedSecurityPrincipal.

## EXAMPLES

### Example 1: Object creation
```powershell
New-AzConfidentialLedgerAadBasedSecurityPrincipalObject `
  -LedgerRoleName "Administrator" `
  -PrincipalId "34621747-6fc8-4771-a2eb-72f31c461f2e" `
  -TenantId "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"
```

```output
LedgerRoleName PrincipalId                          TenantId
-------------- -----------                          --------
Administrator  34621747-6fc8-4771-a2eb-72f31c461f2e bce123b9-2b7b-4975-8360-5ca0b9b1cd08
```

Creates an AadBasedSecurityPrincipalObject that may be used for `Az.ConfidentialLedger` commands.

## PARAMETERS

### -LedgerRoleName
LedgerRole associated with the Security Principal of Ledger.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Support.LedgerRoleName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalId
UUID/GUID based Principal Id of the Security Principal.

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

### -TenantId
UUID/GUID based Tenant Id of the Security Principal.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConfidentialLedger.Models.Api20220513.AadBasedSecurityPrincipal

## NOTES

ALIASES

## RELATED LINKS

