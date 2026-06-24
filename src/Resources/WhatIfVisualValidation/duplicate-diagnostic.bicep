resource duplicateDiagnostic 'RP.Namespace/widgets@1999-12-31' = {
  name: 'foo'
  properties: {
    source: 'duplicate-diagnostic.bicep'
  }
}

resource duplicateDiagnosticTwo 'RP.Namespace/widgets@1999-12-31' = {
  name: 'bar'
  properties: {
    source: 'duplicate-diagnostic.bicep'
  }
}
