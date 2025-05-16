---
external help file:
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-aznetworksecurityperimeter
schema: 2.0.0
---

# Update-AzNetworkSecurityPerimeter

## SYNOPSIS
Patch Tags for a Network Security Perimeter.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzNetworkSecurityPerimeter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzNetworkSecurityPerimeter -Name <String> -ResourceGroupName <String> -Parameter <IUpdateTagsRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzNetworkSecurityPerimeter -InputObject <INetworkSecurityPerimeterIdentity>
 -Parameter <IUpdateTagsRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzNetworkSecurityPerimeter -InputObject <INetworkSecurityPerimeterIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaJsonFilePath
```
Update-AzNetworkSecurityPerimeter -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaJsonString
```
Update-AzNetworkSecurityPerimeter -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch Tags for a Network Security Perimeter.

## EXAMPLES

### Example 1: Update NetworkSecurityPerimeter
```powershell
Update-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1 -Tag @{'Owner'='user-test-1'}
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

Update NetworkSecurityPerimeter

### Example 2: Update NetworkSecurityPerimeter by Identity (using pipe)
```powershell
 $GETObj = Get-AzNetworkSecurityPerimeter -Name nsp-test-1 -ResourceGroupName rg-test-1
 Update-AzNetworkSecurityPerimeter -InputObject $GETObj -Tag @{'Owner'='user-test-2'}
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
                                 " Owner": "user-test-2"
                               }
Type                         : Microsoft.Network/networkSecurityPerimeters
```

Update NetworkSecurityPerimeter by Identity (using pipe)

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
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Patch operation

```yaml
Type: System.String
Parameter Sets: PatchViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Patch operation

```yaml
Type: System.String
Parameter Sets: PatchViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the network security perimeter.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases: NetworkSecurityPerimeterName, SecurityPerimeterName, NSPName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Update tags request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IUpdateTagsRequest
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
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
Parameter Sets: Patch, PatchExpanded, PatchViaJsonFilePath, PatchViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
List of tags for Network Security Perimeter

```yaml
Type: System.Collections.Hashtable
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IUpdateTagsRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeter

## NOTES

## RELATED LINKS

