using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.CLU.Run.Test
{
    public class MemoryConsoleInputOutput : IConsoleInputOutput
    {
        private TextReader textReader = new StringReader("az env");
        private StringBuilder stringBuilder = new StringBuilder();
        private TextWriter textWriter;

        public MemoryConsoleInputOutput()
        {
            this.textWriter = new StringWriter(stringBuilder);
        }

        public TextReader Input
        {
            get
            {
                return this.textReader;
            }
        }

        public bool IsInputRedirected
        {
            get
            {
                return false;
            }
        }

        public bool IsOutputRedirected
        {
            get
            {
                return false;
            }
        }

        public TextWriter PipelineOutput
        {
            get
            {
                return this.textWriter;
            }
        }

        public TextWriter TextOutput
        {
            get
            {
                return this.textWriter;
            }
        }

        public int WindowWidth
        {
            get
            {
                return 200;
            }
        }

        public int PromptForChoice(string caption, string message, IEnumerable<Choice> choices, int defaultChoice)
        {
            throw new NotImplementedException();
        }

        public ConsoleKeyInfo ReadKey()
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        public void Write(string value)
        {
            this.textWriter.Write(value);
        }

        public void Write(string format, params object[] values)
        {
            this.textWriter.Write(string.Format(format, values));
        }

        public void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            Write(value);
        }

        public void WriteDebugLine(string message)
        {
            this.textWriter.WriteLine("DEBUG: " + message);
        }

        public void WriteErrorLine(string message)
        {
            this.textWriter.WriteLine("ERROR: " + message);
        }

        public void WriteLine()
        {
            this.textWriter.WriteLine();
        }

        public void WriteLine(string value)
        {
            this.textWriter.WriteLine(value);
        }

        public void WriteLine(string format, params object[] values)
        {
            this.textWriter.WriteLine(string.Format(format, values));
        }

        public void WriteLine(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            WriteLine(value);
        }

        public void WriteVerboseLine(string message)
        {
            this.textWriter.WriteLine("VERBOSE: " + message);
        }

        public void WriteWarningLine(string message)
        {
            this.textWriter.WriteLine("WARNING: " + message);
        }
    }
}
