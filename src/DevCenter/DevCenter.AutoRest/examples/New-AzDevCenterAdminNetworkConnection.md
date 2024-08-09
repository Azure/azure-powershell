### Example 1: Create an Azure AD joined network connection
```powershell
New-AzDevCenterAdminNetworkConnection -Name eastusNetwork -ResourceGroupName testRg -Location westus3 -DomainJoinType AzureADJoin -NetworkingResourceGroupName NetworkInterfaces -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"

```
This command creates an Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".

### Example 2: Create a hybid Azure AD joined network connection
```powershell
New-AzDevCenterAdminNetworkConnection -Name eastusNetwork -ResourceGroupName testRg -Location westus3 -DomainJoinType HybridAzureADJoin -DomainName mydomaincontroller.local -DomainPassword $password -DomainUsername testuser@mydomaincontroller.local -NetworkingResourceGroupName NetworkInterfaces -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"
```
This command creates a hybid Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".

### Example 3: Create an Azure AD joined network connection using InputObject
```powershell
$networkConnection = @{"ResourceGroupName" = "testRg"; "NetworkConnectionName" = "eastusNetwork"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminNetworkConnection -InputObject $networkConnection -Location westus3 -DomainJoinType AzureADJoin -NetworkingResourceGroupName NetworkInterfaces -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"
```
This command creates an Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".

### Example 4: Create a hybid Azure AD joined network connection using InputObject
```powershell
$networkConnection = @{"ResourceGroupName" = "testRg"; "NetworkConnectionName" = "eastusNetwork"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminNetworkConnection -InputObject $networkConnection -Location westus3 -DomainJoinType HybridAzureADJoin -DomainName mydomaincontroller.local -DomainPassword $password -DomainUsername testuser@mydomaincontroller.local -NetworkingResourceGroupName NetworkInterfaces -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"
```
This command creates a hybid Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".
