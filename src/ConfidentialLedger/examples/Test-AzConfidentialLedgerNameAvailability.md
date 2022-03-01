### Example 1: Name is available
```powershell
PS C:\> Test-AzConfidentialLedgerNameAvailability `
  -NameAvailabilityRequest `
      @{
          Name="available-name";
          Type="Microsoft.ConfidentialLedger/ledgers"
      }

Message       :
NameAvailable : True
Reason        :
```

Checks to see if the specified Confidential Ledger name is available. In this case, the name is available. Confidential Ledger names must be globally unique.

### Example 2: Name is not available
```powershell
PS C:\> Test-AzConfidentialLedgerNameAvailability `
  -NameAvailabilityRequest `
      @{
          Name="not-available-name";
          Type="Microsoft.ConfidentialLedger/ledgers"
      }

Message       : Resource name already exists
NameAvailable : False
Reason        : AlreadyExists
```

Checks to see if the specified Confidential Ledger name is available. In this case, the name is not available. Confidential Ledger names must be globally unique.
