# Migration Guide for Az 11.0.0

## Az.Aks

### `New-AzAksCluster`
The parameter  'DockerBridgeCidr' is removed from the cmdlet 'New-AzAksCluster', and there is no replacement for it.

## Az.CloudService

### `Get-AzCloudServiceNetworkInterface`
The api version is downgraded to `2021-03-01`. Some properties are removed.
- 'ProtectionMode' and 'DdosProtectionPlanId' of type 'IDdosSettings' have been removed.
- 'InboundNatRulesPortMapping' and 'AdminState' of type 'ILoadBalancerBackendAddress' have been removed.
- 'InboundNatRule' and 'DrainPeriodInSecond' of type 'IBackendAddressPool' have been removed.
- 'FlushConnection' of type 'ISubnet' has been removed.
- 'AuxiliaryMode', 'VnetEncryptionSupported', and 'DisableTcpStateTracking' of type 'INetworkInterface' have been removed.


## Az.Compute

### `New-AzDisk`
Creation of Disk without any Image or SecurityType values provided will default to turn Trusted Launch on. 

#### Before
```powershell
$diskconfig = New-AzDiskConfig -DiskSizeGB 127 -AccountType Premium_LRS -OsType Windows -CreateOption FromImage -Location $loc;
```
#### After
```powershell
$diskconfig = New-AzDiskConfig -DiskSizeGB 127 -AccountType Premium_LRS -OsType Windows -CreateOption FromImage -Location $loc -SecurityType "Standard";
```


### `New-AzVM`
Linux image aliases CentOS, Debian, RHEL, and UbuntuLTS are removed. Instead use the aliases CentOS85Gen2, Debian11, RHELRaw8LVMGen2, Ubuntu2204.

#### Before
```powershell
New-AzVM -ResourceGroupName MyResourceGroup -Name mytestvm -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image UbuntuLTS;
```
#### After
```powershell
New-AzVM -ResourceGroupName MyResourceGroup -Name mytestvm -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -Image Ubuntu2204;
```


### `New-AzVM`
Creation of VM without any Image or SecurityType values provided will default to turn Trusted Launch on. 

#### Before
```powershell
$result = New-AzVM -ResourceGroupName $rgname -Credential $vmCred -Name $vmName -DomainNameLabel $domainNameLabel ;
```
#### After
```powershell
$result = New-AzVM-ResourceGroupName $rgname -Credential $vmCred -Name $vmName -ImageName $imageName -DomainNameLabel $domainNameLabel -SecurityType "Standard";
```


### `New-AzVmss`
Linux image aliases CentOS, Debian, RHEL, and UbuntuLTS are removed. Instead use the aliases CentOS85Gen2, Debian11, RHELRaw8LVMGen2, Ubuntu2204.

### `New-AzVmss`
Creation of Vmss using this cmdlet will now default to OrchestrationMode: Flexible. Only when explicitly stated "-OrchestrationMode Uniform", it will create a VMSS in Uniform orchestration mode.  UgradePolicy  and SinglePlacementGroup can also be set now when OrchestrationMode is Flexible. 

#### Before
```powershell
New-AzVmss
```
#### After
```powershell
New-AzVmss
```


### `New-AzVmss`
Creation of Vmss without any Image or SecurityType values provided will default to turn Trusted Launch on. 

#### Before
```powershell
$result = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -DomainNameLabel $domainNameLabel ;
```
#### After
```powershell
$result = New-AzVmss -ResourceGroupName $rgname -Credential $vmCred -VMScaleSetName $vmssName1 -ImageName $imageName -DomainNameLabel $domainNameLabel -SecurityType "Standard";
```


## Az.ContainerInstance

### `Get-AzContainerGroup`
Fixed typos in these output properties: 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'. 
The impacted cmdlets are: 'Get-AzContainerGroup', 'Remove-AzContainerGroup', 'Restart-AzContainerGroup', 'Start-AzContainerGroup', 'Stop-AzContainerGroup', 'Update-AzContainerGroup', 'New-AzContainerInstanceObject', 'New-AzContainerInstanceInitDefinitionObject'

