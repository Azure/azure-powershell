---
external help file:
Module Name: Az.ArizeAI
online version: https://learn.microsoft.com/powershell/module/az.arizeai/update-azarizeaiorganization
schema: 2.0.0
---

# Update-AzArizeAIOrganization

## SYNOPSIS
Update a OrganizationResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzArizeAIOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-MarketplaceSubscriptionId <String>]
 [-OfferDetailOfferId <String>] [-OfferDetailPlanId <String>] [-OfferDetailPlanName <String>]
 [-OfferDetailPublisherId <String>] [-OfferDetailTermId <String>] [-OfferDetailTermUnit <String>]
 [-PartnerPropertyDescription <String>] [-SingleSignOnPropertyAadDomain <String[]>]
 [-SingleSignOnPropertyEnterpriseAppId <String>] [-SingleSignOnPropertyState <String>]
 [-SingleSignOnPropertyType <String>] [-SingleSignOnPropertyUrl <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-UserEmailAddress <String>] [-UserFirstName <String>]
 [-UserLastName <String>] [-UserPhoneNumber <String>] [-UserUpn <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzArizeAIOrganization -InputObject <IArizeAiIdentity> [-EnableSystemAssignedIdentity <Boolean?>]
 [-MarketplaceSubscriptionId <String>] [-OfferDetailOfferId <String>] [-OfferDetailPlanId <String>]
 [-OfferDetailPlanName <String>] [-OfferDetailPublisherId <String>] [-OfferDetailTermId <String>]
 [-OfferDetailTermUnit <String>] [-PartnerPropertyDescription <String>]
 [-SingleSignOnPropertyAadDomain <String[]>] [-SingleSignOnPropertyEnterpriseAppId <String>]
 [-SingleSignOnPropertyState <String>] [-SingleSignOnPropertyType <String>]
 [-SingleSignOnPropertyUrl <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-UserEmailAddress <String>] [-UserFirstName <String>] [-UserLastName <String>] [-UserPhoneNumber <String>]
 [-UserUpn <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a OrganizationResource

## EXAMPLES

### Example 1: Update an existing Organization
```powershell
Update-AzArizeAIOrganization -Name "test2" -ResourceGroupName "yashika-rg-arize" -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -MarketplaceSubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -OfferDetailOfferId "arize-liftr-0" -OfferDetailPlanId "liftr-test-0" -OfferDetailPlanName "Liftr Test 0" -OfferDetailPublisherId "arizeai1657829589668" -OfferDetailTermId "gmz7xq9ge3py" -OfferDetailTermUnit "P1M" -UserEmailAddress "yashikajain@microsoft.com" -UserFirstName "" -UserLastName "" -UserUpn "yashikajain@microsoft.com" -PartnerPropertyDescription "testing" -Tag @{"TestName1" = "TestValue1"}
```

```output
Id                                  : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/yashika-rg-arize/providers/ArizeAi
                                      .ObservabilityEval/organizations/test2
IdentityPrincipalId                 : 
IdentityTenantId                    : 
IdentityType                        : None
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           : 61641157-140c-4b97-b365-30ff76d9f82e
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : test2
OfferDetailOfferId                  : arize-liftr-0
OfferDetailPlanId                   : liftr-test-0
OfferDetailPlanName                 : Liftr Test 0
OfferDetailPublisherId              : arizeai1657829589668
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyDescription          : testing
ProvisioningState                   : Succeeded
ResourceGroupName                   : yashika-rg-arize
SingleSignOnPropertyAadDomain       : 
SingleSignOnPropertyEnterpriseAppId : 
SingleSignOnPropertyState           : 
SingleSignOnPropertyType            : 
SingleSignOnPropertyUrl             : 
SystemDataCreatedAt                 : 7/9/2025 9:04:42 AM
SystemDataCreatedBy                 : yashikajain@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 7/9/2025 9:25:22 AM
SystemDataLastModifiedBy            : yashikajain@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                        "TestName1": "TestValue1"
                                      }
Type                                : arizeai.observabilityeval/organizations
UserEmailAddress                    : yashikajain@microsoft.com
UserFirstName                       : 
UserLastName                        : 
UserPhoneNumber                     : 
UserUpn                             : yashikajain@microsoft.com
```

This command updates the ArizeAI organization.

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
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MarketplaceSubscriptionId
Azure subscription id for the the marketplace offer is purchased from

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerPropertyDescription
Description of the Organization's purpose

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.ArizeAI.Models.IArizeAiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArizeAI.Models.IOrganizationResource

## NOTES

## RELATED LINKS

