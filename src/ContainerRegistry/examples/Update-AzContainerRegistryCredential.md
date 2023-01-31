### Example 1: Regenerate a login credential for a container registry
```powershell
 $Cred =  Update-AzContainerRegistryCredential  -ResourceGroupName "MyResourceGroup" -Name "password" -RegistryName "RegistryExample"
 $Cred.Password
```

```output
Name      Value
----      -----
password  XCzduYWqL05cO3k5BPBHH76GnBJRXJ0UmnWkdJRBKm+ACRBYty1E
password2 IfkrXWliroUg/FjVr5is+cY0XwF3yLFUonxCvh+VH++ACRCNkmdo
```

This command regenerates a login credential for the specified container registry. Admin user has to be enabled for the container registry `RegistryExample` to regenerate login credentials.
