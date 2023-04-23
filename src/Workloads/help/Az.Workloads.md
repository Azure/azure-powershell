---
Module Name: Az.Workloads
Module Guid: ee197d70-9add-4652-9b94-eab7bc0e93e1
Download Help Link: https://learn.microsoft.com/powershell/module/az.workloads
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Workloads Module
## Description
Microsoft Azure PowerShell: Workloads cmdlets

## Az.Workloads Cmdlets
### [Get-AzWorkloadsMonitor](Get-AzWorkloadsMonitor.md)
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.

### [Get-AzWorkloadsProviderInstance](Get-AzWorkloadsProviderInstance.md)
Gets properties of a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

### [Get-AzWorkloadsSapApplicationInstance](Get-AzWorkloadsSapApplicationInstance.md)
Gets the SAP Application Server Instance corresponding to the Virtual Instance for SAP solutions resource.

### [Get-AzWorkloadsSapCentralInstance](Get-AzWorkloadsSapCentralInstance.md)
Gets the SAP Central Services Instance resource.

### [Get-AzWorkloadsSapDatabaseInstance](Get-AzWorkloadsSapDatabaseInstance.md)
Gets the SAP Database Instance resource.

### [Get-AzWorkloadsSapLandscapeMonitor](Get-AzWorkloadsSapLandscapeMonitor.md)
Gets configuration values for Single Pane Of Glass for SAP monitor for the specified subscription, resource group, and resource name.

### [Get-AzWorkloadsSapVirtualInstance](Get-AzWorkloadsSapVirtualInstance.md)
Gets a Virtual Instance for SAP solutions resource

### [Invoke-AzWorkloadsSapDiskConfiguration](Invoke-AzWorkloadsSapDiskConfiguration.md)
Get the SAP Disk Configuration Layout prod/non-prod SAP System.

### [Invoke-AzWorkloadsSapSizingRecommendation](Invoke-AzWorkloadsSapSizingRecommendation.md)
Get SAP sizing recommendations by providing input SAPS for application tier and memory required for database tier

### [Invoke-AzWorkloadsSapSupportedSku](Invoke-AzWorkloadsSapSupportedSku.md)
Get a list of SAP supported SKUs for ASCS, Application and Database tier.

### [New-AzWorkloadsMonitor](New-AzWorkloadsMonitor.md)
Creates a SAP monitor for the specified subscription, resource group, and resource name.

### [New-AzWorkloadsProviderDB2InstanceObject](New-AzWorkloadsProviderDB2InstanceObject.md)
Create an in-memory object for DB2ProviderInstanceProperties.

### [New-AzWorkloadsProviderHanaDbInstanceObject](New-AzWorkloadsProviderHanaDbInstanceObject.md)
Create an in-memory object for HanaDbProviderInstanceProperties.

### [New-AzWorkloadsProviderInstance](New-AzWorkloadsProviderInstance.md)
Creates a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

### [New-AzWorkloadsProviderPrometheusHaClusterInstanceObject](New-AzWorkloadsProviderPrometheusHaClusterInstanceObject.md)
Create an in-memory object for PrometheusHaClusterProviderInstanceProperties.

### [New-AzWorkloadsProviderPrometheusOSInstanceObject](New-AzWorkloadsProviderPrometheusOSInstanceObject.md)
Create an in-memory object for PrometheusOSProviderInstanceProperties.

### [New-AzWorkloadsProviderSapNetWeaverInstanceObject](New-AzWorkloadsProviderSapNetWeaverInstanceObject.md)
Create an in-memory object for SapNetWeaverProviderInstanceProperties.

### [New-AzWorkloadsProviderSqlServerInstanceObject](New-AzWorkloadsProviderSqlServerInstanceObject.md)
Create an in-memory object for MsSqlServerProviderInstanceProperties.

