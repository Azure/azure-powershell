---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/new-azstoragecacheimportjob
schema: 2.0.0
---

# New-AzStorageCacheImportJob

## SYNOPSIS
Create an import job.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageCacheImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AdminStatus <String>] [-ConflictResolutionMode <String>]
 [-ImportPrefix <String[]>] [-MaximumError <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityAmlFilesystemExpanded
```
New-AzStorageCacheImportJob -AmlFilesystemInputObject <IStorageCacheIdentity> -Name <String>
 -Location <String> [-AdminStatus <String>] [-ConflictResolutionMode <String>] [-ImportPrefix <String[]>]
 [-MaximumError <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageCacheImportJob -InputObject <IStorageCacheIdentity> -Location <String> [-AdminStatus <String>]
 [-ConflictResolutionMode <String>] [-ImportPrefix <String[]>] [-MaximumError <Int32>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStorageCacheImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStorageCacheImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an import job.

## EXAMPLES

### Example 1: Create a new import job
```powershell
New-AzStorageCacheImportJob -AmlFilesystemName 'myamlfilesystem' -Name 'myimportjob' -ResourceGroupName 'myresourcegroup' -Location 'East US' -ImportPrefix @('/path1', '/path2')
```

```output
AdminStatus                  : Active
AzureAsyncOperation          :
ConflictResolutionMode       : Fail
Id                           : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.StorageCache/amlFilesyst
                               ems/myamlfilesystem/importJobs/myimportjob
ImportPrefix                 : {/path1, /path2}
Location                     : eastus
MaximumError                 : 0
Name                         : myimportjob
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
StatusBlobsImportedPerSecond : 0
StatusBlobsWalkedPerSecond   : 0
StatusImportedDirectory      :
StatusImportedFile           :
StatusImportedSymlink        :
StatusLastCompletionTime     : 9/4/2025 4:38:00 AM
StatusLastStartedTime        : 9/4/2025 4:37:54 AM
StatusMessage                :
StatusPreexistingDirectory   :
StatusPreexistingFile        :
StatusPreexistingSymlink     :
StatusState                  : Completed
StatusTotalBlobsImported     : 0
StatusTotalBlobsWalked       : 0
StatusTotalConflict          : 0
StatusTotalError             : 0
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.StorageCache/amlFilesystems/importJobs
```

Creates a new import job for the specified AML filesystem with the given import prefixes.

## PARAMETERS

### -AdminStatus
The administrative status of the import job.
Possible values: 'Active', 'Cancel'.
Passing in a value of 'Cancel' will cancel the current active import job.
By default it is set to 'Active'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AmlFilesystemInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: CreateViaIdentityAmlFilesystemExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AmlFilesystemName
Name for the AML file system.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
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

### -ConflictResolutionMode
How the import job will handle conflicts.
For example, if the import job is trying to bring in a directory, but a file is at that path, how it handles it.
Fail indicates that the import job should stop immediately and not do anything with the conflict.
Skip indicates that it should pass over the conflict.
OverwriteIfDirty causes the import job to delete and re-import the file or directory if it is a conflicting type, is dirty, or was not previously imported.
OverwriteAlways extends OverwriteIfDirty to include releasing files that had been restored but were not dirty.
Please reference https://learn.microsoft.com/en-us/azure/azure-managed-lustre/ for a thorough explanation of these resolution modes.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
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

### -ImportPrefix
An array of blob paths/prefixes that get imported into the cluster namespace.
It has '/' as the default value.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

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
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaximumError
Total non-conflict oriented errors the import job will tolerate before exiting with failure.
-1 means infinite.
0 means exit immediately and is the default.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name for the import job.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: ImportJobName

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
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IImportJob

## NOTES

## RELATED LINKS

