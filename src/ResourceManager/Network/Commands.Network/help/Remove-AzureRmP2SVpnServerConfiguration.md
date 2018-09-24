---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermp2svpnserverconfiguration
schema: 2.0.0
---

# Remove-AzureRmP2SVpnServerConfiguration

## SYNOPSIS
Deletes a P2SVpnServerConfiguration associated with Azure Virtual WAN.

## SYNTAX

### ByP2SVpnServerConfigurationName (Default)
```
Remove-AzureRmP2SVpnServerConfiguration -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-PassThru] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationResourceId
```
Remove-AzureRmP2SVpnServerConfiguration -ResourceId <String> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByP2SVpnServerConfigurationObject
```
Remove-AzureRmP2SVpnServerConfiguration -InputObject <PSP2SVpnServerConfiguration> [-PassThru] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes a P2SVpnServerConfiguration associated with Azure Virtual WAN.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG" 
PS C:\> New-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US" -AllowBranchToBranchTraffic $true -Office365LocalBreakoutCategory "Optimize"
PS C:\> $p2sVpnServerConfigCertFilePath = "PathToCertFile.cer"
PS C:\> $listOfCerts = New-Object "System.Collections.Generic.List[String]"
PS C:\> $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
PS C:\> $Secure_String_Pwd = ConvertTo-SecureString "TestRadiusServerPassword" -AsPlainText -Force
PS C:\> New-AzureRmP2SVpnServerConfiguration -Name "P2SVpnServerConfiguration2Name" -ResourceGroupName "testRG" -ParentResourceName "myVirtualWAN" -VpnProtocol IkeV2 -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts
PS C:\> Remove-AzureRmP2SVpnServerConfiguration -ResourceGroupName "testRG" -ParentResourceName "myVirtualWAN" -Name "P2SVpnServerConfiguration2Name"
```

The above will create a resource group "testRG" in region "West US" and an Azure Virtual WAN in that resource group in Azure. 
Then, it will create create P2SVpnServerConfiguration "P2SVpnServerConfiguration2Name" and associates it with an existing Virtual WAN.
Remove-AzureRmP2SVpnServerConfiguration will remove the P2SVpnServerConfiguration "P2SVpnServerConfiguration2Name" associated with Azure Virtual WAN.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

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

### -InputObject
The P2SVpnServerConfiguration object to update.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration
Parameter Sets: ByP2SVpnServerConfigurationObject
Aliases: P2SVpnServerConfiguration

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByP2SVpnServerConfigurationName
Aliases: ResourceName, P2SVpnServerConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
The parent resource name.

```yaml
Type: System.String
Parameter Sets: ByP2SVpnServerConfigurationName
Aliases: ParentVirtualWanName, VirtualWanName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item on which this operation is being performed.

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
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByP2SVpnServerConfigurationName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the P2SVpnServerConfiguration object to delete.

```yaml
Type: System.String
Parameter Sets: ByP2SVpnServerConfigurationResourceId
Aliases: P2SVpnServerConfigurationId

Required: True
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.Network.Models.PSP2SVpnServerConfiguration

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
