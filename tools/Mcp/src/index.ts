import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js"
import { CodegenServer } from "./models/CodegenServer.js";
import * as utils from "./services/utils.js";

// Create server instance
// const server = new McpServer({
//     name: "codegen",
//     version: "1.0.0",
//     capabilities: {
//       resources: {},
//       tools: {},
//     },
// });

// const toolSchemas = specs.tools as toolSchema[];
// for (const schema of toolSchemas) {
//     const parameter = createToolParameterfromSchema(schema.parameters);
//     const callBack = toolServices<typeof parameter>(schema.callbackName);
//     server.tool(
//         schema.name,
//         schema.description,
//         parameter,
//         (parameter) => callBack(parameter)
//     );
// }
// function createToolParameterfromSchema(schemas: toolParameterSchema[]){
//     const parameter: {[k: string]: z.ZodTypeAny} = {}; 
//     for (const schema of schemas) {
//         switch (schema.type) {
//             case "string":
//                 parameter[schema.name] = z.string().describe(schema.description);
//                 break;
//             case "number":
//                 parameter[schema.name] = z.number().describe(schema.description);
//                 break;
//             case "boolean": 
//             parameter[schema.name] = z.boolean().describe(schema.description);
//                 break;
//             case "array":
//                 parameter[schema.name] = z.array(z.string()).describe(schema.description);
//                 break;
//             // object parameter not supported yet    
//             // case "object":
//             //     parameter[schema.name] = z.object({}).describe(input.description); // Placeholder for object type
//             //     break;
//             default:
//                 throw new Error(`Unsupported parameter type: ${schema.type}`);
//         }
//     }
//     return parameter;
// }

// const param = {
//     workingDirectory: z.string().describe("absolute path of the README.md where the code will be generated"),
// } as ZodRawShape;

// server.tool(
//     "generate-autorest",
//     "Generate code using autorest",
//     param,
//     (param) => generateByAutorest(param),
// );

const server = CodegenServer.getInstance();

async function main() {
    server.init();
    const transport = new StdioServerTransport();
    await server.connect(transport);
    console.log(`Codegen MCP Server running on stdio at ${new Date()}`);
}

main().catch((error) => {
    console.error("Fatal error in main():", error);
    process.exit(1);
})