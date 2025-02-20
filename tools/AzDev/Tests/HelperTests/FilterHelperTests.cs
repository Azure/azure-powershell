using AzDev.Models.Inventory;
using AzDev.Services;

namespace AzDev.Tests;

public class FilterHelperTests
{
    [Fact]
    public void CanFilterProjects()
    {
        var codebase = new Codebase
        {
            Modules = new List<Module>
            {
                new Module
                {
                    Name = "FirstModule",
                    Projects = new List<Project>
                    {
                        new OtherProject { Name = "AlphaProject" }
                    }
                },
                new Module
                {
                    Name = "SecondModule",
                    Projects = new List<Project>
                    {
                        new OtherProject { Name = "BetaProject" }
                    }
                }
            }
        };

        // filter by module name
        var filter = "first";
        var result = codebase.FilterProjects(filter);
        Assert.Single(result);
        Assert.Equal("AlphaProject", result.First().Name);

        filter = "second";
        result = codebase.FilterProjects(filter);
        Assert.Single(result);
        Assert.Equal("BetaProject", result.First().Name);

        filter = "module";
        result = codebase.FilterProjects(filter);
        Assert.Equal(2, result.Count());

        filter = "third";
        result = codebase.FilterProjects(filter);
        Assert.Empty(result);

        // filter by project name
        filter = "alpha";
        result = codebase.FilterProjects(filter);
        Assert.Single(result);
        Assert.Equal("AlphaProject", result.First().Name);

        filter = "beta";
        result = codebase.FilterProjects(filter);
        Assert.Single(result);
        Assert.Equal("BetaProject", result.First().Name);

        filter = "project";
        result = codebase.FilterProjects(filter);
        Assert.Equal(2, result.Count());

        filter = "gamma";
        result = codebase.FilterProjects(filter);
        Assert.Empty(result);
    }

    [Fact]
    public void FilterProjectsThrowsOnNullOrEmptyFilter()
    {
        var codebase = new Codebase();
        Assert.Throws<ArgumentException>(() => codebase.FilterProjects(null));
        Assert.Throws<ArgumentException>(() => codebase.FilterProjects(string.Empty));
    }

    [Fact]
    public void ReturnBothWhenModuleAndProjectSameName()
    {
        var codebase = new Codebase
        {
            Modules = new List<Module>
            {
                new Module
                {
                    Name = "FirstModule",
                    Projects = new List<Project>
                    {
                        new OtherProject { Name = "AlphaProject" }
                    }
                },
                new Module
                {
                    Name = "SecondModule",
                    Projects = new List<Project>
                    {
                        new OtherProject { Name = "BetaProject (First)" }
                    }
                }
            }
        };

        var filter = "first";
        var result = codebase.FilterProjects(filter);
        Assert.Equal(2, result.Count());
    }

}