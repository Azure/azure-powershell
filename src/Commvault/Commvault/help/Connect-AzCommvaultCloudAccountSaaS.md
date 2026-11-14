---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/connect-azcommvaultcloudaccountsaas
schema: 2.0.0
---

# Connect-AzCommvaultCloudAccountSaaS

## SYNOPSIS
Links a new SaaS to the cloud account.

## SYNTAX

### LinkExpanded (Default)
```
Connect-AzCommvaultCloudAccountSaaS -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-SaaSResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaJsonString
```
Connect-AzCommvaultCloudAccountSaaS -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Connect-AzCommvaultCloudAccountSaaS -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Link
```
Connect-AzCommvaultCloudAccountSaaS -CloudAccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Body <ISaaSData> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Connect-AzCommvaultCloudAccountSaaS -InputObject <ICommvaultIdentity> [-SaaSResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### LinkViaIdentity
```
Connect-AzCommvaultCloudAccountSaaS -InputObject <ICommvaultIdentity> -Body <ISaaSData>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Links a new SaaS to the cloud account.

## EXAMPLES

### Example 1: Link a SaaS resource to a cloud account
```powershell
Connect-AzCommvaultCloudAccountSaaS -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -SaaSResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Microsoft.SaaS/resources/commvault-saas'
```

Links the SaaS resource to the cloud account.

### Example 2: Link a SaaS resource to a cloud account by using a JSON request
```powershell
Connect-AzCommvaultCloudAccountSaaS -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -JsonString '{"saaSResourceId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Microsoft.SaaS/resources/commvault-saas"}'
```

Links the SaaS resource to the cloud account by passing the request body as a JSON string.

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

### -Body
SaaS-related data properties

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ISaaSData
Parameter Sets: Link, LinkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: LinkViaIdentityExpanded, LinkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonString
Aliases:

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SaaSResourceId
SaaS resource id

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ISaaSData

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICloudAccount

## NOTES

## RELATED LINKS
