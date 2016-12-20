---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
ms.assetid: 6BCB36BC-F5E6-4EDD-983C-8BDE7A9B004D
online version: 
schema: 2.0.0
---

# Set-AzureRmVMDiskEncryptionExtension

## SYNOPSIS
Enables encryption on a running IaaS virtual machine in Azure.

## SYNTAX

### AAD Client Secret Parameters (Default)
```
Set-AzureRmVMDiskEncryptionExtension [-ResourceGroupName] <String> [-VMName] <String> [-AadClientID] <String>
 [-AadClientSecret] <String> [-DiskEncryptionKeyVaultUrl] <String> [-DiskEncryptionKeyVaultId] <String>
 [[-KeyEncryptionKeyUrl] <String>] [[-KeyEncryptionKeyVaultId] <String>] [[-KeyEncryptionAlgorithm] <String>]
 [[-VolumeType] <String>] [[-SequenceVersion] <String>] [[-TypeHandlerVersion] <String>] [[-Name] <String>]
 [[-Passphrase] <String>] [-Force] [-DisableAutoUpgradeMinorVersion] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AAD Client Cert Parameters
```
Set-AzureRmVMDiskEncryptionExtension [-ResourceGroupName] <String> [-VMName] <String> [-AadClientID] <String>
 [-AadClientCertThumbprint] <String> [-DiskEncryptionKeyVaultUrl] <String> [-DiskEncryptionKeyVaultId] <String>
 [[-KeyEncryptionKeyUrl] <String>] [[-KeyEncryptionKeyVaultId] <String>] [[-KeyEncryptionAlgorithm] <String>]
 [[-VolumeType] <String>] [[-SequenceVersion] <String>] [[-TypeHandlerVersion] <String>] [[-Name] <String>]
 [[-Passphrase] <String>] [-Force] [-DisableAutoUpgradeMinorVersion] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmVMDiskEncryptionExtension** cmdlet enables encryption on a running infrastructure as a service (IaaS) virtual machine in Azure.
This cmdlet enables encryption by installing the disk encryption extension on the virtual machine.
If no *Name* parameter is specified, an extension with the default name AzureDiskEncryption for virtual machines that run the Windows operating system or AzureDiskEncryptionForLinux for Linux virtual machines are installed.
This cmdlet requires confirmation from the users as one of the steps to enable encryption requires a restart of the virtual machine.
It is advised that you save your work on the virtual machine before you run this cmdlet.

## EXAMPLES

### Example 1: Enable encryption using Azure AD Client ID and Client Secret
```
PS C:\>$RGName = "MyResourceGroup";
PS C:\> $VMName = "MyTestVM";
PS C:\> $AADClientID = "<clientID of your Azure AD app>";
PS C:\> $AADClientSecret = "<clientSecret of your Azure AD app>";
PS C:\> $VaultName= "MyKeyVault";
PS C:\> $KeyVault = Get-AzureRmKeyVault -VaultName $VaultName -ResourceGroupName $RGName;
PS C:\> $DiskEncryptionKeyVaultUrl = $KeyVault.VaultUri;
PS C:\> $KeyVaultResourceId = $KeyVault.ResourceId;
PS C:\> Set-AzureRmVMDiskEncryptionExtension -ResourceGroupName $RGName -VMName $VMName -AadClientID $AADClientID -AadClientSecret $AADClientSecret -DiskEncryptionKeyVaultUrl $DiskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $KeyVaultResourceId ;
```

This example enables encryption using Azure AD client ID, and client secret.

