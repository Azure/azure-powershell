---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/copy-azrecoveryservicesvault
schema: 2.0.0
---

# Copy-AzRecoveryServicesVault

## SYNOPSIS
Copies data from a vault in one region to a vault in another region.

## SYNTAX

### AzureRSVaultDataMoveParameterSet (Default)
```
Copy-AzRecoveryServicesVault [-Force] [-DefaultProfile <IAzureContextContainer>] [-SourceVault] <ARSVault>
 [-TargetVault] <ARSVault> [-RetryOnlyFailed] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureRSVaultTriggerMoveParameterSet
```
Copy-AzRecoveryServicesVault [-Force] -CorrelationIdForDataMove <String>
 [-DefaultProfile <IAzureContextContainer>] [-SourceVault] <ARSVault> [-TargetVault] <ARSVault> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Copy-AzRecoveryServicesVault** cmdlet copies data from a vault in one region to a vault in another region. Currently we only support vault level data move.

## EXAMPLES

### Example 1: Copy data from vault1 to vault2

```powershell
$sourceVault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName1" -Name "vault1"
$targetVault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName2" -Name "vault2"
Copy-AzRecoveryServicesVault -SourceVault $sourceVault -TargetVault $targetVault
```

The first two cmdlets fetch Recovery Services Vault - vault1 and vault2 respectively. The second command triggers a complete data move from vault1 to vault2. 
$sourceVault and $targetVault can also belong to different subscription within same tenant, can be fetched by setting different subscription contexts.

### Example 2: Copy data from vault1 to vault2 with only failed items

```powershell
$sourceVault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName1" -Name "vault1"
$targetVault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName2" -Name "vault2"
Copy-AzRecoveryServicesVault -SourceVault $sourceVault -TargetVault $targetVault -RetryOnlyFailed
```

The first two cmdlets fetch Recovery Services Vault - vault1 and vault2 respectively.
The second command triggers a partial data move from vault1 to vault2 with only those items which failed in previous move operations.
$sourceVault and $targetVault can also belong to different subscription within same tenant, can be fetched by setting different subscription contexts.

## PARAMETERS

### -CorrelationIdForDataMove
Correlation Id for triggering DS Move.

```yaml
Type: System.String
Parameter Sets: AzureRSVaultTriggerMoveParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Forces the data move operation (prevents confirmation dialog) without asking confirmation for target vault storage redundancy type. This parameter is optional. 

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

### -RetryOnlyFailed
Switch parameter to try data move only for containers in the source vault which are not yet moved.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureRSVaultDataMoveParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceVault
The source vault object to be moved.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.ARSVault
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TargetVault
The target vault object where the data has to be moved.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.ARSVault
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.RecoveryServices.ARSVault

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
