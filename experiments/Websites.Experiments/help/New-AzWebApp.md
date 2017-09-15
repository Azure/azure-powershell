---
external help file: AzureRM.Websites.Experiments-help.xml
online version: 
schema: 2.0.0
---

# New-AzWebApp

## SYNOPSIS
Create a new Azure AppService website and attach it to a git repository.

## SYNTAX

```
New-AzWebApp [[-WebAppName] <String>] [[-ResourceGroupName] <String>] [[-AppServicePlan] <String>] [-Auto]
 [-AddRemote] [[-GitRepositoryPath] <String>]
```

## DESCRIPTION
Create a new Azure AppService website and attach it to a git repository.

## EXAMPLES

### Example 1: Create a website with prompts for settings
```
PS C:\> New-AzWebApp contosoWebApp
```

Creates a web application.  The user will be prompted for the appservice to use and other settings.

## Example 2: Create a website with default settings
```
PS C:\> New-AzWebApp contosoWebApp -Auto
```

Creates a web application using default settings.


## PARAMETERS

### -AddRemote
Add a remote to local github repo.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppServicePlan
The name or id of the AppService Plan to use with this WebApp.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Plan

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Auto
Accept default values for all settings not provided, withotu prompting.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryPath
The path to a github repository where remotes should be added.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group for the Website.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Group

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebAppName
The name of the Website. The website will automatically use this value as the subdomain for the created website.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### None


## OUTPUTS

### Microsoft.Azure.Management.WebSites.Models.Site
Details about the created website, including URL and github repo url.


## NOTES

## RELATED LINKS

