---
external help file: Az.Site-help.xml
Module Name: Az.Site
online version: https://learn.microsoft.com/powershell/module/az.site/new-azsite
schema: 2.0.0
---

# New-AzSite

## SYNOPSIS
Create new Azure Edge Sites across Resource Group, Subscription, and Service Group scopes

## SYNTAX

```
New-AzSite -SiteName <String> [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [-ServicegroupName <String>] [-InputObject <ISiteIdentity>] [-Site <ISite>] [-JsonFilePath <String>]
 [-JsonString <String>] [-Description <String>] [-DisplayName <String>] [-City <String>] [-Country <String>]
 [-PostalCode <String>] [-StateOrProvince <String>] [-StreetAddress1 <String>] [-StreetAddress2 <String>]
 [-Labels <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
Creates new Azure Edge Sites with support for multiple scopes. Use Resource Group scope (ResourceGroupName + SubscriptionId) to create sites within a specific resource group, Subscription scope (SubscriptionId only) to create sites directly under a subscription, or Service Group scope (ServicegroupName) to create sites within a service group. Sites can be configured with display names, descriptions, address information, and custom labels for organization and management.

## EXAMPLES

### Example 1: Create a new site at resource group scope with basic information
```powershell
New-AzSite -SiteName "mysite-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "West Coast Site" -Description "Primary site for west coast operations" -Country "US" -PostalCode "98101"
```

```output
Name        : mysite-001
ResourceGroupName : rg-sites
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : West Coast Site
Description       : Primary site for west coast operations
Country           : US
PostalCode        : 98101
ProvisioningState : Succeeded
```

Create a new Azure Edge Site with basic information including display name, description, and address details.

### Example 2: Create a site with complete address information and labels
```powershell
$labels = @{
    "environment" = "production"
    "region" = "west"
    "owner" = "operations-team"
}

New-AzSite -SiteName "mysite-002" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Seattle Operations Center" -Description "Main operations site for Seattle region" -Country "US" -PostalCode "98101" -StateOrProvince "WA" -City "Seattle" -StreetAddress1 "123 Main St" -Labels $labels
```

```output
Name        : mysite-002
ResourceGroupName : rg-sites
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : Seattle Operations Center
Description       : Main operations site for Seattle region
Country           : US
PostalCode        : 98101
StateOrProvince   : WA
City              : Seattle
StreetAddress1    : 123 Main St
Labels            : {environment=production, region=west, owner=operations-team}
ProvisioningState : Succeeded
```

Create a new Azure Edge Site with complete address information and custom labels for better organization and management.

### Example 3: Create a site at subscription scope
```powershell
New-AzSite -SiteName "global-site-001" -SubscriptionId "12345678-1234-1234-1234-123456789012" -DisplayName "Global Operations Site" -Description "Enterprise-wide operations center" -Country "US" -PostalCode "10001"
```

```output
Name        : global-site-001
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : Global Operations Site
Description       : Enterprise-wide operations center
Country           : US
PostalCode        : 10001
ProvisioningState : Succeeded
```

Create a new Azure Edge Site at the subscription scope rather than within a specific resource group.

### Example 4: Create a site using JSON configuration
```powershell
$jsonConfig = @"
{
    "properties": {
        "displayName": "JSON Created Site",
        "description": "Site created via JSON configuration",
        "siteAddress": {
            "country": "CA",
            "postalCode": "K1A 0A6",
            "stateOrProvince": "ON",
            "city": "Ottawa",
            "streetAddress1": "100 Wellington St"
        },
        "labels": {
            "deployment-method": "json",
            "country": "canada"
        }
    }
}
"@

New-AzSite -SiteName "site-json-001" -ResourceGroupName "rg-sites" -SubscriptionId "12345678-1234-1234-1234-123456789012" -JsonString $jsonConfig
```

```output
Name        : site-json-001
ResourceGroupName : rg-sites
SubscriptionId    : 12345678-1234-1234-1234-123456789012
DisplayName       : JSON Created Site
Description       : Site created via JSON configuration
Country           : CA
PostalCode        : K1A 0A6
StateOrProvince   : ON
City              : Ottawa
StreetAddress1    : 100 Wellington St
Labels            : {deployment-method=json, country=canada}
ProvisioningState : Succeeded
```

Create a new Azure Edge Site using a JSON configuration string for complex deployments or infrastructure-as-code scenarios.

### Example 5: Create a site at service group scope
```powershell
New-AzSite -SiteName "service-site-001" -ServicegroupName "my-service-group" -DisplayName "Service Group Site" -Description "Site managed at service group level" -Country "US" -PostalCode "78701"
```

```output
Name        : service-site-001
ServicegroupName  : my-service-group
DisplayName       : Service Group Site
Description       : Site managed at service group level
Country           : US
PostalCode        : 78701
ProvisioningState : Succeeded
```

Create a new Azure Edge Site at the service group scope.

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

### -SiteName
The name of the Site

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
