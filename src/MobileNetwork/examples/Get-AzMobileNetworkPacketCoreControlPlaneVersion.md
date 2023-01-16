### Example 1: List information about the specified packet core control plane version by sub.
```powershell
Get-AzMobileNetworkPacketCoreControlPlaneVersion
```

```output
Name
----
PMN-4-9-0
......
pmn-2301-0-1
......
...
```

List information about the specified packet core control plane version by sub.

### Example 2: Get information about the specified packet core control plane version by VersionName.
```powershell
Get-AzMobileNetworkPacketCoreControlPlaneVersion -VersionName pmn-2301-0-1
```

```output
Name
----
pmn-2301-0-1
```

Get information about the specified packet core control plane version by VersionName.