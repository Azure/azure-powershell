# Set Default Resource Group for Resources cmdlets
$nestedModules = Test-ModuleManifest '../AzureRM.Profile.psd1'
$dllPath = '../../../../../Package/Debug/ResourceManager/AzureResourceManager/AzureRM.Resources/Microsoft.Azure.Management.ResourceManager.dll'
$Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
$AllCmdlets = $Assembly.GetTypes() | where {$_.CustomAttributes.AttributeType.Name -contains "CmdletAttribute"}

$dllPath = '../../../../../Package/Debug/ResourceManager/AzureResourceManager/AzureRM.Resources/Microsoft.Azure.Commands.Resources.dll'
$Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
$AllCmdlets += $Assembly.GetTypes() | where {$_.CustomAttributes.AttributeType.Name -contains "CmdletAttribute"}

$FilteredCommands = @()
$AllCmdlets | ForEach-Object {
	$rgParameter = $_.GetProperties() | Where-Object {$_.Name -eq "ResourceGroupName"}
	if ($rgParameter -ne $null) {
		$parameterSets = $rgParameter.CustomAttributes | Where-Object {$_.AttributeType.Name -eq "ParameterAttribute"}
		$isMandatory = $true
		$parameterSets | ForEach-Object {
			$hasParameterSet = $_.NamedArguments | where {$_.MemberName -eq "ParameterSetName"}
			$MandatoryParam = $_.NamedArguments | where {$_.MemberName -eq "Mandatory"}
			if (($hasParameterSet -ne $null) -or (!$MandatoryParam.TypedValue.Value)) {
				$isMandatory = $false
			}
		}
		if ($isMandatory) {
			$FilteredCommands += $_
		}
	}
}

$FilteredCommands | ForEach-Object {
	$input = $_.GetCustomAttributes("System.Management.Automation.CmdletAttribute").VerbName + "-" + $_.GetCustomAttributes("System.Management.Automation.CmdletAttribute").NounName + ":ResourceGroupName"
	$global:PSDefaultParameterValues.Add($input,
		{
			$context = Get-AzureRmContext
			if ($context.ExtendedProperties.ContainsKey("Default Resource Group")) {
				$context.ExtendedProperties["Default Resource Group"]
			} 
		})
}
