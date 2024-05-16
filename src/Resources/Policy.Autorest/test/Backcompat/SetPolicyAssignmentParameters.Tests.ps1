# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-SetPolicyAssignmentParameters'

Describe 'Backcompat-SetPolicyAssignmentParameters' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
        $goodIdentityId = "$goodScope/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$someIdentityId"
        $someParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'
        $someLocation = 'west us'
        $someNotScope = 'not scope'
        $emptyNotScope = @()
    }

    It 'no parameters' {
        {
            # validate with no parameters
            Assert-ThrowsContains { Set-AzPolicyAssignment } $missingParameters
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Name' {
        {
            # validate parameter combinations starting with -Name
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $goodScope } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -NotScope $someNotScope } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -NotScope $emptyNotScope } $policyAssignmentNotFound
            #Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -NotScope $null } $parameterNullError
            # null value for NotScopes is now allowed
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -NotScope $null } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -DisplayName $someDisplayName } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -DisplayName $someDisplayName } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Id $someId } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -PolicyParameter $someParameters } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned' -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId -Location $someLocation } $policyAssignmentNotFound
        } | Should -Not -Throw
    }

    It 'parameter combinations starting with -Id' {
        {
            #validation parameter combinations starting with -Id
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $goodId } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -DisplayName $someDisplayName } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameter $someParameters } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -PolicyParameter $someParameters } $parameterSetError
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned' } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned' -Location $someLocation } $policyAssignmentNotFound
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId } $policyAssignmentMissingLocation
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation } $policyAssignmentMissingIdentityId
            Assert-ThrowsContains { Set-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId -Location $someLocation } $policyAssignmentNotFound
        } | Should -Not -Throw
    }
}
