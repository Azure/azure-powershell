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
* Upgraded the module to support the Microsoft.Datadog 2025-12-26-preview API version, adding new cmdlets:
    - `Get-AzDatadogMonitorDefaultApplicationKey` to get the default Datadog application key for a monitor.
    - `Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS` to return the latest SaaS (Software as a Service) resource linked to the Datadog organization of a monitor.
    - `Invoke-AzDatadogLinkDatadogMonitorResourceSaaS` to link a new SaaS (Software as a Service) resource to the Datadog organization of a monitor.
    - `Invoke-AzDatadogManageMonitorSreAgentConnector` to manage connectors for the SRE (Site Reliability Engineering) Agent.
    - `Initialize-AzDatadogSaaSOperationGroupResource` to resolve a token and activate a Datadog SaaS (Software as a Service) resource.

## Version 0.3.0
* Added support of Monitored subscription and made it compatible with latest OpenAPI spec. Please see details [here](https://github.com/Azure/azure-rest-api-specs/blob/main/specification/datadog/resource-manager/Microsoft.Datadog/stable/2025-06-11/datadog.json).

## Version 0.2.0
* Introduced various new features by upgrading code generator. Please see detail [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).

## Version 0.1.2
* Upgraded nuget package to signed package.

## Version 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 0.1.0
* First preview release for module Az.Datadog

