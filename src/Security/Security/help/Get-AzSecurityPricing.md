---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/Get-AzSecurityPricing
schema: 2.0.0
---

# Get-AzSecurityPricing

## SYNOPSIS

Gets the Azure Defender plans for a subscription in Azure Security Center.

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzSecurityPricing [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### SubscriptionLevelResource
```
Get-AzSecurityPricing -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceId
```
Get-AzSecurityPricing -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION

You can view each Azure Defender plan, per subscription, using this cmdlet.

For details about Azure Defender and the available plans, see [Introduction to Azure Defender](https://learn.microsoft.com/azure/security-center/azure-defender).

## EXAMPLES

### Example 1

```powershell
Get-AzSecurityPricing
```

```output
Id                                                                                                                      Name                          PricingTier   SubPlan             FreeTrialRemainingTime    Deprecated  ReplacedBy
--                                                                                                                      ----                          -----------   -------             ----------------------    ----------  ----------
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/VirtualMachines               VirtualMachines               Standard      P2                  00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/SqlServers                    SqlServers                    Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/AppServices                   AppServices                   Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/StorageAccounts               StorageAccounts               Standard      PerStorageAccount   00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/SqlServerVirtualMachines      SqlServerVirtualMachines      Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/KubernetesService             KubernetesService             Free                              00:00:00                  True        [Containers]
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/ContainerRegistry             ContainerRegistry             Free                              00:00:00                  True        [Containers]
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/KeyVaults                     KeyVaults                     Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/Dns                           Dns                           Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/Arm                           Arm                           Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/OpenSourceRelationalDatabases OpenSourceRelationalDatabases Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/CosmosDbs                     CosmosDbs                     Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/Containers                    Containers                    Standard                          00:00:00
/subscriptions/c32e05d9-7207-4e22-bdf4-4f7d9c72e5fd/providers/Microsoft.Security/pricings/CloudPosture                  CloudPosture                  Free                              00:00:00
```

Gets the status of each Azure Defender plan for the subscription.

### Example 2

```powershell
Get-AzSecurityPricing -ResourceId '/subscriptions/fbaa2b23-e9dd-4bed-93c1-9e2a44f64bc0/providers/Microsoft.Security/pricings/VirtualMachines'
```

Gets pricing details of the specific resource ID. Where ResourceId is one of the IDs returned by `Get-AzSecurityPricing`.

### Example 3

```powershell
Get-AzSecurityPricing -Name 'VirtualMachines'
```

```output
Id                     : /subscriptions/10329fc1-5a3b-443c-9054-83d13abd64db/providers/Microsoft.Security/pricings/VirtualMachines
Name                   : VirtualMachines
PricingTier            : Standard
FreeTrialRemainingTime : 00:00:00
SubPlan                : P2
Extensions             : [{"name":"MdeDesignatedSubscription","isEnabled":"False","additionalExtensionProperties":null,"operationStatus":null},{"name":"AgentlessVmScanning","isEnabled":"True","additionalExtensionProperties":{"ExclusionTags":"[{\"key\":\"Microsoft\",\"value\":\"Defender\"},{\"key\":\"For\",\"value\":\"Cloud\"}]"},"operationStatus":null}]
```

Gets pricing details of the named Azure Defender plan. Where `name` is one of the names returned by `Get-AzSecurityPricing`.

## PARAMETERS

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name

Resource name.

```yaml
Type: System.String
Parameter Sets: SubscriptionLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId

Resource ID.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.Pricings.PSSecurityPricing

## NOTES

## RELATED LINKS