### Example 2: Enable encryption using Azure AD client ID and client certification thumbprint
```
PS C:\>$RGName = "MyResourceGroup";
PS C:\> $VMName = "MyTestVM";
#The KeyVault must have enabledForDiskEncryption property set on it
PS C:\> $VaultName= "MyKeyVault";
PS C:\> $KeyVault = Get-AzureRmKeyVault -VaultName $VaultName -ResourceGroupName $RGName;
PS C:\> $DiskEncryptionKeyVaultUrl = $KeyVault.VaultUri;
PS C:\> $KeyVaultResourceId = $KeyVault.ResourceId;

# create Azure AD application and associate the certificate
PS C:\> $CertPath = "C:\certificates\examplecert.pfx";
PS C:\> $CertPassword = "Password";
PS C:\> $Cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertPath, $CertPassword);
PS C:\> $KeyValue = [System.Convert]::ToBase64String($cert.GetRawCertData());
PS C:\> $AzureAdApplication = New-AzureRmADApplication -DisplayName "<Your Application Display Name>" -HomePage "<https://YourApplicationHomePage>" -IdentifierUris "<https://YouApplicationUri>" -KeyValue $KeyValue -KeyType AsymmetricX509Cert ;
PS C:\> $ServicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $AzureAdApplication.ApplicationId;

PS C:\> $AADClientID = $AzureAdApplication.ApplicationId;
PS C:\> $aadClientCertThumbprint= $cert.Thumbprint;

#Upload pfx to KeyVault 
PS C:\> $KeyVaultSecretName = "MyAADCert';
PS C:\> $FileContentBytes = get-content $CertPath -Encoding Byte;
PS C:\> $FileContentEncoded = [System.Convert]::ToBase64String($fileContentBytes);
PS C:\> $JSONObject = @" { "data": "$filecontentencoded", "dataType" :"pfx", "password": "$CertPassword" } "@ ;
PS C:\> $JSONObjectBytes = [System.Text.Encoding]::UTF8.GetBytes($jsonObject);
PS C:\> $JSONEncoded = [System.Convert]::ToBase64String($jsonObjectBytes);

PS C:\> $Secret = ConvertTo-SecureString -String $JSONEncoded -AsPlainText -Force;
PS C:\> Set-AzureKeyVaultSecret -VaultName $VaultName -Name $KeyVaultSecretName -SecretValue $Secret;
PS C:\> Set-AzureRmKeyVaultAccessPolicy -VaultName $VaultName -ResourceGroupName $RGName -EnabledForDeployment;

#deploy cert to VM
PS C:\> $CertUrl = (Get-AzureKeyVaultSecret -VaultName $VaultName -Name $KeyVaultSecretName).Id
$SourceVaultId = (Get-AzureRmKeyVault -VaultName $VaultName -ResourceGroupName $RGName).ResourceId
PS C:\> $VM = Get-AzureRmVM -ResourceGroupName $RGName -Name $VMName 
PS C:\> $VM = Add-AzureRmVMSecret -VM $VM -SourceVaultId $SourceVaultId -CertificateStore "My" -CertificateUrl $CertUrl
PS C:\> Update-AzureRmVM -VM $VM -ResourceGroupName $RGName 

#Enable encryption on the virtual machine using Azure AD client ID and client cert thumbprint
PS C:\> Set-AzureRmVMDiskEncryptionExtension -ResourceGroupName $RGName -VMName $VMName -AadClientID $AADClientID -AadClientCertThumbprint $AADClientCertThumbprint -DiskEncryptionKeyVaultUrl $DiskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $KeyVaultResourceId ;
```

This example enables encryption using Azure AD client ID and client certification thumbprints.

### Example 3: Enable encryption using Azure AD client ID, client secret, and wrap disk encryption key by using key encryption key
```
PS C:\>$RGName = "MyResourceGroup";
PS C:\> $VMName = "MyTestVM";

PS C:\> $AADClientID = "<clientID of your Azure AD app>";
PS C:\> $AADClientSecret = "<clientSecret of your Azure AD app>";

PS C:\> $VaultName= "MyKeyVault";
PS C:\> $KeyVault = Get-AzureRmKeyVault -VaultName $VaultName -ResourceGroupName $RGName;
PS C:\> $DiskEncryptionKeyVaultUrl = $KeyVault.VaultUri;
PS C:\> $KeyVaultResourceId = $KeyVault.ResourceId;

PS C:\> $KEK = Add-AzureKeyVaultKey -VaultName $VaultName -Name $KEKName -Destination "Software"
PS C:\> $KeyEncryptionKeyUrl = $KEK.Key.kid;

PS C:\> Set-AzureRmVMDiskEncryptionExtension -ResourceGroupName $RGName -VMName $VMName -AadClientID $AADClientID -AadClientSecret $AADClientSecret -DiskEncryptionKeyVaultUrl $DiskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $KeyVaultResourceId -KeyEncryptionKeyUrl $KeyEncryptionKeyUrl -KeyEncryptionKeyVaultId $KeyVaultResourceId;
```

