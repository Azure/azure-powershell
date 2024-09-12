---
external help file: Az.ConnectedKubernetes-help.xml
Module Name: Az.ConnectedKubernetes
online version: https://learn.microsoft.com/powershell/module/az.connectedkubernetes/get-azconnectedkubernetesusercredential
schema: 2.0.0
---

# Get-AzConnectedKubernetesUserCredential

## SYNOPSIS
Gets cluster user credentials of the connected cluster with a specified resource group and name.

## SYNTAX

### ListExpanded (Default)
```
Get-AzConnectedKubernetesUserCredential -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -AuthenticationMethod <AuthenticationMethod> [-ClientProxy]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List
```
Get-AzConnectedKubernetesUserCredential -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -Property <IListClusterUserCredentialProperties> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets cluster user credentials of the connected cluster with a specified resource group and name.

## EXAMPLES

### Example 1: Gets cluster user credentials of the connected cluster with a specified resource group and name.
```powershell
Get-AzConnectedKubernetesUserCredential -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -AuthenticationMethod AAD -ClientProxy
```

```output
HybridConnectionConfigExpirationTime       : 1635508790
HybridConnectionConfigHybridConnectionName : microsoft.kubernetes/connectedclusters/8d3bccced1f3ad1d0e01b03e87d1c8f8a312df7ff028e642512a7999542e46fc/1635497990523092736
HybridConnectionConfigRelay                : azgnrelay-eastus-l1
HybridConnectionConfigToken                : SharedAccessSignature sr=******
Kubeconfig                                 : {{
                                               "name": "KubeConfig",
                                               "value": "YXBpVm***G9wDQo="
                                             }}
```

Gets cluster user credentials of the connected cluster with a specified resource group and name.

### Example 2: Gets cluster user credentials of the connected cluster with a specified resource group and name.
```powershell
Get-AzConnectedKubernetesUserCredential -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -AuthenticationMethod Token -ClientProxy:$false
```

```output
HybridConnectionConfigExpirationTime       :
HybridConnectionConfigHybridConnectionName :
HybridConnectionConfigRelay                :
HybridConnectionConfigToken                :
Kubeconfig                                 : {{
                                               "name": "KubeConfig",
                                               "value": "YXBpVm***G9wDQo="
                                             }}
```

Gets cluster user credentials of the connected cluster with a specified resource group and name.

## PARAMETERS

### -AuthenticationMethod
The mode of client authentication.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.AuthenticationMethod
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientProxy
Boolean value to indicate whether the request is for client side proxy or not

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Kubernetes cluster on which get is called.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
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

### -Property
.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20221001Preview.IListClusterUserCredentialProperties
Parameter Sets: List
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
Parameter Sets: (All)
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
Type: System.String[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20221001Preview.IListClusterUserCredentialProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20221001Preview.ICredentialResults

## NOTES

## RELATED LINKS
