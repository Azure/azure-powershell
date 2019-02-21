---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Kusto.dll-Help.xml
Module Name: Az.Kusto
online version: https://docs.microsoft.com/en-us/powershell/module/az.kusto/test-azkustoclustername
schema: 2.0.0
---

# Test-AzKustoClusterName

## SYNOPSIS
Check if a given Kusto cluster name is available.

## SYNTAX

```
Test-AzKustoClusterName -Location <String> -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Check if a given Kusto cluster name is available.

## EXAMPLES

### Example 1 - Check the availability of a Kusto cluster name which is in use

```
PS C:\> Test-AzKustoClusterName -Location 'Central US' -Name mykustocluster

NameAvailable		Name      		   			Message
------------- 			----     		  				-------
False 					mykustocluster 	    Name 'mykustocluster' with type Engine is already taken. Please specify a different name
```

The above command returns whether or not a Kusto cluster named "mykustocluster" exists in the "Central US" region.

### Example 2 - Check the availability of a Kusto cluster name which is not in use

```
PS C:\> Test-AzKustoClusterName -Location 'Central US' -Name mykustocluster

NameAvailable 		Name         			    Message
------------- 			----         				    -------
 True 					mykustocluster
```

The above command returns whether or not a Kusto cluster named "mykustocluster" exists in the "Central US" region.

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

### -Location
The location where to check.

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
Name of a specific cluster.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Kusto.Models.PSKustoClusterNameAvailability

## NOTES

## RELATED LINKS
