---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azbastion
schema: 2.0.0
---

# Set-AzBastion

## SYNOPSIS
Updates the Bastion Resource.

## SYNTAX

```
Set-AzBastion -InputObject <PSBastion> [-Sku <String>] [-ScaleUnit <Int32>] [-EnableKerberos <Boolean>]
 [-DisableCopyPaste <Boolean>] [-EnableTunneling <Boolean>] [-EnableIpConnect <Boolean>]
 [-EnableShareableLink <Boolean>] [-EnableSessionRecording <Boolean>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzBastion** cmdlet can be used to update the Sku, Scale Units or Tags of an existing BastionHost resource.

## EXAMPLES

### Example 1
```powershell
Set-AzBastion -InputObject $bastionObj -Sku "Standard" -ScaleUnit 10 -Force
```

```output
Name                 : MyBastion
Id                   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/bastionHosts/MyBastion
Etag                 : W/"000"
Type                 : Microsoft.Network/bastionHosts
Location             : westus2
Tag                  :
TagsTable            :
ResourceGroupName    : MyRg
DnsName              : bst-00000000-0000-0000-0000-000000000001.test.bastion.azure.com
ResourceGuid         :
ProvisioningState    : Succeeded
IpConfigurationsText : [
                         {
                           "Subnet": {
                             "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/virtualNetworks/MyVnet/subnets/AzureBastionSubnet"
                           },
                           "PublicIpAddress": {
                             "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/publicIPAddresses/PublicIp1"
                           },
                           "ProvisioningState": "Succeeded",
                           "PrivateIpAllocationMethod": "Dynamic",
                           "Name": "IpConf",
                           "Etag": "W/\"000\"",
                           "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/bastionHosts/MyBastion/bastionHostIpConfigurations/IpConf"
                         }
                       ]
Sku                  : {
                         "Name": "Standard"
                       }
Scale Units          : 10
```

Updates BastionHost resource with Basic Sku and 2 Scale Units to Standard Sku and 10 Scale Units

### Example 2
<!-- Skip: Output cannot be splitted from code -->


```powershell
$bastionObj = Get-AzBastion -ResourceGroupName "MyRg" -Name "MyBastion"
$bastionObj

Name                 : MyBastion
Id                   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/bastionHosts/MyBastion
Etag                 : W/"000"
Type                 : Microsoft.Network/bastionHosts
Location             : westus2
Tag                  :
TagsTable            :
ResourceGroupName    : MyRg
DnsName              : bst-00000000-0000-0000-0000-000000000001.test.bastion.azure.com
ResourceGuid         :
ProvisioningState    : Succeeded
IpConfigurationsText : [
                         {
                           "Subnet": {
                             "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/virtualNetworks/MyVnet/subnets/AzureBastionSubnet"
                           },
                           "PublicIpAddress": {
                             "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/publicIPAddresses/PublicIp1"
                           },
                           "ProvisioningState": "Succeeded",
                           "PrivateIpAllocationMethod": "Dynamic",
                           "Name": "IpConf",
                           "Etag": "W/\"000\"",
                           "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/bastionHosts/MyBastion/bastionHostIpConfigurations/IpConf"
                         }
                       ]
Sku                  : {
                         "Name": "Basic"
                       }
Scale Units          : 2

$bastionObj.Sku.Name = "Standard"
$bastionObj.ScaleUnit = 50
Set-AzBastion -InputObject $bastionObj -Force
Name                 : MyBastion
Id                   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/bastionHosts/MyBastion
Etag                 : W/"000"
Type                 : Microsoft.Network/bastionHosts
Location             : westus2
Tag                  :
TagsTable            :
ResourceGroupName    : MyRg
DnsName              : bst-00000000-0000-0000-0000-000000000001.test.bastion.azure.com
ResourceGuid         :
ProvisioningState    : Succeeded
IpConfigurationsText : [
                         {
                           "Subnet": {
                             "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/virtualNetworks/MyVnet/subnets/AzureBastionSubnet"
                           },
                           "PublicIpAddress": {
                             "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/publicIPAddresses/PublicIp1"
                           },
                           "ProvisioningState": "Succeeded",
                           "PrivateIpAllocationMethod": "Dynamic",
                           "Name": "IpConf",
                           "Etag": "W/\"000\"",
                           "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/MyRg/providers/Microsoft.Network/bastionHosts/MyBastion/bastionHostIpConfigurations/IpConf"
                         }
                       ]
Sku                  : {
                         "Name": "Standard"
                       }
Scale Units          : 50
```

Updates BastionHost resource with Basic Sku and 2 Scale Units to Standard Sku and 50 Scale Units

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DisableCopyPaste
Copy and Paste

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnableIpConnect
IP Connect

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnableKerberos
Kerberos

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnableSessionRecording
Session Recording

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnableShareableLink
Shareable Link

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnableTunneling
Native Client

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Force
Ask for confirmation if you want to overwrite a resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
The BastionHost Object

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSBastion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ScaleUnit
The Bastion Scale Units

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 2
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Sku
The Bastion Sku Tier

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Basic, Standard, Premium

Required: False
Position: Named
Default value: Basic
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.Network.Models.PSBastion

### System.String

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Collections.Hashtable

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSBastion

## NOTES

## RELATED LINKS

[New-AzBastion](./New-AzBastion.md)

[Get-AzBastion](./Get-AzBastion.md)

[Remove-AzBastion](./Remove-AzBastion.md)
