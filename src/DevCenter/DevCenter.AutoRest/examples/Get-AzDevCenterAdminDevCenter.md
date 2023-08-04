### Example 1: List dev centers in a subscription
```powershell
Get-AzDevCenterAdminDevCenter
```
This command lists the dev centers in the current subscription.

### Example 2: List dev centers in a resource group
```powershell
Get-AzDevCenterAdminDevCenter -ResourceGroupName testRg
```
This command lists the dev centers under the resource group "testRg".

### Example 3: Get a dev center
```powershell
Get-AzDevCenterAdminDevCenter -ResourceGroupName testRg -Name Contoso
```
This command gets the dev center named "Contoso" under the resource group "testRg". 

### Example 4: Get a dev center using InputObject
```powershell
$devCenter = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminDevCenter -InputObject $devCenter
```
This command gets the dev center named "Contoso" under the resource group "testRg".
