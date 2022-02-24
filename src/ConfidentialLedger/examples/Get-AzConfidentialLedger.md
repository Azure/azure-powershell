### Example 1: List Confidential Ledgers
```powershell
PS C:\> Get-AzConfidentialLedger `
  -SubscriptionId 00000000-0000-0000-0000-000000000000

Location Name               
eastus   testledger0
eastus   testledger1
eastus   testledger2
```

### Example 2: Get a Confidential Ledger
```powershell
PS C:\> Get-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName test-rg

Location Name
eastus   test-ledger
```