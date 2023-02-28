---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspacePipelineJobObject
schema: 2.0.0
---

# New-AzMLWorkspacePipelineJobObject

## SYNOPSIS
Create an in-memory object for PipelineJob.

## SYNTAX

```
New-AzMLWorkspacePipelineJobObject [-ComputeId <String>] [-Description <String>] [-DisplayName <String>]
 [-ExperimentName <String>] [-IdentityType <IdentityConfigurationType>] [-IsArchived <Boolean>]
 [-Job <IPipelineJobJobs>] [-JobInput <IPipelineJobInputs>] [-JobOutput <IPipelineJobOutputs>]
 [-Property <IResourceBaseProperties>] [-ServiceEndpoint <String>] [-ServicePort <Int32>]
 [-ServiceProperty <IJobServiceProperties>] [-ServiceType <String>] [-Setting <IAny>]
 [-Tag <IResourceBaseTags>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PipelineJob.

## EXAMPLES

### Example 1: Create an in-memory object for PipelineJob
```powershell
# You can use following commands to create job input or job oupt as vaule pass to JobInput or JobOutput parameter of the  New-AzMLWorkspacePipelineJobObject

# New-AzMLWorkspaceCustomModelJobInputObject
# New-AzMLWorkspaceCustomModelJobOutputObject
# New-AzMLWorkspaceLiteralJobInputObject
# New-AzMLWorkspaceMLFlowModelJobInputObject
# New-AzMLWorkspaceMLFlowModelJobOutputObject
# New-AzMLWorkspaceMLTableJobInputObject
# New-AzMLWorkspaceMLTableJobOutputObject
# New-AzMLWorkspaceSharedPrivateLinkResourceObject
# New-AzMLWorkspaceTritonModelJobInputObject
# New-AzMLWorkspaceTritonModelJobOutputObject
# New-AzMLWorkspaceUriFileJobInputObject
# New-AzMLWorkspaceUriFileJobOutputObject
# New-AzMLWorkspaceUriFolderJobInputObject
# New-AzMLWorkspaceUriFolderJobOutputObject

New-AzMLWorkspacePipelineJobObject
```

Create an in-memory object for PipelineJob

## PARAMETERS

### -ComputeId
ARM resource ID of the compute resource.

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

### -DisplayName
Display name of job.

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

### -ExperimentName
The name of the experiment the job belongs to.
If not set, the job is placed in the "Default" experiment.

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

### -IdentityType
[Required] Specifies the type of identity framework.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.IdentityConfigurationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsArchived
Is the asset archived?.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Job
Jobs construct the Pipeline Job.
To construct, see NOTES section for JOB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IPipelineJobJobs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobInput
Inputs for the pipeline job.
To construct, see NOTES section for JOBINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IPipelineJobInputs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobOutput
Outputs for the pipeline job.
To construct, see NOTES section for JOBOUTPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IPipelineJobOutputs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
The asset property dictionary.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IResourceBaseProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceEndpoint
Url for endpoint.

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

### -ServicePort
Port for endpoint.

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

### -ServiceProperty
Additional properties to set on the endpoint.
To construct, see NOTES section for SERVICEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IJobServiceProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceType
Endpoint type.

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

### -Setting
Pipeline settings, for things like ContinueRunOnStepFailure etc.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Tag dictionary.
Tags can be added, removed, and updated.
To construct, see NOTES section for TAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IResourceBaseTags
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.PipelineJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`JOB <IPipelineJobJobs>`: Jobs construct the Pipeline Job.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.

`JOBINPUT <IPipelineJobInputs>`: Inputs for the pipeline job.
  - `[(Any) <IJobInput>]`: This indicates any property can be added to this object.

`JOBOUTPUT <IPipelineJobOutputs>`: Outputs for the pipeline job.
  - `[(Any) <IJobOutput>]`: This indicates any property can be added to this object.

`PROPERTY <IResourceBaseProperties>`: The asset property dictionary.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`SERVICEPROPERTY <IJobServiceProperties>`: Additional properties to set on the endpoint.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`TAG <IResourceBaseTags>`: Tag dictionary. Tags can be added, removed, and updated.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

