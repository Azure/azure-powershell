### Example 1: Create an in-memory object for BareMetalMachineConfigurationData.
```powershell
New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword <SecureString> -BmcCredentialsUsername <String> -BmcMacAddress <String> -BootMacAddress <String> -RackSlot <Int64> -SerialNumber <String> [-MachineDetail <String>] [-MachineName <String>]
```
Create an in-memory object for BareMetalMachineConfigurationData.