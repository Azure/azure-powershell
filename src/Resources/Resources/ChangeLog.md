<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->

## Upcoming Release
* Added support for Azure resources deployment in Bicep language
* Fixed issues with TemplateSpec deployments in `New-AzTenantDeployment` and `New-AzManagementGroupDeployment`
* Added support for `-QueryString` parameter in `Test-Az*Deployments` cmdlets
* Fixed issue with dynamic parameters when `New-Az*Deployments` is used with `-QueryString`
* Added support for `-TemplateParameterObject` parameter while using `-TemplateSpecId` parameter in `New-Az*Deployments` cmdlets
* Fixed the inaccurate error message received on trying to deploy a non-existent template spec
* Added support for policy export format to ```New-AzPolicyDefinition -Policy```
* Add support for property updates from ```Set-AzPolicyAssignment -InputObject```

## Version 3.2.1
* Removed principal type on New-AzRoleAssignment and Set-AzRoleAssignment because current mapping was breaking certain scenarios

## Version 3.2.0
* Added support for -QueryString parameter in New-Az*Deployments cmdlets

## Version 3.1.1
* Fixed a NullRef exception issue in `New-AzureManagedApplication` and `Set-AzureManagedApplication`.
* Updated Azure Resource Manager SDK to use latest DeploymentScripts GA api-version: 2020-10-01.

## Version 3.1.0
* Added `-Tag` parameter support to `Set-AzTemplateSpec` and `New-AzTemplateSpec`
* Added Tag display support to default formatter for Template Specs 

## Version 3.0.1
* Fixed an issue where What-If shows two resource group scopes with different casing
* Updated `Export-AzResourceGroup` to use the SDK.
* Added culture info to parse methods
* Fixed issue where attempts to deploy template specs from a subscription outside of the current subscription context would fail
* Changed Double parser for version parser
* Changed New-AzRoleAssignment to include principal type during calls
* Changed Set-AzRoleAssignment to include principal type during calls

