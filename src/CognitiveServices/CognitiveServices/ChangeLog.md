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

## Version 1.8.0

* Updated SDK to 7.4.0-preview.

## Version 1.7.0
* Added `New-AzCognitiveServicesAccountApiProperty` cmdlet.
* Supported `ApiProperty` parameter for `New-AzCognitiveServicesAccount` and `Set-AzCognitiveServicesAccount`

## Version 1.6.0
* Showed additional legal terms for certain APIs.

## Version 1.5.1
* Used `Deny` specifically as NetworkRules default action.

## Version 1.5.0
* Supported displaying account capabilities.
* Supported modifying PublicNetworkAccess.

## Version 1.4.0
* Support PrivateEndpoint and PublicNetworkAccess control. 

## Version 1.3.0
* Supported Identity, Encryption, UserOwnedStorage 

## Version 1.2.3
* Updated SDK to 7.0
* Improved error message when server responses empty body

## Version 1.2.2
* Update references in .psd1 to use relative path

## Version 1.2.1
* Fixed miscellaneous typos across module

## Version 1.2.0
* Added NetworkRuleSet support.

## Version 1.1.1
* Only display Bing disclaimer for Bing Search Services.
* Improve error when create account failed.

## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.1
* Added CustomSubdomainName as a new optional parameter for New-AzCognitiveServicesAccount which is used to specify subdomain for the resource.

## Version 1.0.0
* General availability of `Az.CognitiveServices` module
* Add completers for SkuName and Typem available on New-AzureRmCognitiveServicesAccount operation.
* Removed GetSkusWithAccountParamSetName parameter set from Get-AzCognitiveServicesAccountSkus
