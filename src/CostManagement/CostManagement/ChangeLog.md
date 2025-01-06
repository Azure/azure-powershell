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
* upgraded nuget package to signed package.
* Fixed bug tags in query filter cannot be properly serialized [#22326]

## Version 0.3.3
* Fixed an error that values in row could be null when grouping by the value of TagKey in Invoke-AzCostManagementQuery cmdlet. Fix in 0.3.1 accidentally removed from 0.3.2, added it back. [#25948]

## Version 0.3.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.3.1
* Fixed an error that values in row could be null when grouping by the value of TagKey in Invoke-AzCostManagementQuery cmdlet.

## Version 0.3.0
* Upgraded Api version to 2021-10-01

## Version 0.2.0
* Fixed an error that the CostmanagementExport could not be updated correctly

## Version 0.1.0
* First preview release for module Az.CostManagement
