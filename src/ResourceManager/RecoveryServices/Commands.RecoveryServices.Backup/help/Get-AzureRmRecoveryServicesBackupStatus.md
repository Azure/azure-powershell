---
external help file: Microsoft.Azure.Commands.RecoveryServices.Backup.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesBackupStatus

## SYNOPSIS
Checks whether your ARM resource is backed up or not.

## SYNTAX

### Name (Default)
```
Get-AzureRmRecoveryServicesBackupStatus -Name <String> -ResourceGroupName <String> -Type <String>
 [-DefaultProfile <IAzureContextContainer>]
```

### Id
```
Get-AzureRmRecoveryServicesBackupStatus -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The command returns null/empty if the specified resource is not protected under any Recovery Services vault in the subscription. 
If it is protected, the relevant vault details will be returned.

## EXAMPLES

### Example 1
```
PS C:\> $isVMBackedUp = Get-AzureRmRecoveryServicesBackupStatus -Name “myAzureVM” -ResourceGroupName “myAzureVMRG” -ResourceType “AzureVM”
PS C:\> If ($isVMBackedUp -eq “”) {
Get-AzureRmRecoveryServicesVault -Name "testvault"  -ResourceGroupName "vaultResourceGroup" | Set-AzureRmRecoveryServicesVaultContext
$defPolicy = Get-AzureRmRecoveryServicesBackupProtectionPolicy -WorkloadType "AzureVM"
Enable-AzureRmRecoveryServicesBackupProtection -Policy $defpol -Name "myAzureVM" -ResourceGroupName "myAzureVMRG"
}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Azure Resource whose representative item needs to be checked if it is already protected by some Recovery Services Vault in the subscription.

```yaml
Type: String
Parameter Sets: Name
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group of the Azure Resource whose representative item needs to be checked if it is already protected by some RecoveryServices Vault in the subscription.

```yaml
Type: String
Parameter Sets: Name
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the Azure Resource whose representative item needs to be checked if it is already protected by some RecoveryServices Vault in the subscription.

```yaml
Type: String
Parameter Sets: Id
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Type
Name of the Azure Resource whose representative item needs to be checked if it is already protected by some Recovery Services Vault in the subscription.

```yaml
Type: String
Parameter Sets: Name
Aliases: 
Accepted values: AzureVM

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.String


## NOTES

## RELATED LINKS

