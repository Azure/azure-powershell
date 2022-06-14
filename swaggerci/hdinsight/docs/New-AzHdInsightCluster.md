---
external help file:
Module Name: Az.HdInsight
online version: https://docs.microsoft.com/en-us/powershell/module/az.hdinsight/new-azhdinsightcluster
schema: 2.0.0
---

# New-AzHdInsightCluster

## SYNOPSIS
Creates a new HDInsight cluster with the specified parameters.

## SYNTAX

```
New-AzHdInsightCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ClientGroupInfoGroupId <String>] [-ClientGroupInfoGroupName <String>]
 [-ClusterDefinitionBlueprint <String>] [-ClusterDefinitionComponentVersion <Hashtable>]
 [-ClusterDefinitionConfiguration <IAny>] [-ClusterDefinitionKind <String>] [-ClusterVersion <String>]
 [-ComputeIsolationPropertyEnableComputeIsolation] [-ComputeIsolationPropertyHostSku <String>]
 [-ComputeProfileRole <IRole[]>] [-DiskEncryptionPropertyEncryptionAlgorithm <JsonWebKeyEncryptionAlgorithm>]
 [-DiskEncryptionPropertyEncryptionAtHost] [-DiskEncryptionPropertyKeyName <String>]
 [-DiskEncryptionPropertyKeyVersion <String>] [-DiskEncryptionPropertyMsiResourceId <String>]
 [-DiskEncryptionPropertyVaultUri <String>] [-EncryptionInTransitPropertyIsEncryptionInTransitEnabled]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-KafkaRestPropertyConfigurationOverride <Hashtable>] [-Location <String>] [-MinSupportedTlsVersion <String>]
 [-NetworkPropertyPrivateLink <PrivateLink>]
 [-NetworkPropertyResourceProviderConnection <ResourceProviderConnection>] [-OSType <OSType>]
 [-PrivateLinkConfiguration <IPrivateLinkConfiguration[]>] [-SecurityProfileAaddsResourceId <String>]
 [-SecurityProfileClusterUsersGroupDN <String[]>] [-SecurityProfileDirectoryType <DirectoryType>]
 [-SecurityProfileDomain <String>] [-SecurityProfileDomainUsername <String>]
 [-SecurityProfileDomainUserPassword <SecureString>] [-SecurityProfileLdapsUrl <String[]>]
 [-SecurityProfileMsiResourceId <String>] [-SecurityProfileOrganizationalUnitDn <String>]
 [-StorageProfileStorageaccount <IStorageAccount[]>] [-Tag <Hashtable>] [-Tier <Tier>] [-Zone <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new HDInsight cluster with the specified parameters.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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
```

### -ClientGroupInfoGroupId
The AAD security group id.

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

### -ClientGroupInfoGroupName
The AAD security group name.

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

### -ClusterDefinitionBlueprint
The link to the blueprint.

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

### -ClusterDefinitionComponentVersion
The versions of different services in the cluster.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterDefinitionConfiguration
The cluster configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.IAny
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterDefinitionKind
The type of cluster.

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

### -ClusterVersion
The version of the cluster.

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

### -ComputeIsolationPropertyEnableComputeIsolation
The flag indicates whether enable compute isolation or not.

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

### -ComputeIsolationPropertyHostSku
The host sku.

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

### -ComputeProfileRole
The list of roles in the cluster.
To construct, see NOTES section for COMPUTEPROFILEROLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IRole[]
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskEncryptionPropertyEncryptionAlgorithm
Algorithm identifier for encryption, default RSA-OAEP.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.JsonWebKeyEncryptionAlgorithm
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskEncryptionPropertyEncryptionAtHost
Indicates whether or not resource disk encryption is enabled.

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

### -DiskEncryptionPropertyKeyName
Key name that is used for enabling disk encryption.

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

### -DiskEncryptionPropertyKeyVersion
Specific key version that is used for enabling disk encryption.

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

### -DiskEncryptionPropertyMsiResourceId
Resource ID of Managed Identity that is used to access the key vault.

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

### -DiskEncryptionPropertyVaultUri
Base key vault URI where the customers key is located eg.
https://myvault.vault.azure.net

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

### -EncryptionInTransitPropertyIsEncryptionInTransitEnabled
Indicates whether or not inter cluster node communication is encrypted in transit.

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

### -IdentityType
The type of identity used for the cluster.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The list of user identities associated with the cluster.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaRestPropertyConfigurationOverride
The configurations that need to be overriden.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the cluster.

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

### -MinSupportedTlsVersion
The minimal supported tls version.

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
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkPropertyPrivateLink
Indicates whether or not private link is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.PrivateLink
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkPropertyResourceProviderConnection
The direction for the resource provider connection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.ResourceProviderConnection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -OSType
The type of operating system.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.OSType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkConfiguration
The private link configurations.
To construct, see NOTES section for PRIVATELINKCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IPrivateLinkConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

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

### -SecurityProfileAaddsResourceId
The resource ID of the user's Azure Active Directory Domain Service.

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

