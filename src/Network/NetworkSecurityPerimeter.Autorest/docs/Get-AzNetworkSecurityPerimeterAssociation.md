---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeterassociation
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeterAssociation

## SYNOPSIS
Gets the specified NSP association by name.

## SYNTAX

### List (Default)
```
Get-AzNetworkSecurityPerimeterAssociation -ResourceGroupName <String> -SecurityPerimeterName <String>
 [-SubscriptionId <String[]>] [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkSecurityPerimeterAssociation -Name <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkSecurityPerimeterAssociation -InputObject <INetworkSecurityPerimeterIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified NSP association by name.

## EXAMPLES

### Example 1: List NetworkSecurityPerimeterAccessAssociation
```powershell

 Get-AzNetworkSecurityPerimeterAssociation -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location Name
-------- ----
         association1
         association3


```

List NetworkSecurityPerimeterAccessAssociation

### Example 2: Gets a NetworkSecurityPerimeterAccessAssociation by Name
```powershell

 Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3

```

```output

Location Name
-------- ----
         association3


```

Gets a NetworkSecurityPerimeterAccessAssociation by Name

### Example 3: Gets a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)
```powershell

 $GETObj = Get-AzNetworkSecurityPerimeterAssociation -Name association3 -ResourceGroupName ResourceGroup-1 -SecurityPerimeterName nsp3
 Get-AzNetworkSecurityPerimeterAssociation -InputObject $GETObj

```

```output

Location Name
-------- ----
         association3


```

Gets a NetworkSecurityPerimeterAccessAssociation by identity (using pipe)

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
The name of the NSP association.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AssociationName

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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
Aliases: NetworkSecurityPerimeterName, NSPName

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
Parameter Sets: List
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
Parameter Sets: Get, List
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
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.Api20210201Preview.INspAssociation

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

## RELATED LINKS

