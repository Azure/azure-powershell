---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmServiceFabricCluster

## SYNOPSIS
Create an new ServiceFabric cluster

## SYNTAX

### ByExistingKeyVault
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -SecretIdentifier <String> [-CertificateThumprint <String>] [<CommonParameters>]
```

### ByNewPfxAndVaultName
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -CertificateSubjectName <String> [-KeyVaultName <String>] [-KeyVaultResouceGroupName <String>]
 [-PfxDestinationFile <String>] [<CommonParameters>]
```

### ByExistingPfxAndVaultName
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -KeyVaultName <String> -KeyVaultResouceGroupName <String> -PfxSourceFile <String>
 -CertificatePassword <SecureString> [<CommonParameters>]
```

### ByExistingPfxSetAndVaultId
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -KeyVaultResouceId <String> -PfxSourceFile <String> -CertificatePassword <SecureString> [<CommonParameters>]
```

### ByDefaultArmTemplate
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -Location <String> [-ClusterSize <Int32>]
 -CertificateSubjectName <String> -VmPassword <SecureString> [-OS <OS>] [-PfxDestinationFile <String>]
 [<CommonParameters>]
```

### ByNewPfxAndVaultId
```
New-AzureRmServiceFabricCluster -TemplateFile <String> -ParameterFile <String> -CertificateSubjectName <String>
 -KeyVaultResouceId <String> [-PfxDestinationFile <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmServiceFabricCluster** can deploy an new cluster or update the cluster using Azure resource template
The template file can only be secure cluster template.
You don't need to input the certificate information in the parameter file, it will place the information from parameters into the template file directly

## EXAMPLES

### Example 1
```
PS c:\> $pwd = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS c:\> New-AzureRmServiceFabricCluster -ResourceGroupName 'Group1' -KeyVaultName 'Contoso01Vault' -KeyVaultResouceGroupName 'Contoso01VaultRg' 
-Source c:\existingPfx.pfx -Password $pwd -TemplateFile c:\template.json -TemplateParameterFile c:\parameters.json
```

This command will upload an existing certificate to Azure key vault, and uses it and Azure resource templdate to deploy a ServiceFabric cluster

### Example 2
```
PS c:\> $pwd = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS C:\> New-AzureRmServiceFabricCluster -ResourceGroupName 'Group2' -KeyVaultName 'Contoso02Vault' -KeyVaultResouceGroupName 'Contoso02VaultRg' 
-PfxDestinationFile 'c:\newcert.pfx'  -TemplateFile 'c:\template.json' -TemplateParameterFile 'c:\parameters.json' -CertificateDnsName 'mydns.com' -Password $pwd
```

This command will create a self signed certificate with Dns name provided, and upload to Azure key vault, and uses it and ARM templdate to deploy a ServiceFabric cluster

### Example 3
```
PS C:\> New-AzureRmServiceFabricCluster -ResourceGroupName 'Group3' -TemplateFile 'c:\template.json' -TemplateParameterFile c:\parameters.json  
-SecretUrl 'https://contoso03vault.vault.azure.net/secrets/contoso03vaultrg/7f7de9131c034172b9df37ccc549524f' -CertificateThumprint 'AF06E4BFCBA05DCB59C42720136EC19DBA0A8E9F'
```

This command will deploy an new ServiceFabric cluster using existing Azure key vault and Azure resource template

### Example 4
```
PS c:\> $pwd = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS C:\> New-AzureRmServiceFabricCluster -TemplateFile 'c:\template.json' -TemplateParameterFile  'c:\parameters.json' 
-KeyVaultResouceId '/subscriptions/13ad2c84-84fa-4798-ad71-e70c07af873f/resoceGroups/contoso03vaultrg/providers/Microsoft.KeyVault/vaults/contoso03vault' 
-PfxSourceFile 'c:\pfx.pfx' -Password $pwd  -ResourceGroupName 'Group4'
```

This command will upload an existing certificate to Azure key vault, and uses it and Azure resource templdate to deploy a ServiceFabric cluster

## PARAMETERS

### -CertificatePassword
The password of the pfx file

```yaml
Type: SecureString
Parameter Sets: ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId
Aliases: Password

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertificateSubjectName
The Dns name of the certificate to be created

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByDefaultArmTemplate, ByNewPfxAndVaultId
Aliases: Subject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CertificateThumprint
The thumprint for the Azure key vault secret

```yaml
Type: String
Parameter Sets: ByExistingKeyVault
Aliases: Thumbprint

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ClusterSize
The cluster size, the default is 5 nodes clusters

```yaml
Type: Int32
Parameter Sets: ByDefaultArmTemplate
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultName
Azure key vault name

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName
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
Parameter Sets: ByNewPfxAndVaultName
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultResouceId
Azure key vault resource id

```yaml
Type: String
Parameter Sets: ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The resource group location

```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OS
The OS of the cluster

```yaml
Type: OS
Parameter Sets: ByDefaultArmTemplate
Aliases: OperatingSystem
Accepted values: Windows, Linux

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParameterFile
The path of the template parameter file.

```yaml
Type: String
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PfxDestinationFile
The destination path of the new Pfx file to be created

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByDefaultArmTemplate, ByNewPfxAndVaultId
Aliases: Destination

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PfxSourceFile
The existing Pfx file path

```yaml
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
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId, ByDefaultArmTemplate
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

### -TemplateFile
The path of the template file.

```yaml
Type: String
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VmPassword
The password of the Vms

```yaml
Type: SecureString
Parameter Sets: ByDefaultArmTemplate
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmServiceFabricCluster](./Get-AzureRmServiceFabricCluster.md)

[Add-AzureRmServiceFabricClusterCertificate](./Add-AzureRmServiceFabricClusterCertificate.md)

[Add-AzureRmServiceFabricApplicationCertificate](./Add-AzureRmServiceFabricApplicationCertificate.md)
