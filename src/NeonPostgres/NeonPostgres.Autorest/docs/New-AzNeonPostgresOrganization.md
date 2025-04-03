---
external help file:
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/new-azneonpostgresorganization
schema: 2.0.0
---

# New-AzNeonPostgresOrganization

## SYNOPSIS
create a OrganizationResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzNeonPostgresOrganization -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-CompanyDetailBusinessPhone <String>] [-CompanyDetailCompanyName <String>]
 [-CompanyDetailCountry <String>] [-CompanyDetailDomain <String>] [-CompanyDetailNumberOfEmployee <Int64>]
 [-CompanyDetailOfficeAddress <String>] [-MarketplaceDetailSubscriptionId <String>]
 [-MarketplaceDetailSubscriptionStatus <String>] [-OfferDetailOfferId <String>] [-OfferDetailPlanId <String>]
 [-OfferDetailPlanName <String>] [-OfferDetailPublisherId <String>] [-OfferDetailTermId <String>]
 [-OfferDetailTermUnit <String>] [-PartnerOrganizationPropertyOrganizationId <String>]
 [-PartnerOrganizationPropertyOrganizationName <String>] [-SingleSignOnPropertyAadDomain <String[]>]
 [-SingleSignOnPropertyEnterpriseAppId <String>] [-SingleSignOnPropertySingleSignOnState <String>]
 [-SingleSignOnPropertySingleSignOnUrl <String>] [-Tag <Hashtable>] [-UserDetailEmailAddress <String>]
 [-UserDetailFirstName <String>] [-UserDetailLastName <String>] [-UserDetailPhoneNumber <String>]
 [-UserDetailUpn <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNeonPostgresOrganization -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNeonPostgresOrganization -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
create a OrganizationResource

## EXAMPLES

### Example 1: Create Neon Organization
```powershell
New-AzNeonPostgresOrganization -Name "almasTestNeonPS6" -ResourceGroupName "NeonDemoRG" -Location "centraluseuap" -SubscriptionId "5d9a6cc3-4e60-4b41-be79-d28f0a01074e" -CompanyDetailBusinessPhone "+1234567890" -CompanyDetailCompanyName "DemoCompany" -CompanyDetailCountry "USA" -CompanyDetailDomain "demo.com" -CompanyDetailNumberOfEmployee 500 -CompanyDetailOfficeAddress "1234 Azure Ave" -MarketplaceDetailSubscriptionId "yxmkfivp" -MarketplaceDetailSubscriptionStatus "PendingFulfillmentStart" -OfferDetailOfferId "neon_test" -OfferDetailPlanId "neon_test_1" -OfferDetailPlanName "Neon Serverless Postgres - Free (Test_Liftr)" -OfferDetailPublisherId "neon1722366567200" -OfferDetailTermId "gmz7xq9ge3py" -OfferDetailTermUnit "P1M" -PartnerOrganizationPropertyOrganizationId "org12345" -PartnerOrganizationPropertyOrganizationName "PartnerOrg6" -SingleSignOnPropertyAadDomain @("partnerorg.com") -SingleSignOnPropertyEnterpriseAppId "app12345" -SingleSignOnPropertySingleSignOnState "Enable" -SingleSignOnPropertySingleSignOnUrl "https://sso.partnerorg.com" -UserDetailEmailAddress "khanalmas@microsoft.com" -UserDetailFirstName "Almas" -UserDetailLastName "Khan" -UserDetailPhoneNumber "+1234567890" -UserDetailUpn "khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com"
```

```output
CompanyDetailBusinessPhone                  : +1234567890
CompanyDetailCompanyName                    : DemoCompany
CompanyDetailCountry                        : USA
CompanyDetailDomain                         : demo.com
CompanyDetailNumberOfEmployee               : 500
CompanyDetailOfficeAddress                  : 1234 Azure Ave
Id                                          : /subscriptions/5d9a6cc3-4e60-4b41-be79-d28f0a01074e/resourceGroups/NeonDe
                                              moRG/providers/Neon.Postgres/organizations/almasTestNeonPS6
Location                                    : centraluseuap
MarketplaceDetailSubscriptionId             : cefab913-6de7-4a3b-d369-eae74ea379dc
MarketplaceDetailSubscriptionStatus         : Subscribed
Name                                        : almasTestNeonPS6
OfferDetailOfferId                          : neon_test
OfferDetailPlanId                           : neon_test_1
OfferDetailPlanName                         : Neon Serverless Postgres - Free (Test_Liftr)
OfferDetailPublisherId                      : neon1722366567200
OfferDetailTermId                           : gmz7xq9ge3py
OfferDetailTermUnit                         : P1M
PartnerOrganizationPropertyOrganizationId   : org-sweet-wind-32755039
PartnerOrganizationPropertyOrganizationName : PartnerOrg6
ProvisioningState                           : Succeeded
ResourceGroupName                           : NeonDemoRG
SingleSignOnPropertyAadDomain               : {partnerorg.com}
SingleSignOnPropertyEnterpriseAppId         : app12345
SingleSignOnPropertySingleSignOnState       : Enable
SingleSignOnPropertySingleSignOnUrl         : https://console.neon.tech/azure/sso/org-sweet-wind-32755039
SystemDataCreatedAt                         : 06-Nov-24 4:37:35 AM
SystemDataCreatedBy                         : khanalmas@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 06-Nov-24 4:38:37 AM
SystemDataLastModifiedBy                    : b41fa140-8cb4-43b1-a086-717c2f41909e
SystemDataLastModifiedByType                : Application
Tag                                         : {
                                              }
Type                                        : neon.postgres/organizations
UserDetailEmailAddress                      : khanalmas@microsoft.com
UserDetailFirstName                         : Almas
UserDetailLastName                          : Khan
UserDetailPhoneNumber                       : +1234567890
UserDetailUpn                               : khanalmas_microsoft.com#EXT#@qumulotesttenant2.onmicrosoft.com
```

This command will create a Neon Resource

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailBusinessPhone
Business phone number of the company

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailCompanyName
Company name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailCountry
Country name of the company

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailDomain
Domain of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailNumberOfEmployee
Number of employees in the company

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailOfficeAddress
Office address of the company

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceDetailSubscriptionId
SaaS subscription id for the the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceDetailSubscriptionStatus
Marketplace subscription status

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Neon Organizations resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: OrganizationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailOfferId
Offer Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPlanId
Plan Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPlanName
Plan Name for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPublisherId
Publisher Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailTermId
Term Id for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailTermUnit
Term Name for the marketplace offer

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerOrganizationPropertyOrganizationId
Organization Id in partner's system

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerOrganizationPropertyOrganizationName
Organization name in partner's system

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyAadDomain
List of AAD domains fetched from Microsoft Graph for user.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyEnterpriseAppId
AAD enterprise application Id used to setup SSO

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertySingleSignOnState
State of the Single Sign On for the organization

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertySingleSignOnUrl
URL for SSO to be used by the partner to redirect the user to their system

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailEmailAddress
Email address of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailFirstName
First name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailLastName
Last name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailPhoneNumber
User's phone number

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailUpn
User's principal name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IOrganizationResource

## NOTES

## RELATED LINKS

