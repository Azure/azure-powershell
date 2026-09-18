---
external help file: Az.ImageBuilder-help.xml
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.imagebuilder/new-azimagebuildertemplate
schema: 2.0.0
---

# New-AzImageBuilderTemplate

## SYNOPSIS
create a virtual machine image template

## SYNTAX

### CreateExpanded (Default)
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -Customize <IImageTemplateCustomizer[]> -Distribute <IImageTemplateDistributor[]>
 -Source <IImageTemplateSource> [-BuildTimeoutInMinute <Int32>] [-StagingResourceGroup <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-VMBootState <String>] [-VMProfileOsdiskSizeGb <Int32>]
 [-VMProfileUserAssignedIdentity <String[]>] [-VMProfileVmsize <String>] [-ValidateContinueDistributeOnFailure]
 [-ValidateSourceValidationOnly] [-Validator <IImageTemplateInVMValidator[]>] [-VnetConfigProxyVMSize <String>]
 [-VnetConfigSubnetId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
create a virtual machine image template

## EXAMPLES

### Example 1: Create a virtual machine image template
```powershell
$source = New-AzImageBuilderTemplateSourceObject -Publisher "Canonical" -Offer "UbuntuServer" -Sku "18.04-LTS" -Version "latest"
$customizer = New-AzImageBuilderTemplateCustomizerObject -ShellCustomizer -Name "CheckSumCompareShellScript" -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh" -Sha256Checksum "ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93"
$distributor = New-AzImageBuilderTemplateDistributorObject -SharedImageDistributor -ArtifactTag @{"test"="dis-share"} -GalleryImageId "/subscriptions/{subId}/resourceGroups/azps_test_group_imagebuilder/providers/Microsoft.Compute/galleries/azpsazurecomputergallery/images/azps-vm-image" -ReplicationRegion "eastus" -RunOutputName "runoutput-01"
$userAssignedIdentity = "/subscriptions/{subId}/resourcegroups/azps_test_group_imagebuilder/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azps-mi-imagebuilder"

New-AzImageBuilderTemplate -Name azps-ibt-1 -ResourceGroupName azps_test_group_imagebuilder -Location eastus -UserAssignedIdentity $userAssignedIdentity -Source $source -Customize $customizer -Distribute $distributor
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

New-AzImageBuilderTemplate -Name azps-ibt-2 -ResourceGroupName azps_test_group_imagebuilder -JsonFilePath "C:\request_body.json"
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

This commands creates a virtual machine image template via Json string.

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
Maximum duration to wait while building the image template (includes all customizations, optimization, validations, and distributions).
Omit or specify 0 to use the default (4 hours).

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
Specifies the properties used to describe the customization steps of the image, like Image source etc

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageTemplateCustomizer[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
The distribution targets where the image output needs to go to.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageTemplateDistributor[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases: JsonTemplatePath

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

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

### -Location
The geo-location where the resource lives

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
Specifies the properties used to describe the source image.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageTemplateSource
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StagingResourceGroup
The staging resource group id in the same subscription as the image template that will be used to build the image.
If this field is empty, a resource group with a random name will be created.
If the resource group specified in this field doesn't exist, it will be created with the same name.
If the resource group specified exists, it must be empty and in the same region as the image template.
The resource group created will be deleted during template deletion if this field is empty or the resource group specified doesn't exist, but if the resource group specified exists the resources created in the resource group will be deleted during template deletion and the resource group itself will remain.

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
Resource tags.

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases: UserAssignedIdentityId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateContinueDistributeOnFailure
If validation fails and this field is set to false, output image(s) will not be distributed.
This is the default behavior.
If validation fails and this field is set to true, output image(s) will still be distributed.
Please use this option with caution as it may result in bad images being distributed for use.
In either case (true or false), the end to end image run will be reported as having failed in case of a validation failure.
[Note: This field has no effect if validation succeeds.]

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
If this field is set to true, the image specified in the 'source' section will directly be validated.
No separate build will be run to generate and then validate a customized image.

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
List of validations to be performed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageTemplateInVMValidator[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMBootState
Enabling this field will improve VM boot time by optimizing the final customized image output.

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

### -VMProfileOsdiskSizeGb
Size of the OS disk in GB.
Omit or specify 0 to use Azure's default OS disk size.

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
Optional array of resource IDs of user assigned managed identities to be configured on the build VM and validation VM.
This may include the identity of the image template.

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
Size of the virtual machine used to build, customize and capture images.
Omit or specify empty string to use the default (Standard_D1_v2 for Gen1 images and Standard_D2ds_v4 for Gen2 images).

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
Size of the proxy virtual machine used to pass traffic to the build VM and validation VM.
Omit or specify empty string to use the default (Standard_A1_v2).

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
Resource id of a pre-existing subnet.

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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageTemplate

## NOTES

## RELATED LINKS
