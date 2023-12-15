### Example 1: Remove a sandbox custom image
```powershell
Remove-AzKustoSandboxCustomImage -ClusterName "myCluster" -Name "myImage" -ResourceGroupName "myResourceGroup"
```

The above command removes the sandbox custom image named "myImage" from the cluster named "myCluster" in the resource group named "myResourceGroup".