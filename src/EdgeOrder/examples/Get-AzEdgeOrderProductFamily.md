### Example 1: Get details of specific productFamilies
```powershell
PS C:\>  $familyDetails = Get-AzEdgeOrderProductFamily -SubscriptionId SubscriptionId -FilterableProperty  @{"azurestackedge"=@($filterableProperty)} -Expand "configurations"
PS C:\> $familyDetails.ProductLine.Product.Configuration.HierarchyInformation

ConfigurationName ProductFamilyName ProductLineName ProductName
----------------- ----------------- --------------- -----------
edgep_high        azurestackedge    azurestackedge  azurestackedgegpu
edgepr_base       azurestackedge    azurestackedge  azurestackedgepror
edgemr_mini       azurestackedge    azurestackedge  azurestackedgeminir
```

This command get insights of filtered family. Make sure you run registerProvider on Microsoft.EdgeOrder before running this command.
You can run Get-AzEdgeOrderConfiguration to get details of each configuration
