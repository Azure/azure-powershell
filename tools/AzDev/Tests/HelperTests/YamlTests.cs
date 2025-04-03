using AzDev.Models.Inventory;

namespace AzDev.Tests;

public class YamlTests
{
    [Fact]
    public void CanDeserialize()
    {
        var yaml = @"module-version: 0.1.0
title: Alb
subject-prefix: $(service-name)
inlining-threshold: 100

# pin the swagger version by using the commit id instead of branch name
commit:  1b338481329645df2d9460738cbaab6109472488
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/servicenetworking/resource-manager/readme.md

try-require:
  - $(repo)/specification/servicenetworking/resource-manager/readme.powershell.md

directive:
  # Fix swagger issues
  - from: swagger-document
    where: $.definitions.TrafficControllerUpdateProperties
    transform: delete $['properties']";
        var result = YamlHelper.Deserialize<AutoRestYamlConfig>(yaml);
        Assert.Equal("Alb", result.Title);
        Assert.Equal("1b338481329645df2d9460738cbaab6109472488", result.Commit);
        Assert.Equal(2, result.Require.Count());
        Assert.Single(result.TryRequire);
        Assert.Single(result.Directive);
        Assert.Empty(result.InputFile);
    }

    [Fact]
    public void DefaultValues()
    {
        var yaml = @"module-version: 0.1.0";
        var result = YamlHelper.Deserialize<AutoRestYamlConfig>(yaml);
        Assert.Null(result.Title);
        Assert.Null(result.Commit);
        Assert.Empty(result.Require);
        Assert.Empty(result.TryRequire);
        Assert.Empty(result.Directive);
        Assert.Empty(result.InputFile);
    }
}
