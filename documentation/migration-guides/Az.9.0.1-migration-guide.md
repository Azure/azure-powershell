# Migration Guide for Az 9.0.1

## Az.Advisor

### `Set-AzAdvisorConfiguration`

- No longer has output type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData'.
- No longer supports the type 'System.Int32' for parameter 'LowCpuThreshold'.
- No longer supports the type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'InputObjectRgExcludeParameterSet' is no longer the default parameter set.
- The parameter set 'InputObjectLowCpuExcludeParameterSet' has been removed.
- The parameter set 'InputObjectRgExcludeParameterSet' has been removed.

### `Enable-AzAdvisorRecommendation`

- No longer has output type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase'.
- No longer supports the type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'NameParameterSet' is no longer the default parameter set.
- The parameter set 'IdParameterSet' has been removed.
- The parameter set 'InputObjectParameterSet' has been removed.
- The parameter set 'NameParameterSet' has been removed.

### `Disable-AzAdvisorRecommendation`

- No longer has output type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorSuppressionContract'.
- No longer supports the parameter 'Days' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'IdParameterSet' has been removed.
- The parameter set 'NameParameterSet' has been removed.
- The parameter set 'InputObjectParameterSet' has been removed.

### `Get-AzAdvisorRecommendation`

- No longer has output type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'NameParameterSet' is no longer the default parameter set.
- The parameter set 'IdParameterSet' has been removed.
- The parameter set 'NameParameterSet' has been removed.

### `Get-AzAdvisorConfiguration`

- No longer has output type 'Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'RgParameterSet' has been removed.

## Az.Aks

### `Install-AzAksKubectl`

Replaced by Install-AzAksCliTool

#### Before

```powershell
Install-AzAksKubectl
```

#### After

```powershell
Install-AzAksCliTool
```

## Az.ApiManagement

### `Get-AzApiManagement`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

### `Set-AzApiManagement`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

### `Restore-AzApiManagement`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

### `Get-AzApiManagementSsoToken`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

### `Update-AzApiManagementRegion`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- No longer supports the type 'PsApiManagementSku' for parameter 'Sku'.

### `Backup-AzApiManagement`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

### `Add-AzApiManagementRegion`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'PsApiManagementRegion' has changed from 'PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- No longer supports the type 'System.Nullable`1[Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku]' for parameter 'Sku'.

### `New-AzApiManagement`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- No longer supports the type 'System.Nullable`1[Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku]' for parameter 'Sku'.

### `New-AzApiManagementRegion`

- The type of property 'Sku' of type 'PsApiManagementRegion' has changed from 'PsApiManagementSku' to 'System.String'.

### `Remove-AzApiManagementRegion`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

### `Get-AzApiManagementNetworkStatus`

- The type of property 'Sku' of type 'PsApiManagement' has changed from 'PsApiManagementSku' to 'System.String'.

## Az.Attestation

### `Get-AzAttestation`

- Replaced by 'Get-AzAttestationProvider'.

#### Before

```powershell
Get-AzAttestation -Name testprovider1 -ResourceGroupName test-rg
Get-AzAttestation -DefaultProvider
```

#### After

```powershell
Get-AzAttestationProvider -Name testprovider1 -ResourceGroupName test-rg
Get-AzAttestationDefaultProvider
```

### `New-AzAttestation`

- Replaced by 'New-AzAttestationProvider'.

#### Before

```powershell
New-AzAttestation -Name testprovider2 -ResourceGroupName test-rg -Location "East US" -PolicySignersCertificateFile .\cert1.pem
```

#### After

```powershell
New-AzAttestationProvider -Name testprovider2 -ResourceGroupName test-rg -Location "East US" -PolicySigningCertificateKeyPath .\cert1.pem
```

### `Remove-AzAttestation`

- Replaced by 'Remove-AzAttestationProvider'.

#### Before

```powershell
Remove-AzAttestation -Name testprovider -ResourceGroupName test-rg
```

