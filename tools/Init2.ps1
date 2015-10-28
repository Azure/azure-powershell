	##copy "E:\Git\PS\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\Microsoft.Azure.Commands.ResourceManager.Cmdlets.*" "C:\Program Files\WindowsPowerShell\Modules\AzureRM.Resources\0.10.0\"
	
	write-host "Importing modules.." -ForegroundColor Cyan
	import-module "C:\Program Files\WindowsPowerShell\Modules\AzureRM.Resources\0.10.0\Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll"
	import-module "C:\Program Files\WindowsPowerShell\Modules\AzureRM.Profile\0.10.0\Microsoft.Azure.Commands.Profile.dll"
    import-Module "E:\Git\AzurePS\src\ResourceManager\Intune\Commands.Intune\bin\Debug\Microsoft.Azure.Commands.Intune.dll"
	
	## Install ARM from Gallery
	# Find-Module -Name AzureRM
	# Install-Module -Name AzureRM
	# Install-AzureRM
	
	write-host "Initializing environment.." -ForegroundColor Cyan
	.\Initialize-AzureInternalEnvironments.ps1
	
	write-host "Logging in with Azure environment.." -ForegroundColor Cyan
	$env = Get-AzureRmEnvironment 
	$secpasswd = ConvertTo-SecureString "Pa`$`$w0rd" -AsPlainText -Force
	$mycreds = New-Object System.Management.Automation.PSCredential ("admin@aad296.ccsctp.net", $secpasswd)
	Login-AzureRmAccount -environment $env[2] -credential $mycreds
