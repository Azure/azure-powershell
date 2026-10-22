### Example 1: Change the username claim mapping
```powershell
Update-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth `
  -UsernameClaim 'preferred_username'
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… AwaitingSecret
```

Patches the existing external auth so the cluster maps the `preferred_username` token claim (instead of `email`) to the Kubernetes username. The Confidential console client keeps the resource in `AwaitingSecret` until its in-cluster secret is supplied.
