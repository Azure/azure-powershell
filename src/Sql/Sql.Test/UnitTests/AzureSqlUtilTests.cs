using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class AzureSqlUtilTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MailValidation()
        {
            Assert.True(Util.AreEmailAddressesInCorrectFormat(new[] {
                "kuku@microsoft.com",
                "Kuku@microsoft.com",
                "KUKU@MICROSOFT.COM"}), "Valid email addresses are flagged as invalid");
            Assert.False(Util.AreEmailAddressesInCorrectFormat(new[] { "kuku" }), "Invalid mail address not detected");
            Assert.False(Util.AreEmailAddressesInCorrectFormat(new[] { "kuku@microsoft" }), "Invalid mail address not detected");
            Assert.False(Util.AreEmailAddressesInCorrectFormat(new[] { "@micorsoft.com", "kuku@microsoft.com" }), "One fauly mail address should fail the lot");
        }
    }
}
