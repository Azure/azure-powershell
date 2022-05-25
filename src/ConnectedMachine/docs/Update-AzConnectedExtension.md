---
external help file:
Module Name: Az.ConnectedMachine
online version: https://docs.microsoft.com/powershell/module/az.connectedmachine/update-azconnectedextension
schema: 2.0.0
---

# Update-AzConnectedExtension

## SYNOPSIS
The operation to Upgrade Machine Extensions.

## SYNTAX

### UpgradeExpanded (Default)
```
Update-AzConnectedExtension -MachineName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ExtensionTarget <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Upgrade
```
Update-AzConnectedExtension -MachineName <String> -ResourceGroupName <String>
 -ExtensionUpgradeParameter <IMachineExtensionUpgrade> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentity
```
Update-AzConnectedExtension -InputObject <IConnectedMachineIdentity>
 -ExtensionUpgradeParameter <IMachineExtensionUpgrade> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Update-AzConnectedExtension -InputObject <IConnectedMachineIdentity> [-ExtensionTarget <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to Upgrade Machine Extensions.

## EXAMPLES

### Example 1: Update an extension in a machine to a specific version
```powershell
$target = @{"Microsoft.Compute.CustomScriptExtension" = @{"targetVersion"="1.10.12"}}
Update-AzConnectedExtension -ResourceGroupName $env.ResourceGroupName -MachineName $machineName -ExtensionTarget $target
```

```output
<None>
```

Update an extension in a machine to a specific version

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

### -ExtensionTarget
Describes the Extension Target Properties.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionUpgradeParameter
Describes the Machine Extension Upgrade Properties
To construct, see NOTES section for EXTENSIONUPGRADEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IMachineExtensionUpgrade
Parameter Sets: Upgrade, UpgradeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: UpgradeViaIdentity, UpgradeViaIdentityExpanded
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
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded
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
Parameter Sets: Upgrade, UpgradeExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IMachineExtensionUpgrade

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


EXTENSIONUPGRADEPARAMETER <IMachineExtensionUpgrade>: Describes the Machine Extension Upgrade Properties
  - `[ExtensionTarget <IExtensionTarget>]`: Describes the Extension Target Properties.
    - `[(Any) <IExtensionTargetProperties>]`: This indicates any property can be added to this object.

INPUTOBJECT <IConnectedMachineIdentity>: Identity Parameter
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the target resource.
  - `[MachineName <String>]`: The name of the hybrid machine.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[PrivateLinkScopeId <String>]`: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScopeName <String>]`: The name of the Azure Arc PrivateLinkScope resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

