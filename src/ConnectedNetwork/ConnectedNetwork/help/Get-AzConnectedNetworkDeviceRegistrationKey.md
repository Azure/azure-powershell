---
external help file: Az.ConnectedNetwork-help.xml
Module Name: Az.ConnectedNetwork
online version: https://learn.microsoft.com/powershell/module/az.connectednetwork/get-azconnectednetworkdeviceregistrationkey
schema: 2.0.0
---

# Get-AzConnectedNetworkDeviceRegistrationKey

## SYNOPSIS
List the registration key for the device.

## SYNTAX

```
Get-AzConnectedNetworkDeviceRegistrationKey -DeviceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List the registration key for the device.

## EXAMPLES

### Example 1: Get-AzConnectedNetworkDeviceRegistrationKey using Resource Group, Resource name
```powershell
Get-AzConnectedNetworkDeviceRegistrationKey -DeviceName myMecDevice -ResourceGroupName myResources
```

```output
eyJNZWNEZXZpY2VUcmFuc2llbnRBdXRoS2V5IjoiMTIzNCIsIk1lY0RldmljZUF1dGhLZXlTdGFydFRpbWUiOiIyMDIxLTExLTIyVDA5OjQ2OjQwLjY0ODExOTFaIiwiU2VydmljZUJ1c1F1ZXVlTmFtZSI6ImFiY2QtMTIzNCIsIkFBREVuZHBvaW50IjpudWxsLCJBQURBdWRpZW5jZSI6bnVsbCwiQXJtUmVzb3VyY2VJZCI6bnVsbCwiTWVjQ29udHJvbGxlckVuZHBvaW50IjoiaHR0cHM6Ly93ZXN0Y2VudHJhbHVzLXByb2QubWVjZGV2aWNlLmF6dXJlLmNvbTo0NDMiLCJEYmVEZXZpY2VJZCI6bnVsbCwiUmVzb3VyY2VVbmlxdWVJZCI6IjEyMy1hYmMtMTIzIiwiU3Vic2NyaXB0aW9uSWQiOiJ4eHh4LTEyMzQteHh4eC0xMjM0IiwiUmVzb3VyY2VHcm91cE5hbWUiOiJzYW1wbGVSR25hbWUiLCJQcm92aWRlck5hbWVzcGFjZSI6Ik1pY3Jvc29mdC5IeWJyaWROZXR3b3JrIiwiUmVzb3VyY2VUeXBlIjoiRGV2aWNlcyIsIlJlc291cmNlVHlwZU5hbWUiOiJJREMtRGV2aWNlNC1XZXN0Q2VudHJhbCJ9
```

Getting the registration key for NFM device in resource group myResources with resource name myMecDevice.
To register the device, use the commandlet Invoke-MecRegister with the registration key in the minishell session.

### Example 2: Get-AzConnectedNetworkDeviceRegistrationKey using Resource Group, Resource name and Subscription Id
```powershell
Get-AzConnectedNetworkDeviceRegistrationKey -DeviceName myMecDevice -ResourceGroupName myResources -SubscriptionId xxxxx-00000-xxxxx-00000
```

```output
eyJNZWNEZXZpY2VUcmFuc2llbnRBdXRoS2V5IjoiMTIzNCIsIk1lY0RldmljZUF1dGhLZXlTdGFydFRpbWUiOiIyMDIxLTExLTIyVDA5OjQ2OjQwLjY0ODExOTFaIiwiU2VydmljZUJ1c1F1ZXVlTmFtZSI6ImFiY2QtMTIzNCIsIkFBREVuZHBvaW50IjpudWxsLCJBQURBdWRpZW5jZSI6bnVsbCwiQXJtUmVzb3VyY2VJZCI6bnVsbCwiTWVjQ29udHJvbGxlckVuZHBvaW50IjoiaHR0cHM6Ly93ZXN0Y2VudHJhbHVzLXByb2QubWVjZGV2aWNlLmF6dXJlLmNvbTo0NDMiLCJEYmVEZXZpY2VJZCI6bnVsbCwiUmVzb3VyY2VVbmlxdWVJZCI6IjEyMy1hYmMtMTIzIiwiU3Vic2NyaXB0aW9uSWQiOiJ4eHh4LTEyMzQteHh4eC0xMjM0IiwiUmVzb3VyY2VHcm91cE5hbWUiOiJzYW1wbGVSR25hbWUiLCJQcm92aWRlck5hbWVzcGFjZSI6Ik1pY3Jvc29mdC5IeWJyaWROZXR3b3JrIiwiUmVzb3VyY2VUeXBlIjoiRGV2aWNlcyIsIlJlc291cmNlVHlwZU5hbWUiOiJJREMtRGV2aWNlNC1XZXN0Q2VudHJhbCJ9
```

Getting the registration key for NFM device in resource group myResources with resource name myMecDevice.
To register the device, use the commandlet Invoke-MecRegister with the registration key in the minishell session.

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

### -DeviceName
The name of the device resource.

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

### System.String

## NOTES

## RELATED LINKS
