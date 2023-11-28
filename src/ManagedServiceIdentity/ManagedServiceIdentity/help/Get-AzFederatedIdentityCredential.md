---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/get-azfederatedidentitycredential
schema: 2.0.0
---

# Get-AzFederatedIdentityCredential

## SYNOPSIS
Gets the federated identity credential.

## SYNTAX

### List (Default)
```
Get-AzFederatedIdentityCredential -IdentityName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Skiptoken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFederatedIdentityCredential -InputObject <IManagedServiceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the federated identity credential.

## EXAMPLES

### EXAMPLE 1
```
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01
```

### EXAMPLE 2
```
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01
```

### EXAMPLE 3
```
New-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh03 -Issuer "https://kubernetes-oauth-3.azure.com" -Subject "system:serviceaccount-3:ns:svcaccount" `
        | Get-AzFederatedIdentityCredential
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
Type: String
Parameter Sets: List, Get
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
Type: IManagedServiceIdentity
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
Type: String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: List, Get
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
Type: String
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
Type: String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Number of records to return.

```yaml
Type: Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IManagedServiceIdentity\>: Identity Parameter
  \[FederatedIdentityCredentialResourceName \<String\>\]: The name of the federated identity credential resource.
  \[Id \<String\>\]: Resource identity path
  \[ResourceGroupName \<String\>\]: The name of the Resource Group to which the identity belongs.
  \[ResourceName \<String\>\]: The name of the identity resource.
  \[Scope \<String\>\]: The resource provider scope of the resource.
Parent resource being extended by Managed Identities.
  \[SubscriptionId \<String\>\]: The Id of the Subscription to which the identity belongs.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managedserviceidentity/get-azfederatedidentitycredential](https://learn.microsoft.com/powershell/module/az.managedserviceidentity/get-azfederatedidentitycredential)

