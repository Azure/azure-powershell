---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/get-azstoragemoverjobrun
schema: 2.0.0
---

# Get-AzStorageMoverJobRun

## SYNOPSIS
Gets a Job Run resource.

## SYNTAX

### List (Default)
```
Get-AzStorageMoverJobRun -JobDefinitionName <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStorageMoverJobRun -JobDefinitionName <String> -Name <String> -ProjectName <String>
 -ResourceGroupName <String> -StorageMoverName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageMoverJobRun -InputObject <IStorageMoverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Job Run resource.

## EXAMPLES

### Example 1: Get all job runs with a job definition
```powershell
Get-AzStorageMoverJobRun -JobDefinitionName myJobDefinition -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -ProjectName myProject
```

```output
AgentName                    : myAgent
AgentResourceId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/agents/myAgent
BytesExcluded                : 0
BytesFailed                  : 0
BytesNoTransferNeeded        : 0
BytesScanned                 : 0
BytesTransferred             : 0
BytesUnsupported             : 0
ErrorCode                    :
ErrorMessage                 :
ExecutionEndTime             :
ExecutionStartTime           : 2/24/2023 12:27:58 AM
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob/
                               jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ItemsExcluded                : 0
ItemsFailed                  : 0
ItemsNoTransferNeeded        : 0
ItemsScanned                 : 0
ItemsTransferred             : 0
ItemsUnsupported             : 0
JobDefinitionProperty        : {
                               }
LastStatusUpdate             : 2/24/2023 12:27:39 AM
Name                         : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ProvisioningState            : Succeeded
ScanStatus                   : NotStarted
SourceName                   : sourceendpoint
SourceProperty               : {
                               }
SourceResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/sourceendpoint
Status                       : Started
SystemDataCreatedAt          : 2/24/2023 12:27:39 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2/24/2023 12:36:01 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Target                       :
TargetName                   : targetendpoint
TargetProperty               : {
                               }
TargetResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/targetendpoint
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions/jobruns
```

This command gets all the job runs under a specific job definition

### Example 2: Get a specific job run
```powershell
Get-AzStorageMoverJobRun -Name myJobRun -JobDefinitionName myJobDefinition -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -ProjectName myProject
```

```output
AgentName                    : myAgent
AgentResourceId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/agents/myAgent
BytesExcluded                : 0
BytesFailed                  : 0
BytesNoTransferNeeded        : 0
BytesScanned                 : 0
BytesTransferred             : 0
BytesUnsupported             : 0
ErrorCode                    :
ErrorMessage                 :
ExecutionEndTime             :
ExecutionStartTime           : 2/24/2023 12:27:58 AM
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob/
                               jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ItemsExcluded                : 0
ItemsFailed                  : 0
ItemsNoTransferNeeded        : 0
ItemsScanned                 : 0
ItemsTransferred             : 0
ItemsUnsupported             : 0
JobDefinitionProperty        : {
                               }
LastStatusUpdate             : 2/24/2023 12:27:39 AM
Name                         : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
ProvisioningState            : Succeeded
ScanStatus                   : NotStarted
SourceName                   : sourceendpoint
SourceProperty               : {
                               }
SourceResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/sourceendpoint
Status                       : Started
SystemDataCreatedAt          : 2/24/2023 12:27:39 AM
SystemDataCreatedBy          : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 2/24/2023 12:36:01 AM
SystemDataLastModifiedBy     : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SystemDataLastModifiedByType : Application
Target                       :
TargetName                   : targetendpoint
TargetProperty               : {
                               }
TargetResourceId             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/targetendpoint
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions/jobruns
```

This command gets a specific job run.

## PARAMETERS

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobDefinitionName
The name of the Job Definition resource.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Job Run resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: JobRunName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The name of the Project resource.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IJobRun

## NOTES

## RELATED LINKS
