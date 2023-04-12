---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azaksversion
schema: 2.0.0
---

# Get-AzAksVersion

## SYNOPSIS
List available version for creating managed Kubernetes cluster.
The operation returns properties of each orchestrator including version, available upgrades and whether that version or upgrades are in preview.

## SYNTAX

```
Get-AzAksVersion -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List available version for creating managed Kubernetes cluster.
The operation returns properties of each orchestrator including version, available upgrades and whether that version or upgrades are in preview.

## EXAMPLES

### Example 1: List available version for creating managed Kubernetes cluster
```powershell
Get-AzAksVersion -location eastus
```

```output
Default IsPreview OrchestratorType OrchestratorVersion
------- --------- ---------------- -------------------
                  Kubernetes       1.19.11
                  Kubernetes       1.19.13
                  Kubernetes       1.20.7
True              Kubernetes       1.20.9
                  Kubernetes       1.21.1
                  Kubernetes       1.21.2
        True      Kubernetes       1.22.1
        True      Kubernetes       1.22.2
```

List available version for creating managed Kubernetes cluster.

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

### -Location
The name of a supported Azure region.

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
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20190801.IOrchestratorVersionProfileListResult

## NOTES

ALIASES

## RELATED LINKS

