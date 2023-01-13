### Example 1: Patches a certificate.
```powershell
Update-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert -Tag @{"123"="abc"}
```

```output
Name          Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

Currently only patching of tags is supported.

### Example 2: Patches a certificate.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert | Update-AzContainerAppManagedEnvCert -Tag @{"123"="abc"}
```

```output
Name          Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

Currently only patching of tags is supported.