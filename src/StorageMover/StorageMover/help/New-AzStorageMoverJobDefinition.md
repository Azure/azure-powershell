---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/new-azstoragemoverjobdefinition
schema: 2.0.0
---

# New-AzStorageMoverJobDefinition

## SYNOPSIS
Creates or updates a Job Definition resource, which contains configuration for a single unit of managed data transfer.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] -CopyMode <CopyMode> -SourceName <String>
 -TargetName <String> [-AgentName <String>] [-Description <String>] [-SourceSubpath <String>]
 [-TargetSubpath <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] -JobDefinition <IJobDefinition>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a Job Definition resource, which contains configuration for a single unit of managed data transfer.

## EXAMPLES

### Example 1: Create a job definition
```powershell
New-AzStorageMoverJobDefinition -Name myJob -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -AgentName myAgent -SourceName myNfsEndpoint -TargetName myContainerEndpoint -CopyMode "Additive" -Description "job definition"
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  : job definition
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageM
                               overs/myStorageMover/projects/myProject/jobDefinitions/myJob
LatestJobRunName             :
LatestJobRunResourceId       :
LatestJobRunStatus           :
Name                         : myJob
ProvisioningState            : Succeeded
SourceName                   : myNfsEndpoint
SourceResourceId             :
SourceSubpath                :
SystemDataCreatedAt          : 7/26/2022 6:14:43 AM
SystemDataCreatedBy          : xxxxxxxxxxxxxxxxxxxx
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/26/2022 6:14:43 AM
SystemDataLastModifiedBy     : xxxxxxxxxxxxxxxxxxxx
SystemDataLastModifiedByType : User
TargetName                   : myContainerEndpoint
TargetResourceId             :
TargetSubpath                :
Type                         : microsoft.storagemover/storagemovers/projects/jobdefinitions
```

This command creates a job definition.

## PARAMETERS

### -AgentName
Name of the Agent to assign for new Job Runs of this Job Definition.

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

### -CopyMode
Strategy to use for copy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Support.CopyMode
Parameter Sets: CreateExpanded
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

### -Description
A description for the Job Definition.

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

### -JobDefinition
The Job Definition resource.
To construct, see NOTES section for JOBDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20231001.IJobDefinition
Parameter Sets: Create
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
Parameter Sets: (All)
Aliases: JobDefinitionName

Required: True
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

### -ProjectName
The name of the Project resource.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SourceName
The name of the source Endpoint.

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

### -SourceSubpath
The subpath to use when reading from the source Endpoint.

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

### -StorageMoverName
The name of the Storage Mover resource.

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

### -SubscriptionId
The ID of the target subscription.

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

### -TargetName
The name of the target Endpoint.

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

### -TargetSubpath
The subpath to use when writing to the target Endpoint.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20231001.IJobDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20231001.IJobDefinition

## NOTES

## RELATED LINKS
