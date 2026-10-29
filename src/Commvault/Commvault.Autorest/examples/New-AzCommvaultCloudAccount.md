### Example 1: Create a cloud account
```powershell
New-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso -Location eastus -EnableSystemAssignedIdentity -MarketplaceSubscriptionId '00000000-0000-0000-0000-000000000000' -OfferDetailPublisherId 'contoso-publisher' -OfferDetailOfferId 'contoso-offer' -OfferDetailPlanId 'contoso-plan' -OfferDetailPlanName 'Contoso Plan' -OfferDetailTermUnit 'P1M' -OfferDetailTermId 'contoso-term' -UserFirstName 'John' -UserLastName 'Doe' -UserEmailAddress 'john.doe@contoso.com' -UserUpn 'john.doe@contoso.com'
```

Creates a cloud account with a system-assigned managed identity.

### Example 2: Create a cloud account and assign roles to Microsoft Entra groups
```powershell
$roleAssignments = @(
    @{ RoleName = 'BackupAdmin'; Entity = @(@{ Id = 'aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee'; DisplayName = 'Tenant Admins'; EntityType = 'Group' }) },
    @{ RoleName = 'BackupOperator'; Entity = @(@{ Id = '44444444-5555-6666-7777-888888888888'; DisplayName = 'Ops Team'; EntityType = 'Group' }) }
)
New-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso -Location eastus -EnableSystemAssignedIdentity -MarketplaceSubscriptionId '00000000-0000-0000-0000-000000000000' -OfferDetailPublisherId 'contoso-publisher' -OfferDetailOfferId 'contoso-offer' -OfferDetailPlanId 'contoso-plan' -OfferDetailPlanName 'Contoso Plan' -OfferDetailTermUnit 'P1M' -OfferDetailTermId 'contoso-term' -UserFirstName 'John' -UserLastName 'Doe' -UserEmailAddress 'john.doe@contoso.com' -UserUpn 'john.doe@contoso.com' -RoleAssignmentsOnCcaCreate $roleAssignments
```

Creates a cloud account and assigns the Commvault roles to the specified Microsoft Entra groups.

### Example 3: Create a cloud account by using a JSON file
```powershell
New-AzCommvaultCloudAccount -ResourceGroupName rg-commvault -Name cca-contoso -JsonFilePath '.\cloud-account.json'
```

Creates a cloud account from the request body in the JSON file.

