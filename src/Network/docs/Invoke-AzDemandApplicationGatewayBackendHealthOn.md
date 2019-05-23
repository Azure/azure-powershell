---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azdemandapplicationgatewaybackendhealthon
schema: 2.0.0
---

# Invoke-AzDemandApplicationGatewayBackendHealthOn

## SYNOPSIS
Gets the backend health for given combination of backend pool and http setting of the specified application gateway in a resource group.

## SYNTAX

### Demand (Default)
```
Invoke-AzDemandApplicationGatewayBackendHealthOn -ApplicationGatewayName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Expand <String>] [-ProbeRequest <IApplicationGatewayOnDemandProbe>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DemandExpanded
```
Invoke-AzDemandApplicationGatewayBackendHealthOn -ApplicationGatewayName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Expand <String>] [-BackendHttpSettingName <String>] [-BackendPoolName <String>]
 [-Host <String>] [-MatchBody <String>] [-MatchStatusCode <String[]>] [-Path <String>]
 [-PickHostNameFromBackendHttpSetting <Boolean>] [-Protocol <ApplicationGatewayProtocol>] [-Timeout <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DemandViaIdentityExpanded
```
Invoke-AzDemandApplicationGatewayBackendHealthOn -InputObject <INetworkIdentity> [-Expand <String>]
 [-BackendHttpSettingName <String>] [-BackendPoolName <String>] [-Host <String>] [-MatchBody <String>]
 [-MatchStatusCode <String[]>] [-Path <String>] [-PickHostNameFromBackendHttpSetting <Boolean>]
 [-Protocol <ApplicationGatewayProtocol>] [-Timeout <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DemandViaIdentity
```
Invoke-AzDemandApplicationGatewayBackendHealthOn -InputObject <INetworkIdentity> [-Expand <String>]
 [-ProbeRequest <IApplicationGatewayOnDemandProbe>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the backend health for given combination of backend pool and http setting of the specified application gateway in a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ApplicationGatewayName
The name of the application gateway.

```yaml
Type: System.String
Parameter Sets: Demand, DemandExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -BackendHttpSettingName
Name of backend http setting of application gateway to be used for test probe

```yaml
Type: System.String
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendPoolName
Name of backend pool of application gateway to which probe request will be sent.

```yaml
Type: System.String
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
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

### -Expand
Expands BackendAddressPool and BackendHttpSettings referenced in backend health.

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

### -Host
Host name to send the probe to.

```yaml
Type: System.String
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: DemandViaIdentityExpanded, DemandViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MatchBody
Body that must be contained in the health response.
Default value is empty.

```yaml
Type: System.String
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MatchStatusCode
Allowed ranges of healthy status codes.
Default range of healthy status codes is 200-399.

```yaml
Type: System.String[]
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Relative path of probe.
Valid path starts from '/'.
Probe is sent to \<Protocol\>://\<host\>:\<port\>\<path\>

```yaml
Type: System.String
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PickHostNameFromBackendHttpSetting
Whether the host header should be picked from the backend http settings.
Default value is false.

```yaml
Type: System.Boolean
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeRequest
Details of on demand test probe request

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe
Parameter Sets: Demand, DemandViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Protocol
The protocol used for the probe.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Demand, DemandExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Demand, DemandExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timeout
The probe timeout in seconds.
Probe marked as failed if valid response is not received with this timeout period.
Acceptable values are from 1 second to 86400 seconds.

```yaml
Type: System.Int32
Parameter Sets: DemandExpanded, DemandViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthOnDemand
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azdemandapplicationgatewaybackendhealthon](https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azdemandapplicationgatewaybackendhealthon)

