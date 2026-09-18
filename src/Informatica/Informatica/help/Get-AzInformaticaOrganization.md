---
external help file: Az.Informatica-help.xml
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/get-azinformaticaorganization
schema: 2.0.0
---

# Get-AzInformaticaOrganization

## SYNOPSIS
Get a InformaticaOrganizationResource

## SYNTAX

### List (Default)
```
Get-AzInformaticaOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzInformaticaOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzInformaticaOrganization -InputObject <IInformaticaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a InformaticaOrganizationResource

## EXAMPLES

### Example 1: Get Informatica Organization Details
```powershell
Get-AzInformaticaOrganization -OrganizationName InformaticaTestResource -ResourceGroupName InformaticaTestRg
```

```output
BusinessPhoneNumber                        :
CompanyDetailCompanyName                   : Microsoft
CompanyDetailCountry                       : India
CompanyDetailDomain                        :
CompanyDetailNumberOfEmployee              : 0
CompanyDetailOfficeAddress                 :
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/InformaticaTestResource
InformaticaPropertyInformaticaRegion       : West-US2-Staging
InformaticaPropertyOrganizationId          :
InformaticaPropertyOrganizationName        :
InformaticaPropertySingleSignOnUrl         :
LinkOrganizationToken                      :
Location                                   : westus2
MarketplaceDetailMarketplaceSubscriptionId : 509e641c-c8d9-4ec9-838b-0cdd41d055dc
Name                                       : InformaticaTestResource
OfferDetailOfferId                         : azurenativeinfaservces
OfferDetailPlanId                          : privatepreview-plan-cdi-free_00
OfferDetailPlanName                        : CDI Free - Private Preview
OfferDetailPublisherId                     : informatica
OfferDetailTermId                          : o73usof6rkyy
OfferDetailTermUnit                        : P1Y
ProvisioningState                          : Succeeded
ResourceGroupName                          : InformaticaTestRg
SystemDataCreatedAt                        : 09-Jul-24 11:35:18 AM
SystemDataCreatedBy                        : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 09-Jul-24 11:36:11 AM
SystemDataLastModifiedBy                   : 1907c93c-5795-4a9c-8ad3-7798b1d72580
SystemDataLastModifiedByType               : Application
Tag                                        : {}
Type                                       : informatica.datamanagement/organizations
UserDetailEmailAddress                     : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
UserDetailFirstName                        : Test
UserDetailLastName                         : Infa
UserDetailPhoneNumber                      : 9876543210
```

This command will get Informatica organization details for a specific organization name and resource group

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Organizations resource

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

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaOrganizationResource

## NOTES

## RELATED LINKS
