### Example 1: {{ Create a new firmware using new guid. }}
```powershell
{{ New-AzFirmwareAnalysisFirmware -ResourceGroupName resourceGroupName -WorkspaceName workspaceName -Description description -FileSize 1  -FileName fileName -Vendor vendor -Model model -Version version }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Create a new firmware using new guid. }}

### Example 2: {{ Create a new firmware using a user specified firmwareId. }}
```powershell
{{ New-AzFirmwareAnalysisFirmware -Id firmwareId -ResourceGroupName resourceGroupName -WorkspaceName workspaceName -Description description -FileSize 1  -FileName fileName -Vendor vendor -Model model -Version version
}}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Create a new firmware using a user specified firmwareId. }}

