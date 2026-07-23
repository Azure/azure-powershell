### Example 1: List all images from a specified DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsImage -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

```output
Name              SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----              ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
release-v2509                                                                                                                                                    ResourceGroup-1
release-v2508                                                                                                                                                    ResourceGroup-1
release0811                                                                                                                                                      ResourceGroup-1
june-2025-release                                                                                                                                                ResourceGroup-1
```

This command lists all the images from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1`.

### Example 2: Get a specific image from a DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsImage -ImageName "release-v2509" -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

```output
CompatibleVersion            : {}
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedOperations/Resource-1/images/release-v2509
Name                         : release-v2509
ProvisioningState            : Succeeded
ReleaseDate                  : 10/17/2025 00:00:00
ReleaseDisplayName           : release-v2509
ReleaseNote                  : https://aka.ms/aldo-publicdocs
ReleaseType                  : Install
ReleaseVersion               : 1.0.1
ResourceGroupName            : ResourceGroup-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Edge/disconnectedOperations/images
```

This command gets the image `release-v2509` from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1`.

### Example 3: GetViaIdentity for image.
```powershell
$disconnectedOperationsImage = @{
  "ImageName" = "default";
  "Name" = "Resource-1";
  "ResourceGroupName" = "ResourceGroup-1";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsImage -InputObject $disconnectedOperationsImage
```

```output
CompatibleVersion            : {}
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedOperations/Resource-1/images/release-v2509
Name                         : release-v2509
ProvisioningState            : Succeeded
ReleaseDate                  : 10/17/2025 00:00:00
ReleaseDisplayName           : release-v2509
ReleaseNote                  : https://aka.ms/aldo-publicdocs
ReleaseType                  : Install
ReleaseVersion               : 1.0.1
ResourceGroupName            : ResourceGroup-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Edge/disconnectedOperations/images
```

This command gets the default or latest image from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1` using InputObject for image.

### Example 4: GetViaIdentityDisconnectedOperations for image.
```powershell
$disconnectedOperations = @{
  "Name" = "Resource-1";
  "ResourceGroupName" = "ResourceGroup-1";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsImage -ImageName "default" -DisconnectedOperationInputObject $disconnectedOperations
```

```output
CompatibleVersion            : {}
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedOperations/Resource-1/images/release-v2509
Name                         : release-v2509
ProvisioningState            : Succeeded
ReleaseDate                  : 10/17/2025 00:00:00
ReleaseDisplayName           : release-v2509
ReleaseNote                  : https://aka.ms/aldo-publicdocs
ReleaseType                  : Install
ReleaseVersion               : 1.0.1
ResourceGroupName            : ResourceGroup-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Edge/disconnectedOperations/images
```

This command gets the default or latest image from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1` using DisconnectedOperationsObject and ImageName.