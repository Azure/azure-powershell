---
Module Name: Az.ManagedServices
Module Guid: fe0ae00c-c482-4e5f-a837-fbc342fdc7e0
Download Help Link: https://docs.microsoft.com/powershell/module/az.managedservices
Help Version: 0.0.2
Locale: en-US
---

# Az.ManagedServices Module
## Description
This feature is used by customers of Managed Service Providers (MSPs). Customers give an MSP the ability to manage their subscription or resource group. In addition to granting access, the customer can also remove access or view existing access. MSPs are able to view the list of customers who have granted them access to subscriptions. There are two objects involved in this process: A registration definition which identifies the MSP and the role definitions granted to the MSP users. The MSP can optionally define this object using a Managed Services marketplace offering Access assignments which associate a subscription with the definition.

## Az.ManagedServices Cmdlets
### [Get-AzManagedServicesAssignment](Get-AzManagedServicesAssignment.md)
Gets a specific registration assignment or a list of the registration assignments.

### [Get-AzManagedServicesDefinition](Get-AzManagedServicesDefinition.md)
Gets a specific registration definition or a list of the registration definitions.

### [New-AzManagedServicesAssignment](New-AzManagedServicesAssignment.md)
Creates or updates a registration assignment.

### [New-AzManagedServicesDefinition](New-AzManagedServicesDefinition.md)
Creates or updates a registration definition.

### [Remove-AzManagedServicesAssignment](Remove-AzManagedServicesAssignment.md)
Removes a registration assignment.

### [Remove-AzManagedServicesDefinition](Remove-AzManagedServicesDefinition.md)
Removes a registration definition.
