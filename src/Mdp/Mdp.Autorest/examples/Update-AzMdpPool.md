### Example 1: Update a Managed DevOps Pool
```powershell
Update-AzMdpPool -Name Contoso -ResourceGroupName testRg -MaximumConcurrency 2 -Tag @{"tag1"= "value1"}
```

This command updates a Managed DevOps Pool named "Contoso" under the resource group "testRG"

### Example 2: Update a Managed DevOps Pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "PoolName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}

Update-AzMdpPool -InputObject $pool -MaximumConcurrency 2 -Tag @{"tag1"= "value1"}
```

This command updates a Managed DevOps Pool named "Contoso" under the resource group "testRG"
 