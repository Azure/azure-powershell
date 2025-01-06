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

## Version 0.13.0
* Fixed output type of cmdlet

## Version 0.12.0
* Corrected function that only worked on Windows.
* Prevented unexpected value changes where parameters that were never set are unchanged but replayed back as part of Set-AzConnectedKubernetes processing.

## Version 0.11.1
* Fixed environment variable usage
* Got rid of deprecated module and improved logging

## Version 0.11.0
* Added support for Workload Identity Federation and OIDC Issuer features to the ConnectedKubernetes cmdlets.
* Added support for arc gateway feature in cmdlet New-AzConnectedKubernetes.
* Added Set-AzConnectedKubernetes cmdlet to support updateing arc gateway features on existing resource.

## Version 0.10.3
* Fixed secrets exposure in example documentation.

## Version 0.10.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.10.1
* Fixed custom location enable flag issue.

## Version 0.10.0
* Added support for custom locations id and correlation Id.
## Version 0.9.0
* Used Env:HELM_CLIENT_PATH if user defined in cmdlet New-AzConnectedKubernetes and Remove-AzConnectedKubernetes.
* Added support for downloading signed helm v3.6.3 for Windows in cmdlet New-AzConnectedKubernetes and Remove-AzConnectedKubernetes.
* Moved helm release namespace to "azure-arc-release" in cmdlet New-AzConnectedKubernetes and Remove-AzConnectedKubernetes.
* Cleaned "azure-arc-release" namespace after disconnecting in cmdlet Remove-AzConnectedKubernetes.

## Version 0.8.0
* Added optional configs (-HttpProxy, -HttpsProxy, -NoProxy, -ProxyCert) for connection behind outbound proxy server.
* Added optional configs (-ContainerLogPath, -DisableAutoUpgrade, -NoWait, -OnboardingTimeout).
* Fixed invalid URI issue with display name of location.
* Fixed response can't be parsed issue with UseBasicParsing.

## Version 0.7.1
* Made `New-AzConnectedKubernetes` support PowerShell 5.

## Version 0.7.0
* Added the logic that prompt legal information when users call the parameter "-AzureHybridBenefit" in `New-AzConnectedKubernetes` or `Update-AzConnectedKubernetes`.

## Version 0.6.0
* Added a related legal clause that users need to agree to when using the cmdlet `New-AzConnectedKubernetes` in order to successfully create.

## Version 0.5.0
* Upgraded api version to 2022-10-01-preview

## Version 0.4.0
* Fixed the issue that Azure Arc cannot connect to Kubernetes[#19080]

## Version 0.3.0
* Updated api-version of ConnectedKubernetes to 2021-10-01
* Create new cmdlet: Get-AzConnectedKubernetesUserCredential.
* Update the New-AzConnectedKubernetes to support helm from version 3.7+

## Version 0.2.0
* Updated api-version of ConnectedKubernetes to 2021-03-01

## Version 0.1.0
* The first preview release

