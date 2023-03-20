---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemoverjobdefinition
schema: 2.0.0
---

# Update-AzStorageMoverJobDefinition

## SYNOPSIS
Updates properties for a Job Definition resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] [-AgentName <String>] [-CopyMode <CopyMode>]
 [-Description <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzStorageMoverJobDefinition -Name <String> -ProjectName <String> -ResourceGroupName <String>
 -StorageMoverName <String> -JobDefinition <IJobDefinitionUpdateParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzStorageMoverJobDefinition -InputObject <IStorageMoverIdentity>
 -JobDefinition <IJobDefinitionUpdateParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverJobDefinition -InputObject <IStorageMoverIdentity> [-AgentName <String>]
 [-CopyMode <CopyMode>] [-Description <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates properties for a Job Definition resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update a job definition
```powershell
Update-AzStorageMoverJobDefinition -Name myJob -ProjectName myProject -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Description "Update Description"
```

```output
AgentName                    : myAgent
AgentResourceId              :
CopyMode                     : Additive
Description                  : Update description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob
LatestJobRunName             : 12345678-1234-1234-1234-111111111111
LatestJobRunResourceId       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/projects/myProject/jobDefinitions/myJob/jobRuns/aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
LatestJobRunStatus           : Queued
Name                         : myJob
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

This command updates the description of a job definition.

## PARAMETERS

### -AgentName
Name of the Agent to assign for new Job Runs of this Job Definition.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -Description
A description for the Job Definition.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobDefinition
The Job Definition resource.
To construct, see NOTES section for JOBDEFINITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20230301.IJobDefinitionUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20230301.IJobDefinitionUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20230301.IJobDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IStorageMoverIdentity>`: Identity Parameter
  - `[AgentName <String>]`: The name of the Agent resource.
  - `[EndpointName <String>]`: The name of the Endpoint resource.
  - `[Id <String>]`: Resource identity path
  - `[JobDefinitionName <String>]`: The name of the Job Definition resource.
  - `[JobRunName <String>]`: The name of the Job Run resource.
  - `[ProjectName <String>]`: The name of the Project resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[StorageMoverName <String>]`: The name of the Storage Mover resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`JOBDEFINITION <IJobDefinitionUpdateParameters>`: The Job Definition resource.
  - `[AgentName <String>]`: Name of the Agent to assign for new Job Runs of this Job Definition.
  - `[CopyMode <CopyMode?>]`: Strategy to use for copy.
  - `[Description <String>]`: A description for the Job Definition.

## RELATED LINKS

