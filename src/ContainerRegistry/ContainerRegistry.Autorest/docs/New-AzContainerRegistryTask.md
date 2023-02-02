---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/new-azcontainerregistrytask
schema: 2.0.0
---

# New-AzContainerRegistryTask

## SYNOPSIS
Creates a task for a container registry with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzContainerRegistryTask -Name <String> -RegistryName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AgentConfigurationCpu <Int32>] [-AgentPoolName <String>]
 [-BaseImageTriggerBaseImageTriggerType <BaseImageTriggerType>] [-BaseImageTriggerName <String>]
 [-BaseImageTriggerStatus <TriggerStatus>] [-BaseImageTriggerUpdateTriggerEndpoint <String>]
 [-BaseImageTriggerUpdateTriggerPayloadType <UpdateTriggerPayloadType>]
 [-CredentialsCustomRegistry <Hashtable>] [-IdentityPrincipalId <String>] [-IdentityTenantId <String>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-IsSystemTask]
 [-LogTemplate <String>] [-PlatformArchitecture <Architecture>] [-PlatformOS <OS>]
 [-PlatformVariant <Variant>] [-SourceRegistryLoginMode <SourceRegistryLoginMode>] [-Status <TaskStatus>]
 [-StepContextAccessToken <String>] [-StepContextPath <String>] [-StepType <StepType>] [-Tag <Hashtable>]
 [-Timeout <Int32>] [-TriggerSourceTrigger <ISourceTrigger[]>] [-TriggerTimerTrigger <ITimerTrigger[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzContainerRegistryTask -Name <String> -RegistryName <String> -ResourceGroupName <String>
 -TaskCreateParameter <ITask> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzContainerRegistryTask -InputObject <IContainerRegistryIdentity> -TaskCreateParameter <ITask>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzContainerRegistryTask -InputObject <IContainerRegistryIdentity> -Location <String>
 [-AgentConfigurationCpu <Int32>] [-AgentPoolName <String>]
 [-BaseImageTriggerBaseImageTriggerType <BaseImageTriggerType>] [-BaseImageTriggerName <String>]
 [-BaseImageTriggerStatus <TriggerStatus>] [-BaseImageTriggerUpdateTriggerEndpoint <String>]
 [-BaseImageTriggerUpdateTriggerPayloadType <UpdateTriggerPayloadType>]
 [-CredentialsCustomRegistry <Hashtable>] [-IdentityPrincipalId <String>] [-IdentityTenantId <String>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>] [-IsSystemTask]
 [-LogTemplate <String>] [-PlatformArchitecture <Architecture>] [-PlatformOS <OS>]
 [-PlatformVariant <Variant>] [-SourceRegistryLoginMode <SourceRegistryLoginMode>] [-Status <TaskStatus>]
 [-StepContextAccessToken <String>] [-StepContextPath <String>] [-StepType <StepType>] [-Tag <Hashtable>]
 [-Timeout <Int32>] [-TriggerSourceTrigger <ISourceTrigger[]>] [-TriggerTimerTrigger <ITimerTrigger[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a task for a container registry with the specified parameters.

## EXAMPLES

### Example 1: Create a quicktask
```powershell
 New-AzContainerRegistryTask -Name quicktask -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Location "eastus" -Status 'Enabled' -IsSystemTask -LogTemplate "acr/tasks:{{.Run.OS}}"
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt System
                                                                                                                    DataLa
                                                                                                                    stModi
                                                                                                                    fiedBy
-------- ----      -------------------   -------------------       ----------------------- ------------------------ ------
eastus   quicktask 29/01/2023 8:34:07 pm nanxiangliu@microsoft.com User                    29/01/2023 8:34:07 pm    nanxi…
```

Create a quicktask

## PARAMETERS

### -AgentConfigurationCpu
The CPU configuration in terms of number of cores required for the run.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentPoolName
The dedicated agent pool for the task.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -BaseImageTriggerBaseImageTriggerType
The type of the auto trigger for base image dependency updates.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.BaseImageTriggerType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseImageTriggerName
The name of the trigger.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseImageTriggerStatus
The current status of trigger.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.TriggerStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseImageTriggerUpdateTriggerEndpoint
The endpoint URL for receiving update triggers.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaseImageTriggerUpdateTriggerPayloadType
Type of Payload body for Base image update triggers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.UpdateTriggerPayloadType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CredentialsCustomRegistry
Describes the credential parameters for accessing other custom registries.
The keyfor the dictionary item will be the registry login server (myregistry.azurecr.io) andthe value of the item will be the registry credentials for accessing the registry.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -IdentityPrincipalId
The principal ID of resource identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityTenantId
The tenant ID of resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.ResourceIdentityType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the resource.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/ providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsSystemTask
The value of this property indicates whether the task resource is system task or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource.
This cannot be changed after the resource is created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogTemplate
The template that describes the repository and tag information for run log artifact.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the container registry task.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: TaskName

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

### -PlatformArchitecture
The OS architecture.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.Architecture
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformOS
The operating system type required for the run.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.OS
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlatformVariant
Variant of the CPU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.Variant
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the container registry belongs.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceRegistryLoginMode
The authentication mode which determines the source registry login scope.
The credentials for the source registrywill be generated using the given scope.
These credentials will be used to login tothe source registry during the run.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.SourceRegistryLoginMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The current status of task.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.TaskStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StepContextAccessToken
The token (git PAT or SAS token of storage account blob) associated with the context for a step.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StepContextPath
The URL(absolute or relative) of the source context for the task step.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StepType
The type of the step.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.StepType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskCreateParameter
The task that has the ARM resource and task properties.

The task will have all information to schedule a run against it.
To construct, see NOTES section for TASKCREATEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.ITask
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Timeout
Run timeout in seconds.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerSourceTrigger
The collection of triggers based on source code repository.
To construct, see NOTES section for TRIGGERSOURCETRIGGER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.ISourceTrigger[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerTimerTrigger
The collection of timer triggers.
To construct, see NOTES section for TRIGGERTIMERTRIGGER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.ITimerTrigger[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.ITask

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api20190601Preview.ITask

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerRegistryIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[ConnectedRegistryName <String>]`: The name of the connected registry.
  - `[ExportPipelineName <String>]`: The name of the export pipeline.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[ImportPipelineName <String>]`: The name of the import pipeline.
  - `[PipelineRunName <String>]`: The name of the pipeline run.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[RegistryName <String>]`: The name of the container registry.
  - `[ReplicationName <String>]`: The name of the replication.
  - `[ResourceGroupName <String>]`: The name of the resource group to which the container registry belongs.
  - `[RunId <String>]`: The run ID.
  - `[ScopeMapName <String>]`: The name of the scope map.
  - `[SubscriptionId <String>]`: The Microsoft Azure subscription ID.
  - `[TaskName <String>]`: The name of the container registry task.
  - `[TaskRunName <String>]`: The name of the task run.
  - `[TokenName <String>]`: The name of the token.
  - `[WebhookName <String>]`: The name of the webhook.

`TASKCREATEPARAMETER <ITask>`: The task that has the ARM resource and task properties.         The task will have all information to schedule a run against it.
  - `Location <String>`: The location of the resource. This cannot be changed after the resource is created.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource modification (UTC).
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <LastModifiedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <IResourceTags>]`: The tags of the resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AgentConfigurationCpu <Int32?>]`: The CPU configuration in terms of number of cores required for the run.
  - `[AgentPoolName <String>]`: The dedicated agent pool for the task.
  - `[BaseImageTriggerBaseImageTriggerType <BaseImageTriggerType?>]`: The type of the auto trigger for base image dependency updates.
  - `[BaseImageTriggerName <String>]`: The name of the trigger.
  - `[BaseImageTriggerStatus <TriggerStatus?>]`: The current status of trigger.
  - `[BaseImageTriggerUpdateTriggerEndpoint <String>]`: The endpoint URL for receiving update triggers.
  - `[BaseImageTriggerUpdateTriggerPayloadType <UpdateTriggerPayloadType?>]`: Type of Payload body for Base image update triggers.
  - `[CredentialsCustomRegistry <ICredentialsCustomRegistries>]`: Describes the credential parameters for accessing other custom registries. The key         for the dictionary item will be the registry login server (myregistry.azurecr.io) and         the value of the item will be the registry credentials for accessing the registry.
    - `[(Any) <ICustomRegistryCredentials>]`: This indicates any property can be added to this object.
  - `[IdentityPrincipalId <String>]`: The principal ID of resource identity.
  - `[IdentityTenantId <String>]`: The tenant ID of resource.
  - `[IdentityType <ResourceIdentityType?>]`: The identity type.
  - `[IdentityUserAssignedIdentity <IIdentityPropertiesUserAssignedIdentities>]`: The list of user identities associated with the resource. The user identity         dictionary key references will be ARM resource ids in the form:         '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/             providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    - `[(Any) <IUserIdentityProperties>]`: This indicates any property can be added to this object.
  - `[IsSystemTask <Boolean?>]`: The value of this property indicates whether the task resource is system task or not.
  - `[LogTemplate <String>]`: The template that describes the repository and tag information for run log artifact.
  - `[PlatformArchitecture <Architecture?>]`: The OS architecture.
  - `[PlatformOS <OS?>]`: The operating system type required for the run.
  - `[PlatformVariant <Variant?>]`: Variant of the CPU.
  - `[SourceRegistryLoginMode <SourceRegistryLoginMode?>]`: The authentication mode which determines the source registry login scope. The credentials for the source registry         will be generated using the given scope. These credentials will be used to login to         the source registry during the run.
  - `[Status <TaskStatus?>]`: The current status of task.
  - `[StepContextAccessToken <String>]`: The token (git PAT or SAS token of storage account blob) associated with the context for a step.
  - `[StepContextPath <String>]`: The URL(absolute or relative) of the source context for the task step.
  - `[StepType <StepType?>]`: The type of the step.
  - `[Timeout <Int32?>]`: Run timeout in seconds.
  - `[TriggerSourceTrigger <ISourceTrigger[]>]`: The collection of triggers based on source code repository.
    - `Event <SourceTriggerEvent[]>`: The source event corresponding to the trigger.
    - `Name <String>`: The name of the trigger.
    - `SourceRepositorySourceControlType <SourceControlType>`: The type of source control service.
    - `SourceRepositoryUrl <String>`: The full URL to the source code repository
    - `[SourceControlAuthPropertyExpiresIn <Int32?>]`: Time in seconds that the token remains valid
    - `[SourceControlAuthPropertyRefreshToken <String>]`: The refresh token used to refresh the access token.
    - `[SourceControlAuthPropertyScope <String>]`: The scope of the access token.
    - `[SourceControlAuthPropertyToken <String>]`: The access token used to access the source control provider.
    - `[SourceControlAuthPropertyTokenType <TokenType?>]`: The type of Auth token.
    - `[SourceRepositoryBranch <String>]`: The branch name of the source code.
    - `[Status <TriggerStatus?>]`: The current status of trigger.
  - `[TriggerTimerTrigger <ITimerTrigger[]>]`: The collection of timer triggers.
    - `Name <String>`: The name of the trigger.
    - `Schedule <String>`: The CRON expression for the task schedule
    - `[Status <TriggerStatus?>]`: The current status of trigger.

`TRIGGERSOURCETRIGGER <ISourceTrigger[]>`: The collection of triggers based on source code repository.
  - `Event <SourceTriggerEvent[]>`: The source event corresponding to the trigger.
  - `Name <String>`: The name of the trigger.
  - `SourceRepositorySourceControlType <SourceControlType>`: The type of source control service.
  - `SourceRepositoryUrl <String>`: The full URL to the source code repository
  - `[SourceControlAuthPropertyExpiresIn <Int32?>]`: Time in seconds that the token remains valid
  - `[SourceControlAuthPropertyRefreshToken <String>]`: The refresh token used to refresh the access token.
  - `[SourceControlAuthPropertyScope <String>]`: The scope of the access token.
  - `[SourceControlAuthPropertyToken <String>]`: The access token used to access the source control provider.
  - `[SourceControlAuthPropertyTokenType <TokenType?>]`: The type of Auth token.
  - `[SourceRepositoryBranch <String>]`: The branch name of the source code.
  - `[Status <TriggerStatus?>]`: The current status of trigger.

`TRIGGERTIMERTRIGGER <ITimerTrigger[]>`: The collection of timer triggers.
  - `Name <String>`: The name of the trigger.
  - `Schedule <String>`: The CRON expression for the task schedule
  - `[Status <TriggerStatus?>]`: The current status of trigger.

## RELATED LINKS

