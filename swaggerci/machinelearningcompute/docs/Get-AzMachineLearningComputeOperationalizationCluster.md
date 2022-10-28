---
external help file:
Module Name: Az.MachineLearningCompute
online version: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningcompute/get-azmachinelearningcomputeoperationalizationcluster
schema: 2.0.0
---

# Get-AzMachineLearningComputeOperationalizationCluster

## SYNOPSIS
Gets the operationalization cluster resource view.
Note that the credentials are not returned by this call.
Call ListKeys to get them.

## SYNTAX

### List1 (Default)
```
Get-AzMachineLearningComputeOperationalizationCluster [-SubscriptionId <String[]>] [-Skiptoken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMachineLearningComputeOperationalizationCluster -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMachineLearningComputeOperationalizationCluster -InputObject <IMachineLearningComputeIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzMachineLearningComputeOperationalizationCluster -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Skiptoken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the operationalization cluster resource view.
Note that the credentials are not returned by this call.
Call ListKeys to get them.

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

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Models.IMachineLearningComputeIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group in which the cluster is located.

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

### -Skiptoken
Continuation token for pagination.

```yaml
Type: System.String
Parameter Sets: List, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Models.IMachineLearningComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningCompute.Models.Api20170801Preview.IOperationalizationCluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IMachineLearningComputeIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the cluster.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: Name of the resource group in which the cluster is located.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

## RELATED LINKS

