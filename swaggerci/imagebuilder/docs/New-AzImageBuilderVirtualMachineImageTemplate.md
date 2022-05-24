---
external help file:
Module Name: Az.ImageBuilder
online version: https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/new-azimagebuildervirtualmachineimagetemplate
schema: 2.0.0
---

# New-AzImageBuilderVirtualMachineImageTemplate

## SYNOPSIS
Create or update a virtual machine image template

## SYNTAX

```
New-AzImageBuilderVirtualMachineImageTemplate -ImageTemplateName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-BuildTimeoutInMinute <Int32>]
 [-Customize <IImageTemplateCustomizer[]>] [-Distribute <IImageTemplateDistributor[]>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-SourceType <String>]
 [-StagingResourceGroup <String>] [-Tag <Hashtable>] [-ValidateContinueDistributeOnFailure]
 [-ValidateInVMValidation <IImageTemplateInVMValidator[]>] [-ValidateSourceValidationOnly]
 [-VMProfileOsdiskSizeGb <Int32>] [-VMProfileUserAssignedIdentity <String[]>] [-VMProfileVmsize <String>]
 [-VnetConfigProxyVMSize <String>] [-VnetConfigSubnetId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a virtual machine image template

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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
Maximum duration to wait while building the image template (includes all customizations, validations, and distributions).
Omit or specify 0 to use the default (4 hours).

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customize
Specifies the properties used to describe the customization steps of the image, like Image source etc
To construct, see NOTES section for CUSTOMIZE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateCustomizer[]
Parameter Sets: (All)
Aliases:

Required: False
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
The distribution targets where the image output needs to go to.
To construct, see NOTES section for DISTRIBUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateDistributor[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the image template.
The type 'None' will remove any identities from the image template.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the image template.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageTemplateName
The name of the image Template

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

### -Location
The geo-location where the resource lives

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

### -SourceType
Specifies the type of source image you want to start with.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateInVMValidation
List of validations to be performed.
To construct, see NOTES section for VALIDATEINVMVALIDATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220214.IImageTemplateInVMValidator[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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


CUSTOMIZE <IImageTemplateCustomizer[]>: Specifies the properties used to describe the customization steps of the image, like Image source etc
  - `Type <String>`: The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
  - `[Name <String>]`: Friendly Name to provide context on what this customization step does

DISTRIBUTE <IImageTemplateDistributor[]>: The distribution targets where the image output needs to go to.
  - `RunOutputName <String>`: The name to be used for the associated RunOutput.
  - `Type <String>`: Type of distribution.
  - `[ArtifactTag <IImageTemplateDistributorArtifactTags>]`: Tags that will be applied to the artifact once it has been created/updated by the distributor.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

VALIDATEINVMVALIDATION <IImageTemplateInVMValidator[]>: List of validations to be performed.
  - `Type <String>`: The type of validation you want to use on the Image. For example, "Shell" can be shell validation
  - `[Name <String>]`: Friendly Name to provide context on what this validation step does

## RELATED LINKS

