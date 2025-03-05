### Example 1: Replace a bare metal machine
```powershell
$baseboardManagementControllerPassword = ConvertTo-SecureString "password" -asplaintext -force

Invoke-AzNetworkCloudBareMetalMachineReplace -Name bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -BmcCredentialsPassword $baseboardManagementControllerPassword -BmcCredentialsUsername baseboardManagementControllerUsername -BmcMacAddress baseboardManagementControllerMacAddress -BootMacAddress bmmBootMacAddress -MachineName newMachineName -SerialNumber bmmSerialNumber
```

This command replaces an existing bare metal machine.
