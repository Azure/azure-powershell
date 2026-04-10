### Example 1: Create credentials for a namespace
```powershell
New-AzDeviceRegistryCredentials -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -Location "eastus"
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default eastus   my-resource-group
```

Creates a credentials resource for the specified Device Registry namespace.

{{ Add description here }}

