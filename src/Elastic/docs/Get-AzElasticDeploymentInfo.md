---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelasticdeploymentinfo
schema: 2.0.0
---

# Get-AzElasticDeploymentInfo

## SYNOPSIS
Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource.

## SYNTAX

### List (Default)
```
Get-AzElasticDeploymentInfo -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListViaIdentityMonitor
```
Get-AzElasticDeploymentInfo -MonitorInputObject <IElasticIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource.

## EXAMPLES

### Example 1: Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource
```powershell
Get-AzElasticDeploymentInfo -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
DeploymentUrl                           : /sso/v1/go/ec:1836023263:kibana-monitor01?acs=https://monitor01.kb.eastus
                                          .azure.elastic-cloud.com:9243/api/security/saml/callback&sp_login_url=htt
                                          ps://monitor01.kb.eastus.azure.elastic-cloud.com:9243
DiskCapacity                            : 573440
MarketplaceSaaInfoMarketplaceName       : AzElastic_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_elastic
MarketplaceSaaInfoMarketplaceResourceId :
MarketplaceSaaInfoMarketplaceStatus     :
MarketplaceSubscriptionId               : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
MemoryCapacity                          : 16384
Status                                  : Healthy
Version                                 : 8.8.2
```

Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource.

### Example 2: Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 | Get-AzElasticDeploymentInfo
```

```output
DeploymentUrl                           : /sso/v1/go/ec:1836023263:kibana-monitor01?acs=https://monitor01.kb.eastus
                                          .azure.elastic-cloud.com:9243/api/security/saml/callback&sp_login_url=htt
                                          ps://monitor01.kb.eastus.azure.elastic-cloud.com:9243
DiskCapacity                            : 573440
MarketplaceSaaInfoMarketplaceName       : AzElastic_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_elastic
MarketplaceSaaInfoMarketplaceResourceId :
MarketplaceSaaInfoMarketplaceStatus     :
MarketplaceSubscriptionId               : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
MemoryCapacity                          : 16384
Status                                  : Healthy
Version                                 : 8.8.2
```

Fetch information regarding Elastic cloud deployment corresponding to the Elastic monitor resource via pipeline.

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

### -MonitorInputObject
Identity Parameter
To construct, see NOTES section for MONITORINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: ListViaIdentityMonitor
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Elastic resource belongs.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String[]
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IDeploymentInfoResponse

## NOTES

## RELATED LINKS

