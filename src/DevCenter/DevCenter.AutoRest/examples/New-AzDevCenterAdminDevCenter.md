### Example 1: Create a dev center
```powershell
New-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg -Location eastus
```
This command creates a dev center named "Contoso" in the resource group "testRg". 

### Example 2: Create dev center with user assigned identity
```powershell
$identity = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/identityGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity1" = @{} }
New-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg -Location eastus -IdentityType "UserAssigned" -IdentityUserAssignedIdentity $identity
```
This command creates a dev center named "Contoso" with a user assigned identity.

### Example 3: Create a dev center using InputObject
```powershell
$devCenter = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminDevCenter -InputObject $devCenter -Location eastus
```
This command creates a dev center named "Contoso" in the resource group "testRg". 

### Example 4: Create a devcenter with a system assigned identity using InputObject
```powershell
$devCenter = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminDevCenter -InputObject $devCenter -Location eastus -IdentityType "SystemAssigned"
```
This command creates a dev center named "Contoso" with a system assigned identity.
