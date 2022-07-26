---
external help file:
Module Name: Az.ConnectedKubernetes
online version: https://docs.microsoft.com/powershell/module/az.connectedkubernetes/get-azconnectedkubernetesusercredential
schema: 2.0.0
---

# Get-AzConnectedKubernetesUserCredential

## SYNOPSIS
Gets cluster user credentials of the connected cluster with a specified resource group and name.

## SYNTAX

### ListExpanded (Default)
```
Get-AzConnectedKubernetesUserCredential -ClusterName <String> -ResourceGroupName <String>
 -AuthenticationMethod <AuthenticationMethod> -ClientProxy [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzConnectedKubernetesUserCredential -ClusterName <String> -ResourceGroupName <String>
 -Property <IListClusterUserCredentialProperties> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
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
HybridConnectionConfigToken                : SharedAccessSignature sr=http%3A%2F%2Fazgnrelay-eastus-l1.servicebus.windows.net%2Fmicrosoft.kubernetes%2Fconnectedclusters%2F8d3bccced1f3ad1d0e01b03e87d1c8f8a312df7ff028e642512a7999542e46fc%2F1635497990523092736%2F&sig=wrukC6KAxVFb%2FmsdaTwSv3ChHo0hvTWjf5A80IZs2P4%3D&se=1635509390&skn=sender20211026
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

### -Property
.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20211001.IListClusterUserCredentialProperties
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20211001.IListClusterUserCredentialProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20211001.ICredentialResults

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


PROPERTY `<IListClusterUserCredentialProperties>`: .
  - `AuthenticationMethod <AuthenticationMethod>`: The mode of client authentication.
  - `ClientProxy <Boolean>`: Boolean value to indicate whether the request is for client side proxy or not

## RELATED LINKS

