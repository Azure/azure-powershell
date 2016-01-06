using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FormatParser
{
    public class Program
    {
        public void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new InvalidOperationException("The first parameter must contain a valid format file.");
            }

            var formatFile = args[0];
            if (!File.Exists(formatFile))
            {
                throw new InvalidOperationException("The first parameter must contain a valid format file.");
            }

            Console.WriteLine("****************");
            Console.WriteLine($"Processing file '{formatFile}'");
            Console.WriteLine("****************");
            Console.WriteLine();
            var logger = new ConsoleLogger();
            var parser = new FormatParser(logger, formatFile);
            var validTypes = parser.GetValidTypeList().ToList();
            List<string> invalidTypes = null;
            foreach (var validType in validTypes)
            {
                Console.WriteLine($"Found valid type '{validType}'");
            }
            if (parser.ValidateFormat())
            {
                Console.WriteLine("All Types valid");
            }
            else
            {
                Console.WriteLine("Some Types Invalid");
                invalidTypes = parser.GetInvalidTypeList().ToList();
                foreach (var invalidType in invalidTypes )
                {
                    Console.WriteLine($"Found invalid type '{invalidType}'");
                }
            }

            var assemblyName = args[1];
            Console.WriteLine("****************");
            Console.WriteLine($"Processing file '{assemblyName}'");
            Console.WriteLine("****************");
            Console.WriteLine();

            var validator = new CmdletValidator(logger, assemblyName);
            foreach (var data in validator.ValidateCmdletOutput())
            {
                logger.WriteMessage($"{data.CmdletName}");
                if (data.OutputType != null)
                {
                    foreach (var type in data.OutputType)
                    {
                        logger.WriteMessage($"output type: {type.FullName}");
                        if (invalidTypes != null && invalidTypes.Contains(type.FullName))
                        {
                            logger.WriteError($"### INVALID FORMAT: Cmdlet {data.CmdletName} has INVALID format for output type {type.FullName}");
                        }
                        if (!validTypes.Contains(type.FullName) && data.IsComplex)
                        {
                            logger.WriteError($"### MISSING FORMAT: Cmdlet {data.CmdletName} has MISSING format for output type {type.FullName}");
                        }
                    }

                    if (data.HasComplexOutput)
                    {
                        logger.WriteWarning($"OUTPUT TYPE WITH COMPLEX PROPERTIES: Cmdlet {data.CmdletName} has at least one output type which has complex properties");
                    }

                }
                else
                {
                    logger.WriteError($"MISSING OUTPUT TYPE: No output type specified for cmdlet {data.CmdletName}");
                }

                logger.WriteMessage("*****");
            }

            Console.WriteLine("Processing Complete");
            Console.ReadLine();
        }
    }
}
