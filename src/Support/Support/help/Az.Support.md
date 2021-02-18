---
Module Name: Az.Support
Module Guid: 22d73af7-38c2-4bf6-b56f-4dc9db05d97a
Download Help Link: https://docs.microsoft.com/powershell/module/az.support
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Support Module
## Description
The topics in this section document the Azure PowerShell cmdlets for creating and managing Azure support tickets in the Azure Resource Manager (ARM) framework. The cmdlets exist in the Microsoft.Azure.Commands.Support namespace

## Az.Support Cmdlets
### [Get-AzSupportService](Get-AzSupportService.md)
Gets the current list of Azure services for which support is available. Each Azure service has its own set of categories called problem classification. Get the current list of problem classification for a service using Get-AzSupportProblemClassification. You can use the service and problem classification GUID to create a new support ticket using New-AzSupportTicket.

### [Get-AzSupportProblemClassification](Get-AzSupportProblemClassification.md)
Gets the current list of problem classification for an Azure service. You can use the service and problem classification GUID to create a new support ticket using New-AzSupportTicket. 

### [New-AzSupportContactProfileObject](New-AzSupportContactProfileObject.md)
Helper cmdlet to create a support contact profile object. You can use this object for New-AzSupportTicket cmdlet.

### [New-AzSupportTicket](New-AzSupportTicket.md)
Creates a new Azure support ticket. This operation is modeled on the behavior of the Azure [New support request page](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/overview).

### [Get-AzSupportTicket](Get-AzSupportTicket.md)
Gets the list of support tickets. You can get full support ticket details by ticket name or filter the support tickets by *Status* or *CreatedDate*.

### [Update-AzSupportTicket](Update-AzSupportTicket.md)
Update a support ticket's severity, status or customer contact details.

### [Get-AzSupportTicketCommunication](Get-AzSupportTicketCommunication.md)
Gets communications for a support ticket. You can also filter support ticket communications by *CreatedDate* or *CommunicationType*. 

### [New-AzSupportTicketCommunication](New-AzSupportTicketCommunication.md)
Adds a new customer communication to an Azure support ticket. 



