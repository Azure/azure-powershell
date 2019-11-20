### Example 1: Check whether a resource name is available
```powershell
PS C:\> Test-AzBlockchainLocationNameAvailability -LocationName eastus -Name erw123 -type Microsoft.Blockchain/blockchainMembers

Message NameAvailable Reason
------- ------------- ------
        True          NotSpecified
```

The command checks whether a resource name is available.

