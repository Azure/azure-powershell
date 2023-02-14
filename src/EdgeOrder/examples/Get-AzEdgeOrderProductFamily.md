### Example 1: Get details of specific productFamilies
```powershell
<<<<<<< HEAD
$familyDetails = Get-AzEdgeOrderProductFamily -SubscriptionId SubscriptionId -FilterableProperty  @{"azurestackedge"=@($filterableProperty)} -Expand "configurations"
$familyDetails.ProductLine.Product.Configuration.HierarchyInformation
```

```output
=======
PS C:\>  $familyDetails = Get-AzEdgeOrderProductFamily -SubscriptionId SubscriptionId -FilterableProperty  @{"azurestackedge"=@($filterableProperty)} -Expand "configurations"
PS C:\> $familyDetails.ProductLine.Product.Configuration.HierarchyInformation

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ConfigurationName ProductFamilyName ProductLineName ProductName
----------------- ----------------- --------------- -----------
edgep_high        azurestackedge    azurestackedge  azurestackedgegpu
edgepr_base       azurestackedge    azurestackedge  azurestackedgepror
edgemr_mini       azurestackedge    azurestackedge  azurestackedgeminir
```

This command get insights of filtered family. Make sure you run registerProvider on Microsoft.EdgeOrder before running this command.
You can run Get-AzEdgeOrderConfiguration to get details of each configuration
