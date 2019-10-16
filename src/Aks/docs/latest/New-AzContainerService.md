---
external help file:
Module Name: Az.ContainerService
online version: https://docs.microsoft.com/en-us/powershell/module/az.containerservice/new-azcontainerservice
schema: 2.0.0
---

# New-AzContainerService

## SYNOPSIS
Creates or updates a container service with the specified configuration of orchestrator, masters, and agents.

## SYNTAX

### CreateExpanded (Default)
```
New-AzContainerService -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 [-AgentPoolProfile <IContainerServiceAgentPoolProfile[]>] [-CustomProfileOrchestrator <String>]
 [-KeyVaultSecretRefSecretName <String>] [-KeyVaultSecretRefVaultId <String>]
 [-KeyVaultSecretRefVersion <String>] [-LinuxProfileAdminUsername <String>] [-MasterProfileCount <Count>]
 [-MasterProfileDnsPrefix <String>] [-MasterProfileFirstConsecutiveStaticIP <String>]
 [-MasterProfileOSDiskSizeGb <Int32>] [-MasterProfileStorageProfile <ContainerServiceStorageProfileTypes>]
 [-MasterProfileVMSize <ContainerServiceVMSizeTypes>] [-MasterProfileVnetSubnetId <String>]
 [-OrchestratorProfileOrchestratorType <ContainerServiceOrchestratorTypes>]
 [-OrchestratorProfileOrchestratorVersion <String>] [-ServicePrincipalProfileClientId <String>]
 [-ServicePrincipalProfileSecret <String>] [-SshPublicKey <IContainerServiceSshPublicKey[]>]
 [-Tag <Hashtable>] [-VMDiagnosticEnabled] [-WindowProfileAdminPassword <String>]
 [-WindowProfileAdminUsername <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzContainerService -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Parameter <IContainerService> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzContainerService -InputObject <IContainerServiceIdentity> -Parameter <IContainerService>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzContainerService -InputObject <IContainerServiceIdentity> -Location <String>
 [-AgentPoolProfile <IContainerServiceAgentPoolProfile[]>] [-CustomProfileOrchestrator <String>]
 [-KeyVaultSecretRefSecretName <String>] [-KeyVaultSecretRefVaultId <String>]
 [-KeyVaultSecretRefVersion <String>] [-LinuxProfileAdminUsername <String>] [-MasterProfileCount <Count>]
 [-MasterProfileDnsPrefix <String>] [-MasterProfileFirstConsecutiveStaticIP <String>]
 [-MasterProfileOSDiskSizeGb <Int32>] [-MasterProfileStorageProfile <ContainerServiceStorageProfileTypes>]
 [-MasterProfileVMSize <ContainerServiceVMSizeTypes>] [-MasterProfileVnetSubnetId <String>]
 [-OrchestratorProfileOrchestratorType <ContainerServiceOrchestratorTypes>]
 [-OrchestratorProfileOrchestratorVersion <String>] [-ServicePrincipalProfileClientId <String>]
 [-ServicePrincipalProfileSecret <String>] [-SshPublicKey <IContainerServiceSshPublicKey[]>]
 [-Tag <Hashtable>] [-VMDiagnosticEnabled] [-WindowProfileAdminPassword <String>]
 [-WindowProfileAdminUsername <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a container service with the specified configuration of orchestrator, masters, and agents.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.containerservice/new-azcontainerservice
```



## PARAMETERS

