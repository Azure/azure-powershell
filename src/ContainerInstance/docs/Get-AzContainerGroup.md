---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module/az.containerinstance/get-azcontainergroup
schema: 2.0.0
---

# Get-AzContainerGroup

## SYNOPSIS
Gets the properties of the specified container group in the specified subscription and resource group.
The operation returns the properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.

## SYNTAX

### List (Default)
```
Get-AzContainerGroup [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerGroup -InputObject <IContainerInstanceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzContainerGroup -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified container group in the specified subscription and resource group.
The operation returns the properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.

## EXAMPLES

### Example 1: List all container groups in the current subscription
```powershell
PS C:\> Get-AzContainerGroup

Location Name           Type
-------- ----           ----
eastus   bez-cg1         Microsoft.ContainerInstance/containerGroups
eastus   bez-cg2        Microsoft.ContainerInstance/containerGroups
```

This command gets all container groups in the current subscription.

### Example 2: Get a specific container group
```powershell
PS C:\> Get-AzContainerGroup -Name test-cg1 -ResourceGroupName test-rg | fl


Container                      : {test-container1}
DnsConfigNameServer            :
DnsConfigOption                :
DnsConfigSearchDomain          :
EncryptionPropertyKeyName      :
EncryptionPropertyKeyVersion   :
EncryptionPropertyVaultBaseUrl :
IPAddressDnsNameLabel          :
IPAddressFqdn                  :
IPAddressIP                    : 000.000.000.000
IPAddressPort                  : {Microsoft.Azure.PowerShell.Cmdlets.ContainerInsta 
                                 nce.Models.Api20210301.Port, Microsoft.Azure.Power 
                                 Shell.Cmdlets.ContainerInstance.Models.Api20210301 
                                 .Port}
IPAddressType                  : Public
Id                             : /subscriptions/00000000-0000-0000-0000-000000000000 
                                 0/resourceGroups/test-rg/providers/Microsoft.Contai 
                                 nerInstance/containerGroups/test-cg1
IdentityPrincipalId            :
IdentityTenantId               :
IdentityType                   :
IdentityUserAssignedIdentity   : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.ContainerGroupIdentityUserAs 
                                 signedIdentities
ImageRegistryCredentials       :
InitContainer                  : {}
InstanceViewEvent              :
InstanceViewState              :
Location                       : eastus
LogAnalyticLogType             : 
LogAnalyticMetadata            : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.LogAnalyticsMetadata
LogAnalyticWorkspaceId         :
LogAnalyticWorkspaceKey        :
LogAnalyticWorkspaceResourceId : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.LogAnalyticsWorkspaceResourc 
                                 eId
Name                           : test-cg1
NetworkProfileId               :
OSType                         : Linux
ProvisioningState              : Succeeded
RestartPolicy                  : Never
Sku                            : Standard
Tag                            : Microsoft.Azure.PowerShell.Cmdlets.ContainerInstan 
                                 ce.Models.Api20210301.ResourceTags
Type                           : Microsoft.ContainerInstance/containerGroups        
Volume                         :
```

The command gets the specified container group.

### Example 3: Get container groups in a resource group
```powershell
PS C:\> Get-AzContainerGroup -ResourceGroupName test-rg

Location Name           Type
-------- ----           ----
eastus   bez-cg1         Microsoft.ContainerInstance/containerGroups
eastus   bez-cg2        Microsoft.ContainerInstance/containerGroups
```

The command gets the container groups in the resource group `test-rg`.

### Example 4: Get a container group by piping
```powershell
PS C:\> Update-AzContainerGroup -Name test-cg1 -ResourceGroupName test-rg -Tag @{"test"="value"} | Get-AzContainerGroup

Location Name   Type
-------- ----   ----
eastus   test-cg1 Microsoft.ContainerInstance/containerGroups
```

The command gets the updated container group by piping.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IContainerInstanceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the container group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ContainerGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IContainerInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IContainerInstanceIdentity>: Identity Parameter
  - `[ContainerGroupName <String>]`: The name of the container group.
  - `[ContainerName <String>]`: The name of the container instance.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The identifier for the physical azure location.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

