---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/update-azkustoprivateendpointconnection
schema: 2.0.0
---

# Update-AzKustoPrivateEndpointConnection

## SYNOPSIS
Approve or reject a private endpoint connection with a given name.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzKustoPrivateEndpointConnection -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-PrivateLinkServiceConnectionStateDescription <String>]
 [-PrivateLinkServiceConnectionStateStatus <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzKustoPrivateEndpointConnection -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Parameter <IPrivateEndpointConnection> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzKustoPrivateEndpointConnection -Name <String> -ClusterInputObject <IKustoIdentity>
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityCluster
```
Update-AzKustoPrivateEndpointConnection -Name <String> -ClusterInputObject <IKustoIdentity>
 -Parameter <IPrivateEndpointConnection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzKustoPrivateEndpointConnection -InputObject <IKustoIdentity>
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzKustoPrivateEndpointConnection -InputObject <IKustoIdentity> -Parameter <IPrivateEndpointConnection>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Approve or reject a private endpoint connection with a given name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

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

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentityClusterExpanded, UpdateViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update, UpdateViaIdentityClusterExpanded, UpdateViaIdentityCluster
Aliases: PrivateEndpointConnectionName

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

### -Parameter
A private endpoint connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IPrivateEndpointConnection
Parameter Sets: Update, UpdateViaIdentityCluster, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateDescription
The private link service connection description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateStatus
The private link service connection status.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, Update
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
Type: System.String
Parameter Sets: UpdateExpanded, Update
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IPrivateEndpointConnection

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IPrivateEndpointConnection

## NOTES

## RELATED LINKS
