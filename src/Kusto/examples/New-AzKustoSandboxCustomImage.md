### Example 1: Create a sandbox custom image

```powershell
New-AzKustoSandboxCustomImage -ClusterName "myCluster" -Name "myImage" -ResourceGroupName "myResourceGroup" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -LanguageVersion "3.9.7" -RequirementsFileContent "Pillow"
```

```output
Name
----
myCluster/myImage
```

The above command creates a custom image named "myImage" in the resource group "myResourceGroup" in the subscription "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" based on the cluster "myCluster" with the language version "3.9.7" and the requirements file content "Pillow".