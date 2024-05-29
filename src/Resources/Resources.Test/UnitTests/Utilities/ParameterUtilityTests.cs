using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class ParameterUtilityTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTemplateFileParametersToHashtable()
        {
            var parameterObject = new Hashtable();
            var parameters = new Dictionary<string, TemplateParameterFileParameter>();
            var testObject = JObject.Parse("{ \"Test\": \"value\" }");

            parameters.Add("param1", new TemplateParameterFileParameter { Value = "val1" });
            parameters.Add("param2", new TemplateParameterFileParameter { Reference = testObject });
            parameters.Add("param3", new TemplateParameterFileParameter { Value = "val2" });

            ParameterUtility.AddTemplateFileParametersToHashtable(parameters, parameterObject);

            ((Hashtable)parameterObject["param1"])["value"].Should().Be("val1");
            ((Hashtable)parameterObject["param2"])["reference"].Should().Be(testObject);
            ((Hashtable)parameterObject["param3"])["value"].Should().Be("val2");

            ((Hashtable)parameterObject["param1"]).Keys.Count.Should().Be(1);
            ((Hashtable)parameterObject["param2"]).Keys.Count.Should().Be(1);
            ((Hashtable)parameterObject["param3"]).Keys.Count.Should().Be(1);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddTemplateObjectParametersToHashtable()
        {
            var parameterObject = new Hashtable();
            var parameters = new Hashtable();
            var testObject = JObject.Parse("{ \"Test\": \"value\" }");

            parameters.Add("param1", "val1");
            parameters.Add("param2", new Hashtable() { { "reference", testObject } } );
            parameters.Add("param3", "val2");

            ParameterUtility.AddTemplateObjectParametersToHashtable(parameters, parameterObject);

            ((Hashtable)parameterObject["param1"])["value"].Should().Be("val1");
            ((Hashtable)parameterObject["param2"])["reference"].Should().Be(testObject);
            ((Hashtable)parameterObject["param3"])["value"].Should().Be("val2");

            ((Hashtable)parameterObject["param1"]).Keys.Count.Should().Be(1);
            ((Hashtable)parameterObject["param2"]).Keys.Count.Should().Be(1);
            ((Hashtable)parameterObject["param3"]).Keys.Count.Should().Be(1);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestructureBicepParameters()
        {
            var bicepParameters = new Dictionary<string, TemplateParameterFileParameter>();
            var testObject = JObject.Parse("{ \"Test\": \"value\" }");

            bicepParameters.Add("param1", new TemplateParameterFileParameter { Value = "val1" });
            bicepParameters.Add("param2", new TemplateParameterFileParameter { Reference = testObject });
            bicepParameters.Add("param3", new TemplateParameterFileParameter { Value = "val2" });

            var parameterObject = ParameterUtility.RestructureBicepParameters(bicepParameters);

            parameterObject["param1"].Should().Be("val1");
            ((Hashtable)parameterObject["param2"])["reference"].Should().Be(testObject);
            parameterObject["param3"].Should().Be("val2");

            ((Hashtable)parameterObject["param2"]).Keys.Count.Should().Be(1);
        }
    }
}
