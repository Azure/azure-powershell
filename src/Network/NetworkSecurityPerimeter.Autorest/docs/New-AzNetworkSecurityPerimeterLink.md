---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeterlink
schema: 2.0.0
---

# New-AzNetworkSecurityPerimeterLink

## SYNOPSIS
create NSP link resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String>] [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>]
 [-LocalInboundProfile <String[]>] [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 -Parameter <INspLink> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityPerimeterLink -InputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeter
```
New-AzNetworkSecurityPerimeterLink -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> -Parameter <INspLink>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityNetworkSecurityPerimeterExpanded
```
New-AzNetworkSecurityPerimeterLink -Name <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-Description <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityPerimeterLink -Name <String> -ResourceGroupName <String> -SecurityPerimeterName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
create NSP link resource.

## EXAMPLES

### Example 1: Create NetworkSecurityPerimeter Link
```powershell
$remotePerimeterId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers/Microsoft.Network/networkSecurityPerimeters/test-nsp-2"
New-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName test-nsp-1 -AutoApprovedRemotePerimeterResourceId $remotePerimeterId  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
AutoApprovedRemotePerimeterResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-2
Description                           : Auto Approved.
Id                                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-1/links/link-test-1
LocalInboundProfile                   : {profile-test-1}
LocalOutboundProfile                  : {*}
Name                                  : link-test-1
ProvisioningState                     : Succeeded
RemoteInboundProfile                  : {*}
RemoteOutboundProfile                 : {*}
RemotePerimeterGuid                   : 0000000-b1c5-4473-86d7-7755db0c6970
RemotePerimeterLocation               : eastuseuap
ResourceGroupName                     : rg-test-1
Status                                : Approved
SystemDataCreatedAt                   :
SystemDataCreatedBy                   :
SystemDataCreatedByType               :
SystemDataLastModifiedAt              :
SystemDataLastModifiedBy              :
SystemDataLastModifiedByType          :
Type                                  : Microsoft.Network/networkSecurityPerimeters/links
```

Create NetworkSecurityPerimeter Link

## PARAMETERS

### -AutoApprovedRemotePerimeterResourceId
Perimeter ARM Id for the remote NSP with which the link gets created in Auto-approval mode.
It should be used when the NSP admin have Microsoft.Network/networkSecurityPerimeters/linkPerimeter/action permission on the remote NSP resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaIdentityNetworkSecurityPerimeter, CreateViaIdentityNetworkSecurityPerimeterExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateViaIdentityNetworkSecurityPerimeter, CreateViaIdentityNetworkSecurityPerimeterExpanded
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
Parameter Sets: Create, CreateViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RemoteInboundProfile
Remote Inbound profile names to which Inbound is allowed.
Use ['*'] to allow inbound to all profiles.
This property can only be updated in auto-approval mode.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded, CreateViaIdentityNetworkSecurityPerimeterExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

