---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/start-azeventhubnamespacefailover
schema: 2.0.0
---

# Start-AzEventHubNamespaceFailOver

## SYNOPSIS
Triggers EventHub Namespace Failover

## SYNTAX

### SetExpanded (Default)
```
Start-AzEventHubNamespaceFailOver -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Force] [-PrimaryLocation <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Start-AzEventHubNamespaceFailOver -InputObject <IEventHubIdentity> [-Force] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Triggers EventHub Namespace Failover

## EXAMPLES

### Example 1: Triggers EventHub Namespace Failover.
```powershell
Start-AzEventHubNamespaceFailOver -ResourceGroupName myresourceGroup -NamespaceName mynamespace -PrimaryLocation mylocation
$eventhubNamespace = Get-AzEventHubNamespace -ResourceGroupName myresourceGroup -Name mynamespace 
```

```output
AlternateName                      :
ClusterArmId                       :
CreatedAt                          : 5/5/2025 5:16:45 PM
DisableLocalAuth                   : False
EnableAutoInflate                  : False
Id                                 : /subscriptions/subscriptionId/resourceGroups/myresourceGroup/providers/Microsoft.EventHub/namespaces/mynamespace
IdentityType                       :
KafkaEnabled                       : True
KeySource                          :
KeyVaultProperty                   :
Location                           : mylocation
MaxReplicationLagDurationInSeconds : 0
MaximumThroughputUnit              : 0
MetricId                           : subscriptionId:mynamespace
MinimumTlsVersion                  : 1.2
Name                               : mynamespace
PrincipalId                        :
PrivateEndpointConnection          :
ProvisioningState                  : Succeeded
PublicNetworkAccess                : Enabled
ReplicaLocation                    : {{
                                       "locationName": "mylocation",
                                       "roleType": "Primary",
                                       "replicaState": "Ready"
                                     }, {
                                       "locationName": "mylocation2",
                                       "roleType": "Secondary",
                                       "replicaState": "Ready"
                                     }}
RequireInfrastructureEncryption    :
ResourceGroupName                  : myresourceGroup
ServiceBusEndpoint                 : https://mynamespace.servicebus.windows.net:443/
SkuCapacity                        : 1
SkuName                            : Premium
SkuTier                            : Premium
Status                             : Active
SystemDataCreatedAt                :
SystemDataCreatedBy                :
SystemDataCreatedByType            :
SystemDataLastModifiedAt           :
SystemDataLastModifiedBy           :
SystemDataLastModifiedByType       :
Tag                                : {
                                     }
TenantId                           :
Type                               : Microsoft.EventHub/Namespaces
UpdatedAt                          : 5/5/2025 5:17:49 PM
UserAssignedIdentity               : {
                                     }
ZoneRedundant                      : False
```

Triggers EventHub Namespace Failover.

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

### -Force
If Force is false, then graceful failover is attempted after ensuring no data loss.
If Force flag is set to true, forced failover is attempted with possible data loss.

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

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The name of EventHub namespace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

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

### -PrimaryLocation
New primary location after failover.

```yaml
Type: System.String
Parameter Sets: SetExpanded
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
Parameter Sets: SetExpanded
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
Parameter Sets: SetExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IFailOver

## NOTES

## RELATED LINKS

