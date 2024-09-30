---
external help file:
Module Name: Az.FirmwareAnalysis
online version: https://learn.microsoft.com/powershell/module/az.firmwareanalysis/get-azfirmwareanalysisworkspace
schema: 2.0.0
---

# Get-AzFirmwareAnalysisWorkspace

## SYNOPSIS
Get firmware analysis workspace.

## SYNTAX

### List (Default)
```
Get-AzFirmwareAnalysisWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFirmwareAnalysisWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFirmwareAnalysisWorkspace -InputObject <IFirmwareAnalysisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzFirmwareAnalysisWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get firmware analysis workspace.

## EXAMPLES

### Example 1: List all firmware analysis workspaces in the specified subscription.
```powershell
Get-AzFirmwareAnalysisWorkspace -ResourceGroupName ResourceGroupName
```

```output
Id                           : 
Location                     : 
Name                         : 
ProvisioningState            : 
ResourceGroupName            : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {}
Type                         : microsoft.iotfirmwaredefense/workspaces
```

List all firmware analysis workspaces in the specified subscription.

### Example 2: Get firmware analysis workspace from the specified subscription.
```powershell
Get-AzFirmwareAnalysisWorkspace -ResourceGroupName ResourceGroupName -WorkspaceName WorkspaceName
```

```output
Id                           : 
Location                     : 
Name                         : 
ProvisioningState            : 
ResourceGroupName            : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Tag                          : {}
Type                         : microsoft.iotfirmwaredefense/workspaces
```

Get firmware analysis workspace from the specified subscription.

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

### -Name
The name of the firmware analysis workspace.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

Required: True
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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IFirmwareAnalysisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FirmwareAnalysis.Models.IWorkspace

## NOTES

## RELATED LINKS

