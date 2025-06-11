---
external help file: Az.MongoDB-help.xml
Module Name: Az.MongoDB
online version: https://learn.microsoft.com/powershell/module/az.mongodb/get-azmongodborganization
schema: 2.0.0
---

# Get-AzMongoDBOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzMongoDBOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMongoDBOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzMongoDBOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMongoDBOrganization -InputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get all Organizations in a Resource Group
```powershell
Get-AzMongoDBOrganization -ResourceGroupName yashika-rg
```

```output
Location  Name           SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------  ----           -------------------   -------------------       ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
East US 2 testorg5       5/15/2025 7:17:14 PM  yashikajain@microsoft.com User                    5/16/2025 5:29:13 AM     yashikajain@microsoft.com            User                         yashika-rg
East US 2 test-mongodb-1 5/16/2025 6:03:20 AM  yashikajain@microsoft.com User                    5/16/2025 6:05:36 AM     b059abce-70fd-4c8f-a117-96d2192e90e1 Application                  yashika-rg
East US 2 test-mongodb-3 5/24/2025 12:14:55 PM yashikajain@microsoft.com User                    5/24/2025 12:16:00 PM    b059abce-70fd-4c8f-a117-96d2192e90e1 Application                  yashika-rg
```

This command will get all organization details for all resources in a resource group in a given subscription.

### Example 2: Get a specific Organization in a Resource Group
```powershell
Get-AzMongoDBOrganization -ResourceGroupName yashika-rg -Name testorg5
```

```output
Id                              : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/yashika-rg/providers/MongoDB.Atlas/organizations/t
                                  estorg5
IdentityPrincipalId             :
IdentityTenantId                :
IdentityType                    :
IdentityUserAssignedIdentity    : {
                                  }
Location                        : East US 2
MarketplaceSubscriptionId       : 7c9656d5-bf22-4f97-dba3-783e05b079f8
MarketplaceSubscriptionStatus   : Subscribed
Name                            : testorg5
OfferDetailOfferId              : mongodb_atlas_azure_native_prod
OfferDetailPlanId               : private_plan
OfferDetailPlanName             : Pay as You Go (Free) (Private)
OfferDetailPublisherId          : mongodb
OfferDetailTermId               : gmz7xq9ge3py
OfferDetailTermUnit             : P1M
PartnerPropertyOrganizationId   : 68263def1158e05a95034cd7
PartnerPropertyOrganizationName : testorg5
PartnerPropertyRedirectUrl      : https://account.mongodb.com/account/reset/password?email=yashikajain%40microsoft.com&orgId=68263def1158e05a95034cd7&s
                                  houldRedirect=true
ProvisioningState               : Succeeded
ResourceGroupName               : yashika-rg
SystemDataCreatedAt             : 5/15/2025 7:17:14 PM
SystemDataCreatedBy             : yashikajain@microsoft.com
SystemDataCreatedByType         : User
SystemDataLastModifiedAt        : 5/16/2025 5:29:13 AM
SystemDataLastModifiedBy        : yashikajain@microsoft.com
SystemDataLastModifiedByType    : User
Tag                             : {
                                    "testName": "TestValue3"
                                  }
Type                            : mongodb.atlas/organizations
UserCompanyName                 :
UserEmailAddress                : yashikajain@microsoft.com
UserFirstName                   :
UserLastName                    :
UserPhoneNumber                 :
UserUpn                         : yashikajain@microsoft.com
```

This command will get details of an organization for a resource name in a given subscription.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OrganizationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IOrganizationResource

## NOTES

## RELATED LINKS
