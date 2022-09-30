---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Ssh.dll-Help.xml
Module Name: Az.Ssh
online version:
schema: 2.0.0
---

# Enter-AzVM

## SYNOPSIS
Start interactive SSH session to an Azure Resource (currently supports Azure VMs and Arc Servers).
Users can login using AAD issued certificates or using local user credentials. We recommend login using AAD issued certificates.

## SYNTAX

### Interactive (Default)
```
Enter-AzVM -ResourceGroupName <String> -Name <String> [-PublicKeyFile <String>] [-PrivateKeyFile <String>]
 [-UsePrivateIp] [-LocalUser <String>] [-Port <String>] [-ResourceType <String>] [-CertificateFile <String>]
 [-SshArguments <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### IpAddress
```
Enter-AzVM -Ip <String> [-PublicKeyFile <String>] [-PrivateKeyFile <String>] [-LocalUser <String>]
 [-Port <String>] [-CertificateFile <String>] [-SshArguments <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Enter-AzVM -ResourceId <String> [-PublicKeyFile <String>] [-PrivateKeyFile <String>] [-UsePrivateIp]
 [-LocalUser <String>] [-Port <String>] [-CertificateFile <String>] [-SshArguments <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Start interactive SSH session to an Azure Resource (currently supports Azure VMs and Arc Servers).
Users can login using AAD issued certificates or using local user credentials. We recommend login using AAD issued certificates when possible.


## EXAMPLES

### Example 1: Connect to Azure Resource using AAD issued certificates
```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine
```
When a -LocalUser is not supplied, the cmdlet will attempt to login using Azure AD. This is currently only supported for resources running Linux OS.

### Example 2: Connect to Azure Resource using a Local User credentials
```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -LocalUser azureuser -PrivateKeyFile ./id_rsa -CertificateFile ./cert
```
Provide an SSH certificate and private key to authenticate via certificate-based authentication.

```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -LocalUser azureuser -PrivateKeyFile ./id_rsa
```
Provide a private key file to authenticate via key-based authentication.

```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -LocalUser azureuser
```
If no credentials are provided, authenticate via interactive username and password.

### Example 3: Connect to the Public Ip of an Azure Virtual Machine using AAD issued certificates
```powershell
PS C:\> Enter-AzVM -Ip 1.2.3.4
```

### Example 4: Provide the Resource Type of the target.
```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -ResourceType Microsoft.HybridCompute/machines
```

```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -ResourceType Microsoft.Compute/virtualMachines
```
This parameter is useful when there is more than one supported resource with the same name in the Resource Group.

### Example 5: Provide additional SSH arguments.
```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -vvv "-o" FowardX11=yes
```
The name of some SSH arguments conflicts with the cmdlet parameters. In those cases, you can provide such SSH parameters in quotation marks. 

### Example 6: Connect to Azure Resource using AAD certificate issued certificates and custom key files
```powershell
PS C:\> Enter-AzVM -ResourceGroupName myRg -Name myMachine -PrivateKeyFile ./id_rsa -PublicKeyFile ./id_rsa.pub
```
If custom key files are not provided, the cmdlet will generate the key pair.

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

### -PassThru
Returns true if connection is successful.

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

### -SshArguments
Additional SSH arguments passed to OpenSSH.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

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

### System.String[]

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
Set up to login to a Linux VM by using Azure AD: https://learn.microsoft.com/en-us/azure/active-directory/devices/howto-vm-sign-in-azure-ad-linux
Install OpenSSH for Windows: https://learn.microsoft.com/en-us/windows-server/administration/openssh/openssh_install_firstuse?tabs=gui