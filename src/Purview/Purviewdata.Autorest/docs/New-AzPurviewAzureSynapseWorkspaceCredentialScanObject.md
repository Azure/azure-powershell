---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewazuresynapseworkspacecredentialscanobject
schema: 2.0.0
---

# New-AzPurviewAzureSynapseWorkspaceCredentialScanObject

## SYNOPSIS
Create an in-memory object for AzureSynapseWorkspaceCredentialScan.

## SYNTAX

```
New-AzPurviewAzureSynapseWorkspaceCredentialScanObject [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-ConnectedViaReferenceName <String>] [-CredentialReferenceName <String>]
 [-CredentialType <String>] [-ResourceType <IExpandingResourceScanPropertiesResourceTypes>]
 [-ScanRulesetName <String>] [-ScanRulesetType <String>] [-Worker <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSynapseWorkspaceCredentialScan.

## EXAMPLES

### Example 1: Create Azure Synapse Workspace Credential scan object
```powershell
New-AzPurviewAzureSynapseWorkspaceCredentialScanObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -CredentialType 'ServicePrincipal' -CredentialReferenceName 'svcp' -ScanRulesetName 'AzureSynapseSQL' -ScanRulesetType 'System'
```

```output
CollectionLastModifiedAt  :
CollectionReferenceName   : parv-brs-2
CollectionType            : CollectionReference
ConnectedViaReferenceName :
CreatedAt                 :
CredentialReferenceName   : svcp
CredentialType            : ServicePrincipal
Id                        :
Kind                      : AzureSynapseWorkspaceCredential
LastModifiedAt            :
Name                      :
ResourceType              : {
                            }
Result                    :
ScanRulesetName           : AzureSynapseSQL
ScanRulesetType           : System
Worker                    :
```

Create Azure Synapse Workspace Credential scan object

## PARAMETERS

### -CollectionReferenceName


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

### -CollectionType


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

### -ConnectedViaReferenceName


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

### -CredentialReferenceName


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

### -CredentialType


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

### -ResourceType


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesResourceTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScanRulesetName


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

### -ScanRulesetType


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

### -Worker


```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AzureSynapseWorkspaceCredentialScan

## NOTES

## RELATED LINKS