### [New-AzWorkloadsSapLandscapeMonitor](New-AzWorkloadsSapLandscapeMonitor.md)
Creates a SAP Landscape Monitor Dashboard for the specified subscription, resource group, and resource name.

### [New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject](New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject.md)
Create an in-memory object for SapLandscapeMonitorMetricThresholds.

### [New-AzWorkloadsSapLandscapeMonitorSidMappingObject](New-AzWorkloadsSapLandscapeMonitorSidMappingObject.md)
Create an in-memory object for SapLandscapeMonitorSidMapping.

### [New-AzWorkloadsSapVirtualInstance](New-AzWorkloadsSapVirtualInstance.md)
Creates a Virtual Instance for SAP solutions (VIS) resource

### [Remove-AzWorkloadsMonitor](Remove-AzWorkloadsMonitor.md)
Deletes a SAP monitor with the specified subscription, resource group, and SAP monitor name.

### [Remove-AzWorkloadsProviderInstance](Remove-AzWorkloadsProviderInstance.md)
Deletes a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

### [Remove-AzWorkloadsSapLandscapeMonitor](Remove-AzWorkloadsSapLandscapeMonitor.md)
Deletes a SAP Landscape Monitor Dashboard with the specified subscription, resource group, and SAP monitor name.

### [Remove-AzWorkloadsSapVirtualInstance](Remove-AzWorkloadsSapVirtualInstance.md)
Deletes a Virtual Instance for SAP solutions resource and its child resources, that is the associated Central Services Instance, Application Server Instances and Database Instance.

### [Start-AzWorkloadsSapApplicationInstance](Start-AzWorkloadsSapApplicationInstance.md)
Starts the SAP Application Server Instance.

### [Start-AzWorkloadsSapCentralInstance](Start-AzWorkloadsSapCentralInstance.md)
Starts the SAP Central Services Instance.

### [Start-AzWorkloadsSapDatabaseInstance](Start-AzWorkloadsSapDatabaseInstance.md)
Starts the database instance of the SAP system.

### [Start-AzWorkloadsSapVirtualInstance](Start-AzWorkloadsSapVirtualInstance.md)
Starts the SAP application, that is the Central Services instance and Application server instances.

### [Stop-AzWorkloadsSapApplicationInstance](Stop-AzWorkloadsSapApplicationInstance.md)
Stops the SAP Application Server Instance.

### [Stop-AzWorkloadsSapCentralInstance](Stop-AzWorkloadsSapCentralInstance.md)
Stops the SAP Central Services Instance.

### [Stop-AzWorkloadsSapDatabaseInstance](Stop-AzWorkloadsSapDatabaseInstance.md)
Stops the database instance of the SAP system.

### [Stop-AzWorkloadsSapVirtualInstance](Stop-AzWorkloadsSapVirtualInstance.md)
Stops the SAP Application, that is the Application server instances and Central Services instance.

### [Update-AzWorkloadsMonitor](Update-AzWorkloadsMonitor.md)
Patches the Tags field of a SAP monitor for the specified subscription, resource group, and SAP monitor name.

### [Update-AzWorkloadsSapApplicationInstance](Update-AzWorkloadsSapApplicationInstance.md)
Puts the SAP Application Server Instance resource.

### [Update-AzWorkloadsSapCentralInstance](Update-AzWorkloadsSapCentralInstance.md)
Updates the SAP Central Services Instance resource.


This can be used to update tags on the resource.

### [Update-AzWorkloadsSapDatabaseInstance](Update-AzWorkloadsSapDatabaseInstance.md)
Updates the Database resource.

### [Update-AzWorkloadsSapLandscapeMonitor](Update-AzWorkloadsSapLandscapeMonitor.md)
Patches the SAP Landscape Monitor Dashboard for the specified subscription, resource group, and SAP monitor name.

### [Update-AzWorkloadsSapVirtualInstance](Update-AzWorkloadsSapVirtualInstance.md)
Updates a Virtual Instance for SAP solutions resource

