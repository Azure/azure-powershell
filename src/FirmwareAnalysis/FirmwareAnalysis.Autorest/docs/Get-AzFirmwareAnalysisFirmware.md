---
external help file:
Module Name: Az.FirmwareAnalysis
online version: https://learn.microsoft.com/powershell/module/az.firmwareanalysis/get-azfirmwareanalysisfirmware
schema: 2.0.0
---

# Get-AzFirmwareAnalysisFirmware

## SYNOPSIS
Get firmware.

## SYNTAX

### Get (Default)
```
Get-AzFirmwareAnalysisFirmware -ResourceGroupName <String> -WorkspaceName <String> [-Id <String>]
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFirmwareAnalysisFirmware -InputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzFirmwareAnalysisFirmware -WorkspaceInputObject <IFirmwareAnalysisIdentity> [-Id <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzFirmwareAnalysisFirmware -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get firmware.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases: FirmwareId

Required: False
Position: Named
Default value: str(uuid.uuid4())
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: GetViaIdentityWorkspace
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

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmware

## NOTES

## RELATED LINKS

