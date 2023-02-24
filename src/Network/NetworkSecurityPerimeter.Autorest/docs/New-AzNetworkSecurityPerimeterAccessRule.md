---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworksecurityperimeteraccessrule
schema: 2.0.0
---

# New-AzNetworkSecurityPerimeterAccessRule

## SYNOPSIS
Creates or updates a network access rule.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String>] [-AccessRuleId <String>]
 [-AddressPrefix <String[]>] [-Direction <AccessRuleDirection>] [-FullyQualifiedDomainName <String[]>]
 [-Location <String>] [-Perimeter <IPerimeterBasedAccessRule[]>] [-Subscription <ISubscriptionId[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> -Parameter <INspAccessRule> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityPerimeterAccessRule -InputObject <INetworkSecurityPerimeterIdentity>
 [-AccessRuleId <String>] [-AddressPrefix <String[]>] [-Direction <AccessRuleDirection>]
 [-FullyQualifiedDomainName <String[]>] [-Location <String>] [-Perimeter <IPerimeterBasedAccessRule[]>]
 [-Subscription <ISubscriptionId[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a network access rule.

## EXAMPLES

### Example 1: Creates a NetworkSecurityPerimeterAccessRule
```powershell

 New-AzNetworkSecurityPerimeterAccessRule -Name accessRule1 -ProfileName profile2 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3 -AddressPrefix '10.10.0.0/16' -Direction 'Inbound' -Location eastus2euap

```

```output

Location Name
-------- ----
         accessRule1


```

Creates a NetworkSecurityPerimeterAccessRule

### Example 2: Creates a NetworkSecurityPerimeterAccessRule
```powershell

$perimeter1 = @{
  id='/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.Network/networkSecurityPerimeters/kaushal-nsp1'
  perimeterGuid=''
  location='eastus2euap'
}

$perimeter2 = @{
  id='/subscriptions/<SubscriptionId>/resourceGroups/ResourceGroup-1/providers/Microsoft.Network/networkSecurityPerimeters/kk-nsp4'
  perimeterGuid='bcf8bf02-8b8a-4bcb-933d-2b575d94ec8f'
  location='eastus2euap'
}

$networkSecurityPerimeters  =  @($perimeter1,$perimeter2)

New-AzNetworkSecurityPerimeterAccessRule -Name 'perimeter-ar' -SecurityPerimeterName 'testt-nsp1'  -ProfileName 't-profile2'  -ResourceGroupName 'ResourceGroup-1'  -Direction 'Inbound' -Location 'eastus2euap' -Perimeter $networkSecurityPerimeters

```

```output

Location Name
-------- ----
         perimeter_ar

```

Creates a NetworkSecurityPerimeterAccessRule

## PARAMETERS

### -AccessRuleId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: Id

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AddressPrefix
Inbound address prefixes (IPv4/IPv6)

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -Direction
Direction that specifies whether the access rules is inbound/outbound.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Support.AccessRuleDirection
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FullyQualifiedDomainName
Outbound rules fully qualified domain name format.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NSP access rule.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: AccessRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The NSP access rule resource
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.INspAccessRule
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Perimeter
Inbound rule specified by the perimeter id.
To construct, see NOTES section for PERIMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.IPerimeterBasedAccessRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
The name of the NSP profile.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: SecurityPerimeterProfileName, NSPProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases: NetworkSecurityPerimeterName, NSPName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
List of subscription ids
To construct, see NOTES section for SUBSCRIPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.ISubscriptionId[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.INspAccessRule

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.INspAccessRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <INetworkSecurityPerimeterIdentity>`: Identity Parameter
  - `[AccessRuleName <String>]`: The name of the NSP access rule.
  - `[AssociationName <String>]`: The name of the NSP association.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of network security perimeter.
  - `[NetworkSecurityPerimeterName <String>]`: The name of the network security perimeter.
  - `[ProfileName <String>]`: The name of the NSP profile.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

`PARAMETER <INspAccessRule>`: The NSP access rule resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AddressPrefix <String[]>]`: Inbound address prefixes (IPv4/IPv6)
  - `[Direction <AccessRuleDirection?>]`: Direction that specifies whether the access rules is inbound/outbound.
  - `[FullyQualifiedDomainName <String[]>]`: Outbound rules fully qualified domain name format.
  - `[NetworkSecurityPerimeter <IPerimeterBasedAccessRule[]>]`: Inbound rule specified by the perimeter id.
    - `[Id <String>]`: NSP id in the ARM id format.
  - `[Subscription <ISubscriptionId[]>]`: List of subscription ids
    - `[Id <String>]`: Subscription id in the ARM id format.

`PERIMETER <IPerimeterBasedAccessRule[]>`: Inbound rule specified by the perimeter id.
  - `[Id <String>]`: NSP id in the ARM id format.

`SUBSCRIPTION <ISubscriptionId[]>`: List of subscription ids
  - `[Id <String>]`: Subscription id in the ARM id format.

## RELATED LINKS

