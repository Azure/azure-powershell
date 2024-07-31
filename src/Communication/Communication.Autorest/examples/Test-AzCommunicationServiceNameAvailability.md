### Example 1: Checks if already in use resource name ContosoAcsResource1 is available
```powershell
Test-AzCommunicationServiceNameAvailability -Name ContosoAcsResource1
```

```output
Message                      NameAvailable Reason
-------                      ------------- ------
Resource name already exists False         AlreadyExists
```

Verified that the CommunicationService name is valid and is not already in use.

### Example 2: Checks if new resource name ContosoAcsResource2 is available
```powershell
Test-AzCommunicationServiceNameAvailability -Name ContosoAcsResource2
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Verified that the requested CommunicationService name already in use.
