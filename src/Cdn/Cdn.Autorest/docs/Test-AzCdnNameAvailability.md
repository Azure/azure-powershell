---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/test-azcdnnameavailability
schema: 2.0.0
---

# Test-AzCdnNameAvailability

## SYNOPSIS
Check the availability of a resource name.
This is needed for resources where name is globally unique, such as a CDN endpoint.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzCdnNameAvailability -Name <String> -Type <ResourceType> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzCdnNameAvailability -CheckNameAvailabilityInput <ICheckNameAvailabilityInput>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check1
```
Test-AzCdnNameAvailability -CheckNameAvailabilityInput <ICheckNameAvailabilityInput>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckExpanded1
```
Test-AzCdnNameAvailability -Name <String> -Type <ResourceType> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check the availability of a resource name.
This is needed for resources where name is globally unique, such as a CDN endpoint.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CheckNameAvailabilityInput
Input of CheckNameAvailability API.
To construct, see NOTES section for CHECKNAMEAVAILABILITYINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.ICheckNameAvailabilityInput
Parameter Sets: Check, Check1
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

### -Name
The resource name to validate.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Check1, CheckExpanded1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the resource whose name is to be validated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ResourceType
Parameter Sets: CheckExpanded, CheckExpanded1
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.ICheckNameAvailabilityInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.ICheckNameAvailabilityOutput

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CHECKNAMEAVAILABILITYINPUT <ICheckNameAvailabilityInput>: Input of CheckNameAvailability API.
  - `Name <String>`: The resource name to validate.
  - `Type <ResourceType>`: The type of the resource whose name is to be validated.

## RELATED LINKS

