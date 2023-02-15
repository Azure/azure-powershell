### Example 1: Create a PowerShell validator
```powershell
New-AzImageBuilderTemplateValidatorObject -PowerShellValidator -Name PowerShellValidator -ScriptUri "https://example.com/path/to/script.sh"
```

```output
Name                Inline RunAsSystem RunElevated ScriptUri                             Sha256Checksum ValidExitCode
----                ------ ----------- ----------- ---------                             -------------- -------------
PowerShellValidator                                https://example.com/path/to/script.sh
```

This command creates a powershell validator.

### Example 2: Create a Shell validator
```powershell
New-AzImageBuilderTemplateValidatorObject -ShellValidator -Name ShellValidator -ScriptUri "https://example.com/path/to/script.sh"
```

```output
Name           Inline ScriptUri                             Sha256Checksum
----           ------ ---------                             --------------
ShellValidator        https://example.com/path/to/script.sh
```

This command creates a shell validator.

