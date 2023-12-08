---
external help file:
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicespolicytemplate
schema: 2.0.0
---

# Get-AzRecoveryServicesPolicyTemplate

## SYNOPSIS
Gets default policy template for a selected datasource type.

## SYNTAX

```
Get-AzRecoveryServicesPolicyTemplate -DatasourceType <DatasourceTypes> [<CommonParameters>]
```

## DESCRIPTION
Gets default policy template for a selected datasource type.

## EXAMPLES

### Example 1: Get the default policy client object for creating AzureVM policy
```powershell
$vmPol= Get-AzRecoveryServicesPolicyTemplate -DatasourceType AzureVM
```

This command is used to get default values for a VM policy.
This object can further be used for editing any attributes in the policy client object either manually or using the Edit-AzRecoveryServicesBackupSchedulePolicyClientObject, Edit-AzRecoveryServicesBackupRetentionPolicyClientObject cmdlets.
After changing the values as per need, $vmPol object can further be used to create policy using New-AzRecoveryServicesBackupProtectionPolicy command.

### Example 2: Get the default policy client object for creating MSSQL policy
```powershell
$sqlPol= Get-AzRecoveryServicesPolicyTemplate -DatasourceType MSSQL
```

This command is used to get default policy client object for datasourcetype MSSQL.

### Example 3: Get the default policy client object for creating SAPHANA policy
```powershell
$sqlPol= Get-AzRecoveryServicesPolicyTemplate -DatasourceType SAPHANA
```

This command is used to get default policy client object for datasourcetype SAPHANA.

## PARAMETERS

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ProtectionPolicy

## NOTES

## RELATED LINKS

