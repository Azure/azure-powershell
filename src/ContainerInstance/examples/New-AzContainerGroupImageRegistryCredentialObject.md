### Example 1: Set up an image registry credential to create a container group
```powershell
New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password (ConvertTo-SecureString "******" -AsPlainText -Force) 
```

```output
Password          Server       Username
--------          ------       --------
****** myserver.com username
```

This command sets up an image registry credential to create a container group