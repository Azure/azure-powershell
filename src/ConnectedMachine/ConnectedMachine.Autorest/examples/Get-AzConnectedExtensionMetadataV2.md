### Example 1: Get a list of extension metadata
```powershell
Get-AzConnectedExtensionMetadataV2 -ExtensionType 'NetworkWatcherAgentWindows' -Location 'eastus' -Publisher 'Microsoft.Azure.NetworkWatcher'
```

```output
Name
----
```

Gets all versions of extension metadata for the specified extension type and publisher.

### Example 2: Get a specific extension metadata version
```powershell
Get-AzConnectedExtensionMetadataV2 -ExtensionType 'NetworkWatcherAgentWindows' -Location 'eastus' -Publisher 'Microsoft.Azure.NetworkWatcher' -Version '1.4.2798.3'
```

```output
Name
----
```

Gets extension metadata for a specific version.

{{ Add description here }}

