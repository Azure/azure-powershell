### Example 1: Get a specific policy for a namespace
```powershell
Get-AzDeviceRegistryPolicy -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace" -Name "my-policy"
```

```output
Name      Location ResourceGroupName
----      -------- -----------------
my-policy eastus   my-resource-group
```

Gets the specified policy from the Device Registry namespace.

### Example 2: List all policies for a namespace
```powershell
Get-AzDeviceRegistryPolicy -ResourceGroupName "my-resource-group" -NamespaceName "my-namespace"
```

```output
Name       Location ResourceGroupName
----       -------- -----------------
my-policy  eastus   my-resource-group
my-policy2 eastus   my-resource-group
```

Lists all policies in the specified Device Registry namespace.

{{ Add description here }}

