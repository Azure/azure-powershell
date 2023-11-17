# Upcoming breaking changes in Azure PowerShell

## Az.Aks

### `New-AzAksCluster`

- Parameter breaking-change will happen to all parameter sets
  - `-DockerBridgeCidr`
    - DockerBridgeCidr parameter will be deprecated in Az 11.0.0 without being replaced.
    - This change is expected to take effect from Az.Aks version: 6.0.0 and Az version: 11.0.0

## Az.Compute

### `New-AzDisk`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting in November 2023 the "New-AzDisk" cmdlet will deploy with the Trusted Launch configuration by default. This includes defaulting the "HyperVGeneration" parameter to "v2". To know more about Trusted Launch, please visit https://aka.ms/TLaD
  - This change is expected to take effect from Az.Compute version: 7.0.0 and Az version: 11.0.0

### `New-AzVM`

- Cmdlet breaking-change will happen to all parameter sets
  - Consider using the image alias including the version of the distribution you want to use in the "-Image" parameter of the "New-AzVM" cmdlet. On April 30, 2023, the image deployed using `UbuntuLTS` will reach its end of life. In October 2023, the aliases `UbuntuLTS`, `CentOS`, `Debian`, and `RHEL` will be removed.
  - This change is expected to take effect from Az.Compute version: 7.0.0 and Az version: 11.0.0
  - Starting in November 2023 the "New-AzVM" cmdlet will deploy with the Trusted Launch configuration by default. To know more about Trusted Launch, please visit https://aka.ms/TLaD
  - This change is expected to take effect from Az.Compute version: 7.0.0 and Az version: 11.0.0

### `New-AzVmss`

- Cmdlet breaking-change will happen to all parameter sets
  - Starting November 2023, the "New-AzVmss" cmdlet will default to Trusted Launch VMSS. For more info, visit https://aka.ms/TLaD.
  - This change is expected to take effect from Az.Compute version: 7.0.0 and Az version: 11.0.0
  - Starting November 2023, the "New-AzVmss" cmdlet will use new defaults: Flexible orchestration mode and enable NATv2 configuration for Load Balancer. To learn more about Flexible Orchestration modes, visit https://aka.ms/orchestrationModeVMSS.
  - This change is expected to take effect from Az.Compute version: 7.0.0 and Az version: 11.0.0
  - Consider using the image alias including the version of the distribution you want to use in the "-ImageName" parameter of the "New-AzVmss" cmdlet. On April 30, 2023, the image deployed using `UbuntuLTS` will reach its end of life. In November 2023, the aliases `UbuntuLTS`, `CentOS`, `Debian`, and `RHEL` will be removed.
  - This change is expected to take effect from Az.Compute version: 7.0.0 and Az version: 11.0.0

## Az.ContainerInstance

### `Get-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20221001Preview.IContainerGroup' is changing
  - The following properties in the output type are being deprecated : 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'
  - The following properties are being added to the output type : 'PreviousState' 'PreviousStateDetailStatus' 'PreviousStateExitCode' 'PreviousStateFinishTime' 'PreviousStateStartTime'
  - Change description : The parameters starts with PreviouState will be corrected as PreviousState. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.ContainerInstance version : '4.0.0'

### `Remove-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20221001Preview.IContainerGroup' is changing
  - The following properties in the output type are being deprecated : 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'
  - The following properties are being added to the output type : 'PreviousState' 'PreviousStateDetailStatus' 'PreviousStateExitCode' 'PreviousStateFinishTime' 'PreviousStateStartTime'
  - Change description : The parameters starts with PreviouState will be corrected as PreviousState. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.ContainerInstance version : '4.0.0'

### `Restart-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'bool' is changing
  - The following properties in the output type are being deprecated : 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'
  - The following properties are being added to the output type : 'PreviousState' 'PreviousStateDetailStatus' 'PreviousStateExitCode' 'PreviousStateFinishTime' 'PreviousStateStartTime'
  - Change description : The parameters starts with PreviouState will be corrected as PreviousState. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.ContainerInstance version : '4.0.0'

