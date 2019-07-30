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
