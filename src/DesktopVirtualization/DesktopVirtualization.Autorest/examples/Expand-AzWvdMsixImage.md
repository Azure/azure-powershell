### Example 1: Expands specified Image Path and retrieves Package metadata found in AppxManifest.xml
```powershell
Expand-AzWvdMsixImage -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
          -Uri ImagePathURI
```

```output
Name                          Type
----                          ----
HostPoolName/extractmsiximage Microsoft.DesktopVirtualization/hostpools/extractmsiximage
```

This command returns Metadata of MSIX Package found in the given Image Path.

