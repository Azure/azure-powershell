---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/set-azstackhci
schema: 2.0.0
---

# Set-AzStackHCI

## SYNOPSIS
Set-AzStackHCI modifies resource properties of the Microsoft.AzureStackHCI cloud resource representing the on-premises cluster to enable or disable features.

## SYNTAX

```
Set-AzStackHCI [[-ComputerName] <String>] [-Credential <PSCredential>] [-ResourceId <String>]
 [-EnableWSSubscription <Boolean>] [-DiagnosticLevel <DiagnosticLevel>] [-TenantId <String>]
 [-ArmAccessToken <String>] [-GraphAccessToken <String>] [-AccountId <String>] [-EnvironmentName <String>]
 [-UseDeviceAuthentication] [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Set-AzStackHCI modifies resource properties of the Microsoft.AzureStackHCI cloud resource representing the on-premises cluster to enable or disable features.

## EXAMPLES

### EXAMPLE 1
```powershell
Set-AzStackHCI -EnableWSSubscription $true
```

```output
Result: Success
```

Invoking on one of the cluster node to enable Windows Server Subscription feature

### EXAMPLE 2
```powershell
Set-AzStackHCI -ComputerName ClusterNode1 -DiagnosticLevel Basic
```

```output
Result: Success
```

Invoking from the management node to set the diagnostic level to Basic

## PARAMETERS

### -AccountId
Specifies the ARM access token.
Specifying this along with ArmAccessToken and GraphAccessToken will avoid Azure interactive logon.

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

### -ArmAccessToken
Specifies the ARM access token.
Specifying this along with GraphAccessToken and AccountId will avoid Azure interactive logon.

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

### -ComputerName
Specifies one of the cluster node in on-premise cluster that is registered to Azure.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Specifies the credential for the ComputerName.
Default is the current user executing the Cmdlet.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiagnosticLevel
Specifies the diagnostic level for the cluster.

```yaml
Type: DiagnosticLevel
Parameter Sets: (All)
Aliases:
Accepted values: Off, Basic, Enhanced

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableWSSubscription
Specifies if Windows Server Subscription should be enabled or disabled.
Enabling this feature starts billing through your Azure subscription for Windows Server guest licenses.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
Specifies the Azure Environment.
Default is AzureCloud.
Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: $AzureCloud
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -GraphAccessToken
Specifies the Graph access token.
Specifying this along with ArmAccessToken and AccountId will avoid Azure interactive logon.

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

### -ResourceId
Specifies the fully qualified resource ID, including the subscription, as in the following example: \`/Subscriptions/\`subscription ID\`/providers/Microsoft.AzureStackHCI/clusters/MyCluster\`

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

### -TenantId
Specifies the Azure TenantId.

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

### -UseDeviceAuthentication
Use device code authentication instead of an interactive browser prompt.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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

## OUTPUTS

### PSCustomObject. Returns following Properties in PSCustomObject
### Result: Success or Failed or Cancelled.
## NOTES

## RELATED LINKS
