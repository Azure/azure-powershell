---
external help file:
Module Name: Az.Site
online version: https://learn.microsoft.com/powershell/module/az.site/update-azsite
schema: 2.0.0
---

# Update-AzSite

## SYNOPSIS
Update a Site

## SYNTAX

```
Update-AzSite -Name <String> [-InputObject <ISiteIdentity>] [-ResourceGroupName <String>]
 [-ServicegroupName <String>] [-SubscriptionId <String>] [-City <String>] [-Country <String>]
 [-Description <String>] [-DisplayName <String>] [-JsonFilePath <String>] [-JsonString <String>]
 [-Label <Hashtable>] [-PostalCode <String>] [-Site <ISite>] [-StateOrProvince <String>]
 [-StreetAddress1 <String>] [-StreetAddress2 <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Site in different scopes: Resource Group, Subscription, or Service Group

## EXAMPLES

### Example 1: Update a site's description and labels
```powershell
$newLabels = @{
    "environment" = "updated"
    "version" = "2.0"
    "updated-by" = "admin"
}

Update-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Description "Updated site description" -Labels $newLabels
```

Update an existing Azure Edge Site's description and labels while preserving other properties.

### Example 2: Update only the display name
```powershell
Update-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Updated West Coast Site"
```

Perform a partial update to change only the display name while leaving all other properties unchanged.

### Example 3: Update a site using JSON configuration
```powershell
$jsonUpdate = @"
{
    "properties": {
        "displayName": "JSON Updated Site",
        "description": "Updated via JSON configuration",
        "labels": {
            "update-method": "json",
            "automation": "true"
        }
    }
}
"@

Update-AzSite -Name "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -JsonString $jsonUpdate
```

Update an Azure Edge Site using a JSON configuration for complex updates or automation scenarios.

### Example 4: Update a site at subscription scope
```powershell
Update-AzSite -Name "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Updated Global Site" -Description "Updated enterprise operations center"
```

Update an Azure Edge Site that exists at the subscription scope rather than within a specific resource group.

### Example 5: Update a site at service group scope
```powershell
Update-AzSite -Name "service-site-001" -ServicegroupName "my-service-group" -DisplayName "Updated Service Group Site" -Description "Updated service group managed site"
```

Update an Azure Edge Site that exists at the service group scope.

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

### -City
City of the address

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

### -Country
Country of the address

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

### -Description
Expanded parameters for Site creation
Description of Site resource

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

### -DisplayName
Display name of Site resource

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

### -JsonFilePath
Path of Json file supplied to the Site operation

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

### -JsonString
Json string supplied to the Site operation

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

### -Label
Key-value pairs for labeling the site resource

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: Labels

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -PostalCode
Postal or ZIP code of the address

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

### -Site
Site details

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StateOrProvince
State or province of the address

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

### -StreetAddress1
First line of the street address

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

### -StreetAddress2
Second line of the street address

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

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite

## NOTES

## RELATED LINKS

