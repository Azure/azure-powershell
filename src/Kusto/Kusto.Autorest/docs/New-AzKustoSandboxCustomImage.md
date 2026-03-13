---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/new-azkustosandboxcustomimage
schema: 2.0.0
---

# New-AzKustoSandboxCustomImage

## SYNOPSIS
Create a sandbox custom image.

## SYNTAX

### CreateExpanded (Default)
```
New-AzKustoSandboxCustomImage -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-BaseImageName <String>] [-LanguageVersion <String>]
 [-RequirementsFileContent <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzKustoSandboxCustomImage -ClusterName <String> -Name <String> -ResourceGroupName <String>
 -Parameter <ISandboxCustomImage> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityCluster
```
New-AzKustoSandboxCustomImage -ClusterInputObject <IKustoIdentity> -Name <String>
 -Parameter <ISandboxCustomImage> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityClusterExpanded
```
New-AzKustoSandboxCustomImage -ClusterInputObject <IKustoIdentity> -Name <String> [-BaseImageName <String>]
 [-LanguageVersion <String>] [-RequirementsFileContent <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzKustoSandboxCustomImage -ClusterName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzKustoSandboxCustomImage -ClusterName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a sandbox custom image.

## EXAMPLES

### Example 1: Create a sandbox custom image
```powershell
New-AzKustoSandboxCustomImage -ClusterName "myCluster" -Name "myImage" -ResourceGroupName "myResourceGroup" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -LanguageVersion "3.9.7" -RequirementsFileContent "Pillow"
```

```output
Name
----
myCluster/myImage
```

The above command creates a custom image named "myImage" in the resource group "myResourceGroup" in the subscription "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" based on the cluster "myCluster" with the language version "3.9.7" and the requirements file content "Pillow".

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

### -BaseImageName
The base image name on which the custom image is built on top of.
It can be one of the LanguageExtensionImageName (e.g.: 'Python3_10_8', 'Python3_10_8_DL') or the name of an existing custom image.
Either this property or languageVersion should be specified.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: CreateViaIdentityCluster, CreateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LanguageVersion
The version of the language.
Either this property or baseImageName should be specified.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the sandbox custom image.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SandboxCustomImageName

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

### -Parameter
Class representing a Kusto sandbox custom image.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.ISandboxCustomImage
Parameter Sets: Create, CreateViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RequirementsFileContent
The requirements file content.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.ISandboxCustomImage

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.ISandboxCustomImage

## NOTES

## RELATED LINKS

