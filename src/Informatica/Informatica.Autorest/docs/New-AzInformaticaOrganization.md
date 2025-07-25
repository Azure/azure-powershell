---
external help file:
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/new-azinformaticaorganization
schema: 2.0.0
---

# New-AzInformaticaOrganization

## SYNOPSIS
Create a InformaticaOrganizationResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-CompanyDetailBusiness <String>] [-CompanyDetailCompanyName <String>]
 [-CompanyDetailCountry <String>] [-CompanyDetailDomain <String>] [-CompanyDetailNumberOfEmployee <Int32>]
 [-CompanyDetailOfficeAddress <String>] [-InformaticaPropertyInformaticaRegion <String>]
 [-InformaticaPropertyOrganizationId <String>] [-InformaticaPropertyOrganizationName <String>]
 [-InformaticaPropertySingleSignOnUrl <String>] [-LinkOrganizationToken <String>]
 [-MarketplaceDetailMarketplaceSubscriptionId <String>] [-OfferDetailOfferId <String>]
 [-OfferDetailPlanId <String>] [-OfferDetailPlanName <String>] [-OfferDetailPublisherId <String>]
 [-OfferDetailTermId <String>] [-OfferDetailTermUnit <String>] [-Tag <Hashtable>]
 [-UserDetailEmailAddress <String>] [-UserDetailFirstName <String>] [-UserDetailLastName <String>]
 [-UserDetailPhoneNumber <String>] [-UserDetailUpn <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a InformaticaOrganizationResource

## EXAMPLES

### Example 1: Create new Informatica Resource
```powershell
New-AzInformaticaOrganization -Name "NewInformaticaTestResource" -ResourceGroupName "InformaticaTestRg" -Location "westus2" -SubscriptionId "ce37d538-dfa3-49c3-b3cd-149b4b7db48a"  -CompanyDetailCompanyName "Test" -CompanyDetailCountry "India" -CompanyDetailDomain "" -CompanyDetailNumberOfEmployee 0  -BusinessPhoneNumber ""  -MarketplaceDetailMarketplaceSubscriptionId "c948d31a-c011-4b16-ce29-688c1565fc06" -OfferDetailOfferId "prod-idmc_as_azure_native_isv_service" -OfferDetailPlanId "prod-private_priview_plan_cdi_free" -OfferDetailPlanName "Pay as you go" -OfferDetailPublisherId "informatica" -OfferDetailTermId "zwuaefo5ywwo" -OfferDetailTermUnit "P1Y" -UserDetailEmailAddress "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com" -UserDetailFirstName "Test" -UserDetailLastName "Test" -UserDetailPhoneNumber "9876543210" -UserDetailUpn "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com"
```

```output
BusinessPhoneNumber                        :
CompanyDetailCompanyName                   : Test
CompanyDetailCountry                       : India
CompanyDetailDomain                        :
CompanyDetailNumberOfEmployee              : 0
CompanyDetailOfficeAddress                 :
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/NewInformaticaTestResource
InformaticaPropertyInformaticaRegion       :
InformaticaPropertyOrganizationId          :
InformaticaPropertyOrganizationName        :
InformaticaPropertySingleSignOnUrl         :
LinkOrganizationToken                      :
Location                                   : westus2
MarketplaceDetailMarketplaceSubscriptionId : 3217f8a7-3349-4473-900d-3a6ec5d7c16c
Name                                       : NewInformaticaTestResource
OfferDetailOfferId                         : prod-idmc_as_azure_native_isv_service
OfferDetailPlanId                          : prod-private_priview_plan_cdi_free
OfferDetailPlanName                        : Pay as you go
OfferDetailPublisherId                     : informatica
OfferDetailTermId                          : zwuaefo5ywwo
OfferDetailTermUnit                        : P1Y
ProvisioningState                          : Succeeded
ResourceGroupName                          : InformaticaTestRg
SystemDataCreatedAt                        : 09-Jul-24 11:48:22 AM
SystemDataCreatedBy                        : khanalmas@microsoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 09-Jul-24 11:48:52 AM
SystemDataLastModifiedBy                   : 1907c93c-5795-4a9c-8ad3-7798b1d72580
SystemDataLastModifiedByType               : Application
Tag                                        : {}
Type                                       : informatica.datamanagement/organizations
UserDetailEmailAddress                     : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
UserDetailFirstName                        : Test
UserDetailLastName                         : Test
UserDetailPhoneNumber                      : 9876543210
UserDetailUpn                              : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
```

Create new Informatica Resource in the specified resource group.

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

### -CompanyDetailBusiness
Business phone number

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
company Name

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
Country name

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
Domain name

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
Number Of Employees

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyDetailOfficeAddress
Office Address

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

### -InformaticaPropertyInformaticaRegion
Informatica organization region

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

### -InformaticaPropertyOrganizationId
Organization id

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

### -InformaticaPropertyOrganizationName
Organization name

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

### -InformaticaPropertySingleSignOnUrl
Single sing on URL for informatica organization

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

### -LinkOrganizationToken
Link organization token

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

### -MarketplaceDetailMarketplaceSubscriptionId
Marketplace Subscription Id

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
Name of the Organizations resource

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
Id of the product offering.

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
Id of the product offer plan.

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
Name of the product offer plan.

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
Id of the product publisher.

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
Offer plan term id.

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
Offer plan term unit.

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

### -SubscriptionId
The ID of the target subscription.

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
User email address.

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
User first name.

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
User last name.

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
Phone number of the user used by for contacting them if needed

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
UPN of user

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

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaOrganizationResource

## NOTES

## RELATED LINKS

