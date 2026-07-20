---
external help file:
Module Name: Az.LambdaTest
online version: https://learn.microsoft.com/powershell/module/az.lambdatest/get-azlambdatestorganization
schema: 2.0.0
---

# Get-AzLambdaTestOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzLambdaTestOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzLambdaTestOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzLambdaTestOrganization -InputObject <ILambdaTestIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzLambdaTestOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get all Organizations in a Resource Group
```powershell
Get-AzLambdaTestOrganization -ResourceGroupName jawt-rg
```

```output
Location       Name                   SystemDataCreatedAt    SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
--------       ----                   -------------------    ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
East US        liftr-lamda-org-1      12/17/2024 11:00:11 AM jawt@microsoft.com  User                    12/17/2024 11:00:11 AM   jawt@microsoft.com       User                         jawt-rg
East US        liftr-lambdatest-org2  1/30/2025 9:57:25 AM   jawt@microsoft.com  User                    1/30/2025 2:59:47 PM     jawt@microsoft.com       User                         jawt-rg
East US        liftr-lambdatest-org3  1/30/2025 3:25:38 PM   jawt@microsoft.com  User                    1/30/2025 3:25:38 PM     jawt@microsoft.com       User                         jawt-rg
East US        liftr-lambdatest-org4  2/4/2025 11:00:01 AM   jawt@microsoft.com  User                    2/4/2025 11:00:01 AM     jawt@microsoft.com       User                         jawt-rg
East US        liftr-lambdatest-org6  2/28/2025 8:58:29 AM   jawt@microsoft.com  User                    2/28/2025 8:58:29 AM     jawt@microsoft.com       User                         jawt-rg
East US 2 EUAP liftr-lambdatest-org5  2/21/2025 5:01:40 AM   jawt@microsoft.com  User                    2/21/2025 5:01:40 AM     jawt@microsoft.com       User                         jawt-rg
East US 2 EUAP liftr-lambdatest-org7  3/17/2025 8:32:45 AM   jawt@microsoft.com  User                    3/17/2025 8:32:45 AM     jawt@microsoft.com       User                         jawt-rg
East US 2 EUAP liftr-lambdatest-org8  3/17/2025 9:16:14 AM   jawt@microsoft.com  User                    3/17/2025 9:16:14 AM     jawt@microsoft.com       User                         jawt-rg
East US 2 EUAP liftr-lambdatest-org9  3/17/2025 10:00:39 AM  jawt@microsoft.com  User                    3/17/2025 10:00:39 AM    jawt@microsoft.com       User                         jawt-rg
East US 2 EUAP liftr-lambdatest-org-1                                                                    4/10/2025 2:33:10 PM     jawt@microsoft.com       User                         jawt-rg
```

This command will get all organization details for all resources in a resource group in a given subscription.

### Example 2: Get a specific Organization in a Resource Group
```powershell
Get-AzLambdaTestOrganization -ResourceGroupName jawt-rg -Name liftr-lamda-org-1
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/jawt-rg/providers/lambdatest.hyperexecute/organizations/liftr-lamda-org-1
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : East US
MarketplaceSubscriptionId           : 7f0e6b73-6e01-47dc-c79b-30ab306ee343
MarketplaceSubscriptionStatus       : Subscribed
Name                                : liftr-lamda-org-1
OfferDetailOfferId                  : lambdatest_liftr_testing
OfferDetailPlanId                   : testing
OfferDetailPlanName                 : testing_liftr
OfferDetailPublisherId              : lambdatestinc1584019832435
OfferDetailTermId                   : o73usof6rkyy
OfferDetailTermUnit                 : P1Y
PartnerPropertyLicensesSubscribed   : 1
ProvisioningState                   : Succeeded
ResourceGroupName                   : jawt-rg
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 12/17/2024 11:00:11 AM
SystemDataCreatedBy                 : jawt@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 12/17/2024 11:00:11 AM
SystemDataLastModifiedBy            : jawt@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : lambdatest.hyperexecute/organizations
UserEmailAddress                    : jawt@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : jawt@microsoft.com
```

This command will get details of an organization for a resource name in a given subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.LambdaTest.Models.ILambdaTestIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.LambdaTest.Models.ILambdaTestIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LambdaTest.Models.IOrganizationResource

## NOTES

## RELATED LINKS

