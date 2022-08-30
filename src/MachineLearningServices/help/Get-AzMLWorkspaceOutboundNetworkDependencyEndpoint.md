---
external help file:
Module Name: Az.MachineLearningServices
online version: https://docs.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspaceoutboundnetworkdependencyendpoint
schema: 2.0.0
---

# Get-AzMLWorkspaceOutboundNetworkDependencyEndpoint

## SYNOPSIS
Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically.

## SYNTAX

```
Get-AzMLWorkspaceOutboundNetworkDependencyEndpoint -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically.

## EXAMPLES

### Example 1: Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically
```powershell
Get-AzMLWorkspaceOutboundNetworkDependencyEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Category                                Endpoint
--------                                --------
Azure Active Directory                  {{…
Azure portal                            {{…
Azure Resource Manager                  {{…
Azure Machine Learning studio           {{…
API                                     {{…
Integrated notebook                     {{…
Compute                                 {{…
Microsoft Container Registry            {{…
Azure Machine Learning pre-built images {{…
```

Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically

## PARAMETERS

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IFqdnEndpoints

## NOTES

ALIASES

## RELATED LINKS

