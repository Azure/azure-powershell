---
external help file: Az.Alb-help.xml
Module Name: Az.Alb
online version: https://learn.microsoft.com/powershell/module/az.alb/get-azalbsecuritypolicy
schema: 2.0.0
---

# Get-AzAlbSecurityPolicy

## SYNOPSIS
Get a SecurityPolicy

## SYNTAX

### List (Default)
```
Get-AzAlbSecurityPolicy -AlbName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAlbSecurityPolicy -AlbName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityTrafficController
```
Get-AzAlbSecurityPolicy -Name <String> -TrafficControllerInputObject <IAlbIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAlbSecurityPolicy -InputObject <IAlbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a SecurityPolicy

## EXAMPLES

### Example 1: Get a specified Application Gateway for Containers association resource
```powershell
Get-AzAlbSecurityPolicy -Name test-securityPolicy -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name          ResourceGroupName Location       PolicyType WafPolicyId                                                                                                                                                     ProvisioningState
----          ----------------- --------       ---------- -----------                                                                                                                                                     -----------------
test-frontend test-rg           northcentralus waf        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/test-rg/providers/Microsoft.Networking/applicationGatewayWebApplicationFirewallPolicies/wp-0 Succeeded
```

This command shows a specific Application Gateway for Containers frontend resource.

### Example 2: List associations for a given Application Gateway for Containers resource
```powershell
Get-AzAlbSecurityPolicy -AlbName test-alb -ResourceGroupName test-rg
```

```output
Name          ResourceGroupName Location       PolicyType WafPolicyId                                                                                                                                                     ProvisioningState
----          ----------------- --------       ---------- -----------                                                                                                                                                     -----------------
test-frontend test-rg           northcentralus waf        /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/test-rg/providers/Microsoft.Networking/applicationGatewayWebApplicationFirewallPolicies/wp-0 Succeeded
```

This command lists all Application Gateway for Containers frontend resources belonging to a specific Application Gateway for Containers resource.

## PARAMETERS

### -AlbName
traffic controller name for path

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
SecurityPolicy

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityTrafficController
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -TrafficControllerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity
Parameter Sets: GetViaIdentityTrafficController
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.IAlbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Alb.Models.ISecurityPolicy

## NOTES

## RELATED LINKS
