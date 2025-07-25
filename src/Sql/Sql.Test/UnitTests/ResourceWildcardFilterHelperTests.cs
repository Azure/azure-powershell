using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class ResourceWildcardFilterHelperTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SqlSubResourceWildcardFilterTest()
        {
            ResourceWildcardFilterHelper wildcardFilterHelper = new ResourceWildcardFilterHelper();

            // should match test01
            Assert.Single(wildcardFilterHelper.SqlSubResourceWildcardFilter("test01", ReturnedResources, "PropertyName1"));
            // should match none
            Assert.Empty(wildcardFilterHelper.SqlSubResourceWildcardFilter("test", ReturnedResources, "PropertyName1"));
            // should match all
            Assert.Equal(11, wildcardFilterHelper.SqlSubResourceWildcardFilter("t*t*", ReturnedResources, "PropertyName1").Count);
            // should match none
            Assert.Empty(wildcardFilterHelper.SqlSubResourceWildcardFilter("t*t", ReturnedResources, "PropertyName1"));
            // should match test01 and test11
            Assert.Equal(2, wildcardFilterHelper.SqlSubResourceWildcardFilter("t*1", ReturnedResources, "PropertyName1").Count);
            // should match all because empty value
            Assert.Equal(11, wildcardFilterHelper.SqlSubResourceWildcardFilter(string.Empty, ReturnedResources, "PropertyName1").Count);
            // should match all because null property name
            Assert.Equal(11, wildcardFilterHelper.SqlSubResourceWildcardFilter("anything", ReturnedResources, null).Count);
        }

        private readonly List<TestResource> ReturnedResources = new List<TestResource>()
        {
            new TestResource("test01", "case01"),
            new TestResource("test02", "case02"),
            new TestResource("test03", "case03"),
            new TestResource("test04", "case04"),
            new TestResource("test05", "case05"),
            new TestResource("test06", "case06"),
            new TestResource("test07", "case07"),
            new TestResource("test08", "case08"),
            new TestResource("test09", "case09"),
            new TestResource("test10", "case10"),
            new TestResource("test11", "case11"),
        };
    }

    internal class TestResource
    {
        public TestResource(string PropertyName1, string PropertyName2)
        {
            this.PropertyName1 = PropertyName1;
            this.PropertyName2 = PropertyName2;
        }

        public string PropertyName1 { get; set; }

        public string PropertyName2 { get; set; }
    }
}