---
external help file:
Module Name: Az.StorageCache
online version: https://learn.microsoft.com/powershell/module/az.storagecache/new-azstoragecacheautoexportjob
schema: 2.0.0
---

# New-AzStorageCacheAutoExportJob

## SYNOPSIS
Create an auto export job.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageCacheAutoExportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AdminStatus <String>] [-AutoExportPrefix <String[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityAmlFilesystemExpanded
```
New-AzStorageCacheAutoExportJob -AmlFilesystemInputObject <IStorageCacheIdentity> -Name <String>
 -Location <String> [-AdminStatus <String>] [-AutoExportPrefix <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageCacheAutoExportJob -InputObject <IStorageCacheIdentity> -Location <String>
 [-AdminStatus <String>] [-AutoExportPrefix <String[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStorageCacheAutoExportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStorageCacheAutoExportJob -AmlFilesystemName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an auto export job.

## EXAMPLES

### Example 1: Create a new auto export job
```powershell
New-AzStorageCacheAutoExportJob -AmlFilesystemName 'myamlfilesystem' -Name 'myautoexportjob' -ResourceGroupName 'myresourcegroup' -Location 'East US' -AutoExportPrefix @('/path1')
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

Creates a new auto export job for the specified AML filesystem with the given auto export prefix.

## PARAMETERS

### -AdminStatus
The administrative status of the auto export job.
Possible values: 'Enable', 'Disable'.
Passing in a value of 'Disable' will disable the current active auto export job.
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

### -AutoExportPrefix
An array of blob paths/prefixes that get auto exported to the cluster namespace.
It has '/' as the default value.
Number of maximum allowed paths for now is 1.

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

### -Name
Name for the auto export job.
Allows alphanumerics, underscores, and hyphens.
Start and end with alphanumeric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityAmlFilesystemExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: AutoExportJobName

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageCache.Models.IAutoExportJob

## NOTES

## RELATED LINKS

