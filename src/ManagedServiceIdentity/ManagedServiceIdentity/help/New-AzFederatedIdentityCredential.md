---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/new-azfederatedidentitycredential
schema: 2.0.0
---

# New-AzFederatedIdentityCredential

## SYNOPSIS
Create or update a federated identity credential under the specified user assigned identity.

## SYNTAX

```
New-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Audience <String[]>] [-Issuer <String>] [-Subject <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a federated identity credential under the specified user assigned identity.

## EXAMPLES

### EXAMPLE 1
```
New-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth.azure.com" -Subject "system:serviceaccount:ns:svcaccount"
```

### EXAMPLE 2
```
New-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth.azure.com" -Subject "system:serviceaccount:ns:svcaccount" `
    -Audience @("api://AzureADTokenExchange-Modified")
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managedserviceidentity/new-azfederatedidentitycredential](https://learn.microsoft.com/powershell/module/az.managedserviceidentity/new-azfederatedidentitycredential)

