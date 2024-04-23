---
external help file: Az.ImageBuilder-help.xml
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.imagebuilder/new-azimagebuildertemplate
schema: 2.0.0
---

# New-AzImageBuilderTemplate

## SYNOPSIS
Create or update a virtual machine image template

## SYNTAX

### CreateExpanded (Default)
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -Customize <IImageTemplateCustomizer[]> -Distribute <IImageTemplateDistributor[]>
 -Source <IImageTemplateSource> -UserAssignedIdentityId <String> [-BuildTimeoutInMinute <Int32>]
 [-StagingResourceGroup <String>] [-Tag <Hashtable>] [-VMBootState <VMBootOptimizationState>]
 [-VMProfileOsdiskSizeGb <Int32>] [-VMProfileUserAssignedIdentity <String[]>] [-VMProfileVmsize <String>]
 [-ValidateContinueDistributeOnFailure] [-ValidateSourceValidationOnly]
 [-Validator <IImageTemplateInVMValidator[]>] [-VnetConfigProxyVMSize <String>] [-VnetConfigSubnetId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### JsonTemplatePath
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonTemplatePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzImageBuilderTemplate -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] -JsonString <String> [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a virtual machine image template

## EXAMPLES

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplateCustomizer[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplateDistributor[]
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplateSource
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplateInVMValidator[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMBootState

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.VMBootOptimizationState
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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.IImageTemplate

## NOTES

## RELATED LINKS
