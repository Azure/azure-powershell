---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricnni
schema: 2.0.0
---

# New-AzNetworkFabricNni

## SYNOPSIS
Configuration used to setup CE-PE connectivity PUT Method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -UseOptionB <String> [-EgressAclId <String>]
 [-ExportRoutePolicy <IExportRoutePolicyInformation>] [-ImportRoutePolicy <IImportRoutePolicyInformation>]
 [-IngressAclId <String>] [-IsManagementType <String>] [-Layer2Configuration <ILayer2Configuration>]
 [-NniType <String>] [-NpbStaticRouteConfiguration <INpbStaticRouteConfiguration>]
 [-OptionBLayer3Configuration <INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkFabricExpanded
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricInputObject <IManagedNetworkFabricIdentity>
 -UseOptionB <String> [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicyInformation>]
 [-ImportRoutePolicy <IImportRoutePolicyInformation>] [-IngressAclId <String>] [-IsManagementType <String>]
 [-Layer2Configuration <ILayer2Configuration>] [-NniType <String>]
 [-NpbStaticRouteConfiguration <INpbStaticRouteConfiguration>]
 [-OptionBLayer3Configuration <INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityNetworkFabric
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricInputObject <IManagedNetworkFabricIdentity>
 -Body <INetworkToNetworkInterconnect> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Configuration used to setup CE-PE connectivity PUT Method.

## EXAMPLES

### Example 1: Create the Network To Network Interconnect Resource
```powershell
$optionBLayer3Configuration = @{
    PrimaryIpv4Prefix = "172.31.0.0/31"
    SecondaryIpv4Prefix = "172.31.0.20/31"
    PeerAsn = 28
    VlanId = 501
}
$layer2Configuration = @{
    Interface = @("/subscriptions//resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric/networkToNetworkInterconnects/example-interface")
    Mtu = 1500
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = $global:config.nni.importIpv4RoutePolicyId
    ImportIpv6RoutePolicyId = $global:config.nni.importIpv6RoutePolicyId
}
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = $global:config.nni.exportIpv4RoutePolicyId
    ExportIpv6RoutePolicyId = $global:config.nni.exportIpv6RoutePolicyId
}

New-AzNetworkFabricNni -Name $name -NetworkFabricName $nfName -ResourceGroupName $resourceGroupName -UseOptionB "True" -IsManagementType "True" -Layer2Configuration $layer2Configuration -NniType "CE" -OptionBLayer3Configuration $optionBLayer3Configuration -ExportRoutePolicy $ExportRoutePolicy -ImportRoutePolicy $importRoutePolicy
```

```output
AdministrativeState ConfigurationState EgressAclId ExportRoutePolicy Id
------------------- ------------------ ----------- ----------------- --
Disabled            Succeeded                                        /subscriptions/<identity>/resourceGroups/nfa-tool-t…
```

This command creates the Network To Network Interconnect resource.

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

### -Body
The Network To Network Interconnect resource definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnect
Parameter Sets: CreateViaIdentityNetworkFabric
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -EgressAclId
Egress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportRoutePolicy
Export Route Policy configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExportRoutePolicyInformation
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicy
Import Route Policy configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IImportRoutePolicyInformation
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressAclId
Ingress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsManagementType
Configuration to use NNI for Infrastructure Management.
Example: True/False.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -Layer2Configuration
Common properties for Layer2 Configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ILayer2Configuration
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Network to Network Interconnect.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkToNetworkInterconnectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: CreateViaIdentityNetworkFabricExpanded, CreateViaIdentityNetworkFabric
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkFabricName
Name of the Network Fabric.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NniType
Type of NNI used.
Example: CE | NPB

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
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

### -NpbStaticRouteConfiguration
NPB Static Route Configuration properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INpbStaticRouteConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionBLayer3Configuration
Common properties for Layer3Configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseOptionB
Based on this option layer3 parameters are mandatory.
Example: True/False

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnect

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnect

## NOTES

## RELATED LINKS
