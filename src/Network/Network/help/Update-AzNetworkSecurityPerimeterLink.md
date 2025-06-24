---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-aznetworksecurityperimeterlink
schema: 2.0.0
---

# Update-AzNetworkSecurityPerimeterLink

## SYNOPSIS
Updates a NSP Link

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkSecurityPerimeterLink -ResourceGroupName <String> -Name <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] [-AutoApprovedRemotePerimeterResourceId <String>]
 [-LocalInboundProfile <String[]>] [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkSecurityPerimeterLink -InputObject <INetworkSecurityPerimeterIdentity>
 [-AutoApprovedRemotePerimeterResourceId <String>] [-LocalInboundProfile <String[]>]
 [-RemoteInboundProfile <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a NSP Link

## EXAMPLES

### Example 1: Update NetworkSecurityPerimeter Link
```powershell
Update-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1  -LocalInboundProfile @('*') -RemoteInboundProfile @('*')
```

```output
AutoApprovedRemotePerimeterResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-2
Description                           : Auto Approved.
Id                                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-1/links/link-test-1
LocalInboundProfile                   : {*}
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

Update NetworkSecurityPerimeter Link

### Example 2: Update NetworkSecurityPerimeter Link via Identity
```powershell
$linkObj = Get-AzNetworkSecurityPerimeterLink -Name link-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Update-AzNetworkSecurityPerimeterLink -InputObject $linkObj -LocalInboundProfile @('profile-test-2')
```

```output
AutoApprovedRemotePerimeterResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-2
Description                           : Auto Approved.
Id                                    : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                        /Microsoft.Network/networkSecurityPerimeters/test-nsp-1/links/link-test-1
LocalInboundProfile                   : {profile-test-2}
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

Update NetworkSecurityPerimeter Link via Identity

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

### -AutoApprovedRemotePerimeterResourceId
Auto approved remote perimeter resource id

```yaml
Type: System.String
Parameter Sets: (All)
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
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalInboundProfile
Local inbound profiles

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Link.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: LinkName

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

### -RemoteInboundProfile
Remote inbound profiles

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityPerimeterName
The name of the network security perimeter

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: NetworkSecurityPerimeterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspLink

## NOTES

## RELATED LINKS
