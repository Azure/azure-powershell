---
Module Name: AzureRM.HDInsight
Module Guid: XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# AzureRM.HDInsight Module
## Description
The topics in this section document the Azure PowerShell cmdlets for Microsoft Azure HDInsight in the Azure Resource Manager (ARM) framework. These cmdlets are used to manage HDInsight clusters and the jobs that run on them. The cmdlets exist in the Microsoft.Azure.Commands.HDInsight namespace.

## AzureRM.HDInsight Cmdlets
### [Add-AzureRmHDInsightClusterIdentity](Add-AzureRmHDInsightClusterIdentity.md)
Adds a cluster identity to a cluster configuration object.

### [Add-AzureRmHDInsightComponentVersion](Add-AzureRmHDInsightComponentVersion.md)
Adds a version for a service running in a cluster to a cluster configuration object.

### [Add-AzureRmHDInsightConfigValues](Add-AzureRmHDInsightConfigValues.md)
Adds a Hadoop configuration value customization and/or a Hive shared library customization to a cluster configuration object.

### [Add-AzureRmHDInsightMetastore](Add-AzureRmHDInsightMetastore.md)
Adds a SQL Database to serve as a Hive or Oozie metastore to a cluster configuration object.

### [Add-AzureRmHDInsightScriptAction](Add-AzureRmHDInsightScriptAction.md)
Adds a script action to a cluster configuration object.

### [Add-AzureRmHDInsightSecurityProfile](Add-AzureRmHDInsightSecurityProfile.md)
Adds a security profileto a cluster configuration object.

### [Add-AzureRmHDInsightStorage](Add-AzureRmHDInsightStorage.md)
Adds an Azure Storage key to a cluster configuration object.

### [Disable-AzureRmHDInsightOperationsManagementSuite](Disable-AzureRmHDInsightOperationsManagementSuite.md)
Disables Operations Management Suite (OMS) in a HDInsight cluster and relevant logs will stop flowing to the OMS workspace specified during enable.

### [Enable-AzureRmHDInsightOperationsManagementSuite](Enable-AzureRmHDInsightOperationsManagementSuite.md)
Enables Operations Management Suite (OMS) in a HDInsight cluster and relevant logs will be sent to the OMS workspace specified during enable.

### [Get-AzureRmHDInsightCluster](Get-AzureRmHDInsightCluster.md)
Gets and lists all of the Azure HDInsight clusters associated with the current subscription or a specified resource group, or retrieves a specific cluster.

### [Get-AzureRmHDInsightJob](Get-AzureRmHDInsightJob.md)
Gets the list of jobs from a cluster and lists them in reverse chronological order, or retrieves a specific job.

### [Get-AzureRmHDInsightJobOutput](Get-AzureRmHDInsightJobOutput.md)
Gets the log output for a job from the storage account associated with a specified cluster.

### [Get-AzureRmHDInsightOperationsManagementSuite](Get-AzureRmHDInsightOperationsManagementSuite.md)
Gets the status of Operations Management Suite (OMS) installation on the cluster.

### [Get-AzureRmHDInsightPersistedScriptAction](Get-AzureRmHDInsightPersistedScriptAction.md)
Gets the persisted script actions for a cluster and lists them in chronological order, or gets details for a specified persisted script action.

### [Get-AzureRmHDInsightProperties](Get-AzureRmHDInsightProperties.md)
Gets properties about the HDInsight service, such as available locations and capacity.

### [Get-AzureRmHDInsightScriptActionHistory](Get-AzureRmHDInsightScriptActionHistory.md)
Gets the script action history for a cluster and lists it in reverse chronological order, or gets details of a previously executed script action.

### [Grant-AzureRmHDInsightHttpServicesAccess](Grant-AzureRmHDInsightHttpServicesAccess.md)
Grants HTTP access to the cluster.

### [Grant-AzureRmHDInsightRdpServicesAccess](Grant-AzureRmHDInsightRdpServicesAccess.md)
Grants RDP access to the Windows cluster.

### [Invoke-AzureRmHDInsightHiveJob](Invoke-AzureRmHDInsightHiveJob.md)
Submits a Hive query to an HDInsight cluster and retrieves query results in one operation.

### [New-AzureRmHDInsightCluster](New-AzureRmHDInsightCluster.md)
Creates an Azure HDInsight cluster in the specified resource group for the current subscription.

### [New-AzureRmHDInsightClusterConfig](New-AzureRmHDInsightClusterConfig.md)
Creates a non-persisted cluster configuration object that describes an Azure HDInsight cluster configuration.

### [New-AzureRmHDInsightHiveJobDefinition](New-AzureRmHDInsightHiveJobDefinition.md)
Creates a Hive job object.

### [New-AzureRmHDInsightMapReduceJobDefinition](New-AzureRmHDInsightMapReduceJobDefinition.md)
Creates a MapReduce job object.

### [New-AzureRmHDInsightPigJobDefinition](New-AzureRmHDInsightPigJobDefinition.md)
Creates a Pig job object.

### [New-AzureRmHDInsightSqoopJobDefinition](New-AzureRmHDInsightSqoopJobDefinition.md)
Creates a Sqoop job object.

### [New-AzureRmHDInsightStreamingMapReduceJobDefinition](New-AzureRmHDInsightStreamingMapReduceJobDefinition.md)
Creates a Streaming MapReduce job object.

### [Remove-AzureRmHDInsightCluster](Remove-AzureRmHDInsightCluster.md)
Removes the specified HDInsight cluster from the current subscription.

### [Remove-AzureRmHDInsightPersistedScriptAction](Remove-AzureRmHDInsightPersistedScriptAction.md)
Removes an persisted script action from an HDInsight cluster.

### [Revoke-AzureRmHDInsightHttpServicesAccess](Revoke-AzureRmHDInsightHttpServicesAccess.md)
Disables HTTP access to the cluster.

### [Revoke-AzureRmHDInsightRdpServicesAccess](Revoke-AzureRmHDInsightRdpServicesAccess.md)
Disables RDP access to a Windows cluster.

### [Set-AzureRmHDInsightClusterSize](Set-AzureRmHDInsightClusterSize.md)
Sets the number of Worker nodes in a specified cluster.

### [Set-AzureRmHDInsightDefaultStorage](Set-AzureRmHDInsightDefaultStorage.md)
Sets the default Storage account setting in a cluster configuration object.

### [Set-AzureRmHDInsightPersistedScriptAction](Set-AzureRmHDInsightPersistedScriptAction.md)
Sets a previously executed script action to be a persisted script action.

### [Start-AzureRmHDInsightJob](Start-AzureRmHDInsightJob.md)
Starts a defined Azure HDInsight job on a specified cluster.

### [Stop-AzureRmHDInsightJob](Stop-AzureRmHDInsightJob.md)
Stops a specified running job on a cluster.

### [Submit-AzureRmHDInsightScriptAction](Submit-AzureRmHDInsightScriptAction.md)
Submits a new script action to an Azure HDInsight cluster.

### [Use-AzureRmHDInsightCluster](Use-AzureRmHDInsightCluster.md)
Selects a cluster to be used with the Invoke-RmAzureHDInsightHiveJob cmdlet.

### [Wait-AzureRmHDInsightJob](Wait-AzureRmHDInsightJob.md)
Waits for the completion or failure of a specified job.

