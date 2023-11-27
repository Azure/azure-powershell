---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/get-azfederatedidentitycredentials
schema: 2.0.0
---

# Get-AzFederatedIdentityCredentials

## SYNOPSIS
Gets the federated identity credential.

## SYNTAX

## DESCRIPTION
Gets the federated identity credential.

## EXAMPLES

### Example 1: List federated identity credentials under a user assigned identity
```powershell
Get-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01
```

```output
Name       Issuer                               Subject                               Audience
----       ------                               -------                               --------
fic-pwsh01 https://kubernetes-oauth.azure.com   system:serviceaccount:ns:svcaccount   {api://AzureADTokenExchange}
fic-pwsh02 https://kubernetes-oauth-2.azure.com system:serviceaccount-2:ns:svcaccount {api://AzureADTokenExchange}
```

This command lists federated identity credentials under a user assigned identity.

### Example 2: Get a federated identity credential
```powershell
Get-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01
```

```output
Name       Issuer                             Subject                             Audience
----       ------                             -------                             --------
fic-pwsh01 https://kubernetes-oauth.azure.com system:serviceaccount:ns:svcaccount {api://AzureADTokenExchange}
```

This command gets a federated identity credential by name.

### Example 3: Get a federated identity credential by pipeline
```powershell
New-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh03 -Issuer "https://kubernetes-oauth-3.azure.com" -Subject "system:serviceaccount-3:ns:svcaccount" `
        | Get-AzFederatedIdentityCredentials
```

```output
Name       Issuer                               Subject                               Audience
----       ------                               -------                               --------
fic-pwsh03 https://kubernetes-oauth-3.azure.com system:serviceaccount-3:ns:svcaccount {api://AzureADTokenExchange}
```

This command creates and gets a federated identity credential by pipeline.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IManagedServiceIdentity>`: Identity Parameter
  - `[FederatedIdentityCredentialResourceName <String>]`: The name of the federated identity credential resource.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the Resource Group to which the identity belongs.
  - `[ResourceName <String>]`: The name of the identity resource.
  - `[Scope <String>]`: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  - `[SubscriptionId <String>]`: The Id of the Subscription to which the identity belongs.

## RELATED LINKS
