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

## Version 1.6.4
* Upgraded Azure.Core to 1.35.0.

## Version 1.6.3
* Updated Azure.Core to 1.34.0.

## Version 1.6.2
* Updated Azure.Core to 1.33.0.

## Version 1.6.1
* Updated Azure.Core to 1.31.0.

## Version 1.6.0
* Added support for policy attestations.

## Version 1.5.1
* Updated parameter documentation for Get-AzPolicyState 

## Version 1.5.0
* Added support for new remediation properties allowing the remediation of more resources with better control over the remediation rate and error handling
* Added support of fetching very large sets of results by internally using paginated API calls for policy states and policy events commands

## Version 1.4.1
* Retracted changes made in powershell that increased request row limit. Removed incorrect statement of supporting paging

## Version 1.4.0
* Added support for returning paginated results for Get-AzPolicyState

## Version 1.3.1
* Corrected example 3 for `Start-AzPolicyComplianceScan`

## Version 1.3.0
* Added `Start-AzPolicyComplianceScan` cmdlet for triggering policy compliance scans
* Added policy definition, set definition, and assignment versions to `Get-AzPolicyState` output

## Version 1.2.1
* Improved error messages

## Version 1.2.0
* Support evaluating compliance prior to determining what resource to remediate
    - Add `-ResourceDiscoverMode` parameter to Start-AzPolicyRemediation
* Add Get-AzPolicyMetadata cmdlet for getting policy metadata resources
* Updated Get-AzPolicyState and Get-AzPolicyStateSummary for API version 2019-10-01


## Version 1.1.4
* Update references in .psd1 to use relative path

## Version 1.1.3
* Fixed miscellaneous typos across module

## Version 1.1.2
* Fix null reference issue in Get-AzPolicyState
    - More information here: https://github.com/Azure/azure-powershell/issues/9446

## Version 1.1.1
* Fix Null reference issue in Get-AzPolicyEvent

## Version 1.1.0
* Support for querying policy evaluation details.
    - Add `-Expand` parameter to Get-AzPolicyState. Support `-Expand PolicyEvaluationDetails`.

## Version 1.0.0
* General availability of `Az.PolicyInsights` module
