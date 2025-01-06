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

## Version 1.7.0
* Added new cmdlets for defender for storage

## Version 1.6.2
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.6.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.6.0
* Added new cmdlets for Security Connectors
* Added new cmdlets for ApiCollections Security

## Version 1.5.1
* Fixed bug for `Set-AzSecurityPricing`

## Version 1.5.0
* Fixed some minor issues
* Updated Pricing cmdlets to support extensions
    `Get-AzSecurityPricing`
    `Set-AzSecurityPricing`

## Version 1.4.0
* Updated Alerts cmdlets:
    `Get-AzSecurityAlert`
    `Set-AzSecurityAlert`
* Moving Security Contacts to be based on the latest API version '2020-01-01-preview' with backward compatibility support
## Version 1.3.0
* Added new cmdlet: `Get-AzSecuritySolution`
* Added Alerts Suppression Rules to cmdlets:
    `Get-AlertsSuppressionRule`
    `Remove-AlertsSuppressionRule`
    `Set-AlertsSuppressionRule`
    `New-AzAlertsSuppressionRuleScope`

## Version 1.3.0
* Added new cmdlets for security  SecuritySolutionsReferenceData API

## Version 1.2.0
* Added new cmdlets for security Automations API

## Version 1.1.1
* Updated Security .NET SDK package reference to version 3.0.0

## Version 1.0.0
* General availability of `Az.Security` module
* Changed the name of `Get-AzRegulatoryComplainceAssessment` to `Get-AzRegulatoryComplianceAssessment` to fix typo

## Version 0.11.0
* Fix typo in printing SQL vulnerability assessment scan results

## Version 0.10.0
* Added Sql Vulnerability Assessment cmdlets for  IAAS: 
    `Get-AzSecuritySqlVulnerabilityAssessmentScanRecord`
    `Get-AzSecuritySqlVulnerabilityAssessmentScanResult`
    `Add-AzSecuritySqlVulnerabilityAssessmentBaseline`
    `Remove-AzSecuritySqlVulnerabilityAssessmentBaseline`
    `Get-AzSecuritySqlVulnerabilityAssessmentBaseline`
    `Set-AzSecuritySqlVulnerabilityAssessmentBaseline`

## Version 0.9.0
* Added breaking change notification in AzSecurityAlert:
    `Get-AzSecurityAlert`
    `Set-AzSecurityAlert`
* Added new cmdlets: 
    `Get-AzSecuritySecureScore`
    `Get-AzSecuritySecureScoreControl`
    `Get-AzSecuritySecureScoreControlDefinition`

## Version 0.8.0
* Added new cmdlet: `Get-AzSecurityAdaptiveApplicationControl` and `Get-AzSecurityAdaptiveApplicationControlGroup`
* Added new cmdlet: `Get-AzSecurityTopology`, `Get-AzSecurityAdaptiveNetworkHardening` and `Add-AzSecurityAdaptiveNetworkHardening`

## Version 0.7.10
* Added new cmdlet: `Get-AzAllowedConnection`
* Added new cmdlet: `Get-AzSecurityTopology`

## Version 0.7.9
* Add new cmdlets: 
    `Get-AzSecurityAssessment`,
    `Set-AzSecurityAssessment`,
    `Remove-AzSecurityAssessment`,
    `Get-AzSecurityAssessmentMetadata`,
    `Set-AzSecurityAssessmentMetadata`,
    `Remove-AzSecurityAssessmentMetadata`,
    `Get-AzSecuritySubAssessment`

## Version 0.7.9
* Added new cmdlets: 
    - `Get-AzSecuritySetting`
    - `Set-AzSecuritySetting`

## Version 0.7.8
* Add new cmdlets:
    `Get-AzRegulatoryComplianceStandard`, 
    `Get-AzRegulatoryComplianceControl`, 
    `Get-AzRegulatoryComplainceAssessment`
* Add new API for IoTSecuritySolution, IoTSecuritySolutionAnalytics and DeviceSecurityGroups services
* Support management of SQL Information Protection Policy.

## Version 0.7.7
* Update references in .psd1 to use relative path

## Version 0.7.6
* Fixed miscellaneous typos across module
* Add CosmosDB ATP to md files

## Version 0.7.5
* Use NextLink for return maximum of 1500 security alerts in command Get-AzSecurityAlert

## Version 0.7.4
* Deprecate ResourceGroupName parameter in commands: Get-AzSecurityPricing and Set-AzSecurityPricing

## Version 0.7.3
* Split `Set-AzSecurityThreatProtection` into two new cmdlets:
    - `Disable-AzSecurityAdvancedThreatProtection`
    - `Enable-AzSecurityAdvancedThreatProtection`
* Rename `Get-AzSecurityThreatProtection` to `Get-AzSecurityAdvancedThreatProtection`

## Version 0.7.2
* Add new cmdlets: Get-AzSecurityThreatProtection and Set-AzSecurityThreatProtection

## Version 0.7.0
* Update Set-AzSecurityContact. Phone, AlertAdmin, NotifyOnAlert parameters are no longer mandatory
