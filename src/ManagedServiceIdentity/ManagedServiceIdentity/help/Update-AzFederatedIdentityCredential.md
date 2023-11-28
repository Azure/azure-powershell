---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/update-azfederatedidentitycredential
schema: 2.0.0
---

# Update-AzFederatedIdentityCredential

## SYNOPSIS
Create or update a federated identity credential under the specified user assigned identity.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Audience <String[]>] [-Issuer <String>] [-Subject <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFederatedIdentityCredential -InputObject <IManagedServiceIdentity> [-Audience <String[]>]
 [-Issuer <String>] [-Subject <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a federated identity credential under the specified user assigned identity.

## EXAMPLES

### EXAMPLE 1
```
Update-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

### EXAMPLE 2
```
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01 `
    | Update-AzFederatedIdentityCredential -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

## PARAMETERS

### -Audience
The list of audiences that can appear in the issued token.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Issuer
The URL of the issuer to be trusted.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the federated identity credential resource.

```yaml
Type: String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subject
The identifier of the external identity.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

[https://learn.microsoft.com/powershell/module/az.managedserviceidentity/update-azfederatedidentitycredential](https://learn.microsoft.com/powershell/module/az.managedserviceidentity/update-azfederatedidentitycredential)

