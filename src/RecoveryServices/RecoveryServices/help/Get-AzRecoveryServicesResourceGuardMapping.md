---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version:
schema: 2.0.0
---

# Get-AzRecoveryServicesResourceGuardMapping

## SYNOPSIS
Gets the resource guard mapping added to the recovery services vault.

## SYNTAX

```
Get-AzRecoveryServicesResourceGuardMapping [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the resource guard mapping added to the recovery services vault. This cmdlet fetches the mapping between the recovery services vault and resource guard

## EXAMPLES

### Example 1 Fetch the resource guard mapping

```powershell
Get-AzRecoveryServicesResourceGuardMapping -VaultId $vault.ID
```

The above command fetches the existing mapping between the vault and the resource guard.

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

### -VaultId
ARM ID of the Recovery Services Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.RecoveryServices.Backup.Models.ResourceGuardProxyBaseResource

## NOTES

## RELATED LINKS
