### Example 1: List the external auths on a cluster
```powershell
Get-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… Succeeded
```

Lists every `ExternalAuth` configured on the cluster. A cluster typically has a single external auth that configures the external OIDC identity provider.

### Example 2: Get a single external auth by name
```powershell
Get-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… Succeeded
```

Reads a single external auth by name. The returned object also exposes `.IssuerAudience`, `.ClientProfile`, and the claim-mapping fields (`.ClaimMappingUsernameClaim`, `.ClaimMappingGroupClaim`) for inspecting the full OIDC configuration.
