### Example 1: Create a new Confidential Ledger
```powershell
New-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000 `
  -SubscriptionId 00000000-0000-0000-0000-000000000000 `
  -AadBasedSecurityPrincipal `
      @{
          LedgerRoleName="Administrator"; 
          PrincipalId="34621747-6fc8-4771-a2eb-72f31c461f2e"; 
          TenantId="bce123b9-2b7b-4975-8360-5ca0b9b1cd08"
      } `
  -CertBasedSecurityPrincipal `
      @{
          Cert="-----BEGIN CERTIFICATE-----********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************-----END CERTIFICATE-----"; 
          LedgerRoleName="Reader"
      } `
  -LedgerType Public `
  -Location eastus `
  -Tag @{Location="additional properties 0"}
```

```output
Location Name
eastus   test-ledger
```

Creates a new Confidential Ledger.

### Example 2: Create Using Security Principal Objects
```powershell
$aadSecurityPrincipal = New-AzConfidentialLedgerAADBasedSecurityPrincipalObject `
  -LedgerRoleName "Administrator" `
  -PrincipalId "34621747-6fc8-4771-a2eb-72f31c461f2e" `
  -TenantId "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"

$certSecurityPrincipal = New-AzConfidentialLedgerCertBasedSecurityPrincipalObject `
  -Cert "-----BEGIN CERTIFICATE-----********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************-----END CERTIFICATE-----" `
  -LedgerRoleName "Reader"

New-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000 `
  -SubscriptionId 00000000-0000-0000-0000-000000000000 `
  -AadBasedSecurityPrincipal $aadSecurityPrincipal `
  -CertBasedSecurityPrincipal $certSecurityPrincipal `
  -LedgerType Public `
  -Location eastus `
  -Tag @{Location="additional properties 0"}
```

```output
Location Name
eastus   test-ledger
```

Creates a new Confidential Ledger using objects for `AadBasedSecurityPrincipal` and `CertBasedSecurityPrincipal`.
