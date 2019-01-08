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
* Fix parameter set issue when providing `-ODataQuery` and `-ResourceId` parameters for `Get-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/7875
* Fix handling of the -Custom parameter in New/Set-AzPolicyDefinition

## Version 1.0.0
* General availability of `Az.Resources` module
* Removed -Sku parameter from New/Set-AzPolicyAssignment
* Removed -Password parameter from New-AzADServicePrincipal and New-AzADSpCredential
