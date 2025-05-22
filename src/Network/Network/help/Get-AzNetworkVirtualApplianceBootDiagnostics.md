---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworkvirtualappliancebootdiagnostics
schema: 2.0.0
---

# Get-AzNetworkVirtualApplianceBootDiagnostics

## SYNOPSIS
Retrieves boot diagnostic logs for a given NetworkVirtualAppliance VM instance

## SYNTAX

### ResourceNameParameterSet (Default)
```
Get-AzNetworkVirtualApplianceBootDiagnostics -ResourceGroupName <String> -Name <String> [-InstanceId <Int32>]
 [-SerialConsoleStorageSasUrl <SecureString>] [-ConsoleScreenshotStorageSasUrl <SecureString>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzNetworkVirtualApplianceBootDiagnostics [-InstanceId <Int32>] [-SerialConsoleStorageSasUrl <SecureString>]
 [-ConsoleScreenshotStorageSasUrl <SecureString>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzNetworkVirtualApplianceBootDiagnostics retrieves boot diagnostic logs for a given NetworkVirtualAppliance VM instance.

## EXAMPLES

### Example 1
```powershell
Get-AzNetworkVirtualApplianceBootDiagnostics -ResourceGroupName $rgname -Name $nvaname -InstanceId 0 -SerialConsoleStorageSasUrl <sasUrl1> -ConsoleScreenshotStorageSasUrl <sasUrl2>
```

This command retrieves boot diagnostic logs including the "serial console logs" and "console screen shot" for the given NetworkVirtualAppliance's instance 0 and copies it into the the storage blobs represented by the provided sas urls.

## PARAMETERS

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

### -ConsoleScreenshotStorageSasUrl
Storage blob (eg.
png file) sas url into which console screen shot for requested VM instance is copied

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -InstanceId
Network Virtual Appliance instance id to retrieve boot diagnostics for

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The Network Virtual Appliance name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: VirtualApplianceName, NvaName, NetworkVirtualApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SerialConsoleStorageSasUrl
Storage blob (eg.
txt file) sas url into which serial console logs for requested VM instance is copied

```yaml
Type: System.Security.SecureString
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

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualApplianceBootDiagnosticsOperationStatusResponse

## NOTES

## RELATED LINKS
