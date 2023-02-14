# region Generated 
  # Load the private module dll
<<<<<<< HEAD
  $null = Import-Module -PassThru -Name (Join-Path $PSScriptRoot '../bin/Az.EdgeOrder.private.dll')

  # Load the internal module
  $internalModulePath = Join-Path $PSScriptRoot '../internal/Az.EdgeOrder.internal.psm1'
=======
  $null = Import-Module -PassThru -Name (Join-Path $PSScriptRoot '..\bin\Az.EdgeOrder.private.dll')

  # Load the internal module
  $internalModulePath = Join-Path $PSScriptRoot '..\internal\Az.EdgeOrder.internal.psm1'
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
  if(Test-Path $internalModulePath) {
    $null = Import-Module -Name $internalModulePath
  }

  # Export nothing to clear implicit exports
  Export-ModuleMember

  # Export script cmdlets
  Get-ChildItem -Path $PSScriptRoot -Recurse -Include '*.ps1' -File | ForEach-Object { . $_.FullName }
  Export-ModuleMember -Function (Get-ScriptCmdlet -ScriptFolder $PSScriptRoot) -Alias (Get-ScriptCmdlet -ScriptFolder $PSScriptRoot -AsAlias)
# endregion
