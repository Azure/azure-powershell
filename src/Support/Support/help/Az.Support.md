---
Module Name: Az.Support
Module Guid: 22d73af7-38c2-4bf6-b56f-4dc9db05d97a
Download Help Link: https://learn.microsoft.com/powershell/module/az.support
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Support Module
## Description
The topics in this section document the Azure PowerShell cmdlets for creating and managing Azure support tickets in the Azure Resource Manager (ARM) framework. The cmdlets exist in the Microsoft.Azure.Commands.Support namespace

## Az.Support Cmdlets
### [Get-AzSupportChatTranscript](Get-AzSupportChatTranscript.md)
Returns chatTranscript details for a support ticket under a subscription.

### [Get-AzSupportChatTranscriptsNoSubscription](Get-AzSupportChatTranscriptsNoSubscription.md)
Returns chatTranscript details for a no subscription support ticket.

### [Get-AzSupportCommunication](Get-AzSupportCommunication.md)
Returns communication details for a support ticket.

### [Get-AzSupportCommunicationsNoSubscription](Get-AzSupportCommunicationsNoSubscription.md)
Returns communication details for a support ticket.

### [Get-AzSupportFile](Get-AzSupportFile.md)
Returns details of a specific file in a work space.

### [Get-AzSupportFilesNoSubscription](Get-AzSupportFilesNoSubscription.md)
Returns details of a specific file in a work space.

### [Get-AzSupportFileWorkspace](Get-AzSupportFileWorkspace.md)
Gets details for a specific file workspace in an Azure subscription.

### [Get-AzSupportFileWorkspacesNoSubscription](Get-AzSupportFileWorkspacesNoSubscription.md)
Gets details for a specific file workspace.

### [Get-AzSupportOperation](Get-AzSupportOperation.md)
Lists all the available Microsoft Support REST API operations.

### [Get-AzSupportProblemClassification](Get-AzSupportProblemClassification.md)
Get problem classification details for a specific Azure service.

### [Get-AzSupportService](Get-AzSupportService.md)
Gets a specific Azure service for support ticket creation.

### [Get-AzSupportTicket](Get-AzSupportTicket.md)
Get ticket details for an Azure subscription.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.
If no parameters are specified, then this command will retrieve all tickets created in the last week by default.

### [Get-AzSupportTicketsNoSubscription](Get-AzSupportTicketsNoSubscription.md)
Gets details for a specific support ticket.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.
If no parameters are specified, then this command will retrieve all tickets created in the last week by default.

### [New-AzSupportCommunication](New-AzSupportCommunication.md)
Adds a new customer communication to an Azure support ticket.

### [New-AzSupportCommunicationsNoSubscription](New-AzSupportCommunicationsNoSubscription.md)
Adds a new customer communication to an Azure support ticket.

### [New-AzSupportFileAndUpload](New-AzSupportFileAndUpload.md)
Creates and uploads a new file under a workspace for the specified subscription.

### [New-AzSupportFileAndUploadNoSubscription](New-AzSupportFileAndUploadNoSubscription.md)
Creates and uploads a new file under a workspace for the specified subscription.

### [New-AzSupportFileWorkspace](New-AzSupportFileWorkspace.md)
Create a new file workspace for the specified subscription.

### [New-AzSupportFileWorkspacesNoSubscription](New-AzSupportFileWorkspacesNoSubscription.md)
Create a new file workspace.

### [New-AzSupportTicket](New-AzSupportTicket.md)
Create a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket. Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation. Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file. Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources. **Creating a support ticket for on-behalf-of**: Include _x-ms-authorization-auxiliary_ header to provide an auxiliary token as per [documentation](https://docs.microsoft.com/azure/azure-resource-manager/management/authenticate-multi-tenant).
The primary token will be from the tenant for whom a support ticket is being raised against the subscription, i.e.
Cloud solution provider (CSP) customer tenant.
The auxiliary token will be from the Cloud solution provider (CSP) partner tenant.

### [New-AzSupportTicketsNoSubscription](New-AzSupportTicketsNoSubscription.md)
Create a new support ticket for Billing, and Subscription Management issues.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket. Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation. Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file. Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources. 

### [Test-AzSupportCommunicationNameAvailability](Test-AzSupportCommunicationNameAvailability.md)
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.

### [Test-AzSupportCommunicationsNoSubscriptionNameAvailability](Test-AzSupportCommunicationsNoSubscriptionNameAvailability.md)
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.

### [Test-AzSupportTicketNameAvailability](Test-AzSupportTicketNameAvailability.md)
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.

### [Test-AzSupportTicketsNoSubscriptionNameAvailability](Test-AzSupportTicketsNoSubscriptionNameAvailability.md)
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.

### [Update-AzSupportTicket](Update-AzSupportTicket.md)
This API allows you to update the severity level, ticket status, advanced diagnostic consent and your contact information in the support ticket. Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.

### [Update-AzSupportTicketsNoSubscription](Update-AzSupportTicketsNoSubscription.md)
This API allows you to update the severity level, ticket status, and your contact information in the support ticket. Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.