#### After

```powershell
Remove-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg
```

## Az.EventHub

### `Get-AzEventHubAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'.

### `Get-AzEventHubKey`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'.

### `New-AzEventHubAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'.

### `New-AzEventHubKey`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'

### `Remove-AzEventHubAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been changed to 'EventHubName'.

### `Set-AzEventHubAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'

### `Get-AzEventHubConsumerGroup`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'

### `New-AzEventHubConsumerGroup`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been changed to 'EventHubName'.

### `Set-AzEventHubConsumerGroup`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'

### `Remove-AzEventHubConsumerGroup`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. The parameter 'EventHub' has been renamed to 'EventHubName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'

### `Get-AzEventHub`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `New-AzEventHub`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Set-AzEventHub`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Remove-AzEventHub`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Get-AzEventHubNetworkRuleSet`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Set-AzEventHubNetworkRuleSet`

- Parameter 'Name' has been renamed to 'NamespaceName'.

### `New-AzEventHubSchemaGroup`

Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Remove-AzEventHubSchemaGroup`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Get-AzEventHubSchemaGroup`

Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Get-AzEventHubGeoDRConfiguration`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Set-AzEventHubGeoDRConfigurationBreakPair`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Set-AzEventHubGeoDRConfigurationFailOver`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Remove-AzEventHubGeoDRConfiguration`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `New-AzEventHubGeoDRConfiguration`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Test-AzEventHubName`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

## Az.MarketplaceOrdering

### `Get-AzMarketplaceTerms`

Add OfferType parameter

#### Before

```powershell
Get-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"

Publisher         : microsoft-ads
Product           : windows-data-science-vm
Plan              : windows2016
LicenseTextLink   : <LicenseTextLink>
PrivacyPolicyLink : <PrivacyPolicyLink>
Signature         : <Signature>
Accepted          : True
RetrieveDatetime  : <RetrieveDatetime>
```

#### After

```powershell
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine'

```

### `Set-AzMarketplaceTerms`

Remove parameter 'Term'

#### Before

```powershell
$agreementTerms = Get-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
Set-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Terms $agreementTerms -Accept
```

#### After

```powershell
Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Accept
```

## Az.Migrate

### `New-AzMigrateReplicationVaultSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `Get-AzMigrateReplicationVaultSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `Get-AzMigrateReplicationProtectionIntent`

- Has been removed and no alias was found for the original cmdlet name.

### `Get-AzMigrateSupportedOperatingSystem`

- Has been removed and no alias was found for the original cmdlet name.

### `Get-AzMigrateReplicationEligibilityResult`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzMigrateReplicationProtectionIntent`

- Has been removed and no alias was found for the original cmdlet name.

## Az.Monitor

### `Get-AzActivityLogAlert`

- New API version with new set of input/output, please see cmdlet help for detail

### `Remove-AzActivityLogAlert`

- New API version with new set of input/output, please see cmdlet help for detail

### `Set-AzActivityLogAlert`

- Replaced by New-AzActivityLogAlert

### `Disable-AzActivityLogAlert`

- Replaced by Update-AzActivityLogAlert

### `Enable-AzActivityLogAlert`

- Replaced by Update-AzActivityLogAlert

### `New-AzActionGroup`

- Replaced by New-AzActivityLogAlertActionGroupObject

### `Get-AzDiagnosticSettingCategory`

- New API version with new set of input/output, please see cmdlet help for detail

### `Get-AzDiagnosticSetting`

- New API version with new set of input/output, please see cmdlet help for detail

### `New-AzDiagnosticSetting`

- New API version with new set of input/output, please see cmdlet help for detail

### `Remove-AzDiagnosticSetting`

- New API version with new set of input/output, please see cmdlet help for detail

### `Set-AzDiagnosticSetting`

- Replaced by New-AzDiagnosticSetting

### `New-AzDiagnosticDetailSetting`

