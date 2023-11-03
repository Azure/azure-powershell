### Example 1: List all sandbox custom images in a cluster
```powershell
Get-AzKustoSandboxCustomImage -ClusterName "myCluster" -ResourceGroupName "myResourceGroup"
```

```output
Name
----
myCluser/myImage
```

The above command returns all Kusto sandbox custom images in cluster "myCluster" and resource group "myResourceGroup".

### Example 2: Get a sandbox custom image by name in cluster
```powershell
Get-AzKustoSandboxCustomImage -ClusterName "myCluster" -Name "myImage" -ResourceGroupName "myResourceGroup"
```

```output
Name
----
myCluser/myImage
```

The above command returns a Kusto sandbox custom image named "myImage" in cluster "myCluster" and resource group "myResourceGroup".
