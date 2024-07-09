### Example 1: Creates a Virtual Network Address on a Cloud VM Cluster resource
```powershell
New-AzOracleDatabaseVirtualNetworkAddress -Cloudvmclustername "OFake_PowerShellTestVmCluster" -Name "virtualNetworkAddressName" -ResourceGroupName "PowerShellTestRg"
```

Creates a Virtual Network Address on a Cloud VM Cluster resource.
For more information, execute `Get-Help New-AzOracleDatabaseVirtualNetworkAddress`