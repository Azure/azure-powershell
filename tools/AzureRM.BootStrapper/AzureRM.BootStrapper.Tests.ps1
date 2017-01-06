Import-Module -Name AzureRM.Bootstrapper
$global:testProfileMap = "{`"Profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"Profile2`": { `"Module1`": [`"2.0`"], `"Module2`": [`"2.0`"] }}" 

Describe "Get-ProfileCachePath" {
    InModuleScope AzureRM.Bootstrapper {
        Context "Gets the correct profile cache path" {
            It "Should return proper path" {
                Get-ProfileCachePath | Should Match "(.*)ProfileCache$"
            }
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

        Context "Invoke-RestMethod returns an error" {
            $Response = New-Object System.Net.HttpWebResponse
            $Exception = New-Object System.Net.WebException "Test Error Occurred.", (New-Object System.Exception), ConnectFailure, $Response
            $ErrorRecord = new-object System.Management.Automation.ErrorRecord $Exception, "TestError", ConnectionError, $null
           
            $RestError = @()
            $object = New-Object -TypeName psobject
            $object | Add-Member -Name ErrorRecord -MemberType NoteProperty -value $ErrorRecord
            $RestError += $object

            Mock Invoke-RestMethod {}
            Mock Get-RestResponse { return $RestError }
            It "Throws custom exception" {
                { Get-AzureProfileMap } | Should throw "Http Status Code:" 
            }
        }
    }
}

Describe Get-AzProfile {
    InModuleScope AzureRM.Bootstrapper {
        
        Context "Forces update from Azure Endpoint" {
            Mock Get-AzureProfileMap { $global:testProfileMap }
            
            It "Should get ProfileMap from Azure Endpoint" {
                 Get-AzProfile -Update  | Should Be "{`"profile1`": { `"Module1`": [`"1.0`"], `"Module2`": [`"1.0`"] }, `"profile2`": { `"Module1`": [`"2.0`"], `"Module2`": [`"2.0`"] }}"
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
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available from cache" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Get-Content -Verifiable { return $global:testProfileMap }

            It "Should get ProfileMap from Embedded source" {
                Get-AzProfile | Should Be "@{profile1=; profile2=}"
                Assert-VerifiableMocks
            }
        }

        Context "ProfileMap is not available in cache or Embedded source" {
            Mock Test-Path -Verifiable { $false }
            Mock Get-ProfileCachePath -Verifiable { "MockPath\ProfileCache" }
            Mock Get-Content -Verifiable {}

            It "Should throw FileNotFound Exception" {
                { Get-AzProfile } | Should Throw
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

Describe "Add-SwitchParam" {
    InModuleScope AzureRM.Bootstrapper {
        $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
        
        It "Should return Switch parameter object" {
            Add-SwitchParam $params "TestParam"
            $params.ContainsKey("TestParam") | Should Be $true
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

        Context "Module not in the list" {
            Mock Get-Module -Verifiable { @( [PSCustomObject] @{ Name='Module1'; Version='1.0'; RepositorySourceLocation='foo\bar' }, [PSCustomObject] @{ Name='Module1'; Version='2.0'}) }
            It "Should return null" {
                Get-AzureRmModule -Profile 'Profile2' -Module 'Module2' | Should be $null
                Assert-VerifiableMocks
            }
        }

        Context "Invoke with invalid parameters" {
            It "Should throw" {
                { Get-AzureRmModule -Profile 'XYZ' -Module 'ABC' } | Should Throw
            }
        }

        Context "Invoke with null parameters" {
            It "Should throw" {
                { Get-AzureRmModule -Profile $null -Module $null } | Should Throw
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

        Context "With ListAvailable and update Switches" {
            It "Should return available profiles" {
                $Result = (Get-AzureRmProfile -ListAvailable -Update)
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
            Mock Import-Module { "Module1 1.0 Imported"} -ParameterFilter { $Name -eq "Module1" -and $RequiredVersion -eq "1.0"}
            It "Should skip installing modules, imports the right version module" {
                (Use-AzureRmProfile -Profile 'Profile1' -Force) | Should Be "Module1 1.0 Imported"
                Assert-MockCalled Install-Module -Exactly 0
                Assert-MockCalled Import-Module -Exactly 1
                Assert-VerifiableMocks
            }
        }

        Context "Invoke with invalid profile" {
            It "Should throw" {
                { Use-AzureRmProfile -Profile 'WrongProfileName'} | Should Throw
            }
        }

        Context "Invoke with $null profile" {
            It "Should throw" {
                { Use-AzureRmProfile -Profile $null} | Should Throw
            }
        }
    }
}

Describe "Install-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        $RollupModule = 'Module1'
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        
        Context "Invoke with valid profile name" {
            Mock Install-Module -Verifiable { "Installing module $RollupModule... Version 1.0"} -ParameterFilter { $Name -eq $RollupModule -and $RequiredVersion -eq '1.0' }
            It "Should install RollupModule" {
                (Install-AzureRmProfile -Profile 'Profile1') | Should be "Installing module $RollupModule... Version 1.0"
                Assert-VerifiableMocks
          }
        }

        Context "Invoke with invalid profile name" {
            It "Should throw" {
                { Install-AzureRmProfile -Profile 'WrongProfileName'} | Should Throw
            }
        }

        Context "Invoke with null profile name" {
            It "Should throw" {
                { Install-AzureRmProfile -Profile $null } | Should Throw
            }
        }
    }
}

Describe "Uninstall-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Remove-Module -Verifiable { "Removing module from session..." }
        Mock Uninstall-Module -Verifiable { "Uninstalling module..." }
      
        Context "Modules are installed" {
            It "Should remove and uninstall modules" {
                # Arrange
                $Script:mockCalled = 0
                $mockTestPath = {
                    $Script:mockCalled++
                    if ($Script:mockCalled -eq 1)
                    {
                        return "1.0"
                    }
                    else {
                        return $null
                    }
                }   

                Mock -CommandName Get-AzureRmModule -MockWith $mockTestPath

                # Act
                $callResult = (Uninstall-AzureRmProfile -Profile 'Profile1' -Force)

                # Assert
                $Script:mockCalled | Should Be 3
                $callResult[0] | Should Be "Removing module from session..."
                $callResult[1] | Should Be "Uninstalling module..." 
                Assert-VerifiableMocks
            }
        }

        Context "Modules are not installed" {
            It "Should not call Uninstall-Module" {
                Mock Get-AzureRmModule -Verifiable {}
                $callResult = (Uninstall-AzureRmProfile -Profile 'Profile1' -Force)

                Assert-MockCalled Get-AzureRmModule -Exactly 2 
                Assert-MockCalled Remove-Module -Exactly 0
                Assert-MockCalled Uninstall-Module -Exactly 0
                Assert-VerifiableMocks
            }
        }

        Context "Invoke with invalid profile name" {
            It "Should throw" {
                { Uninstall-AzureRmProfile -Profile 'WrongProfileName' } | Should Throw
            }
        }

        Context "Invoke with null profile name" {
            It "Should throw" {
                { Uninstall-AzureRmProfile -Profile $null } | Should Throw
            }
        }
    }
}

Describe "Update-AzureRmProfile" {
    InModuleScope AzureRM.Bootstrapper {
        Mock Get-AzProfile -Verifiable { ($global:testProfileMap | ConvertFrom-Json) }
        Mock Get-AzProfile -Verifiable -ParameterFilter { $Update.IsPresent } { ($global:testProfileMap | ConvertFrom-Json) }
        
        Context "Profile is installed" {
            # Arrange
            $RollupModule = 'Module1'
            Mock Get-AzureRmModule -Verifiable { "2.0"} -ParameterFilter {$Profile -eq "Profile2" -and $Module -eq "Module1"}
            Mock Get-AzureRmProfile -Verifiable { 'Profile2' }
            Mock Install-Module {}
            Mock Import-Module -Verifiable {'Importing module'}
            Mock Uninstall-AzureRmProfile {}

            # Act
            $result = Update-AzureRmProfile -Profile 'Profile2' -RemovePreviousVersions -Force

            # Assert
            It "Updates and imports modules" {
                $result | Should Be 'Importing module'
                Assert-VerifiableMocks
                Assert-MockCalled Install-Module -Exactly 0
                Assert-MockCalled Uninstall-AzureRmProfile -Exactly 0
            }
        }

        Context "Profile is not installed" {
            # Arrange
            Mock Get-AzureRmProfile -Verifiable {}
            $RollupModule = 'Module1'
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile2" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {'Installing module'}
            Mock Import-Module -Verifiable {'Importing module'}
            Mock Uninstall-AzureRmProfile {}

            # Act
            $result = Update-AzureRmProfile -Profile 'Profile2' -RemovePreviousVersions -Force

            It "Should download and import modules" {
                $result[0] | Should Be 'Installing module'
                $result[1] | Should Be 'Importing module'
                Assert-VerifiableMocks
                Assert-MockCalled Uninstall-AzureRmProfile -Exactly 0
            }
        }

        Context "Old version (Profile1) was detected" {
            # Arrange
            Mock Uninstall-AzureRmProfile -Verifiable { "Uninstalling Profile..." }
            Mock Get-AzureRmProfile -Verifiable { @('Profile1', 'Profile2') }
            $RollupModule = 'Module1'
            Mock Get-AzureRmModule -Verifiable {} -ParameterFilter {$Profile -eq "Profile2" -and $Module -eq "Module1"}
            Mock Install-Module -Verifiable {'Installing module'}
            Mock Import-Module -Verifiable {'Importing module'}

            # Act
            $result = Update-AzureRmProfile -Profile 'Profile2' -RemovePreviousVersions -Force

            It "Removes old version and updates new version" {
                $result[0] | Should Be 'Uninstalling Profile...'
                $result[1] | Should Be 'Installing module'
                $result[2] | Should Be 'Importing module'
                Assert-VerifiableMocks
            }
        }
    }
}
