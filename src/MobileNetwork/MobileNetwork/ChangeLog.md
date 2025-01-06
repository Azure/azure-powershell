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

## Version 0.4.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.4.0
* Three cmdlets were added: `Remove-AzMobileNetworkBulkSimDelete`, `Update-AzMobileNetworkBulkSimUpload`, `Update-AzMobileNetworkBulkSimUploadEncrypted`.

## Version 0.3.0
* Three cmdlets were added: `Deploy-AzMobileNetworkReinstallPacketCoreControlPlane`, `Deploy-AzMobileNetworkRollbackPacketCoreControlPlane`, `Trace-AzMobileNetworkCollectPacketCoreControlPlaneDiagnosticPackage`.
* Improved message shown to user when deleting site, to indicate this will affect dependent resources.
* Made further parameters optional for New-AzMobileNetworkSite when creating on an ASE.

## Version 0.2.0
* Extended the function of the cmdlet `New-AzMobileNetworkSite` -- allowed users to quickly deploy a new site under an existing mobile network using optional parameters, reducing the number of commands they need to execute.

## Version 0.1.1
* The `Update-AzMobileNetwork*` cmdlets has been improved to support more parameter changes.

## Version 0.1.0
* First preview release for module Az.MobileNetwork

