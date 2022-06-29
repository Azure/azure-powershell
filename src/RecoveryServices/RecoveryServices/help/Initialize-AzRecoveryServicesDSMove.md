---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/initialize-azrecoveryservicesdsmove
schema: 2.0.0
---

# Initialize-AzRecoveryServicesDSMove

## SYNOPSIS
Initializes DS move for Copy-AzRecoveryServicesVault.

## SYNTAX

```
Initialize-AzRecoveryServicesDSMove [-DefaultProfile <IAzureContextContainer>] [-SourceVault] <ARSVault>
 [-TargetVault] <ARSVault> [-RetryOnlyFailed] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Initializes DS move for Copy-AzRecoveryServicesVault. It is mandatory to run Test-AzRecoveryServicesDSMove 
cmdlet before this cmdlet. This cmdlet generates a Correlation Id which can be used as Input to 
Copy-AzRecoveryServicesVault cmdlet. This cmdlet is useful for cross tenant DS move scenario. 

## EXAMPLES

### Example 1: Initialize DS Move for cross subscription copy
```powershell
Set-AzContext -SubscriptionName $targetSubscription
$validated = Test-AzRecoveryServicesDSMove -SourceVault $srcVault -TargetVault $trgVault -Force
Set-AzContext -SubscriptionName $sourceSubscription
if($validated) {
  $corr = Initialize-AzRecoveryServicesDSMove  -SourceVault $srcVault -TargetVault $trgVault
 }
```

First cmdlet sets target subscription context. 
Second cmdlet triggers some mandatory validations on target vault.
Third cmdlet sets source subscription context.
Then based on Test-AzRecoveryServicesDSMove cmdlet state, we fetch CorrelationId using
Initialize-AzRecoveryServicesDSMove cmdlet. $corr can be input to the Copy cmdlet.

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

### -RetryOnlyFailed
Switch parameter to try data move only for containers in the source vault which are not yet moved.

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

### -SourceVault
The source vault object to trigger data move.

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

### Microsoft.Azure.Commands.RecoveryServices.ARSVault

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
