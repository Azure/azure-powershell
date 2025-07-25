---
external help file: Az.FirmwareAnalysis-help.xml
Module Name: Az.FirmwareAnalysis
online version: https://learn.microsoft.com/powershell/module/az.firmwareanalysis/update-azfirmwareanalysisfirmware
schema: 2.0.0
---

# Update-AzFirmwareAnalysisFirmware

## SYNOPSIS
The operation to Update firmware.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFirmwareAnalysisFirmware -Id <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> [-Description <String>] [-FileName <String>] [-FileSize <Int64>] [-Model <String>]
 [-Status <String>] [-StatusMessage <IStatusMessage[]>] [-Vendor <String>] [-Version <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityWorkspaceExpanded
```
Update-AzFirmwareAnalysisFirmware -Id <String> -WorkspaceInputObject <IFirmwareAnalysisIdentity>
 [-Description <String>] [-FileName <String>] [-FileSize <Int64>] [-Model <String>] [-Status <String>]
 [-StatusMessage <IStatusMessage[]>] [-Vendor <String>] [-Version <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFirmwareAnalysisFirmware -InputObject <IFirmwareAnalysisIdentity> [-Description <String>]
 [-FileName <String>] [-FileSize <Int64>] [-Model <String>] [-Status <String>]
 [-StatusMessage <IStatusMessage[]>] [-Vendor <String>] [-Version <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to Update firmware.

## EXAMPLES

### Example 1: Update a firmware.
```powershell
Update-AzFirmwareAnalysisFirmware -FirmwareId firmwareId -ResourceGroupName resourceGroupName -WorkspaceName workspaceName -Description description -FileSize 1  -FileName fileName -Vendor vendor -Model model -Version version
```

```output
Description                  : description
FileName                     : FileName
FileSize                     : 1
Id                           : 
Model                        : model
Name                         : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState            : 
ResourceGroupName            : 
Status                       :
StatusMessage                :
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : microsoft.iotfirmwaredefense/workspaces/firmwares
Vendor                       : vendor
Version                      : version
```

Update a firmware.

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

### -Description
User-specified description of the firmware.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileName
File name for a firmware that user uploaded.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSize
File size of the uploaded firmware image.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Model
Firmware model.

```yaml
Type: System.String
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The status of firmware scan.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusMessage
A list of errors or other messages generated during firmware analysis

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IStatusMessage[]
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vendor
Firmware vendor.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Firmware version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity
Parameter Sets: UpdateViaIdentityWorkspaceExpanded
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
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmware

## NOTES

## RELATED LINKS
