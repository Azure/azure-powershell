### Example 1: Get all the available Skus 
```powershell
Get-AzElasticSanSkuList
```

```output
Location      Name           ResourceType Tier   
--------      ----           ------------ ----   
{eastus}      Premium_LRS    elasticSans  Premium
{eastus2}     Premium_LRS    elasticSans  Premium
```

This command gets all the available Skus.
