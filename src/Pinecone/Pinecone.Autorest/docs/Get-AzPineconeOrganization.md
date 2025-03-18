---
external help file:
Module Name: Az.Pinecone
online version: https://learn.microsoft.com/powershell/module/az.pinecone/get-azpineconeorganization
schema: 2.0.0
---

# Get-AzPineconeOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzPineconeOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPineconeOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPineconeOrganization -InputObject <IPineconeIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPineconeOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: List all Pinecone organizations
```powershell
Get-AzPineconeOrganization -ResourceGroupName clitest
```

```output
| Location | Name            | SystemDataCreatedAt  | SystemDataCreatedBy      | SystemDataCreatedByType | SystemDataLastModifiedAt | SystemDataLastModifiedBy | SystemDataLastModifiedByType | ResourceGroupName |
|----------|-----------------|----------------------|--------------------------|-------------------------|--------------------------|--------------------------|------------------------------|-------------------|
| eastus   |  test-cli-instance-1    | 2/25/2025 8:19:04 AM | aggarwalsw@microsoft.com | User                    | 2/25/2025 8:19:04 AM     | aggarwalsw@microsoft.com | User                         | clitest           |
| eastus   |  test-cli-instance-1 | 2/25/2025 8:21:21 AM | aggarwalsw@microsoft.com | User                    | 2/25/2025 8:21:21 AM     | aggarwalsw@microsoft.com | User                         | clitest           |
```

This command will get all organization details for a subscription id

### Example 2: Get Pineone organization details
```powershell
Get-AzPineconeOrganization -Name  test-cli-instance-1 -ResourceGroupName clitest
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/clitest/providers/pinecone.vectordb/organizations/test-cli-instance-1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           : fc35d936-3b89-41f8-8110-a24b56826c37
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test-cli-instance-1
OfferDetailOfferId                  : pineconeliftr
OfferDetailPlanId                   : pinecone_liftr_preview_paygo
OfferDetailPlanName                 : Pinecone - Pay As You Go (Preview)
OfferDetailPublisherId              : pineconesystemsinc1688761585469
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyDisplayName          : Test-CLI-Instance-1
ProvisioningState                   : Accepted
ResourceGroupName                   : clitest
SingleSignOnPropertyAadDomain       : {onmicrosoft}
SingleSignOnPropertyEnterpriseAppId : 0b9873df-1629-4036-9360-5f2f65c0a0d3
SingleSignOnPropertyState           : Initial
SingleSignOnPropertyType            : Saml
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 2/27/2025 8:08:34 AM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 2/27/2025 8:08:34 AM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "Test": "TestValue"
                                      }
Type                                : pinecone.vectordb/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will get all organization details for a resource name in a given subscription id

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Pinecone.Models.IPineconeIdentity
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
Aliases: Organizationname

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Pinecone.Models.IPineconeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Pinecone.Models.IOrganizationResource

## NOTES

## RELATED LINKS