This example enables encryption using Azure AD client ID, client secret, and wrap disk encryption key by using the key encryption key.

### Example 4: Enable encryption using Azure AD client ID, client cert thumbprint, and wrap disk encryptionkey by using key encryption key
```
PS C:\>$RGName = "MyResourceGroup";
PS C:\> $VMName = "MyTestVM";
#The KeyVault must have enabledForDiskEncryption property set on it
PS C:\> $VaultName= "MyKeyVault";
PS C:\> $KeyVault = Get-AzureRmKeyVault -VaultName $VaultName -ResourceGroupName $RGName;
PS C:\> $DiskEncryptionKeyVaultUrl = $KeyVault.VaultUri;
PS C:\> $KeyVaultResourceId = $KeyVault.ResourceId;
PS C:\> $KEK = Add-AzureKeyVaultKey -VaultName $VaultName -Name $KEKName -Destination "Software"
PS C:\> $KeyEncryptionKeyUrl = $KEK.Key.kid;

PS C:\> # create Azure AD application and associate the certificate
PS C:\> $CertPath = "C:\certificates\examplecert.pfx";
PS C:\> $CertPassword = "Password";
PS C:\> $Cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertPath, $CertPassword);
PS C:\> $KeyValue = [System.Convert]::ToBase64String($cert.GetRawCertData());
PS C:\> $AzureAdApplication = New-AzureRmADApplication -DisplayName "<Your Application Display Name>" -HomePage "<https://YourApplicationHomePage>" -IdentifierUris "<https://YouApplicationUri>" -KeyValue $KeyValue -KeyType AsymmetricX509Cert ;
PS C:\> $ServicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $AzureAdApplication.ApplicationId;

PS C:\> $AADClientID = $AzureAdApplication.ApplicationId;
PS C:\> $AADClientCertThumbprint= $Cert.Thumbprint;

#Upload pfx to KeyVault 
PS C:\> $KeyVaultSecretName = "MyAADCert";
PS C:\> $FileContentBytes = get-content $CertPath -Encoding Byte;
PS C:\> $FileContentEncoded = [System.Convert]::ToBase64String($FileContentBytes);
$JSONObject = @" { "data": "$filecontentencoded", "dataType" :"pfx", "password": "$CertPassword" } "@ ;
PS C:\> $JSONObjectBytes = 
[System.Text.Encoding]::UTF8.GetBytes($JSONObject);$jsonEncoded = [System.Convert]::ToBase64String($JSONObjectBytes);
PS C:\> $Secret = ConvertTo-SecureString -String $JSONEncoded -AsPlainText -Force;
PS C:\> Set-AzureKeyVaultSecret -VaultName $VaultName-Name $KeyVaultSecretName -SecretValue $Secret;
PS C:\> Set-AzureRmKeyVaultAccessPolicy -VaultName $VaultName -ResourceGroupName $RGName -EnabledForDeployment;

#deploy cert to VM
PS C:\> $CertUrl = (Get-AzureKeyVaultSecret -VaultName $VaultName -Name $KeyVaultSecretName).Id
PS C:\> $SourceVaultId = (Get-AzureRmKeyVault -VaultName $VaultName -ResourceGroupName $RGName).ResourceId
PS C:\> $VM = Get-AzureRmVM -ResourceGroupName $RGName -Name $VMName 
PS C:\> $VM = Add-AzureRmVMSecret -VM $VM -SourceVaultId $SourceVaultId -CertificateStore "My" -CertificateUrl $CertUrl 
PS C:\> Update-AzureRmVM -VM $VM -ResourceGroupName $RGName 

#Enable encryption on the virtual machine using Azure AD client ID and client cert thumbprint
PS C:\> Set-AzureRmVMDiskEncryptionExtension -ResourceGroupName $RGname -VMName $VMName -AadClientID $AADClientID -AadClientCertThumbprint $AADClientCertThumbprint -DiskEncryptionKeyVaultUrl $DiskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $KeyVaultResourceId ;
```