### -AgentPoolProfile
Properties of the agent pool.
To construct, see NOTES section for AGENTPOOLPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20170701.IContainerServiceAgentPoolProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomProfileOrchestrator
The name of the custom orchestrator to use.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.IContainerServiceIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultSecretRefSecretName
The secret name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultSecretRefVaultId
Key vault identifier.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultSecretRefVersion
The secret version.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LinuxProfileAdminUsername
The administrator username to use for Linux VMs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileCount
Number of masters (VMs) in the container service cluster.
Allowed values are 1, 3, and 5.
The default value is 1.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.Count
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileDnsPrefix
DNS prefix to be used to create the FQDN for the master pool.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileFirstConsecutiveStaticIP
FirstConsecutiveStaticIP used to specify the first static ip of masters.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileOSDiskSizeGb
OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool.
If you specify 0, it will apply the default osDisk size according to the vmSize specified.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileStorageProfile
Storage profile specifies what kind of storage used.
Choose from StorageAccount and ManagedDisks.
Leave it empty, we will choose for you based on the orchestrator choice.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ContainerServiceStorageProfileTypes
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileVMSize
Size of agent VMs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ContainerServiceVMSizeTypes
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterProfileVnetSubnetId
VNet SubnetID specifies the VNet's subnet identifier.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the container service in the specified subscription and resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: ContainerServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OrchestratorProfileOrchestratorType
The orchestrator to use to manage container service cluster resources.
Valid values are Kubernetes, Swarm, DCOS, DockerCE and Custom.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.ContainerServiceOrchestratorTypes
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OrchestratorProfileOrchestratorVersion
The version of the orchestrator to use.
You can specify the major.minor.patch part of the actual version.For example, you can specify version as "1.6.11".

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Container service.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20170701.IContainerService
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServicePrincipalProfileClientId
The ID for the service principal.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServicePrincipalProfileSecret
The secret password associated with the service principal in plain text.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SshPublicKey
The list of SSH public keys used to authenticate with Linux-based VMs.
Only expect one key specified.
To construct, see NOTES section for SSHPUBLICKEY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20170701.IContainerServiceSshPublicKey[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMDiagnosticEnabled
Whether the VM diagnostic agent is provisioned on the VM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowProfileAdminPassword
The administrator password to use for Windows VMs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WindowProfileAdminUsername
The administrator username to use for Windows VMs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20170701.IContainerService

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.IContainerServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20170701.IContainerService

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### AGENTPOOLPROFILE <IContainerServiceAgentPoolProfile[]>: Properties of the agent pool.
  - `Name <String>`: Unique name of the agent pool profile in the context of the subscription and resource group.
  - `VMSize <ContainerServiceVMSizeTypes>`: Size of agent VMs.
  - `[Count <Int32?>]`: Number of agents (VMs) to host docker containers. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. 
  - `[DnsPrefix <String>]`: DNS prefix to be used to create the FQDN for the agent pool.
  - `[OSDiskSizeGb <Int32?>]`: OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.
  - `[OSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
  - `[Port <Int32[]>]`: Ports number array used to expose on this agent pool. The default opened ports are different based on your choice of orchestrator.
  - `[StorageProfile <ContainerServiceStorageProfileTypes?>]`: Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will choose for you based on the orchestrator choice.
  - `[VnetSubnetId <String>]`: VNet SubnetID specifies the VNet's subnet identifier.

#### INPUTOBJECT <IContainerServiceIdentity>: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[ContainerServiceName <String>]`: The name of the container service in the specified subscription and resource group.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of a supported Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceName <String>]`: The name of the managed cluster resource.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

#### PARAMETER <IContainerService>: Container service.
  - `Location <String>`: Resource location
  - `CustomProfileOrchestrator <String>`: The name of the custom orchestrator to use.
  - `KeyVaultSecretRefSecretName <String>`: The secret name.
  - `KeyVaultSecretRefVaultId <String>`: Key vault identifier.
  - `LinuxProfileAdminUsername <String>`: The administrator username to use for Linux VMs.
  - `MasterProfileDnsPrefix <String>`: DNS prefix to be used to create the FQDN for the master pool.
  - `MasterProfileVMSize <ContainerServiceVMSizeTypes>`: Size of agent VMs.
  - `OrchestratorProfileOrchestratorType <ContainerServiceOrchestratorTypes>`: The orchestrator to use to manage container service cluster resources. Valid values are Kubernetes, Swarm, DCOS, DockerCE and Custom.
  - `ServicePrincipalProfileClientId <String>`: The ID for the service principal.
  - `SshPublicKey <IContainerServiceSshPublicKey[]>`: The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
    - `KeyData <String>`: Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without headers.
  - `VMDiagnosticEnabled <Boolean>`: Whether the VM diagnostic agent is provisioned on the VM.
  - `WindowProfileAdminPassword <String>`: The administrator password to use for Windows VMs.
  - `WindowProfileAdminUsername <String>`: The administrator username to use for Windows VMs.
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AgentPoolProfile <IContainerServiceAgentPoolProfile[]>]`: Properties of the agent pool.
    - `Name <String>`: Unique name of the agent pool profile in the context of the subscription and resource group.
    - `VMSize <ContainerServiceVMSizeTypes>`: Size of agent VMs.
    - `[Count <Int32?>]`: Number of agents (VMs) to host docker containers. Allowed values must be in the range of 1 to 100 (inclusive). The default value is 1. 
    - `[DnsPrefix <String>]`: DNS prefix to be used to create the FQDN for the agent pool.
    - `[OSDiskSizeGb <Int32?>]`: OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.
    - `[OSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
    - `[Port <Int32[]>]`: Ports number array used to expose on this agent pool. The default opened ports are different based on your choice of orchestrator.
    - `[StorageProfile <ContainerServiceStorageProfileTypes?>]`: Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will choose for you based on the orchestrator choice.
    - `[VnetSubnetId <String>]`: VNet SubnetID specifies the VNet's subnet identifier.
  - `[KeyVaultSecretRefVersion <String>]`: The secret version.
  - `[MasterProfileCount <Count?>]`: Number of masters (VMs) in the container service cluster. Allowed values are 1, 3, and 5. The default value is 1.
  - `[MasterProfileFirstConsecutiveStaticIP <String>]`: FirstConsecutiveStaticIP used to specify the first static ip of masters.
  - `[MasterProfileOSDiskSizeGb <Int32?>]`: OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.
  - `[MasterProfileStorageProfile <ContainerServiceStorageProfileTypes?>]`: Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will choose for you based on the orchestrator choice.
  - `[MasterProfileVnetSubnetId <String>]`: VNet SubnetID specifies the VNet's subnet identifier.
  - `[OrchestratorProfileOrchestratorVersion <String>]`: The version of the orchestrator to use. You can specify the major.minor.patch part of the actual version.For example, you can specify version as "1.6.11".
  - `[ServicePrincipalProfileSecret <String>]`: The secret password associated with the service principal in plain text.

#### SSHPUBLICKEY <IContainerServiceSshPublicKey[]>: The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
  - `KeyData <String>`: Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without headers.

## RELATED LINKS