- Replaced by New-AzDiagnosticSettingLogSettingsObject and New-AzDiagnosticSettingMetricSettingsObject

### `Get-AzSubscriptionDiagnosticSettingCategory`

- Replaced by Get-AzEventCategory

### `Get-AzAutoscaleSetting`

- New API version with new set of input/output, please see cmdlet help for detail

### `Remove-AzAutoscaleSetting`

- New API version with new set of input/output, please see cmdlet help for detail

### `Add-AzAutoscaleSetting`

- Replaced by New-AzAutoscaleSetting

### `New-AzAutoscaleNotification`

- Replaced by New-AzAutoscaleNotificationObject

### `New-AzAutoscaleProfile`

- Replaced by New-AzAutoscaleProfileObject

### `New-AzAutoscaleRule`

- Replaced by New-AzAutoscaleScaleRuleObject

### `New-AzAutoscaleWebhook`

- Replaced by New-AzAutoscaleWebhookNotificationObject

### `Get-AzScheduledQueryRule`

- New API version with new set of input/output, please see cmdlet help for detail

### `New-AzScheduledQueryRuleAlertingAction`

- Removed due to new API version

### `New-AzScheduledQueryRuleAznActionGroup`

- Removed due to new API version

### `New-AzScheduledQueryRule`

- New API version with new set of input/output, please see cmdlet help for detail

### `New-AzScheduledQueryRuleLogMetricTrigger`

- Removed due to new API version

### `New-AzScheduledQueryRuleSchedule`

- Removed due to new API version

### `New-AzScheduledQueryRuleSource`

- Removed due to new API version

### `New-AzScheduledQueryRuleTriggerCondition`

- Removed due to new API version

### `Remove-AzScheduledQueryRule`

- New API version with new set of input/output, please see cmdlet help for detail

### `Set-AzScheduledQueryRule`

- Removed and no replacement.

### `Update-AzScheduledQueryRule`

- New API version with new set of input/output, please see cmdlet help for detail

## Az.Network

### `New-AzFirewall`

- The property 'IdentifyTopFatFlow' of type 'PSAzureFirewall' has been removed.
- The property 'publicIPAddresses' of type 'PSAzureFirewallHubIpAddresses' has been removed.
- No longer supports the parameter 'IdentifyTopFatFlow' and no alias was found for the original parameter name.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'OldIpConfigurationParameterValues' has been removed.
- The parameter set 'IpConfigurationParameterValues' has been removed.

### `New-AzFirewallHubIpAddress`

- The property 'publicIPAddresses' of type 'PSAzureFirewallHubIpAddresses' has been removed.

### `Set-AzFirewall`

- The property 'IdentifyTopFatFlow' of type 'PSAzureFirewall' has been removed.

### `New-AzNetworkManagerAddressPrefixItem`

- A validate set has been added for parameter 'AddressPrefixType'.

### `New-AzNetworkManagerSecurityAdminConfiguration`

- The element type for parameter 'ApplyOnNetworkIntentPolicyBasedService' has been changed from 'System.String' to 'Microsoft.Azure.Commands.Network.NewAzNetworkManagerSecurityAdminConfigurationCommand.NetworkIntentPolicyBasedServiceType'.

### `New-AzNetworkManager`

- The element type for parameter 'NetworkManagerScopeAccess' has been changed from 'System.String' to 'Microsoft.Azure.Commands.Network.NewAzNetworkManagerCommand.NetworkManagerScopeAccessType'.

### `Get-AzFirewall`

- The property 'publicIPAddresses' of type 'PSAzureFirewallHubIpAddresses' has been removed.
- The property 'IdentifyTopFatFlow' of type 'PSAzureFirewall' has been removed.
- The property 'IdentifyTopFatFlow' of type 'PSAzureFirewall' has been removed.

### `New-AzNetworkManagerConnectivityConfiguration`

- A validate set has been added for parameter 'ConnectivityTopology'.

