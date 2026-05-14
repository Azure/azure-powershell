---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/new-azstoragecacheautoimportjob
schema: 2.0.0
---

# New-AzStorageCacheAutoImportJob

## SYNOPSIS
Create an auto import job.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageCacheAutoImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AdminStatus <String>] [-AutoImportPrefix <String[]>]
 [-ConflictResolutionMode <String>] [-EnableDeletion] [-MaximumError <Int64>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityAmlFilesystemExpanded
```
New-AzStorageCacheAutoImportJob -AmlFilesystemInputObject <IStorageCacheIdentity> -Name <String>
 -Location <String> [-AdminStatus <String>] [-AutoImportPrefix <String[]>] [-ConflictResolutionMode <String>]
 [-EnableDeletion] [-MaximumError <Int64>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageCacheAutoImportJob -InputObject <IStorageCacheIdentity> -Location <String>
 [-AdminStatus <String>] [-AutoImportPrefix <String[]>] [-ConflictResolutionMode <String>] [-EnableDeletion]
 [-MaximumError <Int64>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStorageCacheAutoImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStorageCacheAutoImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an auto import job.

## EXAMPLES

### Example 1: Create a new auto import job
```powershell
New-AzStorageCacheAutoImportJob -AmlFilesystemName 'myamlfilesystem' -Name 'myautoimportjob' -ResourceGroupName 'myresourcegroup' -Location 'East US' -AutoImportPrefix @('/path1', '/path2')
```

```output
AdminStatus                  : Enable
AutoImportPrefix             : {/path1, /path2}
AzureAsyncOperation          :
ConflictResolutionMode       : Fail
EnableDeletion               : False
Id                           : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.StorageCache/amlFilesyst
                               ems/myamlfilesystem/autoImportJobs/myautoimportjob
Location                     : eastus
MaximumError                 : 0
Name                         : myautoimportjob
ProvisioningState            : Succeeded
ResourceGroupName            : myresourcegroup
Status                       : {
                                 "blobSyncEvents": {
                                   "importedFiles": 0,
                                   "importedDirectories": 0,
                                   "importedSymlinks": 0,
                                   "preexistingFiles": 0,
                                   "preexistingDirectories": 0,
                                   "preexistingSymlinks": 0,
                                   "totalBlobsImported": 0,
                                   "rateOfBlobImport": 0,
                                   "totalErrors": 0,
                                   "totalConflicts": 0,
                                   "deletions": 0
                                 },
                                 "state": "InProgress",
                                 "totalBlobsWalked": 0,
                                 "rateOfBlobWalk": 0,
                                 "totalBlobsImported": 0,
                                 "rateOfBlobImport": 0,
                                 "importedFiles": 0,
                                 "importedDirectories": 0,
                                 "importedSymlinks": 0,
                                 "preexistingFiles": 0,
                                 "preexistingDirectories": 0,
                                 "preexistingSymlinks": 0,
                                 "totalErrors": 0,
                                 "totalConflicts": 0,
                                 "lastStartedTimeUTC": "2025-09-06T02:29:26.4888208Z"
                               }
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.StorageCache/amlFilesystems/autoImportJobs
```

Creates a new auto import job for the specified AML filesystem with the given auto import prefixes.

## PARAMETERS

### -AdminStatus
The administrative status of the auto import job.
Possible values: 'Enable', 'Disable'.
Passing in a value of 'Disable' will disable the current active auto import job.
By default it is set to 'Enable'.

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

### -AutoImportPrefix
An array of blob paths/prefixes that get auto imported to the cluster namespace.
It has '/' as the default value.
Number of maximum allowed paths is 100.

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

### -ConflictResolutionMode
How the auto import job will handle conflicts.
For example, if the auto import job is trying to bring in a directory, but a file is at that path, how it handles it.
Fail indicates that the auto import job should stop immediately and not do anything with the conflict.
Skip indicates that it should pass over the conflict.
OverwriteIfDirty causes the auto import job to delete and re-import the file or directory if it is a conflicting type, is dirty, or is currently released.
OverwriteAlways extends OverwriteIfDirty to include releasing files that had been restored but were not dirty.
Please reference https://learn.microsoft.com/en-us/azure/azure-managed-lustre/blob-integration#conflict-resolution-mode for a thorough explanation of these resolution modes.

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

### -EnableDeletion
Whether or not to enable deletions during auto import.
This only affects overwrite-dirty.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Total non-conflict-oriented errors (e.g., OS errors) Import will tolerate before exiting with failure.
-1 means infinite.
0 means exit immediately on any error.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name for the auto import job.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: AutoImportJobName

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IAutoImportJob

## NOTES

## RELATED LINKS

