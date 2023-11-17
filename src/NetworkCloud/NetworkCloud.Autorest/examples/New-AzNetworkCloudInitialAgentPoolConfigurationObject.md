### Example 1: Create an in-memory object for InitialAgentPoolConfiguration.
```powershell
New-AzNetworkCloudInitialAgentPoolConfigurationObject -Count <Int64> -Mode <AgentPoolMode> -Name <String> -VMSkuName <String> -AdministratorConfigurationAdminUsername <String> -AdministratorConfigurationSshPublicKey <ISshPublicKey[]>  -AgentOptionHugepagesCount <Int64> -AgentOptionHugepagesSize <HugepagesSize> -AttachedNetworkConfigurationL2Network <IL2NetworkAttachmentConfiguration[]> -AttachedNetworkConfigurationL3Network <IL3NetworkAttachmentConfiguration[]> -AttachedNetworkConfigurationTrunkedNetwork <ITrunkedNetworkAttachmentConfiguration[]> -AvailabilityZone <String[]> -Label <IKubernetesLabel[]> -Taint <IKubernetesLabel[]> -UpgradeSettingMaxSurge <String>
```
 
Create an in-memory object for InitialAgentPoolConfiguration.
