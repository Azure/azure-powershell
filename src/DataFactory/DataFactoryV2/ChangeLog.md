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
* Added support copyComputeScale And pipelineExternalComputeScale in `Set-AzDataFactoryV2IntegrationRuntime` Command

## Version 1.17.1
* Added ParquetReadSettings in ADF
* Fixed minor issues

## Version 1.17.0
* Added DisablePublish to Set_AzDataFactoryV2 Command

## Version 1.16.13
* Updated ADF .Net SDK version to 9.2.0
* Added AzureBlobFS sasUri and sasToken properties in ADF
* Added AzureBlobStorage containerUri and authenticationType properties in ADF
* Added support copyComputeScale And pipelineExternalComputeScale in IntegrationRuntime

## Version 1.16.12
* Updated ADF .Net SDK version to 9.0.0

## Version 1.16.11
* Updated ADF .Net SDK version to 8.0.0

## Version 1.16.10
* Updated ADF .Net SDK version to 7.0.0

## Version 1.16.9
* Updated ADF .Net SDK version to 6.4.0

## Version 1.16.8
* Updated ADF .Net SDK version to 6.3.0

## Version 1.16.7
* Updated ADF .Net SDK version to 6.1.0
* Fixed Set-AzDataFactoryV2 -InputObject not correct with PublicNetworkAccess Parameter

## Version 1.16.6
* Updated ADF .Net SDK version to 6.0.0

## Version 1.16.5
* Updated ADF .Net SDK version to 5.4.0

## Version 1.16.4
* Updated ADF .Net SDK version to 5.2.0

## Version 1.16.3
* Updated ADF .Net SDK version to 5.1.0

## Version 1.16.2
* Updated ADF .Net SDK version to 5.0.0

## Version 1.16.1
* Updated ADF .Net SDK version to 4.28.0

## Version 1.16.0
* Added PublicNetworkAccess to Update_AzDataFactoryV2 Command
* Updated ADF .Net SDK version to 4.26.0

## Version 1.15.0
* Added a DataFlowEnableQuickReuse argument for the `Set-AzDataFactoryV2IntegrationRuntime` cmdlet to enable quick reuse of clusters in next pipeline activities.
* Updated ADF .Net SDK version to 4.25.0
* Added a VNetInjectionMethod argument for the `Set-AzDataFactoryV2IntegrationRuntime` cmdlet to support the express virtual network injection of Azure-SSIS Integration Runtime.

## Version 1.14.0
* Added a subnetId argument for the `Set-AzDataFactoryV2IntegrationRuntime` cmdlet to support RBAC checking for VNet injection against the subnet resource ID instead of the VNet resource ID.
* Added the `Get-AzDataFactoryV2IntegrationRuntimeOutboundNetworkDependenciesEndpoint` cmdlet to provide a list of outbound network dependencies for SSIS integration runtime in Azure Data Factory that joins a virtual network.
* Added PublicNetworkAccess to Data Factory.
* Updated ADF .Net SDK version to 4.23.0

## Version 1.13.1
* Updated ADF .Net SDK version to 4.21.0

## Version 1.13.0
* Added Customer Managed Key Encryption to DataFactory

## Version 1.12.1
* Updated ADF .Net SDK version to 4.19.0

## Version 1.12.0
* Added User Assigned Identities to Data Factory.
* Updated ADF .Net SDK version to 4.18.0

## Version 1.11.5
* Updated ADF .Net SDK version to 4.15.0

## Version 1.11.4
* Updated ADF .Net SDK version to 4.14.0

## Version 1.11.3
* Fixed the command `Invoke-AzDataFactoryV2Pipeline` for SupportsShouldProcess issue

## Version 1.11.2
* Updated ADF .Net SDK version to 4.13.0

## Version 1.11.1
* Improved error message of `New-AzDataFactoryV2LinkedServiceEncryptedCredential` command

## Version 1.11.0
* Updated ADF .Net SDK version to 4.12.0
* Updated ADF encryption client SDK version to 4.14.7587.7
* Added `Stop-AzDataFactoryV2TriggerRun` and `Invoke-AzDataFactoryV2TriggerRun` commands

## Version 1.10.2
* Fixed typo in output messages

