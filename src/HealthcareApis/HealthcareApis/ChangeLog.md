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

## Version 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 2.0.0
* Migrated module to generated codebase.
* Added cmdlets:
    - New/Get/Update/Remove-AzHealthcareApisService
    - New/Get/Update/Remove-AzHealthcareApisWorkspace
    - New/Get/Update/Remove-AzHealthcareFhirService
    - New/Get/Update/Remove-AzHealthcareDicomService
    - New/Get/Update/Remove-AzHealthcareIoTConnector
    - New/Get/Remove-AzHealthcareIotConnectorFhirDestination
    - Get-AzHealthcareFhirDestination

## Version 1.3.2
* HealthcareApis cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

## Version 1.3.1
* Added support for Acr LoginServers

## Version 1.2.0
* Added support for customer managed keys

## Version 3.0.0
* Updated the SDK version to 3.0.0
* Added support for Private Link

## Version 1.1.0
* Updated the SDK version to 1.1.0
* Added support for Export settings and Managed Identity

## Version 1.0.2
* Access policies are no longer defaulted to the current principal

## Version 1.0.1
* Update references in .psd1 to use relative path
* Exception Handling

## Version 1.0.0
* Updated the powershell version to 1.0.0
* Updated the SDK version to 1.0.2
* Update in tests to refer to new SDK version
* Updated the output structure from nested to flattened.

## Version 0.1.2
* Added Exception Handling around KeyNotFoundException


## Version 0.1.1
* Added Error Handling in all cmdlets
* Fixed few typos
* Enable Set-AzHealthcareApisService to allow updating tags.
* Fixed bug around inaccurate kind.
* Added Exception Handling around KeyNotFoundException.

## Version 0.1.0
* Added following CRUD operation cmdlets to HealthcareApis service. 
  * New-AzHealthcareApisService, Set-AzHealthcareApisService, Get-AzHealthcareApisService, Remove-AzHealthcareApisService
