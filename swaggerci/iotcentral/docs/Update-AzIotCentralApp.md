---
external help file:
Module Name: Az.IotCentral
online version: https://docs.microsoft.com/en-us/powershell/module/az.iotcentral/update-aziotcentralapp
schema: 2.0.0
---

# Update-AzIotCentralApp

## SYNOPSIS
Update the metadata of an IoT Central application.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzIotCentralApp -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-DisplayName <String>] [-IdentityType <SystemAssignedServiceIdentityType>] [-NetworkRuleSetApplyToDevice]
 [-NetworkRuleSetApplyToIoTCentral] [-NetworkRuleSetDefaultAction <NetworkAction>]
 [-NetworkRuleSetIPRule <INetworkRuleSetIPRule[]>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-SkuName <AppSku>] [-Subdomain <String>] [-Tag <Hashtable>] [-Template <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzIotCentralApp -InputObject <IIotCentralIdentity> [-DisplayName <String>]
 [-IdentityType <SystemAssignedServiceIdentityType>] [-NetworkRuleSetApplyToDevice]
 [-NetworkRuleSetApplyToIoTCentral] [-NetworkRuleSetDefaultAction <NetworkAction>]
 [-NetworkRuleSetIPRule <INetworkRuleSetIPRule[]>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-SkuName <AppSku>] [-Subdomain <String>] [-Tag <Hashtable>] [-Template <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the metadata of an IoT Central application.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -DisplayName
The display name of the application.

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

### -IdentityType
Type of managed service identity (either system assigned, or none).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Support.SystemAssignedServiceIdentityType
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Models.IIotCentralIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkRuleSetApplyToDevice
Whether these rules apply for device connectivity to IoT Hub and Device Provisioning service associated with this application.

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

### -NetworkRuleSetApplyToIoTCentral
Whether these rules apply for connectivity via IoT Central web portal and APIs.

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

### -NetworkRuleSetDefaultAction
The default network action to apply.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Support.NetworkAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetIPRule
List of IP rules.
To construct, see NOTES section for NETWORKRULESETIPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Models.Api20211101Preview.INetworkRuleSetIPRule[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -PublicNetworkAccess
Whether requests from the public network are allowed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the IoT Central application.

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

### -ResourceName
The ARM resource name of the IoT Central application.

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

### -SkuName
The name of the SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Support.AppSku
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subdomain
The subdomain of the application.

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

### -SubscriptionId
The subscription identifier.

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

### -Tag
Instance tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Template
The ID of the application template, which is a blueprint that defines the characteristics and behaviors of an application.
Optional; if not specified, defaults to a blank blueprint and allows the application to be defined from scratch.

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

### Microsoft.Azure.PowerShell.Cmdlets.IotCentral.Models.IIotCentralIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IIotCentralIdentity>: Identity Parameter
  - `[GroupId <String>]`: The private link resource name.
  - `[Id <String>]`: Resource identity path
  - `[PrivateEndpointConnectionName <String>]`: The private endpoint connection name.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the IoT Central application.
  - `[ResourceName <String>]`: The ARM resource name of the IoT Central application.
  - `[SubscriptionId <String>]`: The subscription identifier.

NETWORKRULESETIPRULE <INetworkRuleSetIPRule[]>: List of IP rules.
  - `[FilterName <String>]`: The readable name of the IP rule.
  - `[IPMask <String>]`: The CIDR block defining the IP range.

## RELATED LINKS

