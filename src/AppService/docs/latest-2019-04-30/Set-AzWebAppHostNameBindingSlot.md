---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/set-azwebapphostnamebindingslot
schema: 2.0.0
---

# Set-AzWebAppHostNameBindingSlot

## SYNOPSIS
Creates a hostname binding for an app.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzWebAppHostNameBindingSlot -HostName <String> -Name <String> -ResourceGroupName <String> -Slot <String>
 [-SubscriptionId <String>] [-AzureResourceName <String>] [-AzureResourceType <AzureResourceType>]
 [-CustomHostNameDnsRecordType <CustomHostNameDnsRecordType>] [-DomainId <String>]
 [-HostNameType <HostNameType>] [-Kind <String>] [-SiteName <String>] [-SslState <SslState>]
 [-Thumbprint <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzWebAppHostNameBindingSlot -HostName <String> -Name <String> -ResourceGroupName <String> -Slot <String>
 -HostNameBinding <IHostNameBinding> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a hostname binding for an app.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AzureResourceName
Azure resource name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AzureResourceType
Azure resource type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.AzureResourceType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomHostNameDnsRecordType
Custom DNS record type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.CustomHostNameDnsRecordType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DomainId
Fully qualified ARM domain resource URI.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostName
Hostname in the hostname binding.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostNameBinding
A hostname binding object.
To construct, see NOTES section for HOSTNAMEBINDING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IHostNameBinding
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -HostNameType
Hostname type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.HostNameType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SiteName
App Service app name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will create a binding for the production slot.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SslState
SSL type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.SslState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Thumbprint
SSL certificate thumbprint

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IHostNameBinding

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20160801.IHostNameBinding

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### HOSTNAMEBINDING <IHostNameBinding>: A hostname binding object.
  - `[Kind <String>]`: Kind of resource.
  - `[AzureResourceName <String>]`: Azure resource name.
  - `[AzureResourceType <AzureResourceType?>]`: Azure resource type.
  - `[CustomHostNameDnsRecordType <CustomHostNameDnsRecordType?>]`: Custom DNS record type.
  - `[DomainId <String>]`: Fully qualified ARM domain resource URI.
  - `[HostNameType <HostNameType?>]`: Hostname type.
  - `[SiteName <String>]`: App Service app name.
  - `[SslState <SslState?>]`: SSL type
  - `[Thumbprint <String>]`: SSL certificate thumbprint

## RELATED LINKS

