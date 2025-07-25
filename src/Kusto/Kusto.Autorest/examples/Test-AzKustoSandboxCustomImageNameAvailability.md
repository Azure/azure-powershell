### Example 1: Check the availability of a sandbox custom image name in a cluster
```powershell
Test-AzKustoSandboxCustomImageNameAvailability -ClusterName "myCluster" -ResourceGroupName "myResourceGroup" -Name "myImage"
```

```output
Message Name      NameAvailable Reason
------- ----      ------------- ------
        testimage True
```

The above command returns whether or not a sandbox custom image named "myImage" exists in the cluster named "myCluster".
