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