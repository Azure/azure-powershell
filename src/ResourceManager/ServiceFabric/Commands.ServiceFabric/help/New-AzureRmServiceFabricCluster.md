---
external help file: Microsoft.Azure.Commands.ServiceFabric.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmServiceFabricCluster

## SYNOPSIS
This command uses certificates that you provide or system generated self signed certificates to set up a new service fabric cluster. It can use a default template or a custom template that you provide. You have the option of specifying a folder to export the self signed certificates to or fetching them later from the key vault. 

## SYNTAX

### ByDefaultArmTemplate (Default)
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> [-CertificateOutputFolder <String>]
 [-CertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>] [-KeyVaultName <String>]
 -Location <String> [-Name <String>] [-VmUserName <String>] [-ClusterSize <Int32>]
 [-CertificateSubjectName <String>] -VmPassword <SecureString> [-OS <OperatingSystem>] [-VmSku <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByExistingKeyVault
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 [-VmUserName <String>] -SecretIdentifier <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByNewPfxAndVaultName
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 [-CertificateOutputFolder <String>] [-CertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>]
 [-KeyVaultName <String>] [-VmUserName <String>] [-CertificateSubjectName <String>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByExistingPfxAndVaultName
```
New-AzureRmServiceFabricCluster [-ResourceGroupName] <String> -TemplateFile <String> -ParameterFile <String>
 -CertificateFile <String> [-CertificatePassword <SecureString>] [-SecondaryCertificateFile <String>]
 [-SecondaryCertificatePassword <SecureString>] [-KeyVaultResouceGroupName <String>] [-KeyVaultName <String>]
 [-VmUserName <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmServiceFabricCluster** command uses certificates that you provide or system generated self signed certificates to set up a new service fabric cluster. The template used can be a default template or a custom template that you provide. You have the option of specifying a folder to export the self signed certificates or fetching them later from the key vault.

If you are specifying a custom template and parameter file, you don't need to provide the certificate information in the parameter file, the system will populate these parameters.

The four options are detailed below. Scroll down for explanations of each of the parameters.

## EXAMPLES

### Example 1: Specify only the cluster size, the cert subject name and the OS to deploy a cluster.
```
$pwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force
$RGname="chacko09"
$clusterloc="SouthCentralUS"
$subname="$RGname.$clusterloc.cloudapp.azure.com"
$pfxfolder="c:\Mycertificates\"

Write-Output "create cluster in " $clusterloc "subject name for cert " $subname "and output the cert into " $pfxfolder

New-AzureRmServiceFabricCluster -ResourceGroupName $RGname -Location $clusterloc -ClusterSize 3 -VmPassword $pwd -CertificateSubjectName $subname -PfxOutputFolder $pfxfolder -CertificatePassword $pwd
```

This command specifies only the cluster size, the cert subject name and the OS to deploy a cluster.

### Example 2: Specify an existing Certificate resource in a key vault and a custom template to deploy a cluster
```
$RGname="chacko20"
$templateParmfile="C:\service-fabric-secure-nsg-cluster-65-node-3-nodetype\azuredeploytest.parameters.json"
$templateFile="C:\azure-quickstart-templates\service-fabric-secure-nsg-cluster-65-node-3-nodetype\azuredeploy.json"
$secertId="https://chackokv1.vault.azure.net:443/secrets/chackdantestcertificate4/56ec774dc61a462bbc645ffc9b4b225f"

New-AzureRmServiceFabricCluster -ResourceGroupName $RGname -TemplateFile $templateFile -ParameterFile $templateParmfile -SecretIdentifier $secertId
```

This command specifies an existing Certificate resource in a key vault and a custom template to deploy a cluster 

### Example 3: Create a new cluster using a custom template, Specify the different RG name for the key vault and have the system upload the certificate to it
```
$pwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force
$RGname="chacko20"
$keyVaultRG="chacko20kvrg"
$keyVault="chacko20kv"
$clusterloc="SouthCentralUS"
$subname="$RGname.$clusterloc.cloudapp.azure.com"
$pfxfolder="c:\Mycertificates\"
$templateParmfile="C:\service-fabric-secure-nsg-cluster-65-node-3-nodetype\azuredeploytest.parameters.json"
$templateFile="C:\service-fabric-secure-nsg-cluster-65-node-3-nodetype\azuredeploy.json"
$secertId="https://chackokv1.vault.azure.net:443/secrets/chackdantestcertificate4/55ec7c4dc61a462bbc645ffc9b4b225f"
$thumprint="C2D7E11DD35153A702A51D10A424A3014B9B6E8B"

New-AzureRmServiceFabricCluster -ResourceGroupName $RGname -TemplateFile $templateFile -ParameterFile $templateParmfile -CertificateOutputFolder $pfxfolder -CertificatePassword $pwd -KeyVaultResouceGroupName $keyVaultRG  -KeyVaultName $keyVault -CertificateSubjectName $subname
```

This command creates a new cluster using a custom template, Specify the different RG name for the key vault and have the system upload the certificate to it 

### Example 4: Bring your own Certificate and custom template and create a new cluster
```
$certPwd="Password#1234" | ConvertTo-SecureString -AsPlainText -Force
$RGname="chacko20"
$keyVaultRG="chacko20kvrg"
$keyVault="chacko20kv"
$clusterloc="SouthCentralUS"
$pfxsourcefile="c:\Mycertificates\my2017Prodcert.pfx"
$templateParmfile="C:\Users\chackdan\Documents\GitHub\azure-quickstart-templates-parms\service-fabric-secure-nsg-cluster-65-node-3-nodetype\azuredeploytest.parameters.json"
$templateFile="C:\Users\chackdan\Documents\GitHub\azure-quickstart-templates\service-fabric-secure-nsg-cluster-65-node-3-nodetype\azuredeploy.json"

New-AzureRmServiceFabricCluster -ResourceGroupName $RGname -TemplateFile $templateFile -ParameterFile $templateParmfile -CertificateSourceFile $pfxsourcefile -CertificatePassword $certpwd -KeyVaultResouceGroupName $keyVaultRG -KeyVaultName $keyVault
```

This command will let you bring your own Certificate and custom template and create a new cluster

## PARAMETERS

### -CertificateFile
The existing certificate file path for the primary cluster certificate

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

### -CertificateOutputFolder
The folder of the new certificate file to be created

```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate, ByNewPfxAndVaultName
Aliases: Destination

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CertificatePassword
The password of the certificate file

```yaml
Type: SecureString
Parameter Sets: ByDefaultArmTemplate, ByNewPfxAndVaultName, ByExistingPfxAndVaultName
Aliases: CertPassword

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CertificateSubjectName
The subject name of the certificate to be created

```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate, ByNewPfxAndVaultName
Aliases: Subject

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterSize
The number of nodes in the cluster.
Default are 5 nodes

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
Azure key vault name, it not given it will be defaulted to the resource group name

```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate, ByNewPfxAndVaultName, ByExistingPfxAndVaultName
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultResouceGroupName
Azure key vault resource group name, it not given it will be defaulted to resource group name

```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate, ByNewPfxAndVaultName, ByExistingPfxAndVaultName
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
Specify the name of the cluster, if not given it will be same as resource group name

```yaml
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
The Operating System of the VMs that make up the cluster.

```yaml
Type: OperatingSystem
Parameter Sets: ByDefaultArmTemplate
Aliases: VmImage
Accepted values: WindowsServer2012R2Datacenter, WindowsServer2016Datacenter, WindowsServer2016DatacenterwithContainers, UbuntuServer1604

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ParameterFile
The path to the template parameter file.

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

### -ResourceGroupName
Specify the name of the resource group.

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

### -SecondaryCertificateFile
The existing certificate file path for the secondary cluster certificate

```yaml
Type: String
Parameter Sets: ByExistingPfxAndVaultName
Aliases: SecSource

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SecondaryCertificatePassword
The password of the certificate file

```yaml
Type: SecureString
Parameter Sets: ByExistingPfxAndVaultName
Aliases: SecCertPassword

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SecretIdentifier
The existing Azure key vault secret URL, for example 'https://mykv.vault.azure.net:443/secrets/mysecrets/55ec7c4dc61a462bbc645ffc9b4b225f'

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
The path to the template file.

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
The password of the Vm

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
The Vm Sku

```yaml
Type: String
Parameter Sets: ByDefaultArmTemplate
Aliases: Sku

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VmUserName
The user name for logging to Vm

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Security.SecureString
System.Int32
Microsoft.Azure.Commands.ServiceFabric.Models.OperatingSystem

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PSDeploymentResult

## NOTES

## RELATED LINKS

