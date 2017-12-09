using System;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface ITaskProgress
    {
        IResourceConfig Config { get; }

        double GetProgress();

        bool IsDone { get; }
    }
}
