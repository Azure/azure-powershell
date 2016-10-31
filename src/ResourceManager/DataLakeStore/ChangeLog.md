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

## Version 3.0.0
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