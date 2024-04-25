---
Module Name: Az.Security
Module Guid: 5e312bb4-9d3a-4c88-94c3-8e5bbb2e3da4
Download Help Link: https://learn.microsoft.com/powershell/module/az.security
Help Version: 0.1.0
Locale: en-US
---

# Az.Security Module
## Description
Azure Security Center gives you control over the security of your Azure subscriptions and other machines that you connected to it outside of Azure.

## Az.Security Cmdlets
### [Add-AzSecurityAdaptiveNetworkHardening](Add-AzSecurityAdaptiveNetworkHardening.md)
Enforces the given rules on the NSG(s) listed in the request

### [Add-AzSecuritySqlVulnerabilityAssessmentBaseline](Add-AzSecuritySqlVulnerabilityAssessmentBaseline.md)
Add SQL vulnerability assessment baseline.

### [Confirm-AzSecurityAutomation](Confirm-AzSecurityAutomation.md)
Validates the security automation model before create or update. Any validation errors are returned to the client

### [Disable-AzIotSecurityAnalyticsAggregatedAlert](Disable-AzIotSecurityAnalyticsAggregatedAlert.md)
Dismiss Iot aggregated alert

### [Disable-AzSecurityAdvancedThreatProtection](Disable-AzSecurityAdvancedThreatProtection.md)
Disables the advanced threat protection policy for a storage / cosmosDB account.

### [Enable-AzSecurityAdvancedThreatProtection](Enable-AzSecurityAdvancedThreatProtection.md)
Enables the advanced threat protection policy for a storage / cosmosDB account.

### [Get-AzAlertsSuppressionRule](Get-AzAlertsSuppressionRule.md)
Gets alerts suppression rules.

### [Get-AzAllowedConnection](Get-AzAllowedConnection.md)
Used to display allowed traffic between resources for the subscription

### [Get-AzDeviceSecurityGroup](Get-AzDeviceSecurityGroup.md)
Get device security group (IoT Hub security)

### [Get-AzDiscoveredSecuritySolution](Get-AzDiscoveredSecuritySolution.md)
Gets security solutions that were discovered by Azure Security Center

### [Get-AzExternalSecuritySolution](Get-AzExternalSecuritySolution.md)
Get external security solution 

### [Get-AzIotSecurityAnalytics](Get-AzIotSecurityAnalytics.md)
Get IoT security analytics

### [Get-AzIotSecurityAnalyticsAggregatedAlert](Get-AzIotSecurityAnalyticsAggregatedAlert.md)
Get IoT security aggregated alert

### [Get-AzIotSecurityAnalyticsAggregatedRecommendation](Get-AzIotSecurityAnalyticsAggregatedRecommendation.md)
Get IoT security aggregated recommendation

### [Get-AzIotSecuritySolution](Get-AzIotSecuritySolution.md)
Get IoT security solution

### [Get-AzJitNetworkAccessPolicy](Get-AzJitNetworkAccessPolicy.md)
Gets the JIT network access policies

### [Get-AzRegulatoryComplianceAssessment](Get-AzRegulatoryComplianceAssessment.md)
Gets regulatory compliance assessments

### [Get-AzRegulatoryComplianceControl](Get-AzRegulatoryComplianceControl.md)
Gets regulatory compliance controls

### [Get-AzRegulatoryComplianceStandard](Get-AzRegulatoryComplianceStandard.md)
Gets regulatory compliance standards

### [Get-AzSecurityAdaptiveApplicationControl](Get-AzSecurityAdaptiveApplicationControl.md)
Gets a list of application control VM/server groups for the subscription.

### [Get-AzSecurityAdaptiveApplicationControlGroup](Get-AzSecurityAdaptiveApplicationControlGroup.md)
Gets an application control VM/server group.

### [Get-AzSecurityAdaptiveNetworkHardening](Get-AzSecurityAdaptiveNetworkHardening.md)
Gets a list of Adaptive Network Hardenings resources in scope of an extended resource.

