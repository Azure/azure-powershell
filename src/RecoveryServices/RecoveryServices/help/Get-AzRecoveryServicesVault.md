<<<<<<< HEAD
﻿---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: 818B5302-91EE-425F-B1CD-86B626F1B7A3
online version: https://docs.microsoft.com/en-us/powershell/module/az.recoveryservices/get-azrecoveryservicesvault
=======
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: 818B5302-91EE-425F-B1CD-86B626F1B7A3
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesvault
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzRecoveryServicesVault

## SYNOPSIS

Gets a list of Recovery Services vaults.

## SYNTAX

<<<<<<< HEAD
```
Get-AzRecoveryServicesVault [-ResourceGroupName <String>] [-Name <String>]
=======
### ByTagNameValueParameterSet
```
Get-AzRecoveryServicesVault [[-ResourceGroupName] <String>] [[-Name] <String>] [-TagName <String>]
 [-TagValue <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByTagObjectParameterSet
```
Get-AzRecoveryServicesVault [[-ResourceGroupName] <String>] [[-Name] <String>] -Tag <Hashtable>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

The **Get-AzRecoveryServicesVault** cmdlet gets a list of Recovery Services vaults in the current subscription.

## EXAMPLES

### Example 1

<<<<<<< HEAD
```powershell
=======
```
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\> Get-AzRecoveryServicesVault
```

Get the list of vault in selected subscription.

### Example 2

<<<<<<< HEAD
```powershell
=======
```
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
PS C:\> Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup"
```

Get the list of vault in resource group in selected subscription.

### Example 3

<<<<<<< HEAD
```powershell
PS C:\> Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
```

Get the vault in resource group with given name.
=======
```
PS C:\> $vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
PS C:\> $vault.Identity | fl

PrincipalId : XXXXXXXX-XXXX-XXXX
TenantId    : XXXXXXXX-XXXX-XXXX
Type        : SystemAssigned
```

The first cmdlet gets the vault in resource group with given name. Then we access the MSI information from the vault.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## PARAMETERS

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name

Specifies the name of the vault to query for.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
<<<<<<< HEAD
Position: Named
=======
Position: 2
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName

Specifies the name of the Azure resource group from which to retrieve the specified Recovery Services object.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
<<<<<<< HEAD
=======
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag

Specifies the Tags to query for

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ByTagObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagName

Specifies the Key of the Tag to query for

```yaml
Type: System.String
Parameter Sets: ByTagNameValueParameterSet
Aliases:

Required: False
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

<<<<<<< HEAD
### -CommonParameters

=======
### -TagValue

Specifies the Value of the Tag to query for

```yaml
Type: System.String
Parameter Sets: ByTagNameValueParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.ARSVault

## NOTES
<<<<<<< HEAD
=======
Get-AzRecoveryServicesVault in old version of Az.RecoveryServices(<=2.10.0) cannot work with Az.Accounts(>=1.8.1) because of incorrect assembly reference. The module Az.RecoveryServices needs to be upgraded to 2.11.0 or newer if you are using the latest Az or Az.Accounts.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## RELATED LINKS

[Get-AzRecoveryServicesVaultSettingsFile](./Get-AzRecoveryServicesVaultSettingsFile.md)

[New-AzRecoveryServicesVault](./New-AzRecoveryServicesVault.md)

[Remove-AzRecoveryServicesVault](./Remove-AzRecoveryServicesVault.md)
