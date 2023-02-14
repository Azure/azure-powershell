### Example 1: Delete a Confidential Ledger
```powershell
<<<<<<< HEAD
Remove-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000
=======
PS C:\> Remove-AzConfidentialLedger `
  -Name test-ledger `
  -ResourceGroupName rg-000

# No output
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Deletes the specified Confidential Ledger.