### `Start-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'bool' is changing
  - The following properties in the output type are being deprecated : 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'
  - The following properties are being added to the output type : 'PreviousState' 'PreviousStateDetailStatus' 'PreviousStateExitCode' 'PreviousStateFinishTime' 'PreviousStateStartTime'
  - Change description : The parameters starts with PreviouState will be corrected as PreviousState. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.ContainerInstance version : '4.0.0'

### `Stop-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'bool' is changing
  - The following properties in the output type are being deprecated : 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'
  - The following properties are being added to the output type : 'PreviousState' 'PreviousStateDetailStatus' 'PreviousStateExitCode' 'PreviousStateFinishTime' 'PreviousStateStartTime'
  - Change description : The parameters starts with PreviouState will be corrected as PreviousState. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.ContainerInstance version : '4.0.0'

### `Update-AzContainerGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20221001Preview.IContainerGroup' is changing
  - The following properties in the output type are being deprecated : 'PreviouState' 'PreviouStateDetailStatus' 'PreviouStateExitCode' 'PreviouStateFinishTime' 'PreviouStateStartTime'
  - The following properties are being added to the output type : 'PreviousState' 'PreviousStateDetailStatus' 'PreviousStateExitCode' 'PreviousStateFinishTime' 'PreviousStateStartTime'
  - Change description : The parameters starts with PreviouState will be corrected as PreviousState. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.ContainerInstance version : '4.0.0'

## Az.DesktopVirtualization

### `New-AzWvdScalingPlan`

- Parameter breaking-change will happen to all parameter sets
  - `-HostPoolType`
    - The parameter : 'HostPoolType' is changing.
    - Change description : The allowed value of this parameter changed from 'BYODesktop, Personal, Pooled' to 'Pooled' 
    - The change is expected to take effect in Az.DesktopVirtualization the version : '4.0.0'

## Az.HDInsight

### `Add-AzHDInsightClusterIdentity`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Add-AzHDInsightComponentVersion`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Add-AzHDInsightConfigValue`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Add-AzHDInsightMetastore`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Add-AzHDInsightScriptAction`

- Parameter breaking-change will happen to all parameter sets
  - `-NodeType`
    - The parameter : 'NodeType' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Management.HDInsight.Models.ClusterNodeType' to 'RuntimeScriptActionClusterNodeType'.
    - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Add-AzHDInsightSecurityProfile`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Add-AzHDInsightStorage`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Disable-AzHDInsightAzureMonitor`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Enable-AzHDInsightAzureMonitor`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Get-AzHDInsightAzureMonitor`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Get-AzHDInsightCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Get-AzHDInsightClusterAutoscaleConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Get-AzHDInsightHost`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Get-AzHDInsightProperty`

- Cmdlet breaking-change will happen to all parameter sets
  - The generic type for 'property ComponentVersions' will change from 'System.Collections.Generic.IDictionary`2[System.String,System.String]' to 'System.Collections.Generic.IReadOnlyDictionary`2[System.String,System.String]'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `New-AzHDInsightCluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-ScriptActions`
    - The parameter : 'NodeType' is changing.
    The type of the parameter is changing from 'Microsoft.Azure.Management.HDInsight.Models.ClusterNodeType' to 'RuntimeScriptActionClusterNodeType'.
    - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `New-AzHDInsightClusterConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Remove-AzHDInsightClusterAutoscaleConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Set-AzHDInsightClusterAutoscaleConfiguration`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Set-AzHDInsightClusterDiskEncryptionKey`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Set-AzHDInsightClusterSize`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' is changing
  - The following properties in the output type are being deprecated : 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties DiskEncryption' 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups> WorkerNodeDataDisksGroups'
  - The following properties are being added to the output type : 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties DiskEncryption' 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup> WorkerNodeDataDisksGroups'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Set-AzHDInsightDefaultStorage`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightConfig' is changing
  - The following properties in the output type are being deprecated : 'Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - The following properties are being added to the output type : 'Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions'
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

### `Set-AzHDInsightGatewayCredential`

