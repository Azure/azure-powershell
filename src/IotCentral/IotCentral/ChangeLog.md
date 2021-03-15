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
* Update our Azure PowerShell command to use our latest released .NET package with the version of 3.1.0.

## Version 0.8.0
* Allow pricing information to be updated using Set-AzIoTCentralApp command.

## Version 0.7.4
* Updated SDK version to throw Cloud Exception with error details. Update default SKU to be ST2.

## Version 0.7.3
* This release adds new skus: ST0, ST1, ST2 for IotCentral.

## Version 0.7.2
* Update references in .psd1 to use relative path.
* Remove subdomain and resource name checks for create new IotCentral application, it will be handled by resource provider for idempotent.

## Version 0.7.1
* Added subdomain parameter to Set-AzureRmIoTCentralApp for updating subdomain.
