---
external help file:
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/get-aziotoperationsservicebrokerauthentication
schema: 2.0.0
---

# Get-AzIoTOperationsServiceBrokerAuthentication

## SYNOPSIS
Get a BrokerAuthenticationResource

## SYNTAX

### List (Default)
```
Get-AzIoTOperationsServiceBrokerAuthentication -BrokerName <String> -InstanceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName <String> -BrokerName <String>
 -InstanceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzIoTOperationsServiceBrokerAuthentication -InputObject <IIoTOperationsServiceIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityBroker
```
Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName <String>
 -BrokerInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityInstance
```
Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName <String> -BrokerName <String>
 -InstanceInputObject <IIoTOperationsServiceIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a BrokerAuthenticationResource

## EXAMPLES

### List (Default)
```powershell

```

Get-AzIoTOperationsServiceBrokerAuthentication -BrokerName \<String\> -InstanceName \<String\>
 -ResourceGroupName \<String\> [-SubscriptionId \<String[]\>] [-DefaultProfile \<PSObject\>] [\<CommonParameters\>]
```

### Get
```powershell

```

Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName \<String\> -BrokerName \<String\>
 -InstanceName \<String\> -ResourceGroupName \<String\> [-SubscriptionId \<String[]\>] [-DefaultProfile \<PSObject\>]
 [\<CommonParameters\>]
```

### GetViaIdentity
```powershell

```

Get-AzIoTOperationsServiceBrokerAuthentication -InputObject \<IIoTOperationsServiceIdentity\>
 [-DefaultProfile \<PSObject\>] [\<CommonParameters\>]
```

### GetViaIdentityBroker
```powershell

```

Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName \<String\>
 -BrokerInputObject \<IIoTOperationsServiceIdentity\> [-DefaultProfile \<PSObject\>] [\<CommonParameters\>]
```

### GetViaIdentityInstance
```powershell

```

Get-AzIoTOperationsServiceBrokerAuthentication -AuthenticationName \<String\> -BrokerName \<String\>
 -InstanceInputObject \<IIoTOperationsServiceIdentity\> [-DefaultProfile \<PSObject\>] [\<CommonParameters\>]
```

## DESCRIPTION
Get a BrokerAuthenticationResource

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

### -AuthenticationName
```powershell

```

Type: System.String
Parameter Sets: Get, GetViaIdentityBroker, GetViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BrokerInputObject
```powershell

```

Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityBroker
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BrokerName
```powershell

```

Type: System.String
Parameter Sets: Get, GetViaIdentityInstance, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
```powershell

```

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
```powershell

```

Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceInputObject
```powershell

```

Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
```powershell

```

Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
```powershell

```

Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
```powershell

```

Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
```powershell

```

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
```powershell

```

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthenticationResource
```powershell

```

## NOTES

## RELATED LINKS

## PARAMETERS

### -AuthenticationName
Name of Instance broker authentication resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBroker, GetViaIdentityInstance
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BrokerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity
Parameter Sets: GetViaIdentityBroker
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
Parameter Sets: Get, GetViaIdentityInstance, List
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
Parameter Sets: GetViaIdentity
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
Parameter Sets: GetViaIdentityInstance
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
Parameter Sets: Get, List
Aliases:

Required: True
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IIoTOperationsServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IBrokerAuthenticationResource

## NOTES

## RELATED LINKS