### `Deploy-AzNetworkManagerCommit`

- A validate set has been added for parameter 'CommitType'.

### `New-AzNetworkManagerConnectivityGroupItem`

- A validate set has been added for parameter 'GroupConnectivity'.

### `New-AzNetworkManagerSecurityAdminRule`

- A validate set has been added for parameter 'Protocol'.
- A validate set has been added for parameter 'Direction'.
- A validate set has been added for parameter 'Access'.

## Az.RecoveryServices

### `Get-AzRecoveryServicesBackupContainer`

- No longer supports the parameter 'Status' and no alias was found for the original parameter name.
The parameter set '__AllParameterSets' has been removed.

## Az.SecurityInsights

### `Update-AzSentinelAlertRuleAction`

- No longer has output type 'PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'PSSentinelActionResponse' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ActionId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `New-AzSentinelIncidentOwner`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzSentinelIncidentComment`

- No longer has output type 'PSSentinelIncidentComment'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSentinelBookmark`

- No longer has output type 'PSSentinelBookmark'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelAlertRule`

- No longer has output type 'PSSentinelAlertRule'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'System.String' for parameter 'ProductFilter'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'DisplayNamesExcludeFilter'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'DisplayNamesFilter'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'SeveritiesFilter'.
- No longer supports the parameter 'SuppressionDisabled' and no alias was found for the original parameter name.
- No longer supports the type 'System.Nullable`1[System.TimeSpan]' for parameter 'QueryFrequency'.
- No longer supports the type 'System.Nullable`1[System.TimeSpan]' for parameter 'QueryPeriod'.
- No longer supports the type 'System.String' for parameter 'Severity'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'Tactic'.
- No longer supports the type 'Microsoft.Azure.Management.SecurityInsights.Models.TriggerOperator' for parameter 'TriggerOperator'.
- No longer supports the type 'System.Nullable`1[System.Int32]' for parameter 'TriggerThreshold'.
- No longer supports the type 'PSSentinelAlertRule' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'InputObject' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Get-AzSentinelIncidentComment`

- No longer has output type 'PSSentinelIncidentComment'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ResourceId' has been removed.

### `Get-AzSentinelAlertRuleAction`

- No longer has output type 'PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.
- The parameter set 'ActionId' has been removed.

### `Remove-AzSentinelIncident`

- No longer supports the type 'PSSentinelIncident' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'IncidentId' has been removed.

### `New-AzSentinelBookmark`

- No longer has output type 'PSSentinelBookmark'.
- No longer supports the parameter 'IncidentInfo' and no alias was found for the original parameter name.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'Label'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Remove-AzSentinelAlertRule`

- No longer has output type 'PSSentinelAlertRule'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'PSSentinelAlertRule' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.

### `Remove-AzSentinelAlertRuleAction`

- No longer has output type 'PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'PSSentinelActionResponse' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ActionId' has been removed.

### `Get-AzSentinelAlertRule`

- No longer has output type 'PSSentinelAlertRule'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelDataConnector`

- No longer has output type 'PSSentinelDataConnector'.
- No longer supports the parameter 'DataConnectorId' and no alias was found for the original parameter name.
- No longer supports the type 'PSSentinelDataConnector' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the parameter 'AwsRoleArn' and no alias was found for the original parameter name.
- No longer supports the parameter 'Logs' and no alias was found for the original parameter name.
- No longer supports the parameter 'DiscoveryLogs' and no alias was found for the original parameter name.
- No longer supports the parameter 'Indicators' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'DataConnectorId' has been removed.
- The parameter set 'InputObject' has been removed.
- The parameter set 'ResourceId' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Remove-AzSentinelBookmark`

- No longer has output type 'PSSentinelBookmark'.
- No longer supports the type 'PSSentinelBookmark' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.

### `New-AzSentinelIncident`

