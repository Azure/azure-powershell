---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeter
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeter

## SYNOPSIS
Gets the specified network security perimeter by the name.

## SYNTAX

### List (Default)
```
Get-AzNetworkSecurityPerimeter [-SubscriptionId <String[]>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkSecurityPerimeter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkSecurityPerimeter -InputObject <INetworkSecurityPerimeterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNetworkSecurityPerimeter -ResourceGroupName <String> [-SubscriptionId <String[]>] [-SkipToken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified network security perimeter by the name.

## EXAMPLES

### Example 1: List NetworkSecurityPerimeter
```powershell

 Get-AzNetworkSecurityPerimeter -ResourceGroupName ResourceGroup-1

```

```output

Location    Name
--------    ----
eastus2euap nsp4
eastus2euap nsp3
eastus2euap nsp1
eastus2euap nsp6
eastus2euap nsp5


```

List NetworkSecurityPerimeter

### Example 2: List NetworkSecurityPerimeter in a subscription
```powershell

 Get-AzNetworkSecurityPerimeter

```

```output

Location    Name
--------    ----
eastus2euap nsp4
eastus2euap nsp3
eastus2euap nsp1
eastus2euap nsp6
eastus2euap nsp5


```

List NetworkSecurityPerimeter in a subscription

### Example 3: Gets a NetworkSecurityPerimeter by Name
```powershell

 Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName ResourceGroup-1

```

```output

Location    Name
--------    ----
eastus2euap nsp3


```

Gets a NetworkSecurityPerimeter by Name

### Example 4: Gets a NetworkSecurityPerimeter by identity (using pipe)
```powershell

 $GETObj = Get-AzNetworkSecurityPerimeter -Name nsp3 -ResourceGroupName ResourceGroup-1
 Get-AzNetworkSecurityPerimeter -InputObject $GETObj

```

```output

Location    Name
--------    ----
eastus2euap nsp3

```

Gets a NetworkSecurityPerimeter by identity (using pipe)

## PARAMETERS

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the network security perimeter.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkSecurityPerimeterName, SecurityPerimeterName, NSPName

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
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
SkipToken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.String
Parameter Sets: List, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
An optional query parameter which specifies the maximum number of records to be returned by the server.

```yaml
Type: System.Int32
Parameter Sets: List, List1
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.INetworkSecurityPerimeter

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <INetworkSecurityPerimeterIdentity>`: Identity Parameter
  - `[AccessRuleName <String>]`: The name of the NSP access rule.
  - `[AssociationName <String>]`: The name of the NSP association.
  - `[Id <String>]`: Resource identity path
  - `[LinkName <String>]`: The name of the NSP link.
  - `[LinkReferenceName <String>]`: The name of the NSP linkReference.
  - `[Location <String>]`: The location of network security perimeter.
  - `[NetworkSecurityPerimeterName <String>]`: The name of the network security perimeter.
  - `[ProfileName <String>]`: The name of the NSP profile.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