- Cmdlet breaking-change will happen to all parameter sets
  - The type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' will change from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.The type of property 'WorkerNodeDataDisksGroups' will change from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  - This change is expected to take effect from Az.HDInsight version: 7.0.0 and Az version: 11.0.0

## Az.Maintenance

### `New-AzMaintenanceConfiguration`

- Parameter breaking-change will happen to all parameter sets
  - `-PostTask`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.Maintenance version: 2.0.0 and Az version: 11.0.0
  - `-PreTask`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.Maintenance version: 2.0.0 and Az version: 11.0.0

## Az.Monitor

### `Get-AzDataCollectionRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter set ByResourceId will be deprecated
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `New-AzActionGroupReceiver`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameters about receiver will be replaced by child types.
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `New-AzDataCollectionRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter RuleFile will be replaced by JsonFilePath.
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `Remove-AzActionGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter set ByResourceId will be deprecated
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `Remove-AzDataCollectionRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter set ByResourceId will be deprecated
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `Remove-AzDataCollectionRuleAssociation`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter set ByResourceId will be deprecated
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `Set-AzActionGroup`

- Parameter breaking-change will happen to all parameter sets
  - `-DisableGroup`
    - Parameter DisableGroup will be replaced by Enabled
    - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0
  - `-Receiver`
    - Parameters receiver will be replaced by child parameters.
    - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0
  - `-ResourceId`
    - Parameter set ByResourceId will be deprecated
    - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0
  - `-Tag`
    - The parameter : 'Tag' is changing.
    The type of the parameter is changing from 'System.Collections.IDictionary' to 'Hashtable'.
    - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `Set-AzDataCollectionRule`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter set ByResourceId will be deprecated
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

### `Test-AzActionGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet 'New-AzActionGroupNotification' is replacing this cmdlet.
  - This change is expected to take effect from Az.Monitor version: 5.0.0 and Az version: 11.0.0

## Az.Network

### `New-AzApplicationGatewayFirewallCustomRuleGroupByVariable`

- Parameter breaking-change will happen to all parameter sets
  - `-VariableName`
    - Geo would be invalid for parameter VariableName
    - This change is expected to take effect from Az.Network version: 7.0.0 and Az version: 11.0.0

## Az.PowerBIEmbedded

### `Get-AzPowerBIWorkspace`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.PowerBIEmbedded version: 2.0.0 and Az version: 11.0.0

### `Get-AzPowerBIWorkspaceCollection`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.PowerBIEmbedded version: 2.0.0 and Az version: 11.0.0

### `Get-AzPowerBIWorkspaceCollectionAccessKey`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.PowerBIEmbedded version: 2.0.0 and Az version: 11.0.0

### `New-AzPowerBIWorkspaceCollection`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.PowerBIEmbedded version: 2.0.0 and Az version: 11.0.0

### `Remove-AzPowerBIWorkspaceCollection`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.PowerBIEmbedded version: 2.0.0 and Az version: 11.0.0

### `Reset-AzPowerBIWorkspaceCollectionAccessKey`

- Cmdlet breaking-change will happen to all parameter sets
  - The cmdlet is being deprecated. There will be no replacement for it.
  - This change is expected to take effect from Az.PowerBIEmbedded version: 2.0.0 and Az version: 11.0.0

## Az.RecoveryServices

### `Get-AzRecoveryServicesVaultSettingsFile`

- Parameter breaking-change will happen to all parameter sets
  - `-Certificate`
    - Parameter is being deprecated without being replaced
    - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 11.0.0

## Az.Resources

### `Get-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Get-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Get-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Get-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `New-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `New-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `New-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `New-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Set-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Set-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Set-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

### `Set-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.0.0 and Az version: 11.0.0

## Az.SecurityInsights

### `Get-AzSentinelBookmarkRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEnrichment`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntity`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntityActivity`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntityInsight`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntityQuery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntityQueryTemplate`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntityRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelEntityTimeline`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelIncidentEntity`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Get-AzSentinelSetting`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelAlertRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Parameters of NRT set will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelAutomationRule`

