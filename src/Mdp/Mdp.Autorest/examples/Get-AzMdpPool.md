### Example 1: List pools in a subscription
```powershell
Get-AzMdpPool
```
This command lists the Managed DevOps Pools in the current subscription.

### Example 2: List pools in a resource group
```powershell
Get-AzMdpPool -ResourceGroupName testRg
```
This command lists the Managed DevOps Pools under the resource group "testRg".

### Example 3: Get a pool
```powershell
Get-AzMdpPool -ResourceGroupName testRg -Name Contoso
```
This command gets the Managed DevOps Pool named "Contoso" under the resource group "testRg". 

### Example 4: Get a pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "PoolName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzMdpPool -InputObject $pool
```
This command gets the Managed DevOps Pool named "Contoso" under the resource group "testRg".
