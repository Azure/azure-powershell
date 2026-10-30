### Example 1: Create an external auth trusting Microsoft Entra ID
```powershell
$clientProfile = @(
    @{
        ComponentName                = 'console'
        ComponentAuthClientNamespace = 'openshift-console'
        ClientId                     = 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
        Type                         = 'Confidential'
    }
)

New-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth `
  -IssuerUrl 'https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/v2.0' `
  -IssuerAudience @('xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx') `
  -ClientProfile $clientProfile -UsernameClaim 'email' -GroupClaim 'groups'
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… AwaitingSecret
```

Creates an `ExternalAuth` that points the cluster's kube-apiserver at the given Entra OIDC issuer and maps the `email`/`groups` token claims to users and groups. The OpenShift web console (`console`/`openshift-console`) must be a `Confidential` client, so the resource provisions to `AwaitingSecret` until its client secret is supplied in-cluster.

### Example 2: Create an external auth with both a console and a CLI client
```powershell
$clientProfile = @(
    @{
        ComponentName                = 'console'
        ComponentAuthClientNamespace = 'openshift-console'
        ClientId                     = 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
        Type                         = 'Confidential'
    },
    @{
        ComponentName                = 'cli'
        ComponentAuthClientNamespace = 'openshift-console'
        ClientId                     = 'yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy'
        Type                         = 'Public'
    }
)

New-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth `
  -IssuerUrl 'https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/v2.0' `
  -IssuerAudience @('xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx','yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy') `
  -ClientProfile $clientProfile -UsernameClaim 'email' -GroupClaim 'groups'
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… AwaitingSecret
```

Registers two OIDC clients on the same external auth: the web console as a `Confidential` client and the `oc` CLI as a `Public` (PKCE) client. Each `ClientId` must also appear in `-IssuerAudience`. The Confidential console client leaves the resource in `AwaitingSecret` until its secret is provided in-cluster.
