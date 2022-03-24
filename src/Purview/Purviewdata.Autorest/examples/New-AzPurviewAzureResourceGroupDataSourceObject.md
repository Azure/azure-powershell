### Example 1: Create Azure resource group data source object
```powershell
New-AzPurviewAzureResourceGroupDataSourceObject -Kind 'AzureResourceGroup' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ResourceGroup 'rg' -SubscriptionId '6810b9ce-82d3-4562-9658-xxxxxxxxxx'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzureResourceGroup
LastModifiedAt           :
Name                     :
ResourceGroup            : rg
Scan                     :
SubscriptionId           : 6810b9ce-82d3-4562-9658-xxxxxxxxxx
```

Create Azure resource group data source object

