---
Module Name: Az.MarketplaceOrdering
Module Guid: 6e0e216b-1dff-4992-b943-b3a4f14679ab
Download Help Link: https://docs.microsoft.com/powershell/module/az.marketplaceordering
Help Version: 0.1.0.0
Locale: en-US
---

# Az.MarketplaceOrdering Module
## Description
The topics in this section document the Azure PowerShell cmdlets for Azure MarketplaceOrdering in the Azure Resource Manager (ARM) framework. The cmdlets exist in the Microsoft.Azure.Commands.MarketplaceOrdering namespace. These cmdlets allow azure users to accept the legal terms for a marketplace offering further allowing programmatic deployment for these solutions. Users may also reject set of legal terms already accepted.

## Az.MarketplaceOrdering Cmdlets
### [Get-AzMarketplaceTerms](Get-AzMarketplaceTerms.md)
Get the agreement terms for a given publisher id(Publisher), offer id(Product) and plan id(Name). The terms object which is returned by this command should be passed to Set-AzMarketplaceTerms to accept the legal terms.

### [Set-AzMarketplaceTerms](Set-AzMarketplaceTerms.md)
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name). Please use Get-AzMarketplaceTerms to get the agreement terms.