- No longer has output type 'PSSentinelIncident'.
- No longer supports the parameter 'Classificaton' and no alias was found for the original parameter name.
- No longer supports the type 'System.String' for parameter 'ClassificationReason'.
- No longer supports the type 'System.Collections.Generic.IList`1[Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncidentLabel]' for parameter 'Label'.
- No longer supports the parameter 'Owner' and no alias was found for the original parameter name.
- No longer supports the type 'System.String' for parameter 'Severity'.
- No longer supports the type 'System.String' for parameter 'Status'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'IncidentId' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `New-AzSentinelAlertRuleAction`

- No longer has output type 'PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ActionId' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSentinelIncident`

- No longer has output type 'PSSentinelIncident'.
- No longer supports the parameter 'OrderBy' and no alias was found for the original parameter name.
- No longer supports the parameter 'Max' and no alias was found for the original parameter name.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'WorkspaceScope' has been removed.
- The parameter set 'IncidentId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Remove-AzSentinelDataConnector`

- No longer has output type 'PSSentinelDataConnector'.
- No longer supports the type 'PSSentinelDataConnector' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'DataConnectorId' has been removed.

### `New-AzSentinelDataConnector`

- No longer has output type 'PSSentinelDataConnector'.
- No longer supports the parameter 'DataConnectorId' and no alias was found for the original parameter name.
- No longer supports the parameter 'AzureActiveDirectory' and no alias was found for the original parameter name.
- No longer supports the parameter 'AzureAdvancedThreatProtection' and no alias was found for the original parameter name.
- No longer supports the parameter 'AzureSecurityCenter' and no alias was found for the original parameter name.
- No longer supports the parameter 'AmazonWebServicesCloudTrail' and no alias was found for the original parameter name.
- No longer supports the parameter 'MicrosoftCloudAppSecurity' and no alias was found for the original parameter name.
- No longer supports the parameter 'MicrosoftDefenderAdvancedThreatProtection' and no alias was found for the original parameter name.
- No longer supports the parameter 'Office365' and no alias was found for the original parameter name.
- No longer supports the parameter 'ThreatIntelligence' and no alias was found for the original parameter name.
- No longer supports the parameter 'AwsRoleArn' and no alias was found for the original parameter name.
- No longer supports the parameter 'Logs' and no alias was found for the original parameter name.
- No longer supports the parameter 'DiscoveryLogs' and no alias was found for the original parameter name.
- No longer supports the parameter 'Indicators' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AzureActiveDirectory' has been removed.
- The parameter set 'AzureAdvancedThreatProtection' has been removed.
- The parameter set 'AzureSecurityCenter' has been removed.
- The parameter set 'AmazonWebServicesCloudTrail' has been removed.
- The parameter set 'MicrosoftCloudAppSecurity' has been removed.
- The parameter set 'MicrosoftDefenderAdvancedThreatProtection' has been removed.
- The parameter set 'Office365' has been removed.
- The parameter set 'ThreatIntelligence' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `New-AzSentinelAlertRule`

- No longer has output type 'PSSentinelAlertRule'.
- No longer supports the parameter 'Scheduled' and no alias was found for the original parameter name.
- No longer supports the parameter 'MicrosoftSecurityIncidentCreation' and no alias was found for the original parameter name.
- No longer supports the parameter 'Fusion' and no alias was found for the original parameter name.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'System.String' for parameter 'ProductFilter'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'DisplayNamesExcludeFilter'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'DisplayNamesFilter'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'SeveritiesFilter'.
- No longer supports the type 'System.Nullable`1[System.TimeSpan]' for parameter 'QueryFrequency'.
- No longer supports the type 'System.Nullable`1[System.TimeSpan]' for parameter 'QueryPeriod'.
- No longer supports the type 'System.String' for parameter 'Severity'.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'Tactic'.
- No longer supports the type 'Microsoft.Azure.Management.SecurityInsights.Models.TriggerOperator' for parameter 'TriggerOperator'.
- No longer supports the type 'System.Nullable`1[System.Int32]' for parameter 'TriggerThreshold'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'FusionAlertRule' has been removed.
- The parameter set 'MicrosoftSecurityIncidentCreationRule' has been removed.
- The parameter set 'ScheduledAlertRule' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSentinelAlertRuleTemplate`

- No longer has output type 'PSSentinelAlertRuleTemplate'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleTemplateId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelIncident`

