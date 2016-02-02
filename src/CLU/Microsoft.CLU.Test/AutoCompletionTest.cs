using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.CLU.Help;
using Microsoft.CLU.CommandModel;
using Microsoft.CLU.CommandBinder;
using Moq;
using System.Management.Automation;
using Microsoft.CLU.Common;
using Microsoft.CLU.Common.Properties;

namespace Microsoft.CLU.Test
{
    public class AutoCompletionTest
    {
        private readonly ConfigurationDictionary mockConfig;
        private readonly Mock<IHelpPackageFinder> helpPackageFinderMock = new Mock<IHelpPackageFinder>();
        private readonly Mock<ICommandRuntime> mockCommandRuntime = new Mock<ICommandRuntime>();
        private CmdletBinderAndCommand cmdletBinderAndCommandMock;
        public AutoCompletionTest()
        {
            mockConfig = ConfigurationDictionary.Create(new string[] { "test" });
            this.cmdletBinderAndCommandMock = new CmdletBinderAndCommand(mockConfig, mockCommandRuntime.Object);
            this.helpPackageFinderMock
                .Setup(m => m.FindPackages())
                .Returns(() =>
                {
                    return new List<CommandDispatchHelper.PkgInfo>()
                    {
                        new MockPkgInfo("abc", "1.0.0", "abc.ext"),
                        new MockPkgInfo("abc;def", "1.0.0", "abc.def.ext"),
                        new MockPkgInfo("abc;dkf;ghi", "1.0.0", "abc.dkf.ghi.ext"),
                        new MockPkgInfo("ddd;eee;aaa", "1.0.0", "ddd.eee.aaa.ext"),
                    };
                });
        }
        //test commandline with --complete
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListCommandsWithComplete()
        {
            var commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[1] { "ab" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[1] { "ab" }, true, commandInfos)).ElementAt(0), "abc");
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[1] { "ab" }, true, commandInfos)).Count(), 1);

            commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "abc" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc" }, true, commandInfos)).Count(), 3);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc" }, true, commandInfos)).ElementAt(0), "");
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc" }, true, commandInfos)).ElementAt(1), "def");
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc" }, true, commandInfos)).ElementAt(2), "dkf");

            commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "ddd", "eee" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "ddd", "eee" }, true, commandInfos)).Count(), 1);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "ddd", "eee" }, true, commandInfos)).ElementAt(0), "aaa");

            commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "abc", "d" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "d" }, true, commandInfos)).Count(), 2);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "d" }, true, commandInfos)).ElementAt(0), "def");
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "d" }, true, commandInfos)).ElementAt(1), "dkf");

            var expected = string.Format(Strings.CmdletHelp_Generate_NoCommandAvailable, CLUEnvironment.ScriptName, String.Join(" ", new string[] { "abc", "k" }));
            commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "abc", "k" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "k" }, true, commandInfos)).Count(), 1);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "k" }, true, commandInfos)).ElementAt(0), expected);
        }
        //test commandline without  --complete
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListCommandsWithOutComplete()
        {
            var commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "ddd", "eee" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "ddd", "eee" }, false, commandInfos)).Count(), 1);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "ddd", "eee" }, false, commandInfos)).ElementAt(0), "ddd eee aaa");

            var expected = string.Format(Strings.CmdletHelp_Generate_NoCommandAvailable, CLUEnvironment.ScriptName, String.Join(" ", new string[] {"abc", "k"}));
            commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "abc", "k" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "k" }, false, commandInfos)).Count(), 1);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "k" }, false, commandInfos)).ElementAt(0), expected);

            commandInfos = CommandDispatchHelper.CompleteCommands(this.helpPackageFinderMock.Object, new string[] { "abc", "d" }).ToArray();
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "d" }, false, commandInfos)).Count(), 2);
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "d" }, false, commandInfos)).ElementAt(0), "abc def");
            Assert.Equal((this.cmdletBinderAndCommandMock.ListCommands(new string[] { "abc", "d" }, false, commandInfos)).ElementAt(1), "abc dkf ghi");
        }
        
    }
}
