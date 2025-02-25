---
external help file:
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/update-aziotoperationsservicebrokerauthorization
schema: 2.0.0
---

# Update-AzIoTOperationsServiceBrokerAuthorization

## SYNOPSIS
update a BrokerAuthorizationResource

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String> -BrokerName <String>
 -InstanceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthorizationPolicyCache <String>] [-AuthorizationPolicyRule <IAuthorizationRule[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String> -BrokerName <String>
 -InstanceName <String> -ResourceGroupName <String> -Resource <IBrokerAuthorizationResource>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzIoTOperationsServiceBrokerAuthorization -InputObject <IIoTOperationsServiceIdentity>
 -Resource <IBrokerAuthorizationResource> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityBroker
```
Update-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String>
 -BrokerInputObject <IIoTOperationsServiceIdentity> -Resource <IBrokerAuthorizationResource>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityBrokerExpanded
```
Update-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String>
 -BrokerInputObject <IIoTOperationsServiceIdentity> [-AuthorizationPolicyCache <String>]
 [-AuthorizationPolicyRule <IAuthorizationRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzIoTOperationsServiceBrokerAuthorization -InputObject <IIoTOperationsServiceIdentity>
 [-AuthorizationPolicyCache <String>] [-AuthorizationPolicyRule <IAuthorizationRule[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityInstance
```
Update-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String> -BrokerName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> -Resource <IBrokerAuthorizationResource>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityInstanceExpanded
```
Update-AzIoTOperationsServiceBrokerAuthorization -AuthorizationName <String> -BrokerName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> [-AuthorizationPolicyCache <String>]
 [-AuthorizationPolicyRule <IAuthorizationRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a BrokerAuthorizationResource

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

### -AuthorizationName
Name of Instance broker authorization resource

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityBroker, UpdateViaIdentityBrokerExpanded, UpdateViaIdentityInstance, UpdateViaIdentityInstanceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationPolicyCache
Enable caching of the authorization rules.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityBrokerExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityInstanceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationPolicyRule
The authorization rules to follow.
If no rule is set, but Authorization Resource is used that would mean DenyAll.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IAuthorizationRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityBrokerExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityInstanceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BrokerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: UpdateViaIdentityBroker, UpdateViaIdentityBrokerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BrokerName
Name of broker.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityInstance, UpdateViaIdentityInstanceExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: UpdateViaIdentityInstance, UpdateViaIdentityInstanceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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

### -Resource
Instance broker authorizations resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthorizationResource
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityBroker, UpdateViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Type: System.String
Parameter Sets: Update, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthorizationResource

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthorizationResource

## NOTES

## RELATED LINKS

