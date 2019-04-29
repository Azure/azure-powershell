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

## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.0
* General availability of `Az.Batch` module
* Added the ability to see what version of the Azure Batch Node Agent is running on each of the VMs in a pool, via the new `NodeAgentInformation` property on `PSComputeNode`.
* Removed the `ValidationStatus` property from `PSTaskCounts`.
* The `Caching` default for `PSDataDisk` is now `ReadWrite` instead of `None`.
