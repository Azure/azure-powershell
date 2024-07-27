### Example 1: Set up an image registry credential to create a container group
```powershell
$pwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password $pwd
```

```output
Password          Server       Username
--------          ------       --------
****** myserver.com username
```

This command sets up an image registry credential to create a container group