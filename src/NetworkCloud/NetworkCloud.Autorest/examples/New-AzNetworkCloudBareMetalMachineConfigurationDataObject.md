### Example 1: Create an in-memory object for BareMetalMachineConfigurationData.
```powershell
$password = ConvertTo-SecureString "********" -AsPlainText -Force

New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername username -BmcMacAddress "00:BB:CC:DD:EE:FF" -BootMacAddress "00:BB:CC:DD:EE:FF" -RackSlot 1 -SerialNumber serialNumber -MachineDetail machineDetail -MachineName machineName
```

```output
BmcConnectionString BmcMacAddress     BootMacAddress    MachineDetail MachineName RackSlot SerialNumber
------------------- -------------     --------------    ------------- ----------- -------- ------------
                    00:BB:CC:DD:EE:FF 00:BB:CC:DD:EE:FF machineDetail machineName 1        serialNumber
```

Create an in-memory object for BareMetalMachineConfigurationData.
