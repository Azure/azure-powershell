ipmo D:\powershell\azure-powershell\src\Network\Network.Test\bin\Debug\netcoreapp2.2\Assert.ps1
ipmo D:\powershell\azure-powershell\src\Network\Network.Test\ScenarioTests\Common.ps1
ipmo D:\powershell\azure-powershell\src\Network\Network.Test\bin\Debug\netcoreapp2.2\Common.ps1
Import-Module D:\powershell\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
Import-Module D:\powershell\azure-powershell\artifacts\Debug\Az.Network\Az.Network.psd1
New-MarkdownCommandHelp -ModuleInfo (Get-Module Az.Network) -OutputFolder D:\powershell\Md -Force
#$cmdHelp = Import-MarkdownCommandHelp -Path D:\powershell\azure-powershell\src\Network\Network\help\*-*.md
#Update-MarkdownModuleFile -Path D:\powershell\azure-powershell\src\Network\Network\help\Az.Network.md -CommandHelp $cmdHelp -NoBackup
