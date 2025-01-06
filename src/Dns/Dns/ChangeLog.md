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

## Version 1.3.0
* Added `NAPTR` record type support in cmdlets.

## Version 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.2.0
* Added cmdlets:
    - `Get-AzDnsDnssecConfig`
    - `New-AzDnsDnssecConfig`
    - `Remove-AzDnsDnssecConfig`
* Added three new record types, `DS`, `TLSA` and `NAPTR`.

## Version 1.1.3
* Removed length validation for DNS TXT record to make it consistent with Azure CLI and Azure portal.

## Version 1.1.2
* Update references in .psd1 to use relative path

## Version 1.1.1
* Fixed a typo in `Set-AzDnsZone` help examples.

## Version 1.1.0
* Automatic DNS NameServer Delegation
    - Create DNS zone cmdlet accepts parent zone name as additional optional parameter.
    - Adds NS records in the parent zone for newly created child zone.

## Version 1.0.0
* General availability of `Az.Dns` module
