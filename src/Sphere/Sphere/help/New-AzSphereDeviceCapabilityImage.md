---
external help file: Az.Sphere-help.xml
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/new-azspheredevicecapabilityimage
schema: 2.0.0
---

# New-AzSphereDeviceCapabilityImage

## SYNOPSIS
Generates the capability image for the device.
Use '.unassigned' or '.default' for the device group and product names to generate the image for a device that does not belong to a specific device group and product.

## SYNTAX

### GenerateExpanded (Default)
```
New-AzSphereDeviceCapabilityImage -DeviceName <String> -CatalogName <String> -DeviceGroupName <String>
 -ProductName <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Capability <String[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GenerateViaJsonString
```
New-AzSphereDeviceCapabilityImage -DeviceName <String> -CatalogName <String> -DeviceGroupName <String>
 -ProductName <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GenerateViaJsonFilePath
```
New-AzSphereDeviceCapabilityImage -DeviceName <String> -CatalogName <String> -DeviceGroupName <String>
 -ProductName <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GenerateViaIdentityProductExpanded
```
New-AzSphereDeviceCapabilityImage -DeviceName <String> -DeviceGroupName <String>
 -ProductInputObject <ISphereIdentity> -Capability <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GenerateViaIdentityCatalogExpanded
```
New-AzSphereDeviceCapabilityImage -DeviceName <String> -DeviceGroupName <String> -ProductName <String>
 -CatalogInputObject <ISphereIdentity> -Capability <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GenerateViaIdentityDeviceGroupExpanded
```
New-AzSphereDeviceCapabilityImage -DeviceName <String> -DeviceGroupInputObject <ISphereIdentity>
 -Capability <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Generates the capability image for the device.
Use '.unassigned' or '.default' for the device group and product names to generate the image for a device that does not belong to a specific device group and product.

## EXAMPLES

### Example 1: Generates the capability image for the device.
```powershell
New-AzSphereDeviceCapabilityImage -ResourceGroupName joyer-test -CatalogName test2024 -DeviceGroupName testdevicegroup2 -ProductName product2024 -DeviceName DBB0E0CB8BD961A6129096E1E8A1375AC1FA274F030C08161B37AE3BC5A94F443BDB628CF257BC5BC810D8768C03B6F5CA301A35CD0169F56A49624255964560 -Capability 'ApplicationDevelopment' | Format-List
```

```output
Image : /Vz9XAEAAADMAAAA27Dgy4vZYaYSkJbh6KE3WsH6J08DDAgWGzeuO8WpT0Q722KM8le8W8gQ2HaMA7b1yjAaNc0BafVqSWJCVZZFYAsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA 
        AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANFg0TQMAAABJRCQADQAAANi1KEHCq1VBmjOKHzHtZ+yYQTwYazyNRbRvoHzwyZefU0cYAJZKiVhXTEtr0FMmMLhe+JiQpbh/AQAA 
        AERCKAAAAAAAAAAAAGZ3X2NvbmZpZwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAfAAAAMyzku8X6GdcOC1Sd9Cfozpmsiny2TzmjyXK7IvOhfA1B8nwdf1GoPa6PPVNMnn15TPIFK/P5/S2TD/mQrNh0Nk=
```

This command generates the capability image for specified device.

## PARAMETERS

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

### -Capability
List of capabilities to create

```yaml
Type: System.String[]
Parameter Sets: GenerateExpanded, GenerateViaIdentityProductExpanded, GenerateViaIdentityCatalogExpanded, GenerateViaIdentityDeviceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GenerateViaIdentityCatalogExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaJsonString, GenerateViaJsonFilePath
Aliases:

Required: True
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

### -DeviceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GenerateViaIdentityDeviceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DeviceGroupName
Name of device group.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaJsonString, GenerateViaJsonFilePath, GenerateViaIdentityProductExpanded, GenerateViaIdentityCatalogExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceName
Device name

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

### -JsonFilePath
Path of Json file supplied to the Generate operation

```yaml
Type: System.String
Parameter Sets: GenerateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Generate operation

```yaml
Type: System.String
Parameter Sets: GenerateViaJsonString
Aliases:

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

### -ProductInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GenerateViaIdentityProductExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProductName
Name of product.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaJsonString, GenerateViaJsonFilePath, GenerateViaIdentityCatalogExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaJsonString, GenerateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaJsonString, GenerateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISignedCapabilityImageResponse

## NOTES

## RELATED LINKS
