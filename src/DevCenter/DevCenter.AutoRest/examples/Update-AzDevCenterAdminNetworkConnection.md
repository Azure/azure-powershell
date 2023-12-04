### Example 1: Update an Azure AD joined network connection
```powershell
Update-AzDevCenterAdminNetworkConnection -Name eastusNetwork -ResourceGroupName testRg -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default" -DomainPassword $null
```
This command updates an Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".


### Example 2: Update a hybid Azure AD joined network connection
```powershell
Update-AzDevCenterAdminNetworkConnection -Name eastusNetwork -ResourceGroupName testRg -DomainName mydomaincontroller.local -DomainUsername testuser@mydomaincontroller.local -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"
```
This command updates a hybid Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".


### Example 3: Update an Azure AD joined network connection
```powershell
$networkConnectionInput = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName testRg -Name eastusNetwork
Update-AzDevCenterAdminNetworkConnection -InputObject $networkConnectionInput -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default" -DomainPassword $null
```
This command updates an Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".


### Example 4: Update a hybid Azure AD joined network connection
```powershell
$hybridNetworkConnectionInput = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName testRg -Name eastusNetwork
Update-AzDevCenterAdminNetworkConnection -InputObject $hybridNetworkConnectionInput -DomainName mydomaincontroller.local -DomainUsername testuser@mydomaincontroller.local -SubnetId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ExampleRG/providers/Microsoft.Network/virtualNetworks/ExampleVNet/subnets/default"
```
This command updates a hybid Azure AD joined network connection named "eastusNetwork" in the resource group "testRg".