### [Get-AzSecurityAdvancedThreatProtection](Get-AzSecurityAdvancedThreatProtection.md)
Gets the advanced threat protection policy for a storage / cosmosDB account.

### [Get-AzSecurityAlert](Get-AzSecurityAlert.md)
Gets security alerts that were detected by Azure Security Center

### [Get-AzSecurityApiCollection](Get-AzSecurityApiCollection.md)
Gets an Azure API Management API if it has been onboarded to Microsoft Defender for APIs.
If an Azure API Management API is onboarded to Microsoft Defender for APIs, the system will monitor the operations within the Azure API Management API for intrusive behaviors and provide alerts for attacks that have been detected.

### [Get-AzSecurityAssessment](Get-AzSecurityAssessment.md)
Gets security assessments and their results on a subscription

### [Get-AzSecurityAssessmentMetadata](Get-AzSecurityAssessmentMetadata.md)
Gets security assessments types and metadta in a subscription.

### [Get-AzSecurityAutomation](Get-AzSecurityAutomation.md)
Gets security automations

### [Get-AzSecurityAutoProvisioningSetting](Get-AzSecurityAutoProvisioningSetting.md)
Gets the security automatic provisioning settings

### [Get-AzSecurityCompliance](Get-AzSecurityCompliance.md)
Get the security compliance of a subscription over time

### [Get-AzSecurityConnector](Get-AzSecurityConnector.md)
Retrieves details of a specific security connector

### [Get-AzSecurityConnectorAzureDevOpsOrg](Get-AzSecurityConnectorAzureDevOpsOrg.md)
Returns a monitored Azure DevOps organization resource.

### [Get-AzSecurityConnectorAzureDevOpsOrgAvailable](Get-AzSecurityConnectorAzureDevOpsOrgAvailable.md)
Returns a list of all Azure DevOps organizations accessible by the user token consumed by the connector.

### [Get-AzSecurityConnectorAzureDevOpsProject](Get-AzSecurityConnectorAzureDevOpsProject.md)
Returns a monitored Azure DevOps project resource.

### [Get-AzSecurityConnectorAzureDevOpsRepo](Get-AzSecurityConnectorAzureDevOpsRepo.md)
Returns a monitored Azure DevOps repository resource.

### [Get-AzSecurityConnectorDevOpsConfiguration](Get-AzSecurityConnectorDevOpsConfiguration.md)
Gets a DevOps Configuration.

### [Get-AzSecurityConnectorGitHubOwner](Get-AzSecurityConnectorGitHubOwner.md)
Returns a monitored GitHub owner.

### [Get-AzSecurityConnectorGitHubOwnerAvailable](Get-AzSecurityConnectorGitHubOwnerAvailable.md)
Returns a list of all GitHub owners accessible by the user token consumed by the connector.

### [Get-AzSecurityConnectorGitHubRepo](Get-AzSecurityConnectorGitHubRepo.md)
Returns a monitored GitHub repository.

### [Get-AzSecurityConnectorGitLabGroup](Get-AzSecurityConnectorGitLabGroup.md)
Returns a monitored GitLab Group resource for a given fully-qualified name.

### [Get-AzSecurityConnectorGitLabGroupAvailable](Get-AzSecurityConnectorGitLabGroupAvailable.md)
Returns a list of all GitLab groups accessible by the user token consumed by the connector.

### [Get-AzSecurityConnectorGitLabProject](Get-AzSecurityConnectorGitLabProject.md)
Returns a monitored GitLab Project resource for a given fully-qualified group name and project name.

### [Get-AzSecurityConnectorGitLabSubgroup](Get-AzSecurityConnectorGitLabSubgroup.md)
Gets nested subgroups of given GitLab Group which are onboarded to the connector.

### [Get-AzSecurityContact](Get-AzSecurityContact.md)
Gets security contacts that were configured on this subscription

