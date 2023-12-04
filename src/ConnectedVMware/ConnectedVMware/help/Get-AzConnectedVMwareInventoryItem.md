---
external help file: Az.ConnectedVMware-help.xml
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwareinventoryitem
schema: 2.0.0
---

# Get-AzConnectedVMwareInventoryItem

## SYNOPSIS
Implements InventoryItem GET method.

## SYNTAX

### List (Default)
```
Get-AzConnectedVMwareInventoryItem -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VcenterName <String> [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### GetViaIdentityVcenter
```
Get-AzConnectedVMwareInventoryItem -Name <String> -VcenterInputObject <IConnectedVMwareIdentity>
 [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### Get
```
Get-AzConnectedVMwareInventoryItem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VcenterName <String> [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzConnectedVMwareInventoryItem -InputObject <IConnectedVMwareIdentity> [-DefaultProfile <PSObject>]
 [-Break] [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

## DESCRIPTION
Implements InventoryItem GET method.

## EXAMPLES

### EXAMPLE 1
```
Get-AzConnectedVMwareInventoryItem -ResourceGroupName "test-rg" -VcenterName "test-vc"
```

### EXAMPLE 2
```
Get-AzConnectedVMwareInventoryItem -Name "vm-1528708" -VcenterName "test-vc" -ResourceGroupName "test-rg"
```

## PARAMETERS

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the inventoryItem.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityVcenter, Get
Aliases: InventoryItemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The Resource Group Name.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VcenterInputObject
Identity Parameter
To construct, see NOTES section for VCENTERINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
Parameter Sets: GetViaIdentityVcenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VcenterName
Name of the vCenter.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IConnectedVMwareIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IInventoryItem
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IConnectedVMwareIdentity\>: Identity Parameter
  \[ClusterName \<String\>\]: Name of the cluster.
  \[DatastoreName \<String\>\]: Name of the datastore.
  \[HostName \<String\>\]: Name of the host.
  \[Id \<String\>\]: Resource identity path
  \[InventoryItemName \<String\>\]: Name of the inventoryItem.
  \[ResourceGroupName \<String\>\]: The Resource Group Name.
  \[ResourcePoolName \<String\>\]: Name of the resourcePool.
  \[ResourceUri \<String\>\]: The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.
  \[SubscriptionId \<String\>\]: The Subscription ID.
  \[VcenterName \<String\>\]: Name of the vCenter.
  \[VirtualMachineTemplateName \<String\>\]: Name of the virtual machine template resource.
  \[VirtualNetworkName \<String\>\]: Name of the virtual network resource.

VCENTERINPUTOBJECT \<IConnectedVMwareIdentity\>: Identity Parameter
  \[ClusterName \<String\>\]: Name of the cluster.
  \[DatastoreName \<String\>\]: Name of the datastore.
  \[HostName \<String\>\]: Name of the host.
  \[Id \<String\>\]: Resource identity path
  \[InventoryItemName \<String\>\]: Name of the inventoryItem.
  \[ResourceGroupName \<String\>\]: The Resource Group Name.
  \[ResourcePoolName \<String\>\]: Name of the resourcePool.
  \[ResourceUri \<String\>\]: The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.
  \[SubscriptionId \<String\>\]: The Subscription ID.
  \[VcenterName \<String\>\]: Name of the vCenter.
  \[VirtualMachineTemplateName \<String\>\]: Name of the virtual machine template resource.
  \[VirtualNetworkName \<String\>\]: Name of the virtual network resource.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwareinventoryitem](https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwareinventoryitem)

