### Example 1: Build a Resource Graph discovery specification
```powershell
New-AzMonitorHealthModelResourceGraphQuerySpecificationObject -ResourceGraphQuery "resources | where type =~ 'microsoft.compute/virtualmachines' | project id"
```

Creates the specification for a discovery rule that finds resources with an Azure Resource Graph query. The query must project the resource id.
