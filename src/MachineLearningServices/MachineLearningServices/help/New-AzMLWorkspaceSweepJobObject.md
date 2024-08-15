---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceSweepJobObject
schema: 2.0.0
---

# New-AzMLWorkspaceSweepJobObject

## SYNOPSIS
Create an in-memory object for SweepJob.

## SYNTAX

```
New-AzMLWorkspaceSweepJobObject -ObjectiveGoal <Goal> -ObjectivePrimaryMetric <String>
 -SamplingAlgorithmType <SamplingAlgorithmType> -SearchSpace <IAny> -TrialCommand <String>
 -TrialEnvironmentId <String> [-DistributionType <DistributionType>] [-EarlyTerminationDelayEvaluation <Int32>]
 [-EarlyTerminationEvaluationInterval <Int32>] [-EarlyTerminationPolicyType <EarlyTerminationPolicyType>]
 [-JobInput <ISweepJobInputs>] [-LimitMaxConcurrentTrial <Int32>] [-LimitMaxTotalTrial <Int32>]
 [-LimitTimeout <TimeSpan>] [-LimitTrialTimeout <TimeSpan>] [-JobOutput <ISweepJobOutputs>]
 [-ResourceInstanceCount <Int32>] [-ResourceInstanceType <String>]
 [-ResourceProperty <IResourceConfigurationProperties>] [-TrialCodeId <String>]
 [-TrialEnvironmentVariable <ITrialComponentEnvironmentVariables>] [-ComputeId <String>]
 [-DisplayName <String>] [-ExperimentName <String>] [-IdentityType <IdentityConfigurationType>]
 [-IsArchived <Boolean>] [-ServiceEndpoint <String>] [-ServicePort <Int32>]
 [-ServiceProperty <IJobServiceProperties>] [-ServiceType <String>] [-Description <String>]
 [-Property <IResourceBaseProperties>] [-Tag <IResourceBaseTags>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SweepJob.

## EXAMPLES

### Example 1: Create an in-memory object for SweepJob
```powershell
# You can use following commands to create job input or job output as value pass to JobInput or JobOutput parameter of the New-AzMLWorkspaceSweepJobObject

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

New-AzMLWorkspaceSweepJobObject
```

Create an in-memory object for SweepJob

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

### -EarlyTerminationDelayEvaluation
Number of intervals by which to delay the first evaluation.

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

### -EarlyTerminationEvaluationInterval
Interval (number of runs) between policy evaluations.

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

### -EarlyTerminationPolicyType
[Required] Name of policy configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EarlyTerminationPolicyType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISweepJobInputs
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISweepJobOutputs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitMaxConcurrentTrial
Sweep Job max concurrent trials.

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

### -LimitMaxTotalTrial
Sweep Job max total trials.

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

### -LimitTrialTimeout
Sweep Job Trial timeout value.

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

### -ObjectiveGoal
[Required] Defines supported metric goals for hyperparameter tuning.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Goal
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectivePrimaryMetric
[Required] Name of the metric to optimize.

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

### -Property
The asset property dictionary.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseProperties
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceConfigurationProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SamplingAlgorithmType
[Required] The algorithm used for generating hyperparameter values, along with configuration properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SamplingAlgorithmType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchSpace
[Required] A dictionary containing each parameter and its distribution.
The dictionary key is the name of the parameter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny
Parameter Sets: (All)
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobServiceProperties
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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrialCodeId
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

### -TrialCommand
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

### -TrialEnvironmentId
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

### -TrialEnvironmentVariable
Environment variables included in the job.
To construct, see NOTES section for TRIALENVIRONMENTVARIABLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITrialComponentEnvironmentVariables
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SweepJob

## NOTES

## RELATED LINKS
