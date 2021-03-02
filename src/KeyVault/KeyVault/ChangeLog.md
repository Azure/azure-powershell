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

## Version 3.4.0
* Supported specifying key type and curve name when importing keys via a BYOK file

## Version 3.3.1
* Fixed an issue in Secret Management module

## Version 3.3.0
* Added a new parameter `-AsPlainText` to `Get-AzKeyVaultSecret` to directly return the secret in plain text [#13630]
* Supported selective restore a key from a managed HSM full backup [#13526]
* Fixed some minor issues [#13583] [#13584]
* Added missing return objects of `Get-Secret` in SecretManagement module
* Fixed an issue that may cause vault to be created without default access policy [#13687]

## Version 3.2.0
* Supported "all" as an option when setting key vault access policies
* Supported new version of SecretManagement module [#13366]
* Supported ByteArray, String, PSCredential and Hashtable for `SecretValue` in SecretManagementModule [#12190]
* [Breaking change] redesigned the API surface of cmdlets related to managed HSM.

## Version 3.1.0
* Supported updating key vault tag

## Version 3.0.0
* [Breaking Change] Deprecated parameter DisableSoftDelete in `New-AzKeyVault` and EnableSoftDelete in `Update-AzKeyVault`
* [Breaking Change] Removed attribute SecretValueText to avoid displaying SecretValue directly [#12266]
* Supported new resource type: managed HSM
    - CRUD of managed HSM and cmdlets to operate keys on managed HSM
    - Full HSM backup/restore, AES key creation, security domain backup/restore, RBAC

## Version 2.2.1
* Provided the detailed date of removing property SecretValueText

## Version 2.2.0
* Added support for RBAC authorization [#10557]
* Enhanced error handling in `Set-AzKeyVaultAccessPolicy` [#4007]

## Version 2.1.0
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
