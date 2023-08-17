### Example 1: List Confidential Ledgers
```powershell
Get-AzConfidentialLedger `
  -SubscriptionId 00000000-0000-0000-0000-000000000000
```

```output
Location Name               
eastus   testledger0
eastus   testledger1
eastus   testledger2
```

Lists all the Confidential Ledgers under a subscription.

### Example 2: Get a Confidential Ledger
```powershell
Get-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName test-rg
```

```output
Location Name
eastus   test-ledger
```

Lists all the Confidential Ledgers under a resource group.