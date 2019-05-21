---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebapprelayserviceconnectionslot
schema: 2.0.0
---

# New-AzWebAppRelayServiceConnectionSlot

## SYNOPSIS
Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).

## SYNTAX

### Create (Default)
```
New-AzWebAppRelayServiceConnectionSlot -EntityName <String> -Name <String> -ResourceGroupName <String>
 -Slot <String> -SubscriptionId <String> [-ConnectionEnvelope <IRelayServiceConnectionEntity>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWebAppRelayServiceConnectionSlot [-EntityName <String>] -InputObject <IWebSiteIdentity>
 [-BiztalkUri <String>] [-EntityConnectionString <String>] [-Hostname <String>] [-Kind <String>]
 [-Port <Int32>] [-ResourceConnectionString <String>] [-ResourceType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzWebAppRelayServiceConnectionSlot -EntityName <String> -Name <String> -ResourceGroupName <String>
 -Slot <String> -SubscriptionId <String> [-BiztalkUri <String>] [-EntityConnectionString <String>]
 [-Hostname <String>] [-Kind <String>] [-Port <Int32>] [-PropertiesEntityName <String>]
 [-ResourceConnectionString <String>] [-ResourceType <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWebAppRelayServiceConnectionSlot -InputObject <IWebSiteIdentity>
 [-ConnectionEnvelope <IRelayServiceConnectionEntity>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new hybrid connection configuration (PUT), or updates an existing one (PATCH).

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -BiztalkUri
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionEnvelope
Hybrid Connection for an App Service app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IRelayServiceConnectionEntity
Parameter Sets: Create, CreateViaIdentity
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

### -EntityConnectionString
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EntityName
Name of the hybrid connection configuration.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Hostname
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
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
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Port
HELP MESSAGE MISSING

```yaml
Type: System.Int32
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesEntityName
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceConnectionString
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will create or update a hybrid connection for the production slot.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160801.IRelayServiceConnectionEntity
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebapprelayserviceconnectionslot](https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebapprelayserviceconnectionslot)

