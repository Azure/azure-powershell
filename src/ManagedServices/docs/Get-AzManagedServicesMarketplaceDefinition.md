---
external help file:
Module Name: Az.ManagedServices
online version: https://docs.microsoft.com/powershell/module/az.managedservices/get-azmanagedservicesmarketplacedefinition
schema: 2.0.0
---

# Get-AzManagedServicesMarketplaceDefinition

## SYNOPSIS
Get the marketplace registration definition for the marketplace identifier.

## SYNTAX

### ListWithScope (Default)
```
Get-AzManagedServicesMarketplaceDefinition [-Scope <String>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzManagedServicesMarketplaceDefinition -InputObject <IManagedServicesIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetWithoutScope
```
Get-AzManagedServicesMarketplaceDefinition -MarketplaceIdentifier <String> -Tenant
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetWithScope
```
Get-AzManagedServicesMarketplaceDefinition -MarketplaceIdentifier <String> [-Scope <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListWithoutScope
```
Get-AzManagedServicesMarketplaceDefinition -Tenant [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the marketplace registration definition for the marketplace identifier.

## EXAMPLES

### Example 1: Get the Azure Lighthouse Marketplace registration definition offer details
```powershell
Get-AzManagedServicesMarketplaceDefinition -MarketplaceIdentifier marketplace_test.managed_offer.managed_plan1.1.0.1 | Format-List Id, PlanProduct, PlanPublisher, PlanName, PlanVersion
```

```output
Id            : /providers/Microsoft.ManagedServices/marketplaceRegistrationDefinitions/marketplace_test.managed_offer.managed_plan1.1.0.1
PlanProduct   : managed_offer
PlanPublisher : marketplace_test
PlanName      : managed_plan1
PlanVersion   : 1.0.1
```

Gets the Azure Lighthouse Marketplace registration definition offer details.

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

### -Filter
The filter query parameter to filter marketplace registration definitions by plan identifier, publisher, version etc.

```yaml
Type: System.String
Parameter Sets: ListWithoutScope, ListWithScope
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.IManagedServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MarketplaceIdentifier
The Azure Marketplace identifier.
Expected formats: {publisher}.{product[-preview]}.{planName}.{version} or {publisher}.{product[-preview]}.{planName} or {publisher}.{product[-preview]} or {publisher}).

```yaml
Type: System.String
Parameter Sets: GetWithoutScope, GetWithScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the resource.

```yaml
Type: System.String
Parameter Sets: GetWithScope, ListWithScope
Aliases:

Required: False
Position: Named
Default value: "subscriptions/" + (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tenant
The filter query parameter to filter marketplace registration definitions by plan identifier, publisher, version etc.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetWithoutScope, ListWithoutScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.IManagedServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IMarketplaceRegistrationDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IManagedServicesIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MarketplaceIdentifier <String>]`: The Azure Marketplace identifier. Expected formats: {publisher}.{product[-preview]}.{planName}.{version} or {publisher}.{product[-preview]}.{planName} or {publisher}.{product[-preview]} or {publisher}).
  - `[RegistrationAssignmentId <String>]`: The GUID of the registration assignment.
  - `[RegistrationDefinitionId <String>]`: The GUID of the registration definition.
  - `[Scope <String>]`: The scope of the resource.

## RELATED LINKS

