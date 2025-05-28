import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js"
import { CodegenServer } from "./CodegenServer.js";
import * as utils from "./services/utils.js";
import { yamlContent } from "./types.js";

const server = CodegenServer.getInstance();

async function main() {
    server.init();
    const transport = new StdioServerTransport();
    await server.connect(transport);
    const time = `Codegen MCP Server running on stdio at ${new Date()}`;
    console.log(time);
    
    // const yaml = utils.getYamlContentFromReadMe("C:/workspace/azure-powershell/tools/Mcp/test/README.md") as yamlContent;
    // console.log(yaml['input-file'])
    // for (const directive of yaml.directive) {
    //     console.log(directive);
    // }
    //utils.testCase();
}

main().catch((error) => {
    console.error("Fatal error in main():", error);
    process.exit(1);
})