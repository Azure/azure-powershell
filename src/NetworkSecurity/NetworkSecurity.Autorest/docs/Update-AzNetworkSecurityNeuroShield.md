---
external help file:
Module Name: Az.NetworkSecurity
online version: https://learn.microsoft.com/powershell/module/az.networksecurity/update-aznetworksecurityneuroshield
schema: 2.0.0
---

# Update-AzNetworkSecurityNeuroShield

## SYNOPSIS
Update the tags or properties of a NeuroShield resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-Description <String>] [-ResponseMode <String>] [-SeverityThreshold <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> -Property <INeuroShieldPatch>
 [-SubscriptionId <String>] [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzNetworkSecurityNeuroShield -InputObject <INetworkSecurityIdentity> -Property <INeuroShieldPatch>
 [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkSecurityNeuroShield -InputObject <INetworkSecurityIdentity> [-IfMatch <String>]
 [-Description <String>] [-ResponseMode <String>] [-SeverityThreshold <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update the tags or properties of a NeuroShield resource.

## EXAMPLES

### Example 1: Update a NeuroShield's description and tags
```powershell
Update-AzNetworkSecurityNeuroShield -ResourceGroupName 'myResourceGroup' -Name 'myNeuroShield' -Description 'Production fleet protection' -Tag @{ environment = 'production' }
```

Patches the NeuroShield without replacing the resource.

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

### -Description
Human-readable description of the NeuroShield resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The entity tag that makes the request conditional.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the NeuroShield resource.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: NeuroShieldName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
Patch request body for updating a NeuroShield resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldPatch
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResponseMode
Response mode that controls mitigation serving behavior.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeverityThreshold
Minimum severity level for mitigation generation.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldPatch

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldResource

## NOTES

## RELATED LINKS
