# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'UpdatePolicyAssignment'

Describe 'UpdatePolicyAssignment' {

    BeforeAll {
        $goodScope = "/subscriptions/$subscriptionId"
        $goodId = "$goodScope/providers/Microsoft.Authorization/policyAssignments/$someName"
        $goodIdentityId = "$goodScope/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$someIdentityId"
        $someParameters = '{ "someKindaParameter": { "value": [ "Mmmm", "Doh!" ] } }'
        $someLocation = 'west us'
        $someNotScope = 'not scope'
        $emptyNotScope = @()
    }

    It 'Update-AzPolicyAssignment' {
        {
            Update-AzPolicyAssignment
        } | Should -Throw $missingParameters
    }

    It 'Update-AzPolicyAssignment -Name <missing>' {
        {
            Update-AzPolicyAssignment -Name
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyAssignment -Name' {
        {
            Update-AzPolicyAssignment -Name $someName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $goodScope
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -NotScope' {
        {
            Update-AzPolicyAssignment -Name $someName -NotScope $someNotScope
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -NotScope <empty>' {
        {
            Update-AzPolicyAssignment -Name $someName -NotScope $emptyNotScope
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -NotScope <null>' {
        {
            Update-AzPolicyAssignment -Name $someName -NotScope $null
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Id' {
        {
            Update-AzPolicyAssignment -Name $someName -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyAssignment -Name -DisplayName' {
        {
            Update-AzPolicyAssignment -Name $someName -DisplayName $someDisplayName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Description' {
        {
            Update-AzPolicyAssignment -Name $someName -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Metadata' {
        {
            Update-AzPolicyAssignment -Name $someName -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Name $someName -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -Id' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyAssignment -Name -Scope -DisplayName' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -DisplayName $someDisplayName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -Description' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -Metadata' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -Id' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Id $someId
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -Description' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -Metadata' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Metadata' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -PolicyParameter $someParameters
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType <user> -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Name -Scope -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType -IdentityId -Location' {
        {
            Update-AzPolicyAssignment -Name $someName -Scope $someScope -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id <missing>' {
        {
            Update-AzPolicyAssignment -Id
        } | Should -Throw $missingAnArgument
    }

    It 'Update-AzPolicyAssignment -Id' {
        {
            Update-AzPolicyAssignment -Id $goodId
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -DisplayName' {
        {
            Update-AzPolicyAssignment -Id $someId -DisplayName $someDisplayName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -Description' {
        {
            Update-AzPolicyAssignment -Id $someId -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -Metadata' {
        {
            Update-AzPolicyAssignment -Id $someId -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Id $someId -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Id $someId -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -IdentityType' {
        {
            Update-AzPolicyAssignment -Id $someId -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -Description' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -Metadata' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -IdentityType' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Metadata' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -IdentityType' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -IdentityType' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameter' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameter $someParameters
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -IdentityType' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -IdentityType -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -PolicyParameter $someParameters
        } | Should -Throw $parameterSetError
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned'
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType <user> -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType <sys> -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'SystemAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType -IdentityId' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId
        } | Should -Throw $policyAssignmentMissingLocation
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType <user> -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -Location $someLocation
        } | Should -Throw $policyAssignmentMissingIdentityId
    }

    It 'Update-AzPolicyAssignment -Id -NotScope -DisplayName -Description -Metadata -PolicyParameterObject -IdentityType <user> -IdentityId -Location' {
        {
            Update-AzPolicyAssignment -Id $someId -NotScope $someNotScope -DisplayName $someDisplayName -Description $description -Metadata $metadata -PolicyParameterObject $someParameterObject -IdentityType 'UserAssigned' -IdentityId $goodIdentityId -Location $someLocation
        } | Should -Throw $policyAssignmentNotFound
    }
}