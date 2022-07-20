const raw = require('./CommandMappings.json');

var allC = [];
for (const m in raw.modules) {
    for (const c in raw.modules[m]) {
        allC.push(c);
    }
}

console.log(allC.length);

for (var r in raw.migration) {
    for (var c in raw.migration[r]) {
        const rep = raw.migration[r][c].replacement;
        if (rep && !allC.includes(rep)) {
            console.error(`${rep} is not found.`);
        }
    }
}