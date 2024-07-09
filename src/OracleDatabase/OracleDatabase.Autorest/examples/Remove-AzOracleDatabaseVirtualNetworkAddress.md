### Example 1: Deletes a Virtual Network Address on a Cloud VM Cluster resource
```powershell
Remove-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername "OFake_PowerShellTestVmCluster" -Name "virtualNetworkAddressName" -ResourceGroupName "PowerShellTestRg"
```

Deletes a Virtual Network Address on a Cloud VM Cluster resource.
For more information, execute `Get-Help Remove-AzOracleDatabaseVirtualNetworkAddress`