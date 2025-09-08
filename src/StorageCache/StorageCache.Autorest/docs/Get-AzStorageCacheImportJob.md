---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/get-azstoragecacheimportjob
schema: 2.0.0
---

# Get-AzStorageCacheImportJob

## SYNOPSIS
Returns an import job.

## SYNTAX

### List (Default)
```
Get-AzStorageCacheImportJob -AmlFilesystemName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageCacheImportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageCacheImportJob -InputObject <IStorageCacheIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAmlFilesystem
```
Get-AzStorageCacheImportJob -AmlFilesystemInputObject <IStorageCacheIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns an import job.

## EXAMPLES

### Example 1: Get all import jobs for an AML filesystem
```powershell
Get-AzStorageCacheImportJob -AmlFilesystemName 'myamlfilesystem' -ResourceGroupName 'myresourcegroup'
```

```output
AdminStatus          : Completed
ClientRequestId       :
ConflictResolution    : OverwriteAlways
FailureReason        :
Id                   : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.Sto
                       rageCache/amlFilesystems/myamlfilesystem/importJobs/myimportjob1
ImportPrefixesSource :
ImportPrefixes       : {/path1}
Location             : East US
MaximumError         : 0
Name                 : myimportjob1
ProvisioningState    : Succeeded
State                : Completed
StatusMessage        : Import job completed successfully
SystemDataCreatedAt  : 12/8/2024 2:30:15 PM
SystemDataCreatedBy  : user@example.com
SystemDataCreatedByType : User
SystemDataLastModifiedAt : 12/8/2024 2:35:20 PM
SystemDataLastModifiedBy : user@example.com
SystemDataLastModifiedByType : User
Type                 : Microsoft.StorageCache/amlFilesystems/importJobs

AdminStatus          : InProgress
ClientRequestId       :
ConflictResolution    : OverwriteIfDirty
FailureReason        :
Id                   : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.Sto
                       rageCache/amlFilesystems/myamlfilesystem/importJobs/myimportjob2
ImportPrefixesSource :
ImportPrefixes       : {/path2}
Location             : East US
MaximumError         : 5
Name                 : myimportjob2
ProvisioningState    : Succeeded
State                : InProgress
StatusMessage        : Import job is running
SystemDataCreatedAt  : 12/8/2024 3:00:10 PM
SystemDataCreatedBy  : user@example.com
SystemDataCreatedByType : User
SystemDataLastModifiedAt : 12/8/2024 3:00:10 PM
SystemDataLastModifiedBy : user@example.com
SystemDataLastModifiedByType : User
Type                 : Microsoft.StorageCache/amlFilesystems/importJobs
```

Gets all import jobs for the specified AML filesystem.

## PARAMETERS

### -AmlFilesystemInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: GetViaIdentityAmlFilesystem
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
Parameter Sets: Get, List
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IStorageCacheIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name for the import job.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityAmlFilesystem
Aliases: ImportJobName

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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

