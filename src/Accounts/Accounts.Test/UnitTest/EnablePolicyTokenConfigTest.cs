// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------
using Microsoft.Azure.Commands.Common.Authentication.Config.Definitions;
using NUnit.Framework;

namespace Microsoft.Azure.Commands.Profile.Test.UnitTest
{
    [TestFixture]
    public class EnablePolicyTokenConfigTest
    {
        [Test]
        public void Default_IsFalse_And_KeyMatches()
        {
            var cfg = new EnablePolicyTokenConfig();
            Assert.AreEqual(false, cfg.DefaultValue, "Default should be false for safety opt-in.");
            Assert.AreEqual("EnablePolicyToken", cfg.Key, "Config key mismatch.");
        }
    }
}