### [Get-AzSecurityLocation](Get-AzSecurityLocation.md)
Gets the location where Azure Security Center will automatically save data for the specific subscription

### [Get-AzSecurityPricing](Get-AzSecurityPricing.md)
Gets the Azure Defender plans for a subscription in Azure Security Center.

### [Get-AzSecuritySecureScore](Get-AzSecuritySecureScore.md)
Gets security secure scores and their results on a subscription

### [Get-AzSecuritySecureScoreControl](Get-AzSecuritySecureScoreControl.md)
Gets security secure score controls and their results on a subscription

### [Get-AzSecuritySecureScoreControlDefinition](Get-AzSecuritySecureScoreControlDefinition.md)
Gets security secure score control definitions on a subscription

### [Get-AzSecuritySetting](Get-AzSecuritySetting.md)
Get security settings in Azure Security Center

### [Get-AzSecuritySolution](Get-AzSecuritySolution.md)
Get Security Solutions

### [Get-AzSecuritySolutionsReferenceData](Get-AzSecuritySolutionsReferenceData.md)
Get Security Solutions Reference Data

### [Get-AzSecuritySqlVulnerabilityAssessmentBaseline](Get-AzSecuritySqlVulnerabilityAssessmentBaseline.md)
Get SQL vulnerability assessment baseline.

### [Get-AzSecuritySqlVulnerabilityAssessmentScanRecord](Get-AzSecuritySqlVulnerabilityAssessmentScanRecord.md)
Gets SQL vulnerability assessment scan summary.

### [Get-AzSecuritySqlVulnerabilityAssessmentScanResult](Get-AzSecuritySqlVulnerabilityAssessmentScanResult.md)
Gets SQL vulnerability assessment scan results.

### [Get-AzSecuritySubAssessment](Get-AzSecuritySubAssessment.md)
Gets sub assessments results in a subscription.

### [Get-AzSecurityTask](Get-AzSecurityTask.md)
Gets the security tasks that Azure Security Center recommends you to do in order to strengthen your security posture.

### [Get-AzSecurityTopology](Get-AzSecurityTopology.md)
Gets a list of Security Topologies on a subscription

### [Get-AzSecurityWorkspaceSetting](Get-AzSecurityWorkspaceSetting.md)
Gets the configured security workspace settings on a subscription.

### [Get-AzSqlInformationProtectionPolicy](Get-AzSqlInformationProtectionPolicy.md)
Retrieves the effective tenant SQL information protection policy.

### [Invoke-AzSecurityApiCollectionApimOffboard](Invoke-AzSecurityApiCollectionApimOffboard.md)
Offboard an Azure API Management API from Microsoft Defender for APIs.
The system will stop monitoring the operations within the Azure API Management API for intrusive behaviors.

### [Invoke-AzSecurityApiCollectionApimOnboard](Invoke-AzSecurityApiCollectionApimOnboard.md)
Onboard an Azure API Management API to Microsoft Defender for APIs.
The system will start monitoring the operations within the Azure Management API for intrusive behaviors and provide alerts for attacks that have been detected.

### [New-AzAlertsSuppressionRuleScope](New-AzAlertsSuppressionRuleScope.md)
Helper cmdlet to create PSIScopeElement.

### [New-AzDeviceSecurityGroupAllowlistCustomAlertRuleObject](New-AzDeviceSecurityGroupAllowlistCustomAlertRuleObject.md)
Create new allow list custom alert rule for device security group (IoT Security)

### [New-AzDeviceSecurityGroupDenylistCustomAlertRuleObject](New-AzDeviceSecurityGroupDenylistCustomAlertRuleObject.md)
Create new deny list custom alert rule for device security group (IoT Security)

### [New-AzDeviceSecurityGroupThresholdCustomAlertRuleObject](New-AzDeviceSecurityGroupThresholdCustomAlertRuleObject.md)
Create new threshold custom alert rule for device security group (IoT Security)

