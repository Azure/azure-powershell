---
external help file:
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/get-azdocumentdbfirewallrule
schema: 2.0.0
---

# Get-AzDocumentDBFirewallRule

## SYNOPSIS
Gets information about a mongo cluster firewall rule.

## SYNTAX

### List (Default)
```
Get-AzDocumentDBFirewallRule -MongoClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDocumentDBFirewallRule -MongoClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDocumentDBFirewallRule -InputObject <IDocumentDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityMongoCluster
```
Get-AzDocumentDBFirewallRule -MongoClusterInputObject <IDocumentDbIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets information about a mongo cluster firewall rule.

## EXAMPLES

### Example 1: Get a firewall rule of a mongo cluster
```powershell
Get-AzDocumentDBFirewallRule -Name allow-azure -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name         ProvisioningState StartIPAddress EndIPAddress
----         ----------------- -------------- ------------
allow-azure  Succeeded         0.0.0.0        0.0.0.0
```

Get a single firewall rule of a mongo cluster by name.

### Example 2: List the firewall rules of a mongo cluster
```powershell
Get-AzDocumentDBFirewallRule -MongoClusterName myCluster -ResourceGroupName myResourceGroup
```

```output
Name         ProvisioningState StartIPAddress EndIPAddress
----         ----------------- -------------- ------------
allow-azure  Succeeded         0.0.0.0        0.0.0.0
```

List all firewall rules of a mongo cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MongoClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity
Parameter Sets: GetViaIdentityMongoCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MongoClusterName
The name of the mongo cluster.

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

### -Name
The name of the mongo cluster firewall rule.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityMongoCluster
Aliases: FirewallRuleName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IFirewallRule

## NOTES

## RELATED LINKS
