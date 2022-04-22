---
external help file:
Module Name: Az.DevTestLabs
online version: https://docs.microsoft.com/en-us/powershell/module/az.devtestlabs/new-azdevtestlabslabuploaduri
schema: 2.0.0
---

# New-AzDevTestLabsLabUploadUri

## SYNOPSIS
Generate a URI for uploading custom disk images to a Lab.

## SYNTAX

### GenerateExpanded (Default)
```
New-AzDevTestLabsLabUploadUri -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BlobName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Generate
```
New-AzDevTestLabsLabUploadUri -Name <String> -ResourceGroupName <String>
 -GenerateUploadUriParameter <IGenerateUploadUriParameter> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzDevTestLabsLabUploadUri -InputObject <IDevTestLabsIdentity>
 -GenerateUploadUriParameter <IGenerateUploadUriParameter> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GenerateViaIdentityExpanded
```
New-AzDevTestLabsLabUploadUri -InputObject <IDevTestLabsIdentity> [-BlobName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Generate a URI for uploading custom disk images to a Lab.

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

### -BlobName
The blob name of the upload URI.

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

### -GenerateUploadUriParameter
Properties for generating an upload URI.
To construct, see NOTES section for GENERATEUPLOADURIPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IGenerateUploadUriParameter
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

### -Name
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

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IGenerateUploadUriParameter

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.IDevTestLabsIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


GENERATEUPLOADURIPARAMETER <IGenerateUploadUriParameter>: Properties for generating an upload URI.
  - `[BlobName <String>]`: The blob name of the upload URI.

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

## RELATED LINKS

