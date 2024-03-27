---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/Az.PaloAltoNetworks/new-azpaloaltonetworksfrontendsettingobject
schema: 2.0.0
---

# New-AzPaloAltoNetworksFrontendSettingObject

## SYNOPSIS
Create an in-memory object for FrontendSetting.

## SYNTAX

```
New-AzPaloAltoNetworksFrontendSettingObject -BackendConfigurationPort <String>
 -FrontendConfigurationPort <String> -Name <String> -Protocol <String> [-Address <String>]
 [-BackendConfigurationAddress1 <String>] [-BackendConfigurationAddressResourceId <String>]
 [-FrontendConfigurationAddressResourceId <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for FrontendSetting.

## EXAMPLES

### Example 1: Create an in-memory object for FrontendSetting.
```powershell
New-AzPaloAltoNetworksFrontendSettingObject -BackendConfigurationPort "80" -FrontendConfigurationPort "80" -Name "azps-panfs" -Protocol 'TCP' -Address "20.22.91.251" -BackendConfigurationAddress1 "20.22.32.136" -BackendConfigurationAddressResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/mj-liftr-integration/providers/Microsoft.Network/publicIPAddresses/mj-liftr-integration-frontendSettingIp2" -FrontendConfigurationAddressResourceId "/subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/mj-liftr-integration/providers/Microsoft.Network/publicIPAddresses/mj-liftr-integration-frontendSettingIp1"
```

```output
Name       Protocol
----       --------
azps-panfs TCP
```

Create an in-memory object for FrontendSetting.

## PARAMETERS

### -Address
Address value.

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

### -BackendConfigurationAddress1
Address value.

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

### -BackendConfigurationAddressResourceId
Resource Id.

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

### -BackendConfigurationPort
port ID.

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

### -FrontendConfigurationAddressResourceId
Resource Id.

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

### -FrontendConfigurationPort
port ID.

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

### -Name
Settings name.

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

### -Protocol
Protocol Type.

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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.FrontendSetting

## NOTES

## RELATED LINKS
