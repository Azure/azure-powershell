---
Module Name: AzureRM.MarketplaceOrdering
Module Guid: 6e0e216b-1dff-4992-b943-b3a4f14679ab
Download Help Link: 
Help Version: 0.1.0
Locale: en-US
---

# AzureRM.MarketplaceOrdering Module
## Description
The topics in this section document the Azure PowerShell cmdlets for Azure MarketplaceOrdering in the Azure Resource Manager (ARM) framework. The cmdlets exist in the Microsoft.Azure.Commands.MarketplaceOrdering namespace. These cmdlets allow azure users to accept the legal terms for a marketplace offering further allowing programmatic deployment for these solutions. Users may also reject set of legal terms already accepted.

## AzureRM.MarketplaceOrdering Cmdlets
### [Get-AzureRmMarketplaceTerms](Get-AzureRmMarketplaceTerms.md)
Get the agreement terms for a given publisher id(Publisher), offer id(Product) and plan id(Name). The terms object which is returned by this command should be passed to Set-AzureRmMarketplaceTerms to accept the legal terms.

### [Set-AzureRmMarketplaceTerms](Set-AzureRmMarketplaceTerms.md)
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name). Please use Get-AzureRmMarketplaceTerms to get the agreement terms.

