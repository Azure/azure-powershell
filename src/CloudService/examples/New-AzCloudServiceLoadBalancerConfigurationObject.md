### Example 1: Create load balancer configuration object

```powershell
PS C:\> $publicIP = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ContosOrg/providers/Microsoft.Network/publicIPAddresses/ContosoPublicIP"
PS C:\> $loadBalancerId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ContosOrg/providers/Microsoft.Network/loadBalancers/ContosoLB"
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIP
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -Id $loadBalancerId -FrontendIPConfiguration $feIpConfig
```
This command creates load balancer configuration object which is used for creating or updating a cloud service. For more details see New-AzCloudService.


