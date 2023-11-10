### Example 1: Create a virtual machine image template
```powershell
$source = New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher "Canonical" -Offer "UbuntuServer" -Sku "18.04-LTS" -Version "latest"
$customizer = New-AzImageBuilderTemplateCustomizerObject -ShellCustomizer -Name "CheckSumCompareShellScript" -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh" -Sha256Checksum "ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93"
$distributor = New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{"test"="dis-share"} -GalleryImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image" -ReplicationRegion "eastus" -RunOutputName "runoutput-01"
$userAssignedIdentity = "/subscriptions/{subId}/resourcegroups/azps_test_group_imagebuilder/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-mi-imagebuilder"

New-AzImageBuilderTemplate -Name azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Location eastus -UserAssignedIdentityId $userAssignedIdentity -Source $source -Customize $customizer -Distribute $distributor
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-1 azps_test_group_imagebuilder
```

This commands creates a virtual machine image template.

### Example 2: Create a virtual machine image template via Json file
```powershell
$requestbodyjson = '{
  "location": "eastus",
  "properties": {
    "source": {
      "type": "PlatformImage",
      "publisher": "Canonical",
      "offer": "UbuntuServer",
      "sku": "18.04-LTS",
      "version": "latest"
    },
    "customize": [
      {
        "type": "Shell",
        "name": "CheckSumCompareShellScript",
        "scriptUri": "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh",
        "sha256Checksum": "ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93"
      }
    ],
    "distribute": [
      {
        "type": "SharedImage",
        "runOutputName": "runoutput-01",
        "artifactTags": {
          "test": "dis-share"
        },
        "galleryImageId": "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image",
        "replicationRegions": [
          "eastus"
        ]
      }
    ]
  },
  "identity": {
    "type": "UserAssigned",
    "userAssignedIdentities": {
      "/subscriptions/{subId}/resourcegroups/azps_test_group_imagebuilder/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-mi-imagebuilder": {}
    }
  }
}'
$requestbodyjson | Out-File -FilePath "C:\request_body.json"

New-AzImageBuilderTemplate -Name azps-ibt-2 -ResourceGroupName azps_test_group_imagebuilder -JsonTemplatePath "C:\request_body.json"
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-2 azps_test_group_imagebuilder
```

This commands creates a virtual machine image template via Json file.

### Example 3: Create a virtual machine image template via Json string
```powershell
New-AzImageBuilderTemplate -Name azps-ibt-3 -ResourceGroupName azps_test_group_imagebuilder -JsonString '{
  "location": "eastus",
  "properties": {
    "source": {
      "type": "PlatformImage",
      "publisher": "Canonical",
      "offer": "UbuntuServer",
      "sku": "18.04-LTS",
      "version": "latest"
    },
    "customize": [
      {
        "type": "Shell",
        "name": "CheckSumCompareShellScript",
        "scriptUri": "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh",
        "sha256Checksum": "ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93"
      }
    ],
    "distribute": [
      {
        "type": "SharedImage",
        "runOutputName": "runoutput-01",
        "artifactTags": {
          "test": "dis-share"
        },
        "galleryImageId": "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image",
        "replicationRegions": [
          "eastus"
        ]
      }
    ]
  },
  "identity": {
    "type": "UserAssigned",
    "userAssignedIdentities": {
      "/subscriptions/{subId}/resourcegroups/azps_test_group_imagebuilder/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-mi-imagebuilder": {}
    }
  }
}'
```

```output
Location Name       ResourceGroupName
-------- ----       -----------------
eastus   azps-ibt-3 azps_test_group_imagebuilder
```

This commands creates a virtual machine image template via Json stri.