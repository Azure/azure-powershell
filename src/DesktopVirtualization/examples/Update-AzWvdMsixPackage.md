### Example 1: Update a MSIX Package 
```powershell
PS C:\> Update-AzWvdMsixPackage -HostPoolName HostPoolName `
				-ResourceGroupName ResourceGroupName `
				-SubscriptionId SubscriptionId `
				-displayName 'Updated-display-Name' `
        			-IsRegularRegistration:$False `
				-IsActive:$True

Name                                                  Type
----                                                  ----
HostPoolName/MSIXPackage_FullName1                    Microsoft.DesktopVirtualization/hostpools/msixpackages
```

This command updates a MSIX Package in a HostPool.


