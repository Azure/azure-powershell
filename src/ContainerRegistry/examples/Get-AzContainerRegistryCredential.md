### Example 1: Get the login credentials for a container registry
```powershell
 $Cred = Get-AzContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
 $Cred.Password
```

```output
Name      Value
----      -----
password  vLf7A2T5u/naoMbuvdwaRl8R90fRB8X+EV9qTctyMy+ACRCQOGqg
password2 IfkrXWliroUg/FjVr5is+cY0XwF3yLFUonxCvh+VH++ACRCNkmdo
```

This command gets the login credentials for the specified container registry. Admin user has to be enabled for the container registry `RegistryExample` to get login credentials.
