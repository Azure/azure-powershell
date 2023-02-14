## Breaking changes in module Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll

 The following cmdlets were affected this release:




### **Update-AzStorageAccountNetworkRuleSet**
The following parameters were affected this release:
#### **DefaultAction**
 - Cmdlet : 'Update-AzStorageAccountNetworkRuleSet'
 - The parameter : 'DefaultAction' is changing.
	Change description : The DefaultAction value will change in a future release from: Allow = 1, Deny = 0, to: Allow = 0, Deny = 1.




## Breaking changes in module Microsoft.Azure.PowerShell.Cmdlets.Storage.dll

 The following cmdlets were affected this release:




### **Get-AzStorageTable**
 - Cmdlet : 'Get-AzStorageTable'
 - "The output type 'Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageTable' is changing"
	Change description : AzureStorageTable.CloudTable.ServiceClient will have 2 properties removed in a future release: ConnectionPolicy, ConsistencyLevel.


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageTable





### **New-AzStorageTable**
 - Cmdlet : 'New-AzStorageTable'
 - "The output type 'Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageTable' is changing"
	Change description : AzureStorageTable.CloudTable.ServiceClient will have 2 properties removed in a future release: ConnectionPolicy, ConsistencyLevel.


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageTable




