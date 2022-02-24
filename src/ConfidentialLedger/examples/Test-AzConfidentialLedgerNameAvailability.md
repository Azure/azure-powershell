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
