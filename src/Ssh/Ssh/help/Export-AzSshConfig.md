---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Ssh.dll-Help.xml
Module Name: Az.Ssh
online version:
schema: 2.0.0
---

# Export-AzSshConfig

## SYNOPSIS
This cmdlet exports an SSH configuration file that can be used to connect to Azure Resources through client applications that support OpenSSH config and certificates. SSH config files can be created that use AAD issued certificates or local user credentials.

## SYNTAX

### Interactive
```
Export-AzSshConfig -ResourceGroupName <String> -Name <String> -ConfigFilePath <String>
 [-PublicKeyFile <String>] [-PrivateKeyFile <String>] [-UsePrivateIp] [-LocalUser <String>] [-Port <String>]
 [-ResourceType <String>] [-CertificateFile <String>] [-Overwrite] [-KeysDestinationFolder <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IpAddress
```
Export-AzSshConfig -Ip <String> -ConfigFilePath <String> [-PublicKeyFile <String>] [-PrivateKeyFile <String>]
 [-LocalUser <String>] [-Port <String>] [-CertificateFile <String>] [-Overwrite]
 [-KeysDestinationFolder <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Export-AzSshConfig -ResourceId <String> -ConfigFilePath <String> [-PublicKeyFile <String>]
 [-PrivateKeyFile <String>] [-UsePrivateIp] [-LocalUser <String>] [-Port <String>] [-CertificateFile <String>]
 [-Overwrite] [-KeysDestinationFolder <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The exported SSH configuration file can be used to connect to Azure Resources by client applications that support OpenSSH config and certificates. Applications such as git and rsync can use configuration file by setting the command to 'ssh -F /path/to/config'.
For example:
rsync -e 'ssh -F /path/to/config'.
Users can create ssh config files that use AAD issued certificates or local user credentials.

## EXAMPLES

### Example 1: Export a SSH configuration file for connecting to a resource using AAD issued certificates for authentication.
```powershell
Export-AzSshConfig -ResourceGroupName myRg -Name myMachine -ConfigFilePath ./sshconfig.config
```
When a -LocalUser is not supplied, the cmdlet will attempt to create a certificate to login using Azure AD. This is currently only supported for resources running Linux OS.
When using Azure AD to login to resource, the Host name in the configuration entry will be "{resource group name}-{resource name}", or "{ip address}" for Azure VMs.

### Example 2: Export a SSH configuration file for connecting to the Public Ip of an Azure Virtual Machine using AAD issued certificates.
```powershell
Export-AzSshConfig -Ip 1.2.3.4 -ConfigFilePath ./sshconfig.config
```

### Example 3: Export a SSH configuration file for connecting to Local User on Azure Resource using SSH certificates for authentication
```powershell
Export-AzSshConfig -ResourceGroupName myRg -Name myVm -LocalUser azureuser -CertificateFile ./cert -PrivateKeyFile ./id_rsa -ConfigFilePath ./sshconfig.config
```
When using local user credentials to login, the host name in the configuration entry will be "{resource group name}-{resource name}-{username}", or "{ip address}-{username}" for Azure VMs.
### Example 4: Export a SSH configuration file for connecting to Local User on Azure Resource using SSH private key for authentication

```powershell
Export-AzSshConfig -ResourceGroupName myRg -Name myVm -LocalUser azureuser -PrivateKeyFile ./id_rsa -ConfigFilePath ./sshconfig.config
```
### Example 5: Export a SSH configuration file for connecting to Local User on Azure Resource using interactive username and password for authentication

```powershell
Export-AzSshConfig -ResourceGroupName myRg -Name myVm -LocalUser azureuser -ConfigFilePath ./sshconfig.config
```
### Example 6: Determine where generated keys and certificates for the certificate will the stored.
```powershell
Export-AzSshConfig -ResourceGroupName myRg -Name myVm -KeysDestinationFolder /home/user/mykeys -ConfigFilePath ./sshconfig.config
```
Generated keys and certificates are, by default, stored in "az_ssh_config" directory in the same directory as the config file. The -KeysDestinationFolder parameter allows user to decide where the keys will be stored.

### Example 7: Create a generic config for use with any Azure VM.
```powershell
Export-AzSshConfig -Ip * -ConfigFilePath ./sshconfig.config
```

### Example 8: Provide the Resource Type of the target.
```powershell
Export-AzSshConfig -ResourceGroupName myRg -Name myVm -ResourceType Microsoft.Compute/virtualMachines -ConfigFilePath ./sshconfig.config
```
This parameter is useful when there is more than one supported resource with the same name in the Resource Group.

## PARAMETERS

### -CertificateFile
SSH Certificate to be used to authenticate to local user account.

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

### -ConfigFilePath
Path to write SSH configuration to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Ip
IP Address of target Azure VM.

```yaml
Type: System.String
Parameter Sets: IpAddress
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeysDestinationFolder
Directory where generated keys and certificates will be stored.

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

### -LocalUser
Username for a local user in the target resource.

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

### -Name
Name of the target Azure Resource.

```yaml
Type: System.String
Parameter Sets: Interactive
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Overwrite
Overwrite the config file, instead of appending new entry to the end of the file.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
Port to connect to on the remote host.

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

### -PrivateKeyFile
Path to private key file. 

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

### -PublicKeyFile
Path to public key file.

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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: Interactive
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource ID of the target resource.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceType
Resource type of the target resource.

```yaml
Type: System.String
Parameter Sets: Interactive
Aliases:
Accepted values: Microsoft.Compute/virtualMachines, Microsoft.HybridCompute/machines

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsePrivateIp
When connecting to an Azure VM, this flag specifies that it should connect to one of the private IPs of the VM. It requires connectivity to the private IP.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Interactive, ResourceId
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Ssh.Models.PSSshConfigEntry

## NOTES

## RELATED LINKS
[Login to a Linux VM by using Azure AD](https://learn.microsoft.com/en-us/azure/active-directory/devices/howto-vm-sign-in-azure-ad-linux)
[Install OpenSSH for Windows](https://learn.microsoft.com/en-us/windows-server/administration/openssh/openssh_install_firstuse?tabs=gui)