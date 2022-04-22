---
external help file:
Module Name: Az.AgriFoodRpService
online version: https://docs.microsoft.com/en-us/powershell/module/az.agrifoodrpservice/get-azagrifoodrpservicefarmbeatsextension
schema: 2.0.0
---

# Get-AzAgriFoodRpServiceFarmBeatsExtension

## SYNOPSIS
Get farmBeats extension.

## SYNTAX

### List (Default)
```
Get-AzAgriFoodRpServiceFarmBeatsExtension [-ExtensionCategory <String[]>] [-FarmBeatsExtensionId <String[]>]
 [-FarmBeatsExtensionName <String[]>] [-MaxPageSize <Int32>] [-PublisherId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAgriFoodRpServiceFarmBeatsExtension -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAgriFoodRpServiceFarmBeatsExtension -InputObject <IAgriFoodRpServiceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get farmBeats extension.

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

### -ExtensionCategory
Extension categories.

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FarmBeatsExtensionId
FarmBeatsExtension ids.

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FarmBeatsExtensionName
FarmBeats extension names.

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
farmBeatsExtensionId to be queried.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FarmBeatsExtensionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AgriFoodRpService.Models.IAgriFoodRpServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaxPageSize
Maximum number of items needed (inclusive).
Minimum = 10, Maximum = 1000, Default value = 50.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherId
Publisher ids.

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AgriFoodRpService.Models.IAgriFoodRpServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AgriFoodRpService.Models.Api20200512Preview.IFarmBeatsExtension

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAgriFoodRpServiceIdentity>: Identity Parameter
  - `[ExtensionId <String>]`: Id of extension resource.
  - `[FarmBeatsExtensionId <String>]`: farmBeatsExtensionId to be queried.
  - `[FarmBeatsResourceName <String>]`: FarmBeats resource name.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

