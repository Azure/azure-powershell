---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: FC6BC096-DBC4-48DA-A366-B87EB18A0496
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azvmss
schema: 2.0.0
---

# Get-AzVmss

## SYNOPSIS
Gets the properties of a VMSS.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzVmss [[-ResourceGroupName] <String>] [[-VMScaleSetName] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### FriendMethod
```
Get-AzVmss [[-ResourceGroupName] <String>] [[-VMScaleSetName] <String>] [-InstanceView] [-UserData]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### OSUpgradeHistoryMethodParameter
```
Get-AzVmss [[-ResourceGroupName] <String>] [[-VMScaleSetName] <String>] [-OSUpgradeHistory]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzVmss [-ResourceId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzVmss** cmdlet gets the model and instance view of a Virtual Machine Scale Set (VMSS).
The model view is the user specified properties of the virtual machine scale set.
The instance view is the instance level status of the virtual machine scale set.
Specify the *InstanceView* parameter to get only the instance view of a virtual machine scale set.

## EXAMPLES

### Example 1: Get the properties of a VMSS
```powershell
Get-AzVmss -ResourceGroupName "Group001" -VMScaleSetName "VMSS001"
```

```output
ResourceGroupName                           : Group001
Sku                                         :
  Name                                      : Standard_DS1_v2
  Tier                                      : Standard
  Capacity                                  : 2
UpgradePolicy                               :
  Mode                                      : Manual
VirtualMachineProfile                       :
  OsProfile                                 :
    ComputerNamePrefix                      : test
    AdminUsername                           : contoso
    WindowsConfiguration                    :
      ProvisionVMAgent                      : True
      EnableAutomaticUpdates                : True
  StorageProfile                            :
    ImageReference                          :
      Publisher                             : MicrosoftWindowsServer
      Offer                                 : WindowsServer
      Sku                                   : 2016-Datacenter
      Version                               : latest
    OsDisk                                  :
      Caching                               : None
      CreateOption                          : FromImage
      ManagedDisk                           :
        StorageAccountType                  : Premium_LRS
  NetworkProfile                            :
    NetworkInterfaceConfigurations[0]       :
      Name                                  : Group001
      Primary                               : True
      EnableAcceleratedNetworking           : False
      NetworkSecurityGroup                  :
        Id                                  : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/Group001
/providers/Microsoft.Network/networkSecurityGroups/Group001
      DnsSettings                           :
      IpConfigurations[0]                   :
        Name                                : Group001
        Subnet                              :
          Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/group001
/providers/Microsoft.Network/virtualNetworks/Group001/subnets/Group001
        PrivateIPAddressVersion             : IPv4
        LoadBalancerBackendAddressPools[0]  :
          Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/group001
/providers/Microsoft.Network/loadBalancers/Group001/backendAddressPools/Group001
        LoadBalancerInboundNatPools[0]      :
          Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/group001
/providers/Microsoft.Network/loadBalancers/Group001/inboundNatPools/Group001
        LoadBalancerInboundNatPools[1]      :
          Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/group001
/providers/Microsoft.Network/loadBalancers/Group001/inboundNatPools/Group001
      EnableIPForwarding                    : False
ProvisioningState                           : Succeeded
Overprovision                               : True
UniqueId                                    : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SinglePlacementGroup                        : False
Id                                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/Group001/
providers/Microsoft.Compute/virtualMachineScaleSets/VMSS001
Name                                        : VMSS001
Type                                        : Microsoft.Compute/virtualMachineScaleSets
Location                                    : eastus
Tags                                        : {}
```

This command gets the properties of the VMSS named VMSS001 that belongs to the resource group named Group001.
Since the command does not specify the *InstanceView* switch parameter, the cmdlet gets the model view of the virtual machine scale set.

### Example 2: Get all Vmss in a resource group
```powershell
Get-AzVmss -ResourceGroupName "Group001"
```

```output
ResourceGroupName                               Name       Location             Sku Capacity ProvisioningState
-----------------                               ----       --------             --- -------- -----------------
Group001                                       VMSS001      eastus Standard_DS1_v2        2         Succeeded
Group001                                       VMSS002      eastus     Standard_A1        2         Succeeded
```

Get all Vmss in resource group "Group001"

### Example 3: Get all Vmss in a subscription
```powershell
Get-AzVmss
```

```output
ResourceGroupName                               Name       Location             Sku Capacity ProvisioningState
-----------------                               ----       --------             --- -------- -----------------
Group001                                       VMSS001      eastus Standard_DS1_v2        2         Succeeded
Group001                                       VMSS002      eastus     Standard_A1        2         Succeeded
Group002                                       VMSS003      eastus     Standard_A1        1         Succeeded
Group002                                       VMSS004      eastus Standard_DS1_v2        2         Succeeded
```

Get all Vmss in subscription.

### Example 4: Get all Vmss using filtering
```powershell
Get-AzVmss -Name VMSS00*
```

```output
ResourceGroupName                               Name       Location             Sku Capacity ProvisioningState
-----------------                               ----       --------             --- -------- -----------------
Group001                                       VMSS001      eastus Standard_DS1_v2        2         Succeeded
Group001                                       VMSS002      eastus     Standard_A1        2         Succeeded
Group002                                       VMSS003      eastus     Standard_A1        1         Succeeded
Group002                                       VMSS004      eastus Standard_DS1_v2        2         Succeeded
```

Get all Vmss in subscription that start with "VMSS00".

### Example 5: Get the Vmss with a UserData value
```powershell
Get-AzVmss -ResourceGroupName <RESOURCE GROUP NAME> -VMScaleSetName <VMSS NAME> -InstanceView:$false -UserData;
```

```output
ResourceGroupName                           : <RESOURCE GROUP NAME>
Sku                                         :
  Name                                      : Standard_DS1_v2
  Tier                                      : Standard
  Capacity                                  : 2
UpgradePolicy                               :
  Mode                                      : Manual
ProvisioningState                           : Succeeded
Overprovision                               : True
DoNotRunExtensionsOnOverprovisionedVMs      : False
UniqueId                                    : <UNIQUE ID>
SinglePlacementGroup                        : False
Id                                          : /subscriptions/<SUBSCRIPTION ID>/resourceGroups/<RESOURCE GROUP NAME>/providers/Microsoft.Compute/virtualMachineScaleSets/<VMSS NAME>
Name                                        : usdvmss
Type                                        : Microsoft.Compute/virtualMachineScaleSets
Location                                    : eastus
Tags                                        :
{"azsecpack":"nonprod","platformsettings.host_environment.service.platform_optedin_for_rootcerts":"true"}
VirtualMachineProfile                       :
  OsProfile                                 :
    ComputerNamePrefix                      : <PREFIX>
    AdminUsername                           : <USERNAME>
    WindowsConfiguration                    :
      ProvisionVMAgent                      : True
      EnableAutomaticUpdates                : True
  StorageProfile                            :
    ImageReference                          :
      Publisher                             : MicrosoftWindowsServer
      Offer                                 : WindowsServer
      Sku                                   : 2016-Datacenter
      Version                               : latest
    OsDisk                                  :
      Caching                               : None
      CreateOption                          : FromImage
      DiskSizeGB                            : 127
      OsType                                : Windows
      ManagedDisk                           :
        StorageAccountType                  : Premium_LRS
  NetworkProfile                            :
    NetworkInterfaceConfigurations[0]       :
      Name                                  : <VMSS NAME>
      Primary                               : True
      EnableAcceleratedNetworking           : False
      DnsSettings                           :
      IpConfigurations[0]                   :
        Name                                : <VMSS NAME>
        Subnet                              :
          Id                                : /subscriptions/<SUBSCRIPTION ID>/resourceGroups/<RESOURCE GROUP NAME>/providers/Microsoft.Network/virtualNetworks/<VMSS NAME>/subnets/<VMSS NAME>
        PrivateIPAddressVersion             : IPv4
        LoadBalancerBackendAddressPools[0]  :
          Id                                : /subscriptions/<SUBSCRIPTION ID>/resourceGroups/<RESOURCE GROUP NAME>/providers/Microsoft.Network/loadBalancers/<VMSS NAME>/backendAddressPools/<VMSS NAME>
        LoadBalancerInboundNatPools[0]      :
          Id                                : /subscriptions/<SUBSCRIPTION ID>/resourceGroups/<RESOURCE GROUP NAME>/providers/Microsoft.Network/loadBalancers/<VMSS NAME>/inboundNatPools/<VMSS NAME>
        LoadBalancerInboundNatPools[1]      :
          Id                                : /subscriptions/<SUBSCRIPTION ID>/resourceGroups/<RESOURCE GROUP NAME>/providers/Microsoft.Network/loadBalancers/<VMSS NAME>/inboundNatPools/<VMSS NAME>
      EnableIPForwarding                    : False
  ExtensionProfile                          :
    Extensions[0]                           :
      Name                                  : Microsoft.Azure.Security.AntimalwareSignature.AntimalwareConfiguration
      Publisher                             : Microsoft.Azure.Security.AntimalwareSignature
      Type                                  : AntimalwareConfiguration
      TypeHandlerVersion                    : 2.0
      AutoUpgradeMinorVersion               : True
      EnableAutomaticUpgrade                : True
      Settings                              : {}
    Extensions[1]                           :
      Name                                  : Microsoft.Azure.Geneva.GenevaMonitoring
      Publisher                             : Microsoft.Azure.Geneva
      Type                                  : GenevaMonitoring
      TypeHandlerVersion                    : 2.0
      AutoUpgradeMinorVersion               : True
      EnableAutomaticUpgrade                : True
      Settings                              : {}
  UserData                                  : dQBwAGQAYQB0AGUAIAB2AG0AcwBzAA==
```

The UserData value must be Base64 encoded. This command assumes you have created a Vmss with a UserData value. 

### Example 6: Get a Virtual Machine Scale Set via its ResourceId.
```powershell
$rgname = "ResourceGroupName";
$loc = "eastus";
New-AzResourceGroup -Name $rgname -Location $loc;

$vmssSize = 'Standard_D4s_v3';
$vmssName1 = 'vmss1' + $rgname;
$imageName = "Win2019Datacenter";
$adminUsername = <Username>;
$adminPassword = ConvertTo-SecureString -String "****" -AsPlainText -Force;
$cred = New-Object System.Management.Automation.PSCredential($adminUsername, $adminPassword);

$result = New-AzVmss -ResourceGroupName $rgname -Credential $cred -VMScaleSetName $vmssName1 -ImageName $imageName;

$vmss = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName1;
$vmssId = $vmss.Id;
$vmssGet = Get-AzVmss -ResourceId $vmssId;
```

Make a Vmss then get that same Vmss via its ARM resource Id. 

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -InstanceView
Indicates that this cmdlet gets only the instance view of the virtual machine scale set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: FriendMethod
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSUpgradeHistory
Indicates that this cmdlet lists the os upgrade history of the virtual machine scale set.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: OSUpgradeHistoryMethodParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the Resource Group of the VMSS.

```yaml
Type: System.String
Parameter Sets: DefaultParameter, FriendMethod, OSUpgradeHistoryMethodParameter
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
The ARM resource id specifying the specific virtual machine scale set object you want returned.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserData
UserData for the Vmss, which will be base-64 encoded. Customer should not pass any secrets in here.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: FriendMethod
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VMScaleSetName
Species the name of the VMSS.

```yaml
Type: System.String
Parameter Sets: DefaultParameter, FriendMethod, OSUpgradeHistoryMethodParameter
Aliases: Name

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## NOTES

## RELATED LINKS

[New-AzVmss](./New-AzVmss.md)

[Remove-AzVmss](./Remove-AzVmss.md)

[Restart-AzVmss](./Restart-AzVmss.md)

[Set-AzVmss](./Set-AzVmss.md)

[Start-AzVmss](./Start-AzVmss.md)

[Stop-AzVmss](./Stop-AzVmss.md)

[Update-AzVmss](./Update-AzVmss.md)
