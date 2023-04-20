### Example 1: Regenerate a login credential for a container registry
```powershell
Update-AzContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -PasswordName Password
```

```output
Username            Password  Password2
--------            --------  ---------
RegistryExample     xxxxxxxxx xxxxxxxxx
```

This command regenerates a login credential for the specified container registry.
Admin user has to be enabled for the container registry \`MyRegistry\` to regenerate login credentials.