- Cmdlet breaking-change will happen to parameter set `NewAzSentinelAutomationRule_Create`
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : ParameterSet Create will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

- Parameter breaking-change will happen to parameter set `NewAzSentinelAutomationRule_CreateExpanded`
  - `-Action`
    - The parameter : 'Action' is becoming mandatory.
    - Change description : Action is required. 
    - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
    - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'
  - `-DisplayName`
    - The parameter : 'DisplayName' is becoming mandatory.
    - Change description : DisplayName is required. 
    - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
    - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'
  - `-Order`
    - The parameter : 'Order' is becoming mandatory.
    - Change description : Order is required. 
    - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
    - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelBookmark`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : ParameterSet Create will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelBookmarkRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelDataConnector`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : ParameterSets AmazonWebServicesS3, Dynamics365, MicrosoftThreatIntelligence, MicrosoftThreatProtection, OfficeATP, OfficeIRM, ThreatIntelligenceTaxii will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelEntityQuery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelIncident`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet parameter set is being deprecated. There will be no replacement for it.
  - Change description : ParameterSet Create will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `New-AzSentinelIncidentTeam`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Remove-AzSentinelBookmarkRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Remove-AzSentinelEntityQuery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Test-AzSentinelDataConnectorCheckRequirement`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Update-AzSentinelAlertRule`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : Parameters of NRT set will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Update-AzSentinelAutomationRule`

- Parameter breaking-change will happen to all parameter sets
  - `-Action`
    - The parameter : 'Action' is becoming mandatory.
    - Change description : Action is required. 
    - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
    - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'
  - `-DisplayName`
    - The parameter : 'DisplayName' is becoming mandatory.
    - Change description : DisplayName is required. 
    - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
    - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'
  - `-Order`
    - The parameter : 'Order' is becoming mandatory.
    - Change description : Order is required. 
    - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
    - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Update-AzSentinelBookmarkRelation`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Update-AzSentinelDataConnector`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - Change description : ParameterSets AmazonWebServicesS3, Dynamics365, MicrosoftThreatIntelligence, MicrosoftThreatProtection, OfficeATP, OfficeIRM, ThreatIntelligenceTaxii will be deprecated. 
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Update-AzSentinelEntityQuery`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

### `Update-AzSentinelSetting`

- Cmdlet breaking-change will happen to all parameter sets
  The cmdlet is being deprecated. There will be no replacement for it.
  - This change will take effect on '11/15/2023'- The change is expected to take effect in Az version : '11.0.0'
  - The change is expected to take effect in Az.SecurityInsights version : '4.0.0'

## Az.Storage

### `Get-AzStorageQueueStoredAccessPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - Permissions in the ouput access policy will be changed to a string like "raup" in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzDataLakeGen2SasToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageAccount`

- Cmdlet breaking-change will happen to all parameter sets
  - Default value of AllowBlobPublicAccess and AllowCrossTenantReplication settings on storage account will be changed to False in the future release. 
  When AllowBlobPublicAccess is False on a storage account, container ACLs cannot be configured to allow anonymous access to blobs within the storage account. 
  When AllowCrossTenantReplication is False on a storage account, cross AAD tenant object replication is not allowed when setting up Object Replication policies.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageAccountSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageBlobSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageContainerSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageContext`

- Parameter breaking-change will happen to all parameter sets
  - `-SasToken`
    - The SAS token in created Storage context properties 'ConnectionString' and 'StorageAccount.Credentials' won't have the leading question mark '?' in a future release.
    - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageFileSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageQueueSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageShareSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageTableSASToken`

- Cmdlet breaking-change will happen to all parameter sets
  - The leading question mark '?' of the created SAS token will be removed in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `Set-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-EnableLargeFileShare`
    - EnableLargeFileShare parameter will be deprecated in a future release.
    - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `Set-AzStorageQueueStoredAccessPolicy`

- Cmdlet breaking-change will happen to all parameter sets
  - Permissions in the ouput access policy will be changed to a string like "raup" in a future release.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

