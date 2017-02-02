﻿<!--
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

## Version 3.3.0
* Updated help for all cmdlets to include output as well as more descriptions of parameters and the inclusion of aliases.
* Update New-AdlStore and Set-AdlStore to support commitment tier options for the service.
* Added OutputType mismatch warnings to all cmdlets with incorrect OutputType attributes. These will be fixed in a future breaking change release.
* Add Diagnostic logging support to Import-AdlStoreItem and Export-AdlStoreItem. This can be enabled through the following parameters:
    * -Debug, enables full diagnostic logging as well as debug logging to the PowerShell console. Most verbose options
    * -DiagnosticLogLevel, allows finer control of the output than debug. If used with debug, this is ignored and debug logging is used.
    * -DiagnosticLogPath, optionally specify the file to write diagnostic logs to. By default it is written to a file under %LOCALAPPDATA%\AdlDataTransfer
* Added support to New-AdlStore to explicitly opt-out of account encryption. To do so, create the account with the -DisableEncryption flag.

## Version 3.2.0
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