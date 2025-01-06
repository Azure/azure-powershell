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

## Version 0.7.2
* Fixed issue that `New-AzKubernetesExtension` installing Flux fails with error "Failed to perform resource identity operation" [#22455]

## Version 0.7.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.7.0
* Upgraded API version to 2022-11-01.

## Version 0.6.0
 * Added cmdlets:
   * `Get-AzKubernetesConfigFluxOperationStatus`
   * `Get-AzKubernetesConfigurationFlux`
   * `New-AzKubernetesConfigurationFlux`
   * `Update-AzKubernetesConfigurationFlux`
   * `Remove-AzKubernetesConfigurationFlux`

## Version 0.5.0
* Onboarded cmdlets `New/Update/Get/Remove-AzKubernetesExtension` and `New/Get/Remove-AzKubernetesConfiguration`
* Removed the plural form of parameter HelmOperatorChartValues, OperatorParameters and SshKnownHosts in `New-AzKubernetesConfiguration`

## Version 0.4.0
* Added SshKnownHosts and ConfigurationProtectedSetting to New-AzKubernetesConfiguration.

## Version 0.3.0
* Upgraded API version to 2021-03-01.

## Version 0.2.0
* Upgraded API version from 2019-11-01-preview to 2020-10-01-preview.

## Version 0.1.0
* The first preview release

