---
external help file:
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubproviderregistration
schema: 2.0.0
---

# Get-AzProviderHubProviderRegistration

## SYNOPSIS
Gets the provider registration details.

## SYNTAX

### List (Default)
```
Get-AzProviderHubProviderRegistration [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzProviderHubProviderRegistration -ProviderNamespace <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzProviderHubProviderRegistration -InputObject <IProviderHubIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the provider registration details.

## EXAMPLES

### Example 1: Get the provider registration.
```powershell
Get-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso"
```

```output
Name                Type
----                ----
Microsoft.Contoso   Microsoft.ProviderHub/providerRegistrations
```

Get the provider registration.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

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

### -SubscriptionId
The ID of the target subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IProviderHubIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[NestedResourceTypeFirst <String>]`: The first child resource type.
  - `[NestedResourceTypeSecond <String>]`: The second child resource type.
  - `[NestedResourceTypeThird <String>]`: The third child resource type.
  - `[NotificationRegistrationName <String>]`: The notification registration.
  - `[ProviderNamespace <String>]`: The name of the resource provider hosted within ProviderHub.
  - `[ResourceType <String>]`: The resource type.
  - `[RolloutName <String>]`: The rollout name.
  - `[Sku <String>]`: The SKU.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

