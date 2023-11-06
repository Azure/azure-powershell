---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/unregister-azstackhci
schema: 2.0.0
---

# Unregister-AzStackHCI

## SYNOPSIS
Unregister-AzStackHCI deletes the Microsoft.AzureStackHCI cloud resource representing the on-premises cluster and unregisters the on-premises cluster with Azure.
The registered information available on the cluster is used to unregister the cluster if no parameters are passed.

## SYNTAX

```
Unregister-AzStackHCI [[-SubscriptionId] <String>] [[-ResourceName] <String>] [[-TenantId] <String>]
 [[-ResourceGroupName] <String>] [[-ArmAccessToken] <String>] [[-AccountId] <String>]
 [[-EnvironmentName] <String>] [[-Region] <String>] [[-ComputerName] <String>] [[-Credential] <PSCredential>]
 [-DisableOnlyAzureArcServer] [-Force] [-UseDeviceAuthentication] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Unregister-AzStackHCI deletes the Microsoft.AzureStackHCI cloud resource representing the on-premises cluster and unregisters the on-premises cluster with Azure.
The registered information available on the cluster is used to unregister the cluster if no parameters are passed.

## EXAMPLES

### Example 1: 
```powershell
Unregister-AzStackHCI
```

```output
Result: Success
```

Invoking on one of the cluster node

### Example 2:
```powershell
Unregister-AzStackHCI -ComputerName ClusterNode1
```

```output
Result: Success
```

Invoking from the management node

### Example 3: 
```powershell
Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -AccountId user1@corp1.com -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG -Confirm:$False
```

```output
Result: Success
```

Invoking from WAC

### Example 4: 
```powershell
Unregister-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciClusterRG -ArmAccessToken eerrer..ere= -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential
```

```output
Result: Success
```

Invoking with all the parameters

## PARAMETERS

### -AccountId
Specifies the AccoundId.
Specifying this along with ArmAccessToken will avoid Azure interactive logon.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArmAccessToken
Specifies the ARM access token.
Specifying this along with AccountId will avoid Azure interactive logon.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputerName
Specifies one of the cluster node in on-premise cluster that is being registered to Azure.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 8
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
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableOnlyAzureArcServer
Specifying this parameter to $true will only unregister the cluster nodes with Arc for servers and Azure Stack HCI registration will not be altered.

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

### -EnvironmentName
Specifies the Azure Environment.
Default is AzureCloud.
Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Specifies that unregistration should continue even if we could not delete the Arc extensions on the nodes.

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

### -Region
Specifies the Region the resource is created in Azure.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the Azure Resource Group name.
If not specified \<LocalClusterName\>-rg will be used as resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
Specifies the resource name of the resource created in Azure.
If not specified, on-premises cluster name is used.

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

### -SubscriptionId
Specifies the Azure Subscription to create the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
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
Position: 2
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

## OUTPUTS

### PSCustomObject. Returns following Properties in PSCustomObject
Result: Success or Failed or Cancelled.

## NOTES

ALIASES

## RELATED LINKS

