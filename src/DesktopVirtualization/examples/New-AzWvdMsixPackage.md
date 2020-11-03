### Example 1: Creates New MSIX Package in the HostPool via Package Alias
```powershell
PS C:\> New-AzWvdMsixPackage -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
	  -PackageAlias packagealias `
	  -ImagePath ImagePathURI  `
```

This command adds MSIX package from specified image path to HostPool

### Example 2: Creates New MSIX Package in the HostPool
```powershell
PS C:\> New-AzWvdMsixPackage -FullName PackageFullName `
							-HostPoolName HostPoolName `
							-ResourceGroupName ResourceGroupName ` 
							-SubscriptionId SubscriptionId ` 
							-DisplayName displayname `
							-ImagePath imageURI ` 
							-IsActive:$false `
							-IsRegularRegistration:$false `
							-LastUpdated datelastupdated `
							-PackageApplication $apps `
							-PackageDependency $deps `
							-PackageFamilyName packagefamilyname `
							-PackageName packagename `
							-PackageRelativePath packagerelativepath `
							-Version packageversion `

Name                              Type
----                              ----
HotPoolName/PackageFullName		 Microsoft.DesktopVirtualization/hostpools/msixpackages

```

This command adds MSIX Package in the specified HostPool

