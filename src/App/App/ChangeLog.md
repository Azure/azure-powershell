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

## Version 2.0.0
* The parameters of the `New-AzContainerApp`, `New-AzContainerAppJob`, `Update-AzContainerApp`, `Update-AzContainerAppJob` commands have changed.
  * `IdentityType` has been removed. `EnableSystemAssignedIdentity` is used to enable/disable system-assigned identities.
  * The type of `UserAssignedIdentity` is simplified to an array of strings that is used to specify the user's assigned identity.

## Version 1.1.0
* Added breaking change messages:
  * `New-AzContainerApp`
  * `New-AzContainerAppJob`
  * `Update-AzContainerApp`
  * `Update-AzContainerAppJob`
* Fixed an issue that caused Get/New-Az* cmdlets with returned objects to incorrectly expose the parameter [-PassThru].
  * `Get-AzContainerApp`
  * `Get-AzContainerAppAuthToken`
  * `Get-AzContainerAppDiagnosticRoot`
  * `New-AzContainerAppManagedCert`

## Version 1.0.1
* Fixed secrets exposure in example documentation.

## Version 1.0.0
* General availability for module Az.App.
* Upgraded api version to 2023-05-01.

## Version 0.1.1
* Added enrich example for the cmdlet `New-AzContainerAppScaleRuleObject`.[#20334]

## Version 0.1.0
* First preview release for module Az.App

