---
external help file:
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/test-azconfluentvalidationorganization
schema: 2.0.0
---

# Test-AzConfluentValidationOrganization

## SYNOPSIS
Organization Validate proxy resource

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzConfluentValidationOrganization -OrganizationName <String> -ResourceGroupName <String>
 -Location <String> -OfferDetailId <String> -OfferDetailPlanId <String> -OfferDetailPlanName <String>
 -OfferDetailPublisherId <String> -OfferDetailTermUnit <String> -UserDetailEmailAddress <String>
 [-SubscriptionId <String>] [-LinkOrganizationToken <SecureString>] [-OfferDetailPrivateOfferId <String>]
 [-OfferDetailStatus <String>] [-OfferDetailTermId <String>] [-PropertiesOfferDetailPrivateOfferId <String[]>]
 [-Tag <Hashtable>] [-UserDetailAadEmail <String>] [-UserDetailFirstName <String>]
 [-UserDetailLastName <String>] [-UserDetailUserPrincipalName <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzConfluentValidationOrganization -OrganizationName <String> -ResourceGroupName <String>
 -Body <IOrganizationResource> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzConfluentValidationOrganization -InputObject <IConfluentIdentity> -Body <IOrganizationResource>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzConfluentValidationOrganization -InputObject <IConfluentIdentity> -Location <String>
 -OfferDetailId <String> -OfferDetailPlanId <String> -OfferDetailPlanName <String>
 -OfferDetailPublisherId <String> -OfferDetailTermUnit <String> -UserDetailEmailAddress <String>
 [-LinkOrganizationToken <SecureString>] [-OfferDetailPrivateOfferId <String>] [-OfferDetailStatus <String>]
 [-OfferDetailTermId <String>] [-PropertiesOfferDetailPrivateOfferId <String[]>] [-Tag <Hashtable>]
 [-UserDetailAadEmail <String>] [-UserDetailFirstName <String>] [-UserDetailLastName <String>]
 [-UserDetailUserPrincipalName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaJsonFilePath
```
Test-AzConfluentValidationOrganization -OrganizationName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaJsonString
```
Test-AzConfluentValidationOrganization -OrganizationName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Organization Validate proxy resource

## EXAMPLES

### Example 1: Organization Validate proxy resource
```powershell
Test-AzConfluentValidationOrganization `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -Location "centralus" `
    -OfferDetailId "confluent-cloud-azure-prod" `
    -OfferDetailPlanId "confluent-cloud-azure-payg-prod" `
    -OfferDetailPlanName "Confluent Cloud - Pay as you Go" `
    -OfferDetailPublisherId "confluentinc" `
    -OfferDetailTermUnit "P1M" `
    -UserDetailEmailAddress "user4@example.com" `
    -UserDetailFirstName "Prem" `
    -UserDetailLastName "Gnanashekar" `
    -UserDetailUserPrincipalName "user4@example.com"
```

```output
Test-AzConfluentValidationOrganization_ValidateExpanded: SaaS Purchase Payment Check Failed as validationResponse was {"isEligible":false,"errorMessage":"Test header retention date cannot be in the past. {\"contact\":\"testaccounts@example.com\",\"scenarios\":\"BAMI,CSZ,Inv-v7,crs-vnext\",\"retention\":\"2099-01-01T00:00:00.000Z\"}"} Organization resource already exists with resource id: /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org. Cannot complete signup. Reason: Email already exists. For more details: https://docs.confluent.io/cloud/current/billing/ccloud-azure-payg.html#prerequisites.ErrorCode:40025CorrelationID:00000000-0000-0000-0000-000000000002
```

This command Validates Organization proxy resource

## PARAMETERS

### -Body
Organization resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IOrganizationResource
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinkOrganizationToken
User auth token

```yaml
Type: System.Security.SecureString
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailId
Offer Id

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPlanId
Offer Plan Id

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPlanName
Offer Plan Name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPrivateOfferId
Private Offer Id

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailPublisherId
Publisher Id

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailStatus
SaaS Offer Status

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailTermId
Offer Plan Term Id

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferDetailTermUnit
Offer Plan Term unit

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesOfferDetailPrivateOfferId
Array of Private Offer Ids

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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
Parameter Sets: Validate, ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
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
Type: System.String
Parameter Sets: Validate, ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
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
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailAadEmail
AAD email address

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailEmailAddress
Email address

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailFirstName
First name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailLastName
Last name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserDetailUserPrincipalName
User principal name

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IOrganizationResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IOrganizationResource

## NOTES

## RELATED LINKS

