---
external help file: Microsoft.Azure.Commands.AzureBackup.dll-Help.xml
Module Name: AzureRM.Backup
ms.assetid: 394500DB-D2BB-4793-8D9F-2CAF4D892A55
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.backup/register-azurermbackupcontainer
schema: 2.0.0
---

# Register-AzureRmBackupContainer

## SYNOPSIS
Registers the container with a Backup vault.

## SYNTAX

### V1VM
```
Register-AzureRmBackupContainer -Name <String> -ServiceName <String> [-Vault] <AzureRMBackupVault>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### V2VM
```
Register-AzureRmBackupContainer -Name <String> -ResourceGroupName <String> [-Vault] <AzureRMBackupVault>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Register-AzureRmBackupContainer** cmdlet registers the container with an Azure Backup vault.
To configure backup by using Azure Backup, first register your server or virtual machine with a Backup vault.
This cmdlet registers an infrastructure as a service (IaaS) virtual machine with the specified vault.
The register operation associates the Azure virtual machine with the backup vault and tracks the virtual machine through the backup life cycle.

## EXAMPLES

### Example 1: Register a virtual machine to a Backup vault
```
PS C:\>$Vault = Get-AzureRmBackupVault -Name "Vault03"
PS C:\> Register-AzureRmBackupContainer -Vault $Vault -Name "Contoso03Vm" -ServiceName "ContosoService27"
```

The first command gets the vault named Vault03 by using the Get-AzureRmBackupVault cmdlet.
The command stores the vault in the $Vault variable.

The second command registers the virtual machine named Contoso03Vm with the vault in $Vault.
That virtual machine belongs to the service named ContosoService27.

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
Specifies the name of the virtual machine that this cmdlet registers.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group for the virtual machine.

```yaml
Type: String
Parameter Sets: V2VM
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
Specifies the service name of the virtual machine that this cmdlet registers.

Typically, a cloud service name has a suffix .cloudapp.net.
Do not include the suffix when you specify this parameter.

To obtain information about a virtual machine, use the Get-AzureRMVM cmdlet.
The service name is the **DeploymentName** property of the virtual machine object.

```yaml
Type: String
Parameter Sets: V1VM
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Vault
Specifies the Backup vault to which this cmdlet registers virtual machine.
To obtain an **AzureRmBackupVault** object, use the Get-AzureRmBackupVault cmdlet.

```yaml
Type: AzureRMBackupVault
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### AzureRmBackupVault

## OUTPUTS

### AzureRmBackupJob

## NOTES

## RELATED LINKS

[Get-AzureRmBackupVault](./Get-AzureRmBackupVault.md)


