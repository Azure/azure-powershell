---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmServiceFabricCluster

## SYNOPSIS
This command uses certificates that you provide or system generated self signed certificates to setup a new service fabric cluster. The template used can be a default template or a custom template that you provide. You have the option of specifying a folder to export the self signed certificates or fetching it later from the keyvault. 

## SYNTAX

### ByExistingKeyVault
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -SecretIdentifier <String> [-CertificateThumprint <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByNewPfxAndVaultName
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 [-PfxOutputFolder <String>] [-CertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>]
 [-KeyVaultName <String>] [-CertificateSubjectName <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByExistingPfxAndVaultName
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -PfxSourceFile <String> [-CertificatePassword <SecureString>] [-SecondaryPfxSourceFile <String>]
 [-SecondaryCertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>] [-KeyVaultName <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByDefaultArmTemplate
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> [-PfxOutputFolder <String>]
 [-CertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>] [-KeyVaultName <String>]
 -Location <String> [-Name <String>] [-ClusterSize <Int32>] [-CertificateSubjectName <String>]
 -VmPassword <SecureString> [-OS <OperatingSystem>] [-VmSku <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmServiceFabricCluster** command uses certificates that you provide or system generated self signed certificates to setup a new service fabric cluster. The template used can be a default template or a custom template that you provide. You have the option of specifying a folder to export the self signed certificates or fetching it later from the keyvault.

If you are specifing a custom tempalte and parmater file, ou don't need to provide the certificate information in the parameter file, the system will popualte these paramters.

The four options are detailed below. Scroll down for explainatins of each of the paramters.

## EXAMPLES

### Example 1
### Specify only the cluster size, the OS to deploy a cluster

In addition to creating a new self signed cert, the commands also uploads the certificate to a new or existing keyvault and uses it to deploy a secure service fabric cluster and Azure resource templdate to deploy a ServiceFabric cluster
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> [-PfxOutputFolder <String>]
 [-CertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>] [-KeyVaultName <String>]
 -Location <String> [-Name <String>] [-ClusterSize <Int32>] [-CertificateSubjectName <String>]
 -VmPassword <SecureString> [-OS <OperatingSystem>] [-VmSku <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

Here is a filled out example.

```
$pwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force
$RGname="chacko09"
$clusterloc="SouthCentralUS"
$subname="$RGname.$clusterloc.cloudapp.azure.com"
$pfxfolder="c:\Mycertificates\"

Write-Output "create cluster in " $clusterloc "subject name for cert " $subname "and output the cert into " $pfxfolder

New-AzureRmServiceFabricCluster -ResourceGroupName $RGname -Location $clusterloc -ClusterSize 3 -VmPassword $pwd -CertificateSubjectName $subname -PfxOutputFolder $pfxfolder -CertificatePassword $pwd

```



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
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByDefaultArmTemplate
Aliases: CertPassword

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CertificateSubjectName
The Dns name of the certificate to be created

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByDefaultArmTemplate
Aliases: Subject

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByValue)
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultName
Azure key vault name

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByDefaultArmTemplate
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultResouceGroupName
Azure key vault resource group name

```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByExistingPfxAndVaultName, ByDefaultArmTemplate
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specify the name of the cluster, if not given it will be same as resource group name```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate
Aliases: ClusterName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OS
The OS of the cluster

```yaml
Type: OperatingSystem
Parameter Sets: ByDefaultArmTemplate
Aliases: 
Accepted values: WindowsServer2012R2Datacenter, WindowsServer2016Datacenter, WindowsServer2016DatacenterwithContainers, UbuntuServer1604

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
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PfxOutputFolder
The folder of the new Pfx file to be created```yaml
Type: String
Parameter Sets: ByNewPfxAndVaultName, ByDefaultArmTemplate
Aliases: Destination

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PfxSourceFile
The existing Pfx file path

```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName
Aliases: Source

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SecondaryCertificatePassword
The password of the pfx file```yaml
Type: SecureString
Parameter Sets: ByExistingPfxAndVaultName
Aliases: SecCertPassword

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SecondaryPfxSourceFile
The existing Pfx file path for the secondary cluster certificate```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName
Aliases: SecSource

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TemplateFile
The path of the template file.

```yaml
Type: String
Parameter Sets: ByExistingKeyVault, ByNewPfxAndVaultName, ByExistingPfxAndVaultName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -VmSku
The Vm Sku```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate
Aliases: Sku

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

[Get-AzureRmServiceFabricCluster](./Get-AzureRmServiceFabricCluster.md)
[Add-AzureRmServiceFabricClusterCertificate](./Add-AzureRmServiceFabricClusterCertificate.md)
[Add-AzureRmServiceFabricApplicationCertificate](./Add-AzureRmServiceFabricApplicationCertificate.md)
