---
external help file: Az.Site-help.xml
Module Name: Az.Site
online version: https://learn.microsoft.com/powershell/module/az.site/update-azsite
schema: 2.0.0
---

# Update-AzSite

## SYNOPSIS
Update existing Azure Edge Sites across Resource Group, Subscription, and Service Group scopes

## SYNTAX

```
Update-AzSite -Name <String> [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [-ServicegroupName <String>] [-InputObject <ISiteIdentity>] [-Site <ISite>] [-JsonFilePath <String>]
 [-JsonString <String>] [-Description <String>] [-DisplayName <String>] [-City <String>] [-Country <String>]
 [-PostalCode <String>] [-StateOrProvince <String>] [-StreetAddress1 <String>] [-StreetAddress2 <String>]
 [-Labels <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
Updates existing Azure Edge Sites with support for multiple scopes. Use Resource Group scope (ResourceGroupName + SubscriptionId) to update sites within a specific resource group, Subscription scope (SubscriptionId only) to update sites directly under a subscription, or Service Group scope (ServicegroupName) to update sites within a service group. You can modify display names, descriptions, address information, and labels for existing sites.

## EXAMPLES

### Example 1: Update site display name and description
```powershell
Update-AzSite -SiteName "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Updated West Coast Site" -Description "Updated description for west coast operations"
```

```output
Name        : mysite-001
ResourceGroupName : rg-sites
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : Updated West Coast Site
Description       : Updated description for west coast operations
Country           : US
PostalCode        : 98101
StateOrProvince   : WA
City              : Seattle
StreetAddress1    : 123 Main St
ProvisioningState : Succeeded
```

Update an existing Azure Edge Site's display name and description.

### Example 2: Update site with new address information
```powershell
Update-AzSite -SiteName "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Country "US" -PostalCode "90210" -StateOrProvince "CA" -City "Beverly Hills" -StreetAddress1 "456 Rodeo Drive"
```

```output
Name        : mysite-001
ResourceGroupName : rg-sites
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : Updated West Coast Site
Description       : Updated description for west coast operations
Country           : US
PostalCode        : 90210
StateOrProvince   : CA
City              : Beverly Hills
StreetAddress1    : 456 Rodeo Drive
ProvisioningState : Succeeded
```

Update an existing Azure Edge Site's address information including country, postal code, state, city, and street address.

### Example 3: Update site labels
```powershell
$updatedLabels = @{
    "environment" = "staging"
    "region" = "west"
    "owner" = "dev-team"
    "priority" = "high"
}

Update-AzSite -SiteName "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Labels $updatedLabels
```

```output
Name        : mysite-001
ResourceGroupName : rg-sites
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : Updated West Coast Site
Description       : Updated description for west coast operations
Country           : US
PostalCode        : 90210
StateOrProvince   : CA
City              : Beverly Hills
StreetAddress1    : 456 Rodeo Drive
Labels            : {environment=staging, region=west, owner=dev-team, priority=high}
ProvisioningState : Succeeded
```

Update an existing Azure Edge Site's labels with new or modified key-value pairs for better organization and management.

### Example 4: Update site at subscription scope
```powershell
Update-AzSite -SiteName "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Updated Global Operations Site" -Description "Updated enterprise-wide operations center"
```

```output
Name        : global-site-001
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : Updated Global Operations Site
Description       : Updated enterprise-wide operations center
Country           : US
PostalCode        : 10001
StateOrProvince   : NY
City              : New York
ProvisioningState : Succeeded
```

Update an Azure Edge Site that exists at the subscription scope rather than within a specific resource group.

### Example 5: Update site at service group scope
```powershell
Update-AzSite -SiteName "service-site-001" -ServicegroupName "my-service-group" -DisplayName "Updated Service Group Site" -Description "Updated site managed at service group level"
```

```output
Name        : service-site-001
ServicegroupName  : my-service-group
DisplayName       : Updated Service Group Site
Description       : Updated site managed at service group level
Country           : US
PostalCode        : 78701
StateOrProvince   : TX
City              : Austin
ProvisioningState : Succeeded
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

### -Labels
Key-value pairs for labeling the site resource

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Site.Models.ISite

## NOTES

## RELATED LINKS
