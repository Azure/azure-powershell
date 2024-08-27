---
external help file: Az.Astro-help.xml
Module Name: Az.Astro
online version: https://learn.microsoft.com/powershell/module/az.astro/new-azastroorganization
schema: 2.0.0
---

# New-AzAstroOrganization

## SYNOPSIS
Create a OrganizationResource

## SYNTAX

### CreateExpanded (Default)
```
New-AzAstroOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -MarketplaceSubscriptionId <String> -OfferDetailOfferId <String>
 -OfferDetailPlanId <String> -OfferDetailPublisherId <String> -UserEmailAddress <String>
 -UserFirstName <String> -UserLastName <String> [-EnableSystemAssignedIdentity]
 [-MarketplaceSubscriptionStatus <String>] [-OfferDetailPlanName <String>] [-OfferDetailTermId <String>]
 [-OfferDetailTermUnit <String>] [-PartnerOrganizationPropertyOrganizationId <String>]
 [-PartnerOrganizationPropertyOrganizationName <String>] [-PartnerOrganizationPropertyWorkspaceId <String>]
 [-PartnerOrganizationPropertyWorkspaceName <String>] [-SingleSignOnPropertyAadDomain <String[]>]
 [-SingleSignOnPropertyEnterpriseAppId <String>] [-SingleSignOnPropertySingleSignOnState <String>]
 [-SingleSignOnPropertySingleSignOnUrl <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserPhoneNumber <String>] [-UserUpn <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzAstroOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzAstroOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a OrganizationResource

## EXAMPLES

### Example 1: Create a Astro organization
```powershell
New-AzAstroOrganization -Name UT.7.test -ResourceGroupName astro-user -Location eastus -MarketplaceSubscriptionId 11111111-2222-3333-4444-123456789101 -OfferDetailOfferId astro -OfferDetailPlanId astro-paygo -OfferDetailPublisherId astronomer1 -OfferDetailPlanName 'Monthly Pay-As-You-Go' -OfferDetailTermId abcdefghijkl -OfferDetailTermUnit Monthly -UserEmailAddress example@microsoft.com -UserFirstName user -UserLastName test -UserUpn example@microsoft.com -PartnerOrganizationPropertyWorkspaceName aaa -PartnerOrganizationPropertyOrganizationName bbb -SingleSignOnPropertyAadDomain MicrosoftCustomerLed.onmicrosoft.com
```

```output
Id                                          : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/astro-user/providers/Astronomer.Astro/organizations/UT.2.test
IdentityPrincipalId                         : 
IdentityTenantId                            : 
IdentityType                                : 
IdentityUserAssignedIdentity                : {
                                              }
Location                                    : eastus
MarketplaceSubscriptionId                   : 11111111-2222-3333-4444-123456789102
MarketplaceSubscriptionStatus               : Subscribed
Name                                        : UT.7.test
OfferDetailOfferId                          : astro
OfferDetailPlanId                           : astro-paygo
OfferDetailPlanName                         : Monthly Pay-As-You-Go 
OfferDetailPublisherId                      : astronomer1
OfferDetailTermId                           : abcdefghijkl
OfferDetailTermUnit                         : Monthly
PartnerOrganizationPropertyOrganizationId   : 1111122222333334444455555
PartnerOrganizationPropertyOrganizationName : bbb
PartnerOrganizationPropertyWorkspaceId      : 1111122222333334444455555
PartnerOrganizationPropertyWorkspaceName    : aaa
ProvisioningState                           : Succeeded
ResourceGroupName                           : astro-user
SingleSignOnPropertyAadDomain               : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyEnterpriseAppId         : 
SingleSignOnPropertyProvisioningState       : 
SingleSignOnPropertySingleSignOnState       : Enable
SingleSignOnPropertySingleSignOnUrl         : https://account.astronomer.io/login?connection=waad-liftr-1111122222333334444455555&org-id=1111122222333334444455555
SystemDataCreatedAt                         : 8/5/2024 9:37:41 AM
SystemDataCreatedBy                         : example@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 8/5/2024 9:40:46 AM
SystemDataLastModifiedBy                    : 11111111-2222-3333-4444-123456789103
SystemDataLastModifiedByType                : Application
Tag                                         : {
                                              }
Type                                        : astronomer.astro/organizations
UserEmailAddress                            : example@microsoft.com
UserFirstName                               : user
UserLastName                                : test
UserPhoneNumber                             : 11111111111
UserUpn                                     : example@microsoft.com
```

This command creates a Astro organization.

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
Decides if enable a system assigned identity for the resource.

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

### -MarketplaceSubscriptionId
Azure subscription id for the the marketplace offer is purchased from

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

### -MarketplaceSubscriptionStatus
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
Offer Id for the marketplace offer

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

### -OfferDetailPlanId
Plan Id for the marketplace offer

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

Required: True
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

### -PartnerOrganizationPropertyWorkspaceId
Workspace Id in partner's system

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

### -PartnerOrganizationPropertyWorkspaceName
Workspace name in partner's system

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

Required: True
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

Required: True
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

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Astro.Models.IOrganizationResource

## NOTES

## RELATED LINKS
