---
external help file: Az.Napster-help.xml
Module Name: Az.Napster
online version: https://learn.microsoft.com/powershell/module/az.napster/get-aznapsterorganization
schema: 2.0.0
---

# Get-AzNapsterOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzNapsterOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNapsterOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzNapsterOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNapsterOrganization -InputObject <INapsterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get all Napster Organizations in a Resource Group
```powershell
Get-AzNapsterOrganization -ResourceGroupName acctest0001
```

```output
Location   Name          SystemDataCreatedAt   SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType ResourceGroupName
--------   ----          -------------------   -------------------        ----------------------- ------------------------ ------------------------   ---------------------------- -----------------
eastus2euap napster-test1 5/1/2025 11:00:11 AM yashikajain@microsoft.com  User                    5/1/2025 11:00:11 AM     yashikajain@microsoft.com  User                         acctest0001
eastus2euap napster-test2 5/2/2025 9:57:25 AM  yashikajain@microsoft.com  User                    5/2/2025 2:59:47 PM      yashikajain@microsoft.com  User                         acctest0001
```

This command lists all Napster organizations in the specified resource group.

### Example 2: Get a specific Napster Organization in a Resource Group
```powershell
Get-AzNapsterOrganization -ResourceGroupName acctest0001 -Name napster-test1
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus2euap
MarketplaceSubscriptionId           : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus       : Subscribed
Name                                : napster-test1
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
SystemDataCreatedAt                 : 5/1/2025 11:00:11 AM
SystemDataCreatedBy                 : yashikajain@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 5/1/2025 11:00:11 AM
SystemDataLastModifiedBy            : yashikajain@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : napster.companionapi/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : yashikajain@microsoft.com
```

This command gets details of a specific Napster organization by name in the specified resource group.

### Example 3: List all Napster Organizations in the subscription
```powershell
Get-AzNapsterOrganization -SubscriptionId 61641157-140c-4b97-b365-30ff76d9f82e
```

```output
Location    Name          ResourceGroupName
--------    ----          -----------------
eastus2euap napster-test1 acctest0001
eastus2euap napster-test2 acctest0001
```

This command lists all Napster organizations across all resource groups in the subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.INapsterIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.INapsterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.IOrganizationResource

## NOTES

## RELATED LINKS
