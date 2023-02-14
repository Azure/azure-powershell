### Example 1: Name is available
```powershell
<<<<<<< HEAD
Test-AzConfidentialLedgerNameAvailability `
  -Name "available-name" `
  -Type "Microsoft.ConfidentialLedger/ledgers"
```

```output
=======
PS C:\> Test-AzConfidentialLedgerNameAvailability `
  -NameAvailabilityRequest `
      @{
          Name="available-name";
          Type="Microsoft.ConfidentialLedger/ledgers"
      }

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Message       :
NameAvailable : True
Reason        :
```

Checks to see if the specified Confidential Ledger name is available. In this case, the name is available. Confidential Ledger names must be globally unique.

### Example 2: Name is not available
```powershell
<<<<<<< HEAD
Test-AzConfidentialLedgerNameAvailability `
  -Name "not-available-name" `
  -Type "Microsoft.ConfidentialLedger/ledgers"
```

```output
=======
PS C:\> Test-AzConfidentialLedgerNameAvailability `
  -NameAvailabilityRequest `
      @{
          Name="not-available-name";
          Type="Microsoft.ConfidentialLedger/ledgers"
      }

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Message       : Resource name already exists
NameAvailable : False
Reason        : AlreadyExists
```

Checks to see if the specified Confidential Ledger name is available. In this case, the name is not available. Confidential Ledger names must be globally unique.
