---
external help file:
Module Name: Az.DevTestLabs
online version: https://docs.microsoft.com/en-us/powershell/module/az.devtestlabs/new-azdevtestlabsartifactarmtemplate
schema: 2.0.0
---

# New-AzDevTestLabsArtifactArmTemplate

## SYNOPSIS
Generates an ARM template for the given artifact, uploads the required files to a storage account, and validates the generated artifact.

## SYNTAX

### GenerateExpanded (Default)
```
New-AzDevTestLabsArtifactArmTemplate -ArtifactSourceName <String> -LabName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-FileUploadOption <FileUploadOptions>]
 [-Location <String>] [-Parameter <IParameterInfo[]>] [-VirtualMachineName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Generate
```
New-AzDevTestLabsArtifactArmTemplate -ArtifactSourceName <String> -LabName <String> -Name <String>
 -ResourceGroupName <String> -GenerateArmTemplateRequest <IGenerateArmTemplateRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzDevTestLabsArtifactArmTemplate -InputObject <IDevTestLabsIdentity>
 -GenerateArmTemplateRequest <IGenerateArmTemplateRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GenerateViaIdentityExpanded
```
New-AzDevTestLabsArtifactArmTemplate -InputObject <IDevTestLabsIdentity>
 [-FileUploadOption <FileUploadOptions>] [-Location <String>] [-Parameter <IParameterInfo[]>]
 [-VirtualMachineName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Generates an ARM template for the given artifact, uploads the required files to a storage account, and validates the generated artifact.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ArtifactSourceName
The name of the artifact source.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
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

### -FileUploadOption
Options for uploading the files for the artifact.
UploadFilesAndGenerateSasTokens is the default value.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Support.FileUploadOptions
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GenerateArmTemplateRequest
Parameters for generating an ARM template for deploying artifacts.
To construct, see NOTES section for GENERATEARMTEMPLATEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IGenerateArmTemplateRequest
Parameter Sets: Generate, GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity
Parameter Sets: GenerateViaIdentity, GenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabName
The name of the lab.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the virtual machine.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the artifact.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters of the ARM template.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IParameterInfo[]
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
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
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualMachineName
The resource name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IGenerateArmTemplateRequest

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IArmTemplateInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


GENERATEARMTEMPLATEREQUEST <IGenerateArmTemplateRequest>: Parameters for generating an ARM template for deploying artifacts.
  - `[FileUploadOption <FileUploadOptions?>]`: Options for uploading the files for the artifact. UploadFilesAndGenerateSasTokens is the default value.
  - `[Location <String>]`: The location of the virtual machine.
  - `[Parameter <IParameterInfo[]>]`: The parameters of the ARM template.
    - `[Name <String>]`: The name of the artifact parameter.
    - `[Value <String>]`: The value of the artifact parameter.
  - `[VirtualMachineName <String>]`: The resource name of the virtual machine.

INPUTOBJECT <IDevTestLabsIdentity>: Identity Parameter
  - `[ArtifactSourceName <String>]`: The name of the artifact source.
  - `[Id <String>]`: Resource identity path
  - `[LabName <String>]`: The name of the lab.
  - `[LocationName <String>]`: The name of the location.
  - `[Name <String>]`: The name of the lab.
  - `[PolicySetName <String>]`: The name of the policy set.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ServiceFabricName <String>]`: The name of the service fabric.
  - `[SubscriptionId <String>]`: The subscription ID.
  - `[UserName <String>]`: The name of the user profile.
  - `[VirtualMachineName <String>]`: The name of the virtual machine.

PARAMETER <IParameterInfo[]>: The parameters of the ARM template.
  - `[Name <String>]`: The name of the artifact parameter.
  - `[Value <String>]`: The value of the artifact parameter.

## RELATED LINKS