#### Before
```powershell
$aci = Get-AzContainerGroup -ResourceGroupName 'rg name' -Name 'aci name'
$previousState = $aci.Property.Container.PreviouState

```
#### After
```powershell
$aci = Get-AzContainerGroup -ResourceGroupName 'rg name' -Name 'aci name'
$previousState = $aci.Property.Container.PreviousState

```


## Az.DesktopVirtualization

### `New-AzWvdScalingPlan`
The allowed value of this parameter changed from 'BYODesktop, Personal, Pooled' to 'Pooled'

## Az.Functions

### `Get-AzFunctionApp`
This cmdlet will redact the application settings of the returned function apps and only the keys will be shown while previously it returned both keys and values.

#### Before
```powershell
Get-AzFunctionApp  -Name <AppName> -ResourceGroupName <ResourceGroupName>
```output
Name                                                                        Value
----                                                                             -----
FUNCTIONS_EXTENSION_VERSION            ~4
WEBSITE_CONTENTAZUREFILECONNE… <connection string>
AzureWebJobsStorage                                       <connection string>
APPLICATIONINSIGHTS_CONNECTIO…   <connection string>
APPINSIGHTS_INSTRUMENTATIONKEY     <guid>
FUNCTIONS_WORKER_RUNTIME                 powershell
WEBSITE_CONTENTSHARE                            <share name>
```
```
#### After
```powershell
Get-AzFunctionApp  -Name <AppName> -ResourceGroupName <ResourceGroupName>
```output
WARNING: App settings have been redacted. Use the Get-AzFunctionAppSetting cmdlet to view them.
Name                                                                        Value
----                                                                             -----
FUNCTIONS_EXTENSION_VERSION            
WEBSITE_CONTENTAZUREFILECONNE… 
AzureWebJobsStorage                                       
APPLICATIONINSIGHTS_CONNECTIO…   
APPINSIGHTS_INSTRUMENTATIONKEY     
FUNCTIONS_WORKER_RUNTIME                 
WEBSITE_CONTENTSHARE                             
```
```


### `Update-AzFunctionAppSetting`
This cmdlet will only return the updated application settings while previously all of them returned.

#### Before
```powershell
Update-AzFunctionAppSetting  -Name <AppName> -ResourceGroupName <ResourceGroupName>  -AppSetting @{"foo3"="bar3"}
```output
Name                                                                        Value
----                                                                             -----
FUNCTIONS_EXTENSION_VERSION            ~4
WEBSITE_CONTENTAZUREFILECONNE… <connection string>
foo3                                                                           bar3
AzureWebJobsStorage                                       <connection string>
APPLICATIONINSIGHTS_CONNECTIO…   <connection string>
APPINSIGHTS_INSTRUMENTATIONKEY     <guid>
FUNCTIONS_WORKER_RUNTIME                 powershell
WEBSITE_CONTENTSHARE                            <share name>
```
```
#### After
```powershell
Update-AzFunctionAppSetting  -Name <AppName> -ResourceGroupName <ResourceGroupName>  -AppSetting @{"foo3"="bar3"}
```output
Name                      Value
----                           -----
foo3                         bar3
```
```


## Az.KeyVault

### `New-AzKeyVaultManagedHsm`
parameter `SoftDeleteRetentionInDays` in `New-AzKeyVaultManagedHsm` is becoming mandatory

#### Before
```powershell
New-AzKeyVaultManagedHsm -HsmName $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminId
```
#### After
```powershell
New-AzKeyVaultManagedHsm -HsmName $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $adminId -SoftDeleteRetentionInDays 7
```


## Az.Monitor

### `Set-AzDataCollectionRule`
The cmdlet 'Set-AzDataCollectionRule' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
Set-AzDataCollectionRule -Location 'East US 2 EUAP' `
                                -ResourceGroupName 'testdcr' `
                                -RuleName 'newDcr' `
                                -RuleFile 'C:\samples\dcr1.json' `
                                -Description 'Updated Description'
