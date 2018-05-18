namespace Microsoft.Azure.Commands.StorageSync.Evaluation.OutputWriters
{
    using System;

    class AfsConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }
    }
}
