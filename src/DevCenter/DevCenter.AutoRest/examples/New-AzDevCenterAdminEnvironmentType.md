### Example 1: Create an environment type
```powershell
$tags = @{"dev" ="test"}
New-AzDevCenterAdminEnvironmentType -DevCenterName Contoso -Name DevTest -ResourceGroupName testRg -Tag $tags
```
This command creates an environment type named "DevTest" in the dev center "Contoso". 

### Example 2: Create an environment type using InputObject
```powershell
$tags = @{"dev" ="test"}
$envType = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminEnvironmentType -InputObject $envType -Tag $tags
```
This command creates an environment type named "DevTest" in the dev center "Contoso". 

