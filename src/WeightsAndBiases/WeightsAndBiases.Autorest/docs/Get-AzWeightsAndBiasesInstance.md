---
external help file:
Module Name: Az.WeightsAndBiases
online version: https://learn.microsoft.com/powershell/module/az.weightsandbiases/get-azweightsandbiasesinstance
schema: 2.0.0
---

# Get-AzWeightsAndBiasesInstance

## SYNOPSIS
Get a InstanceResource

## SYNTAX

### List (Default)
```
Get-AzWeightsAndBiasesInstance [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWeightsAndBiasesInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWeightsAndBiasesInstance -InputObject <IWeightsAndBiasesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzWeightsAndBiasesInstance -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a InstanceResource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
Get-AzWeightsAndBiasesInstance -ResourceGroupName jawt-rg
```

```output
Location Name                     SystemDataCreatedAt   SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModified
                                                                                                                                                       ByType
-------- ----                     -------------------   -------------------  ----------------------- ------------------------ ------------------------ ----------------------
eastus   pleasedeletethisresource 11/15/2024 8:29:35 AM shijoy@microsoft.com User                    11/15/2024 8:29:35 AM    shijoy@microsoft.com     User
East US  efref4                   2/28/2025 10:38:03 AM shijoy@microsoft.com User                    2/28/2025 10:38:03 AM    shijoy@microsoft.com     User
```

This command lists all the resources in a given resource group

### Example 2: {{ Add title here }}
```powershell
Get-AzWeightsAndBiasesInstance -ResourceGroupName jawt-rg -Name wnb-test-org-5
```

```output
Id                                  : /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/jawt-rg/providers/Microsoft.WeightsAndBiases/instances/wnb-test-org-
                                      5
IdentityPrincipalId                 :
IdentityTenantId                    :
IdentityType                        :
IdentityUserAssignedIdentity        : {
                                      }
Location                            : eastus
MarketplaceSubscriptionId           : 03de7830-78ff-45f3-c564-58dd30bc36ca
MarketplaceSubscriptionStatus       : PendingFulfillmentStart
Name                                : wnb-test-org-5
OfferDetailOfferId                  : wandb_liftr
OfferDetailPlanId                   : liftr0plan
OfferDetailPlanName                 : WandB Liftr
OfferDetailPublisherId              : weightsandbiasesinc1641502883483
OfferDetailTermId                   : gmz7xq9ge3py
OfferDetailTermUnit                 : P1M
PartnerPropertyRegion               : eastus
PartnerPropertySubdomain            : testorg5
ProvisioningState                   : Failed
ResourceGroupName                   : jawt-rg
SingleSignOnPropertyAadDomain       :
SingleSignOnPropertyEnterpriseAppId :
SingleSignOnPropertyState           :
SingleSignOnPropertyType            :
SingleSignOnPropertyUrl             :
SystemDataCreatedAt                 : 1/31/2025 11:53:13 AM
SystemDataCreatedBy                 : jawt@microsoft.com
SystemDataCreatedByType             : User
SystemDataLastModifiedAt            : 1/31/2025 11:53:13 AM
SystemDataLastModifiedBy            : jawt@microsoft.com
SystemDataLastModifiedByType        : User
Tag                                 : {
                                      }
Type                                : microsoft.weightsandbiases/instances
UserEmailAddress                    : jawt@microsoft.com
UserFirstName                       :
UserLastName                        :
UserPhoneNumber                     :
UserUpn                             : jawt_microsoft.com#EXT#@MicrosoftCustomerLed.onmicrosoft.com
```

This command lists the details of requested resource name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.WeightsAndBiases.Models.IWeightsAndBiasesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Instance resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Instancename

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

### Microsoft.Azure.PowerShell.Cmdlets.WeightsAndBiases.Models.IWeightsAndBiasesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WeightsAndBiases.Models.IInstanceResource

## NOTES

## RELATED LINKS

