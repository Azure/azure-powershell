---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkvendorsku
schema: 2.0.0
---

# New-AzConnectedNetworkVendorSku

## SYNOPSIS
create a sku.
This operation can take up to 2 hours to complete.
This is expected service behavior.

## SYNTAX

### CreateExpanded (Default)
```
New-AzConnectedNetworkVendorSku -SkuName <String> -VendorName <String> [-SubscriptionId <String>]
 [-DeploymentMode <String>] [-ManagedApplicationParameter <Hashtable>]
 [-ManagedApplicationTemplate <Hashtable>]
 [-NetworkFunctionRoleConfigurationType <INetworkFunctionRoleConfiguration[]>] [-NetworkFunctionType <String>]
 [-Preview] [-SkuType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityVendorExpanded
```
New-AzConnectedNetworkVendorSku -SkuName <String> -VendorInputObject <IConnectedNetworkIdentity>
 [-DeploymentMode <String>] [-ManagedApplicationParameter <Hashtable>]
 [-ManagedApplicationTemplate <Hashtable>]
 [-NetworkFunctionRoleConfigurationType <INetworkFunctionRoleConfiguration[]>] [-NetworkFunctionType <String>]
 [-Preview] [-SkuType <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConnectedNetworkVendorSku -SkuName <String> -VendorName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConnectedNetworkVendorSku -SkuName <String> -VendorName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
create a sku.
This operation can take up to 2 hours to complete.
This is expected service behavior.

## EXAMPLES

### Example 1: New-AzConnectedNetworkVendorSku
```powershell
$role = New-AzConnectedNetworkFunctionRoleConfigurationObject -NetworkInterface $ip1,$ip2 -OSDiskName NetFoundry -OSDiskOstype Linux -OSDiskSizeGb 40 -OSProfileCustomDataRequired $False -OSProfileAdminUsername MecUser -RoleName hpehss -RoleType VirtualMachine -VirtualMachineSize "Standard_D3_v2" -SshPublicKey $key -StorageProfileDataDisk $storage -VhdUri "https://mecvdrvhd.blob.core.windows/myvhd.vhd"
New-AzConnectedNetworkVendorSku -SkuName sku1 -VendorName myVendor -SubscriptionId xxxxx-22222-xxxxx-22222 -SkuType VirtualMachine -DeploymentMode PrivateEdgeZone -NetworkFunctionRoleConfigurationType @($role)
```

Creating NF role configuration object wuth the specified details.
Using this to create sku with sku name sku1, vendor name myVendor, sku type VirtualMachine, deployment type PrivateEdgeZone.

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

### -DeploymentMode
The sku deployment mode.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedApplicationParameter
The parameters for the managed application to be supplied by the vendor.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedApplicationTemplate
The template for the managed application deployment.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFunctionRoleConfigurationType
An array of network function role definitions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.INetworkFunctionRoleConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFunctionType
The network function type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
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

### -Preview
Indicates if the vendor sku is in preview mode.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the sku.

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

### -SkuType
The sku type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityVendorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VendorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IConnectedNetworkIdentity
Parameter Sets: CreateViaIdentityVendorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VendorName
The name of the vendor.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IConnectedNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.IVendorSku

## NOTES

## RELATED LINKS

