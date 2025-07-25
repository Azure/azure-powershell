### Example 1: Creates an AppAttachPackage object from Package metadata found in AppxManifest.xml
```powershell
Import-AzWvdAppAttachPackageInfo -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
          -Path ImagePathURI
```

```output
Name                       Type
----                       ----
importappattachpackageinfo Microsoft.DesktopVirtualization/appattachpackages
```

This command returns Metadata of MSIX Package found in the given Image Path.
