---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceCommandJobObject
schema: 2.0.0
---

# New-AzMLWorkspaceCommandJobObject

## SYNOPSIS
Create an in-memory object for CommandJob.

## SYNTAX

```
New-AzMLWorkspaceCommandJobObject -Command <String> -EnvironmentId <String> [-CodeId <String>]
 [-ComputeId <String>] [-Description <String>] [-DisplayName <String>] [-DistributionType <DistributionType>]
 [-EnvironmentVariable <Hashtable>] [-ExperimentName <String>] [-IdentityType <IdentityConfigurationType>]
 [-IsArchived <Boolean>] [-JobInput <ICommandJobInputs>] [-JobOutput <ICommandJobOutputs>]
 [-LimitTimeout <TimeSpan>] [-Property <IResourceBaseProperties>] [-ResourceInstanceCount <Int32>]
 [-ResourceInstanceType <String>] [-ResourceProperty <IResourceConfigurationProperties>]
 [-ServiceEndpoint <String>] [-ServicePort <Int32>] [-ServiceProperty <IJobServiceProperties>]
 [-ServiceType <String>] [-Tag <IResourceBaseTags>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CommandJob.

## EXAMPLES

### Example 1: Create an in-memory object for CommandJob
```powershell
# You can use following commands to create job input or job oupt as vaule pass to JobInput or JobOutput parameter of the  New-AzMLWorkspaceCommandJobObject

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

New-AzMLWorkspaceCommandJobObject -Command "echo `"hello world`"" `
-ComputeId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/computes/aml02' `
-EnvironmentId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/ml-rg-test/providers/Microsoft.MachineLearningServices/workspaces/mlworkspace-test01/environments/commandjobenv/versions/1'`
-DisplayName 'commandjob01' -ExperimentName 'commandjobexperiment'
```

Create an in-memory object for CommandJob.

## PARAMETERS

### -CodeId
ARM resource ID of the code asset.

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

### -Command
[Required] The command to execute on startup of the job.
eg.
"python train.py".

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

### -DistributionType
[Required] Specifies the type of distribution framework.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.DistributionType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentId
[Required] The ARM resource ID of the Environment specification for the job.

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

### -EnvironmentVariable
Environment variables included in the job.

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

### -JobInput
Mapping of input data bindings used in the job.
To construct, see NOTES section for JOBINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ICommandJobInputs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobOutput
Mapping of output data bindings used in the job.
To construct, see NOTES section for JOBOUTPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ICommandJobOutputs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitTimeout
The max run duration in ISO 8601 format, after which the job will be cancelled.
Only supports duration with precision as low as Seconds.

```yaml
Type: System.TimeSpan
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

### -ResourceInstanceCount
Optional number of instances or nodes used by the compute target.

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

### -ResourceInstanceType
Optional type of VM used as supported by the compute target.

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

### -ResourceProperty
Additional properties bag.
To construct, see NOTES section for RESOURCEPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IResourceConfigurationProperties
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.CommandJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`JOBINPUT <ICommandJobInputs>`: Mapping of input data bindings used in the job.
  - `[(Any) <IJobInput>]`: This indicates any property can be added to this object.

`JOBOUTPUT <ICommandJobOutputs>`: Mapping of output data bindings used in the job.
  - `[(Any) <IJobOutput>]`: This indicates any property can be added to this object.

`PROPERTY <IResourceBaseProperties>`: The asset property dictionary.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`RESOURCEPROPERTY <IResourceConfigurationProperties>`: Additional properties bag.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.

`SERVICEPROPERTY <IJobServiceProperties>`: Additional properties to set on the endpoint.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`TAG <IResourceBaseTags>`: Tag dictionary. Tags can be added, removed, and updated.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

