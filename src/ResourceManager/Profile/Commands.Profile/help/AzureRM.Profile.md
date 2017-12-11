---
Module Name: AzureRM.Profile
Module Guid: 342714fc-4009-4863-8afb-a9067e3db04b
Download Help Link: {{Please enter FwLink manually}}
Help Version: {{Please enter version of help manually (X.X.X.X) format}}
Locale: en-US
---

# AzureRM.Profile Module
## Description
Manages credentials and common configuration for all Azure modules.

## AzureRM.Profile Cmdlets
### [Connect-AzureRmAccount](Connect-AzureRmAccount.md)
Connects to Azure with an authenticated account for use with Azure Resource Manager cmdlet requests.

### [Add-AzureRmEnvironment](Add-AzureRmEnvironment.md)
Adds endpoints and metadata for an instance of Azure Resource Manager.

### [Clear-AzureRmContext](Clear-AzureRmContext.md)
Remove all Azure credentials, account, and subscription information.

### [Disable-AzureRmContextAutosave](Disable-AzureRmContextAutosave.md)
Turn off autosaving Azure credentials.  Your login information will be forgotten the next time you open a PowerShell window

### [Disable-AzureRmDataCollection](Disable-AzureRmDataCollection.md)
Opts out of collecting data to improve the AzurePowerShell cmdlets. 
Data is not collected unless you explicitly opt in.

### [Enable-AzureRmContextAutosave](Enable-AzureRmContextAutosave.md)
Allow the azure credential, account and subscription information to be saved and automatically loaded when you open a PowerShell window. 

### [Enable-AzureRmDataCollection](Enable-AzureRmDataCollection.md)
Enables Azure PowerShell to collect data to improve the user experience with AzurePowerShell cmdlets.
Executing this cmdlet opts in to data collection for the current user on the current machine.
No data is collected unless you explicitly opt in.

### [Get-AzureRmContext](Get-AzureRmContext.md)
Gets the metadata used to authenticate Azure Resource Manager requests.

### [Get-AzureRmContextAutosaveSetting](Get-AzureRmContextAutosaveSetting.md)
Display metadata about the context autosave feature, including whterh the context is 
automaticallys aved, and where saved context and credential information cna be found.

### [Get-AzureRmEnvironment](Get-AzureRmEnvironment.md)
Get endpoints and metadata for an instance of Azure services.

### [Get-AzureRmSubscription](Get-AzureRmSubscription.md)
Get subscriptions that the current account can access.

### [Get-AzureRmTenant](Get-AzureRmTenant.md)
Gets tenants that are authorized for the current user.

### [Import-AzureRmContext](Import-AzureRmContext.md)
Loads Azure authentication information from a file.

### [Disconnect-AzureRmAccount](Disconnect-AzureRmAccount.md)
Disconnects from a connected Azure account and removes all credentials and contexts associated with that account.

### [Remove-AzureRmContext](Remove-AzureRmContext.md)
Remove a context from the set of available contexts

### [Remove-AzureRmEnvironment](Remove-AzureRmEnvironment.md)
Removes endpoints and metadata for connecting to a given Azure instance.

### [Rename-AzureRmContext](Rename-AzureRmContext.md)
Rename an Azure context.  By default contexts are named by user account and subscription.

### [Resolve-AzureRmError](Resolve-AzureRmError.md)
Display detailed information about PowerShell errors, with extended details for Azure PowerShell errors.

### [Save-AzureRmContext](Save-AzureRmContext.md)
Saves the current authentication information for use in other PowerShell sessions.

### [Select-AzureRmContext](Select-AzureRmContext.md)
Select a subscription and account to target in Azure PowerShell cmdlets

### [Send-Feedback](Send-Feedback.md)
Sends feedback to the Azure PowerShell team via a set of guided prompts.

### [Set-AzureRmContext](Set-AzureRmContext.md)
Sets the tenant, subscription, and environment for cmdlets to use in the current session.

### [Set-AzureRmEnvironment](Set-AzureRmEnvironment.md)
Sets properties for an Azure environment.

