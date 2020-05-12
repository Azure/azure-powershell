### Example 1: Regenerate Api keys for a transaction node
```powershell
PS C:\> New-AzBlockchainTransactionNodeApiKey -BlockchainMemberName dolauli001 -ResourceGroupName testgroup -TransactionNodeName tranctionnode001 -KeyName key1 -Value H4_GPhxbqYENxwas4Vc4l5U9

KeyName Value
------- -----
key1    0-UCaNSNfS0lwRKRyv09sgb-
key2    0Prk4Dl3lsOKdhyPEFQ-AnQb
```

This command generates Api keys for a transaction node.

