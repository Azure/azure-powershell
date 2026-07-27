### Example 1: Get all extension types for a publisher in a location
```powershell
Get-AzConnectedExtensionType -Location 'eastus' -Publisher 'Microsoft.Azure.NetworkWatcher'
```

```output
Name
----
NetworkWatcherAgentWindows
NetworkWatcherAgentLinux
```

Gets all extension types available from the specified publisher in the given Azure region.

{{ Add description here }}

