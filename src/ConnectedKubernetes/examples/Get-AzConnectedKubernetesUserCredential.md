### Example 1: Gets cluster user credentials of the connected cluster with a specified resource group and name.
```powershell
PS C:\> Get-AzConnectedKubernetesUserCredential -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -AuthenticationMethod AAD -ClientProxy

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
PS C:\> Get-AzConnectedKubernetesUserCredential -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -AuthenticationMethod Token -ClientProxy:$false

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