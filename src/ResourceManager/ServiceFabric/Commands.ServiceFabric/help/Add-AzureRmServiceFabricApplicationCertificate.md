---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmServiceFabricApplicationCertificate

## SYNOPSIS
Add an certificate which will be used as application certificate

## SYNTAX

### ByExistingKeyVault
```
Add-AzureRmServiceFabricApplicationCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -SecretIdentifier <String> [-CertificateThumprint <String>] [<CommonParameters>]
```

### ByNewPfxAndVaultName
```
Add-AzureRmServiceFabricApplicationCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -KeyVaultName <String> -KeyVaultResouceGroupName <String> [-SecretName <String>] -PfxDestinationFile <String>
 -CertificatePassword <SecureString> -CertificateDnsName <String> [<CommonParameters>]
```

### ByExistingPfxAndVaultName
```
Add-AzureRmServiceFabricApplicationCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -KeyVaultName <String> -KeyVaultResouceGroupName <String> [-SecretName <String>] -PfxSourceFile <String>
 -CertificatePassword <SecureString> [<CommonParameters>]
```

### ByExistingPfxSetAndVaultId
```
Add-AzureRmServiceFabricApplicationCertificate [-ResourceGroupName] <String> [-ClusterName] <String>
 -KeyVaultResouceId <String> [-SecretName <String>] -PfxSourceFile <String> -CertificatePassword <SecureString>
 [<CommonParameters>]
```

### ByNewPfxAndVaultId
```
Add-AzureRmServiceFabricApplicationCertificate -KeyVaultResouceId <String> [-SecretName <String>]
 -PfxDestinationFile <String> -CertificatePassword <SecureString> -CertificateDnsName <String>
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmServiceFabricApplicationCertificate** installs the certificate to the all nodetypes in the cluster, either from existing Azure key vault 
or creating an new Azure key vault using existing certificate provided or from an new self signed certificate created

## EXAMPLES

### Example 1
```
PS c:> Add-AzureRmServiceFabricApplicationCertificate -ResourceGroupName 'Group1' -ClusterName 'Contoso01SFCluster' -SecretUrl 'https://contoso03vault.vault.azure.net/secrets/contoso03vaultrg/7f7de9131c034172b9df37ccc549524f'
-CertificateThumprint 5F3660C715EBBDA31DB1FFDCF508302348DE8E7A
```

This command will add a certificate from existing Azure key vault to all node types of the cluster named myCluster

### Example 2
```
PS c:\> $pwd = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS C:\> Add-AzureRmServiceFabricApplicationCertificate -ResourceGroupName 'Group2' -ClusterName 'Contoso02SFCluster' -KeyVaultName 'Contoso02Vault' -KeyVaultResouceGroupName 'Contoso02VaultRg' 
-PfxDestinationFile 'c:\newcert.pfx' -Password  $pwd  -CertificateDnsName 'Contoso.com''
```

This command will add certificate by creating an new self signed certificate and uploading to Azure key vault, then installs to all node types of the cluster

## PARAMETERS

### -CertificateDnsName
The Dns name of the certificate to be created```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByNewPfxAndVaultId
Aliases: Dns

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertificatePassword
The password of the pfx file```yaml
Type: SecureString
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId
Aliases: Password

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertificateThumprint
The thumprint for the Azure key vault secret```yaml
Type: String
Parameter Sets: ByExistingKeyVault
Aliases: Thumbprint

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ClusterName
Specifies the name of the cluster

```yaml
Type: String
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultName
Azure key vault name

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultResouceGroupName
Azure key vault resource group name

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultResouceId
Azure key vault resource id```yaml
Type: String
Parameter Sets: ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PfxDestinationFile
The destination path of the new Pfx file to be created```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByNewPfxAndVaultId
Aliases: Destination

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PfxSourceFile
The existing Pfx file path```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId
Aliases: Source

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group.

```yaml
Type: String
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecretIdentifier
The existing Azure key vault secret uri

```yaml
Type: String
Parameter Sets: ByExistingKeyVault
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecretName
Azure key vault secret name, if not specified, it will use the new or existing certificate name

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

[Add-AzureRmServiceFabricClusterCertificate](./Add-AzureRmServiceFabricClusterCertificate.md)
[New-AzureRmServiceFabricCluster](./New-AzureRmServiceFabricCluster.md)