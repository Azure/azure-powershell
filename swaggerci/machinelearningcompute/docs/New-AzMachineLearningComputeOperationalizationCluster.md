---
external help file:
Module Name: Az.MachineLearningCompute
online version: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningcompute/new-azmachinelearningcomputeoperationalizationcluster
schema: 2.0.0
---

# New-AzMachineLearningComputeOperationalizationCluster

## SYNOPSIS
Create or update an operationalization cluster.

## SYNTAX

```
New-AzMachineLearningComputeOperationalizationCluster -ClusterName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AppInsightResourceId <String>] [-ClusterType <ClusterType>]
 [-ContainerRegistryResourceId <String>] [-ContainerServiceAgentCount <Int32>]
 [-ContainerServiceAgentVMSize <AgentVMSizeTypes>] [-ContainerServiceMasterCount <Int32>]
 [-ContainerServiceOrchestratorType <OrchestratorType>] [-ContainerServiceSystemService <ISystemService[]>]
 [-Description <String>] [-GlobalServiceConfiguration <IGlobalServiceConfiguration>]
 [-ServicePrincipalClientId <String>] [-ServicePrincipalSecret <String>] [-StorageAccountResourceId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update an operationalization cluster.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AppInsightResourceId
ARM resource ID of the App Insights.

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

### -ClusterName
The name of the cluster.

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

### -ClusterType
The cluster type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Support.ClusterType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerRegistryResourceId
ARM resource ID of the Azure Container Registry used to store Docker images for web services in the cluster.
If not provided one will be created.
This cannot be changed once the cluster is created.

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

### -ContainerServiceAgentCount
The number of agent nodes in the Container Service.
This can be changed to scale the cluster.

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

### -ContainerServiceAgentVMSize
The Azure VM size of the agent VM nodes.
This cannot be changed once the cluster is created.
This list is non exhaustive; refer to https://docs.microsoft.com/en-us/azure/virtual-machines/windows/sizes for the possible VM sizes.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Support.AgentVMSizeTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerServiceMasterCount
The number of master nodes in the container service.

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

### -ContainerServiceOrchestratorType
Type of orchestrator.
It cannot be changed once the cluster is created.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Support.OrchestratorType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerServiceSystemService
The system services deployed to the cluster
To construct, see NOTES section for CONTAINERSERVICESYSTEMSERVICE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Models.Api20170801Preview.ISystemService[]
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
The description of the cluster.

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

### -GlobalServiceConfiguration
Contains global configuration for the web services in the cluster.
To construct, see NOTES section for GLOBALSERVICECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Models.Api20170801Preview.IGlobalServiceConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Specifies the location of the resource.

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

### -ResourceGroupName
Name of the resource group in which the cluster is located.

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

### -ServicePrincipalClientId
The service principal client ID

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

### -ServicePrincipalSecret
The service principal secret.
This is not returned in response of GET/PUT on the resource.
To see this please call listKeys.

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

### -StorageAccountResourceId
ARM resource ID of the Azure Storage Account to store CLI specific files.
If not provided one will be created.
This cannot be changed once the cluster is created.

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

### -SubscriptionId
The Azure subscription ID.

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
Contains resource tags defined as key/value pairs.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Models.Api20170801Preview.IOperationalizationCluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONTAINERSERVICESYSTEMSERVICE <ISystemService[]>`: The system services deployed to the cluster
  - `Type <SystemServiceType>`: The system service type

`GLOBALSERVICECONFIGURATION <IGlobalServiceConfiguration>`: Contains global configuration for the web services in the cluster.
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[AutoScaleMaxReplica <Int32?>]`: The maximum number of replicas for each service.
  - `[AutoScaleMinReplica <Int32?>]`: The minimum number of replicas for each service.
  - `[AutoScaleRefreshPeriodInSecond <Int32?>]`: Refresh period in seconds.
  - `[AutoScaleStatus <Status?>]`: If auto-scale is enabled for all services. Each service can turn it off individually.
  - `[AutoScaleTargetUtilization <Single?>]`: The target utilization.
  - `[Etag <String>]`: The configuration ETag for updates.
  - `[ServiceAuthPrimaryAuthKeyHash <String>]`: The primary auth key hash. This is not returned in response of GET/PUT on the resource.. To see this please call listKeys API.
  - `[ServiceAuthSecondaryAuthKeyHash <String>]`: The secondary auth key hash. This is not returned in response of GET/PUT on the resource.. To see this please call listKeys API.
  - `[SslCert <String>]`: The SSL cert data in PEM format.
  - `[SslCname <String>]`: The CName of the certificate.
  - `[SslKey <String>]`: The SSL key data in PEM format. This is not returned in response of GET/PUT on the resource. To see this please call listKeys API.
  - `[SslStatus <Status?>]`: SSL status. Allowed values are Enabled and Disabled.

## RELATED LINKS

