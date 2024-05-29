---
external help file: Az.DiagnosticSetting.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azdiagnosticsetting
schema: 2.0.0
---

# Get-AzDiagnosticSetting

## SYNOPSIS
Gets the active diagnostic settings for the specified resource.

## SYNTAX

### List (Default)
```
Get-AzDiagnosticSetting -ResourceId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDiagnosticSetting -Name <String> -ResourceId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiagnosticSetting -InputObject <IDiagnosticSettingIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the active diagnostic settings for the specified resource.

## EXAMPLES

### Example 1: List diagnostic settings
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
Get-AzDiagnosticSetting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001
```

List diagnostic settings for resource

### Example 2: Get diagnostic setting by name
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
Get-AzDiagnosticSetting -ResourceId /subscriptions/$subscriptionId/resourceGroups/test-rg-name/providers/Microsoft.AppPlatform/Spring/springcloud-001 -Name test-setting
```

Get diagnostic settings under resource by name

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.IDiagnosticSettingIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the diagnostic setting.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.IDiagnosticSettingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DiagnosticSetting.Models.Api20210501Preview.IDiagnosticSettingsResource

## NOTES

## RELATED LINKS
