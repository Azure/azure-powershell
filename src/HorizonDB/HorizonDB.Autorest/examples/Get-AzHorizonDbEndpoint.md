### Example 1: List cluster endpoints
```powershell
Get-AzHorizonDbEndpoint -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, Scope, Role, FullyQualifiedDomainName
```

```output
Name                     : example-cluster
Scope                    : Cluster
Role                     : ReadWrite
FullyQualifiedDomainName : example-cluster.ffffffffffff.eastus2.horizondb.azure.com

Name                     : example-pool-01
Scope                    : Pool
Role                     : ReadOnly
FullyQualifiedDomainName : example-pool-01.example-cluster.ffffffffffff.eastus2.horizondb.azure.com
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a cluster endpoint
```powershell
Get-AzHorizonDbEndpoint -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-cluster' | Format-List -Property Name, Scope, Role, FullyQualifiedDomainName
```

```output
Name                     : example-cluster
Scope                    : Cluster
Role                     : ReadWrite
FullyQualifiedDomainName : example-cluster.ffffffffffff.eastus2.horizondb.azure.com
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 3: Get a read-only pool endpoint
```powershell
Get-AzHorizonDbEndpoint -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name 'example-pool-01' | Format-List -Property Name, Scope, Role, FullyQualifiedDomainName
```

```output
Name                     : example-pool-01
Scope                    : Pool
Role                     : ReadOnly
FullyQualifiedDomainName : example-pool-01.example-cluster.ffffffffffff.eastus2.horizondb.azure.com
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
