### Example 1: Object creation
```powershell
<<<<<<< HEAD
New-AzConfidentialLedgerAadBasedSecurityPrincipalObject `
  -LedgerRoleName "Administrator" `
  -PrincipalId "34621747-6fc8-4771-a2eb-72f31c461f2e" `
  -TenantId "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"
```

```output
=======
PS C:\> New-AzConfidentialLedgerAadBasedSecurityPrincipalObject `
  -LedgerRoleName "Administrator" `
  -PrincipalId "34621747-6fc8-4771-a2eb-72f31c461f2e" `
  -TenantId "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
LedgerRoleName PrincipalId                          TenantId
-------------- -----------                          --------
Administrator  34621747-6fc8-4771-a2eb-72f31c461f2e bce123b9-2b7b-4975-8360-5ca0b9b1cd08
```

Creates an AadBasedSecurityPrincipalObject that may be used for `Az.ConfidentialLedger` commands.