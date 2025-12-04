### Example 1: Create an in-memory object for KeySetUser.
```powershell
New-AzNetworkCloudKeySetUserObject -AzureUserName azureUserName -SshPublicKeyData "ssh-rsa-key" -Description "userDescription"
```

```output
AzureUserName Description
------------- -----------
azureUserName userDescription
```

Create an in-memory object for KeySetUser.
