$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

$errorMessage = "WebApp could not be created."

Describe "New-AzureRmWebAppExperimental" {

    Context "[live test] When an invalid Webapp location is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppExperimental -WebAppLocation random} | Should Throw $errorMessage
        }        
    }

    Context "[live test] When an invalid App Service Plan location is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppExperimental -AppServicePlanLocation random} | Should Throw $errorMessage
        }        
    }

    Context "[live test] When an invalid Resource Group location is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppExperimental -ResourceGroupLocation random} | Should Throw $errorMessage
        }        
    }

    Context "[live test] When an invalid Tier for App Service Plan is provided: "{

        It "Throws an error: " {
            { New-AzureRmWebAppExperimental -Tier random} | Should Throw $errorMessage
        }        
    }
}

