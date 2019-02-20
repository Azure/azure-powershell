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
* Correct example in Get-AzWebAppSlotMetrics

## Version 1.1.0
* Update incorrect online help URLs
* Fixes `New-AzWebAppSSLBinding` to upload the certificate to the correct resourcegroup+location if the app is hosted on an ASE.
* Fixes `New-AzWebAppSSLBinding` to not overwrite the tags on binding an SSL certificate to an app

## Version 1.0.1
* Fixed a date parsing bug in `Get-AzDeletedWebApp`
* Fix backward compatibility issue with Az.Accounts module

## Version 1.0.0
* General availability of `Az.Websites` module
* Removed deprecated properties from PS models
