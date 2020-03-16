## Breaking changes in module Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll

 The following cmdlets were affected this release:




### **Get-AzEventHubNamespace**
 - Cmdlet : 'Get-AzEventHubNamespace'
 - "The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing"
 - The following properties in the output type are being deprecated :
 'ResourceGroup'
- The following properties are being added to the output type :
 'ResourceGroupName' 'Tags'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'ResourceGroup'
BreakingChangesAttributesCmdLetOutputPropertiesAdded:  'ResourceGroupName' 'Tags'





### **New-AzEventHubNamespace**
 - Cmdlet : 'New-AzEventHubNamespace'
 - "The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing"
 - The following properties in the output type are being deprecated :
 'ResourceGroup'
- The following properties are being added to the output type :
 'ResourceGroupName' 'Tags'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'ResourceGroup'
BreakingChangesAttributesCmdLetOutputPropertiesAdded:  'ResourceGroupName' 'Tags'





### **Set-AzEventHubNamespace**
 - Cmdlet : 'Set-AzEventHubNamespace'
 - "The output type 'Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes' is changing"
 - The following properties in the output type are being deprecated :
 'ResourceGroup'
- The following properties are being added to the output type :
 'ResourceGroupName' 'Tags'


BreakingChangesAttributesCmdLetOutputChange2: Microsoft.Azure.Commands.EventHub.Models.PSNamespaceAttributes
BreakingChangesAttributesCmdLetOutputPropertiesRemoved:  'ResourceGroup'
BreakingChangesAttributesCmdLetOutputPropertiesAdded:  'ResourceGroupName' 'Tags'


The following parameters were affected this release:
#### **State**
 - Cmdlet : 'Set-AzEventHubNamespace'
 - The parameter : 'State' is changing.
	Change description : 'State' Parameter is being deprecated without being replaced

