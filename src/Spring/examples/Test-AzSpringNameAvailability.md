### Example 1: Checks that the resource name is valid and is not already in use
```powershell
Test-AzSpringNameAvailability -Location EastUS -Name Spring-service -Type "Microsoft.AppPlatform/Spring" -debug
```

```output 
Message
-------
The resource name is invalid. It can contain only lowercase letters, numbers and hyphens. The first character must be …
```

Checks that the resource name is valid and is not already in use.



