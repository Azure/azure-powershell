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

## Version 2.0.3
* Migrated Attestation SDK to generated SDK
    - Removed "Microsoft.Azure.Management.Attestation" Version "0.12.0-preview" PackageReference
    - Added Attestation.Management.Sdk ProjectReference

## Version 2.0.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 2.0.1
* Fixed vulnerability https://github.com/advisories/GHSA-8g9c-28fc-mcx2

## Version 2.0.0
* [Breaking Change] Replaced `New/Remove/Get-AzAttestation` with `New/Remove/Get-AzAttestationProvider`
* Added `Get-AzAttestationDefaultProvider` and `Update-AzAttestationProvider`
* Upgraded API version from 2018-09-01-preview to 2020-10-01

## Version 1.0.0
* General availability of `Az.Attestation` module

## Version 0.1.8
* Added default provider support to `Az.Attestation` module
    - Added `Location` and `DefaultProvider` to `Get-AzAttestation`
    - Added `Location` and `DefaultProvider` to policy signer management cmdlets
    - Added `Location` and `DefaultProvider` to policy management cmdlets
* Updated claim name from `aas-policyCertificate` to `maa-policyCertificate` for policy signer cmdlets

## Version 0.1.7
* Added text based policy support to policy cmdlets

## Version 0.1.6
* Improved error messages for server response codes 400 and 401
* Improved example code included in documentation files
* Added three additional required assemblies to Az.Attestation.psd1

## Version 0.1.5
* Added policy signer management cmdlets to `Az.Attestation` module
* Added `Location` and `Tag` to `New-AzAttestation`

## Version 0.1.4
* Added policy management cmdlets to `Az.Attestation` module

## Version 0.1.3
* Update references in .psd1 to use relative path

## Version 0.1.2
* Fixed miscellaneous typos across module

## Version 0.1.1
* Fix typo in `PSAttestation` type with property `AttestUri`
* Update .Net SDK with newer version

## Version 0.1.0
* General availability of `Az.Attestation` module
