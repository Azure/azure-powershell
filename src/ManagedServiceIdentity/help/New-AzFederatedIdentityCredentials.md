---
external help file:
Module Name: Az.ManagedServiceIdentity
online version: https://docs.microsoft.com/powershell/module/az.managedserviceidentity/new-azfederatedidentitycredentials
schema: 2.0.0
---

# New-AzFederatedIdentityCredentials

## SYNOPSIS
Create or update a federated identity credential under the specified user assigned identity.

## SYNTAX

```
New-AzFederatedIdentityCredentials -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Audience <String[]>] [-Issuer <String>] [-Subject <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a federated identity credential under the specified user assigned identity.

## EXAMPLES

### Example 1: Create a federated identity credential under the specified user assigned identity
```powershell
New-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth.azure.com" -Subject "system:serviceaccount:ns:svcaccount"
```

```output
Name       Issuer                             Subject                             Audience
----       ------                             -------                             --------
fic-pwsh01 https://kubernetes-oauth.azure.com system:serviceaccount:ns:svcaccount {api://AzureADTokenExchange}
```

This command creates a federated identity credential under the specified user assigned identity.

### Example 2: Create a federated identity credential under the specified user assigned identity with 'Audience' override
```powershell
New-AzFederatedIdentityCredentials -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh01 -Issuer "https://kubernetes-oauth.azure.com" -Subject "system:serviceaccount:ns:svcaccount" `
    -Audience @("api://AzureADTokenExchange-Modified")
```

```output
Name       Issuer                             Subject                             Audience
----       ------                             -------                             --------
fic-pwsh01 https://kubernetes-oauth.azure.com system:serviceaccount:ns:svcaccount {api://AzureADTokenExchange}
```

This command creates a federated identity credential under the specified user assigned identity with the custom audience

## PARAMETERS

### -Audience
The list of audiences that can appear in the issued token.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: @("api://AzureADTokenExchange")
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: System.String
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
Type: System.String
Parameter Sets: (All)
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
Type: System.String
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20220131Preview.IFederatedIdentityCredential

## NOTES

ALIASES

## RELATED LINKS

