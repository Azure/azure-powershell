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
* Introduction of deprecation warning for nested properties for all ARM resources. Nested properties will be removed in a future release and all properties will be moved one level up.
* Removed the ability to set encryption in Set-AzureRMDataLakeStoreAccount (never was supported)
* Added ability to enable/disable firewall rules and the trusted id providers during Set-AzureRMDataLakeStoreAccount
* Added a new cmdlet: Set-AzureRMDataLakeStoreItemExpiry, which allows the user to set or remove the expiration for files (not folders) in their ADLS account.
* Small fix for friendly date properties to pivot off UTC time instead of local time, ensuring standard time reporting.

## Version 3.1.0
* Improvements to import and export data cmdlets
    - Drastically increased performance for distributed download scenarios, where multiple sessions are running across many clients targeting the same ADLS account.
    - Better error handling and messaging for both upload and download scenarios.
* Full Firewall rules management CRUD
    - The below cmdlets can be used to manage firewall rules for an ADLS account:
    - Add-AzureRMDataLakeStoreFirewallRule
    - Set-AzureRMDataLakeStoreFirewallRule
    - Get-AzureRMDataLakeStoreFirewallRule
    - Remove-AzureRMDataLakeStoreFirewallRule
* Full Trusted ID provider management CRUD
    - The below cmdlets can be used to manage trusted identity providers for an ADLS account:
    - Add-AzureRMDataLakeStoreTrustedIdProvider
    - Set-AzureRMDataLakeStoreTrustedIdProvider
    - Get-AzureRMDataLakeStoreTrustedIdProvider
    - Remove-AzureRMDataLakeStoreTrustedIdProvider
* Account Encryption Support
    - You can now encrypt newly created ADLS accounts as well as enable encryption on existing ADLS accounts using the New-AzureRMDataLakeStoreAccount and Set-AzureRMDataLakeStoreAccount cmdlets, respectively.