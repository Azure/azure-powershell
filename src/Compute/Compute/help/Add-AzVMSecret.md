---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 5008F83F-AF3E-47CF-99A3-55129E654128
online version: https://docs.microsoft.com/powershell/module/az.compute/add-azvmsecret
schema: 2.0.0
---

# Add-AzVMSecret

## SYNOPSIS
Adds a secret to a virtual machine.

## SYNTAX

```
Add-AzVMSecret [-VM] <PSVirtualMachine> [[-SourceVaultId] <String>] [[-CertificateStore] <String>]
 [[-CertificateUrl] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzVMSecret** cmdlet adds a secret to a virtual machine.
This value lets you add a certificate to the virtual machine.
The secret must be stored in a Key Vault.
For more information about Key Vault, see [What is Azure Key Vault?](https://azure.microsoft.com/en-us/documentation/articles/key-vault-whatis/).
For more information about the cmdlets, see [Azure Key Vault Cmdlets](/powershell/module/az.keyvault) or the [Set-AzKeyVaultSecret](/powershell/module/az.keyvault/set-azkeyvaultsecret) cmdlet.

## EXAMPLES

### Example 1: Add a secret to a virtual machine
```
PS C:\> $VirtualMachine = New-AzVMConfig -VMName "VirtualMachine07" -VMSize "Standard_A1" -AvailabilitySetID $AvailabilitySet.Id
PS C:\> $Credential = Get-Credential
PS C:\> $VirtualMachine = Set-AzVMOperatingSystem -VM $VirtualMachine  -Windows -ComputerName "Contoso26" -Credential $Credential
PS C:\> $SourceVaultId = "/subscriptions/46f8cea4-2de6-4179-8ab1-365da4211af4/resourceGroups/vault/providers/Microsoft.KeyVault/vaults/keyvault"
PS C:\> $CertificateStore01 = "My"
PS C:\> $CertificateUrl01 = "https://contosovault.vault.azure.net/secrets/514ceb769c984379a7e0230bdd703272"
PS C:\> $VirtualMachine = Add-AzVMSecret -VM $VirtualMachine -SourceVaultId $SourceVaultId -CertificateStore $CertificateStore01 -CertificateUrl $CertificateUrl01
```

The first command creates a virtual machine object, and then stores it in the $VirtualMachine variable.
The command assigns a name and size to the virtual machine.
The second command creates a credential object by using the Get-Credential cmdlet, and then stores the result in the $Credential variable.
The command prompts you for a user name and password.
For more information, type `Get-Help Get-Credential`.
The third command uses the **Set-AzVMOperatingSystem** cmdlet to configure the virtual machine stored in $VirtualMachine.
The fourth command assigns a source vault ID to the $SourceVaultId variable for later use.
The command assumes that the $SubscriptionId variable has an appropriate value.
The fifth command assigns a value to the $CertificateStore01 variable for later use.
The sixth command assigns a URL for a certificate store.
The seventh command adds a secret to the virtual machine stored in $VirtualMachine.
The SourceVaultId parameter specifies the Key Vault.
The command specifies the name of the certificate store and the URL of the certificate.
You can run the **Add-AzVMSecret** repeatedly to add secrets for other certificates.

## PARAMETERS

### -CertificateStore
Specifies the name of a certificate store on the virtual machine that runs the Windows operating system.
This cmdlet adds the certificate to the store that this parameter specifies.
You can only specify this parameter for virtual machines that run the Windows operating system.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertificateUrl
Specifies the URL that points to a Key Vault secret which contains a certificate.
The certificate is the Base64 encoding of the following JavaScript Object Notation (JSON) object, which is encoded in UTF-8:
{
"data": "\<Base64-encoded-file\>",
"dataType": "\<file-format\>",
"password": "\<pfx-file-password\>"
}
Currently, dataType accepts only .pfx files.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -SourceVaultId
Specifies the resource ID of the Key Vault that contains the certificates that you can add to the virtual machine.
This value also acts as the key for adding multiple certificates.
This means that you can use the same value for *SourceVaultId* when you add multiple certificates from the same Key Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Id

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VM
Specifies the virtual machine object that this cmdlet modifies.
To obtain a virtual machine object, use the [Get-AzVM](./Get-AzVM.md) cmdlet.
You can use the [New-AzVMConfig](./New-AzVMConfig.md) cmdlet to create a virtual machine object.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases: VMProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS

[Get-AzVM](./Get-AzVM.md)

[New-AzVMConfig](./New-AzVMConfig.md)

[Set-AzVMOperatingSystem](./Set-AzVMOperatingSystem.md)
