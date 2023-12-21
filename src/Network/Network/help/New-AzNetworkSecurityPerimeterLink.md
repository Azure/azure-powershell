---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeterlink
schema: 2.0.0
---

# New-AzNetworkSecurityPerimeterLink

## SYNOPSIS
Create NSP link resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>]
 [-LocalInboundProfile <String[]>] [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeterExpanded
```
New-AzNetworkSecurityPerimeterLink -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeter
```
New-AzNetworkSecurityPerimeterLink -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> -Parameter <INspLink>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] -Parameter <INspLink> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityPerimeterLink -InputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create NSP link resource.

## EXAMPLES

### EXAMPLE 1
```
/resourceGroups/psrg_ex/providers/Microsoft.Network/networkSecurityPerimeters/nsp7"
New-AzNetworkSecurityPerimeterLink -Name exlink3 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

### EXAMPLE 2
```
/resourceGroups/psrg_ex/providers/Microsoft.Network/networkSecurityPerimeters/nsp7"
New-AzNetworkSecurityPerimeterLink -Name exlink4 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

## PARAMETERS

### -AutoApprovedRemotePerimeterResourceId
Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode.
It should be used when the NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
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
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
A message passed to the owner of the remote NSP link resource with this connection request.
In case of Auto-approved flow, it is default to 'Auto Approved'.
Restricted to 140 chars.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
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
Type: INetworkSecurityPerimeterIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: String
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
Type: String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalInboundProfile
Local Inbound profile names to which Inbound is allowed.
Use \['*'\] to allow inbound to all profiles.
It's default value is \['*'\].

```yaml
Type: String[]
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NSP link.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityNetworkSecurityPerimeter, Create
Aliases: LinkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityPerimeterInputObject
Identity Parameter
To construct, see NOTES section for NETWORKSECURITYPERIMETERINPUTOBJECT properties and create a hash table.

```yaml
Type: INetworkSecurityPerimeterIdentity
Parameter Sets: CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
The network security perimeter link resource
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: INspLink
Parameter Sets: CreateViaIdentityNetworkSecurityPerimeter, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RemoteInboundProfile
Remote Inbound profile names to which Inbound is allowed.
Use \['*'\] to allow inbound to all profiles.
This property can only be updated in auto-approval mode.
It's default value is \['*'\].

```yaml
Type: String[]
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaIdentityExpanded
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
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityPerimeterName
The name of the network security perimeter.

```yaml
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases: NetworkSecurityPerimeterName, NSPName

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
Type: String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<INetworkSecurityPerimeterIdentity\>: Identity Parameter
  \[AccessRuleName \<String\>\]: The name of the NSP access rule.
  \[AssociationName \<String\>\]: The name of the NSP association.
  \[Id \<String\>\]: Resource identity path
  \[LinkName \<String\>\]: The name of the NSP link.
  \[LinkReferenceName \<String\>\]: The name of the NSP linkReference.
  \[Location \<String\>\]: The location of network security perimeter.
  \[NetworkSecurityPerimeterName \<String\>\]: The name of the network security perimeter.
  \[ProfileName \<String\>\]: The name of the NSP profile.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
  \[SubscriptionId \<String\>\]: The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

NETWORKSECURITYPERIMETERINPUTOBJECT \<INetworkSecurityPerimeterIdentity\>: Identity Parameter
  \[AccessRuleName \<String\>\]: The name of the NSP access rule.
  \[AssociationName \<String\>\]: The name of the NSP association.
  \[Id \<String\>\]: Resource identity path
  \[LinkName \<String\>\]: The name of the NSP link.
  \[LinkReferenceName \<String\>\]: The name of the NSP linkReference.
  \[Location \<String\>\]: The location of network security perimeter.
  \[NetworkSecurityPerimeterName \<String\>\]: The name of the network security perimeter.
  \[ProfileName \<String\>\]: The name of the NSP profile.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
  \[SubscriptionId \<String\>\]: The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

PARAMETER \<INspLink\>: The network security perimeter link resource
  \[AutoApprovedRemotePerimeterResourceId \<String\>\]: Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode.
It should be used when the NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.
  \[Description \<String\>\]: A message passed to the owner of the remote NSP link resource with this connection request.
In case of Auto-approved flow, it is default to 'Auto Approved'.
Restricted to 140 chars.
  \[LocalInboundProfile \<List\<String\>\>\]: Local Inbound profile names to which Inbound is allowed.
Use \['*'\] to allow inbound to all profiles.
It's default value is \['*'\].
  \[RemoteInboundProfile \<List\<String\>\>\]: Remote Inbound profile names to which Inbound is allowed.
Use \['*'\] to allow inbound to all profiles.
This property can only be updated in auto-approval mode.
It's default value is \['*'\].

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeterlink](https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeterlink)