### -SecurityProfileClusterUsersGroupDN
Optional.
The Distinguished Names for cluster user groups

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

### -SecurityProfileDirectoryType
The directory type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.DirectoryType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityProfileDomain
The organization's active directory domain.

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

### -SecurityProfileDomainUsername
The domain user account that will have admin privileges on the cluster.

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

### -SecurityProfileDomainUserPassword
The domain admin password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityProfileLdapsUrl
The LDAPS protocol URLs to communicate with the Active Directory.

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

### -SecurityProfileMsiResourceId
User assigned identity that has permissions to read and create cluster-related artifacts in the user's AADDS.

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

### -SecurityProfileOrganizationalUnitDn
The organizational unit within the Active Directory to place the cluster and service accounts.

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

### -StorageProfileStorageaccount
The list of storage accounts in the cluster.
To construct, see NOTES section for STORAGEPROFILESTORAGEACCOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IStorageAccount[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tier
The cluster tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Support.Tier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
The availability zones.

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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.ICluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


COMPUTEPROFILEROLE <IRole[]>: The list of roles in the cluster.
  - `[CapacityMaxInstanceCount <Int32?>]`: The maximum instance count of the cluster
  - `[CapacityMinInstanceCount <Int32?>]`: The minimum instance count of the cluster
  - `[DataDisksGroup <IDataDisksGroups[]>]`: The data disks groups for the role.
    - `[DisksPerNode <Int32?>]`: The number of disks per node.
  - `[EncryptDataDisk <Boolean?>]`: Indicates whether encrypt the data disks.
  - `[HardwareProfileVMSize <String>]`: The size of the VM
  - `[LinuxOperatingSystemProfilePassword <String>]`: The password.
  - `[LinuxOperatingSystemProfileUsername <String>]`: The username.
  - `[MinInstanceCount <Int32?>]`: The minimum instance count of the cluster.
  - `[Name <String>]`: The name of the role.
  - `[RecurrenceSchedule <IAutoscaleSchedule[]>]`: Array of schedule-based autoscale rules
    - `[Day <DaysOfWeek[]>]`: Days of the week for a schedule-based autoscale rule
    - `[TimeAndCapacityMaxInstanceCount <Int32?>]`: The maximum instance count of the cluster
    - `[TimeAndCapacityMinInstanceCount <Int32?>]`: The minimum instance count of the cluster
    - `[TimeAndCapacityTime <String>]`: 24-hour time in the form xx:xx
  - `[RecurrenceTimeZone <String>]`: The time zone for the autoscale schedule times
  - `[ScriptAction <IScriptAction[]>]`: The list of script actions on the role.
    - `Name <String>`: The name of the script action.
    - `Parameter <String>`: The parameters for the script provided.
    - `Uri <String>`: The URI to the script.
  - `[SshProfilePublicKey <ISshPublicKey[]>]`: The list of SSH public keys.
    - `[CertificateData <String>]`: The certificate for SSH.
  - `[TargetInstanceCount <Int32?>]`: The instance count of the cluster.
  - `[VMGroupName <String>]`: The name of the virtual machine group.
  - `[VirtualNetworkProfileId <String>]`: The ID of the virtual network.
  - `[VirtualNetworkProfileSubnet <String>]`: The name of the subnet.

PRIVATELINKCONFIGURATION <IPrivateLinkConfiguration[]>: The private link configurations.
  - `GroupId <String>`: The HDInsight private linkable sub-resource name to apply the private link configuration to. For example, 'headnode', 'gateway', 'edgenode'.
  - `IPConfiguration <IIPConfiguration[]>`: The IP configurations for the private link service.
    - `Name <String>`: The name of private link IP configuration.
    - `[Primary <Boolean?>]`: Indicates whether this IP configuration is primary for the corresponding NIC.
    - `[PrivateIPAddress <String>]`: The IP address.
    - `[PrivateIPAllocationMethod <PrivateIPAllocationMethod?>]`: The method that private IP address is allocated.
    - `[SubnetId <String>]`: The azure resource id.
  - `Name <String>`: The name of private link configuration.

STORAGEPROFILESTORAGEACCOUNT <IStorageAccount[]>: The list of storage accounts in the cluster.
  - `[Container <String>]`: The container in the storage account, only to be specified for WASB storage accounts.
  - `[FileSystem <String>]`: The filesystem, only to be specified for Azure Data Lake Storage Gen 2.
  - `[Fileshare <String>]`: The file share name.
  - `[IsDefault <Boolean?>]`: Whether or not the storage account is the default storage account.
  - `[Key <String>]`: The storage account access key.
  - `[MsiResourceId <String>]`: The managed identity (MSI) that is allowed to access the storage account, only to be specified for Azure Data Lake Storage Gen 2.
  - `[Name <String>]`: The name of the storage account.
  - `[ResourceId <String>]`: The resource ID of storage account, only to be specified for Azure Data Lake Storage Gen 2.
  - `[Saskey <String>]`: The shared access signature key.

## RELATED LINKS

