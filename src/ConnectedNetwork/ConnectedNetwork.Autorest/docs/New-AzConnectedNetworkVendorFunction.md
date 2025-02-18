---
external help file:
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/new-azconnectednetworkvendorfunction
schema: 2.0.0
---

# New-AzConnectedNetworkVendorFunction

## SYNOPSIS
Creates or updates a vendor network function.
This operation can take up to 6 hours to complete.
This is expected service behavior.

## SYNTAX

```
New-AzConnectedNetworkVendorFunction -LocationName <String> -ServiceKey <String> -VendorName <String>
 [-SubscriptionId <String>] [-SkuType <SkuType>]
 [-VendorConfiguration <INetworkFunctionVendorConfiguration[]>]
 [-VendorProvisioningState <VendorProvisioningState>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a vendor network function.
This operation can take up to 6 hours to complete.
This is expected service behavior.

## EXAMPLES

### Example 1: New-AzConnectedNetworkVendorFunction
```powershell
$ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
$ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
$keyData = @{keyData = "ssh-rsa\AAAAB3NzaC1yc2EAAAADAQABAAABAQCyMpVbBgu0kftv1k+z1c3NtcB5CVDoo/X9X1LE2JUjlLlo0luEkFGJk61i53BhiTSTeRmQXN8hAZ7sn4MDUmZK7fWcHouZ2fsJo+ehses3wQPLubWBFw2L/hoSTyXifXMbEBu9SxHgqf1CEKQcvdNiWf4U7npXwjweXW9DtsF5E7h4kxhKJKFI4sNFTIX0IwUB15QEVHoBs92kDwH3fBH3kZZCMBJE/u6kT+XB22crRKkIGlp3a9gcogtOCvP+3xmsP7hjw5+nHxMUwkc/6kYyfTeLwvfI4xrTWpnB5xufts5LW5/U5GOXVg97ix9EXgiV0czThowG5K2xQ649UlJb redmond\user@n1-azuredev1"; path = $Null}
$keys = @{ }
$key += $keyData
$vendorconf = New-AzConnectedNetworkFunctionVendorConfigurationObject -NetworkInterface $ip1,$ip2 -RoleName hpehss -OSProfileAdminUsername MecUser -OSProfileCustomData $customData -OSProfileCustomDataRequired $True -SshPublicKey $key
$vendorvnf1 = New-AzConnectedNetworkVendorFunction -LocationName eastus2euap -ServiceKey b78d39-xxxx-xxxx-00946c5 -SubscriptionId xxxx-4444-xxxx-4444 -VendorName myVendor -VendorConfiguration $vendorconf -SkuType EvolvedPacketCore -VendorProvisioningState Provisioning
```

Creating network interfaces with dynamic method allocation and ip version to IPv4.
And using these to create two network configuration objects with vm switch type.
Creating a ssh key identity, Then using those to create vendor configuration object with role name hpehss, custom data, keyData and network interface array.
Using this to create vendor NF with the specified service key, vendor subscription, location eastus2euap, vendor name myVendor, sku type EvolvedPacketCore, vendor provisioning state Provisioning.

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

### -LocationName
The Azure region where the network function resource was created by the customer.

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

### -ServiceKey
The GUID for the vendor network function.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.SkuType
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VendorConfiguration
An array of network function vendor configurations.
To construct, see NOTES section for VENDORCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.INetworkFunctionVendorConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VendorName
The name of the vendor.

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

### -VendorProvisioningState
The vendor controlled provisioning state of the vendor network function.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Support.VendorProvisioningState
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedNetwork.Models.Api20210501.IVendorNetworkFunction

## NOTES

## RELATED LINKS

