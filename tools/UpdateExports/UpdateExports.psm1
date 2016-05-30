
function Update-ModuleExports
{
  [CmdletBinding(SupportsShouldProcess=$true)]
  param([Parameter(Mandatory=$true, ValueFromPipeline=$true)]
  [string] $modulePath)
  PROCESS
  {
    Write-Verbose "Processing $modulePath"
    $module = Test-ModuleManifest -Path $modulePath
    $keys = $module.NestedModules | %{
      $_.ExportedCmdlets.Keys
    }
    if ($pscmdlet.ShouldProcess($modulePath, "Updating module manifest with cmdlets [$keys]"))
    {
      Update-ModuleManifest -Path $module.Path -CmdletsToExport $keys
    }
  }
}

function Update-AllModuleExports {
[CmdletBinding(SupportsShouldProcess=$true)]
  param([string] $path)
  PROCESS
  {
    Get-ChildItem -Path $path | %{([System.IO.Path]::Combine($path, $_, "$_.psd1"))} | Where -FilterScript {Test-Path $_} | Update-ModuleExports
  }
}

function Test-AllModuleExports {
  param([string] $path)
  Get-ChildItem -Path $path | %{([System.IO.Path]::Combine($path, $_, "$_.psd1"))} | Where -FilterScript {Test-Path $_} | Test-ModuleExports
}

function Test-ModuleExports
{
  [CmdletBinding()]
  param(
  [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
  [string] $modulePath)
  PROCESS
  {
    Write-Verbose "Processing $modulePath"
    $module = Test-ModuleManifest -Path $modulePath
    $keys = $module.NestedModules | %{
       $_.ExportedCmdlets.Keys
    }
    
    $data = Get-Content $modulePath | Out-String
    $manifest = (Invoke-Expression $data)
    if ($manifest.CmdletsToExport -eq '*')
    {
       Write-Error "Cmdlets not explicitly specified, run Update-ModuleExports"
    }
    else
    {
      if ($manifest.CmdletsToExport -ne $null -and $manifest.CmdletsToExport.Count -gt 0)
      {
        $keys | %{
          if (!$manifest.CmdletsToExport.Contains($_)) {
            Write-Error("$_ not found in module manifest")
          }
        }

        $manifest.CmdletsToExport | %{
          if (!$keys.Contains($_)) {
            Write-Error("$_ not found in module code")
          }
        }
      }
    }
  }
}