```
#### After
```powershell
Update-AzDataCollectionRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DataCollectionEndpointId <String>] [-DataFlow <IDataFlow[]>]
 [-DataSourceDataImportEventHubConsumerGroup <String>] [-DataSourceDataImportEventHubName <String>]
 [-DataSourceDataImportEventHubStream <String>] [-DataSourceExtension <IExtensionDataSource[]>]
 [-DataSourceIisLog <IIisLogsDataSource[]>] [-DataSourceLogFile <ILogFilesDataSource[]>]
 [-DataSourcePerformanceCounter <IPerfCounterDataSource[]>]
 [-DataSourcePlatformTelemetry <IPlatformTelemetryDataSource[]>]
 [-DataSourcePrometheusForwarder <IPrometheusForwarderDataSource[]>] [-DataSourceSyslog <ISyslogDataSource[]>]
 [-DataSourceWindowsEventLog <IWindowsEventLogDataSource[]>]
 [-DataSourceWindowsFirewallLog <IWindowsFirewallLogsDataSource[]>] [-Description <String>]
 [-DestinationAzureMonitorMetricName <String>] [-DestinationEventHub <IEventHubDestination[]>]
 [-DestinationEventHubsDirect <IEventHubDirectDestination[]>]
 [-DestinationLogAnalytic <ILogAnalyticsDestination[]>]
 [-DestinationMonitoringAccount <IMonitoringAccountDestination[]>]
 [-DestinationStorageAccount <IStorageBlobDestination[]>]
 [-DestinationStorageBlobsDirect <IStorageBlobDestination[]>]
 [-DestinationStorageTablesDirect <IStorageTableDestination[]>] [-IdentityType <String>] [-Kind <String>]
 [-Location <String>] [-StreamDeclaration <Hashtable>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


### `Get-AzDataCollectionRule`
The cmdlet 'Get-AzDataCollectionRule' no longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource'.
The cmdlet 'Get-AzDataCollectionRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
The cmdlet 'Get-AzDataCollectionRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Get-AzDataCollectionRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.

#### Before
```powershell
Description       : DCR description
DataSources       : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDataSources
Destinations      : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDestinations
DataFlows         : {Microsoft.Azure.Commands.Insights.OutputClasses.PSDataFlow}
ProvisioningState : Succeeded
Etag              : "{etag}"
Id                : /subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr
Name              : testDcr
Type              : Microsoft.Insights/dataCollectionRules
Location          : East US 2 EUAP
Tags              : {[tag2, value2], [tag1, value1]}
```
#### After
```powershell
DataCollectionEndpointId                  :
DataFlow                                  : {{
                                              "streams": [ "Microsoft-InsightsMetrics" ],
                                              "destinations": [ "azureMonitorMetrics-default" ]
                                            }}
DataSourceDataImportEventHubConsumerGroup :
DataSourceDataImportEventHubName          :
DataSourceDataImportEventHubStream        :
DataSourceExtension                       :
DataSourceIisLog                          :
DataSourceLogFile                         :
DataSourcePerformanceCounter              : {{
                                              "streams": [ "Microsoft-InsightsMetrics" ],
                                              "samplingFrequencyInSeconds": 60,
                                              "counterSpecifiers": [ "\\Processor(_Total)\\% Processor Time" ],
                                              "name": "perfCounter01"
                                            }, {
                                              "streams": [ "Microsoft-Perf" ],
                                              "samplingFrequencyInSeconds": 15,
                                              "counterSpecifiers": [ "\\Processor(_Total)\\% Processor Time", "\\Memory\\Committed Bytes", "\\LogicalDisk(_Total)\\Free Megabytes",
                                            "\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" ],
                                              "name": "cloudTeamCoreCounters"
                                            }}
DataSourcePlatformTelemetry               :
DataSourcePrometheusForwarder             :
DataSourceSyslog                          :
DataSourceWindowsEventLog                 :
DataSourceWindowsFirewallLog              :
Description                               :
DestinationAzureMonitorMetricName         : azureMonitorMetrics-default
DestinationEventHub                       :
DestinationEventHubsDirect                :
DestinationLogAnalytic                    :
DestinationMonitoringAccount              :
DestinationStorageAccount                 :
DestinationStorageBlobsDirect             :
DestinationStorageTablesDirect            :
Etag                                      : "bb02d25d-0000-0100-0000-65017aed0000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule1  
IdentityPrincipalId                       :
IdentityTenantId                          :
IdentityType                              :
IdentityUserAssignedIdentity              : {
                                            }
ImmutableId                               : dcr-2eebbe7e7a974226b2ef938194ada574
Kind                                      :
Location                                  : eastus
MetadataProvisionedBy                     :
MetadataProvisionedByResourceId           :
Name                                      : myCollectionRule1
ProvisioningState                         : Succeeded
ResourceGroupName                         : AMCS-TEST
StreamDeclaration                         : {
                                            }
SystemDataCreatedAt                       : 9/13/2023 9:03:39 AM
SystemDataCreatedBy                       : v-jiaji@microsoft.com
SystemDataCreatedByType                   : User
SystemDataLastModifiedAt                  : 9/13/2023 9:03:39 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```


### `New-AzDataCollectionRule`
The cmdlet 'New-AzDataCollectionRule' no longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource'
The cmdlet 'New-AzDataCollectionRule' no longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource'.
The cmdlet 'New-AzDataCollectionRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'New-AzDataCollectionRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'New-AzDataCollectionRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Description       : DCR description
DataSources       : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDataSources
Destinations      : Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleDestinations
DataFlows         : {Microsoft.Azure.Commands.Insights.OutputClasses.PSDataFlow}
ProvisioningState : Succeeded
Etag              : "{etag}"
Id                : /subscriptions/{subId}/resourceGroups/testgroup/providers/Microsoft.Insights/dataCollectionRules/testDcr
Name              : testDcr
Type              : Microsoft.Insights/dataCollectionRules
Location          : East US 2 EUAP
Tags              : {[tag2, value2], [tag1, value1]}
```
#### After
```powershell
DataCollectionEndpointId                  :
DataFlow                                  : {{
                                              "streams": [ "Microsoft-InsightsMetrics" ],
                                              "destinations": [ "azureMonitorMetrics-default" ]
                                            }}
DataSourceDataImportEventHubConsumerGroup :
DataSourceDataImportEventHubName          :
DataSourceDataImportEventHubStream        :
DataSourceExtension                       :
DataSourceIisLog                          :
DataSourceLogFile                         :
DataSourcePerformanceCounter              : {{
                                              "streams": [ "Microsoft-InsightsMetrics" ],
                                              "samplingFrequencyInSeconds": 60,
                                              "counterSpecifiers": [ "\\Processor(_Total)\\% Processor Time" ],
                                              "name": "perfCounter01"
                                            }, {
                                              "streams": [ "Microsoft-Perf" ],
                                              "samplingFrequencyInSeconds": 15,
                                              "counterSpecifiers": [ "\\Processor(_Total)\\% Processor Time", "\\Memory\\Committed Bytes", "\\LogicalDisk(_Total)\\Free Megabytes",
                                            "\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" ],
                                              "name": "cloudTeamCoreCounters"
                                            }}
DataSourcePlatformTelemetry               :
DataSourcePrometheusForwarder             :
DataSourceSyslog                          :
DataSourceWindowsEventLog                 :
DataSourceWindowsFirewallLog              :
Description                               :
DestinationAzureMonitorMetricName         : azureMonitorMetrics-default
DestinationEventHub                       :
DestinationEventHubsDirect                :
DestinationLogAnalytic                    :
DestinationMonitoringAccount              :
DestinationStorageAccount                 :
DestinationStorageBlobsDirect             :
DestinationStorageTablesDirect            :
Etag                                      : "bb02d25d-0000-0100-0000-65017aed0000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule1  
IdentityPrincipalId                       :
IdentityTenantId                          :
IdentityType                              :
IdentityUserAssignedIdentity              : {
                                            }
ImmutableId                               : dcr-2eebbe7e7a974226b2ef938194ada574
Kind                                      :
Location                                  : eastus
MetadataProvisionedBy                     :
MetadataProvisionedByResourceId           :
Name                                      : myCollectionRule1
ProvisioningState                         : Succeeded
ResourceGroupName                         : AMCS-TEST
StreamDeclaration                         : {
                                            }
SystemDataCreatedAt                       : 9/13/2023 9:03:39 AM
SystemDataCreatedBy                       : v-jiaji@microsoft.com
SystemDataCreatedByType                   : User
SystemDataLastModifiedAt                  : 9/13/2023 9:03:39 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```


### `Get-AzDataCollectionRuleAssociation`
The cmdlet 'Get-AzDataCollectionRuleAssociation' no longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource' for parameter 'InputObject'.".
The cmdlet 'Get-AzDataCollectionRuleAssociation' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.".

#### Before
```powershell
Description          :
DataCollectionRuleId : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.I
                       nsights/dataCollectionRules/{dcrName}
ProvisioningState    :
Etag                 : "{etag}"
Id                   : /subscriptions/{subId}/resourceGroups/{rg}/providers/Microsoft.C
                       ompute/virtualMachines/{vmName}/providers/Microsoft.Insights/dataCollectionRuleAssociations/{assocName}
Name                 : {assocName}
Type                 : Microsoft.Insights/dataCollectionRuleAssociations
```
#### After
```powershell
DataCollectionEndpointId        :
DataCollectionRuleId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule2
Description                     :
Etag                            : "20017ecf-0000-0100-0000-651147350000"
Id                              : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01/providers/Microsof
                                  t.Insights/dataCollectionRuleAssociations/myCollectionRule2-association1
MetadataProvisionedBy           :
MetadataProvisionedByResourceId :
Name                            : myCollectionRule2-association1
ProvisioningState               :
ResourceGroupName               : amcs-test
SystemDataCreatedAt             : 9/25/2023 8:39:15 AM
SystemDataCreatedBy             : v-jiaji@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 9/25/2023 8:39:15 AM
SystemDataLastModifiedBy        : v-jiaji@microsoft.com
SystemDataLastModifiedByType    : User
Type                            : Microsoft.Insights/dataCollectionRuleAssociations
```


### `New-AzDataCollectionRuleAssociation`
The cmdlet 'New-AzDataCollectionRuleAssociation' no longer supports the parameter 'InputObject' and no alias was found for the original parameter name.
The cmdlet 'New-AzDataCollectionRuleAssociation' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'New-AzDataCollectionRuleAssociation' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'New-AzDataCollectionRuleAssociation' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
The parameter set 'ByInputObject' for cmdlet 'New-AzDataCollectionRuleAssociation' has been removed.

#### Before
```powershell
$dcr = Get-AzDataCollectionRule -ResourceGroupName $rg -RuleName $dcrName
$vmId = '/subscriptions/{subId}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/virtualMachines/{vmName}'
$dcr | New-AzDataCollectionRuleAssociation -TargetResourceId $vmId -AssociationName "dcrAssocInput"
```
#### After
```powershell
New-AzDataCollectionRuleAssociation -AssociationName myCollectionRule2-association1 -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.compute/virtualmachines/monitortestvm01 -DataCollectionRuleId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule2
```


### `Remove-AzDataCollectionRule`
The cmdlet 'Remove-AzDataCollectionRule' no longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource' for parameter 'InputObject'.
The cmdlet 'Remove-AzDataCollectionRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'Remove-AzDataCollectionRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Remove-AzDataCollectionRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzDataCollectionRule -ResourceGroupName "testdcr" -RuleName "dcrFromPipe95" | Remove-AzDataCollectionRule
```
#### After
```powershell
Get-AzDataCollectionRule -ResourceGroupName "testdcr" -RuleName "dcrFromPipe95" | Remove-AzDataCollectionRule
```


### `Remove-AzDataCollectionRuleAssociation`
The cmdlet 'Remove-AzDataCollectionRuleAssociation' no longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleAssociationProxyOnlyResource' for parameter 'InputObject'.
The cmdlet 'Remove-AzDataCollectionRuleAssociation' no longer supports the parameter 'AssociationId' and no alias was found for the original parameter name.
The cmdlet 'Remove-AzDataCollectionRuleAssociation' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'Remove-AzDataCollectionRuleAssociation' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Remove-AzDataCollectionRuleAssociation' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
The parameter set 'ByResourceId' for cmdlet 'Remove-AzDataCollectionRuleAssociation' has been removed.

#### Before
```powershell
$dcrAssoc | Remove-AzDataCollectionRuleAssociation
Remove-AzDataCollectionRuleAssociation -AssociationId $dcrAssoc.Id
```
#### After
```powershell
$dcrAssoc | Remove-AzDataCollectionRuleAssociation
Remove-AzDataCollectionRuleAssociation -InputObject $dcrAssoc.Id
```


### `Update-AzDataCollectionRule`
The cmdlet 'Update-AzDataCollectionRule' no longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource'.
The cmdlet 'Update-AzDataCollectionRule' no longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource' for parameter 'InputObject'.
The cmdlet 'Update-AzDataCollectionRule' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'Update-AzDataCollectionRule' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Update-AzDataCollectionRule' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
$dcr = Get-AzDataCollectionRule -ResourceGroupName "testdcr" -Name "newDcr"
$dcr | Update-AzDataCollectionRule -Tag @{"tag1"="value1"; "tag2"="value2"}
```
#### After
```powershell
$dcr = Get-AzDataCollectionRule -ResourceGroupName "testdcr" -Name "newDcr"
$dcr | Update-AzDataCollectionRule -Tag @{"tag1"="value1"; "tag2"="value2"}
```


### `Get-AzActionGroup`
The cmdlet 'Get-AzActionGroup' no longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupResource'.
The cmdlet 'Get-AzActionGroup' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'Get-AzActionGroup' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Get-AzActionGroup' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Get-AzActionGroup -ResourceGroupName "Default-activityLogAlerts" -Name "actionGroup1"
```
#### After
```powershell
Get-AzActionGroup -ResourceGroupName "Default-activityLogAlerts" -Name "actionGroup1"

ArmRoleReceiver           : {}
AutomationRunbookReceiver : {}
AzureAppPushReceiver      : {}
AzureFunctionReceiver     : {}
EmailReceiver             : {}
Enabled                   : False
EventHubReceiver          : {}
GroupShortName            : ag1
Id                        : /subscriptions/{subid}/resourceGroups/Monitor-Action/providers/microsoft.insights/actionGroups/actiongroup1
ItsmReceiver              : {}
Location                  : northcentralus
LogicAppReceiver          : {}
Name                      : actiongroup1
ResourceGroupName         : Monitor-Action
SmsReceiver               : {}
Tag                       : {
                            }
Type                      : Microsoft.Insights/ActionGroups
VoiceReceiver             : {}
WebhookReceiver           : {}
```


### `Remove-AzActionGroup`
The cmdlet 'Remove-AzActionGroup' no longer supports the type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupResource' for parameter 'InputObject'.
The parameter set 'ByResourceId' for cmdlet 'Remove-AzActionGroup' has been removed.
The cmdlet 'Remove-AzActionGroup' no longer supports the parameter 'ResourceId' and no alias was found for the original parameter name.
The cmdlet 'Remove-AzActionGroup' no longer has output type 'Microsoft.Azure.AzureOperationResponse'.
The cmdlet 'Remove-AzActionGroup' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'Remove-AzActionGroup' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Remove-AzActionGroup' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.

#### Before
```powershell
Remove-AzActionGroup -ResourceGroupName "Default-Web-CentralUS" -Name "myActionGroup"

RequestId                                                                                                    StatusCode
---------                                                                                                    ----------
2c6c159b-0e73-4a01-a67b-c32c1a0008a3                                                                                 OK
```
#### After
```powershell
Remove-AzActionGroup -ResourceGroupName Monitor-Action -Name actiongroup1 --PassThur

True
```


### `Set-AzActionGroup`
The cmdlet 'Set-AzActionGroup' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
$email1 = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'user1@example.com'
$sms1 = New-AzActionGroupReceiver -Name 'user2' -SmsReceiver -CountryCode '1' -PhoneNumber '5555555555'
Set-AzActionGroup -Name $actionGroupName -ResourceGroupName $resourceGroupName -ShortName $shortName -Receiver $email1,$sms1
```
#### After
```powershell
$email1 = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user1
$sms1 = New-AzActionGroupSmsReceiverObject -CountryCode '{countrycode}' -Name user2 -PhoneNumber '{phonenumber}'
New-AzActionGroup -Name 'actiongroup1' -ResourceGroupName 'Monitor-Action' -Location northcentralus -GroupShortName ag1 -EmailReceiver $email1 -SmsReceiver $sms1
```


### `Test-AzActionGroup`
The cmdlet 'Test-AzActionGroup' no longer supports the type 'System.Collections.Generic.List`1[Microsoft.Azure.Commands.Insights.OutputClasses.PSActionGroupReceiverBase]' for parameter 'Receiver'.
The cmdlet 'Test-AzActionGroup' no longer has output type 'Microsoft.Azure.Commands.Insights.OutputClasses.PSTestNotificationDetailsResponse'.
The parameter set 'ByPropertyName' for cmdlet 'Test-AzActionGroup' is no longer the default parameter set.
The cmdlet 'Test-AzActionGroup' no longer supports the type 'Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer' for parameter 'DefaultProfile'.
The cmdlet 'Test-AzActionGroup' no longer supports the alias 'AzContext' for parameter 'DefaultProfile'.
The cmdlet 'Test-AzActionGroup' no longer supports the alias 'AzureRmContext' for parameter 'DefaultProfile'.
The parameter set 'ByPropertyName' for cmdlet 'Test-AzActionGroup' has been removed.

#### Before
```powershell
$email = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'test@test.example.com'
Test-AzActionGroup -AlertType servicehealth -Receiver $email -ResourceGroupName "test-RG" -ActionGroupName "test-AG"
```
#### After
```powershell
$sms1 = New-AzActionGroupSmsReceiverObject -CountryCode 86 -Name user1 -PhoneNumber 'phonenumber'
$email2 = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user2
Test-AzActionGroup -ActionGroupName actiongroup1 -ResourceGroupName monitor-action -AlertType servicehealth -Receiver $email2,$sms1

ActionDetail              : {{
                              "MechanismType": "Email",
                              "Name": "user2",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-11-08T05:16:09.6280455+00:00"
                            }, {
                              "MechanismType": "Sms",
                              "Name": "user1",
                              "Status": "Succeeded",
                              "SubState": "Default",
                              "SendTime": "2023-11-08T05:16:09.642967+00:00"
                            }}
CompletedTime             : 2023-11-08T05:18:10.6755827+00:00
ContextNotificationSource : Microsoft.Insights/TestNotification
ContextType               : Microsoft.Insights/ServiceHealth
CreatedTime               : 2023-11-08T05:16:00.7951739+00:00
State                     : Complete
```


### `New-AzActionGroupReceiver`
The cmdlet 'New-AzActionGroupReceiver' has been removed and no alias was found for the original cmdlet name.

#### Before
```powershell
$emailReceiver = New-AzActionGroupReceiver -Name 'emailReceiver1' -EmailReceiver -EmailAddress 'user1@example.com'
```
#### After
```powershell
$emailReceiver = New-AzActionGroupEmailReceiverObject -EmailAddress user@example.com -Name user1
```


## Az.Network

### `New-AzApplicationGatewayFirewallCustomRuleGroupByVariable`
"Geo" is no longwe a valid input for parameter `VariableName` in `NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable`

## Az.PowerBIEmbedded

### `Remove-AzPowerBIWorkspaceCollection`
The cmdlet 'Remove-AzPowerBIWorkspaceCollection' has been removed as Workspace Collection is no longer supported

### `Get-AzPowerBIWorkspaceCollection`
The cmdlet 'Get-AzPowerBIWorkspaceCollection' has been removed as Workspace Collection is no longer supported

### `Get-AzPowerBIWorkspaceCollectionAccessKey`
The cmdlet Get-AzPowerBIWorkspaceCollectionAccessKey' has been removed as Workspace Collection is no longer supported

### `Get-AzPowerBIWorkspace`
The cmdlet 'Get-AzPowerBIWorkspace' has been removed as Workspace Collection is no longer supported

### `New-AzPowerBIWorkspaceCollection`
The cmdlet 'New-AzPowerBIWorkspaceCollection' has been removed as Workspace Collection is no longer supported

### `Reset-AzPowerBIWorkspaceCollectionAccessKey`
The cmdlet 'Reset-AzPowerBIWorkspaceCollectionAccessKey' has been removed as Workspace Collection is no longer supported


## AZ.Storage

### `Get-AzStorageQueueStoredAcessPolicy`
Permissions in the ouput access policy is changed to a string like "raup"

### `New-AzStorageAccountSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageBlobSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageContainerSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageFileSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageQueueSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageShareSasToken`
The leading question mark '?' of the created SAS token is removed

### `New-AzStorageTableSasToken`
The leading question mark '?' of the created SAS token is removed

### `Set-AzStorageQueueStoredAccessPolicy`
Permissions in the ouput access policy is changed to a string like "raup"

