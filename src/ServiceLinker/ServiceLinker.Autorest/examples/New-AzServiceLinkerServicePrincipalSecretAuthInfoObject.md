### Example 1: Create AuthInfo of service principal secret type
```powershell
New-AzServiceLinkerServicePrincipalSecretAuthInfoObject -ClientId 00000000-0000-0000-0000-000000000000 -PrincipalId 00000000-0000-0000-0000-000000000000 -Secret secret
```

```output

AuthType               ClientId                             PrincipalId
--------               --------                             -----------
servicePrincipalSecret 00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-00…

```

Create AuthInfo of service principal secret type
