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

## Version 0.2.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 0.1.0
* New Cmdlet Get-AzureRmMarketplaceTerms
    - Get the agreement terms of a given publisher id, offer id and plan id.
* New Cmdlet Set-AzureRmMarketplaceTerms
	- Accept or reject agreement terms of a give publisher id, offer id and plan id. Please use Get-AzureRmMarketplaceTerms to get the agreement terms.