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

## Version 1.3.2
* Updated signed 3rd party assembly NLog.dll to PSGallery

## Version 1.3.1
* Removed the outdated deps.json file.

## Version 1.3.0
* Updated ADLS dataplane SDK to 1.2.4-alpha. Changes:https://github.com/Azure/azure-data-lake-store-net/blob/preview-alpha/CHANGELOG.md#version-124-alpha

## Version 1.2.8
* Added breaking change description for `Export-AzDataLakeStoreItem` and `Import-AzDataLakeStoreItem`
* Added option of Byte encoding for `New-AzDataLakeStoreItem`, `Add-AzDAtaLakeStoreItemContent`, and `Get-AzDAtaLakeStoreItemContent`

## Version 1.2.7
* Added reference to System.Buffers explicitly in csproj and psd1.

## Version 1.2.6
* Update references in .psd1 to use relative path

## Version 1.2.5
* Update documentation of Get-AzDataLakeStoreDeletedItem and Restore-AzDataLakeStoreDeletedItem

## Version 1.2.4
* Update ADLS SDK version (https://github.com/Azure/azure-data-lake-store-net/blob/preview-alpha/CHANGELOG.md#version-123-alpha), brings following fixes
* Avoid throwing exception while unable to deserialize the creationtime of the trash or directory entry.
* Expose setting per request timeout in adlsclient
* Fix passing the original syncflag for badoffset recovery
* Fix EnumerateDirectory to retrieve continuation token once response is checked
* Fix Concat Bug

## Version 1.2.3
* Fix account validation so that accounts with "-" can be passed without domain

## Version 1.2.2
* Fix hanging of Get-DataLakeStoreDeletedItem for any errors or remote exceptions.
* Fixed miscellaneous typos across module

## Version 1.2.1
* Update the ADLS sdk to use httpclient, integrate dataplane testing with azure framework

## Version 1.2.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.1.0
* Add cmdlets for ADL deleted item enumerate and restore

## Version 1.0.2
* Fix issue with ADLS endpoint when using MSI
    - More information here: https://github.com/Azure/azure-powershell/issues/7462
* Update incorrect online help URLs

## Version 1.0.1
* Update the sdk version of dataplane to 1.1.14 for SDK fixes.
    - Fix handling of negative acesstime and modificationtime for getfilestatus and liststatus, Fix async cancellation token

## Version 1.0.0
* General availability of `Az.DataLakeStore` module
* Update the sdk version of dataplane to 1.1.13
* Change the type of Encoding parameter to system.Encoding for commandlets: New-AzureRmDataLakeStoreItem, Add-AzureRmDataLakeStoreItemContent, Get-AzureRmDataLakeStoreItemContent to make it compatible to .netcore
* Removed deprecated -Tags alias from New/Set-AzDataLakeStoreAccount
* Removed deprecated properties from PSDataLakeStoreAccountBasic model
