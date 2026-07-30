---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.pinecone/get-azpineconeorganization
Module Name: Az.Pinecone
ms.date: 07-30-2026
PlatyPS schema version: 2024-05-01
---

# Get-AzPineconeOrganization

## SYNOPSIS

Get a OrganizationResource

## SYNTAX

### List (Default)

```
Get-AzPineconeOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get

```
Get-AzPineconeOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity

```
Get-AzPineconeOrganization -InputObject <IPineconeIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1

```
Get-AzPineconeOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## ALIASES

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
DefaultValue: None
SupportsWildcards: false
Aliases:
- AzureRMContext
- AzureCredential
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -InputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Pinecone.Models.IPineconeIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: GetViaIdentity
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

Name of the Organization resource

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- Organizationname
ParameterSets:
- Name: Get
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -SubscriptionId

The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: List
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Pinecone.Models.IPineconeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Pinecone.Models.IOrganizationResource

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

