---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/update-azwebappswiftvirtualnetworkconnection
schema: 2.0.0
---

# Update-AzWebAppSwiftVirtualNetworkConnection

## SYNOPSIS
Integrates this Web App with a Virtual Network.
This requires that 1) \"swiftSupported\" is true when doing a GET against this resource, and 2) that the target Subnet has already been delegated, and is not\nin use by another App Service Plan other than the one this App is in.

## SYNTAX

### Update (Default)
```
Update-AzWebAppSwiftVirtualNetworkConnection -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-ConnectionEnvelope <ISwiftVirtualNetwork>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzWebAppSwiftVirtualNetworkConnection -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Kind <String>] [-SubnetResourceId <String>] [-SwiftSupported <Boolean>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWebAppSwiftVirtualNetworkConnection -InputObject <IWebSiteIdentity> [-Kind <String>]
 [-SubnetResourceId <String>] [-SwiftSupported <Boolean>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzWebAppSwiftVirtualNetworkConnection -InputObject <IWebSiteIdentity>
 [-ConnectionEnvelope <ISwiftVirtualNetwork>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Integrates this Web App with a Virtual Network.
This requires that 1) \"swiftSupported\" is true when doing a GET against this resource, and 2) that the target Subnet has already been delegated, and is not\nin use by another App Service Plan other than the one this App is in.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -ConnectionEnvelope
Swift Virtual Network Contract.
This is used to enable the new Swift way of doing virtual network integration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISwiftVirtualNetwork
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the app.

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

### -ResourceGroupName
Name of the resource group to which the resource belongs.

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

### -SubnetResourceId
The Virtual Network subnet's resource ID.
This is the subnet that this Web App will join.
This subnet must have a delegation to Microsoft.Web/serverFarms defined first.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

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

### -SwiftSupported
A flag that specifies if the scale unit this Web App is on supports Swift integration.

```yaml
Type: System.Boolean
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20180201.ISwiftVirtualNetwork
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/update-azwebappswiftvirtualnetworkconnection](https://docs.microsoft.com/en-us/powershell/module/az.website/update-azwebappswiftvirtualnetworkconnection)

