---
external help file: Az.NetworkSecurity-help.xml
Module Name: Az.NetworkSecurity
online version: https://learn.microsoft.com/powershell/module/az.networksecurity/new-aznetworksecurityneuroshield
schema: 2.0.0
---

# New-AzNetworkSecurityNeuroShield

## SYNOPSIS
Create a NeuroShield resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] -Location <String> -ResponseMode <String> [-Description <String>]
 [-SeverityThreshold <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzNetworkSecurityNeuroShield -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] -Resource <INeuroShieldResource> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzNetworkSecurityNeuroShield -InputObject <INetworkSecurityIdentity> [-IfMatch <String>] -Location <String>
 -ResponseMode <String> [-Description <String>] [-SeverityThreshold <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzNetworkSecurityNeuroShield -InputObject <INetworkSecurityIdentity> [-IfMatch <String>]
 -Resource <INeuroShieldResource> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a NeuroShield resource.

## EXAMPLES

### Example 1: Create a NeuroShield in manual response mode
```powershell
New-AzNetworkSecurityNeuroShield -ResourceGroupName 'myResourceGroup' -Name 'myNeuroShield' -Location '<supported-region>' -ResponseMode Manual -SeverityThreshold Medium
```

Creates a NeuroShield.
Replace the location placeholder with a region enabled for your subscription.

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
Omission in a fullPUT request resolves to an empty string.
Control characters other than tab,line feed, and carriage return are not allowed.

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
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases: NeuroShieldName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Azure Resource Manager tracked resource representing a NeuroShield instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldResource
Parameter Sets: Create, CreateViaIdentity
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResponseMode
Response mode that controls mitigation serving behavior.
A full create orupdate (PUT) request must specify Auto or Manual; there is no default.Omitting responseMode from a PATCH request preserves the existing mode.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SeverityThreshold
Minimum severity level for mitigation generation.
Omission in a full PUTrequest resolves to Low; omission in PATCH preserves the value.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldResource

## NOTES

## RELATED LINKS
