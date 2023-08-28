### Example 1: Update an environment type
```powershell
$tags = @{"dev" = "test" }

Update-AzDevCenterAdminEnvironmentType -DevCenterName Contoso -Name DevTest -ResourceGroupName testRg -Tag $tags
```
This command updates an environment type named "DevTest" in the dev center "Contoso". 


### Example 2: Update an environment type using InputObject
```powershell
$envType = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "EnvironmentTypeName" = "DevTest"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
$tags = @{"dev" = "test" }

Update-AzDevCenterAdminEnvironmentType -InputObject $envType -Tag $tags
```
This command updates an environment type named "DevTest" in the dev center "Contoso". 

