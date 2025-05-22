---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-aznetworksecurityperimeteraccessrule
schema: 2.0.0
---

# Update-AzNetworkSecurityPerimeterAccessRule

## SYNOPSIS
Updates an access rule.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkSecurityPerimeterAccessRule -ResourceGroupName <String> -Name <String>
 -SecurityPerimeterName <String> -ProfileName <String> [-SubscriptionId <String>] [-AddressPrefix <String[]>]
 [-FullyQualifiedDomainName <String[]>] [-EmailAddress <String[]>] [-PhoneNumber <String[]>]
 [-ServiceTag <String[]>] [-Direction <String>] [-Subscription <ISubscriptionId[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkSecurityPerimeterAccessRule -InputObject <INetworkSecurityPerimeterIdentity>
 [-AddressPrefix <String[]>] [-FullyQualifiedDomainName <String[]>] [-EmailAddress <String[]>]
 [-PhoneNumber <String[]>] [-ServiceTag <String[]>] [-Direction <String>] [-Subscription <ISubscriptionId[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an access rule.

## EXAMPLES

### Example 1: Update NetworkSecurityPerimeter AccessRule
```powershell
Update-AzNetworkSecurityPerimeterAccessRule -Name access-rule-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -ProfileName profile-test-1  -AddressPrefix @('10.10.0.0/24')
```

```output
AddressPrefix                : {10.10.0.0/24}
Direction                    : Inbound
EmailAddress                 : {}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1/accessRules/access-rule-test-1
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

Update NetworkSecurityPerimeter AccessRule

### Example 2: Update NetworkSecurityPerimeter AccessRule by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeterAccessRule -Name access-rule-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1 -ProfileName profile-test-1
Update-AzNetworkSecurityPerimeterAccessRule -InputObject $GETObj -AddressPrefix @('10.0.0.0/16')
```

```output
AddressPrefix                : {10.10.0.0/16}
Direction                    : Inbound
EmailAddress                 : {}
FullyQualifiedDomainName     : {}
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1/accessRules/access-rule-test-1
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

Updates a NetworkSecurityPerimeterAccessRule by identity (using pipe)

## PARAMETERS

### -AddressPrefix
Address Prefix

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Direction
Direction

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

### -EmailAddress
Email Addresses

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FullyQualifiedDomainName
Fully qualified domain name

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INetworkSecurityPerimeterIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the access rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: AccessRuleName

Required: True
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

### -PhoneNumber
Phone Numbers

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
The name of the profile

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SecurityPerimeterName
The name of the network security perimeter

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: NetworkSecurityPerimeterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceTag
Service Tags

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
Subscription ids

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.ISubscriptionId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspAccessRule

## NOTES

## RELATED LINKS
