---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/update-azfederatedidentitycredentials
schema: 2.0.0
---

# Update-AzFederatedIdentityCredentials

## SYNOPSIS
Create or update a federated identity credential under the specified user assigned identity.

## SYNTAX

## DESCRIPTION
Create or update a federated identity credential under the specified user assigned identity.

## EXAMPLES

### Example 1: Update federated identity credential under the specified user assigned identity
```powershell
Update-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

```output
Name       Issuer                                 Subject                                 Audience
----       ------                                 -------                                 --------
fic-pwsh01 https://kubernetes-oauth-upd.azure.com system:serviceaccount-upd:ns:svcaccount {api://AzureADTokenExchange}
```

This command updates a federated identity credential under the specified user assigned identity.

### Example 2: Update federated identity credential under the specified user assigned identity by pipeline
```powershell
Get-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01 `
    | Update-AzFederatedIdentityCredentials -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

```output
Name       Issuer                                 Subject                                 Audience
----       ------                                 -------                                 --------
fic-pwsh01 https://kubernetes-oauth-upd.azure.com system:serviceaccount-upd:ns:svcaccount {api://AzureADTokenExchange}
```

This command updates a federated identity credential under the specified user assigned identity by pipeline.

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
