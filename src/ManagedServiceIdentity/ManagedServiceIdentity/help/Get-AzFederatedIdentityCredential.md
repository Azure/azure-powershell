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
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFederatedIdentityCredential -InputObject <IManagedServiceIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the federated identity credential.

## EXAMPLES

### Example 1: List federated identity credentials under a user assigned identity
```powershell
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01
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
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01
```

```output
Name       Issuer                             Subject                             Audience
----       ------                             -------                             --------
fic-pwsh01 https://kubernetes-oauth.azure.com system:serviceaccount:ns:svcaccount {api://AzureADTokenExchange}
```

This command gets a federated identity credential by name.

### Example 3: Get a federated identity credential by pipeline
```powershell
New-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 `
    -Name fic-pwsh03 -Issuer "https://kubernetes-oauth-3.azure.com" -Subject "system:serviceaccount-3:ns:svcaccount" `
        | Get-AzFederatedIdentityCredential
```

```output
Name       Issuer                               Subject                               Audience
----       ------                               -------                               --------
fic-pwsh03 https://kubernetes-oauth-3.azure.com system:serviceaccount-3:ns:svcaccount {api://AzureADTokenExchange}
```

This command creates and gets a federated identity credential by pipeline.

## PARAMETERS

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20230131.IFederatedIdentityCredential

## NOTES

ALIASES

Get-AzFederatedIdentityCredentials

## RELATED LINKS
