---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/Az.ServiceBus/new-AzServiceBusKeyVaultPropertiesObject
schema: 2.0.0
---

# New-AzServiceBusKeyVaultPropertiesObject

## SYNOPSIS
Create an in-memory object for KeyVaultProperties.

## SYNTAX

```
New-AzServiceBusKeyVaultPropertiesObject [-KeyName <String>] [-KeyVaultUri <String>] [-KeyVersion <String>]
 [-UserAssignedIdentity <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeyVaultProperties.

## EXAMPLES

### Example 1: Construct an in-memory KeyVaultProperties object
```powershell
New-AzServiceBusKeyVaultPropertiesObject -KeyName key1 -KeyVaultUri https://testkeyvault.vault.azure.net/
```

```Output
KeyName KeyVaultUri                            KeyVersion UserAssignedIdentity
------- -----------                            ---------- --------------------
key4    https://testkeyvault.vault.azure.net/
```
Creates an in-memory object of type `IKeyVaultProperties`.
An array of `IKeyVaultProperties` can be fed as 
input to `KeyVaultProperty` parameter of New-AzServiceBusNamespaceV2 and Set-AzServiceBusNamespaceV2 to enable encryption.

### Example 2: Construct an in-memory KeyVaultProperties object having UserassignedIdentity
```powershell
$ec1 = "/subscriptions/0000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity"
New-AzServiceBusKeyVaultPropertiesObject -KeyName key4 -KeyVaultUri https://testkeyvault.vault.azure.net/ -UserAssignedIdentity $ec1
```

```Output
KeyName KeyVaultUri                            KeyVersion UserAssignedIdentity
------- -----------                            ---------- --------------------
key4    https://testkeyvault.vault.azure.net/           /subscriptions/0000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myFirstIdentity
```
Creates an in-memory object of type `IKeyVaultProperties`.
An array of `IKeyVaultProperties` can be fed as 
input to `KeyVaultProperty` parameter of New-AzServiceBusNamespaceV2 and Set-AzServiceBusNamespaceV2 to enable encryption.

## PARAMETERS

### -KeyName
Name of the Key from KeyVault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUri
Uri of KeyVault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVersion
Version of KeyVault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
ARM ID of user Identity selected for encryption.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.KeyVaultProperties

## NOTES

ALIASES

## RELATED LINKS

