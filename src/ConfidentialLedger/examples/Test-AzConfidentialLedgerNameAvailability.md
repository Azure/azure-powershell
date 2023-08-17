### Example 1: Name is available
```powershell
Test-AzConfidentialLedgerNameAvailability `
  -Name "available-name" `
  -Type "Microsoft.ConfidentialLedger/ledgers"
```

```output
Message       :
NameAvailable : True
Reason        :
```

Checks to see if the specified Confidential Ledger name is available. In this case, the name is available. Confidential Ledger names must be globally unique.

### Example 2: Name is not available
```powershell
Test-AzConfidentialLedgerNameAvailability `
  -Name "not-available-name" `
  -Type "Microsoft.ConfidentialLedger/ledgers"
```

```output
Message       : Resource name already exists
NameAvailable : False
Reason        : AlreadyExists
```

Checks to see if the specified Confidential Ledger name is available. In this case, the name is not available. Confidential Ledger names must be globally unique.
