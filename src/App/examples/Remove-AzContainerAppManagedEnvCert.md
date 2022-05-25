### Example 1: Deletes the specified Certificate.
```powershell
Remove-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert-02
```

Deletes the specified Certificate.

### Example 2: Deletes the specified Certificate.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert-02 | Remove-AzContainerAppManagedEnvCert
```

Deletes the specified Certificate.