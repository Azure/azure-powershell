---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azdownloadvpnsiteconfiguration
schema: 2.0.0
---

# Invoke-AzDownloadVpnSiteConfiguration

## SYNOPSIS
Gives the sas-url to download the configurations for vpn-sites in a resource group.

## SYNTAX

### DownloadSubscriptionIdViaHost (Default)
```
Invoke-AzDownloadVpnSiteConfiguration -ResourceGroupName <String> -VirtualWanName <String> [-PassThru]
 [-Request <IGetVpnSitesConfigurationRequest>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DownloadExpanded
```
Invoke-AzDownloadVpnSiteConfiguration -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualWanName <String> [-PassThru] -OutputBlobSasUrl <String> [-VpnSite <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Download
```
Invoke-AzDownloadVpnSiteConfiguration -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualWanName <String> [-PassThru] [-Request <IGetVpnSitesConfigurationRequest>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DownloadSubscriptionIdViaHostExpanded
```
Invoke-AzDownloadVpnSiteConfiguration -ResourceGroupName <String> -VirtualWanName <String> [-PassThru]
 -OutputBlobSasUrl <String> [-VpnSite <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Gives the sas-url to download the configurations for vpn-sites in a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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

### -OutputBlobSasUrl
The sas-url to download the configurations for vpn-sites

```yaml
Type: System.String
Parameter Sets: DownloadExpanded, DownloadSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

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

### -Request
List of Vpn-Sites

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IGetVpnSitesConfigurationRequest
Parameter Sets: DownloadSubscriptionIdViaHost, Download
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: DownloadExpanded, Download
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualWanName
The name of the VirtualWAN for which configuration of all vpn-sites is needed.

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

### -VpnSite
List of resource-ids of the vpn-sites for which config is to be downloaded.

```yaml
Type: System.String[]
Parameter Sets: DownloadExpanded, DownloadSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azdownloadvpnsiteconfiguration](https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azdownloadvpnsiteconfiguration)

