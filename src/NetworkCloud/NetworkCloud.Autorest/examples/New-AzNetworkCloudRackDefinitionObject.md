### Example 1: Create an in-memory object for RackDefinition.
```powershell
$password = ConvertTo-SecureString "********" -AsPlainText -Force
$bmmConfigurationData = New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername "username" -BmcMacAddress "00:BB:CC:DD:EE:FF" -BootMacAddress "00:BB:CC:DD:EE:FF" -RackSlot 1 -SerialNumber "serialNumber" -MachineDetail "machineDetail" -MachineName "machineName"
$saConfigurationData = New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword $password -AdminCredentialsUsername "username" -RackSlot 1 -SerialNumber "serialNumber" -StorageApplianceName "storageApplianceName"

$object = New-AzNetworkCloudRackDefinitionObject -NetworkRackId "/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/vNet/subnets/Subnet" -RackSerialNumber "aa5678" -RackSkuId "/subscriptions/subscriptionId/providers/Microsoft.NetworkCloud/rackSkus/VNearEdge1_Compute_DellR750_16C2M" -AvailabilityZone "1" -BareMetalMachineConfigurationData $bmmConfigurationData -RackLocation "Foo Datacenter, Floor 3, Aisle 9, Rack 2" -StorageApplianceConfigurationData $saConfigurationData

Write-Host ($object | Format-List | Out-String)
```

```output
AvailabilityZone                  : 1
BareMetalMachineConfigurationData : {{
                                      "bmcCredentials": {
                                        "password": "redacted",
                                        "username": "username"
                                      },
                                      "bmcMacAddress": "00:BB:CC:DD:EE:FF",
                                      "bootMacAddress": "00:BB:CC:DD:EE:FF",
                                      "machineDetails": "machineDetail",
                                      "machineName": "machineName",
                                      "rackSlot": 1,
                                      "serialNumber": "serialNumber"
                                    }}
NetworkRackId                     : /subscriptions/subscription/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/vNet/subnets/Subnet
RackLocation                      : Foo Datacenter, Floor 3, Aisle 9, Rack 2
RackSerialNumber                  : aa5678
RackSkuId                         : /subscriptions/subscriptionId/providers/Microsoft.NetworkCloud/rackSkus/VNearEdge1_Compute_DellR750_16C2M
StorageApplianceConfigurationData : {{
                                      "adminCredentials": {
                                        "password": "redacted",
                                        "username": "username"
                                      },
                                      "rackSlot": 1,
                                      "serialNumber": "serialNumber",
                                      "storageApplianceName": "storageApplianceName"
                                    }}
```

Create an in-memory object for RackDefinition.
