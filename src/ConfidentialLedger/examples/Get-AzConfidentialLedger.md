### Example 1: List Confidential Ledgers
```powershell
<<<<<<< HEAD
Get-AzConfidentialLedger `
  -SubscriptionId 00000000-0000-0000-0000-000000000000
```

```output
=======
PS C:\> Get-AzConfidentialLedger `
  -SubscriptionId 00000000-0000-0000-0000-000000000000

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name               
eastus   testledger0
eastus   testledger1
eastus   testledger2
```

Lists all the Confidential Ledgers under a subscription.

### Example 2: Get a Confidential Ledger
```powershell
<<<<<<< HEAD
Get-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName test-rg
```

```output
=======
PS C:\> Get-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName test-rg

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
eastus   test-ledger
```

Lists all the Confidential Ledgers under a resource group.