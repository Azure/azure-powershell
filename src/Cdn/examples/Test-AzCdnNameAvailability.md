### Example 1: Check AzureCDN endpint name availability
```powershell
Test-AzCdnNameAvailability -Name endptest001 -Type Microsoft.Cdn/Profiles/Endpoints
```

```output
Message            NameAvailable Reason
-------            ------------- ------
Name not available False         Name is already in use
```

Check AzureCDN endpint name availability

