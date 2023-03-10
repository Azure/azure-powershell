### Example 1: Returns the cluster user credentials for the dedicated appliance.
```powershell
Get-AzArcResourceBridgeApplianceCredential -ResourceGroupName azps_test_group -Name azps-resource-bridge
```

```output
HybridConnectionConfigExpirationTime       : 1678424933
HybridConnectionConfigHybridConnectionName : microsoft.resourceconnector/appliances/bc2***a81fb98c/167***794176
HybridConnectionConfigRelay                : azgnrelay-ph0-l1
HybridConnectionConfigToken                : SharedAccessSignature***30308
Kubeconfig                                 : {{
                                               "name": "clusterUser",
                                               "value": "YXBpV***zZQo="
                                             }}
```

Returns the cluster user credentials for the dedicated appliance.