### Example 1: Object creation
```powershell
New-AzConfidentialLedgerAADBasedSecurityPrincipalObject `
  -LedgerRoleName "Administrator" `
  -PrincipalId "00001111-aaaa-2222-bbbb-3333cccc4444" `
  -TenantId "00001111-aaaa-2222-bbbb-3333cccc4444"
```

```output
LedgerRoleName PrincipalId                          TenantId
-------------- -----------                          --------
Administrator  00001111-aaaa-2222-bbbb-3333cccc4444 00001111-aaaa-2222-bbbb-3333cccc4444
```

Creates an AadBasedSecurityPrincipalObject that may be used for `Az.ConfidentialLedger` commands.