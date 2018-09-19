<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled "Current Breaking Changes", and should adhere to the following format:

    ## Current Breaking Changes

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below: 

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
-->

## Current Breaking Changes

## Release 0.5.0 - November 2017

The following cmdlets were affected this release:
	
**New-AzureRmEventHubNamespaceAuthorizationRule**
- The 'New-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'New-AzureRmEventHubAuthorizationRule' cmdlet
	
**Get-AzureRmEventHubNamespaceAuthorizationRule**
- The 'Get-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Get-AzureRmEventHubAuthorizationRule' cmdlet
	
**Set-AzureRmEventHubNamespaceAuthorizationRule**
- The 'Set-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Set-AzureRmEventHubAuthorizationRule' cmdlet
	
**Remove-AzureRmEventHubNamespaceAuthorizationRule**
- The 'Remove-AzureRmEventHubNamespaceAuthorizationRule' cmdlet has been removed. Please use the 'Remove-AzureRmEventHubAuthorizationRule' cmdlet
	
**New-AzureRmEventHubNamespaceKey**
- The 'New-AzureRmEventHubNamespaceKey' cmdlet has been removed. Please use the 'New-AzureRmEventHubKey' cmdlet
	
**Get-AzureRmEventHubNamespaceKey**
- The 'Get-AzureRmEventHubNamespaceKey' cmdlet has been removed. Please use the 'Get-AzureRmEventHubKey' cmdlet
	
**New-AzureRmEventHubNamespace**
- The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

```powershell
# Old
# The $namespace has Status and Enabled property  
$namespace = New-AzureRmEventHubNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
$namespace = Get-AzureRmEventHubNamespace <parameters>
```
	
**Get-AzureRmEventHubNamespace**
- The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

```powershell
# Old
# The $namespace has Status and Enabled property 
$namespace = Get-AzureRmEventHubNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
$namespace = Get-AzureRmEventHubNamespace <parameters>
```
	
**Set-AzureRmEventHubNamespace**
- The property 'Status' and 'Enabled' from the NamespceAttributes will be removed. 

```powershell
# Old
# The $namespace has Status and Enabled property 
$namespace = Set-AzureRmEventHubNamespace <parameters>
$namespace.Status
$namespace.Enabled

# New
# The call remains the same, but the returned values NameSpace object will not have the Status and Enabled property    
$namespace = Set-AzureRmEventHubNamespace <parameters>
```	
  
**New-AzureRmEventHubConsumerGroup**
- The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

```powershell
# Old
# The $consumergroup has EventHubPath property 
$consumergroup = New-AzureRmEventHubConsumerGroup <parameters>
$consumergroup.EventHubPath

# New
# The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
$consumergroup = New-AzureRmEventHubConsumerGroup <parameters>
```
	
**Set-AzureRmEventHubConsumerGroup**
- The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

```powershell
# Old
# The $consumergroup has EventHubPath property 
$consumergroup = Set-AzureRmEventHubConsumerGroup <parameters>
$consumergroup.EventHubPath

# New
# The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
$consumergroup = Set-AzureRmEventHubConsumerGroup <parameters>
```
	
**Get-AzureRmEventHubConsumerGroup**
- The property 'EventHubPath' from the ConsumerGroupAttributes will be removed.

```powershell
# Old
# The $consumergroup has EventHubPath property 
$consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
$consumergroup.EventHubPath

# New
# The call remains the same, but the returned values ConsumerGroup object will not have the EventHubPath property    
$consumergroup = Get-AzureRmEventHubConsumerGroup <parameters>
```	