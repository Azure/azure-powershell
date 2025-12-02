---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/new-azmlworkspaceenvironmentversion
schema: 2.0.0
---

# New-AzMLWorkspaceEnvironmentVersion

## SYNOPSIS
Create an EnvironmentVersion.

## SYNTAX

### CreateExpanded (Default)
```
New-AzMLWorkspaceEnvironmentVersion -Name <String> -ResourceGroupName <String> -Version <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-AutoRebuild <String>] [-BuildContextUri <String>]
 [-BuildDockerfilePath <String>] [-CondaFile <String>] [-Description <String>] [-Image <String>] [-IsAnonymou]
 [-IsArchived] [-LivenessRoutePath <String>] [-LivenessRoutePort <Int32>] [-OSType <String>]
 [-ReadinessRoutePath <String>] [-ReadinessRoutePort <Int32>] [-ResourceBaseProperty <Hashtable>]
 [-ScoringRoutePath <String>] [-ScoringRoutePort <Int32>] [-Stage <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityEnvironmentExpanded
```
New-AzMLWorkspaceEnvironmentVersion -EnvironmentInputObject <IMachineLearningServicesIdentity>
 -Version <String> [-AutoRebuild <String>] [-BuildContextUri <String>] [-BuildDockerfilePath <String>]
 [-CondaFile <String>] [-Description <String>] [-Image <String>] [-IsAnonymou] [-IsArchived]
 [-LivenessRoutePath <String>] [-LivenessRoutePort <Int32>] [-OSType <String>] [-ReadinessRoutePath <String>]
 [-ReadinessRoutePort <Int32>] [-ResourceBaseProperty <Hashtable>] [-ScoringRoutePath <String>]
 [-ScoringRoutePort <Int32>] [-Stage <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzMLWorkspaceEnvironmentVersion -Name <String> -Version <String>
 -WorkspaceInputObject <IMachineLearningServicesIdentity> [-AutoRebuild <String>] [-BuildContextUri <String>]
 [-BuildDockerfilePath <String>] [-CondaFile <String>] [-Description <String>] [-Image <String>] [-IsAnonymou]
 [-IsArchived] [-LivenessRoutePath <String>] [-LivenessRoutePort <Int32>] [-OSType <String>]
 [-ReadinessRoutePath <String>] [-ReadinessRoutePort <Int32>] [-ResourceBaseProperty <Hashtable>]
 [-ScoringRoutePath <String>] [-ScoringRoutePort <Int32>] [-Stage <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMLWorkspaceEnvironmentVersion -Name <String> -ResourceGroupName <String> -Version <String>
 -WorkspaceName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMLWorkspaceEnvironmentVersion -Name <String> -ResourceGroupName <String> -Version <String>
 -WorkspaceName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an EnvironmentVersion.

## EXAMPLES

### Example 1: Create or update an EnvironmentVersion.
```powershell
New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-test -WorkspaceName mlworkspace-test2 -Name commandjobenv -Version 1 -Image "library/python:latest"
```

```output
AutoRebuild                  : Disabled
BuildContextUri              : 
BuildDockerfilePath          : 
CondaFile                    : 
Description                  : 
EnvironmentType              : UserCreated
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/ml-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test2/environments/commandjobenv/versions/1
Image                        : library/python:latest
IsAnonymou                   : False
IsArchived                   : False
LivenessRoutePath            : 
LivenessRoutePort            : 0
Name                         : 1
OSType                       : Linux
ProvisioningState            : Succeeded
ReadinessRoutePath           : 
ReadinessRoutePort           : 0
ResourceBaseProperty         : {
                                 "azureml.labels": "latest"
                               }
ResourceGroupName            : ml-test
ScoringRoutePath             : 
ScoringRoutePort             : 0
Stage                        : Development
SystemDataCreatedAt          : 11/5/2025 9:40:49 AM
SystemDataCreatedBy          : User Name (Example)
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/5/2025 9:40:49 AM
SystemDataLastModifiedBy     : User Name (Example)
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : Microsoft.MachineLearningServices/workspaces/environments/versions
XmsAsyncOperationTimeout     : 
```

This command creates or updates an EnvironmentVersion.

## PARAMETERS

### -AutoRebuild
Defines if image needs to be rebuilt based on base image changes.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildContextUri
[Required] URI of the Docker build context used to build the image.
Supports blob URIs on environment creation and may return blob or Git URIs.\<seealso href="https://docs.docker.com/engine/reference/commandline/build/#extended-description" /\>

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildDockerfilePath
Path to the Dockerfile in the build context.\<seealso href="https://docs.docker.com/engine/reference/builder/" /\>

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CondaFile
Standard configuration file used by Conda that lets you install any kind of package, including Python, R, and C/C++ packages.\<see href="https://repo2docker.readthedocs.io/en/latest/config_files.html#environment-yml-install-a-conda-environment" /\>

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
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

### -Description
The asset description text.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: CreateViaIdentityEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Image
Name of the image that will be used for the environment.\<seealso href="https://docs.microsoft.com/en-us/azure/machine-learning/how-to-deploy-custom-docker-image#use-a-custom-base-image" /\>

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAnonymou
If the name version are system generated (anonymous registration).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsArchived
Is the asset archived?

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -LivenessRoutePath
[Required] The path for the route.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessRoutePort
[Required] The port for the route.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of EnvironmentVersion.
This is case-sensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
The OS type of the environment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessRoutePath
[Required] The path for the route.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessRoutePort
[Required] The port for the route.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceBaseProperty
The asset property dictionary.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
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

### -ScoringRoutePath
[Required] The path for the route.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScoringRoutePort
[Required] The port for the route.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stage
Stage in the environment lifecycle assigned to this environment

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
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
Tag dictionary.
Tags can be added, removed, and updated.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of EnvironmentVersion.

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

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: CreateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IEnvironmentVersion

## NOTES

## RELATED LINKS

