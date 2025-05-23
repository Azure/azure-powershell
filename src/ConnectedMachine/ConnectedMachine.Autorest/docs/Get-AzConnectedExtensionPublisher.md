---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedextensionpublisher
schema: 2.0.0
---

# Get-AzConnectedExtensionPublisher

## SYNOPSIS
Gets all Extension publishers based on the location

## SYNTAX

```
Get-AzConnectedExtensionPublisher -Location <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets all Extension publishers based on the location

## EXAMPLES

### Example 1: Get extension publishers
```powershell
Get-AzConnectedExtensionPublisher -Location eastus
```

```output
Name
----
azurestackhci.telemetry.agent
datadog.agent
dynatrace.ruxit
microsoft.admincenter
microsoft.aksarcforlinux
microsoft.azure.activedirectory
microsoft.azure.automation.hybridworker
microsoft.azure.azuredefenderforservers
microsoft.azure.azuredefenderforsql
microsoft.azure.changetrackingandinventory
microsoft.azure.extensions
microsoft.azure.geneva
microsoft.azure.keyvault
microsoft.azure.meshvpn
microsoft.azure.monitor
microsoft.azure.monitoring.dependencyagent
microsoft.azure.networkwatcher
microsoft.azure.openssh
microsoft.azure.recoveryservices.workloadbackup
microsoft.azure.scommi
microsoft.azure.security
microsoft.azure.security.linuxattestation
microsoft.azure.security.monitoring
microsoft.azure.security.windowsattestation
microsoft.azuredata
microsoft.azurestack.arcvirtualization
microsoft.azurestack.hci.alerts
microsoft.azurestack.observability
microsoft.azurestack.orchestration
microsoft.compute
microsoft.cplat.core
microsoft.edge
microsoft.edge.backup
microsoft.enterprisecloud.monitoring
microsoft.sentinel.azuremonitoragentextensions
microsoft.serviceshub
microsoft.siterecovery.dra
microsoft.softwareupdatemanagement
microsoft.sqlserver.management
newrelic.infrastructure.extensions
qualys
```

Get extension publishers

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

### -Location
The name of Azure region.

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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IExtensionPublisher

## NOTES

## RELATED LINKS

