---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.dll-Help.xml
Module Name: Az.ManagedNetwork
online version: https://docs.microsoft.com/en-us/powershell/module/az.managednetwork/new-azmanagednetwork
schema: 2.0.0
---

# New-AzManagedNetwork

## SYNOPSIS
Creates a managedNetwork.

## SYNTAX

```
New-AzManagedNetwork -ResourceGroupName <String> -Name <String> -Location <String> -Scope <PSScope> [-Tag <HashTable<String, String>>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>][-WhatIf] [-Confirm][<CommonParameters>]
```

## DESCRIPTION
The **New-AzManagedNetwork** cmdlet creates a managed network.

## EXAMPLES

### 1: Create a managed network
```
$testmanagednetwork = New-AzManagedNetwork ResourceGroupName TestRG -Name TestManagedNetwork -Location exampleregion
-Scope $sampleScope -Tag $sampleTag
```

This example creates a Managed Network.

## PARAMETERS

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Location
location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The Scope of the managed network

```yaml
Type: Microsoft.Azure.Commands.ManagedNetwork.Models.PSScope
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:
@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### Microsoft.Azure.Commands.ManagedNetwork.Models.PSScope

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSManagedNetwork

## NOTES

## RELATED LINKS

[Get-AzManagedNetwork](./Get-AzManagedNetwork.md)

[Remove-AzManagedNetwork](./Remove-AzManagedNetwork.md)

[update-AzManagedNetwork](./Update-AzManagedNetwork.md)