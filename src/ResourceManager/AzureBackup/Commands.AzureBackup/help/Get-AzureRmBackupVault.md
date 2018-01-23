---
external help file: Microsoft.Azure.Commands.AzureBackup.dll-Help.xml
Module Name: AzureRM.Backup
ms.assetid: 95FF3F7A-5CC6-4AA6-A393-5EBB5579D9A2
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.backup/get-azurermbackupvault
schema: 2.0.0
---

# Get-AzureRmBackupVault

## SYNOPSIS
Gets Backup vaults.

## SYNTAX

```
Get-AzureRmBackupVault [[-ResourceGroupName] <String>] [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmBackupVault** cmdlet gets Azure Backup vaults.
This cmdlet returns **AzureRmBackupVault** objects for use with other cmdlets.

## EXAMPLES

### Example 1: View all the Backup vaults
```
PS C:\>Get-AzureRmBackupVault
```

This command gets all the Azure Backup vaults.

### Example 2: View all vaults created in West US
```
PS C:\>Get-AzureRmBackupVault | Where-Object { $_.Region -eq "westus" }
```

This command gets all the Backup vaults.
The command passes them to the Where-Object cmdlet by using the pipeline operator.
That cmdlet filters the results based on the **Region** property.
For more information, type `Get-Help Where-Object`.

### Example 3: Get a specific vault
```
PS C:\>Get-AzureRmBackupVault -Name "Vault03"
ResourceId        : /subscriptions/4bfbe168-f42a-4a06-8f5a-331cad1f497e/resourceGroups/ResourceGroup011/providers/Microsoft.Backup
                    /BackupVault/Vault
Name              : Vault03
ResourceGroupName : ResourceGroup01
Region            : westus
Storage           : GeoRedundant
```

This command gets the vault named Vault03.

### Example 4: Count the number of vaults that have locally redundant storage
```
PS C:\>Get-AzureRmBackupVault | Where-Object { $_.Storage -match "LocallyRedundant" } | Measure-Object
Count    : 4
Average  : 
Sum      : 
Maximum  : 
Minimum  : 
Property :
```

This command gets all the Azure Backup vaults.
The command passes them to **Where-Object**, which filters the results based on the **Storage** property.
The command passes the ones that have a value of LocallyRedundant to the Measure-Object cmdlet, which counts the results.
For more information, type `Get-Help Measure-Object`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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
Specifies the name of the Backup vault that this cmdlet gets.
If more than one Backup vault has the same name, this cmdlet returns them all.
Specify the *ResourceGroupName* parameter to get a unique vault.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of an Azure resource group in which this cmdlet gets a Backup vault.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### AzureRmBackupVault

## NOTES
* None

## RELATED LINKS

[Get-AzureRmBackupContainer](./Get-AzureRmBackupContainer.md)

[New-AzureRmBackupVault](./New-AzureRmBackupVault.md)

[Remove-AzureRmBackupVault](./Remove-AzureRmBackupVault.md)

[Set-AzureRmBackupVault](./Set-AzureRmBackupVault.md)


