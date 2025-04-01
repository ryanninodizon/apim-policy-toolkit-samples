param servicename string

resource service 'Microsoft.ApiManagement/service@2023-03-01-preview' existing = {
  name: servicename
  scope: resourceGroup()
}

resource echoApi 'Microsoft.ApiManagement/service/apis@2023-03-01-preview' existing = {
  parent: service
  name: 'echo-api'
}

resource echoApiPolicy 'Microsoft.ApiManagement/service/apis/policies@2023-03-01-preview' = {
  parent: echoApi
  name: 'policy'
  properties: {
    format: 'rawxml'
    value: loadTextContent('./apis/${echoApi.name}/TestPolicy.xml', 'utf-8')
  }
}
