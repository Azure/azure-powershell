---
external help file:
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.servicelinker/new-azservicelinkerconnectorconfiguration
schema: 2.0.0
---

# New-AzServiceLinkerConnectorConfiguration

## SYNOPSIS
Generate configurations for a Connector.

## SYNTAX

### GenerateExpanded (Default)
```
New-AzServiceLinkerConnectorConfiguration -ConnectorName <String> -Location <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Action <ActionType>]
 [-AdditionalConfiguration <Hashtable>] [-CustomizedKey <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Generate
```
New-AzServiceLinkerConnectorConfiguration -ConnectorName <String> -Location <String>
 -ResourceGroupName <String> -Parameter <IConfigurationInfo> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzServiceLinkerConnectorConfiguration -InputObject <IServiceLinkerIdentity>
 -Parameter <IConfigurationInfo> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentityExpanded
```
New-AzServiceLinkerConnectorConfiguration -InputObject <IServiceLinkerIdentity> [-Action <ActionType>]
 [-AdditionalConfiguration <Hashtable>] [-CustomizedKey <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Generate configurations for a Connector.

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

### -Action
Optional, indicate whether to apply configurations on source application.
If enable, generate configurations and applied to the source application.
Default is enable.
If optOut, no configuration change will be made on source.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.ActionType
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdditionalConfiguration
A dictionary of additional configurations to be added.
Service will auto generate a set of basic configurations and this property is to full fill more customized configurations

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectorName
The name of resource.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomizedKey
Optional.
A dictionary of default key name and customized key name mapping.
If not specified, default key name will be used for generate configurations

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IServiceLinkerIdentity
Parameter Sets: GenerateViaIdentity, GenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of Azure region.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The configuration information, used to generate configurations or save to applications
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.IConfigurationInfo
Parameter Sets: Generate, GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
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
Type: System.String
Parameter Sets: Generate, GenerateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.IConfigurationInfo

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IServiceLinkerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.ISourceConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IServiceLinkerIdentity>`: Identity Parameter
  - `[ConnectorName <String>]`: The name of resource.
  - `[DryrunName <String>]`: The name of dryrun.
  - `[Id <String>]`: Resource identity path
  - `[LinkerName <String>]`: The name Linker resource.
  - `[Location <String>]`: The name of Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the resource to be connected.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`PARAMETER <IConfigurationInfo>`: The configuration information, used to generate configurations or save to applications
  - `[Action <ActionType?>]`: Optional, indicate whether to apply configurations on source application. If enable, generate configurations and applied to the source application. Default is enable. If optOut, no configuration change will be made on source.
  - `[AdditionalConfiguration <IConfigurationInfoAdditionalConfigurations>]`: A dictionary of additional configurations to be added. Service will auto generate a set of basic configurations and this property is to full fill more customized configurations
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[CustomizedKey <IConfigurationInfoCustomizedKeys>]`: Optional. A dictionary of default key name and customized key name mapping. If not specified, default key name will be used for generate configurations
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[DeleteOrUpdateBehavior <DeleteOrUpdateBehavior?>]`: Indicates whether to clean up previous operation when Linker is updating or deleting

## RELATED LINKS

