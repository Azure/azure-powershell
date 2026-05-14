### Example 1: Create a new Confidential Ledger
```powershell
New-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000 `
  -SubscriptionId 00000000-0000-0000-0000-000000000000 `
  -AadBasedSecurityPrincipal `
      @{
          LedgerRoleName="Administrator"; 
          PrincipalId="00001111-aaaa-2222-bbbb-3333cccc4444"; 
          TenantId="00001111-aaaa-2222-bbbb-3333cccc4444"
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
  -PrincipalId "00001111-aaaa-2222-bbbb-3333cccc4444" `
  -TenantId "00001111-aaaa-2222-bbbb-3333cccc4444"

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
