---
external help file:
Module Name: Az.Napster
online version: https://learn.microsoft.com/powershell/module/az.napster/new-aznapsterorganization
schema: 2.0.0
---

# New-AzNapsterOrganization

## SYNOPSIS
Create a OrganizationResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzNapsterOrganization -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-EnableSystemAssignedIdentity] [-MarketplaceSaasResourceId <String>]
 [-MarketplaceSubscriptionId <String>] [-OfferDetailOfferId <String>] [-OfferDetailPlanId <String>]
 [-OfferDetailPlanName <String>] [-OfferDetailPublisherId <String>] [-OfferDetailTermId <String>]
 [-OfferDetailTermUnit <String>] [-PartnerPropertyApplication <String>]
 [-SingleSignOnPropertyAadDomain <String[]>] [-SingleSignOnPropertyEnterpriseAppId <String>]
 [-SingleSignOnPropertyState <String>] [-SingleSignOnPropertyType <String>]
 [-SingleSignOnPropertyUrl <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserEmailAddress <String>] [-UserFirstName <String>] [-UserLastName <String>] [-UserPhoneNumber <String>]
 [-UserUpn <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNapsterOrganization -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNapsterOrganization -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a OrganizationResource

## EXAMPLES

### Example 1: Create a new Napster Organization with Single Sign-On
```powershell
New-AzNapsterOrganization -Name "napster-test3" -Location "eastus2euap" -ResourceGroupName "acctest0001" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId "09fffd7d-d000-4467-cc23-d82b97e9431d" -OfferDetailOfferId "napster_companion_api" -OfferDetailPlanId "napster_companion_api_feb_2026" -OfferDetailPlanName "Pay As You Go" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "touchcastinc1655995956899" -OfferDetailTermId "n7ja87drquhy" -PartnerPropertyApplication "dsaf" -SingleSignOnPropertyType "OpenId" -SingleSignOnPropertyState "Initial" -SingleSignOnPropertyAadDomain @("MicrosoftCustomerLed.onmicrosoft.com") -SingleSignOnPropertyUrl "https://companion-api.napsterai.dev/admin/ms-auth" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com"
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test3
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus2euap
MarketplaceSubscriptionId           : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus       : Subscribed
Name                                : napster-test3
OfferDetailOfferId                  : napster_companion_api
OfferDetailPlanId                   : napster_companion_api_feb_2026
OfferDetailPlanName                 : Pay As You Go
OfferDetailPublisherId              : touchcastinc1655995956899
OfferDetailTermId                   : n7ja87drquhy
OfferDetailTermUnit                 : P1M
PartnerPropertyApplication          : dsaf
ProvisioningState                   : Succeeded
ResourceGroupName                   : acctest0001
SingleSignOnPropertyAadDomain       : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyState           : Initial
SingleSignOnPropertyType            : OpenId
SingleSignOnPropertyUrl             : https://companion-api.napsterai.dev/admin/ms-auth
SystemDataCreatedAt                 : 5/3/2025 11:18:50 PM
SystemDataCreatedBy                 : yashikajain@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 5/3/2025 11:18:50 PM
SystemDataLastModifiedBy            : yashikajain@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : napster.companionapi/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : yashikajain@microsoft.com
```

This command creates a new Napster Companion API organization with Single Sign-On configured via OpenId, linked to the specified Azure Marketplace SaaS offer.

### Example 2: Create a new Napster Organization without Single Sign-On
```powershell
New-AzNapsterOrganization -Name "napster-test-basic" -Location "eastus2euap" -ResourceGroupName "acctest0001" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId "09fffd7d-d000-4467-cc23-d82b97e9431d" -OfferDetailOfferId "napster_companion_api" -OfferDetailPlanId "napster_companion_api_feb_2026" -OfferDetailPlanName "Pay As You Go" -OfferDetailTermUnit "P1M" -OfferDetailPublisherId "touchcastinc1655995956899" -OfferDetailTermId "n7ja87drquhy" -PartnerPropertyApplication "dsaf" -Tag @{"TestName" = "TestValue"} -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com"
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test-basic
Location                            : eastus2euap
MarketplaceSubscriptionId           : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus       : Subscribed
Name                                : napster-test-basic
OfferDetailOfferId                  : napster_companion_api
OfferDetailPlanId                   : napster_companion_api_feb_2026
OfferDetailPlanName                 : Pay As You Go
OfferDetailPublisherId              : touchcastinc1655995956899
OfferDetailTermId                   : n7ja87drquhy
OfferDetailTermUnit                 : P1M
PartnerPropertyApplication          : dsaf
ProvisioningState                   : Succeeded
ResourceGroupName                   : acctest0001
Tag                                 : {
                                        "TestName": "TestValue"
                                      }
Type                                : napster.companionapi/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserUpn                             : yashikajain@microsoft.com
```

This command creates a new Napster Companion API organization without Single Sign-On configuration.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -MarketplaceSaasResourceId
Marketplace SaaS Resource Id

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

### -MarketplaceSubscriptionId
Azure subscription id for the the marketplace offer is purchased from

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
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Organizationname

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
Plan Display Name for the marketplace offer

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
Plan Display Name for the marketplace offer

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

### -PartnerPropertyApplication
Application name

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

### -SingleSignOnPropertyState
State of the Single Sign On for the resource

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

### -SingleSignOnPropertyType
Type of Single Sign-On mechanism being used

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

### -SingleSignOnPropertyUrl
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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### -UserEmailAddress
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

### -UserFirstName
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

### -UserLastName
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

### -UserPhoneNumber
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

### -UserUpn
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

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.IOrganizationResource

## NOTES

## RELATED LINKS

