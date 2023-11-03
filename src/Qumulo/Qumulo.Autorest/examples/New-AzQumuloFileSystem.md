### Example 1: Create a minimum set file system resource
```powershell
$password = ConvertTo-SecureString "1qaz@WSX" -AsPlainText

New-AzQumuloFileSystem -Name qumulo01 -ResourceGroupName ps-joyer-test -DelegatedSubnetId /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/ps-joyer-test/providers/Microsoft.Network/virtualNetworks/eastus-ps-virtualnetwork/subnets/qumulo-vn -InitialCapacity 50 -Location eastus -MarketplaceOfferId "qumulo-saas-mpp" -MarketplacePlanId "qumulo-on-azure-v1%%gmz7xq9ge3py%%P1M" -MarketplacePublisherId qumulo1584033880660 -StorageSku Standard -UserEmail user@organization.com -AdminPassword $password
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   qumulo01           5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 7:42:17 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test
```

Create a file system resource. The password must contain at least 8 characters and have at least 1 letter, 1 number and 1 special character.

### Example 2: Create a file system resource with other settings
```powershell
$password = ConvertTo-SecureString "2wsx#EDC" -AsPlainText

New-AzQumuloFileSystem -Name qumulo02 -ResourceGroupName ps-joyer-test -AdminPassword $password -DelegatedSubnetId /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/ps-joyer-test/providers/Microsoft.Network/virtualNetworks/eastus-ps-virtualnetwork/subnets/qumulo-vn -InitialCapacity 50 -Location eastus -MarketplaceOfferId "qumulo-saas-mpp" -MarketplacePlanId "qumulo-on-azure-v1%%gmz7xq9ge3py%%P1M" -MarketplacePublisherId qumulo1584033880660 -StorageSku Standard -UserEmail user@organization.com -AvailabilityZone 1 -Tag @{"123"="abc"}
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------  
eastus   qumulo02           5/24/2023 9:31:50 AM user@organization.com User                    5/24/2023 9:41:10 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test
```

Create a file system resource with a maximum set