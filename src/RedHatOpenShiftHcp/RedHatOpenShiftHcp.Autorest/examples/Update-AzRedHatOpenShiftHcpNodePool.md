### Example 1: Scale a node pool by changing its replica count
```powershell
Update-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -Replica 3
```

```output
Name        Location ProvisioningState Replica PlatformVMSize   OSDiskSizeGiB VersionId
----        -------- ----------------- ------- --------------   ------------- ---------
mynodepool  eastus   Succeeded         3       Standard_D8s_v3  128           4.22.18
```

Patches the node pool `mynodepool` to run 3 replicas. This is an asynchronous (LRO) PATCH.

### Example 2: Change the node drain timeout
```powershell
Update-AzRedHatOpenShiftHcpNodePool -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster `
  -Name mynodepool -NodeDrainTimeoutMinute 45
```

```output
Name        Location ProvisioningState Replica NodeDrainTimeoutMinute VersionId
----        -------- ----------------- ------- ---------------------- ---------
mynodepool  eastus   Succeeded         3       45                     4.22.18
```

A cheap, config-only PATCH (no node churn) that updates the node drain timeout to 45 minutes. Only a subset of fields is patchable on a node pool (`-Replica`, `-AutoScalingMin`/`-AutoScalingMax`, `-Label`, `-Taint`, `-NodeDrainTimeoutMinute`, `-Tag`, `-VersionId`, `-VersionChannelGroup`) — not platform/subnet/osDisk/vmSize.
