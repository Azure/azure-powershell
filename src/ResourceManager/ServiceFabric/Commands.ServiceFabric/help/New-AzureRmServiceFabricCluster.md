---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmServiceFabricCluster

## SYNOPSIS
Create an new ServiceFabric cluster

## SYNTAX

### ByExistingPfxSetAndVaultId
```
New-AzureRmServiceFabricCluster -TemplateFile <String> -TemplateParameterFile <String> [-Mode <DeploymentMode>]
 -KeyVaultResouceId <String> [-SecretName <String>] -PfxSourceFile <String> -Password <SecureString>
 [-ResourceGroupName] <String> [<CommonParameters>]
```

### ByNewPfxAndVaultId
```
New-AzureRmServiceFabricCluster -TemplateFile <String> -TemplateParameterFile <String> [-Mode <DeploymentMode>]
 -KeyVaultResouceId <String> [-SecretName <String>] -PfxDestinationFile <String> -Password <SecureString>
 -CertificateDnsName <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

### ByExistingPfxAndVaultName
```
New-AzureRmServiceFabricCluster -TemplateFile <String> -TemplateParameterFile <String> [-Mode <DeploymentMode>]
 -KeyVaultName <String> -KeyVaultResouceGroupName <String> [-SecretName <String>] -PfxSourceFile <String>
 -Password <SecureString> [-ResourceGroupName] <String> [<CommonParameters>]
```

### ByNewPfxAndVaultName
```
New-AzureRmServiceFabricCluster -TemplateFile <String> -TemplateParameterFile <String> [-Mode <DeploymentMode>]
 -KeyVaultName <String> -KeyVaultResouceGroupName <String> [-SecretName <String>] -PfxDestinationFile <String>
 -Password <SecureString> -CertificateDnsName <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

### ByExistingKeyVault
```
New-AzureRmServiceFabricCluster -TemplateFile <String> -TemplateParameterFile <String> [-Mode <DeploymentMode>]
 -SecretIdentifier <String> -CertificateThumprint <String> [-ResourceGroupName] <String> [<CommonParameters>]
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

### -CertificateDnsName
The Dns name of the certificate to be created```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultId, ByNewPfxAndVaultName
Aliases: Dns

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
Aliases: Thumprint

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultName
Azure key vault name

```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName, ByNewPfxAndVaultName
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
Parameter Sets: ByExistingPfxAndVaultName, ByNewPfxAndVaultName
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

### -Mode
The deployment mode.

```yaml
Type: DeploymentMode
Parameter Sets: (All)
Aliases: 
Accepted values: Incremental, Complete

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Password
The password of the pfx file

```yaml
Type: SecureString
Parameter Sets: ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId, ByExistingPfxAndVaultName, ByNewPfxAndVaultName
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
Parameter Sets: ByNewPfxAndVaultId, ByNewPfxAndVaultName
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
Parameter Sets: ByExistingPfxSetAndVaultId, ByExistingPfxAndVaultName
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
Parameter Sets: (All)
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
Parameter Sets: ByExistingPfxSetAndVaultId, ByNewPfxAndVaultId, ByExistingPfxAndVaultName, ByNewPfxAndVaultName
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TemplateFile
The path of the template file.

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

### -TemplateParameterFile
The path of the template parameter file.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmServiceFabricCluster](./[Get-AzureRmServiceFabricCluster.md)
[Add-AzureRmServiceFabricClusterCertificate](./Add-AzureRmServiceFabricClusterCertificate.md)
[Add-AzureRmServiceFabricApplicationCertificate](./Add-AzureRmServiceFabricApplicationCertificate.md)
