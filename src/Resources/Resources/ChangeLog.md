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
* Improve handling of providers for `Get-AzResource` when providing `-ResourceId` or `-ResourceGroupName`, `-Name` and `-ResourceType` parameters

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
