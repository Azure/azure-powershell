### Example 1: Get an Azure Virtual Desktop App Attach Package by Name
```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -Name packageName1
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
```

This command gets an Azure Virtual Desktop App Attach Packages by name.

### Example 2: List all Azure Virtual Desktop App Attach Packages in a resource group
```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a resource group.

### Example 3: List all Azure Virtual Desktop App Attach Packages in a specified subscription
```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a subscription.

### Example 4: List all Azure Virtual Desktop App Attach Packages in the current subscription
```powershell
Get-AzWvdAppAttachPackage
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a subscription.
