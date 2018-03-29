---
external help file: Microsoft.Azure.Commands.RecoveryServices.Backup.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.recoveryservices.backup/get-azurermrecoveryservicesbackupstatus
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesBackupStatus

## SYNOPSIS
Checks whether your ARM resource is backed up or not.

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
The command returns null/empty if the specified resource is not protected under any Recovery Services vault in the subscription. 
If it is protected, the relevant vault details will be returned.

## EXAMPLES

### Example 1
```
PS C:\> Example Code
```

Example DESCRIPTION

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
Name of the ARM resource to be checked.

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
Resource group of the ARM resource to be checked.

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
The relevant ID of the ARM resource.

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
The type of the ARM resource which Azure Recovery Services vault can protect. 
Acceptable values: Microsoft.Compute/virtualMachines, Microsoft.ClassicCompute/virtualMachines.

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

