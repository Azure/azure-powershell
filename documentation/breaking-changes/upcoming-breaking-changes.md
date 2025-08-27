# Upcoming breaking changes in Azure PowerShell

The breaking changes listed in this article are planned for the next major release of the Az
PowerShell module unless otherwise noted. Per our
[Support lifecycle](azureps-support-lifecycle.md), breaking changes in Azure PowerShell occur twice
a year with major versions of the Az PowerShell module.

Preview modules are not included in this list. Read more about [module version types](azureps-support-lifecycle.md#module-version-types).

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
    

### `New-AzContainerInstanceContainerGroupProfile`

- Parameter breaking-change will happen to all parameter sets
  - `-OSType`
    - The parameter : 'OSType' is changing.
    - Change description : Removing the default value of OSType parameter. 
    - This change will take effect on '5/21/2025'- The change is expected to take effect from Az version : '14.0.0'
    - The change is expected to take effect from version : '5.0.0'

## Az.DevCenter

### `Connect-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Connect-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Connect-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Connect-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminAttachedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminAttachedNetwork' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCatalogSyncErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCatalogSyncErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCustomizationTask`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCustomizationTask' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminCustomizationTaskErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminCustomizationTaskErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminDevBoxDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminEnvironmentDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminEnvironmentDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminGallery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminGallery' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminImage`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminImage' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminImageVersion`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminImageVersion' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The default parameter set will change from list dev center image versions to list project image versions. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminNetworkConnection' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminNetworkConnectionHealthDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminNetworkConnectionHealthDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminOperationStatus`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminOperationStatus' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminPool' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProject' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectAllowedEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectAllowedEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectCatalogSyncErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectCatalogSyncErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectEnvironmentDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectEnvironmentDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectEnvironmentDefinitionErrorDetail`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectEnvironmentDefinitionErrorDetail' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminProjectInheritedSetting`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Get-AzDevCenterAdminProjectInheritedSetting' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Get-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Invoke-AzDevCenterAdminExecuteCheckNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Invoke-AzDevCenterAdminExecuteCheckNameAvailability' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Invoke-AzDevCenterAdminExecuteCheckScopedNameAvailability' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminAttachedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'New-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-PlanId`
    - The parameter : 'PlanId' is changing.
    - Change description : PlanId parameter will be removed. 
    - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'New-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminGallery`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The Plan resource will be deprecated
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The PlanMember resource will be deprecated
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `New-AzDevCenterUserDevBox`

- Parameter breaking-change will happen to all parameter sets
  - `-LocalAdministrator`
    

### `Remove-AzDevCenterAdminAttachedNetwork`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminAttachedNetwork' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminDevBoxDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminGallery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminGallery' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminNetworkConnection' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminPool' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminProject' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Remove-AzDevCenterAdminProjectEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Remove-AzDevCenterUserEnvironment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Repair-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Restart-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Start-AzDevCenterAdminNetworkConnectionHealthCheck`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Start-AzDevCenterAdminNetworkConnectionHealthCheck' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Start-AzDevCenterAdminPoolHealthCheck`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Start-AzDevCenterAdminPoolHealthCheck' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Start-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Stop-AzDevCenterUserDevBox`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type is changing from the existing type :'OperationStatus' to the new type :'OperationStatus'
  - The following properties in the output type are being deprecated : 'Property'
  - The following properties are being added to the output type : 'Property'
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Sync-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Sync-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Sync-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Sync-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminDevBoxDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminDevBoxDefinition' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminDevCenter`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminDevCenter' is replacing this cmdlet.
  - Change description : PlanId will be removed from the DevCenter output. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-PlanId`
    - The parameter : 'PlanId' is changing.
    - Change description : PlanId parameter will be removed. 
    - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminNetworkConnection`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminNetworkConnection' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminPlan`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminPlanMember`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : The Plan and PlanMember resources will be removed. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminPool`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminPool' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminProject`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminProject' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminProjectCatalog`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminProjectCatalog' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminProjectEnvironmentType`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet 'Update-AzDevCenterAdminProjectEnvironmentType' is replacing this cmdlet.
  - Change description : PlanName and MemberName will be removed from the InputObject parameter. 
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

### `Update-AzDevCenterAdminSchedule`

- Cmdlet breaking-change will happen to all parameter sets
  MemberName and PlanName will be removed from InputObject
  - This change will take effect on '11/18/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '3.0.0'

## Az.ManagedServices

### `Get-AzManagedServicesAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationAssignment' is changing
  - The following properties in the output type are being deprecated : 'Authorization[]' 'EligibleAuthorization[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzManagedServicesDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationDefinition' is changing
  - The following properties in the output type are being deprecated : 'Authorization[]' 'EligibleAuthorization[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzManagedServicesAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationAssignment' is changing
  - The following properties in the output type are being deprecated : 'Authorization[]' 'EligibleAuthorization[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `New-AzManagedServicesAuthorizationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-DelegatedRoleDefinitionId`
    

### `New-AzManagedServicesDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IRegistrationDefinition' is changing
  - The following properties in the output type are being deprecated : 'Authorization' 'EligibleAuthorization' 'DelegatedRoleDefinitionId[]' 'JustInTimeAccessPolicyManagedByTenantApprover[]'
  - The following properties are being added to the output type : 'List[Authorization]' 'List[EligibleAuthorization]' 'List[DelegatedRoleDefinitionId]' 'List[JustInTimeAccessPolicyManagedByTenantApprover]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Authorization`
    - The parameter : 'Authorization' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '9.0.0'
  - `-EligibleAuthorization`
    - The parameter : 'EligibleAuthorization' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '9.0.0'

### `New-AzManagedServicesEligibleAuthorizationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-JustInTimeAccessPolicyManagedByTenantApprover`
    

## Az.Monitor

### `Get-AzActivityLogAlert`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IActivityLogAlertResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'ConditionAllOf' 'Scope'
  - The following properties are being added to the output type : 'ActionGroup' 'ConditionAllOf' 'Scope'
  - Change description : The types of the properties ActionGroup, ConditionAllOf and Scope will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAutoscalePredictiveMetric`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IPredictiveResponse' is changing
  - The following properties in the output type are being deprecated : 'Data'
  - The following properties are being added to the output type : 'Data'
  - Change description : The type of the property 'Data' of type 'IPredictiveResponse' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource' is changing
  - The following properties in the output type are being deprecated : 'Notification' 'Profile'
  - The following properties are being added to the output type : 'Notification' 'Profile'
  - Change description : The types of the properties 'Notification' and 'Profile' of type 'IAutoscaleSettingResource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log' 'Metric'
  - The following properties are being added to the output type : 'Log' 'Metric'
  - Change description : The types of the properties Log and Metric will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzDiagnosticSettingCategory`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsCategoryResource' is changing
  - The following properties in the output type are being deprecated : 'CategoryGroup'
  - The following properties are being added to the output type : 'CategoryGroup'
  - Change description : The type of the property CategoryGroup will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - The following properties are being added to the output type : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - Change description : The types of the properties ActionGroup, CriterionAllOf, Scope and TargetResourceType will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Get-AzSubscriptionDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.ISubscriptionDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log'
  - The following properties are being added to the output type : 'Log'
  - Change description : The type of the property Log will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.AlertRuleAnyOfOrLeafCondition' is changing
  - The following properties in the output type are being deprecated : '"ContainsAny","AnyOf[]"'
  - The following properties are being added to the output type : '"List[ContainsAny]","List[AnyOf]"'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-AnyOf`
    
  - `-ContainsAny`
    

### `New-AzActivityLogAlertAlertRuleLeafConditionObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.AlertRuleLeafCondition' is changing
  - The following properties in the output type are being deprecated : 'ContainsAny'
  - The following properties are being added to the output type : 'List[ContainsAny]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-ContainsAny`
    

### `New-AzAutoscaleNotificationObject`

- Parameter breaking-change will happen to all parameter sets
  - `-EmailCustomEmail`
    
  - `-Webhook`
    

### `New-AzAutoscaleProfileObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Rule`
    
  - `-ScheduleDay`
    
  - `-ScheduleHour`
    
  - `-ScheduleMinute`
    

### `New-AzAutoscaleScaleRuleMetricDimensionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Value`
    

### `New-AzAutoscaleScaleRuleObject`

- Parameter breaking-change will happen to all parameter sets
  - `-MetricTriggerDimension`
    

### `New-AzAutoscaleSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource' is changing
  - The following properties in the output type are being deprecated : 'Notification' 'Profile'
  - The following properties are being added to the output type : 'Notification' 'Profile'
  - Change description : The types of the properties 'Notification' and 'Profile' of type 'IAutoscaleSettingResource' will be changed from single object to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to parameter set `NewAzAutoscaleSetting_CreateExpanded`
  - `-Profile`
    - The parameter : 'Profile' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '7.0.0'

### `New-AzDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log' 'Metric'
  - The following properties are being added to the output type : 'Log' 'Metric'
  - Change description : The types of the properties Log and Metric will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '7.0.0'

### `New-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - The following properties are being added to the output type : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - Change description : The types of the properties ActionGroup, CriterionAllOf, Scope and TargetResourceType will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzScheduledQueryRuleConditionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Dimension`
    

### `New-AzScheduledQueryRuleDimensionObject`

- Parameter breaking-change will happen to all parameter sets
  - `-Value`
    

### `New-AzSubscriptionDiagnosticSetting`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.ISubscriptionDiagnosticSettingsResource' is changing
  - The following properties in the output type are being deprecated : 'Log'
  - The following properties are being added to the output type : 'Log'
  - Change description : The type of the property Log will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Log`
    - The parameter : 'Log' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '7.0.0'

### `Update-AzMonitorWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.MonitorWorkspace.Models.Api20230403.IAzureMonitorWorkspaceResource' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection' 'ProvisioningState'
  - The following properties are being added to the output type : 'PrivateEndpointConnection' 'ProvisioningState'
  - Change description : The types of the properties PrivateEndpointConnection and ProvisioningState will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `Update-AzScheduledQueryRule`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource' is changing
  - The following properties in the output type are being deprecated : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - The following properties are being added to the output type : 'ActionGroup' 'CriterionAllOf' 'Scope' 'TargetResourceType'
  - Change description : The types of the properties ActionGroup, CriterionAllOf, Scope and TargetResourceType will be changed from single object or fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

## Az.Nginx

### `Get-AzNginxConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxConfiguration' is changing
  - The following properties in the output type are being deprecated : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - The following properties are being added to the output type : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - Change description : The types of the properties File, ProtectedFile and PackageProtectedFile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Get-AzNginxDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxDeployment' is changing
  - The following properties in the output type are being deprecated : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - The following properties are being added to the output type : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - Change description : The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Invoke-AzNginxAnalysisConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.IAnalysisResult' is changing
  - The following properties in the output type are being deprecated : 'DataError'
  - The following properties are being added to the output type : 'DataError'
  - Change description : The type of the property DataError will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Cmdlet breaking-change will happen to parameter set `InvokeAzNginxAnalysisConfiguration_Analysis`
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set 'Analysis' and 'AnalysisViaIdentity' will be removed. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

- Cmdlet breaking-change will happen to parameter set `InvokeAzNginxAnalysisConfiguration_AnalysisViaIdentity`
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : The parameter set 'Analysis' and 'AnalysisViaIdentity' will be removed. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '7.0.0'

### `New-AzNginxConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxConfiguration' is changing
  - The following properties in the output type are being deprecated : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - The following properties are being added to the output type : 'File' 'ProtectedFile' 'PackageProtectedFile'
  - Change description : The types of the properties File, ProtectedFile and PackageProtectedFile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `New-AzNginxDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxDeployment' is changing
  - The following properties in the output type are being deprecated : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - The following properties are being added to the output type : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - Change description : The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'

### `New-AzNginxNetworkProfileObject`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.NginxNetworkProfile' is changing
  - Change description : The types of the properties PrivateIPAddress and PublicIPAddress of Property FrontendIPConfiguration will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

### `Update-AzNginxDeployment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api202401Preview.INginxDeployment' is changing
  - The following properties in the output type are being deprecated : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - The following properties are being added to the output type : 'PrivateIPAddress' 'PublicIPAddress' 'AutoScaleSettingProfile'
  - Change description : The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'. 
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '2.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-IdentityType`
    - The parameter : 'IdentityType' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'
  - `-IdentityUserAssignedIdentity`
    - The parameter : 'IdentityUserAssignedIdentity' is changing.
    - Change description : The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity. 
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '2.0.0'

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupSchedulePolicyObject`

- Cmdlet breaking-change will happen to all parameter sets
  - May 2025 onwards, this command will return a schedule policy object for Enhanced policy by default for AzureVM workload
  - This change is expected to take effect from Az.RecoveryServices version: 8.0.0 and Az version: 14.0.0

## Az.Relay

### `Get-AzRelayNamespace`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.IRelayNamespace' is changing
  - The following properties in the output type are being deprecated : 'PrivateEndpointConnection'
  - The following properties are being added to the output type : 'List[PrivateEndpointConnection]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Get-AzRelayNamespaceNetworkRuleSet`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.Api20211101.INetworkRuleSet' is changing
  - The following properties in the output type are being deprecated : 'IPRule'
  - The following properties are being added to the output type : 'List[IPRule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

## Az.Resources

### `Get-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

### `Update-AzRoleManagementPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization.Models.Api20201001Preview.IRoleManagementPolicy' is changing
  - The following properties in the output type are being deprecated : 'EffectiveRule[]' 'Rule[]'
  - The following properties are being added to the output type : 'List[EffectiveRule]' 'List[Rule]'
  - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
  - The change is expected to take effect from version : '9.0.0'

- Parameter breaking-change will happen to all parameter sets
  - `-Rule`
    - The parameter : 'Rule' is changing.
    The type of the parameter is changing from 'Array' to 'List'.
    - This change will take effect on '11/3/2025'- The change is expected to take effect from Az version : '15.0.0'
    - The change is expected to take effect from version : '9.0.0'
