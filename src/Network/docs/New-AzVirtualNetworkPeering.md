---
external help file: Az.Network-help.xml
Module Name:
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewayvpnprofile
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayVpnProfile

## SYNOPSIS
Generates VPN profile for P2S client of the virtual network gateway in the specified resource group.
Used for IKEV2 and radius based authentication.

## SYNTAX

### Generate (Default)
```
New-AzVirtualNetworkGatewayVpnProfile -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualNetworkGatewayName <String> [-Parameter <IVpnClientParameters>] [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GenerateExpanded
```
New-AzVirtualNetworkGatewayVpnProfile -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualNetworkGatewayName <String> [-PassThru] [-AuthenticationMethod <AuthenticationMethod>]
 [-ClientRootCertificate <String[]>] [-ProcessorArchitecture <ProcessorArchitecture>]
 [-RadiusServerAuthCertificate <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GenerateViaIdentityExpanded
```
New-AzVirtualNetworkGatewayVpnProfile -InputObject <INetworkIdentity> [-PassThru]
 [-AuthenticationMethod <AuthenticationMethod>] [-ClientRootCertificate <String[]>]
 [-ProcessorArchitecture <ProcessorArchitecture>] [-RadiusServerAuthCertificate <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzVirtualNetworkGatewayVpnProfile -InputObject <INetworkIdentity> [-Parameter <IVpnClientParameters>]
 [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Generates VPN profile for P2S client of the virtual network gateway in the specified resource group.
Used for IKEV2 and radius based authentication.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AuthenticationMethod
VPN client authentication method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AuthenticationMethod
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientRootCertificate
A list of client root certificates public certificate data encoded as Base-64 strings.
Optional parameter for external radius based authentication with EAPTLS.

```yaml
Type: System.String[]
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: GenerateViaIdentityExpanded, GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
Vpn Client Parameters for package generation

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVpnClientParameters
Parameter Sets: Generate, GenerateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

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

### -ProcessorArchitecture
VPN client Processor Architecture.
Possible values are: 'AMD64' and 'X86'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProcessorArchitecture
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RadiusServerAuthCertificate
The public certificate data for the radius server authentication certificate as a Base-64 encoded string.
Required only if external radius authentication has been configured with EAPTLS authentication.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
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
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
The name of the virtual network gateway.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
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

## OUTPUTS

### System.String
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewayvpnprofile](https://docs.microsoft.com/en-us/powershell/module/az.network/new-azvirtualnetworkgatewayvpnprofile)

