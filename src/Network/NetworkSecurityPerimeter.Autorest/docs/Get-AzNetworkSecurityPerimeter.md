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

### Example 1: List NetworkSecurityPerimeters in ResourceGroup
```powershell
Get-AzNetworkSecurityPerimeter -ResourceGroupName rg-test-1
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus2euap nsp-test-1  rg-test-1
eastus2euap nsp-test-2  rg-test-1
eastus2euap nsp-test-3  rg-test-1
```

List NetworkSecurityPerimeters in ResourceGroup

### Example 2: List NetworkSecurityPerimeters in Subscription
```powershell
Get-AzNetworkSecurityPerimeter
```

```output
Location    Name        ResourceGroupName
--------    ----        -----------------
eastus2euap nsp-test-1  rg-test-1
eastus2euap nsp-test-2  rg-test-1
eastus2euap nsp-test-3  rg-test-1
eastus2euap nsp-test-4  rg-test-2
eastus2euap nsp-test-5  rg-test-2
```

List NetworkSecurityPerimeters in Subscription

### Example 3: Get NetworkSecurityPerimeter by Name
```powershell
Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1
Location                     : eastus2euap
Name                         : nsp-test-1
PerimeterGuid                : 00000000-0000-0000-0000-000000000000
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                                 " Owner": "user-test-1"
                               }
Type                         : Microsoft.Network/networkSecurityPerimeters
```

Get NetworkSecurityPerimeter by Name

### Example 4: Get NetworkSecurityPerimeter by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
Get-AzNetworkSecurityPerimeter -InputObject $GETObj
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1
Location                     : eastus2euap
Name                         : nsp-test-1
PerimeterGuid                : 00000000-0000-0000-0000-000000000000
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                                 " Owner": "user-test-1"
                               }
Type                         : Microsoft.Network/networkSecurityPerimeters
```

Get NetworkSecurityPerimeter by Identity (using pipe)

## PARAMETERS

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

### -InputObject
Identity Parameter

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeter

## NOTES

## RELATED LINKS

