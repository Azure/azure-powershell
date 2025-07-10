### Example 1: Create a new MongoDB organization
```powershell
New-AzMongoDbOrganization -Name "MongoDBCLI11July2025" -ResourceGroupName "cli-test-rg" -Location "East US 2" -MarketplaceSubscriptionId "911e07bd-f921-4b16-a206-6af36bfb7fbc" -OfferDetailOfferId "mongodb_atlas_azure_native_prod" -OfferDetailPlanId "private_plan" -OfferDetailPlanName "Pay as You Go (Free) (Private)" -OfferDetailPublisherId "mongodb" -OfferDetailTermId "gmz7xq9ge3py" -OfferDetailTermUnit "P1M" -UserEmailAddress "ajaykumar@microsoft.com" -UserFirstName "Ajay" -UserLastName "Kumar" -UserUpn "ajaykumar@microsoft.com"
```

```output
Name                 : MongoDBCLI11July2025
ResourceGroupName    : cli-test-rg
Location             : East US 2
Type                 : Microsoft.MongoDB/organizations
```

Creates a new MongoDB organization with the specified configuration and user details.

