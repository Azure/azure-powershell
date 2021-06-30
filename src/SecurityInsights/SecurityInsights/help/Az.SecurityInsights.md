---
Module Name: Az.SecurityInsights
Module Guid: 453d4fb9-65ec-4cf1-8358-6a0fbd995d19
Download Help Link: https://docs.microsoft.com/powershell/module/az.securityinsights
Help Version: 0.1.0
Locale: en-US
---

# Az.SecurityInsights Module
## Description
Microsoft Azure Sentinel is a scalable, cloud-native, security information event management (SIEM) and security orchestration automated response (SOAR) solution. Azure Sentinel delivers intelligent security analytics and threat intelligence across the enterprise, providing a single solution for alert detection, threat visibility, proactive hunting, and threat response.<br/>
The Azure Sentinel PowerShell module (Az.SecurityInsights) allows you to interact with the following  components: * Incidents
* Analytics Rules (Alert Rules)
* Analytics Rules Templates
* Analytics Rules Actions (like attaching an Azure Logic Apps Playbooks to your rule)
* Bookmarks
* Data Connectors
* Comments

All cmdlets are able to work with a connection object to provide your resourceGroupName and workspaceName like in the following example:

## Az.SecurityInsights Cmdlets
### [Get-AzSentinelAlertRule](Get-AzSentinelAlertRule.md)
Gets a specific or all Analytic Rules (Alert Rule).

### [Get-AzSentinelAlertRuleAction](Get-AzSentinelAlertRuleAction.md)
Gets an Automated Response (Alert Rule Action) for an Analytics Rule, like an Azure Logic Apps Playbook.<br/>
Azure Sentinel Automation Rules will be supported in the future.

*Note: This requires a parameter value of "AlertRuleId"*

### [Get-AzSentinelAlertRuleTemplate](Get-AzSentinelAlertRuleTemplate.md)
Gets an Analytic Rule Template.

### [Get-AzSentinelBookmark](Get-AzSentinelBookmark.md)
Gets a Bookmark. <br/>
A Bookmark is used to preserve queries, comments and tags for a specific incident.<br/>
You create the Bookmark first and then add it to an incident.

### [Get-AzSentinelDataConnector](Get-AzSentinelDataConnector.md)
Gets a Data Connector. <br/><br/>
Please note that automation support is only available for the following data connectors:
* AADDataConnector
* AATPDataConnector
* ASCDataConnector
* AwsCloudTrailDataConnector
* MCASDataConnector
* MDATPDataConnector
* OfficeDataConnector
* TIDataConnector

### [Get-AzSentinelIncident](Get-AzSentinelIncident.md)
Get one or more Azure Sentinel Incidents.

### [Get-AzSentinelIncidentComment](Get-AzSentinelIncidentComment.md)
Gets an Incident Comment.

### [New-AzSentinelAlertRule](New-AzSentinelAlertRule.md)
Create an Analytics Rule (Alert Rule).

### [New-AzSentinelAlertRuleAction](New-AzSentinelAlertRuleAction.md)
Add an Automated Response to an Analytic Rule.

### [New-AzSentinelBookmark](New-AzSentinelBookmark.md)
Creates a Bookmark for a specific incident.<br/>

### [New-AzSentinelDataConnector](New-AzSentinelDataConnector.md)
Creates a Data Connector.

### [New-AzSentinelIncident](New-AzSentinelIncident.md)
Creates an Incident.

### [New-AzSentinelIncidentComment](New-AzSentinelIncidentComment.md)
Adds a Comment to an Incident.

### [New-AzSentinelIncidentOwner](New-AzSentinelIncidentOwner.md)
Create Incident Owner object to update an incident owner.

### [Remove-AzSentinelAlertRule](Remove-AzSentinelAlertRule.md)
Deletes an Analytics Rule (AlertRule)

### [Remove-AzSentinelAlertRuleAction](Remove-AzSentinelAlertRuleAction.md)
Removes an Automated Response from an Analytic Rule.

### [Remove-AzSentinelBookmark](Remove-AzSentinelBookmark.md)
Deletes a Bookmark.

### [Remove-AzSentinelDataConnector](Remove-AzSentinelDataConnector.md)
Removes a Data Connector.

### [Remove-AzSentinelIncident](Remove-AzSentinelIncident.md)
Deletes an Incident.

### [Update-AzSentinelAlertRule](Update-AzSentinelAlertRule.md)
Updates an Analytic Rule (Alert Rule).

### [Update-AzSentinelAlertRuleAction](Update-AzSentinelAlertRuleAction.md)
Updates an Automated Response (Alert Rule Action).

### [Update-AzSentinelBookmark](Update-AzSentinelBookmark.md)
Updates a Bookmark.

### [Update-AzSentinelDataConnector](Update-AzSentinelDataConnector.md)
Updates a Data Connector.

### [Update-AzSentinelIncident](Update-AzSentinelIncident.md)
Updates an Incident

