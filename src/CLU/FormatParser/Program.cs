using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Network;
using Newtonsoft.Json;

namespace FormatParser
{
    public class Program
    {
        public static readonly string[] Modules = new string[]
        {
            "Microsoft.Azure.Commands.Compute",
            "Microsoft.Azure.Commands.Management.Storage",
            "Microsoft.Azure.Commands.Profile",
            "Microsoft.Azure.Commands.Resources",
            "Microsoft.Azure.Commands.Websites",
            "Commands.ResourceManager.Cmdlets"
        };

        public IToolsLogger Logger { get; set; }
        public void Main(string[] args)
        {
            var cluDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..");
            var reportFile = Path.Combine(Directory.GetCurrentDirectory(), "outputTypes.csv");
            Logger = new ConsoleLogger();
            foreach (var assemblyIdentity in Modules)
            {
                (Logger as ConsoleLogger).Assembly = assemblyIdentity;
                var moduleDirectory = Path.Combine(cluDirectory, assemblyIdentity);
                Validate(moduleDirectory, assemblyIdentity);
            }


            Console.WriteLine("Processing Complete");
            var records = (Logger as ConsoleLogger).Records;
            if (records != null && records.Count > 0)
            {
                using (var writer = new StreamWriter(File.OpenWrite(reportFile)))
                {
                    writer.WriteLine(records[0].PrintHeaders());
                    foreach (var record in records)
                    {
                        writer.WriteLine(record.ToString());
                    }
                }
            }

            Console.ReadLine();
        }

        public void Validate(string baseDirectory, string assemblyIdentity)
        {
            var formatPath = Path.Combine(baseDirectory, $"{assemblyIdentity}.format.ps1xml");
            bool validateFormat = File.Exists(formatPath);
            var logger = Logger;
            List<string> invalidTypes = null;
            List<string> validTypes = null;


            if (validateFormat)
            {
                Console.WriteLine("****************");
                Console.WriteLine($"Processing file '{formatPath}'");
                Console.WriteLine("****************");
                Console.WriteLine();
                var parser = new FormatParser(logger, formatPath);
                validTypes = parser.GetValidTypeList().ToList();
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
                    foreach (var invalidType in invalidTypes)
                    {
                        Console.WriteLine($"Found invalid type '{invalidType}'");
                    }
                }
            }

            Console.WriteLine("****************");
            Console.WriteLine($"Processing file '{assemblyIdentity}'");
            Console.WriteLine("****************");
            Console.WriteLine();

            var validator = new CmdletValidator(logger, assemblyIdentity);
            foreach (var validationRecord in validator.ValidateCmdletOutput())
            {
                logger.WriteMessage($"{validationRecord.CmdletName}");
                if (validationRecord.OutputType != null)
                {
                    foreach (var type in validationRecord.OutputType)
                    {
                        logger.WriteMessage($"output type: {type.FullName}");
                        if (invalidTypes != null && invalidTypes.Contains(type.FullName))
                        {
                            logger.WriteError($"### INVALID FORMAT: Cmdlet {validationRecord.CmdletName} has INVALID format for output type {type.FullName}");
                            logger.LogRecord(new ValidationRecord {Target = validationRecord.CmdletName, Description = $"Invalid format for cmdlet output type {type.FullName}",
                                Severity = 0, Remediation = $"Fix output format for type {type.FullName} in {assemblyIdentity}.format.ps1xml" });
                        }

                        if (validationRecord.IsComplex && (validTypes == null || !validTypes.Contains(type.FullName)))
                        {
                            logger.WriteError($"### MISSING FORMAT: Cmdlet {validationRecord.CmdletName} has MISSING format for output type {type.FullName}");
                            logger.LogRecord(new ValidationRecord
                            {
                                Target = validationRecord.CmdletName,
                                Severity = 1,
                                Description = $"Missing output format for cmdlet output type {type.FullName}",
                                Remediation = $"Add an output format for type {type.FullName} in {assemblyIdentity}.format.ps1xml, or verify the default output display is correct."
                            });
                        }

                        if (TypeChangesSerialization(type))
                        {
                            logger.WriteError($"### MISSING DISPLAY TYPE: Cmdlet {validationRecord.CmdletName} outputs an underlying SDK type {type.FullName}, which has non-default Json Serialization. This will break piping scenarios and provided non-optimal Json serialization.");
                            logger.LogRecord(new ValidationRecord
                            {
                                Target = validationRecord.CmdletName,
                                Severity = 0,
                                Description = $"The output type {type.FullName} for cmdlet {validationRecord.CmdletName} uses custom JSON serialization, which will make scripting difficult and break piping scenarios",
                                Remediation = $"Add a new display type for cmdlet output (for example PS{type.Name}), then add an output format for the new type in {assemblyIdentity}.format.ps1xml"
                            });
                        }
                    }

                    if (validationRecord.HasComplexOutput)
                    {
                        logger.WriteWarning($"OUTPUT TYPE WITH COMPLEX PROPERTIES: Cmdlet {validationRecord.CmdletName} has at least one output type which has complex properties");
                        foreach (
                            var type in validationRecord.OutputType.Where(CmdletValidationInfo.HasComplexProperties))
                        {
                            logger.LogRecord(new ValidationRecord
                            {
                                Target = validationRecord.CmdletName,
                                Severity = 3,
                                Description =
                                    $"The output type {type.FullName} for cmdlet {validationRecord.CmdletName} has properties that are complex types, this may result in unexpected siaply output.",
                                Remediation =
                                    $"Verify cmdlet output for {validationRecord.CmdletName}"
                            });
                        }
                    }

                }
                else
                {
                    logger.WriteError($"MISSING OUTPUT TYPE: No output type specified for cmdlet {validationRecord.CmdletName}");
                    logger.LogRecord(new ValidationRecord
                    {
                        Target = validationRecord.CmdletName,
                        Severity = 0,
                        Description =
                           $"The cmdlet {validationRecord.CmdletName} has no OutputType attribute.  Please add an OutputType attribute for each of the types the cmdlet may output.",
                        Remediation =
                           $"Add OutputType attribute for each output type of cmdlet {validationRecord.CmdletName}."
                    });
                }

                logger.WriteMessage("*****");
            }
        }

        private bool TypeChangesSerialization(Type type)
        {
            return
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Any(PropertySerializationChanged);
        }

        private static bool PropertySerializationChanged(PropertyInfo property)
        {
            var result = false;
            if (property.HasAttribute<JsonPropertyAttribute>())
            {
                var attribute = property.GetAttribute<JsonPropertyAttribute>() as JsonPropertyAttribute;
                result = attribute != null &&
                         !string.Equals(attribute.PropertyName, property.Name, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }
}
