---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/new-azspringapiportal
schema: 2.0.0
---

# New-AzSpringApiPortal

## SYNOPSIS
Create the default API portal or update the existing API portal.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSpringApiPortal -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-GatewayId <String[]>] [-HttpsOnly] [-Public] [-SkuCapacity <Int32>]
 [-SkuName <String>] [-SkuTier <String>] [-SourceUrl <String[]>] [-SsoPropertyClientId <String>]
 [-SsoPropertyClientSecret <String>] [-SsoPropertyIssuerUri <String>] [-SsoPropertyScope <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentitySpringExpanded
```
New-AzSpringApiPortal -Name <String> -SpringInputObject <ISpringIdentity> [-GatewayId <String[]>] [-HttpsOnly]
 [-Public] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-SourceUrl <String[]>]
 [-SsoPropertyClientId <String>] [-SsoPropertyClientSecret <String>] [-SsoPropertyIssuerUri <String>]
 [-SsoPropertyScope <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzSpringApiPortal -Name <String> -ResourceGroupName <String> -ServiceName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzSpringApiPortal -Name <String> -ResourceGroupName <String> -ServiceName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create the default API portal or update the existing API portal.

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

### -GatewayId
The array of resource Ids of gateway to integrate with API portal.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpsOnly
Indicate if only https is allowed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of API portal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApiPortalName

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

### -Public
Indicates whether the API portal exposes endpoint.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the Sku

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Tier of the Sku

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceUrl
Collection of OpenAPI source URL locations.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter
To construct, see NOTES section for SPRINGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: CreateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SsoPropertyClientId
The public identifier for the application

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SsoPropertyClientSecret
The secret known only to the application and the authorization server

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SsoPropertyIssuerUri
The URI of Issuer Identifier

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SsoPropertyScope
It defines the specific actions applications can be allowed to do on a user's behalf

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IApiPortalResource

## NOTES

## RELATED LINKS

