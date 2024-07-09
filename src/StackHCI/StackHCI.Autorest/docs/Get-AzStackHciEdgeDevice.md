---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/get-azstackhciedgedevice
schema: 2.0.0
---

# Get-AzStackHciEdgeDevice

## SYNOPSIS
Get a EdgeDevice

## SYNTAX

### List (Default)
```
Get-AzStackHciEdgeDevice -ResourceUri <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStackHciEdgeDevice -Name <String> -ResourceUri <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStackHciEdgeDevice -InputObject <IStackHciIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a EdgeDevice

## EXAMPLES

### Example 1:
```powershell
Get-AzStackHciEdgeDevice -ResourceUri "subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>"
```

```output
Kind    Name
----    ----
HCI     default
```

Gets the Edge Device

## PARAMETERS

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
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Device

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EdgeDeviceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IEdgeDevice

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IStackHciIdentity>`: Identity Parameter
  - `[ArcSettingName <String>]`: The name of the proxy resource holding details of HCI ArcSetting information.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[DeploymentSettingsName <String>]`: Name of Deployment Setting
  - `[EdgeDeviceName <String>]`: Name of Device
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the resource.
  - `[SecuritySettingsName <String>]`: Name of security setting
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[UpdateName <String>]`: The name of the Update
  - `[UpdateRunName <String>]`: The name of the Update Run

## RELATED LINKS

