---
external help file:
Module Name: Az.ConnectedKubernetes
online version: https://learn.microsoft.com/powershell/module/az.connectedkubernetes/update-azconnectedkubernetes
schema: 2.0.0
---

# Update-AzConnectedKubernetes

## SYNOPSIS
API to update certain properties of the connected cluster resource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedKubernetes -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AcceptEULA] [-AzureHybridBenefit <AzureHybridBenefit>] [-Distribution <String>]
 [-DistributionVersion <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedKubernetes -InputObject <IConnectedKubernetesIdentity> [-AcceptEULA]
 [-AzureHybridBenefit <AzureHybridBenefit>] [-Distribution <String>] [-DistributionVersion <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API to update certain properties of the connected cluster resource

## EXAMPLES

### Example 1: Update a connected kubernetes.
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -Tag @{'key'='1'}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command updates a connected kubernetes.

### Example 2: Update a connected kubernetes by object.
```powershell
Get-AzConnectedKubernetes -ClusterName azps_test_cluster -ResourceGroupName azps_test_group | Update-AzConnectedKubernetes -Tag @{'key'='2'}
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps_test_cluster azps_test_group
```

This command updates a connected kubernetes by object.

### Example 3: Update a ConnectedKubernetes's AzureHybridBenefit.
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Tag @{'key'='1'} -AzureHybridBenefit 'True'
```

```output
I confirm I have an eligible Windows Server license with Azure Hybrid Benefit to apply this benefit to AKS on Azure Stack HCI or Windows Server. Visit https://aka.ms/ahb-aks for details.
[Y] Yes  [N] No  (default is "N"): y

Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

Update a ConnectedKubernetes's AzureHybridBenefit.

### Example 4: Using [-AcceptEULA] will default to your acceptance of the terms of our legal agreement and update a ConnectedKubernetes's AzureHybridBenefit.
```powershell
Update-AzConnectedKubernetes -ClusterName azps_test_cluster_ahb -ResourceGroupName azps_test_group -Tag @{'key'='1'} -AzureHybridBenefit 'True' -AcceptEULA
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps_test_cluster_ahb azps_test_group
```

Using [-AcceptEULA] will default to your acceptance of the terms of our legal agreement and update a ConnectedKubernetes's AzureHybridBenefit.

## PARAMETERS

### -AcceptEULA
Accept EULA of ConnectedKubernetes, legal term will pop up without this parameter provided

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

### -AzureHybridBenefit
Indicates whether Azure Hybrid Benefit is opted in

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.AzureHybridBenefit
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Kubernetes cluster on which get is called.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: Name

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

### -Distribution
Represents the distribution of the connected cluster

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

### -DistributionVersion
Represents the Kubernetes distribution version on this connected cluster.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedKubernetesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.IConnectedKubernetesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.IConnectedCluster

## NOTES

## RELATED LINKS

