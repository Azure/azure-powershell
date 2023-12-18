### Example 1: Delete a network connection
```powershell
Remove-AzDevCenterAdminNetworkConnection -Name networkEastUs -ResourceGroupName testRg
```
This command deletes a network connection named "networkEastUs" in the resource group "testRg".

### Example 2: Delete a network connection using InputObject
```powershell
$networkConnection = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName testRg -Name networkEastUs
Remove-AzDevCenterAdminNetworkConnection -InputObject $networkConnection
```
This command deletes a network connection named "networkEastUs" in the resource group "testRg".
