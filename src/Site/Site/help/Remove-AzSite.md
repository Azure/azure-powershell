---
external help file: Az.Site-help.xml
Module Name: Az.Site
online version: https://learn.microsoft.com/powershell/module/az.site/remove-azsite
schema: 2.0.0
---

# Remove-AzSite

## SYNOPSIS
Remove Azure Edge Sites across Resource Group, Subscription, and Service Group scopes

## SYNTAX

```
Remove-AzSite -Name <String> [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [-ServicegroupName <String>] [-InputObject <ISiteIdentity>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Permanently deletes Azure Edge Sites with support for multiple scopes. Use Resource Group scope (ResourceGroupName + SubscriptionId) to remove sites within a specific resource group, Subscription scope (SubscriptionId only) to remove sites directly under a subscription, or Service Group scope (ServicegroupName) to remove sites within a service group. This operation cannot be undone, so use with caution.

## EXAMPLES

### Example 1: Remove a site from resource group scope
```powershell
Remove-AzSite -SiteName "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

```output
(No output - operation completed successfully)
```

Remove an Azure Edge Site from a specific resource group. This operation permanently deletes the site and cannot be undone.

### Example 2: Remove a site from subscription scope
```powershell
Remove-AzSite -SiteName "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

```output
(No output - operation completed successfully)
```

Remove an Azure Edge Site that exists at the subscription scope rather than within a specific resource group.

### Example 3: Remove a site from service group scope
```powershell
Remove-AzSite -SiteName "service-site-001" -ServicegroupName "my-service-group"
```

```output
(No output - operation completed successfully)
```

Remove an Azure Edge Site that exists at the service group scope.

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
Use the SubscriptionId parameter when available.

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
Identity Parameter for pipeline operations

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Site

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SiteName

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

### -PassThru
Returns true when the command succeeds

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
Required for resource group scope operations.

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

### -ServicegroupName
The name of the service group.
Required for service group scope operations.

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

### -SubscriptionId
The ID of the target subscription.
Required for resource group and subscription scope operations.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
