---
external help file:
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/test-azdigitaltwinsinstancenameavailability
schema: 2.0.0
---

# Test-AzDigitalTwinsInstanceNameAvailability

## SYNOPSIS
Check if a DigitalTwinsInstance name is available.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDigitalTwinsInstanceNameAvailability -Location <String> -Name <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzDigitalTwinsInstanceNameAvailability -InputObject <IDigitalTwinsIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check if a DigitalTwinsInstance name is available.

## EXAMPLES

### Example 1: Check if a DigitalTwinsInstance name is available.
```powershell
Test-AzDigitalTwinsInstanceNameAvailability -Location westus2 -Name testName
```

```output
Message                  NameAvailable Reason
-------                  ------------- ------
'testName' is available. True
```

Check if a DigitalTwinsInstance name is available.

### Example 2: Check if a DigitalTwinsInstance name is not available.
```powershell
Test-AzDigitalTwinsInstanceNameAvailability -Location westus2 -Name !testName
```

```output
Message                                                                                                                                NameAvailable Reason
-------                                                                                                                                ------------- ------
'!testName' must be between 3 and 63 characters. Alphanumerics and hyphens are allowed. Value must start and end with an alphanumeric. False         Invalid
```

Check if a DigitalTwinsInstance name is not available.

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Location of DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name.

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

### -SubscriptionId
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.ICheckNameResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDigitalTwinsIdentity>`: Identity Parameter
  - `[EndpointName <String>]`: Name of Endpoint Resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Location of DigitalTwinsInstance.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the DigitalTwinsInstance.
  - `[ResourceId <String>]`: The name of the private link resource.
  - `[ResourceName <String>]`: The name of the DigitalTwinsInstance.
  - `[SubscriptionId <String>]`: The subscription identifier.
  - `[TimeSeriesDatabaseConnectionName <String>]`: Name of time series database connection.

## RELATED LINKS

