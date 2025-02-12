### Example 1: Update properties of a storage class of a connected cluster
```powershell
Update-AzKubernetesRuntimeStorageClass `
    -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 `
    -Name "default" `
    -TypePropertyAzureStorageAccountName "accountName"
```

Update the `typeProperties.azureStorageAccountName` property of the storage class of the connected cluster.


### Example 2: Update secret property of a storage class of a connected cluster
```powershell
Update-AzKubernetesRuntimeStorageClass `
    -ArcConnectedClusterId /subscriptions/00000000-1111-2222-3333-444444444444/resourceGroups/example/providers/Microsoft.Kubernetes/connectedClusters/cluster1 `
    -Name "default" `
    -TypePropertyAzureStorageAccountKey $(ConvertTo-SecureString 'accountKey' -AsPlainText)
```

Update the `typeProperties.azureStorageAccountKey` secure string property of the storage class of the connected cluster.
