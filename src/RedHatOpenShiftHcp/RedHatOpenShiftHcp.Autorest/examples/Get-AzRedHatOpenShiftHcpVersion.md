### Example 1: List installable versions in a region
```powershell
Get-AzRedHatOpenShiftHcpVersion -Location westeurope -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

```output
Name     ChannelGroup Enabled EndOfLifeTimestamp
----     ------------ ------- ------------------
4.20.0   stable       True
4.20.42  stable       True
4.21.0   stable       True
4.21.37  stable       True
4.22.0   stable       True
4.22.18  stable       True
```

Lists the installable node-pool patch versions for the region, enabled-only and sorted ascending by semver (disabled versions are hidden). This default view is equivalent to `-NodePool`; use `Select-Object -Last 1` to pick the highest.

### Example 2: Control-plane view (distinct MAJOR.MINOR a cluster accepts)
```powershell
Get-AzRedHatOpenShiftHcpVersion -Location westeurope -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -ControlPlane
```

```output
Name ChannelGroup
---- ------------
4.20 stable
4.21 stable
4.22 stable
```

Returns the distinct MAJOR.MINOR versions a cluster accepts (enabled-only, ascending). Feed the highest, e.g. `4.22`, to `New-/Update-AzRedHatOpenShiftHcpCluster -VersionId` (the RP manages the patch and rejects a full X.Y.Z).

### Example 3: Node-pool view (full X.Y.Z a node pool requires)
```powershell
Get-AzRedHatOpenShiftHcpVersion -Location westeurope -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -NodePool
```

```output
Name     ChannelGroup Enabled EndOfLifeTimestamp
----     ------------ ------- ------------------
4.20.0   stable       True
4.21.0   stable       True
4.22.17  stable       True
4.22.18  stable       True
```

Returns the full X.Y.Z patch versions a node pool requires (enabled-only, ascending). Feed a concrete patch, e.g. `4.22.18`, to `New-AzRedHatOpenShiftHcpNodePool -VersionId` (a bare X.Y is rejected for node pools).
