---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/get-azstoragecacheautoexportjob
schema: 2.0.0
---

# Get-AzStorageCacheAutoExportJob

## SYNOPSIS
Returns an auto export job.

## SYNTAX

### List (Default)
```
Get-AzStorageCacheAutoExportJob -AmlFilesystemName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageCacheAutoExportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageCacheAutoExportJob -InputObject <IStorageCacheIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityAmlFilesystem
```
Get-AzStorageCacheAutoExportJob -AmlFilesystemInputObject <IStorageCacheIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns an auto export job.

## EXAMPLES

### Example 1: List all auto export jobs for an AML filesystem
```powershell
Get-AzStorageCacheAutoExportJob -AmlFilesystemName 'myamlfilesystem' -ResourceGroupName 'myresourcegroup'
```

```output
AdminStatus                                    : Enable
AutoExportPrefix                               : {/path1}
AzureAsyncOperation                            :
Id                                             : /subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/myresourcegroup/providers/Microsoft.Storag
                                                 eCache/amlFilesystems/myamlfilesystem/autoExportJobs/myautoexportjob
Location                                       : eastus
Name                                           : myautoexportjob
ProvisioningState                              : Succeeded
ResourceGroupName                              : myresourcegroup
StatusCode                                     :
StatusCurrentIterationFilesDiscovered          : 0
StatusCurrentIterationFilesExported            : 0
StatusCurrentIterationFilesFailed              : 0
StatusCurrentIterationMiBDiscovered            : 0
StatusCurrentIterationMiBExported              : 0
StatusExportIterationCount                     : 0
StatusLastCompletionTimeUtc                    :
StatusLastStartedTimeUtc                       :
StatusLastSuccessfulIterationCompletionTimeUtc :
StatusMessage                                  :
StatusState                                    : InProgress
StatusTotalFilesExported                       : 0
StatusTotalFilesFailed                         : 0
StatusTotalMiBExported                         : 0
SystemDataCreatedAt                            :
SystemDataCreatedBy                            :
SystemDataCreatedByType                        :
SystemDataLastModifiedAt                       :
SystemDataLastModifiedBy                       :
SystemDataLastModifiedByType                   :
Tag                                            : {
                                                 }
Type                                           : Microsoft.StorageCache/amlFilesystems/autoExportJobs
```

Lists all auto export jobs for the specified AML filesystem.

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
Name for the auto export job.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityAmlFilesystem
Aliases: AutoExportJobName

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IAutoExportJob

## NOTES

## RELATED LINKS