- No longer has output type 'PSSentinelIncident'.
- No longer supports the parameter 'IncidentID' and no alias was found for the original parameter name.
- No longer supports the type 'PSSentinelIncident' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'System.String' for parameter 'Classification'.
- No longer supports the type 'System.String' for parameter 'ClassificationReason'.
- No longer supports the type 'System.Collections.Generic.IList`1[Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncidentLabel]' for parameter 'Label'.
- No longer supports the parameter 'Owner' and no alias was found for the original parameter name.
- No longer supports the type 'System.String' for parameter 'Severity'.
- No longer supports the type 'System.String' for parameter 'Status'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'IncidentId' has been removed.
- The parameter set 'InputObject' has been removed.
- The parameter set 'ResourceId' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSentinelDataConnector`

- No longer has output type 'PSSentinelDataConnector'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelBookmark`

- No longer has output type 'PSSentinelBookmark'.
- No longer supports the type 'PSSentinelBookmark' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the parameter 'IncidentInfo' and no alias was found for the original parameter name.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'Label'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.
- The parameter set 'InputObject' has been removed.
- The parameter set 'ResourceId' has been removed.
- The parameter set '__AllParameterSets' has been removed.

## Az.ServiceBus

### `Get-AzServiceBusAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Queue' has been renamed to 'QueueName'. Parameter 'Topic' has been renamed to 'TopicName'.

### `Get-AzServiceBusKey`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Queue' has been renamed to 'QueueName'. Parameter 'Topic' has been renamed to 'TopicName'.

### `New-AzServiceBusAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Queue' has been renamed to 'QueueName'. Parameter 'Topic' has been renamed to 'TopicName'.

### `New-AzServiceBusKey`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Queue' has been renamed to 'QueueName'. Parameter 'Topic' has been renamed to 'TopicName'.

### `Remove-AzServiceBusAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Queue' has been renamed to 'QueueName'. Parameter 'Topic' has been renamed to 'TopicName'.

### `Set-AzServiceBusAuthorizationRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Queue' has been renamed to 'QueueName'. Parameter 'Topic' has been renamed to 'TopicName'.

### `Test-AzServiceBusName`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Set-AzServiceBusGeoDRConfigurationBreakPair`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Stop-AzServiceBusMigration`

- Parameter 'Name' has been renamed to 'NamespaceName'. Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Get-AzServiceBusNetworkRuleSet`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Set-AzServiceBusNetworkRuleSet`

- Parameter 'Name' has been replaced by 'NamespaceName'.

### `Get-AzServiceBusQueue`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzServiceBusQueue`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Set-AzServiceBusQueue`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Remove-AzServiceBusQueue`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Get-AzServiceBusRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Topic' has been renamed to 'TopicName'. Parameter 'Subscription' has been renamed to 'SubscriptionName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzServiceBusRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Topic' has been renamed to 'TopicName'. Parameter 'Subscription' has been renamed to 'SubscriptionName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Set-AzServiceBusRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Topic' has been renamed to 'TopicName'. Parameter 'Subscription' has been renamed to 'SubscriptionName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Remove-AzServiceBusRule`

