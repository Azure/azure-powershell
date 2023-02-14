### Example 1: Update tags for a Confidential Ledger
```powershell
<<<<<<< HEAD
Update-AzConfidentialLedger `
=======
PS C:\> Update-AzConfidentialLedger `
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
  -Tag `
      @{
          Location="additional properties 0"
          NewTag="New tag"
      }
<<<<<<< HEAD
```

```output
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
eastus   test-ledger
```

Updates metadata for an existing Confidential Ledger.