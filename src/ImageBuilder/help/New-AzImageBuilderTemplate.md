---
external help file:
Module Name: Az.ImageBuilder
online version: https://docs.microsoft.com/powershell/module/az.imagebuilder/new-azimagebuildertemplate
schema: 2.0.0
---

# New-AzImageBuilderTemplate

## SYNOPSIS
Create or update a virtual machine image template

## SYNTAX

### CreateExpanded (Default)
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> -Customize <IImageTemplateCustomizer[]>
 -Distribute <IImageTemplateDistributor[]> -Location <String> -Source <IImageTemplateSource>
 -UserAssignedIdentityId <String> [-SubscriptionId <String>] [-BuildTimeoutInMinute <Int32>]
 [-StagingResourceGroup <String>] [-Tag <Hashtable>] [-ValidateContinueDistributeOnFailure]
 [-ValidateSourceValidationOnly] [-Validator <IImageTemplateInVMValidator[]>] [-VMProfileOsdiskSizeGb <Int32>]
 [-VMProfileUserAssignedIdentity <String[]>] [-VMProfileVmsize <String>] [-VnetConfigProxyVMSize <String>]
 [-VnetConfigSubnetId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### JsonTemplatePath
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> -JsonTemplatePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create or update a virtual machine image template

## EXAMPLES

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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildTimeoutInMinute


```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customize
To construct, see NOTES section for CUSTOMIZE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateCustomizer[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Distribute
To construct, see NOTES section for DISTRIBUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateDistributor[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string.

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonTemplatePath


```yaml
Type: System.String
Parameter Sets: JsonTemplatePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the image Template

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ImageTemplateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
To construct, see NOTES section for SOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateSource
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StagingResourceGroup


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription Id forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag


```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateContinueDistributeOnFailure


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateSourceValidationOnly


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Validator
To construct, see NOTES section for VALIDATOR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateInVMValidator[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMProfileOsdiskSizeGb


```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMProfileUserAssignedIdentity


```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMProfileVmsize


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetConfigProxyVMSize


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetConfigSubnetId


```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplate

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CUSTOMIZE <IImageTemplateCustomizer[]>`: 
  - `Type <String>`: The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
  - `[Name <String>]`: Friendly Name to provide context on what this customization step does

`DISTRIBUTE <IImageTemplateDistributor[]>`: 
  - `RunOutputName <String>`: The name to be used for the associated RunOutput.
  - `Type <String>`: Type of distribution.
  - `[ArtifactTag <IImageTemplateDistributorArtifactTags>]`: Tags that will be applied to the artifact once it has been created/updated by the distributor.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`SOURCE <IImageTemplateSource>`: 
  - `Type <String>`: Specifies the type of source image you want to start with.

`VALIDATOR <IImageTemplateInVMValidator[]>`: 
  - `Type <String>`: The type of validation you want to use on the Image. For example, "Shell" can be shell validation
  - `[Name <String>]`: Friendly Name to provide context on what this validation step does

## RELATED LINKS

