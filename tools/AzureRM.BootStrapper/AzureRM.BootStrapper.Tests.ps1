Import-Module -Name AzureRM.Bootstrapper
$global:testProfileMap = "{`"Profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"Profile2`": { `"Module1`": [`"2.0`"], `"Module2`": [`"2.0`"] }}" 

Describe "Get-ProfileCachePath" {
    Context "Gets the correct profile cache path" {
        It "Should return proper path" {
            Get-ProfileCachePath | Should Match "(.*)ProfileCache$"
        }
    }
}

Describe "Get-AzureProfileMap" {
    InModuleScope AzureRM.Bootstrapper {
        Mock New-Item -Verifiable { return "Creating ProfilePath"}
        Mock Get-ProfileCachePath -Verifiable { return "MockPath\ProfileCache"}
        Mock Invoke-RestMethod -Verifiable { return "Invoking ProfileMapEndPoint... Receiving ProfileMap.json"}
        Mock Get-Content -Verifiable { return $testProfileMap }
    
        Context "ProfilePath does not exist" {
            It "Returns the proper json file" {
                Get-AzureProfileMap | Should Be "@{profile1=; profile2=}"
            }
            It "Checks all the verifiable Mock calls" {
                Assert-VerifiableMocks
            }
        }

        Context "ProfilePath Exists" {
            Mock Test-Path { $true }
            Mock New-Item {}
            It "Returns Correct ProfileMap" {
                Get-AzureProfileMap | Should Be "@{profile1=; profile2=}"
            }
            It "Should not call New-Item" {
                Assert-MockCalled New-Item -Exactly 0
            }
        }

        Context "Invoke-RestMethod throws exception" {
            Mock Invoke-RestMethod { throw [System.Net.WebException] }

            It "Throws Web Exception" {
                { Get-AzureProfileMap } | Should throw 
            }
        }
    }
}

Describe Get-AzProfile {
    InModuleScope AzureRM.Bootstrapper {
        
        Context "Forces update from Azure Endpoint" {
            Mock Get-AzureProfileMap { $global:testProfileMap }
            
            It "Should get ProfileMap from Azure Endpoint" {
                 Get-AzProfile -Force  | Should Be "{`"profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"profile2`": { `"Module1`": [`"2.0`"], `"Module2`": [`"2.0`"] }}"
            }
            It "Checks Mock calls to Get-AzureProfileMap" {
                Assert-MockCalled Get-AzureProfileMap -Exactly 1
            }
        }
        
        Context "Gets Azure ProfileMap from Cache" {
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Test-Path -Verifiable { $true }
            Mock Get-Content -Verifiable { return $global:testProfileMap }
            
            It "Should get ProfileMap from Cache" {
                Get-AzProfile | Should Be "@{profile1=; profile2=}"
            }
            It "Checks all verifiable mocks" {
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available from cache" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Get-Content -Verifiable { return $global:testProfileMap }

            It "Should get ProfileMap from Embedded source" {
                Get-AzProfile | Should Be "@{profile1=; profile2=}"
            }
            It "Checks all verifiable mocks" {
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available in cache or Embedded source" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Get-Content -Verifiable {}

            It "Should throw FileNotFound Exception" {
                { Get-AzProfile } | Should Throw
            }
            It "Checks all verifiable mocks" {
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Add-ProfileParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }

        It "Should return Profile parameter object" {
            (Add-ProfileParam $params)
            $params.ContainsKey("Profile") | Should Be $true
            Assert-VerifiableMocks
        }
    }
}

Describe "Add-ForceParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        
        It "Should return Force parameter object" {
            Add-ForceParam $params
            $params.ContainsKey("Force") | Should Be $true
        }
    }
}

Describe "Get-AzureRmModule" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        
        Context "Module is installed" {
           Mock Get-Module -Verifiable { @( [PSCustomObject] @{ Name='Module1'; Version='1.0'; RepositorySourceLocation='foo\bar' }, [PSCustomObject] @{ Name='Module1'; Version='2.0'}) }
           It "Should return installed version" {
                Get-AzureRmModule -Profile 'Profile1' -Module 'Module1' | Should Be "1.0"
                Assert-VerifiableMocks
            }
        }
        
        Context "Module is not installed" {
            Mock Get-Module -Verifiable {}
            It "Should return null" {
                Get-AzureRmModule -Profile 'Profile1' -Module 'Module1' | Should be $null
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Get-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }

        Context "With ListAvailable Switch" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable)
                $Result.Length | Should Be 14
                $Result[0] | Should Be "Profile: Profile1"
                Assert-VerifiableMocks
            }
        }

        Context "With ListAvailable and Force Switches" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable -Force)
                $Result.Length | Should Be 14
                $Result[0] | Should Be "Profile: Profile1"
                Assert-VerifiableMocks
            }
        }

        Context "Without ListAvailable Switch" {
            $RollupModule = 'Module1'
            Mock Get-AzureRmModule -Verifiable { "1.0"} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Returns installed Profile" {
                (Get-AzureRmProfile) | Should Be "Profile1"
                Assert-VerifiableMocks
            }
        }

        Context "No profiles installed" {
            $RollupModule = 'Module1'
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Returns null" {
                (Get-AzureRmProfile) | Should Be $null
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Use-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        $RollupModule = 'Module1'
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Install-Module { "Installing module..."}
        Mock Import-Module -Verifiable { "Importing Module..."}

        Context "Modules not installed" {
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Should install modules" {
                $Result = (Use-AzureRmProfile -Profile 'Profile1' -Force)
                $Result.Length | Should Be 2
                $Result[0] | Should Be "Installing module..."
                $Result[1] | Should Be "Importing Module..."
                Assert-VerifiableMocks
            }
        }

        Context "Modules are installed" {
            Mock Get-AzureRmModule -Verifiable { "1.0" } -ParameterFilter {$Profile -eq "Profile1" -and $Module -eq "Module1"}
            It "Should skip installing modules" {
                (Use-AzureRmProfile -Profile 'Profile1' -Force) | Should Be "Importing Module..."
                Assert-MockCalled Install-Module -Exactly 0
                Assert-VerifiableMocks
            }
        }
    }
}

Describe "Install-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        $RollupModule = 'Module1'
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Install-Module -Verifiable { "Installing module..."}
        It "Should install RollupModule" {
            (Install-AzureRmProfile -Profile 'profile1') | Should be "Installing module..."
            Assert-VerifiableMocks
        }
    }
}
