---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/remove-azconnectedmachineruncommand
schema: 2.0.0
---

# Remove-AzConnectedMachineRunCommand

## SYNOPSIS
The operation to delete a run command.

## SYNTAX

### Delete (Default)
```
Remove-AzConnectedMachineRunCommand -MachineName <String> -ResourceGroupName <String> -RunCommandName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentityMachine
```
Remove-AzConnectedMachineRunCommand -RunCommandName <String> -MachineInputObject <IConnectedMachineIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzConnectedMachineRunCommand -InputObject <IConnectedMachineIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to delete a run command.

## EXAMPLES

### EXAMPLE 1
```
Remove-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -RunCommandName "myRunCommand3" -MachineName "testmachine"
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
Type: IConnectedMachineIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineInputObject
Identity Parameter
To construct, see NOTES section for MACHINEINPUTOBJECT properties and create a hash table.

```yaml
Type: IConnectedMachineIdentity
Parameter Sets: DeleteViaIdentityMachine
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineName
The name of the hybrid machine.

```yaml
Type: String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunCommandName
The name of the run command.

```yaml
Type: String
Parameter Sets: Delete, DeleteViaIdentityMachine
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
Type: String
Parameter Sets: Delete
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
## OUTPUTS

### System.Boolean
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IConnectedMachineIdentity\>: Identity Parameter
  \[ExtensionName \<String\>\]: The name of the machine extension.
  \[ExtensionType \<String\>\]: The extensionType of the Extension being received.
  \[GroupName \<String\>\]: The name of the private link resource.
  \[Id \<String\>\]: Resource identity path
  \[LicenseName \<String\>\]: The name of the license.
  \[LicenseProfileName \<String\>\]: The name of the license profile.
  \[Location \<String\>\]: The location of the Extension being received.
  \[MachineName \<String\>\]: The name of the hybrid machine.
  \[MetadataName \<String\>\]: Name of the HybridIdentityMetadata.
  \[Name \<String\>\]: The name of the hybrid machine.
  \[OSType \<String\>\]: Defines the os type.
  \[PerimeterName \<String\>\]: The name, in the format {perimeterGuid}.{associationName}, of the Network Security Perimeter resource.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection.
  \[PrivateLinkScopeId \<String\>\]: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  \[Publisher \<String\>\]: The publisher of the Extension being received.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceUri \<String\>\]: The fully qualified Azure Resource manager identifier of the resource to be connected.
  \[RunCommandName \<String\>\]: The name of the run command.
  \[ScopeName \<String\>\]: The name of the Azure Arc PrivateLinkScope resource.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Version \<String\>\]: The version of the Extension being received.

MACHINEINPUTOBJECT \<IConnectedMachineIdentity\>: Identity Parameter
  \[ExtensionName \<String\>\]: The name of the machine extension.
  \[ExtensionType \<String\>\]: The extensionType of the Extension being received.
  \[GroupName \<String\>\]: The name of the private link resource.
  \[Id \<String\>\]: Resource identity path
  \[LicenseName \<String\>\]: The name of the license.
  \[LicenseProfileName \<String\>\]: The name of the license profile.
  \[Location \<String\>\]: The location of the Extension being received.
  \[MachineName \<String\>\]: The name of the hybrid machine.
  \[MetadataName \<String\>\]: Name of the HybridIdentityMetadata.
  \[Name \<String\>\]: The name of the hybrid machine.
  \[OSType \<String\>\]: Defines the os type.
  \[PerimeterName \<String\>\]: The name, in the format {perimeterGuid}.{associationName}, of the Network Security Perimeter resource.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection.
  \[PrivateLinkScopeId \<String\>\]: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  \[Publisher \<String\>\]: The publisher of the Extension being received.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ResourceUri \<String\>\]: The fully qualified Azure Resource manager identifier of the resource to be connected.
  \[RunCommandName \<String\>\]: The name of the run command.
  \[ScopeName \<String\>\]: The name of the Azure Arc PrivateLinkScope resource.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[Version \<String\>\]: The version of the Extension being received.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.connectedmachine/remove-azconnectedmachineruncommand](https://learn.microsoft.com/powershell/module/az.connectedmachine/remove-azconnectedmachineruncommand)