## Version 1.10.1
* Updated ADF .Net SDK version to 4.11.0

## Version 1.10.0
* Added missing properties to PSPipelineRun class.

## Version 1.9.0

* Added global parameters to Data Factory.

## Version 1.8.2
* Updated ADF .Net SDK version to 4.9.0

## Version 1.8.1
* Updated assembly version of data factory V2 cmdlets

## Version 1.8.0
* Supported CRUD of data flow runtime properties in Managed IR.

## Version 1.7.0
* Updated ADF .Net SDK version to 4.8.0
* Added optional parameters to `Invoke-AzDataFactoryV2Pipeline` command to support rerun

## Version 1.6.1
* Update ADF .Net SDK version to 4.7.0

## Version 1.6.0
* Add AutoUpdateETA, LatestVersion, PushedVersion, TaskQueueId and VersionStatus properties for Get-AzDataFactoryV2IntegrationRuntime cmd

* Update ADF .Net SDK version to 4.6.0
* Add parameter "PublicIPs" for "Set-AzureRmDataFactoryV2IntegrationRuntime" cmd 
to enable create Azure-SSIS IR with static public IP addresses.

## Version 1.5.1
* Update ADF .Net SDK version to 4.5.0
* Update references in .psd1 to use relative path

## Version 1.5.0
* Update ADF .Net SDK version to 4.4.0
* Add parameter "ExpressCustomSetup" for "Set-AzureRmDataFactoryV2IntegrationRuntime" cmd to enable setup configurations and 3rd party components without custom setup script.

## Version 1.4.1
* Update ADF .Net SDK version to 4.3.0

## Version 1.4.0
* Adding CRUD commands for ADF V2 data flow: Set-AzDataFactoryV2DataFlow, Remove-AzDataFactoryV2DataFlow, and Get-AzDataFactoryV2DataFlow.
* Adding action commands for ADF V2 data flow debug Session: Start-AzDataFactoryV2DataFlowDebugSession, Get-AzDataFactoryV2DataFlowDebugSession, Add-AzDataFactoryV2DataFlowDebugSessionPackage, Invoke-AzDataFactoryV2DataFlowDebugSessionCommand and Stop-AzDataFactoryV2DataFlowDebugSession.
* Update ADF .Net SDK version to 4.2.0

## Version 1.3.0
* Adding 3 new commands for ADF V2 - Add-AzDataFactoryV2TriggerSubscription, Remove-AzDataFactoryV2TriggerSubscription, and Get-AzDataFactoryV2TriggerSubscriptionStatus
* Updated ADF .Net SDK version to 4.1.3


## Version 1.2.0
* Fix typo to capitalize "Windows" in 'New-AzDataFactoryEncryptValue" documentation
* Fixed miscellaneous typos across module
* Updated ADF .Net SDK version to 4.1.2
* Add parameter "DataProxyIntegrationRuntimeName", "DataProxyStagingLinkedServiceName" and "DataProxyStagingPath" for "Set-AzureRmDataFactoryV2IntegrationRuntime" cmd to enable set up Self-Hosted Integration Runtime as a proxy for SSIS Integration Runtime
* Updated PSTriggerRun to show the triggered pipelines, message and properties, and PSActivityRun to show the activity type

## Version 1.1.3
* Updated ADF .Net SDK version to 4.1.0
* Fix typo in documentation for `Get-AzDataFactoryV2PipelineRun`

## Version 1.1.2
* Updating the output of get activity runs, get pipeline runs, and get trigger runs ADF cmdlets to support Select-Object pipe.

## Version 1.1.1
* Add SsisProperties if NodeCount not null for managed integration runtime.

## Version 1.1.0
* Updated ADF .Net SDK version to 3.0.2
* Updated Set-AzDataFactoryV2 cmdlet with extra parameters for RepoConfiguration related settings.

## Version 1.0.2
* Updated ADF .Net SDK version to 3.0.1

## Version 1.0.1
* Updated ADF .Net SDK version to 3.0.0

## Version 1.0.0
* General availability of `Az.DataFactory` module
* Removed -LinkedServiceName parameter from Get-AzDataFactoryV2ActivityRun
