<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release

## Version 6.0.0
* Set minimum dependency of module to PowerShell 5.0
* Remove obsolete parameter -AtScopeAndBelow from Get-AzureRmRoledefinition call
* Include assignments to deleted Users/Groups/ServicePrincipals in Get-AzureRmRoleAssignment result
* Add convenience cmdlet for creating ServicePrincipals
* Add Tab completers for Scope and ResourceType
* Merge Get- and Find- functionality in Get-AzureRmResource
* Add AD Cmdlets:
  - Remove-AzureRmADGroupMember
  - Get-AzureRmADGroup
  - New-AzureRmADGroup
  - Remove-AzureRmADGroup
  - Remove-AzureRmADUser
  - Update-AzureRmADApplication
  - Update-AzureRmADServicePrincipal
  - Update-AzureRmADUser

## Version 5.5.2
* Updated to the latest version of the Azure ClientRuntime

## Version 5.5.1
* Fix issue with Default Resource Group in CloudShell

## Version 5.5.0
* Fixed issue with importing aliases
* Add Support for DataActions and NotDataActions to be passed in roledefinition create calls
* Fix Roledefinitions calls to use the type filter

## Version 5.4.0
* Register-AzureRmProviderFeature: Added missing example in the docs
* Register-AzureRmResourceProvider: Added missing example in the docs
* Add proper error handling for Insufficient graph permission Issue whilst performing Roleassignment calls.
* Fix roleassignment get calls when there are duplicate objectIds.
* Fix RoleAssignment get to respect the ExpandPrincipalGroups parameter
* Fix Roleassignment get calls to be used with roledefinition ID.

## Version 5.3.0
* Get-AzureRmADServicePrincipal: Removed -ServicePrincipalName from the default Empty parameter set as it was redundant with the SPN parameter set

## Version 5.2.0
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob support for long-running Resources cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
* Added alias from Get-AzureRmProviderOperation to Get-AzureRmResourceProviderAction to conform with naming conventions
* Get-AzureRmProviderOperation: Added alias from -OperationSearchString to -Name and set default value of -OperationSearchString to "*", which will return all provider operations.

## Version 5.1.1
* Fixed issue where Get-AzureRMRoleAssignment would result in a assignments without roledefiniton name for custom roles
    - Users can now use Get-AzureRMRoleAssignment with assignments having roledefinition names irrespective of the type of role
* Fixed issue where Set-AzureRMRoleRoleDefinition used to throw RD not found error when there was a new scope in assignablescopes
    - Users can now use Set-AzureRMRoleRoleDefinition with assignable scopes including new scopes irrespective of the position of the scope
* Allow scopes to end with "/"
    - Users can now use RoleDefinition and RoleAssignment commandlets with scopes ending with "/" ,consistent with API and CLI
* Allow users to create RoleAssignment using delegation flag
    - Users can now use New-AzureRMRoleAssignment with an option of adding the delegation flag
* Fix RoleAssignment get to respect the scope parameter
* Add an alias for ServicePrincipalName in the New-AzureRmRoleAssignment Commandlet
    - Users can now use the ApplicationId instead of the ServicePrincipalName when using the New-AzureRmRoleAssignment commandlet

## Version 5.0.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 4.4.1

## Version 4.4.0
* Add ManagedApplication cmdlets
    - New-AzureRmManagedApplication cmdlet to create a managed application
    - Get-AzureRmManagedApplication cmdlet to list all managed applications under a subscription or to get a specific managed application
    - Remove-AzureRmManagedApplication cmdlet to delete a managed application
    - Set-AzureRmManagedApplication cmdlet to update an existing managed application
* Add ManagedApplicationDefinition cmdlets
    - New-AzureRmManagedApplicationDefinition cmdlet to create a managed application definition using a zip file uri or using mainTemplate and createUiDefinition json files
    - Get-AzureRmManagedApplicationDefinition cmdlet to list all managed application definitions under a resource group or to get a specific managed application definition
    - Remove-AzureRmManagedApplicationDefinition cmdlet to delete a managed application definition
    - Set-AzureRmManagedApplicationDefinition cmdlet to update an existing managed application definition
* Add PolicySetDefinition cmdlets
    - New-AzureRmPolicySetDefinition cmdlet to create a policy set definition
    - Get-AzureRmPolicySetDefinition cmdlet to list all policy set definitions or to get a specific policy set definition
    - Remove-AzureRmPolicySetDefinition cmdlet to delete a policy set definition
    - Set-AzureRmPolicySetDefinition cmdlet to update an existing policy set definition
* Add -PolicySetDefinition, -Sku and -NotScope parameters to New-AzureRmPolicyAssignment and Set-AzureRmPolicyAssignment cmdlets
* Add support to pass in policy url to New-AzureRmPolicyDefinition and Set-AzureRmPolicyDefinition cmdlets
* Add -Mode parameter to New-AzureRmPolicyDefinition cmdlet
* Add Support for removal of roleassignment using PSRoleAssignment object
    - Users can now use PSRoleassignmnet inputobject with Remove-AzureRMRoleAssignment commandlet to remove the roleassignment.
    
## Version 4.3.1

## Version 4.3.0
* Add Support for validation of scopes for the following roledefinition and roleassignment commandlets before sending the request to ARM
    - Get-AzureRMRoleAssignment
    - New-AzureRMRoleAssignment
    - Remove-AzureRMRoleAssignment
    - Get-AzureRMRoleDefinition
    - New-AzureRMRoleDefinition
    - Remove-AzureRMRoleDefinition
    - Set-AzureRMRoleDefinition

## Version 4.2.1

## Version 4.2.0

## Version 4.1.0
* Fixed issue where Get-AzureRMRoleAssignment would result in a Bad Request if the number of roleassignments where greater than 1000
    - Users can now use Get-AzureRMRoleAssignment even if the roleassignments to be returned is greater than 1000
    
## Version 4.0.1

## Version 4.0.0
* Support cross-resource-group deployments for New-AzureRmResourceGroupDeployment
    - Users can now use nested deployments to deploy to different resource groups.

## Version 3.8.0

## Version 3.7.0

## Version 3.6.0
* Support policy parameters for New-AzureRmPolicyDefinition and New-AzureRmPolicyAssignment
    - Users can now use Parameter parameter with New-AzureRmPolicyDefinition. This accepts both JSON string and file path.
    - Users can now provide policy parameter values in New-AzureRmPolicyAssignment in a couple of ways, including JSON string, file path, PS object, and through PowerShell parameters. 

## Version 3.5.0
* Support Tag as parameters for Find-AzureRmResource
    - Users can now use Tag parameter with Find-AzureRmResource
    - Fixed the issue where illegal combinations of TagName, TagValue with other search parameters was allowed in Find-AzureRmResource and would result in users getting exception from the service by disallowing such combinations. 

## Version 3.4.0
* Support ResourceNameEquals and ResourceGroupNameEquals as parameters for Find-AzureRmResource
    - Users can now use ResourceNameEquals and ResourceGroupNameEquals with Find-AzureRmResource

## Version 3.3.0
* Lookup of AAD group by Id now uses GetObjectsByObjectId AAD Graph call instead of Groups/<id>
    - This will enable Groups lookup in CSP scenario
* Remove unnecessary AAD graph call in Get role assignments logic
    - Only make call when needed instead of always
* Fixed issue where Remove-AzureRmResource would throw an exception if one of the resources passed through the pipeline failed to be removed
    - If cmdlet fails to remove one of the resources, the result will not have an effect on the removal of other resources