## Version 3.0.0
* Fixed parsing bug
* Updated ARM template What-If cmdlets to remove preview message from results
* Fixed an issue where template deployment cmdlets crash if `-WhatIf` is set at a higher scope [#13038]
* Fixed an issue where template deployment cmdlets does not preserve case for template parameters
* Added a default API version to be used in `Export-AzResourceGroup` cmdlet
* Added cmdlets for Template Specs (`Get-AzTemplateSpec`, `Set-AzTemplateSpec`, `New-AzTemplateSpec`, `Remove-AzTemplateSpec`, `Export-AzTemplateSpec`)
* Added support for deploying Template Specs using existing deployment cmdlets (via the new -TemplateSpecId parameter) 
* Updated `Get-AzResourceGroupDeploymentOperation` to use the SDK.
* Removed `-ApiVersion` parameter from `*-AzDeployment` cmdlets.

## Version 2.5.1
* Added missing check for Set-AzRoleAssignment
* Added breaking change attribute to `SubscriptionId` parameter of `Get-AzResourceGroupDeploymentOperation`
* Updated ARM template What-If cmdlets to show "Ignore" resource changes last
* Fixed secure and array parameter serialization issues for deployment cmdlets [#12773]

## Version 2.5.0
* Updated `Get-AzPolicyAlias` response to include information indicating whether the alias is modifiable by Azure Policy.
* Created new cmdlet `Set-AzRoleAssignment`
* Added `Get-AzDeploymentManagementGroupWhatIfResult` for getting ARM template What-If results at management Group scope
* Added `Get-AzTenantWhatIfResult` new cmdlet for getting ARM template What-If results at tenant scope
* Overrode `-WhatIf` and `-Confirm` for `New-AzManagementGroupDeployment` and `New-AzTenantDeployment` to use ARM template What-If results
* Fixed the behaviors of `-WhatIf` and `-Confirm` for new deployment cmdlets so they comply with $WhatIfPreference and $ConfrimPreference
* Fixed serialization error for `-TemplateObject` and `TemplateParameterObject` [#1528] [#6292]

## Version 2.4.0
* Added properties "Condition", "ConditionVersion" and "Description" to `New-AzRoleAssignment`
    - This included all the relevant changes to the data models

## Version 2.3.0
* Updated `Save-AzResourceGroupDeploymentTemplate` to use the SDK.
* Added 'Unregister-AzResourceProvider' cmdlet.

## Version 2.2.0
* Added `UsageLocation`, `GivenName`, `Surname`, `AccountEnabled`, `MailNickname`, `Mail` on `PSADUser` [#10526] [#10497]
* Fixed issue that `-Mail` doesn't work on `Get-AzADUser` [#11981]
* Added `-ExcludeChangeType` parameter to `Get-AzDeploymentWhatIfResult` and `Get-AzResourceGroupDeploymentWhatIfResult`
* Added `-WhatIfExcludeChangeType` parameter to `New-AzDeployment` and `New-AzResourceGroupDeployment`
* Updated `Test-Az*Deployment` cmdlets to show better error messages
* Fixed help message for `-Name` parameter of deployment create and What-If cmdlets

## Version 2.1.0
* Added Tail parameter to Get-AzDeploymentScriptLog and Save-AzDeploymentScriptLog cmdlets
* Formatted Output property and show it on the Get-AzDeploymentScript cmdlet output
* Renamed -DeploymentScriptInputObject parameter to -DeploymentScriptObject
* Fixed missing file/target name in cmdlet messages.
* Updated assembly version of resource manager and tags cmdlets

## Version 2.0.1
* Added message warning about view delay when creating a new Role Definition
* Changed policy cmdlets to output strongly-typed objects
* Removed `-TenantLevel` parameter used for on the `Get-AzResourceLock` cmdlet [#11335]
* Fixed `Remove-AzResourceGroup -Id ResourceId`[#9882]
* Added new cmdlet for getting ARM template What-If results at resource group scope: `Get-AzDeploymentResourceGroupWhatIfResult`
* Added new cmdlet for getting ARM template What-If results at subscription scope: `Get-AzDeploymentWhatIfResult`
   - Alias: `Get-AzSubscriptionDeploymentWhatIf`
* Overrode `-WhatIf` and `-Confirm` parameters for `New-AzDeployment` and `New-AzResourceGroupDeployment` to use ARM template What-If results
* Added deprecation message for `ApiVersion` parameter in deployment cmdlets
* Added capability to show improved error messages for deployment failures
* Added correlationId logging for deployment failures
* Added `error` property to the deployment script output
* Updated nuget Microsoft.Azure.Management.ResourceManager to "3.7.1-preview"
* Removed specific test cases as Error property in DeploymentValidateResult has changed to readonly from nuget 3.7.1-preview
* Brought GenericResourceExpanded from SDK ResourceManager 3.7.1-preview
* Added tag support for all Get cmdlets for deployment, as well as
    - `New-AzDeployment`
    - `New-AzManagementGroupDeployment`
    - `New-AzResourceGroupDeployment`
    - `New-AzTenantDeployment`


## Version 1.13.0
* Fixed `Get-AzResource -ResourceGroupName -Name -ExpandProperties -ResourceType` to use actual apiVersion of resources instead of default apiVersion [#11267]
* Added correlationId logging for error scenarios
* Small documentation change to `Get-AzResourceLock`. Added example.
* Escaped single quote in parameter value of `Get-AzADUser` [#11317]
* Added new cmdlets for Deployment Scripts (`Get-AzDeploymentScript`, `Get-AzDeploymentScriptLog`, `Save-AzDeploymentScriptLog`, `Remove-AzDeploymentScript`)

## Version 1.12.0
* Fixed for null reference bug in `Get-AzRoleAssignment`
* Marked switch `-Force` and `-PassThru` optional in `Remove-AzADGroup` [#10849]
* Fixed issue that `MailNickname` doesn't return in `Remove-AzADGroup` [#11167]
* Fixed issue that `Remove-AzADGroup` pipe operation doesn't work [#11171]
* Fixed for null reference bug in GetAzureRoleAssignmentCommand
* Added breaking change attributes for upcoming changes to policy cmdlets
* Updated `Get-AzResourceGroup` to perform resource group tag filtering on server-side
* Extended Tag cmdlets to accept -ResourceId
    - Get-AzTag -ResourceId
    - New-AzTag -ResourceId
    - Remove-AzTag -ResourceId
* Added new Tag cmdlet
    - Update-AzTag -ResourceId
* Brought ScopedDeployment from SDK 3.3.0 

## Version 1.11.0
* Refactored template deployment cmdlets
    - Added new cmdlets for managing deployments at management group: *-AzManagementGroupDeployment
    - Added new cmdlets for managing deployments at tenant scope: *-AzTenantDeployment
    - Refactored *-AzDeployment cmdlets to work specifically at subscription scope
    - Created aliases *-AzSubscriptionDeployment for *-AzDeployment cmdlets
* Fixed `Update-AzADApplication` when parameter `AvailableToOtherTenants` is not set
* Removed ApplicationObjectWithoutCredentialParameterSet to avoid AmbiguousParameterSetException.
* Regenerated help files

## Version 1.10.0
* Make -Scope optional in *-AzPolicyAssignment cmdlets with default to context subscription
* Add examples of creating ADServicePrincipal with password and key credential

## Version 1.9.1
* Fix an error in help document of `Remove-AzTag`.
* Fix for aliases missing from output of Get-AzPolicyAlias
* Update resource client to new version that retrieves providers and aliases at tenant level
* Update Get-AzPolicyAlias to retrieve aliases at tenant level
* Update -Policy parameter of New-AzPolicyDefinition and Set-AzPolicyDefinition to allow full policy object

## Version 1.9.0
* Update references in .psd1 to use relative path
* Fix an issue where template deployment fails to read a template parameter if its name conflicts with some built-in parameter name.
* Updated policy cmdlets to use new api version 2019-09-01 that introduces grouping support within policy set definitions.
* Fix the bug that the output of some sub-resource is empty when using `Get-AzResource`.

## Version 1.8.0
- Updated policy cmdlets to use new api version 2019-06-01 that has new EnforcementMode property in policy assignment.
- Updated create policy definition help example
- Fix bug Remove-AZADServicePrincipal -ServicePrincipalName, throw null reference when service principal name not found.
- Fix bug New-AZADServicePrincipal, throw null reference when tenant doesn't have any subscription.
- Change New-AzAdServicePrincipal to add credentials only to associated application.

## Version 1.7.1
* Update dependency assembly Microsoft.Extensions.Caching.Memory from 1.1.1 to 2.2

## Version 1.7.0
* Fix bug where New-AzRoleAssignment could not be called without parameter Scope.

## Version 1.6.2
* Add support for new api version 2019-05-10 for Microsoft.Resource
    - Add support for `copy.count = 0` for variables, resources and properties
    - Resources with `condition = false` or `copy.count = 0` will be deleted in complete mode
* Fixed miscellaneous typos across module
* Add an example of assigning policy at subscription level to help doc
* Added breaking change notice about new required parameter `-ScopeType` in the `AzDeployment` cmdlets
    - `Get-AzDeployment`
    - `Get-AzDeploymentOperation`
    - `New-AzDeployment`
    - `Remove-AzDeployment`
    - `Save-AzDeploymentTemplate`
    - `Stop-AzDeployment`
    - `Test-AzDeployment`

## Version 1.6.1
- Remove missing cmdlet referenced in `New-AzResourceGroupDeployment` documentation
- Updated policy cmdlets to use new api version 2019-01-01

## Version 1.6.0
- Fix help text for Get-AzPolicyState -Top parameter
- Add client-side paging support for Get-AzPolicyAlias
- Add new parameters for Set-AzPolicyAssignment, -PolicyParameters and -PolicyParametersObject
- Handful of doc and example updates for Policy cmdlets

## Version 1.5.0
* Support for additional Template Export options
    - Add `-SkipResourceNameParameterization` parameter to Export-AzResourceGroup
    - Add `-SkipAllParameterization` parameter to Export-AzResourceGroup
    - Add `-Resource` parameter to Export-AzResourceGroup for exported resource filtering

## Version 1.4.0
* Add new cmdlet Get-AzureRmDenyAssignment for retrieving deny assignments
* Added 'Description' parameter when working with Azure AD Groups:
    - Added a parameter to New-AzAdGroup
    - Added as output on Get-AzAdGroup

## Version 1.3.1
* Fix documentation for wildcards

## Version 1.3.0
* Improve handling of providers for `Get-AzResource` when providing `-ResourceId` or `-ResourceGroupName`, `-Name` and `-ResourceType` parameters
* Improve error handling for for `Test-AzDeployment` and `Test-AzResourceGroupDeployment`
    - Handle errors thrown outside of deployment validation and include them in output of command instead
    - More information here: https://github.com/Azure/azure-powershell/issues/6856
* Add `-IgnoreDynamicParameters` switch parameter to set of deployment cmdlets to skip prompt in script and job scenarios
    - More information here: https://github.com/Azure/azure-powershell/issues/6856

## Version 1.2.1
* Update wildcard support for Get-AzResource and Get-AzResourceGroup
* Update credentials used when making generic calls to ARM

## Version 1.2.0
* Add `-TemplateObject` parameter to deployment cmdlets
    - More information here: https://github.com/Azure/azure-powershell/issues/2933
* Fix issue when piping the result of `Get-AzResource` to `Set-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/8240
* Fix issue with JSON data type change when running `Set-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/7930

## Version 1.1.3
* Fix for issue https://github.com/Azure/azure-powershell/issues/8166
* Fix for issue https://github.com/Azure/azure-powershell/issues/8235
* Fix for issue https://github.com/Azure/azure-powershell/issues/6219
* Fix bug preventing repeat creation of KeyCredentials

## Version 1.1.2
* Fix tagging for resource groups
    - More information here: https://github.com/Azure/azure-powershell/issues/8166
* Fix issue where `Get-AzureRmRoleAssignment` doesn't respect -ErrorAction
    - More information here: https://github.com/Azure/azure-powershell/issues/8235

## Version 1.1.1
* Fix incorrect examples in `New-AzADAppCredential` and `New-AzADSpCredential` reference documentation
* Fix issue where path for `-TemplateFile` parameter was not being resolved before executing resource group deployment cmdlets
* Az.Resources: Correct documentation for New-AzureRmPolicyDefinition -Mode default value
* Az.Resources: Fix for issue https://github.com/Azure/azure-powershell/issues/7522
* Az.Resources: Fix for issue https://github.com/Azure/azure-powershell/issues/5747
* Fix formatting issue with `PSResourceGroupDeployment` object
    - More information here: https://github.com/Azure/azure-powershell/issues/2123

## Version 1.1.0
* Fix parameter set issue when providing `-ODataQuery` and `-ResourceId` parameters for `Get-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/7875
* Fix handling of the -Custom parameter in New/Set-AzPolicyDefinition
* Fix typo in New-AzDeployment documentation
* Made `-MailNickname` parameter mandatory for `New-AzADUser`
    - More information here: https://github.com/Azure/azure-powershell/issues/8220

## Version 1.0.0
* General availability of `Az.Resources` module
* Removed -Sku parameter from New/Set-AzPolicyAssignment
* Removed -Password parameter from New-AzADServicePrincipal and New-AzADSpCredential
