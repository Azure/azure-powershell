### Example 1: List the specified Certificate.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp
```

```output
Name             Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----             --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert    canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
azps-env-cert-02 canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

List the specified Certificate.

### Example 2: Get the specified Certificate.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert
```

```output
Name          Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

Get the specified Certificate.