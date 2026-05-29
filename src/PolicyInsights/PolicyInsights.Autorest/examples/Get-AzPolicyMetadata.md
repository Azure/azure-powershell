### Example 1: Get all policy metadata resources
```powershell
Get-AzPolicyMetadata
```

This command gets all policy metadata resources.

### Example 2: Get a collection of 10 policy metadata resources
```powershell
Get-AzPolicyMetadata -Top 10
```

This command gets a collection of 10 policy metadata resources.

### Example 3: Get a single policy metadata resource with the name 'ACF1348'
```powershell
Get-AzPolicyMetadata -Name ACF1348
```

This command gets a single policy metadata resource with the name 'ACF1348'. 
It will include a bit more info about the resource than collection calls.