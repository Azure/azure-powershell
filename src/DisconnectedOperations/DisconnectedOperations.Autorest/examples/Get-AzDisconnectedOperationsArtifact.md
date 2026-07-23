### Example 1: List all artifacts from a specified image
```powershell
Get-AzDisconnectedOperationsArtifact -ImageName "default" -Name "disconnected-operation-name" -ResourceGroupName "my-resource-group"
```

```output
Name                   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
My-artifact-1                                                                                                                                                         my-resource-group
My-artifact-2                                                                                                                                                         my-resource-group                                                                    
```

This command lists all the artifacts from image `default` in resource group `my-resource-group`

### Example 2: Get a specific artifact by name
```powershell
Get-AzDisconnectedOperationsArtifact -ArtifactName "my-artifact" -ImageName "default" -Name "disconnected-operation-name" -ResourceGroupName "my-resource-group"
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group`	

### Example 3: GetViaIdentity for artifact.
```powershell
$disconnectedOperationsArtifact = @{
  "ArtifactName" = "my-artifact";
  "ImageName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsArtifact -InputObject $disconnectedOperationsArtifact
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact.vhdx
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx` via the Artifact Identity input object.

### Example 4: GetViaIdentityImage for artifact.
```powershell
$disconnectedOperationsImage = @{
  "ImageName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsArtifact -ArtifactName "my-artifact" -ImageInputObject $disconnectedOperationsImage
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact.vhdx
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx` via the Image Identity input object.

### Example 5: GetViaIdentityDisconnectedOperation for artifact.
```powershell
$disconnectedOperations = @{
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsArtifact -ArtifactName "my-artifact" -ImageName "default" -DisconnectedOperationInputObject $disconnectedOperations
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact.vhdx
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx` via the DisconnectedOperations Identity input object.