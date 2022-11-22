---
external help file:
Module Name: Az.ManagedServiceIdentity
online version: https://docs.microsoft.com/powershell/module/az.managedserviceidentity/get-azfederatedidentitycredentials
schema: 2.0.0
---

# Get-AzFederatedIdentityCredentials

## SYNOPSIS
Gets the federated identity credential.

## SYNTAX

### List (Default)
```
Get-AzFederatedIdentityCredentials -IdentityName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Skiptoken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzFederatedIdentityCredentials -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFederatedIdentityCredentials -InputObject <IManagedServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityName
The name of the identity resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the federated identity credential resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Resource Group to which the identity belongs.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skiptoken
A skip token is used to continue retrieving items after an operation returns a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Id of the Subscription to which the identity belongs.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Number of records to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20220131Preview.IFederatedIdentityCredential

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

