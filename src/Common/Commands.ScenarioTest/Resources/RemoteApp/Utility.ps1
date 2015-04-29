
[string] $eol = "`r`n"

function Get-RandomName
{
[CmdletBinding()] param (
      [parameter(Mandatory=$false)]
      [string] $name,
      [int] $count = 12
   )
   $suffix = -join $(Get-Random -InputObject 'a0b1c2d3e5f6g6h7i8j9k0l1m2n3o4p5q6r7s8t9u0v1w2z3y4z'.ToCharArray() -Count $Count)
   if ($suffix -ne '')
   {
      "$name$suffix"
   }
   else
   {
      "$name"
   }
}

function Is-RunningAsAdmin
{
    $windowsIdentity = [System.Security.Principal.WindowsIdentity]::GetCurrent()
    $windowsPrincipal = new-object System.Security.Principal.WindowsPrincipal($windowsIdentity)
    $administratorRole = [System.Security.Principal.WindowsBuiltInRole]::Administrator
    $isRunningAsAdmin = $windowsPrincipal.IsInRole($administratorRole)
    return $isRunningAsAdmin
}

function New_Log([string] $fileName)
{
   $i=1
   while ((Test-Path "$fileName-$i.txt"))
   {
      $i++
   }
   $folder = Split-Path -Path $fileName-$i.txt -Parent
   if ((Test-Path $folder))
   {
      $Script:Test_LogFile = "$fileName-$i.txt"
      $Script:LOGGING = $true
      $Script:Test_LogFile
   }
}

function Open-Log([string] $fileName)
{
   if ((Test-Path $fileName))
   {
       $Script:Test_LogFile = $fileName
       $Script:LOGGING = $true
   }
}

function Write-Log([string] $msg, [bool] $EndOfLine = $true)
{
   if ($eol)
   {
      $msg += $eol
   }

   if ($LOGGING)
   {
      Write-Output "$msg" | Out-File -FilePath $Test_LogFile -Append
   }
}

function echo([string] $msg,[bool] $EndOfLine = $true)
{
   Write_Log $msg
   Write-Host $msg
}

function Assert([ScriptBlock] $Condition)
{
   if ((& $Condition) -eq $false)
   {
        throw "Assertion Failed $($Condition.ToString()): $(Get-PSCallStack | Out-String)"
   }
}
