---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/update-azdatatransferflowprofile
schema: 2.0.0
---

# Update-AzDataTransferFlowProfile

## SYNOPSIS
Applies partial update to an existing FlowProfile resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataTransferFlowProfile -Name <String> -PipelineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AntivirusAvSolution <String[]>] [-ArchiveMaximumCompressionRatioLimit <Double>]
 [-ArchiveMaximumDepthLimit <Int64>] [-ArchiveMaximumExpansionSizeLimit <Int64>]
 [-ArchiveMinimumSizeForExpansion <Int64>] [-DataSizeMaximum <Int64>] [-DataSizeMinimum <Int64>]
 [-Description <String>] [-IdentityType <String>] [-MimeFilter <IMimeTypeFilter[]>] [-MimeFilterType <String>]
 [-Status <String>] [-Tag <Hashtable>] [-TextMatchingDeny <ITextMatch[]>] [-UserAssignedIdentity <Hashtable>]
 [-XmlFilterDefaultNamespace <String>] [-XmlFilterReference <String>] [-XmlFilterSchema <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataTransferFlowProfile -InputObject <IDataTransferIdentity> [-AntivirusAvSolution <String[]>]
 [-ArchiveMaximumCompressionRatioLimit <Double>] [-ArchiveMaximumDepthLimit <Int64>]
 [-ArchiveMaximumExpansionSizeLimit <Int64>] [-ArchiveMinimumSizeForExpansion <Int64>]
 [-DataSizeMaximum <Int64>] [-DataSizeMinimum <Int64>] [-Description <String>] [-IdentityType <String>]
 [-MimeFilter <IMimeTypeFilter[]>] [-MimeFilterType <String>] [-Status <String>] [-Tag <Hashtable>]
 [-TextMatchingDeny <ITextMatch[]>] [-UserAssignedIdentity <Hashtable>] [-XmlFilterDefaultNamespace <String>]
 [-XmlFilterReference <String>] [-XmlFilterSchema <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityPipelineExpanded
```
Update-AzDataTransferFlowProfile -Name <String> -PipelineInputObject <IDataTransferIdentity>
 [-AntivirusAvSolution <String[]>] [-ArchiveMaximumCompressionRatioLimit <Double>]
 [-ArchiveMaximumDepthLimit <Int64>] [-ArchiveMaximumExpansionSizeLimit <Int64>]
 [-ArchiveMinimumSizeForExpansion <Int64>] [-DataSizeMaximum <Int64>] [-DataSizeMinimum <Int64>]
 [-Description <String>] [-IdentityType <String>] [-MimeFilter <IMimeTypeFilter[]>] [-MimeFilterType <String>]
 [-Status <String>] [-Tag <Hashtable>] [-TextMatchingDeny <ITextMatch[]>] [-UserAssignedIdentity <Hashtable>]
 [-XmlFilterDefaultNamespace <String>] [-XmlFilterReference <String>] [-XmlFilterSchema <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDataTransferFlowProfile -Name <String> -PipelineName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDataTransferFlowProfile -Name <String> -PipelineName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Applies partial update to an existing FlowProfile resource.

## EXAMPLES

### Example 1: Update FlowProfile status and description
```powershell
Update-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "files-flowprofile" -Status "Disabled" -Description "Updated FlowProfile - temporarily disabled for maintenance"
```

```output
Name               : files-flowprofile
ResourceGroupName  : ResourceGroup01
Location           : EastUS
Pipeline          : Pipeline01
ReplicationScenario: Files
Status            : Disabled
Description       : Updated FlowProfile - temporarily disabled for maintenance
FlowProfileId     : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile
ModifiedTime      : 2025-09-23T11:15:30Z
```

Updates the status and description of an existing FlowProfile.
This is useful for maintenance scenarios or when you need to modify basic properties.

### Example 2: Add MIME filters and antivirus protection to an existing FlowProfile
```powershell
$mimeFilters = @("application/pdf", "image/jpeg", "image/png", "application/zip")
Update-AzDataTransferFlowProfile -PipelineName "Pipeline01" -ResourceGroupName "ResourceGroup01" -FlowProfileName "files-flowprofile" -MimeFilter $mimeFilters -AntiviruAvSolution @("Defender") -Status "Enabled"
```

```output
Name               : files-flowprofile
ResourceGroupName  : ResourceGroup01
Location           : EastUS
Pipeline          : Pipeline01
ReplicationScenario: Files
Status            : Enabled
Description       : Updated FlowProfile - temporarily disabled for maintenance
MimeFilter        : {application/pdf, image/jpeg, image/png, application/zip}
AntiviruAvSolution: {Defender}
FlowProfileId     : /subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/ResourceGroup01/providers/Microsoft.AzureDataTransfer/pipelines/Pipeline01/flowProfiles/files-flowprofile
ModifiedTime      : 2025-09-23T11:20:45Z
```

Enhances an existing FlowProfile by adding MIME type filtering and antivirus protection while re-enabling it.
This demonstrates how to add security features to existing configurations.

## PARAMETERS

### -AntivirusAvSolution
Optional.
The list of antiviruses to be used as a scanning solution for replicating data.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArchiveMaximumCompressionRatioLimit
Optional.
Provides the multiplication value for an archive in total based on the initial object being validated.
This value takes the root object size and multiplies it by this value to create a maximum.
Once this maximum is exceeded, the archive is failed.
Used to detect and block archives with suspiciously high compression (e.g., zip bombs).

```yaml
Type: System.Double
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArchiveMaximumDepthLimit
Optional.
The maximum depth of nested archives that can be expanded.
Limits how many layers of embedded archives will be processed.
Archives exceeding the max limit will be denied for replication.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArchiveMaximumExpansionSizeLimit
Optional.
The combined maximum size (in bytes) of all extracted files that an expanded archive is allowed to reach.
Archives exceeding the max limit will be denied for replication.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArchiveMinimumSizeForExpansion
Optional.
Default is 0.
The minimum archive file size (in bytes) required to trigger expansion during replication.
Any archive file size below the configured threshold will skip the rest of the configured rulesets for archives.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DataSizeMaximum
Optional.
Specifies the maximum allowed size (in bytes) for files to be replicated.
Any file size greater than maximum will be denied replication.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSizeMinimum
Optional.
Default is 0.
Specifies the minimum required size (in bytes) for a file to be eligible for replication.
Any file size less than minimum will be denied replication.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
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

### -Description
A description of the FlowProfile that defines the replication scenario.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MimeFilter
Defines the Media types (f.k.a MIME types) and associated file extensions to be filtered.
For more detail, please refer to the MimeTypeFiler model.

```yaml
Type: ADT.Models.IMimeTypeFilter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MimeFilterType
Specifies whether the filter is an allow list or deny list.
For more detail, please refer to the FilterType model.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the FlowProfile resource to operate on.
Must be 3 to 64 characters long and contain only alphanumeric characters or hyphens.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityPipelineExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: FlowProfileName

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

### -PipelineInputObject
Identity Parameter

```yaml
Type: ADT.Models.IDataTransferIdentity
Parameter Sets: UpdateViaIdentityPipelineExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PipelineName
The name of the pipeline on which to operate.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The operational status of the FlowProfile.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TextMatchingDeny
A list of text patterns to block, each with matching rules and case sensitivity options.

```yaml
Type: ADT.Models.ITextMatch[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XmlFilterDefaultNamespace
The default XML namespace used for schema validation.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XmlFilterReference
Defines the method for referencing the xml schema.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XmlFilterSchema
The inline XSD schema to be used for validation.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityPipelineExpanded
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

### ADT.Models.IDataTransferIdentity

## OUTPUTS

### ADT.Models.IFlowProfile

## NOTES

## RELATED LINKS

