---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeteraccessrule
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeterAccessRule

## SYNOPSIS
Gets the specified NSP access rule by name.

## SYNTAX

### List (Default)
```
Get-AzNetworkSecurityPerimeterAccessRule -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String[]>] [-SkipToken <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityProfile
```
Get-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileInputObject <INetworkSecurityPerimeterIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityNetworkSecurityPerimeter
```
Get-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String>
 -NetworkSecurityPerimeterInputObject <INetworkSecurityPerimeterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkSecurityPerimeterAccessRule -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -SecurityPerimeterName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkSecurityPerimeterAccessRule -InputObject <INetworkSecurityPerimeterIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified NSP access rule by name.

## EXAMPLES

### Example 1: List NetworkSecurityPerimeter AccessRules
```powershell
Get-AzNetworkSecurityPerimeterAccessRule -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
Name                 ResourceGroupName
----                 ----------------- 
access-rule-test-1   rg-test-1
access-rule-test-2   rg-test-1
```

List NetworkSecurityPerimeter AccessRules

### Example 2: Get NetworkSecurityPerimeter AccessRule by Name
```powershell
Get-AzNetworkSecurityPerimeterAccessRule -Name access-rule-test-1 -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
AddressPrefix                : {198.168.0.0/32}
Direction                    : Inbound
EmailAddress                 : {}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1
                                /accessRules/access-rule-test-1
Name                         : access-rule-test-1
NetworkSecurityPerimeter     : {}
PhoneNumber                  : {}
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
ServiceTag                   :
Subscription                 : {}
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/profiles/accessRules
```

Get NetworkSecurityPerimeter AccessRule by Name

### Example 3: Get NetworkSecurityPerimeter AccessRule by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name access-rule-test-1 -ProfileName profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Get-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj
```

```output
AddressPrefix                : {198.168.0.0/32}
Direction                    : Inbound
EmailAddress                 : {}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1
                                /accessRules/access-rule-test-1
Name                         : access-rule-test-1
NetworkSecurityPerimeter     : {}
PhoneNumber                  : {}
ProvisioningState            : Succeeded
ResourceGroupName            : rg-test-1
ServiceTag                   :
Subscription                 : {}
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/profiles/accessRules
```

Get NetworkSecurityPerimeter AccessRule by Identity (using pipe)

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
The name of the NSP access rule.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityProfile, GetViaIdentityNetworkSecurityPerimeter, Get
Aliases: AccessRuleName

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
Parameter Sets: GetViaIdentityNetworkSecurityPerimeter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: GetViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
The name of the NSP profile.

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityNetworkSecurityPerimeter, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAccessRule

## NOTES

## RELATED LINKS
