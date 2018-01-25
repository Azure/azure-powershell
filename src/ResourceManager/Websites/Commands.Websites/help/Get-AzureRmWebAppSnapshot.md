---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
Module Name: AzureRM.WebSites
online version: 
schema: 2.0.0
---

# Get-AzureRmWebAppSnapshot

## SYNOPSIS
Gets snapshots of an Azure Web App.

## SYNTAX

### FromResourceName
```
Get-AzureRmWebAppSnapshot [-ResourceGroupName] <String> [-Name] <String> [[-Slot] <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

### FromWebApp
```
Get-AzureRmWebAppSnapshot [-WebApp] <Site> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Get-AzureRmWebAppSnapshot** cmdlet gets a list of the snapshots of an Azure Web App. Snapshots are data backups that are automatically created by Azure App Service. Snapshots can be restored with the **Restore-AzureRmWebAppSnapshot** cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmWebAppSnapshot -ResourceGroupName Default-Web-WestUS -Name MyWebApp
```

Gets the snapshots for an Azure Web App named MyWebApp in the Default-Web-WestUS ResourceGroup.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the web app.

```yaml
Type: String
Parameter Sets: FromResourceName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: FromResourceName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Slot
The name of the web app slot.

```yaml
Type: String
Parameter Sets: FromResourceName
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WebApp
The web app object

```yaml
Type: Site
Parameter Sets: FromWebApp
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

## INPUTS

### System.String
Microsoft.Azure.Management.WebSites.Models.Site


## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore.AzureWebAppSnapshot[]


## NOTES

## RELATED LINKS

