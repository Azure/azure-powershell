---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/test-azpeeringserviceprovideravailability
schema: 2.0.0
---

# Test-AzPeeringServiceProviderAvailability

## SYNOPSIS
Checks if the peering service provider is present within 1000 miles of customer's location

## SYNTAX

### CheckExpanded (Default)
```
Test-AzPeeringServiceProviderAvailability [-SubscriptionId <String>] [-PeeringServiceLocation <String>]
 [-PeeringServiceProvider <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Check
```
Test-AzPeeringServiceProviderAvailability [-SubscriptionId <String>]
 -CheckServiceProviderAvailabilityInput <ICheckServiceProviderAvailabilityInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzPeeringServiceProviderAvailability -InputObject <IPeeringIdentity> [-PeeringServiceLocation <String>]
 [-PeeringServiceProvider <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzPeeringServiceProviderAvailability -InputObject <IPeeringIdentity>
 -CheckServiceProviderAvailabilityInput <ICheckServiceProviderAvailabilityInput> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks if the peering service provider is present within 1000 miles of customer's location

## EXAMPLES

### Example 1: Check if provider is available at a location
```powershell
$providerAvailability = New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
Test-AzPeeringServiceProviderAvailability -CheckServiceProviderAvailabilityInput $providerAvailability
```

```output
"Available"
```

Check whether the given provider is available at the given location

## PARAMETERS

### -CheckServiceProviderAvailabilityInput
Class for CheckServiceProviderAvailabilityInput
To construct, see NOTES section for CHECKSERVICEPROVIDERAVAILABILITYINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.ICheckServiceProviderAvailabilityInput
Parameter Sets: Check, CheckViaIdentity
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity
Parameter Sets: CheckViaIdentityExpanded, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PeeringServiceLocation
Gets or sets the peering service location.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringServiceProvider
Gets or sets the peering service provider.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, Check
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.ICheckServiceProviderAvailabilityInput

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
