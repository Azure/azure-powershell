---
external help file:
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/update-azfederatedidentitycredential
schema: 2.0.0
---

# Update-AzFederatedIdentityCredential

## SYNOPSIS
update a federated identity credential under the specified user assigned identity.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Audience <String[]>] [-Issuer <String>] [-Subject <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFederatedIdentityCredential -InputObject <IManagedServiceIdentity> [-Audience <String[]>]
 [-Issuer <String>] [-Subject <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityUserAssignedIdentity
```
Update-AzFederatedIdentityCredential -Name <String> -UserAssignedIdentityInputObject <IManagedServiceIdentity>
 -Parameter <IFederatedIdentityCredential> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityUserAssignedIdentityExpanded
```
Update-AzFederatedIdentityCredential -Name <String> -UserAssignedIdentityInputObject <IManagedServiceIdentity>
 [-Audience <String[]>] [-Issuer <String>] [-Subject <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityUserAssignedIdentityExpanded1
```
Update-AzFederatedIdentityCredential -Name <String> -UserAssignedIdentityInputObject <IManagedServiceIdentity>
 [-Audience <String[]>] [-Issuer <String>] [-Subject <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath1
```
Update-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString1
```
Update-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
update a federated identity credential under the specified user assigned identity.

## EXAMPLES

### Example 1: Update federated identity credential under the specified user assigned identity
```powershell
Update-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
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
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01 `
    | Update-AzFederatedIdentityCredential -Issuer "https://kubernetes-oauth-upd.azure.com" -Subject "system:serviceaccount-upd:ns:svcaccount"
```

```output
Name       Issuer                                 Subject                                 Audience
----       ------                                 -------                                 --------
fic-pwsh01 https://kubernetes-oauth-upd.azure.com system:serviceaccount-upd:ns:svcaccount {api://AzureADTokenExchange}
```

This command updates a federated identity credential under the specified user assigned identity by pipeline.

## PARAMETERS

### -Audience
The list of audiences that can appear in the issued token.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: @("api://AzureADTokenExchange")
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath, UpdateViaJsonFilePath1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the federated identity credential resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityUserAssignedIdentity, UpdateViaIdentityUserAssignedIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded1, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Describes a federated identity credential.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IFederatedIdentityCredential
Parameter Sets: UpdateViaIdentityUserAssignedIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded1
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity
Parameter Sets: UpdateViaIdentityUserAssignedIdentity, UpdateViaIdentityUserAssignedIdentityExpanded, UpdateViaIdentityUserAssignedIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IFederatedIdentityCredential

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IFederatedIdentityCredential

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IFederatedIdentityCredentialAutoGenerated

## NOTES

ALIASES

Update-AzFederatedIdentityCredentials

## RELATED LINKS

