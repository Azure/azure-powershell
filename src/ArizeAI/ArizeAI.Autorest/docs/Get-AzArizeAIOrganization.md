---
external help file:
Module Name: Az.ArizeAI
online version: https://learn.microsoft.com/powershell/module/az.arizeai/get-azarizeaiorganization
schema: 2.0.0
---

# Get-AzArizeAIOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzArizeAIOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzArizeAIOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArizeAIOrganization -InputObject <IArizeAiIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzArizeAIOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get all Organizations in a Resource Group
```powershell
Get-AzArizeAIOrganization -ResourceGroupName QM_clitest_qumulo2_eastus
```

```output

Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/QM_clitest_qum
                                      ulo2_eastus/providers/arizeai.observabilityeval/organizations/test-instance-cli-1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           :
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test-instance-cli-1
OfferDetailOfferId                  : arize-liftr-0
OfferDetailPlanId                   : liftr-test-0
OfferDetailPlanName                 : Liftr Test 0
OfferDetailPublisherId              : arizeai1657829589668
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyDescription          :
ProvisioningState                   : Accepted
ResourceGroupName                   : QM_clitest_qumulo2_eastus
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 3/2/2025 1:48:39 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 3/2/2025 1:48:39 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : arizeai.observabilityeval/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will get all organization details in a given Resource group.

### Example 2: Get a specific Organization in a Resource Group
```powershell
Get-AzArizeAIOrganization -ResourceGroupName QM_clitest_qumulo2_eastus -Name test-instance-cli-1 
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/QM_clitest_qum
                                      ulo2_eastus/providers/arizeai.observabilityeval/organizations/test-instance-cli-1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           : a45bd40f-e8c5-483d-c972-a40fe50c03ba
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test-instance-cli-1
OfferDetailOfferId                  : arize-liftr-0
OfferDetailPlanId                   : liftr-test-0
OfferDetailPlanName                 : Liftr Test 0
OfferDetailPublisherId              : arizeai1657829589668
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyDescription          :
ProvisioningState                   : Accepted
ResourceGroupName                   : QM_clitest_qumulo2_eastus
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 3/2/2025 1:48:39 PM
SystemDataCreatedBy                 : aggarwalsw@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 3/2/2025 1:48:39 PM
SystemDataLastModifiedBy            : aggarwalsw@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : arizeai.observabilityeval/organizations
UserEmailAddress                    : aggarwalsw@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : aggarwalsw@microsoft.com
```

This command will get all organization details for a resource name in a given subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ArizeAI.Models.IArizeAiIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.ArizeAI.Models.IArizeAiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArizeAI.Models.IOrganizationResource

## NOTES

## RELATED LINKS

