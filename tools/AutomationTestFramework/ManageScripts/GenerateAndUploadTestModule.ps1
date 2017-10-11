. "$PSScriptRoot\GenerateTestModule.ps1"
. "$PSScriptRoot\DeliverModuleToAutomationAccount.ps1"

<#
.SYNOPSIS
Combines calls of the related functions together
.PARAMETER srcPath
Path to the solution src folder
.PARAMETER projectList
List of the projects to coolect test scripts from. 
Projects are azure-powershell\src\ResourceManager subfolders.
.EXAMPLE
GenerateAndUploadTestsModule `
    -srcPath "e:\git\azure-powershell\src\" `
    -projectList @('Compute', 'Storage','Network', 'KeyVault', 'Sql', 'Websites')
#>
function GenerateAndUploadTestsModule (
    [string] $srcPath
    ,[string[]] $projectList) {

    $moduleName  = 'AutomationTests'

    $modulePath = "$srcPath\Package\$moduleName"

    # projects are azure-powershell\src\ResourceManager subfolders 
    #$projectList = @('Compute', 'Storage','Network', 'KeyVault', 'Sql', 'Websites')

    GenerateTestsModule `
        -srcPath $srcPath `
        -targetPath $modulePath `
        -moduleName $moduleName `
        -projectList $projectList

    DeliverModuleToAutomationAccount `
        -modulePath $modulePath `
        -moduleName $moduleName

    CheckModuleProvisionState `
        -moduleList $moduleName `

}