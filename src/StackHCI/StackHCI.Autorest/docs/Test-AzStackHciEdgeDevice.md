---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/test-azstackhciedgedevice
schema: 2.0.0
---

# Test-AzStackHciEdgeDevice

## SYNOPSIS
A long-running resource action.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzStackHciEdgeDevice -Name <String> -ResourceUri <String> -EdgeDeviceId <String[]>
 [-AdditionalInfo <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Validate
```
Test-AzStackHciEdgeDevice -Name <String> -ResourceUri <String> -ValidateRequest <IValidateRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzStackHciEdgeDevice -InputObject <IStackHciIdentity> -ValidateRequest <IValidateRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzStackHciEdgeDevice -InputObject <IStackHciIdentity> -EdgeDeviceId <String[]> [-AdditionalInfo <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action.

## EXAMPLES

### Example 1:
```powershell
$ValidateRequest = @{
    edgeDeviceIds = @(
        "/subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>/edgeDevices/default",
        "/subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node2>/edgeDevices/default"
    )
    additionalInfo = "test"
}

Test-AzStackHciEdgeDevice -ResourceUri "subscriptions/<subId>/resourceGroups/<test-rg>/providers/Microsoft.HybridCompute/machines/<test-node>" -Name "default" -ValidateRequest $ValidateRequest
```

Tests the edge devices for the node

## PARAMETERS

### -AdditionalInfo
Additional info required for validation.

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

### -EdgeDeviceId
Node Ids against which, current node has to be validated.

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
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
Parameter Sets: Validate, ValidateExpanded
Aliases: EdgeDeviceName

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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

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

### -ValidateRequest
The validate request for Edge Device.
To construct, see NOTES section for VALIDATEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IValidateRequest
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20240401.IValidateRequest

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.IStackHciIdentity

## OUTPUTS

### System.String

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

`VALIDATEREQUEST <IValidateRequest>`: The validate request for Edge Device.
  - `EdgeDeviceId <String[]>`: Node Ids against which, current node has to be validated.
  - `[AdditionalInfo <String>]`: Additional info required for validation.

## RELATED LINKS

