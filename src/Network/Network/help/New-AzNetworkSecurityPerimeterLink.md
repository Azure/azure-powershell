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
 [-LocalInboundProfile <String[]>] [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeterExpanded
```
New-AzNetworkSecurityPerimeterLink -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeter
```
New-AzNetworkSecurityPerimeterLink -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> -Parameter <INspLink>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] -Parameter <INspLink> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityPerimeterLink -InputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create NSP link resource.

## EXAMPLES

### Example 1: Create network security perimeter link
```powershell
$remoteNsp = "/subscriptions/<SUBSCRIPTION_ID>/resourceGroups/psrg_ex/providers/Microsoft.Network/networkSecurityPerimeters/nsp7"
New-AzNetworkSecurityPerimeterLink -Name exlink3 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
Etag Name
---- ----
     exlink3
```

Create network security perimeter link

### Example 2: Create network security perimeter link
```powershell
$remoteNsp = "/subscriptions/<SUBSCRIPTION_ID>/resourceGroups/psrg_ex/providers/Microsoft.Network/networkSecurityPerimeters/nsp7"
New-AzNetworkSecurityPerimeterLink -Name exlink4 -ResourceGroupName psrg_ex -SecurityPerimeterName ext-nsp6 -AutoApprovedRemotePerimeterResourceId $remoteNsp  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
Etag Name
---- ----
     exlink4
```

Create network security perimeter link

## PARAMETERS

### -AutoApprovedRemotePerimeterResourceId
Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode.
It should be used when the NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.

```yaml
Type: System.String
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
Type: System.Management.Automation.PSObject
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
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
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

### -LocalInboundProfile
Local Inbound profile names to which Inbound is allowed.
Use ['*'] to allow inbound to all profiles.

```yaml
Type: System.String[]
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
Type: System.String
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink
Parameter Sets: CreateViaIdentityNetworkSecurityPerimeter, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteInboundProfile
Remote Inbound profile names to which Inbound is allowed.
Use ['*'] to allow inbound to all profiles.
This property can only be updated in auto-approval mode.

```yaml
Type: System.String[]
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
Type: System.String
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
Type: System.String
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink

## NOTES

## RELATED LINKS
