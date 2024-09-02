---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridpartnerconfiguration
schema: 2.0.0
---

# New-AzEventGridPartnerConfiguration

## SYNOPSIS
Synchronously creates or updates a partner configuration with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridPartnerConfiguration -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Location <String>] [-PartnerAuthorizationAuthorizedPartnersList <IPartner[]>]
 [-PartnerAuthorizationDefaultMaximumExpirationTimeInDay <Int32>] [-ProvisioningState <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridPartnerConfiguration -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridPartnerConfiguration -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Synchronously creates or updates a partner configuration with the specified parameters.

## EXAMPLES

### Example 1: Synchronously Create a partner configuration with the specified parameters.
```powershell
$partner = New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -Name "Auth0" -RegistrationImmutableId "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
New-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 10 -PartnerAuthorizationAuthorizedPartnersList $partner
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Synchronously Create a partner configuration with the specified parameters.

### Example 2: Synchronously Create a partner configuration with the specified parameters.
```powershell
$partnerRegistration = Get-AzEventGridPartnerRegistration -ResourceGroupName azps_test_group_eventgrid -Name azps-registration
$partner = New-AzEventGridPartnerObject -AuthorizationExpirationTimeInUtc "2023-11-19T09:31:42.521Z" -RegistrationImmutableId $partnerRegistration.ImmutableId
New-AzEventGridPartnerConfiguration -ResourceGroupName azps_test_group_eventgrid -Location global -PartnerAuthorizationDefaultMaximumExpirationTimeInDay 10 -PartnerAuthorizationAuthorizedPartnersList $partner
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
default global   azps_test_group_eventgrid
```

Synchronously Create a partner configuration with the specified parameters.

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
Location of the resource.

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

### -PartnerAuthorizationAuthorizedPartnersList
The list of authorized partners.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPartner[]
Parameter Sets: CreateExpanded
Aliases: AuthorizedPartner

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerAuthorizationDefaultMaximumExpirationTimeInDay
Time used to validate the authorization expiration time for each authorized partner.
If DefaultMaximumExpirationTimeInDays isnot specified, the default is 7 days.
Otherwise, allowed values are between 1 and 365 days.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases: MaxExpirationTimeInDays

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ProvisioningState
Provisioning state of the partner configuration.

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
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
Tags of the resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IPartnerConfiguration

## NOTES

## RELATED LINKS

