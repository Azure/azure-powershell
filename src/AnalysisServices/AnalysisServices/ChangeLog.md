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

## Version 1.1.6
* Migrated AnalysisServices SDK to generated SDK
    - Removed "Microsoft.Azure.Management.Analysis" Version "2.0.4" PackageReference
    - Added AnalysisServices.Management.Sdk ProjectReference

## Version 1.1.5
* Removed the outdated deps.json file.

## Version 1.1.4
* Removed project reference to Authentication

## Version 1.1.3
* Updated assembly version of data plane cmdlets

## Version 1.1.2
* Update references in .psd1 to use relative path

## Version 1.1.1
* Fixed miscellaneous typos across module

## Version 1.1.0
* Using ServiceClient in dataplane cmdlets and removing the original authentication logic
* Making Add-AzureASAccount a wrapper of Connect-AzAccount to avoid a breaking change

## Version 1.0.2
* Deprecated AddAzureASAccount cmdlet

## Version 1.0.1
* Release with updated Authentication dependency

## Version 1.0.0
* General availability of `Az.AnalysisServices` module