### [New-AzDeviceSecurityGroupTimeWindowRuleObject](New-AzDeviceSecurityGroupTimeWindowRuleObject.md)
Create new time window rule for device security group (IoT Security)

### [New-AzIotSecuritySolutionRecommendationConfigurationObject](New-AzIotSecuritySolutionRecommendationConfigurationObject.md)
Create new recommendation configuration for iot security solution

### [New-AzIotSecuritySolutionUserDefinedResourcesObject](New-AzIotSecuritySolutionUserDefinedResourcesObject.md)
Create new user defined resources for iot security solution

### [New-AzSecurityAutomation](New-AzSecurityAutomation.md)
Creates new security automation

### [New-AzSecurityAutomationActionObject](New-AzSecurityAutomationActionObject.md)
Creates new security automation action object

### [New-AzSecurityAutomationRuleObject](New-AzSecurityAutomationRuleObject.md)
Creates security automation rule object

### [New-AzSecurityAutomationRuleSetObject](New-AzSecurityAutomationRuleSetObject.md)
Creates security automation rule set object

### [New-AzSecurityAutomationScopeObject](New-AzSecurityAutomationScopeObject.md)
Creates security automation scope object

### [New-AzSecurityAutomationSourceObject](New-AzSecurityAutomationSourceObject.md)
Creates security automation source object

### [New-AzSecurityAwsEnvironmentObject](New-AzSecurityAwsEnvironmentObject.md)
Create an in-memory object for AwsEnvironment.

### [New-AzSecurityAwsOrganizationalDataMasterObject](New-AzSecurityAwsOrganizationalDataMasterObject.md)
Create an in-memory object for AwsOrganizationalDataMaster.

### [New-AzSecurityAwsOrganizationalDataMemberObject](New-AzSecurityAwsOrganizationalDataMemberObject.md)
Create an in-memory object for AwsOrganizationalDataMember.

### [New-AzSecurityAzureDevOpsScopeEnvironmentObject](New-AzSecurityAzureDevOpsScopeEnvironmentObject.md)
Create an in-memory object for AzureDevOpsScopeEnvironment.

### [New-AzSecurityConnector](New-AzSecurityConnector.md)
Create a security connector.
If a security connector is already Created and a subsequent request is issued for the same security connector id, then it will be Created.

### [New-AzSecurityConnectorActionableRemediationObject](New-AzSecurityConnectorActionableRemediationObject.md)
Create an in-memory object for ActionableRemediation.

### [New-AzSecurityConnectorDevOpsConfiguration](New-AzSecurityConnectorDevOpsConfiguration.md)
Create a DevOps Configuration.

### [New-AzSecurityCspmMonitorAwsOfferingObject](New-AzSecurityCspmMonitorAwsOfferingObject.md)
Create an in-memory object for CspmMonitorAwsOffering.

### [New-AzSecurityCspmMonitorAzureDevOpsOfferingObject](New-AzSecurityCspmMonitorAzureDevOpsOfferingObject.md)
Create an in-memory object for CspmMonitorAzureDevOpsOffering.

### [New-AzSecurityCspmMonitorGcpOfferingObject](New-AzSecurityCspmMonitorGcpOfferingObject.md)
Create an in-memory object for CspmMonitorGcpOffering.

### [New-AzSecurityCspmMonitorGithubOfferingObject](New-AzSecurityCspmMonitorGithubOfferingObject.md)
Create an in-memory object for CspmMonitorGithubOffering.

### [New-AzSecurityCspmMonitorGitLabOfferingObject](New-AzSecurityCspmMonitorGitLabOfferingObject.md)
Create an in-memory object for CspmMonitorGitLabOffering.

### [New-AzSecurityDefenderCspmAwsOfferingObject](New-AzSecurityDefenderCspmAwsOfferingObject.md)
Create an in-memory object for DefenderCspmAwsOffering.

### [New-AzSecurityDefenderCspmGcpOfferingObject](New-AzSecurityDefenderCspmGcpOfferingObject.md)
Create an in-memory object for DefenderCspmGcpOffering.

