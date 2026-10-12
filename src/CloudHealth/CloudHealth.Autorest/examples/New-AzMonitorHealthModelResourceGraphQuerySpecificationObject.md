### Example 1: Build a Resource Graph discovery specification
```powershell
# Build a Resource Graph specification for use with a discovery rule
New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
```

Creates a Resource Graph specification for use with a discovery rule.
The query projects the resource id.
