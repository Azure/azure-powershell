using System.IO.Abstractions.TestingHelpers;
using AzDev.Services;
using Xunit.Sdk;

namespace AzDev.Tests;

public class DefaultContextProviderTests
{
    [Fact]
    public void ContextIO()
    {
        var fs = new MockFileSystem();
        const string profilePath = @"C:\DevContext.json";
        var contextProvider = new DefaultContextProvider(profilePath, fs, NoopLogger.Instance);
        // context file should not exist
        Assert.False(fs.FileExists(profilePath));
        Assert.Throws<FileNotFoundException>(contextProvider.LoadContext);

        var context = new AzDev.Models.DevContext()
        {
            AzurePowerShellRepositoryRoot = @"D:\azure-powershell"
        };
        contextProvider.SaveContext(context);
        // you can save multiple times
        contextProvider.SaveContext(context);
        // now the context file should exist
        Assert.True(fs.FileExists(profilePath));
        // the in-memory context should be updated
        Assert.Equal(context.AzurePowerShellRepositoryRoot, contextProvider.LoadContext().AzurePowerShellRepositoryRoot);
        // force reload from disk
        contextProvider = new DefaultContextProvider(profilePath, fs, NoopLogger.Instance);
        Assert.Equal(context.AzurePowerShellRepositoryRoot, contextProvider.LoadContext().AzurePowerShellRepositoryRoot);
    }

    [Fact]
    public void LoadFromDisk()
    {
        const string profilePath = @"C:\DevContext.json";
        var fs = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { profilePath, new MockFileData(@"{
                ""AzurePowerShellRepositoryRoot"":""D:\\azure-powershell"",
                ""AzurePowerShellCommonRepositoryRoot"":""D:\\azure-powershell-common"",
                ""UnsupportedProperty"":""value""
            }") }
        }); // UnsupportedProperty should not block deserialization
        var contextProvider = new DefaultContextProvider(profilePath, fs, NoopLogger.Instance);
        var context = contextProvider.LoadContext();
        Assert.Equal(@"D:\azure-powershell", context.AzurePowerShellRepositoryRoot);
        Assert.Equal(@"D:\azure-powershell-common", context.AzurePowerShellCommonRepositoryRoot);
    }
}