### [New-AzSecurityDefenderForContainersAwsOfferingObject](New-AzSecurityDefenderForContainersAwsOfferingObject.md)
Create an in-memory object for DefenderForContainersAwsOffering.

### [New-AzSecurityDefenderForContainersGcpOfferingObject](New-AzSecurityDefenderForContainersGcpOfferingObject.md)
Create an in-memory object for DefenderForContainersGcpOffering.

### [New-AzSecurityDefenderForDatabasesAwsOfferingObject](New-AzSecurityDefenderForDatabasesAwsOfferingObject.md)
Create an in-memory object for DefenderForDatabasesAwsOffering.

### [New-AzSecurityDefenderForDatabasesGcpOfferingObject](New-AzSecurityDefenderForDatabasesGcpOfferingObject.md)
Create an in-memory object for DefenderForDatabasesGcpOffering.

### [New-AzSecurityDefenderForServersAwsOfferingObject](New-AzSecurityDefenderForServersAwsOfferingObject.md)
Create an in-memory object for DefenderForServersAwsOffering.

### [New-AzSecurityDefenderForServersGcpOfferingObject](New-AzSecurityDefenderForServersGcpOfferingObject.md)
Create an in-memory object for DefenderForServersGcpOffering.

### [New-AzSecurityGcpOrganizationalDataMemberObject](New-AzSecurityGcpOrganizationalDataMemberObject.md)
Create an in-memory object for GcpOrganizationalDataMember.

### [New-AzSecurityGcpOrganizationalDataOrganizationObject](New-AzSecurityGcpOrganizationalDataOrganizationObject.md)
Create an in-memory object for GcpOrganizationalDataOrganization.

### [New-AzSecurityGcpProjectEnvironmentObject](New-AzSecurityGcpProjectEnvironmentObject.md)
Create an in-memory object for GcpProjectEnvironment.

### [New-AzSecurityGitHubScopeEnvironmentObject](New-AzSecurityGitHubScopeEnvironmentObject.md)
Create an in-memory object for GitHubScopeEnvironment.

### [New-AzSecurityGitLabScopeEnvironmentObject](New-AzSecurityGitLabScopeEnvironmentObject.md)
Create an in-memory object for GitLabScopeEnvironment.

### [New-AzSecurityInformationProtectionAwsOfferingObject](New-AzSecurityInformationProtectionAwsOfferingObject.md)
Create an in-memory object for InformationProtectionAwsOffering.

### [Remove-AzAlertsSuppressionRule](Remove-AzAlertsSuppressionRule.md)
Deletes an alerts suppression rule.

### [Remove-AzDeviceSecurityGroup](Remove-AzDeviceSecurityGroup.md)
Delete device security group

### [Remove-AzIotSecuritySolution](Remove-AzIotSecuritySolution.md)
Delete IoT security solution

### [Remove-AzJitNetworkAccessPolicy](Remove-AzJitNetworkAccessPolicy.md)
Deletes a JIT network access policy.

### [Remove-AzSecurityAssessment](Remove-AzSecurityAssessment.md)
Deletes a security assessment result from a subscription.

### [Remove-AzSecurityAssessmentMetadata](Remove-AzSecurityAssessmentMetadata.md)
Deletes a security assessment metadata from a subscription.

### [Remove-AzSecurityAutomation](Remove-AzSecurityAutomation.md)
Deletes security automation

### [Remove-AzSecurityConnector](Remove-AzSecurityConnector.md)
Deletes a security connector.

### [Remove-AzSecurityConnectorDevOpsConfiguration](Remove-AzSecurityConnectorDevOpsConfiguration.md)
Deletes a DevOps Connector.

### [Remove-AzSecurityContact](Remove-AzSecurityContact.md)
Deletes a security contact.

