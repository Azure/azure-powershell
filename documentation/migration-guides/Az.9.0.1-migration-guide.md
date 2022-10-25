- [Migration Guide for Az 9.0.1](#migration-guide-for-az-901)
  - [Az.Advisor](#azadvisor)
    - [`Set-AzAdvisorConfiguration`](#set-azadvisorconfiguration)
    - [`Enable-AzAdvisorRecommendation`](#enable-azadvisorrecommendation)
    - [`Disable-AzAdvisorRecommendation`](#disable-azadvisorrecommendation)
    - [`Get-AzAdvisorRecommendation`](#get-azadvisorrecommendation)
    - [`Get-AzAdvisorConfiguration`](#get-azadvisorconfiguration)
  - [Az.Aks](#azaks)
    - [`Install-AzAksKubectl`](#install-azakskubectl)
  - [Az.ApiManagement](#azapimanagement)
    - [`Get-AzApiManagement`](#get-azapimanagement)
    - [`Set-AzApiManagement`](#set-azapimanagement)
    - [`Restore-AzApiManagement`](#restore-azapimanagement)
    - [`Get-AzApiManagementSsoToken`](#get-azapimanagementssotoken)
    - [`Update-AzApiManagementRegion`](#update-azapimanagementregion)
    - [`Backup-AzApiManagement`](#backup-azapimanagement)
    - [`Add-AzApiManagementRegion`](#add-azapimanagementregion)
    - [`New-AzApiManagement`](#new-azapimanagement)
    - [`New-AzApiManagementRegion`](#new-azapimanagementregion)
    - [`Remove-AzApiManagementRegion`](#remove-azapimanagementregion)
    - [`Get-AzApiManagementNetworkStatus`](#get-azapimanagementnetworkstatus)
  - [Az.Attestation](#azattestation)
    - [`Get-AzAttestation`](#get-azattestation)
    - [`New-AzAttestation`](#new-azattestation)
    - [`Remove-AzAttestation`](#remove-azattestation)
  - [Az.EventHub](#azeventhub)
    - [`Get-AzEventHubAuthorizationRule`](#get-azeventhubauthorizationrule)
    - [`Get-AzEventHubKey`](#get-azeventhubkey)
    - [`New-AzEventHubAuthorizationRule`](#new-azeventhubauthorizationrule)
    - [`New-AzEventHubKey`](#new-azeventhubkey)
    - [`Remove-AzEventHubAuthorizationRule`](#remove-azeventhubauthorizationrule)
    - [`Set-AzEventHubAuthorizationRule`](#set-azeventhubauthorizationrule)
    - [`Get-AzEventHubConsumerGroup`](#get-azeventhubconsumergroup)
    - [`New-AzEventHubConsumerGroup`](#new-azeventhubconsumergroup)
    - [`Set-AzEventHubConsumerGroup`](#set-azeventhubconsumergroup)
    - [`Remove-AzEventHubConsumerGroup`](#remove-azeventhubconsumergroup)
    - [`Get-AzEventHub`](#get-azeventhub)
    - [`New-AzEventHub`](#new-azeventhub)
    - [`Set-AzEventHub`](#set-azeventhub)
    - [`Remove-AzEventHub`](#remove-azeventhub)
    - [`Get-AzEventHubNetworkRuleSet`](#get-azeventhubnetworkruleset)
    - [`Set-AzEventHubNetworkRuleSet`](#set-azeventhubnetworkruleset)
    - [`New-AzEventHubSchemaGroup`](#new-azeventhubschemagroup)
    - [`Remove-AzEventHubSchemaGroup`](#remove-azeventhubschemagroup)
    - [`Get-AzEventHubSchemaGroup`](#get-azeventhubschemagroup)
    - [`Get-AzEventHubGeoDRConfiguration`](#get-azeventhubgeodrconfiguration)
    - [`Set-AzEventHubGeoDRConfigurationBreakPair`](#set-azeventhubgeodrconfigurationbreakpair)
    - [`Set-AzEventHubGeoDRConfigurationFailOver`](#set-azeventhubgeodrconfigurationfailover)
    - [`Remove-AzEventHubGeoDRConfiguration`](#remove-azeventhubgeodrconfiguration)
    - [`New-AzEventHubGeoDRConfiguration`](#new-azeventhubgeodrconfiguration)
    - [`Test-AzEventHubName`](#test-azeventhubname)
  - [Az.MarketplaceOrdering](#azmarketplaceordering)
    - [`Get-AzMarketplaceTerms`](#get-azmarketplaceterms)
    - [`Set-AzMarketplaceTerms`](#set-azmarketplaceterms)
  - [Az.Migrate](#azmigrate)
    - [`New-AzMigrateReplicationVaultSetting`](#new-azmigratereplicationvaultsetting)
    - [`Get-AzMigrateReplicationVaultSetting`](#get-azmigratereplicationvaultsetting)
    - [`Get-AzMigrateReplicationProtectionIntent`](#get-azmigratereplicationprotectionintent)
    - [`Get-AzMigrateSupportedOperatingSystem`](#get-azmigratesupportedoperatingsystem)
    - [`Get-AzMigrateReplicationEligibilityResult`](#get-azmigratereplicationeligibilityresult)
    - [`New-AzMigrateReplicationProtectionIntent`](#new-azmigratereplicationprotectionintent)
  - [Az.Monitor](#azmonitor)
    - [`Get-AzAutoscaleSetting`](#get-azautoscalesetting)
    - [`Get-AzSubscriptionDiagnosticSettingCategory`](#get-azsubscriptiondiagnosticsettingcategory)
    - [`Remove-AzAutoscaleSetting`](#remove-azautoscalesetting)
    - [`New-AzAutoscaleProfile`](#new-azautoscaleprofile)
    - [`Remove-AzDiagnosticSetting`](#remove-azdiagnosticsetting)
    - [`New-AzDiagnosticSetting`](#new-azdiagnosticsetting)
    - [`New-AzScheduledQueryRule`](#new-azscheduledqueryrule)
    - [`New-AzScheduledQueryRuleAznsActionGroup`](#new-azscheduledqueryruleaznsactiongroup)
    - [`Set-AzScheduledQueryRule`](#set-azscheduledqueryrule)
    - [`New-AzScheduledQueryRuleSource`](#new-azscheduledqueryrulesource)
    - [`New-AzScheduledQueryRuleLogMetricTrigger`](#new-azscheduledqueryrulelogmetrictrigger)
    - [`Enable-AzActivityLogAlert`](#enable-azactivitylogalert)
    - [`New-AzAutoscaleNotification`](#new-azautoscalenotification)
    - [`New-AzActionGroup`](#new-azactiongroup)
    - [`New-AzDiagnosticDetailSetting`](#new-azdiagnosticdetailsetting)
    - [`New-AzAutoscaleRule`](#new-azautoscalerule)
    - [`New-AzScheduledQueryRuleSchedule`](#new-azscheduledqueryruleschedule)
    - [`Remove-AzActivityLogAlert`](#remove-azactivitylogalert)
    - [`New-AzAutoscaleWebhook`](#new-azautoscalewebhook)
    - [`Remove-AzScheduledQueryRule`](#remove-azscheduledqueryrule)
    - [`Disable-AzActivityLogAlert`](#disable-azactivitylogalert)
    - [`Set-AzDiagnosticSetting`](#set-azdiagnosticsetting)
    - [`Get-AzScheduledQueryRule`](#get-azscheduledqueryrule)
    - [`Add-AzAutoscaleSetting`](#add-azautoscalesetting)
    - [`Update-AzScheduledQueryRule`](#update-azscheduledqueryrule)
    - [`Get-AzDiagnosticSetting`](#get-azdiagnosticsetting)
    - [`Get-AzDiagnosticSettingCategory`](#get-azdiagnosticsettingcategory)
    - [`New-AzScheduledQueryRuleAlertingAction`](#new-azscheduledqueryrulealertingaction)
    - [`New-AzActivityLogAlertCondition`](#new-azactivitylogalertcondition)
    - [`Set-AzActivityLogAlert`](#set-azactivitylogalert)
    - [`Get-AzActivityLogAlert`](#get-azactivitylogalert)
    - [`New-AzScheduledQueryRuleTriggerCondition`](#new-azscheduledqueryruletriggercondition)
  - [Az.Network](#aznetwork)
    - [`New-AzFirewall`](#new-azfirewall)
    - [`New-AzFirewallHubIpAddress`](#new-azfirewallhubipaddress)
    - [`Set-AzFirewall`](#set-azfirewall)
    - [`New-AzNetworkManagerAddressPrefixItem`](#new-aznetworkmanageraddressprefixitem)
    - [`New-AzNetworkManagerSecurityAdminConfiguration`](#new-aznetworkmanagersecurityadminconfiguration)
    - [`New-AzNetworkManager`](#new-aznetworkmanager)
    - [`Get-AzFirewall`](#get-azfirewall)
    - [`New-AzNetworkManagerConnectivityConfiguration`](#new-aznetworkmanagerconnectivityconfiguration)
    - [`Deploy-AzNetworkManagerCommit`](#deploy-aznetworkmanagercommit)
    - [`New-AzNetworkManagerConnectivityGroupItem`](#new-aznetworkmanagerconnectivitygroupitem)
    - [`New-AzNetworkManagerSecurityAdminRule`](#new-aznetworkmanagersecurityadminrule)
  - [Az.RecoveryServices](#azrecoveryservices)
    - [`Get-AzRecoveryServicesBackupContainer`](#get-azrecoveryservicesbackupcontainer)
  - [Az.SecurityInsights](#azsecurityinsights)
    - [`Update-AzSentinelAlertRuleAction`](#update-azsentinelalertruleaction)
    - [`New-AzSentinelIncidentOwner`](#new-azsentinelincidentowner)
    - [`New-AzSentinelIncidentComment`](#new-azsentinelincidentcomment)
    - [`Get-AzSentinelBookmark`](#get-azsentinelbookmark)
    - [`Update-AzSentinelAlertRule`](#update-azsentinelalertrule)
    - [`Get-AzSentinelIncidentComment`](#get-azsentinelincidentcomment)
    - [`Get-AzSentinelAlertRuleAction`](#get-azsentinelalertruleaction)
    - [`Remove-AzSentinelIncident`](#remove-azsentinelincident)
    - [`New-AzSentinelBookmark`](#new-azsentinelbookmark)
    - [`Remove-AzSentinelAlertRule`](#remove-azsentinelalertrule)
    - [`Remove-AzSentinelAlertRuleAction`](#remove-azsentinelalertruleaction)
    - [`Get-AzSentinelAlertRule`](#get-azsentinelalertrule)
    - [`Update-AzSentinelDataConnector`](#update-azsentineldataconnector)
    - [`Remove-AzSentinelBookmark`](#remove-azsentinelbookmark)
    - [`New-AzSentinelIncident`](#new-azsentinelincident)
    - [`New-AzSentinelAlertRuleAction`](#new-azsentinelalertruleaction)
    - [`Get-AzSentinelIncident`](#get-azsentinelincident)
    - [`Remove-AzSentinelDataConnector`](#remove-azsentineldataconnector)
    - [`New-AzSentinelDataConnector`](#new-azsentineldataconnector)
    - [`New-AzSentinelAlertRule`](#new-azsentinelalertrule)
    - [`Get-AzSentinelAlertRuleTemplate`](#get-azsentinelalertruletemplate)
    - [`Update-AzSentinelIncident`](#update-azsentinelincident)
    - [`Get-AzSentinelDataConnector`](#get-azsentineldataconnector)
    - [`Update-AzSentinelBookmark`](#update-azsentinelbookmark)
  - [Az.ServiceBus](#azservicebus)
    - [`Get-AzServiceBusAuthorizationRule`](#get-azservicebusauthorizationrule)
    - [`Get-AzServiceBusKey`](#get-azservicebuskey)
    - [`New-AzServiceBusAuthorizationRule`](#new-azservicebusauthorizationrule)
    - [`New-AzServiceBusKey`](#new-azservicebuskey)
    - [`Remove-AzServiceBusAuthorizationRule`](#remove-azservicebusauthorizationrule)
    - [`Set-AzServiceBusAuthorizationRule`](#set-azservicebusauthorizationrule)
    - [`Test-AzServiceBusName`](#test-azservicebusname)
    - [`Set-AzServiceBusGeoDRConfigurationBreakPair`](#set-azservicebusgeodrconfigurationbreakpair)
    - [`Stop-AzServiceBusMigration`](#stop-azservicebusmigration)
    - [`Get-AzServiceBusNetworkRuleSet`](#get-azservicebusnetworkruleset)
    - [`Set-AzServiceBusNetworkRuleSet`](#set-azservicebusnetworkruleset)
    - [`Get-AzServiceBusQueue`](#get-azservicebusqueue)
    - [`New-AzServiceBusQueue`](#new-azservicebusqueue)
    - [`Set-AzServiceBusQueue`](#set-azservicebusqueue)
    - [`Remove-AzServiceBusQueue`](#remove-azservicebusqueue)
    - [`Get-AzServiceBusRule`](#get-azservicebusrule)
    - [`New-AzServiceBusRule`](#new-azservicebusrule)
    - [`Set-AzServiceBusRule`](#set-azservicebusrule)
    - [`Remove-AzServiceBusRule`](#remove-azservicebusrule)
    - [`Get-AzServiceBusTopic`](#get-azservicebustopic)
    - [`New-AzServiceBusTopic`](#new-azservicebustopic)
    - [`Set-AzServiceBusTopic`](#set-azservicebustopic)
    - [`Remove-AzServiceBusTopic`](#remove-azservicebustopic)
    - [`Get-AzServiceBusSubscription`](#get-azservicebussubscription)
    - [`New-AzServiceBusSubscription`](#new-azservicebussubscription)
    - [`Set-AzServiceBusSubscription`](#set-azservicebussubscription)
    - [`Remove-AzServiceBusSubscription`](#remove-azservicebussubscription)
    - [`Get-AzServiceBusGeoDRConfiguration`](#get-azservicebusgeodrconfiguration)
    - [`Set-AzServiceBusGeoDRConfigurationFailOver`](#set-azservicebusgeodrconfigurationfailover)
    - [`New-AzServiceBusGeoDRConfiguration`](#new-azservicebusgeodrconfiguration)
    - [`Remove-AzServiceBusGeoDRConfiguration`](#remove-azservicebusgeodrconfiguration)
    - [`Start-AzServiceBusMigration`](#start-azservicebusmigration)
    - [`Get-AzServiceBusMigration`](#get-azservicebusmigration)
    - [`Complete-AzServiceBusMigration`](#complete-azservicebusmigration)
    - [`Remove-AzServiceBusMigration`](#remove-azservicebusmigration)
  - [Az.Sql](#azsql)
    - [`Update-AzSqlServerAdvancedThreatProtectionSetting`](#update-azsqlserveradvancedthreatprotectionsetting)
    - [`Get-AzSqlServerAdvancedThreatProtectionSetting`](#get-azsqlserveradvancedthreatprotectionsetting)
    - [`Clear-AzSqlDatabaseAdvancedThreatProtectionSetting`](#clear-azsqldatabaseadvancedthreatprotectionsetting)
    - [`Update-AzSqlDatabaseAdvancedThreatProtectionSetting`](#update-azsqldatabaseadvancedthreatprotectionsetting)
    - [`Clear-AzSqlServerAdvancedThreatProtectionSetting`](#clear-azsqlserveradvancedthreatprotectionsetting)
    - [`Disable-AzSqlServerAdvancedDataSecurity`](#disable-azsqlserveradvanceddatasecurity)
    - [`Get-AzSqlDatabaseAdvancedThreatProtectionSetting`](#get-azsqldatabaseadvancedthreatprotectionsetting)
    - [`Enable-AzSqlServerAdvancedDataSecurity`](#enable-azsqlserveradvanceddatasecurity)
  - [Az.Storage](#azstorage)
    - [`Get-AzStorageFileCopyState`](#get-azstoragefilecopystate)
  - [Az.Synapse](#azsynapse)
    - [`Get-AzSynapseLinkConnectionLinkTableStatus`](#get-azsynapselinkconnectionlinktablestatus)
    - [`Remove-AzSynapseLinkConnection`](#remove-azsynapselinkconnection)
    - [`Update-AzSynapseLinkConnectionLandingZoneCredential`](#update-azsynapselinkconnectionlandingzonecredential)
    - [`Get-AzSynapseLinkConnectionLinkTable`](#get-azsynapselinkconnectionlinktable)
    - [`Stop-AzSynapseLinkConnection`](#stop-azsynapselinkconnection)
    - [`Set-AzSynapseLinkConnection`](#set-azsynapselinkconnection)
    - [`Get-AzSynapseLinkConnection`](#get-azsynapselinkconnection)
    - [`Start-AzSynapseLinkConnection`](#start-azsynapselinkconnection)
    - [`Set-AzSynapseLinkConnectionLinkTable`](#set-azsynapselinkconnectionlinktable)

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

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Set-AzApiManagement`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Restore-AzApiManagement`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Get-AzApiManagementSsoToken`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Update-AzApiManagementRegion`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- No longer supports the type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' for parameter 'Sku'.

### `Backup-AzApiManagement`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Add-AzApiManagementRegion`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementRegion' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- No longer supports the type 'System.Nullable`1[Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku]' for parameter 'Sku'.

### `New-AzApiManagement`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- No longer supports the type 'System.Nullable`1[Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku]' for parameter 'Sku'.

### `New-AzApiManagementRegion`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementRegion' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Remove-AzApiManagementRegion`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.
- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

### `Get-AzApiManagementNetworkStatus`

- The type of property 'Sku' of type 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement' has changed from 'Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSku' to 'System.String'.

## Az.Attestation

### `Get-AzAttestation`

- Has been removed and no alias was found for the original cmdlet name.

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

- Has been removed and no alias was found for the original cmdlet name.

#### Before

```powershell
New-AzAttestation -Name testprovider2 -ResourceGroupName test-rg -Location "East US" -PolicySignersCertificateFile .\cert1.pem
```

#### After

```powershell
New-AzAttestationProvider -Name testprovider2 -ResourceGroupName test-rg -Location "East US" -PolicySigningCertificateKeyPath .\cert1.pem
```

### `Remove-AzAttestation`

- Has been removed and no alias was found for the original cmdlet name.

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

Remove Term parameter

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

### `Get-AzAutoscaleSetting`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSAutoscaleSetting'.
- No longer supports the alias 'ResourceGroup' for parameter 'ResourceGroupName'.
- No longer supports the parameter 'DetailedOutput' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'GetAutoscaleSetting' has been removed.

### `Get-AzSubscriptionDiagnosticSettingCategory`

- Has been removed and no alias was found for the original cmdlet name.

### `Remove-AzAutoscaleSetting`

- No longer has output type 'Microsoft.Azure.AzureOperationResponse'.
- No longer supports the alias 'ResourceGroup' for parameter 'ResourceGroupName'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'RemoveAutoscaleSetting' has been removed.

### `New-AzAutoscaleProfile`

- Has been removed and no alias was found for the original cmdlet name.

### `Remove-AzDiagnosticSetting`

- No longer has output type 'Microsoft.Azure.AzureOperationResponse'.
- No longer supports the alias 'TargetResourceId' for parameter 'ResourceId'.
- No longer supports the parameter 'SubscriptionId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'ResourceIdParameterSet' has been removed.
- The parameter set 'SubscriptionIdParameterSet' has been removed.

### `New-AzDiagnosticSetting`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSServiceDiagnosticSettings'.
- No longer supports the parameter 'DedicatedLogAnalyticsDestinationType' and no alias was found for the original parameter name.
- No longer supports the parameter 'Setting' and no alias was found for the original parameter name.
- No longer supports the alias 'TargetResourceId' for parameter 'ResourceId'.
- No longer supports the parameter 'SubscriptionId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'ResourceIdParameterSet' has been removed.
- The parameter set 'SubscriptionIdParameterSet' has been removed.

### `New-AzScheduledQueryRule`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSScheduledQueryRuleResource'.
- No longer supports the parameter 'Source' and no alias was found for the original parameter name.
- No longer supports the parameter 'Schedule' and no alias was found for the original parameter name.
- No longer supports the parameter 'Action' and no alias was found for the original parameter name.
- No longer supports the type 'System.Boolean' for parameter 'Enabled'.
- No longer supports the parameter 'AsJob' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.

### `New-AzScheduledQueryRuleAznsActionGroup`

- Has been removed and no alias was found for the original cmdlet name.

### `Set-AzScheduledQueryRule`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzScheduledQueryRuleSource`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzScheduledQueryRuleLogMetricTrigger`

- Has been removed and no alias was found for the original cmdlet name.

### `Enable-AzActivityLogAlert`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzAutoscaleNotification`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzActionGroup`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzDiagnosticDetailSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzAutoscaleRule`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzScheduledQueryRuleSchedule`

- Has been removed and no alias was found for the original cmdlet name.

### `Remove-AzActivityLogAlert`

- No longer has output type 'Microsoft.Azure.AzureOperationResponse'.
- No longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSActivityLogAlertResource' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'RemoveByNameAndResourceGroup' has been removed.
- The parameter set 'RemoveByResourceId' has been removed.

### `New-AzAutoscaleWebhook`

- Has been removed and no alias was found for the original cmdlet name.

### `Remove-AzScheduledQueryRule`

- No longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSScheduledQueryRuleResource' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ByResourceId' has been removed.

### `Disable-AzActivityLogAlert`

- Has been removed and no alias was found for the original cmdlet name.

### `Set-AzDiagnosticSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `Get-AzScheduledQueryRule`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSScheduledQueryRuleResource'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BySubscriptionOrResourceGroup' has been removed.
- The parameter set 'ByResourceId' has been removed.

### `Add-AzAutoscaleSetting`

- Has been removed and no alias was found for the original cmdlet name.

### `Update-AzScheduledQueryRule`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSScheduledQueryRuleResource'.
- No longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSScheduledQueryRuleResource' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'System.Boolean' for parameter 'Enabled'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ByResourceId' has been removed.

### `Get-AzDiagnosticSetting`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSServiceDiagnosticSettings'.
- No longer supports the alias 'TargetResourceId' for parameter 'ResourceId'.
- No longer supports the parameter 'SubscriptionId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'ResourceIdParameterSet' has been removed.
- The parameter set 'SubscriptionIdParameterSet' has been removed.

### `Get-AzDiagnosticSettingCategory`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDiagnosticSettingCategory'.
- No longer supports the parameter 'TargetResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.

### `New-AzScheduledQueryRuleAlertingAction`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzActivityLogAlertCondition`

- Has been removed and no alias was found for the original cmdlet name.

### `Set-AzActivityLogAlert`

- Has been removed and no alias was found for the original cmdlet name.

### `Get-AzActivityLogAlert`

- No longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSActivityLogAlertResource'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'GetByNameAndResourceGroup' has been removed.
- The parameter set 'GetByResourceGroup' has been removed.

### `New-AzScheduledQueryRuleTriggerCondition`

- Has been removed and no alias was found for the original cmdlet name.

## Az.Network

### `New-AzFirewall`

- The property 'IdentifyTopFatFlow' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' has been removed.
- The property 'publicIPAddresses' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' has been removed.
- No longer supports the parameter 'IdentifyTopFatFlow' and no alias was found for the original parameter name.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'OldIpConfigurationParameterValues' has been removed.
- The parameter set 'IpConfigurationParameterValues' has been removed.

### `New-AzFirewallHubIpAddress`

- The property 'publicIPAddresses' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' has been removed.

### `Set-AzFirewall`

- The property 'IdentifyTopFatFlow' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' has been removed.
- The property 'IdentifyTopFatFlow' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' has been removed.

### `New-AzNetworkManagerAddressPrefixItem`

- A validate set has been added for parameter 'AddressPrefixType'.

### `New-AzNetworkManagerSecurityAdminConfiguration`

- The element type for parameter 'ApplyOnNetworkIntentPolicyBasedService' has been changed from 'System.String' to 'Microsoft.Azure.Commands.Network.NewAzNetworkManagerSecurityAdminConfigurationCommand+NetworkIntentPolicyBasedServiceType'.

### `New-AzNetworkManager`

- The element type for parameter 'NetworkManagerScopeAccess' has been changed from 'System.String' to 'Microsoft.Azure.Commands.Network.NewAzNetworkManagerCommand+NetworkManagerScopeAccessType'.

### `Get-AzFirewall`

- The property 'publicIPAddresses' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses' has been removed.
- The property 'IdentifyTopFatFlow' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' has been removed.
- The property 'IdentifyTopFatFlow' of type 'Microsoft.Azure.Commands.Network.Models.PSAzureFirewall' has been removed.

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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ActionId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `New-AzSentinelIncidentOwner`

- Has been removed and no alias was found for the original cmdlet name.

### `New-AzSentinelIncidentComment`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.IncidentComments.PSSentinelIncidentComment'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSentinelBookmark`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelAlertRule`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule'.
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
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule' for parameter 'InputObject'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.
- The parameter set '__AllParameterSets' has been removed.
- The parameter set 'InputObject' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Get-AzSentinelIncidentComment`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.IncidentComments.PSSentinelIncidentComment'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ResourceId' has been removed.

### `Get-AzSentinelAlertRuleAction`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.
- The parameter set 'ActionId' has been removed.

### `Remove-AzSentinelIncident`

- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncident' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'IncidentId' has been removed.

### `New-AzSentinelBookmark`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark'.
- No longer supports the parameter 'IncidentInfo' and no alias was found for the original parameter name.
- No longer supports the type 'System.Collections.Generic.IList`1[System.String]' for parameter 'Label'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Remove-AzSentinelAlertRule`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.

### `Remove-AzSentinelAlertRuleAction`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ActionId' has been removed.

### `Get-AzSentinelAlertRule`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelDataConnector`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors.PSSentinelDataConnector'.
- No longer supports the parameter 'DataConnectorId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors.PSSentinelDataConnector' for parameter 'InputObject'.
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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark'.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'BookmarkId.' has been removed.

### `New-AzSentinelIncident`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncident'.
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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse'.
- No longer supports the parameter 'AlertRuleId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ActionId' has been removed.
- The parameter set '__AllParameterSets' has been removed.

### `Get-AzSentinelIncident`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncident'.
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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors.PSSentinelDataConnector'.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors.PSSentinelDataConnector' for parameter 'InputObject'.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'DataConnectorId' has been removed.

### `New-AzSentinelDataConnector`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors.PSSentinelDataConnector'.
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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule'.
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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.AlertRuleTemplates.PSSentinelAlertRuleTemplate'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'AlertRuleTemplateId' has been removed.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelIncident`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncident'.
- No longer supports the parameter 'IncidentID' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.Incidents.PSSentinelIncident' for parameter 'InputObject'.
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

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors.PSSentinelDataConnector'.
- No longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
- No longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
- No longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
- The parameter set 'ResourceId' has been removed.

### `Update-AzSentinelBookmark`

- No longer has output type 'Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark'.
- No longer supports the type 'Microsoft.Azure.Commands.SecurityInsights.Models.Bookmarks.PSSentinelBookmark' for parameter 'InputObject'.
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

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Remove-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Update-AzSynapseLinkConnectionLandingZoneCredential`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Get-AzSynapseLinkConnectionLinkTable`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Stop-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Set-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Get-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Start-AzSynapseLinkConnection`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.

### `Set-AzSynapseLinkConnectionLinkTable`

- The type of property 'Properties' of type 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnectionResource' has changed from 'Azure.Analytics.Synapse.Artifacts.Models.LinkConnection' to 'Microsoft.Azure.Commands.Synapse.Models.PSLinkConnection'.
