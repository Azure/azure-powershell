---
external help file: Az.FirmwareAnalysis-help.xml
Module Name: Az.FirmwareAnalysis
online version: https://learn.microsoft.com/powershell/module/az.firmwareanalysis/remove-azfirmwareanalysisfirmware
schema: 2.0.0
---

# Remove-AzFirmwareAnalysisFirmware

## SYNOPSIS
The operation to delete a firmware.

## SYNTAX

### Delete (Default)
```
Remove-AzFirmwareAnalysisFirmware -Id <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityWorkspace
```
Remove-AzFirmwareAnalysisFirmware -Id <String> -WorkspaceInputObject <IFirmwareAnalysisIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzFirmwareAnalysisFirmware -InputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to delete a firmware.

## EXAMPLES

### Example 1: Delete a firmware analysis workspace.
```powershell
Remove-AzFirmwareAnalysisFirmware -Id firmwareId -ResourceGroupName resourceGroupName -WorkspaceName workspaceName
```

Delete a firmware analysis workspace.

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

### -Id
The id of the firmware.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteViaIdentityWorkspace
Aliases: FirmwareId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: DeleteViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the firmware analysis workspace.

```yaml
Type: System.String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
