---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/get-azsshkey
schema: 2.0.0
---

# Get-AzSshKey

## SYNOPSIS
Gets the properties of SSH Public Key resources.

## SYNTAX

### DefaultParameterSet (Default)
```
Get-AzSshKey [-ResourceGroupName <String>] [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceIDParameterSet
```
Get-AzSshKey [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of SSH Public Key resources.

## EXAMPLES

### Example 1
```powershell
Get-AzSshKey -ResourceGroupName "testRG" -Name "SshKey1"
```

This example retrieves a specific Ssh Public Key resource.

### Example 2
```powershell
Get-AzSshKey -ResourceGroupName "testRG"
```

This example retrieves a list of Ssh Public Key resources that are in Resource Group: "testRG"

### Example 3
```powershell
Get-AzSshKey 
```

This example retrieves all the Ssh Public Key resources in the subscription. 

## PARAMETERS

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

### -Name
Specifies the name of the Ssh Public Key resource to get.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: sshkeyName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
Specifies the name of a resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceId
Resource ID for your SSH Public Key Resource.

```yaml
Type: System.String
Parameter Sets: ResourceIDParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSSshPublicKeyResource

## NOTES

## RELATED LINKS
