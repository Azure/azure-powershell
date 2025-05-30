# Upcoming breaking changes in Azure PowerShell

## Az.Blueprint

### `Export-AzBlueprintWithArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Get-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Get-AzBlueprintArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Get-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Import-AzBlueprintWithArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `New-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `New-AzBlueprintArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `New-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Publish-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Remove-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Set-AzBlueprint`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Set-AzBlueprintArtifact`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

### `Set-AzBlueprintAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - Blueprints and associated cmdlets will be deprecated as early as July 2026. Customers are encouraged to transition to Template Specs and Deployments Stacks to support their scenarios beyond that date. Migration documentation is available at https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/migrate-blueprint.
  - This change is expected to take effect from Az.Blueprint version: - and Az version: 16.0.0

## Az.Compute

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter sets
  - The default VM size will change from 'Standard_D2s_v3' to 'Standard_D2s_v5'.
  - This change is expected to take effect from Az.Compute version: 11.0.0 and Az version: 15.0.0

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - In the next breaking change period (Nov 2025), the default VM size will change from 'Standard_Ds1_v2' to 'Standard_D2s_v5'.
  - This change is expected to take effect from Az.Compute version: 11.0.0 and Az version: 15.0.0

## Az.ContainerInstance

### `New-AzContainerGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - This change will take effect on '5/21/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

### `New-AzContainerInstanceContainerGroupProfile`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - Change description : Removing the default value of OSType parameter. 
    - This change will take effect on '5/21/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

## Az.Maps

### `Get-AzMapsCreator`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.9.0'

### `New-AzMapsCreator`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '5/19/2025'- The change is expected to take effect from Az version : '14.0.0'
  - The change is expected to take effect from version : '0.9.0'

### `Update-AzMapsCreator`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.9.0'

## Az.MixedReality

### `Get-AzMixedRealityObjectAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Get-AzMixedRealityObjectAnchorsAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Get-AzMixedRealityRemoteRenderingAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Get-AzMixedRealityRemoteRenderingAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Get-AzMixedRealitySpatialAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Get-AzMixedRealitySpatialAnchorsAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `New-AzMixedRealityObjectAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `New-AzMixedRealityObjectAnchorsAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `New-AzMixedRealityRemoteRenderingAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `New-AzMixedRealityRemoteRenderingAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `New-AzMixedRealitySpatialAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `New-AzMixedRealitySpatialAnchorsAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Remove-AzMixedRealityObjectAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Remove-AzMixedRealityRemoteRenderingAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Remove-AzMixedRealitySpatialAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Test-AzMixedRealityNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Update-AzMixedRealityObjectAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Update-AzMixedRealityRemoteRenderingAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

### `Update-AzMixedRealitySpatialAnchorsAccount`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.3.0'

## Az.MobileNetwork

### `Deploy-AzMobileNetworkReinstallPacketCoreControlPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Deploy-AzMobileNetworkRollbackPacketCoreControlPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkAttachedDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkPacketCoreControlPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkPacketCoreControlPlaneVersion`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkPacketCoreDataPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkSim`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkSimGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkSimPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkSite`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Get-AzMobileNetworkSlice`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkAttachedDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkPacketCoreControlPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkPacketCoreDataPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkSim`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkSimGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkSimPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkSite`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `New-AzMobileNetworkSlice`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkAttachedDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkBulkSimDelete`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkPacketCoreControlPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkPacketCoreDataPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkSim`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkSimGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkSimPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkSite`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Remove-AzMobileNetworkSlice`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Trace-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkAttachedDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkBulkSimUpload`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkBulkSimUploadEncrypted`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkDataNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkPacketCoreControlPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkPacketCoreDataPlane`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkSim`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkSimGroup`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkSimPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkSite`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

### `Update-AzMobileNetworkSlice`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '9/30/2025'- The change is expected to take effect from Az version : '14.5.0'
  - The change is expected to take effect from version : '0.5.0'

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupSchedulePolicyObject`

- Cmdlet breaking-change will happen to all parameter sets
  - May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload
  - This change is expected to take effect from Az.RecoveryServices version: 8.0.0 and Az version: 14.0.0

## Az.SpringCloud

### `Deploy-AzSpringCloudApp`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Disable-AzSpringCloudTestEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Enable-AzSpringCloudTestEndpoint`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloud`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudApp`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudAppBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudAppCustomDomain`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudAppDeploymentLogFileUrl`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudBuildpackBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudBuildService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudBuildServiceAgentPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudBuildServiceBuilder`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudBuildServiceSupportedBuildpack`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudBuildServiceSupportedStack`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudConfigServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudConfigurationService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudMonitoringSetting`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudRegistry`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudRuntimeVersion`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudSku`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Get-AzSpringCloudTestKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloud`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudApp`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppCustomDomain`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppDeploymentBuildResultObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppDeploymentJarUploadedObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppDeploymentNetCoreZipUploadedObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppDeploymentSourceUploadedObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudAppLoadedCertificateObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudBuildpackBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudBuildpackObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudBuildpacksGroupObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudBuildServiceAgentPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudBuildServiceBuilder`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudConfigurationService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudConfigurationServiceGitRepositoryObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudContentCertificateObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudGitPatternRepositoryObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudKeyVaultCertificateObject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudRegistry`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `New-AzSpringCloudTestKey`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloud`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudApp`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudAppBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudAppCustomDomain`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudBuildpackBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudBuildServiceBuilder`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Remove-AzSpringCloudConfigurationService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Restart-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Start-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Start-AzSpringCloudAppDeploymentJfr`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Stop-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Test-AzSpringCloudAppCustomDomain`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Test-AzSpringCloudConfigServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Test-AzSpringCloudConfigurationService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Test-AzSpringCloudNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloud`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudApp`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudAppActiveDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudAppBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudAppCustomDomain`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudAppDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudBuildpackBinding`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudBuildServiceAgentPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudBuildServiceBuilder`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudCertificate`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudConfigServer`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudConfigurationService`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

### `Update-AzSpringCloudMonitoringSetting`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Azure Spring Apps, including the Standard consumption and dedicated (currently in Public Preview only), Basic, Standard, and Enterprise plans, will be retired, please see details on https://aka.ms/asaretirement. 
  - This change will take effect on '3/31/2028'- The change is expected to take effect from Az version : '19.3.0'
  - The change is expected to take effect from version : '0.3.2'

