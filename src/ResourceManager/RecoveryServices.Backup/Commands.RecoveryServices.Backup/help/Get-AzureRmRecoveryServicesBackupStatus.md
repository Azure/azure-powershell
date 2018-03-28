---
external help file: Microsoft.Azure.Commands.RecoveryServices.Backup.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesBackupStatus

## SYNOPSIS
This cmdlet can be used to check if a VM is backed up by any vault in the subscription.

## SYNTAX

### Name
```
Get-AzureRmRecoveryServicesBackupStatus [-Name <String>] [-ResourceGroupName <String>] [-Type <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

### Id
```
Get-AzureRmRecoveryServicesBackupStatus [-ResourceId <String>] [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
This cmdlet can be used to check if a VM is backed up by any vault in the subscription.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
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

Required: False
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

Required: False
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

Required: False
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.RecoveryServices.ARSVault, Microsoft.Azure.Commands.RecoveryServices.ARM, Version=4.1.1.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

