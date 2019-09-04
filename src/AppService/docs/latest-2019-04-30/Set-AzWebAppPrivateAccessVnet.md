---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/set-azwebappprivateaccessvnet
schema: 2.0.0
---

# Set-AzWebAppPrivateAccessVnet

## SYNOPSIS
Sets data around private site access enablement and authorized Virtual Networks that can access the site.

## SYNTAX

### PutExpanded (Default)
```
Set-AzWebAppPrivateAccessVnet -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Enabled]
 [-Kind <String>] [-VirtualNetwork <IPrivateAccessVirtualNetwork[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Put
```
Set-AzWebAppPrivateAccessVnet -Name <String> -ResourceGroupName <String> -Access <IPrivateAccess>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets data around private site access enablement and authorized Virtual Networks that can access the site.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Access
Description of the parameters of Private Access for a Web Site.
To construct, see NOTES section for ACCESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IPrivateAccess
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Enabled
Whether private access is enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the web app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualNetwork
The Virtual Networks (and subnets) allowed to access the site privately.
To construct, see NOTES section for VIRTUALNETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IPrivateAccessVirtualNetwork[]
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IPrivateAccess

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.IPrivateAccess

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ACCESS <IPrivateAccess>: Description of the parameters of Private Access for a Web Site.
  - `[Kind <String>]`: Kind of resource.
  - `[Enabled <Boolean?>]`: Whether private access is enabled or not.
  - `[VirtualNetwork <IPrivateAccessVirtualNetwork[]>]`: The Virtual Networks (and subnets) allowed to access the site privately.
    - `[Key <Int32?>]`: The key (ID) of the Virtual Network.
    - `[Name <String>]`: The name of the Virtual Network.
    - `[ResourceId <String>]`: The ARM uri of the Virtual Network
    - `[Subnet <IPrivateAccessSubnet[]>]`: A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean that all subnets are allowed within this Virtual Network.
      - `[Key <Int32?>]`: The key (ID) of the subnet.
      - `[Name <String>]`: The name of the subnet.

#### VIRTUALNETWORK <IPrivateAccessVirtualNetwork[]>: The Virtual Networks (and subnets) allowed to access the site privately.
  - `[Key <Int32?>]`: The key (ID) of the Virtual Network.
  - `[Name <String>]`: The name of the Virtual Network.
  - `[ResourceId <String>]`: The ARM uri of the Virtual Network
  - `[Subnet <IPrivateAccessSubnet[]>]`: A List of subnets that access is allowed to on this Virtual Network. An empty array (but not null) is interpreted to mean that all subnets are allowed within this Virtual Network.
    - `[Key <Int32?>]`: The key (ID) of the subnet.
    - `[Name <String>]`: The name of the subnet.

## RELATED LINKS

