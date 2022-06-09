---
Module Name: Az.Support
Module Guid: 53cc7518-72ef-491f-95a4-12493f5d50ee
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.support
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Support Module
## Description
Microsoft Azure PowerShell: Support cmdlets

## Az.Support Cmdlets
### [Get-AzSupportCommunication](Get-AzSupportCommunication.md)
Returns communication details for a support ticket.

### [Get-AzSupportProblemClassification](Get-AzSupportProblemClassification.md)
Get problem classification details for a specific Azure service.

### [Get-AzSupportService](Get-AzSupportService.md)
Gets a specific Azure service for support ticket creation.

### [Get-AzSupportTicket](Get-AzSupportTicket.md)
Get ticket details for an Azure subscription.
Support ticket data is available for 18 months after ticket creation.
If a ticket was created more than 18 months ago, a request for data might cause an error.

### [New-AzSupportCommunication](New-AzSupportCommunication.md)
Adds a new customer communication to an Azure support ticket.

### [New-AzSupportTicket](New-AzSupportTicket.md)
Creates a new support ticket for Subscription and Service limits (Quota), Technical, Billing, and Subscription Management issues for the specified subscription.
Learn the [prerequisites](https://aka.ms/supportAPI) required to create a support ticket.\<br/\>\<br/\>Always call the Services and ProblemClassifications API to get the most recent set of services and problem categories required for support ticket creation.\<br/\>\<br/\>Adding attachments is not currently supported via the API.
To add a file to an existing support ticket, visit the [Manage support ticket](https://portal.azure.com/#blade/Microsoft_Azure_Support/HelpAndSupportBlade/managesupportrequest) page in the Azure portal, select the support ticket, and use the file upload control to add a new file.\<br/\>\<br/\>Providing consent to share diagnostic information with Azure support is currently not supported via the API.
The Azure support engineer working on your ticket will reach out to you for consent if your issue requires gathering diagnostic information from your Azure resources.\<br/\>\<br/\>**Creating a support ticket for on-behalf-of**: Include _x-ms-authorization-auxiliary_ header to provide an auxiliary token as per [documentation](https://docs.microsoft.com/azure/azure-resource-manager/management/authenticate-multi-tenant).
The primary token will be from the tenant for whom a support ticket is being raised against the subscription, i.e.
Cloud solution provider (CSP) customer tenant.
The auxiliary token will be from the Cloud solution provider (CSP) partner tenant.

### [Test-AzSupportCommunicationNameAvailability](Test-AzSupportCommunicationNameAvailability.md)
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for adding a new communication to the support ticket.

### [Test-AzSupportTicketNameAvailability](Test-AzSupportTicketNameAvailability.md)
Check the availability of a resource name.
This API should be used to check the uniqueness of the name for support ticket creation for the selected subscription.

### [Update-AzSupportTicket](Update-AzSupportTicket.md)
This API allows you to update the severity level, ticket status, and your contact information in the support ticket.\<br/\>\<br/\>Note: The severity levels cannot be changed if a support ticket is actively being worked upon by an Azure support engineer.
In such a case, contact your support engineer to request severity update by adding a new communication using the Communications API.\<br/\>\<br/\>Changing the ticket status to _closed_ is allowed only on an unassigned case.
When an engineer is actively working on the ticket, send your ticket closure request by sending a note to your engineer.

