### Example 1: Create an in-memory object for L3NetworkAttachmentConfiguration.
```powershell
New-AzNetworkCloudL3NetworkAttachmentConfigurationObject -NetworkId '/subscriptions/{subscriptionId}/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3network-502' -IpamEnabled True -PluginType 'SRIOV'
```
```output
IpamEnabled NetworkId                                                                                                                  PluginType
----------- ---------                                                                                                                  ----------
True        /subscriptions/{subscriptionId}/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3network-502 SRIOV
```
Create an in-memory object for L3NetworkAttachmentConfiguration.
