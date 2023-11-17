---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/new-azmlworkspaceenvironmentversion
schema: 2.0.0
---

# New-AzMLWorkspaceEnvironmentVersion

## SYNOPSIS
Creates or updates an EnvironmentVersion.

## SYNTAX

```
New-AzMLWorkspaceEnvironmentVersion -Name <String> -ResourceGroupName <String> -Version <String>
 -WorkspaceName <String> [-SubscriptionId <String>] [-BuildContextUri <String>]
 [-BuildDockerfilePath <String>] [-CondaFile <String>] [-Description <String>] [-Image <String>] [-IsAnonymou]
 [-IsArchived] [-LivenessRoutePath <String>] [-LivenessRoutePort <Int32>] [-OSType <OperatingSystemType>]
 [-ReadinessRoutePath <String>] [-ReadinessRoutePort <Int32>] [-ResourceBaseProperty <Hashtable>]
 [-ScoringRoutePath <String>] [-ScoringRoutePort <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an EnvironmentVersion.

## EXAMPLES

### Example 1: Creates or updates an EnvironmentVersion.
```powershell
New-AzMLWorkspaceEnvironmentVersion -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-test01 -Name commandjobenv -Version 1 -Image "library/python:latest"
```

```output
Name SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy            SystemDataLastModifiedByType ResourceGroupName
---- -------------------  -------------------                 ----------------------- ------------------------ ------------------------            ---------------------------- -----------------
1    5/31/2022 8:28:35 AM Lucas Yao (Wicresoft North America) User                    5/31/2022 8:28:35 AM     Lucas Yao (Wicresoft North America) User                         ml-rg-test
```

Creates or updates an EnvironmentVersion.

## PARAMETERS

### -BuildContextUri
[Required] URI of the Docker build context used to build the image.
Supports blob URIs on environment creation and may return blob or Git URIs.\<seealso href="https://docs.docker.com/engine/reference/commandline/build/#extended-description" /\>

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
The asset description text.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
Name of the image that will be used for the environment.\<seealso href="https://learn.microsoft.com/en-us/azure/machine-learning/how-to-deploy-custom-docker-image#use-a-custom-base-image" /\>

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsArchived
Is the asset archived

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

### -LivenessRoutePath
[Required] The path for the route.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.OperatingSystemType
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEnvironmentVersion

## NOTES

ALIASES

## RELATED LINKS

