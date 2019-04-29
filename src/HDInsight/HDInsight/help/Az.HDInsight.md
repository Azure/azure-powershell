---
Module Name: Az.HDInsight
Module Guid: 3fd1475f-cb23-4ffb-bf08-33d94b7d1acb
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.hdinsight
Help Version: 4.1.2.0
Locale: en-US
---

# Az.HDInsight Module
## Description
The topics in this section document the Azure PowerShell cmdlets for Microsoft Azure HDInsight in the Azure Resource Manager (ARM) framework. These cmdlets are used to manage HDInsight clusters and the jobs that run on them. The cmdlets exist in the Microsoft.Azure.Commands.HDInsight namespace.

## Az.HDInsight Cmdlets
### [Add-AzHDInsightClusterIdentity](Add-AzHDInsightClusterIdentity.md)
Adds a cluster identity to a cluster configuration object.

### [Add-AzHDInsightComponentVersion](Add-AzHDInsightComponentVersion.md)
Adds a version for a service running in a cluster to a cluster configuration object.

### [Add-AzHDInsightConfigValue](Add-AzHDInsightConfigValue.md)
Adds a Hadoop configuration value customization and/or a Hive shared library customization to a cluster configuration object.

### [Add-AzHDInsightMetastore](Add-AzHDInsightMetastore.md)
Adds a SQL Database to serve as a Hive or Oozie metastore to a cluster configuration object.

### [Add-AzHDInsightScriptAction](Add-AzHDInsightScriptAction.md)
Adds a script action to a cluster configuration object.

### [Add-AzHDInsightSecurityProfile](Add-AzHDInsightSecurityProfile.md)
Adds a security profileto a cluster configuration object.

### [Add-AzHDInsightStorage](Add-AzHDInsightStorage.md)
Adds an Azure Storage key to a cluster configuration object.

### [Disable-AzHDInsightOperationsManagementSuite](Disable-AzHDInsightOperationsManagementSuite.md)
Disables Operations Management Suite (OMS) in a HDInsight cluster and relevant logs will stop flowing to the OMS workspace specified during enable.

### [Enable-AzHDInsightOperationsManagementSuite](Enable-AzHDInsightOperationsManagementSuite.md)
Enables Operations Management Suite (OMS) in a HDInsight cluster and relevant logs will be sent to the OMS workspace specified during enable.

### [Get-AzHDInsightCluster](Get-AzHDInsightCluster.md)
Gets and lists all of the Azure HDInsight clusters associated with the current subscription or a specified resource group, or retrieves a specific cluster.

### [Get-AzHDInsightJob](Get-AzHDInsightJob.md)
Gets the list of jobs from a cluster and lists them in reverse chronological order, or retrieves a specific job.

### [Get-AzHDInsightJobOutput](Get-AzHDInsightJobOutput.md)
Gets the log output for a job from the storage account associated with a specified cluster.

### [Get-AzHDInsightOperationsManagementSuite](Get-AzHDInsightOperationsManagementSuite.md)
Gets the status of Operations Management Suite (OMS) installation on the cluster.

### [Get-AzHDInsightPersistedScriptAction](Get-AzHDInsightPersistedScriptAction.md)
Gets the persisted script actions for a cluster and lists them in chronological order, or gets details for a specified persisted script action.

### [Get-AzHDInsightProperty](Get-AzHDInsightProperty.md)
Gets properties about the HDInsight service, such as available locations and capacity.

### [Get-AzHDInsightScriptActionHistory](Get-AzHDInsightScriptActionHistory.md)
Gets the script action history for a cluster and lists it in reverse chronological order, or gets details of a previously executed script action.

### [Grant-AzHDInsightHttpServicesAccess](Grant-AzHDInsightHttpServicesAccess.md)
Grants HTTP access to the cluster.

### [Grant-AzHDInsightRdpServicesAccess](Grant-AzHDInsightRdpServicesAccess.md)
Grants RDP access to the Windows cluster.

### [Invoke-AzHDInsightHiveJob](Invoke-AzHDInsightHiveJob.md)
Submits a Hive query to an HDInsight cluster and retrieves query results in one operation.

### [New-AzHDInsightCluster](New-AzHDInsightCluster.md)
Creates an Azure HDInsight cluster in the specified resource group for the current subscription.

### [New-AzHDInsightClusterConfig](New-AzHDInsightClusterConfig.md)
Creates a non-persisted cluster configuration object that describes an Azure HDInsight cluster configuration.

### [New-AzHDInsightHiveJobDefinition](New-AzHDInsightHiveJobDefinition.md)
Creates a Hive job object.

### [New-AzHDInsightMapReduceJobDefinition](New-AzHDInsightMapReduceJobDefinition.md)
Creates a MapReduce job object.

### [New-AzHDInsightPigJobDefinition](New-AzHDInsightPigJobDefinition.md)
Creates a Pig job object.

### [New-AzHDInsightSqoopJobDefinition](New-AzHDInsightSqoopJobDefinition.md)
Creates a Sqoop job object.

### [New-AzHDInsightStreamingMapReduceJobDefinition](New-AzHDInsightStreamingMapReduceJobDefinition.md)
Creates a Streaming MapReduce job object.

### [Remove-AzHDInsightCluster](Remove-AzHDInsightCluster.md)
Removes the specified HDInsight cluster from the current subscription.

### [Remove-AzHDInsightPersistedScriptAction](Remove-AzHDInsightPersistedScriptAction.md)
Removes an persisted script action from an HDInsight cluster.

### [Revoke-AzHDInsightHttpServicesAccess](Revoke-AzHDInsightHttpServicesAccess.md)
Disables HTTP access to the cluster.

### [Revoke-AzHDInsightRdpServicesAccess](Revoke-AzHDInsightRdpServicesAccess.md)
Disables RDP access to a Windows cluster.

### [Set-AzHDInsightClusterSize](Set-AzHDInsightClusterSize.md)
Sets the number of Worker nodes in a specified cluster.

### [Set-AzHDInsightDefaultStorage](Set-AzHDInsightDefaultStorage.md)
Sets the default Storage account setting in a cluster configuration object.

### [Set-AzHDInsightPersistedScriptAction](Set-AzHDInsightPersistedScriptAction.md)
Sets a previously executed script action to be a persisted script action.

### [Start-AzHDInsightJob](Start-AzHDInsightJob.md)
Starts a defined Azure HDInsight job on a specified cluster.

### [Stop-AzHDInsightJob](Stop-AzHDInsightJob.md)
Stops a specified running job on a cluster.

### [Submit-AzHDInsightScriptAction](Submit-AzHDInsightScriptAction.md)
Submits a new script action to an Azure HDInsight cluster.

### [Use-AzHDInsightCluster](Use-AzHDInsightCluster.md)
Selects a cluster to be used with the Invoke-RmAzureHDInsightHiveJob cmdlet.

### [Wait-AzHDInsightJob](Wait-AzHDInsightJob.md)
Waits for the completion or failure of a specified job.

