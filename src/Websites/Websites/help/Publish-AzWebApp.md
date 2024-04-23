---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/publish-azwebapp
schema: 2.0.0
---

# Publish-AzWebApp

## SYNOPSIS
Deploys an Azure Web App from a ZIP, JAR, or WAR file using zipdeploy. 

## SYNTAX

### FromWebApp (Default)
```
Publish-AzWebApp -ArchivePath <String> [-Type <String>] [-Clean] [-Async] [-Restart] [-TargetPath <String>]
 [-IgnoreStack] [-Reset] [-Force] [-AsJob] [-Timeout <Double>] [-WebApp] <PSSite>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FromResourceName
```
Publish-AzWebApp -ArchivePath <String> [-Type <String>] [-Clean] [-Async] [-Restart] [-TargetPath <String>]
 [-IgnoreStack] [-Reset] [-Force] [-AsJob] [-Timeout <Double>] [-ResourceGroupName] <String> [-Name] <String>
 [[-Slot] <String>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Publish-AzWebApp** cmdlet uploads content to an existing Azure Web App. The content should be packaged in a ZIP file if using stacks such as .NET, Python, or Node, or a WAR or JAR file if using Java. The content should be pre-built and ready-to-run without any additional build steps during deployment. This cmdlet uses the Kudu zipdeploy and wardeploy features to deploy content. Refer to the Kudu wiki for details about how zipdeploy and wardeploy work, and how to properly package a web app for deployment. https://aka.ms/kuduzipdeploy and https://aka.ms/kuduwardeploy contain helpful details about zipdeploy and wardeploy.

## EXAMPLES

### Example 1
```powershell
Publish-AzWebApp -ResourceGroupName Default-Web-WestUS -Name MyApp -ArchivePath C:\project\app.zip
```

Uploads the contents of app.zip to the web app named MyApp belonging to the resource group Default-Web-WestUS.

### Example 2
```powershell
Publish-AzWebApp -ResourceGroupName ContosoRG -Name ContosoApp -Slot Staging -ArchivePath C:\project\javaproject.war
```

Uploads the contents of javaproject.war to the Staging slot of the web app named ContosoApp belonging to the resource group ContosoRG.

### Example 3
```powershell
$app = Get-AzWebApp -ResourceGroupName ContosoRG -Name ContosoApp
Publish-AzWebApp -WebApp $app -ArchivePath C:\project\app.zip -AsJob
```

Uploads the contents of app.zip to the web app named ContosoApp belonging to the resource group ContosoRG. The cmdlet will be run in a background job.

### Example 4
```powershell
$app = Get-AzWebApp -ResourceGroupName ContosoRG -Name ContosoApp
$app | Publish-AzWebApp -ArchivePath C:\project\java_app.jar
```

### Example 5
```powershell
$app = Get-AzWebApp -ResourceGroupName ContosoRG -Name ContosoApp
Publish-AzWebApp -WebApp $app -ArchivePath C:\project\app.zip -Force
```

Uploads the contents of java_app.jar to the web app named ContosoApp belonging to the resource group ContosoRG. If -Force is not specified it will prompt for the confirmation before the contents will be deployed.

### Example 6
```powershell
$app = Get-AzWebApp -ResourceGroupName ContosoRG -Name ContosoApp
Publish-AzWebApp -WebApp $app -ArchivePath C:\project\app.zip -Timeout 300000 -Force
```

Uploads the contents of java_app.jar to the web app named ContosoApp belonging to the resource group ContosoRG. User can Sets the timespan in Milliseconds to wait before the request times out. If -Force is not specified it will prompt for the confirmation before the contents will be deployed.

## PARAMETERS

### -ArchivePath
The path of the archive file. ZIP, WAR, and JAR are supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

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

### -Async
The artifact is deployed asynchronously. (The command will exit once the artifact is pushed to the web app.)

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

### -Clean
Cleans the target directory prior to deploying the file(s).

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
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Forcefully Remove Option

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

### -IgnoreStack
Disables any language-specific defaults

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

### -Name
The name of the web app.

```yaml
Type: System.String
Parameter Sets: FromResourceName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reset
Reset Java web apps to default parking page

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

```yaml
Type: System.String
Parameter Sets: FromResourceName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Restart
The web app will be restarted following the deployment. Set this to false if you are deploying multiple artifacts and do not want to restart the site on the earlier deployments.

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

### -Slot
The name of the web app slot.

```yaml
Type: System.String
Parameter Sets: FromResourceName
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetPath
Absolute path that the artifact should be deployed to.

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

### -Timeout
Sets the timespan in Milliseconds to wait before the request times out.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Used to override the type of artifact being deployed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: war, jar, ear, zip, static

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
The web app object

```yaml
Type: Microsoft.Azure.Commands.WebApps.Models.PSSite
Parameter Sets: FromWebApp
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### Microsoft.Azure.Commands.WebApps.Models.PSSite

## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Models.PSSite

## NOTES

## RELATED LINKS
