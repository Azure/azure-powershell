---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/new-azspringcustomizedaccelerator
schema: 2.0.0
---

# New-AzSpringCustomizedAccelerator

## SYNOPSIS
Create the customized accelerator.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSpringCustomizedAccelerator -ApplicationAcceleratorName <String> -Name <String>
 -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String>] [-AcceleratorTag <String[]>]
 [-AcceleratorType <String>] [-AuthSettingAuthType <String>] [-Description <String>] [-DisplayName <String>]
 [-GitRepositoryBranch <String>] [-GitRepositoryCommit <String>] [-GitRepositoryGitTag <String>]
 [-GitRepositoryIntervalInSecond <Int32>] [-GitRepositorySubPath <String>] [-GitRepositoryUrl <String>]
 [-IconUrl <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityApplicationAcceleratorExpanded
```
New-AzSpringCustomizedAccelerator -ApplicationAcceleratorInputObject <ISpringAppsIdentity> -Name <String>
 [-AcceleratorTag <String[]>] [-AcceleratorType <String>] [-AuthSettingAuthType <String>]
 [-Description <String>] [-DisplayName <String>] [-GitRepositoryBranch <String>]
 [-GitRepositoryCommit <String>] [-GitRepositoryGitTag <String>] [-GitRepositoryIntervalInSecond <Int32>]
 [-GitRepositorySubPath <String>] [-GitRepositoryUrl <String>] [-IconUrl <String>] [-SkuCapacity <Int32>]
 [-SkuName <String>] [-SkuTier <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzSpringCustomizedAccelerator -InputObject <ISpringAppsIdentity> [-AcceleratorTag <String[]>]
 [-AcceleratorType <String>] [-AuthSettingAuthType <String>] [-Description <String>] [-DisplayName <String>]
 [-GitRepositoryBranch <String>] [-GitRepositoryCommit <String>] [-GitRepositoryGitTag <String>]
 [-GitRepositoryIntervalInSecond <Int32>] [-GitRepositorySubPath <String>] [-GitRepositoryUrl <String>]
 [-IconUrl <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentitySpringExpanded
```
New-AzSpringCustomizedAccelerator -ApplicationAcceleratorName <String> -Name <String>
 -SpringInputObject <ISpringAppsIdentity> [-AcceleratorTag <String[]>] [-AcceleratorType <String>]
 [-AuthSettingAuthType <String>] [-Description <String>] [-DisplayName <String>]
 [-GitRepositoryBranch <String>] [-GitRepositoryCommit <String>] [-GitRepositoryGitTag <String>]
 [-GitRepositoryIntervalInSecond <Int32>] [-GitRepositorySubPath <String>] [-GitRepositoryUrl <String>]
 [-IconUrl <String>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzSpringCustomizedAccelerator -ApplicationAcceleratorName <String> -Name <String>
 -ResourceGroupName <String> -ServiceName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzSpringCustomizedAccelerator -ApplicationAcceleratorName <String> -Name <String>
 -ResourceGroupName <String> -ServiceName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the customized accelerator.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AcceleratorTag
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AcceleratorType
Type of the customized accelerator.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationAcceleratorInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: CreateViaIdentityApplicationAcceleratorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ApplicationAcceleratorName
The name of the application accelerator.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySpringExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### -AuthSettingAuthType
The type of the auth setting.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
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

### -Description
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryBranch
Git repository branch to be used.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryCommit
Git repository commit to be used.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryGitTag
Git repository tag to be used.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryIntervalInSecond
Interval for checking for updates to Git or image repository.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositorySubPath
Folder path inside the git repository to consider as the root of the accelerator or fragment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitRepositoryUrl
Git repository URL for the accelerator.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IconUrl
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
The name of the customized accelerator.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentitySpringExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: CustomizedAcceleratorName

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the Sku

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
Tier of the Sku

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityApplicationAcceleratorExpanded, CreateViaIdentityExpanded, CreateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: CreateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ICustomizedAcceleratorResource

## NOTES

## RELATED LINKS

