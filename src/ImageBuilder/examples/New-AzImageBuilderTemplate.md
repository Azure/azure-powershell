### Example 1: Create a virtual machine image template
```powershell
# Create a platform image source
$source = New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher 'Canonical' -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest'
# Create a shell customizer
$customizer = New-AzImageBuilderTemplateCustomizerObject -ShellCustomizer -Name 'CheckSumCompareShellScript' -ScriptUri 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh' -Sha256Checksum 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
# Create a shared image distributor
$distributor = New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Compute/galleries/bez_gallery/images/bez-image' -ReplicationRegion 'eastus2' -RunOutputName 'runoutput-01' -ExcludeFromLatest $false
# the userAssignedIdentity should have access permissions to the image above
$userAssignedIdentity = '/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/bez-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/bez-id'
# Create a virtual machine image template
New-AzImageBuilderTemplate -Name bez-test-img-temp -ResourceGroupName bez-rg -Location eastus -UserAssignedIdentityId $userAssignedIdentity -Source $source -Customize $customizer -Distribute $distributor  
```

```output
Location Name              SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType       
-------- ----              ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------       
eastus   bez-test-img-temp
```

This commands creates a virtual machine image template.

### Example 2: Create a virtual machine image template via Json file
```powershell
# request_body.json
# {
#   "location": "eastus",
#   "properties": {
#     "source": {
#       "type": "PlatformImage",
#       "publisher": "Canonical",
#       "offer": "UbuntuServer",
#       "sku": "18.04-LTS",
#       "version": "latest"
#     },
#     "customize": [
#       {
#         "type": "Shell",
#         "name": "CheckSumCompareShellScript",
#         "scriptUri": "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh",
#         "sha256Checksum": "ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93"
#       }
#     ],
#     "distribute": [
#       {
#         "type": "SharedImage",
#         "runOutputName": "runoutput-01",
#         "artifactTags": {
#           "tag": "dis-share"
#         },
#         "galleryImageId": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Compute/galleries/bez_gallery/images/bez-image",
#         "replicationRegions": [
#           "eastus2"
#         ],
#         "excludeFromLatest": false
#       }
#     ]
#   },
#   "identity": {
#     "type": "UserAssigned",
#     "userAssignedIdentities": {
#       "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/bez-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/bez-id": {}
#     }
#   }
# }
New-AzImageBuilderTemplate -Name bez-test-img-temp12 -ResourceGroupName bez-rg -JsonTemplatePath ./request_body.json
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----                ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
eastus   bez-test-img-temp12
```

This commands creates a virtual machine image template via Json file.

### Example 3: Create a virtual machine image template via Json string
```powershell
New-AzImageBuilderTemplate -Name bez-test-img-temp13 -ResourceGroupName bez-rg -JsonString '{
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
          "tag": "dis-share"
        },
        "galleryImageId": "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Compute/galleries/bez_gallery/images/bez-image",
        "replicationRegions": [
          "eastus2"
        ],
        "excludeFromLatest": false
      }
    ]
  },
  "identity": {
    "type": "UserAssigned",
    "userAssignedIdentities": {
      "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourcegroups/bez-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/bez-id": {}
    }
  }
}'
```

```output
Location Name                SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType
-------- ----                ------------------- ------------------- ----------------------- ------------------------ ------------------------ ----------------------------
eastus   bez-test-img-temp12
```

This commands creates a virtual machine image template via Json stri.