---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/confirm-azwebsiteconnectionconsentcode
schema: 2.0.0
---

# Confirm-AzWebSiteConnectionConsentCode

## SYNOPSIS
Confirms consent code of a connection.

## SYNTAX

### Confirm (Default)
```
Confirm-AzWebSiteConnectionConsentCode -ConnectionName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Content <IConfirmConsentCodeInput>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ConfirmExpanded
```
Confirm-AzWebSiteConnectionConsentCode -ConnectionName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Code <String>] [-Id <String>] [-Kind <String>] -Location <String> [-Name <String>]
 [-ObjectId <String>] [-PrincipalType <PrincipalType>] [-Tag <IResourceTags>] [-TenantId <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ConfirmViaIdentityExpanded
```
Confirm-AzWebSiteConnectionConsentCode -InputObject <IWebSiteIdentity> [-Code <String>] [-Id <String>]
 [-Kind <String>] -Location <String> [-Name <String>] [-ObjectId <String>] [-PrincipalType <PrincipalType>]
 [-Tag <IResourceTags>] [-TenantId <String>] [-Type <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ConfirmViaIdentity
```
Confirm-AzWebSiteConnectionConsentCode -InputObject <IWebSiteIdentity> [-Content <IConfirmConsentCodeInput>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Confirms consent code of a connection.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Code
Code that was returned during consent flow

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionName
The connection name.

```yaml
Type: System.String
Parameter Sets: Confirm, ConfirmExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Content
Confirm Consent Code Input payload

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IConfirmConsentCodeInput
Parameter Sets: Confirm, ConfirmViaIdentity
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

### -Id
Resource Id

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
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
Parameter Sets: ConfirmViaIdentityExpanded, ConfirmViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource Location

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource Name

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
AAD object ID.
This is userId

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalType
Principal type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.PrincipalType
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Confirm, ConfirmExpanded
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
Parameter Sets: Confirm, ConfirmExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IResourceTags
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Tenant Id

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Resource type

```yaml
Type: System.String
Parameter Sets: ConfirmExpanded, ConfirmViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IConnection
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/confirm-azwebsiteconnectionconsentcode](https://docs.microsoft.com/en-us/powershell/module/az.website/confirm-azwebsiteconnectionconsentcode)

