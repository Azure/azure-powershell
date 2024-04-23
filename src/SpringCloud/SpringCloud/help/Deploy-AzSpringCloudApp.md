---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.SpringCloud/deploy-azSpringCloudapp
schema: 2.0.0
---

# Deploy-AzSpringCloudApp

## SYNOPSIS
Deploy the build file to an existing deployment.

## SYNTAX

### DeployAppForStandard (Default)
```
Deploy-AzSpringCloudApp -Name <String> -ResourceGroupName <String> -ServiceName <String> -FilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeployAppForEnterprise
```
Deploy-AzSpringCloudApp -Name <String> -ResourceGroupName <String> -ServiceName <String> -FilePath <String>
 [-SubscriptionId <String>] -BuilderId <String> -AgentPoolId <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deploy the build file to an existing deployment.

## EXAMPLES

### Example 1: Deploy the build file to an standard spring app
```powershell
$jarObj = New-AzSpringCloudAppDeploymentJarUploadedObject -RuntimeVersion "Java_8"
New-AzSpringCloudAppDeployment -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-va4fsz -AppName account -Name green -Source $jarObj
Get-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-va4fsz -Name account | Update-AzSpringCloudAppActiveDeployment -DeploymentName 'green'
Deploy-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-va4fsz -Name account -FilePath "C:\Users\v-diya\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
```

```output
[1/3] Requesting for upload URL
[2/3] Uploading package to blob
[3/3] Updating deployment in app demo (this operation can take a while to complete)

Name  SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----  -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
green 6/24/2022 6:50:58 AM v-test@microsoft.com User                    7/19/2022 7:06:08 AM     v-test@microsoft.com     User                         spring-rg-test
```

This command deploy the build file to an standard spring app.

### Example 2: Deploy the build file to an enterprise spring app
```powershell
$source = New-AzSpringCloudAppDeploymentBuildResultObject
New-AzSpringCloudAppDeployment -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -AppName account -Name green -Source $source
Get-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -Name account | Update-AzSpringCloudAppActiveDeployment -DeploymentName 'green'
$builder = Get-AzSpringCloudBuildServiceBuilder -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -Name default
$agentPool = Get-AzSpringCloudBuildServiceAgentPool -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n
Deploy-AzSpringCloudApp -ResourceGroupName springcloud-rg-0zquav -ServiceName spring-f7lz2n -Name account -AgentPoolId $agentPool.Id -BuilderId $builder.Id -FilePath "C:\Users\v-diya\Downloads\hellospring\target\hellospring-0.0.1-SNAPSHOT.jar"
```

```output
[1/3] Requesting for upload URL
[2/3] Uploading package to blob
[3/3] Updating deployment in app demo (this operation can take a while to complete)

Name  SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----  -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
green 6/24/2022 6:50:58 AM v-test@microsoft.com User                    7/19/2022 7:06:08 AM     v-test@microsoft.com     User                         spring-rg-test
```

This command deploy the build file to an enterprise spring app.

## PARAMETERS

### -AgentPoolId
The resource id of agent pool.

```yaml
Type: System.String
Parameter Sets: DeployAppForEnterprise
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -BuilderId
The resource id of builder to build the source code.

```yaml
Type: System.String
Parameter Sets: DeployAppForEnterprise
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -FilePath
The path of the file need to be deploied.
The file supports Jar, NetcoreZip and Source.

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

### -Name
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AppName

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -ServiceName
The name of the Service resource.

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

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IAppResource

## NOTES

## RELATED LINKS