### [Remove-AzSecuritySqlVulnerabilityAssessmentBaseline](Remove-AzSecuritySqlVulnerabilityAssessmentBaseline.md)
Removes SQL vulnerability assessment baseline.

### [Remove-AzSecurityWorkspaceSetting](Remove-AzSecurityWorkspaceSetting.md)
Deletes the security workspace setting for this subscription.

### [Set-AzAlertsSuppressionRule](Set-AzAlertsSuppressionRule.md)
Create or update an alerts suppression rule.

### [Set-AzDeviceSecurityGroup](Set-AzDeviceSecurityGroup.md)
Create or update device security group

### [Set-AzIotSecuritySolution](Set-AzIotSecuritySolution.md)
Create or update IoT security solution

### [Set-AzJitNetworkAccessPolicy](Set-AzJitNetworkAccessPolicy.md)
Updates JIT network access policy.

### [Set-AzSecurityAlert](Set-AzSecurityAlert.md)
Updates a security alert state.

### [Set-AzSecurityAssessment](Set-AzSecurityAssessment.md)
Create or update a security assessment result on a resource

### [Set-AzSecurityAssessmentMetadata](Set-AzSecurityAssessmentMetadata.md)
Creates or updates a security assessment type.

### [Set-AzSecurityAutoProvisioningSetting](Set-AzSecurityAutoProvisioningSetting.md)
Updates automatic provisioning setting

### [Set-AzSecurityContact](Set-AzSecurityContact.md)
Updates a security contact for a subscription.

### [Set-AzSecurityPricing](Set-AzSecurityPricing.md)
Enables or disables Microsoft Defender plans for a subscription in Microsoft Defender for Cloud.

> [!NOTE]
> For CloudPosture (Defender Cloud Security Posture Management), [the agentless extensions](https://techcommunity.microsoft.com/t5/microsoft-defender-for-cloud/enhanced-cloud-security-value-added-with-defender-cspm-s/ba-p/3880746) will not be enabled when using this command. To enable extensions, please use the Azure Policy definition or scripts in the [Microsoft Defender for Cloud Community Repository](https://github.com/Azure/Microsoft-Defender-for-Cloud/tree/main/Policy/Configure-DCSPM-Extensions).

### [Set-AzSecuritySetting](Set-AzSecuritySetting.md)
Update a security setting in Azure Security Center

### [Set-AzSecuritySqlVulnerabilityAssessmentBaseline](Set-AzSecuritySqlVulnerabilityAssessmentBaseline.md)
Sets new SQL vulnerability assessment baseline on a specific database discards old baseline if any exists.

### [Set-AzSecurityWorkspaceSetting](Set-AzSecurityWorkspaceSetting.md)
Updates the workspace settings for the subscription.

### [Set-AzSqlInformationProtectionPolicy](Set-AzSqlInformationProtectionPolicy.md)
Sets the effective tenant SQL information protection policy.

### [Start-AzJitNetworkAccessPolicy](Start-AzJitNetworkAccessPolicy.md)
Invokes a temporary network access request.

### [Update-AzIotSecuritySolution](Update-AzIotSecuritySolution.md)
Update one or more of the following properties in IoT security solution: tags, recommendation configuration, user defined resources

### [Update-AzSecurityConnector](Update-AzSecurityConnector.md)
Update a security connector

### [Update-AzSecurityConnectorAzureDevOpsOrg](Update-AzSecurityConnectorAzureDevOpsOrg.md)
Update monitored Azure DevOps organization details.

### [Update-AzSecurityConnectorAzureDevOpsProject](Update-AzSecurityConnectorAzureDevOpsProject.md)
Update a monitored Azure DevOps project resource.

### [Update-AzSecurityConnectorAzureDevOpsRepo](Update-AzSecurityConnectorAzureDevOpsRepo.md)
Update a monitored Azure DevOps repository resource.

### [Update-AzSecurityConnectorDevOpsConfiguration](Update-AzSecurityConnectorDevOpsConfiguration.md)
Update a DevOps Configuration.

