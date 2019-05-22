---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/update-azvpngatewaytag
schema: 2.0.0
---

# Update-AzVpnGatewayTag

## SYNOPSIS
Updates virtual wan vpn gateway tags.

## SYNTAX

### Update (Default)
```
Update-AzVpnGatewayTag -GatewayName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-VpnGatewayParameter <ITagsObject>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzVpnGatewayTag -GatewayName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Tag <ITagsObjectTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVpnGatewayTag -InputObject <INetworkIdentity> [-Tag <ITagsObjectTags>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzVpnGatewayTag -InputObject <INetworkIdentity> [-VpnGatewayParameter <ITagsObject>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates virtual wan vpn gateway tags.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -GatewayName
The name of the gateway.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name of the VpnGateway.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObjectTags
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnGatewayParameter
Tags object for patch operations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ITagsObject
Parameter Sets: Update, UpdateViaIdentity
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnGateway
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/update-azvpngatewaytag](https://docs.microsoft.com/en-us/powershell/module/az.network/update-azvpngatewaytag)

