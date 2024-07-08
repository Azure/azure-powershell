### Example 1: Gets a list of the Private IP Addresses for a Cloud VM Cluster resource
```powershell
$subnetName = "delegated"
$subnetId = "/subscriptions/$($subscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)/subnets/$($subnetName)"

Get-AzOracleDatabaseCloudVMClusterPrivateIpaddress -Cloudvmclustername "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -SubnetId $subnetId -VnicId "vnidId"
```

Gets a list of the Private IP Addresses for a Cloud VM Cluster resource.
For more information, execute `Get-Help Get-AzOracleDatabaseCloudVMClusterPrivateIpaddress`