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
* Added warning messages for planning to disable soft delete
* Added warning messages for planning to remove attribute SecretValueText

## Version 2.0.0
* Removed two aliases: `New-AzKeyVaultCertificateAdministratorDetails` and `New-AzKeyVaultCertificateOrganizationDetails`
* Enabled soft delete by default when creating a key vault
* Network rules can be set to govern the accessibility from specific network locations when creating a key vault
* Added support to bring your own key (BYOK)
    - `Add-AzKeyVaultKey` supports generating a key exchange key
    - `Get-AzKeyVaultKey` supports downloading a public key in PEM format
* Updated the "KeyOps" part of the help document of `Add-AzKeyVaultKey`

## Version 1.6.0
* Added a new cmdlet `Update-AzKeyVault` that can enable soft delete and purge protection on a vault
* Added support to Microsoft.PowerShell.SecretManagement [#11178]
* Fixed error in the examples of `Remove-AzKeyVaultManagedStorageSasDefinition` [#11479]
* Added support to private endpoint

## Version 1.5.2
* Added breaking change attributes to `New-AzKeyVault`

## Version 1.5.1
* Fixed duplicated text for Add-AzKeyVaultKey.md

## Version 1.5.0
* Add Name alias to VaultName attribute to make Remove-AzureKeyVault consistent with New-AzureKeyVault.

## Version 1.4.0
* Update references in .psd1 to use relative path
* Fixed error accessing value that is potentially not set
* Elliptic Curve Cryptography Certificate Management
    - Added support to specify the Curve for Certificate Policies

## Version 1.3.1
* Fixed miscellaneous typos across module

## Version 1.3.0
* Added support to specify the KeySize for Certificate Policies

## Version 1.2.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

## Version 1.1.0
* Added wildcard support to KeyVault cmdlets

## Version 1.0.2
* Fix tagging on Set-AzKeyVaultSecret

## Version 1.0.1
* Update incorrect online help URLs

## Version 1.0.0
* General availability of `Az.KeyVault` module
* Remove deprecated PurgeDisabled property from PS models
