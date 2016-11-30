---
external help file: Microsoft.Azure.Commands.AnalysisServices.Dataplane.dll-help.xml
online version: 
schema: 2.0.0
---

# Add-AzureAnalysisServicesAccount

## SYNOPSIS
Adds an authenticated account to use for Azure Analysis Services server cmdlet requests.

## SYNTAX

```
Add-AzureAnalysisServicesAccount [-EnvironmentName] <String> [[-Credential] <PSCredential>] [-WhatIf]
 [-Confirm]
```

## DESCRIPTION
The Add-AzureAnalysisServicesAccount cmdlet is used to login to an instance of Azure Analysis Services server

## EXAMPLES

### Example 1
```
PS C:\>Add-AzureAnalysisServicesAccount
EnvironmentName: westcentralus.asazure.windows.net
Credential: $UserCredential
```

This example will add the account specified by the $UserCredential variable to the westcentralus.asazure.windows.net Analysis Services environment.

## PARAMETERS

### -Credential
Login credentials

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
Name of the Azure Analysis Services environment to which to logon to

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

## INPUTS

## OUTPUTS

## NOTES
Alias: Login-AzureAsAccount

## RELATED LINKS

