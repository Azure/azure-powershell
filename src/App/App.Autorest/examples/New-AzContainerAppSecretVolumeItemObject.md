### Example 1: Create an in-memory object for SecretVolumeItem.
```powershell
New-AzContainerAppSecretVolumeItemObject -Path "secretVolumePath" -SecretRef "redis-secret"
```

```output
Path             SecretRef
----             ---------
secretVolumePath redis-secret
```

Create an in-memory object for SecretVolumeItem.