// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class FirstPartyServiceTagTests : NetworkTestRunner
    {
        public FirstPartyServiceTagTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Resource requires first party service tag access")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void TestFirstPartyServiceTagBasicOperations()
        {
            TestRunner.RunTestScript("Test-FirstPartyServiceTagsCRUD");
        }
    }
}
