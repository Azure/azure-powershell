---
external help file:
Module Name: Az.Confluent
online version: https://docs.microsoft.com/en-us/powershell/module/az.confluent/test-azconfluentvalidationorganization
schema: 2.0.0
---

# Test-AzConfluentValidationOrganization

## SYNOPSIS
Organization Validate proxy resource

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzConfluentValidationOrganization -OrganizationName <String> -ResourceGroupName <String>
 -OfferDetailId <String> -OfferDetailPlanId <String> -OfferDetailPlanName <String>
 -OfferDetailPublisherId <String> -OfferDetailTermUnit <String> -UserDetailEmailAddress <String>
 [-SubscriptionId <String>] [-Location <String>] [-Tag <Hashtable>] [-UserDetailFirstName <String>]
 [-UserDetailLastName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Test-AzConfluentValidationOrganization -InputObject <IConfluentIdentity> -OfferDetailId <String>
 -OfferDetailPlanId <String> -OfferDetailPlanName <String> -OfferDetailPublisherId <String>
 -OfferDetailTermUnit <String> -UserDetailEmailAddress <String> [-Location <String>] [-Tag <Hashtable>]
 [-UserDetailFirstName <String>] [-UserDetailLastName <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Organization Validate proxy resource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Organization resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20211201.IOrganizationResource
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of Organization resource

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
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Microsoft Azure subscription id

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Organization resource tags

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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20211201.IOrganizationResource

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20211201.IOrganizationResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IOrganizationResource>: Organization resource.
  - `OfferDetailId <String>`: Offer Id
  - `OfferDetailPlanId <String>`: Offer Plan Id
  - `OfferDetailPlanName <String>`: Offer Plan Name
  - `OfferDetailPublisherId <String>`: Publisher Id
  - `OfferDetailTermUnit <String>`: Offer Plan Term unit
  - `UserDetailEmailAddress <String>`: Email address
  - `[Location <String>]`: Location of Organization resource
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <IOrganizationResourceTags>]`: Organization resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[UserDetailFirstName <String>]`: First name
  - `[UserDetailLastName <String>]`: Last name

INPUTOBJECT <IConfluentIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[OrganizationName <String>]`: Organization resource name
  - `[ResourceGroupName <String>]`: Resource group name
  - `[SubscriptionId <String>]`: Microsoft Azure subscription id

## RELATED LINKS

