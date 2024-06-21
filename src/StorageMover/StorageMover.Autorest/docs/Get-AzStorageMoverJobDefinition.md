---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/get-azstoragemoverjobdefinition
schema: 2.0.0
---

# Get-AzStorageMoverJobDefinition

## SYNOPSIS
Gets a Job Definition resource.

## SYNTAX

### List (Default)
```
Get-AzStorageMoverJobDefinition -ProjectName <String> -ResourceGroupName <String> -StorageMoverName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageMoverJobDefinition -InputObject <IStorageMoverIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Job Definition resource.

## EXAMPLES

### Example 1: Get all job definitions under a Storage mover
```powershell
Get-AzStorageMoverJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover 
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1
LatestJobRunName             : 12345678-1234-1234-1234-111111111111
LatestJobRunResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
LatestJobRunStatus           : Queued
Name                         : myJob1
ProvisioningState            : Succeeded
SourceName                   : nfsEndpoint1
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/28/2022 5:47:29 AM
SystemDataCreatedBy          : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 3:09:15 AM
SystemDataLastModifiedBy     : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataLastModifiedByType : Application
TargetName                   : containerEndpoint1
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command gets all the job definitions under a specific Storage mover.

### Example 2: Get a specific job definition
```powershell
Get-AzStorageMoverJobDefinition -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myJob1
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1
LatestJobRunName             : 12345678-1234-1234-1234-111111111111
LatestJobRunResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob1/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
LatestJobRunStatus           : Queued
Name                         : myJob1
ProvisioningState            : Succeeded
SourceName                   : nfsEndpoint1
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/28/2022 5:47:29 AM
SystemDataCreatedBy          : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 3:09:15 AM
SystemDataLastModifiedBy     : bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb
SystemDataLastModifiedByType : Application
TargetName                   : containerEndpoint1
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command gets a specific job definition.

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

### -Name
The name of the Job Definition resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: JobDefinitionName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IJobDefinition

## NOTES

## RELATED LINKS

