---
external help file: Az.Informatica-help.xml
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/update-azinformaticaorganization
schema: 2.0.0
---

# Update-AzInformaticaOrganization

## SYNOPSIS
Update a InformaticaOrganizationResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Property <IOrganizationPropertiesCustomUpdate>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzInformaticaOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzInformaticaOrganization -InputObject <IInformaticaIdentity>
 [-Property <IOrganizationPropertiesCustomUpdate>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a InformaticaOrganizationResource

## EXAMPLES

### Example 1: Update Informatica Organization
```powershell
Update-AzInformaticaOrganization -Name "InformaticaTestResource" -ResourceGroupName "InformaticaTestRg" -SubscriptionId "ce37d538-dfa3-49c3-b3cd-149b4b7db48a" -Property @{
    userDetails = @{
        firstName = "Test"
        lastName = ""
        emailAddress = "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com"
        upn = "Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com"
        phoneNumber = "9876543210"
    }
    marketplaceDetails = @{
        marketplaceSubscriptionId = "c948d31a-c011-4b16-ce29-688c1565fc06"
        offerDetails = @{
            offerId = "prod-idmc_as_azure_native_isv_service"
            publisherId = "informatica"
            planId = "prod-private_priview_plan_cdi_free"
            planName = "Pay as you go"
            termUnit = "P1Y"
            termId = "zwuaefo5ywwo"
        }
    }
    companyDetails = @{
        companyName = "TestCompany"
        country = "India"
        domain = ""
        business = ""
        numberOfEmployees = 0
    }
}
```

```output
BusinessPhoneNumber                        :
CompanyDetailCompanyName                   : Test
CompanyDetailCountry                       : India
CompanyDetailDomain                        :
CompanyDetailNumberOfEmployee              : 0
CompanyDetailOfficeAddress                 :
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/InformaticaTestResource
InformaticaPropertyInformaticaRegion       :
InformaticaPropertyOrganizationId          :
InformaticaPropertyOrganizationName        :
InformaticaPropertySingleSignOnUrl         :
LinkOrganizationToken                      :
Location                                   : westus2
MarketplaceDetailMarketplaceSubscriptionId : 3217f8a7-3349-4473-900d-3a6ec5d7c16c
Name                                       : InformaticaTestResource
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
SystemDataLastModifiedAt                   : 09-Jul-24 12:00:42 PM
SystemDataLastModifiedBy                   : khanalmas@microsoft.com
SystemDataLastModifiedByType               : User
Tag                                        : {}
Type                                       : informatica.datamanagement/organizations
UserDetailEmailAddress                     : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
UserDetailFirstName                        : Test
UserDetailLastName                         : Test
UserDetailPhoneNumber                      : 9876543210
UserDetailUpn                              : Test_Infa@mpliftrlogz20210811outlook.onmicrosoft.com
```

Update Informatica resource with the specified properties.

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Organizations resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: OrganizationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
Patchable PropertieInformaticaOrganizationPropertiesUpdates of the Organization observability resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IOrganizationPropertiesCustomUpdate
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaOrganizationResource

## NOTES

## RELATED LINKS