- Parameter 'Namespace' has been renamed to 'NamespaceName'. Parameter 'Topic' has been renamed to 'TopicName'. Parameter 'Subscription' has been renamed to 'SubscriptionName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Get-AzServiceBusTopic`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzServiceBusTopic`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Set-AzServiceBusTopic`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Remove-AzServiceBusTopic`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Get-AzServiceBusSubscription`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'Topic' has been removed to 'TopicName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `New-AzServiceBusSubscription`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'Topic' has been removed to 'TopicName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Set-AzServiceBusSubscription`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'Topic' has been removed to 'TopicName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Remove-AzServiceBusSubscription`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.  Parameter 'Topic' has been removed to 'TopicName'.  Parameter 'ResourceGroupName' would no longer support alias 'ResourceGroup'.

### `Get-AzServiceBusGeoDRConfiguration`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Set-AzServiceBusGeoDRConfigurationFailOver`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `New-AzServiceBusGeoDRConfiguration`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Remove-AzServiceBusGeoDRConfiguration`

- Parameter 'Namespace' has been renamed to 'NamespaceName'.

### `Start-AzServiceBusMigration`

- Parameter 'Name' has been replaced by 'NamespaceName'.

### `Get-AzServiceBusMigration`

- Parameter 'Name' has been replaced by 'NamespaceName'.

### `Complete-AzServiceBusMigration`

- Parameter 'Name' has been replaced by 'NamespaceName'.

### `Remove-AzServiceBusMigration`

- Parameter 'Name' has been replaced by 'NamespaceName'.

## Az.Sql

### `Update-AzSqlServerAdvancedThreatProtectionSetting`

- No longer has output type 'Microsoft.Azure.Commands.Sql.ThreatDetection.Model.ServerThreatDetectionPolicyModel'.
- No longer supports the parameter 'NotificationRecipientsEmails' and no alias was found for the original parameter name.
- No longer supports the parameter 'EmailAdmins' and no alias was found for the original parameter name.
- No longer supports the parameter 'ExcludedDetectionType' and no alias was found for the original parameter name.
- No longer supports the parameter 'StorageAccountName' and no alias was found for the original parameter name.
- No longer supports the parameter 'RetentionInDays' and no alias was found for the original parameter name.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSqlServerAdvancedThreatProtectionSetting`

- No longer has output type 'Microsoft.Azure.Commands.Sql.ThreatDetection.Model.ServerThreatDetectionPolicyModel'.

### `Clear-AzSqlDatabaseAdvancedThreatProtectionSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `Update-AzSqlDatabaseAdvancedThreatProtectionSetting`

- No longer has output type 'Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DatabaseThreatDetectionPolicyModel'.
- No longer supports the parameter 'NotificationRecipientsEmails' and no alias was found for the original parameter name.
- No longer supports the parameter 'EmailAdmins' and no alias was found for the original parameter name.
- No longer supports the parameter 'ExcludedDetectionType' and no alias was found for the original parameter name.
- No longer supports the parameter 'StorageAccountName' and no alias was found for the original parameter name.
- No longer supports the parameter 'RetentionInDays' and no alias was found for the original parameter name.
- The parameter set '__AllParameterSets' has been removed.

### `Clear-AzSqlServerAdvancedThreatProtectionSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `Disable-AzSqlServerAdvancedDataSecurity`

- No longer supports the alias 'Disable-AzSqlServerAdvancedThreatProtection'.

### `Get-AzSqlDatabaseAdvancedThreatProtectionSetting`

- No longer has output type 'Microsoft.Azure.Commands.Sql.ThreatDetection.Model.DatabaseThreatDetectionPolicyModel'.

### `Enable-AzSqlServerAdvancedDataSecurity`

- No longer supports the alias 'Enable-AzSqlServerAdvancedThreatProtection'.

## Az.Storage

### `Get-AzStorageFileCopyState`

- No longer has output type 'Microsoft.Azure.Storage.File.CopyState'.

## Az.Synapse

### `Get-AzSynapseLinkConnectionLinkTableStatus`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Remove-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Update-AzSynapseLinkConnectionLandingZoneCredential`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Get-AzSynapseLinkConnectionLinkTable`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Stop-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Set-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Get-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Start-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.

### `Set-AzSynapseLinkConnectionLinkTable`

- The type of property 'Properties' of type 'PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'PSLinkConnection'.