This example enables encryption using Azure AD client ID, client cert thumbprint, and wrap disk encryption key by using key encryption key.

## PARAMETERS

### -AadClientCertThumbprint
Specifies the thumbprint of the AzureActive Directory (Azure AD) application client certificate that has permissions to write secrets to **KeyVault**.
As a prerequisite, the Azure AD client certificate must be previously deployed to the virtual machine's local computer `my` certificate store.
The Add-AzureRmVMSecret cmdlet can be used to deploy a certificate to a virtual machine in Azure.
For more details, see the **Add-AzureRmVMSecret** cmdlet help.
The certificate must be previously deployed to the virtual machine local computer my certificate store.

```yaml
Type: String
Parameter Sets: AAD Client Cert Parameters
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AadClientID
Specifies the client ID of the Azure AD application that has permissions to write secrets to **KeyVault**.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AadClientSecret
Specifies the client secret of the Azure AD application that has permissions to write secrets to **KeyVault**.

```yaml
Type: String
Parameter Sets: AAD Client Secret Parameters
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableAutoUpgradeMinorVersion
Indicates that this cmdlet disables auto-upgrade of the minor version of the extension.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: 15
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskEncryptionKeyVaultId
Specifies the resource ID of the **KeyVault** to which the virtual machine encryption keys should be uploaded.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskEncryptionKeyVaultUrl
Specifies the **KeyVault** URL to which the virtual machine encryption keys should be uploaded.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionAlgorithm
Specifies the algorithm that is used to wrap and unwrap the key encryption key of the virtual machine.
The default value is RSA-OAEP.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: RSA-OAEP, RSA1_5

Required: False
Position: 9
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyEncryptionKeyUrl
Specifies the URL of the key encryption key that is used to wrap and unwrap the virtual machine encryption key.
This must be the full versioned URL.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyEncryptionKeyVaultId
Specifies the resource ID of the **KeyVault** that contains key encryption key that is used to wrap and unwrap the virtual machine encryption key.
This must be a full versioned URL.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 8
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the Azure Resource Manager resource that represents the extension.
The default value is AzureDiskEncryption for virtual machines that run the Windows operating system or AzureDiskEncryptionForLinux for Linux virtual machines.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ExtensionName

Required: False
Position: 13
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Passphrase
Specifies the passphrase used for encrypting Linux virtual machines only.
This parameter is not used for virtual machines that run the Windows operating system.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 14
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group of the virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SequenceVersion
Specifies the sequence number of the encryption operations for a virtual machine.
This is unique per each encryption operation performed on the same virtual machine.
The Get-AzureRmVMExtension cmdlet can be used to retrieve the previous sequence number that was used.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 11
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TypeHandlerVersion
Specifies the version of the encryption extension.

```yaml
Type: String
Parameter Sets: (All)
Aliases: HandlerVersion, Version

Required: False
Position: 12
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMName
Specifies the name of the virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VolumeType
Specifies the type of virtual machine volumes to perform the encryption operation.
Allowed values for virtual machines that run the Windows operating system are as follows: All, OS, and Data.
The allowed values for Linux virtual machines are as follows: Data only.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: OS, Data, All

Required: False
Position: 10
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.

The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Add-AzureRmVMSecret](./Add-AzureRmVMSecret.md)

[Get-AzureRmVMDiskEncryptionStatus](./Get-AzureRmVMDiskEncryptionStatus.md)

[Remove-AzureRmVMDiskEncryptionExtension](./Remove-AzureRmVMDiskEncryptionExtension.md)


