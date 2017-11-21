---
external help file: Microsoft.Azure.Commands.Websites.dll-Help.xml
Module Name: AzureRM.WebSites
online version: 
schema: 2.0.0
---

# Restore-AzureRmWebAppSnapshot

## SYNOPSIS
Restores an Azure Web App snapshot.

## SYNTAX

### FromResourceName
```
Restore-AzureRmWebAppSnapshot [-RecoverConfiguration] [-TargetApp <Site>] [-Force]
 [-ResourceGroupName] <String> [-Name] <String> [[-Slot] <String>] [-DefaultProfile <IAzureContextContainer>]
 [-SnapshotTime] <String>
```

### FromWebApp
```
Restore-AzureRmWebAppSnapshot [-RecoverConfiguration] [-TargetApp <Site>] [-Force] [-WebApp] <Site>
 [-DefaultProfile <IAzureContextContainer>] [-SnapshotTime] <String>
```

## DESCRIPTION
The **Restore-AzureRmWebAppSnapshot** cmdlet restores an Azure Web App snapshot. The web app will be overwritten with the contents of the snapshot. To prevent data loss, it is best to use the TargetApp parameter with a web app slot. Once the restore is finished, the slots can be swapped with the **Switch-AzureRmWebAppSlot** cmdlet.

## EXAMPLES

### Example 1
```
PS C:\> Restore-AzureRmWebAppSnapshot -ResourceGroupName Default-Web-WestUS -Name MyWebApp -SnapshotTime "09/27/2017 00:05:04"
```

Reverts the contents of MyWebApp to the snapshot taken at 09/27/2017 00:05:04.

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

### -Force
Restore the snapshot without displaying warning about possible data loss.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -RecoverConfiguration
Recover the web app's configuration in addition to files.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
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

### -SnapshotTime
The timestamp of the snapshot.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetApp
The app that the snapshot contents will be restored to.
Must be a slot of the original app.
If unspecified, the original app is overwritten.

```yaml
Type: Site
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
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

### System.Management.Automation.SwitchParameter
Microsoft.Azure.Management.WebSites.Models.Site
System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

