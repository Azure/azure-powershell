---
external help file:
Module Name: Az.Astro
online version: https://learn.microsoft.com/powershell/module/az.astro/get-azastroorganization
schema: 2.0.0
---

# Get-AzAstroOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzAstroOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAstroOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAstroOrganization -InputObject <IAstroIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzAstroOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get specific resource with specified resource group
```powershell
Get-AzAstroOrganization -ResourceGroupName astro-user -Name UT.1.test
```

```output
Id                                          : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/astro-user/providers/Astronomer.Astro/organizations/UT.1.test
IdentityPrincipalId                         : 
IdentityTenantId                            : 
IdentityType                                : None
IdentityUserAssignedIdentity                : {
                                              }
Location                                    : eastus
MarketplaceSubscriptionId                   : 11111111-2222-3333-4444-123456789102
MarketplaceSubscriptionStatus               : Subscribed
Name                                        : UT.1.test
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
ProvisioningState                           : Failed
ResourceGroupName                           : astro-user
SingleSignOnPropertyAadDomain               : {MicrosoftCustomerLed.onmicrosoft.com}
SingleSignOnPropertyEnterpriseAppId         : 
SingleSignOnPropertyProvisioningState       : 
SingleSignOnPropertySingleSignOnState       : 
SingleSignOnPropertySingleSignOnUrl         : 
SystemDataCreatedAt                         : 8/5/2024 9:05:54 AM
SystemDataCreatedBy                         : example@microsoft.com
SystemDataCreatedByType                     : User
SystemDataLastModifiedAt                    : 8/5/2024 9:07:44 AM
SystemDataLastModifiedBy                    : 11111111-2222-3333-4444-123456789103
SystemDataLastModifiedByType                : Application
Tag                                         : {
                                              }
Type                                        : astronomer.astro/organizations
UserEmailAddress                            : example@microsoft.com
UserFirstName                               : user
UserLastName                                : test
UserPhoneNumber                             : 
UserUpn                                     : example@microsoft.com
```

This command gets specific Astro organization with specified resource group.

### Example 2: List by resource group
```powershell
Get-AzAstroOrganization -ResourceGroupName test-group
```

```output
Location      Name          SystemDataCreatedAt    SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------      ----          -------------------    -------------------    ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
australiaeast a-2           11/9/2023 5:58:52 AM   example@microsoft.com  User                    11/9/2023 5:58:52 AM     example@microsoft.com                User                         test-group
eastus2euap   astro61       9/15/2023 11:49:42 AM  example@microsoft.com  User                    9/15/2023 11:51:27 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro81       9/19/2023 6:34:27 AM   example@microsoft.com  User                    9/19/2023 6:37:37 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro82       9/19/2023 7:10:09 AM   example@microsoft.com  User                    9/19/2023 7:13:12 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro83       9/19/2023 7:28:56 AM   example@microsoft.com  User                    9/19/2023 7:31:34 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro84       9/19/2023 10:55:58 AM  example@microsoft.com  User                    9/19/2023 10:56:53 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro101      10/3/2023 11:30:43 AM  example@microsoft.com  User                    10/3/2023 11:31:35 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro102      10/3/2023 11:55:51 AM  example@microsoft.com  User                    10/3/2023 11:56:57 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro201      10/11/2023 9:21:25 AM  example@microsoft.com  User                    10/11/2023 9:25:27 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro203      10/11/2023 12:32:59 PM example@microsoft.com  User                    10/11/2023 3:00:45 PM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   sampleAstro10 11/8/2023 12:07:15 PM  example@microsoft.com  User                    11/8/2023 12:10:36 PM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   a-51          11/9/2023 1:05:27 PM   example@microsoft.com  User                    11/9/2023 1:08:11 PM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   sampleAstro70 11/9/2023 1:07:00 PM   example@microsoft.com  User                    11/9/2023 1:08:43 PM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   sampleAstro75 11/9/2023 6:21:15 PM   example@microsoft.com  User                    11/9/2023 6:24:44 PM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   sample81      11/9/2023 6:30:06 PM   example@microsoft.com  User                    11/9/2023 6:31:38 PM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   sample82      11/10/2023 7:21:38 AM  example@microsoft.com  User                    11/10/2023 7:22:44 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro42       9/13/2023 12:12:15 PM  example@microsoft.com  User                    9/14/2023 6:45:01 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro45       9/13/2023 12:40:31 PM  example@microsoft.com  User                    9/14/2023 6:45:03 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro51       9/14/2023 9:43:28 AM   example@microsoft.com  User                    9/14/2023 9:47:24 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
eastus2euap   astro52       9/14/2023 11:51:48 AM  example@microsoft.com  User                    9/15/2023 9:24:51 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro-30      9/7/2023 11:40:10 AM   example@microsoft.com  User                    9/7/2023 11:44:08 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro-31      9/7/2023 12:16:24 PM   example@microsoft.com  User                    9/7/2023 12:20:30 PM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro-32      9/8/2023 3:44:16 AM    example@microsoft.com  User                    9/8/2023 3:48:24 AM      11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro71       9/18/2023 9:04:13 AM   example@microsoft.com  User                    9/18/2023 9:06:22 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro91       9/25/2023 6:36:24 AM   example@microsoft.com  User                    9/25/2023 6:37:11 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap test-canary-1 8/25/2023 8:51:41 AM   example@microsoft.com  User                    8/25/2023 8:52:16 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro11       8/30/2023 6:55:29 AM   example@microsoft.com  User                    8/30/2023 6:59:47 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro12       8/30/2023 7:05:45 AM   example@microsoft.com  User                    8/30/2023 7:09:59 AM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap sampleAstro   8/31/2023 10:18:49 AM  example@microsoft.com  User                    8/31/2023 10:23:17 AM    11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro18       8/31/2023 2:44:51 PM   example@microsoft.com  User                    8/31/2023 2:49:07 PM     11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro21       9/4/2023 3:30:47 AM    example@microsoft.com  User                    9/4/2023 3:35:03 AM      11111111-2222-3333-4444-123456789103 Application                  test-group
centraluseuap astro22       9/4/2023 5:04:39 AM    example@microsoft.com  User                    9/4/2023 5:08:52 AM      11111111-2222-3333-4444-123456789103 Application                  test-group
```

This command gets list of Astro organization resources by resource group.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Astro.Models.IAstroIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Astro.Models.IAstroIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Astro.Models.IOrganizationResource

## NOTES

## RELATED LINKS

