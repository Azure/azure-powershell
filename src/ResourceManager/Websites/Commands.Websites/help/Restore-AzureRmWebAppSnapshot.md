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
Restore-AzureRmWebAppSnapshot [-RecoverConfiguration] [-TargetApp <Site>] [-Force] [-AsJob]
 [-ResourceGroupName] <String> [-Name] <String> [[-Slot] <String>] [-DefaultProfile <IAzureContextContainer>]
 [-SnapshotTime] <DateTime> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FromWebApp
```
Restore-AzureRmWebAppSnapshot [-RecoverConfiguration] [-TargetApp <Site>] [-Force] [-AsJob] [-WebApp] <Site>
 [-DefaultProfile <IAzureContextContainer>] [-SnapshotTime] <DateTime> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FromWebAppSnapshot
```
Restore-AzureRmWebAppSnapshot [-RecoverConfiguration] [-TargetApp <Site>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] -WebAppSnapshot <AzureWebAppSnapshot> [-SnapshotTime] <DateTime>
 [-WhatIf] [-Confirm] [<CommonParameters>]
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

### -AsJob
Run cmdlet in the background```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: DateTime
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

### -WebAppSnapshot
The Azure Web App snapshot.```yaml
Type: AzureWebAppSnapshot
Parameter Sets: FromWebAppSnapshot
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.SwitchParameter
Microsoft.Azure.Management.WebSites.Models.Site
System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

