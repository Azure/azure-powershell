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
* Added support for Confluent Connector management
  - New cmdlet `New-AzConfluentConnector` to create connectors
  - New cmdlet `Get-AzConfluentConnector` to retrieve connector details
  - New cmdlet `Remove-AzConfluentConnector` to delete connectors
  - New cmdlet `Update-AzConfluentConnector` to update connector configuration
  - New cmdlet `Set-AzConfluentConnector` to manage connector state
* Updated to API version 2025-08-18-preview
* Updated swagger specification commit to da3e3a42110d96609505c4bcb5b4d768341203a8

## Version 0.3.0
* Introduced various new features by upgrading code generator. Please see detail [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).

## Version 0.2.2
* Upgraded nuget package to signed package.

## Version 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.2.0
* Removed New-AzConfluentMarketplaceAgreement
    - Set-AzMarketplaceTerms (Az.MarketplaceOrdering) has same function.
* Added feature for Remove-AzConfluentOrganization
* Enabled interactive to get consent from user to confirm invoke remove operation.

## Version 0.1.0
* First preview release for module Az.Confluent

