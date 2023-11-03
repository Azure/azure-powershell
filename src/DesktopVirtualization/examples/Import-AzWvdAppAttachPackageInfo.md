### Example 1: Creates an App Attach Package object from Package metadata found in AppxManifest.xml

```powershell
Import-AppAttachPackageInfo -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
          -Path ImagePathURI

Name                       Type
----                       ----
importappattachpackageinfo Microsoft.DesktopVirtualization/appattachpackages
```

This command returns Metadata of MSIX Package found in the given Image Path.
