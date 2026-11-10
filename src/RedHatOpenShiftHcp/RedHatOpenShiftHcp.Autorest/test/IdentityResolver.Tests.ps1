# Offline unit tests for the C2/C3 shared helper custom/IdentityResolver.cs.
# Pure string -> string logic: no Azure, no HTTP, no recording. The module must be imported (the harness
# does this) so the compiled type is available.

Describe 'IdentityResolver' {
    BeforeAll {
        $resolver = [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom.IdentityResolver]
        $subnet   = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-rg/providers/Microsoft.Network/virtualNetworks/customer-vnet/subnets/customer-subnet-1'
    }

    It 'returns a full UAMI resource ID unchanged' {
        $id = '/subscriptions/aaaa/resourceGroups/other-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mi-1'
        $resolver::Resolve($id, $subnet) | Should -Be $id
    }

    It 'returns any /subscriptions/ id unchanged' {
        $id = '/subscriptions/bbbb/resourceGroups/rg/providers/Microsoft.Something/foo/bar'
        $resolver::Resolve($id, $subnet) | Should -Be $id
    }

    It 'expands a bare name using sub+rg parsed from the subnet id' {
        $expected = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/my-mi'
        $resolver::Resolve('my-mi', $subnet) | Should -Be $expected
    }

    It 'is idempotent: resolving the expanded id again returns it unchanged' {
        $once = $resolver::Resolve('my-mi', $subnet)
        $resolver::Resolve($once, $subnet) | Should -Be $once
    }

    It 'returns empty input unchanged' {
        $resolver::Resolve('', $subnet) | Should -Be ''
    }

    It 'throws for a bare name when no subnet is provided' {
        { $resolver::Resolve('my-mi', '') } | Should -Throw 'PlatformSubnetId was not provided'
    }

    It 'throws for a bare name when the subnet id is unparseable' {
        { $resolver::Resolve('my-mi', 'not-a-valid-subnet-id') } | Should -Throw 'Cannot parse subscription'
    }
}
