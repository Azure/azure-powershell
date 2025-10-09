---
external help file: Az.Site-help.xml
Module Name: Az.Site
online version: https://learn.microsoft.com/powershell/module/az.site/get-azsite
schema: 2.0.0
---

# Get-AzSite

## SYNOPSIS
Get a Site

## SYNTAX

```
Get-AzSite [-Name <String>] [-ResourceGroupName <String>] [-SubscriptionId <String[]>]
 [-ServicegroupName <String>] [-InputObject <ISiteIdentity>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Site from different scopes: Resource Group, Subscription, or Service Group

## EXAMPLES

### Example 1: Get a specific site by name at resource group scope
```powershell
Get-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

Get a specific Azure Edge Site at resource group scope.

### Example 2: Get a specific site by name at subscription scope
```powershell
Get-AzSite -Name "mysite-001" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

Get a specific Azure Edge Site at subscription scope.

### Example 3: List all sites in a subscription
```powershell
Get-AzSite -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

List all Azure Edge Sites across all resource groups in the specified subscription.

### Example 4: Get a site at service group scope
```powershell
Get-AzSite -Name "mysite-sg-001" -ServicegroupName "my-service-group"
```

Get an Azure Edge Site managed at the service group scope.

## PARAMETERS

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
The name of the Site (optional for list operations)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SiteName

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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite

## NOTES

## RELATED LINKS
