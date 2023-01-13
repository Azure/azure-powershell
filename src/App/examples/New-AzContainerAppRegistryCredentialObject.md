### Example 1: Create a RegistryCredentials object for ContainerApp.
```powershell
New-AzContainerAppRegistryCredentialObject -Identity system -PasswordSecretRef "myloginpassword" -Server azps-containerapp -Username azps-container-user
```

```output
Identity PasswordSecretRef Server            Username
-------- ----------------- ------            --------
system   myloginpassword   azps-containerapp azps-container-user
```

Create a RegistryCredentials object for ContainerApp.