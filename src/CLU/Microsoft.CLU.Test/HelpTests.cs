using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.CLU.Help;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.CLU.Test
{
    public class HelpTests
    {
        private readonly Mock<IHelpPackageFinder> helpPackageFinderMock = new Mock<IHelpPackageFinder>();

        public HelpTests()
        {
            this.helpPackageFinderMock
                .Setup(m => m.FindPackages())
                .Returns(() =>
                {
                    return new List<CommandDispatchHelper.PkgInfo>()
                    {
                        new MockPkgInfo("abc", "1.0.0", "foo"),
                        new MockPkgInfo("abc def", "1.0.0", "foo"),
                        new MockPkgInfo("abc def ghi", "1.0.0", "foo"),
                        new MockPkgInfo("ddd eee aaa", "1.0.0", "foo"),
                    };
                });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHelpStartsWith()
        {
            var commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "a" });
            Assert.Equal(3, commandInfos.Count());
            Assert.Equal(commandInfos.Count(), commandInfos.Where(c => c.Discriminators.StartsWith("a")).Count());

            commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "abc" });
            Assert.Equal(3, commandInfos.Count());
            Assert.Equal(commandInfos.ElementAt(0).Discriminators, "abc");
            Assert.Equal(commandInfos.ElementAt(1).Discriminators, "abc def");
            Assert.Equal(commandInfos.ElementAt(2).Discriminators, "abc def ghi");

            commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "dd" });
            Assert.Equal(1, commandInfos.Count());
            Assert.Equal(commandInfos.Count(), commandInfos.Where(c => c.Discriminators.StartsWith("dd")).Count());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHelpParams()
        {
            var commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "help" });
            int count = commandInfos.Count();
            Assert.True(count > 0);

            commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "--help" });
            Assert.True(commandInfos.Count() == count);

            commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "-help" });
            Assert.True(commandInfos.Count() == count);

            commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "-h" });
            Assert.True(commandInfos.Count() == count);

            commandInfos = CommandDispatchHelper.CompleteCommands(helpPackageFinderMock.Object, new string[] { "--h" });
            Assert.True(commandInfos.Count() == count);
        }
    }
}
