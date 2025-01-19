### Example 1: Checks that the resource name is valid and is not already in use.
```powershell
Test-AzSpringNameAvailability -Location eastus -Name myserver -Type "Microsoft.AppPlatform/Spring"
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

Checks that the resource name is valid and is not already in use.