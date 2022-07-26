---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://docs.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilesexportpolicyobject
schema: 2.0.0
---

# New-AzNetAppFilesExportPolicyObject

## SYNOPSIS
Creates export policy object.

## SYNTAX

```
New-AzNetAppFilesExportPolicyObject -Rule <PSNetAppFilesExportPolicyRule[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
New-AzNetAppFilesExportPolicyObject is a helper cmdlet that creates an export policy object that can be used with New-AzNetAppFilesVolume.
Each ExportPolicy object consists of a set of ExportPolicy rules that can be applied to an ANF volume. 

## EXAMPLES

### Example 1
```powershell
$exportPolicyRule = New-AzNetAppFilesExportPolicyRuleObject -RuleIndex 1 -AllowedClient '0.0.0.0/0' -UnixReadOnly -UnixReadWrite -Cifs -Nfsv3 
$exportPolicyRules = $($exportPolicyRule)
$newExportPolicy = New-AzNetAppFilesExportPolicyObject -Rule $exportPolicyRules
New-AzNetAppFilesVolume -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -Name "MyAnfVolume" -Location "westus2" -CreationToken "MyAnfVolume" -UsageThreshold 1099511627776 -ServiceLevel "Premium" -SubnetId "/subscriptions/subsId/resourceGroups/MyRG/providers/Microsoft.Network/virtualNetworks/MyVnetName/subnets/MySubNetName" -ExportPolicy $newExportPolicy
```

This example creates an ExportPolicyRule in variable $exportPolicyRule, sets it an export policy object  $exportPolicyRules that is then used in the creation of an AFN volume "MyAnfVolume""

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
List of items which need to be included into endpont scope.

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesExportPolicyRule[]
Parameter Sets: (All)
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeExportPolicy

## NOTES

## RELATED LINKS

[Get-AzNetAppFilesVolume](./Get-AzNetAppFilesVolume.md)
[New-AzNetAppFilesVolume](./New-AzNetAppFilesVolume.md)
[Update-AzNetAppFilesVolume](./Update-AzNetAppFilesVolume.md)
[Remove-AzNetAppFilesVolume](./Remove-AzNetAppFilesVolume.md)