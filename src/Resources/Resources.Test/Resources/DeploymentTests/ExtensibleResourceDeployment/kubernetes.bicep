@secure()
param kubeConfig string

provider kubernetes with {
  kubeConfig: kubeConfig
  namespace: 'default'
}

var backName = 'azure-vote-back'
var backPort = 6379

var frontName = 'azure-vote-front'
var frontPort = 80

@description('Application back-end deployment (redis)')
resource backDeploy 'apps/Deployment@v1' = {
  metadata: {
    name: backName
  }
  spec: {
    replicas: 1
    selector: {
      matchLabels: {
        app: backName
      }
    }
    template: {
      metadata: {
        labels: {
          app: backName
        }
      }
      spec: {
        containers: [
          {
            name: backName
            image: 'mcr.microsoft.com/oss/bitnami/redis:6.0.8'
            env: [
              {
                name: 'ALLOW_EMPTY_PASSWORD'
                value: 'yes'
              }
            ]
            resources: {
              requests: {
                cpu: '100m'
                memory: '128Mi'
              }
              limits: {
                cpu: '250m'
                memory: '256Mi'
              }
            }
            ports: [
              {
                containerPort: backPort
                name: 'redis'
              }
            ]
          }
        ]
      }
    }
  }
}

@description('Configure back-end service')
resource backSvc 'core/Service@v1' = {
  metadata: {
    name: backName
  }
  spec: {
    ports: [
      {
        port: backPort
      }
    ]
    selector: {
      app: backName
    }
  }
}

@description('Application front-end deployment (website)')
resource frontDeploy 'apps/Deployment@v1' = {
  metadata: {
    name: frontName
  }
  spec: {
    replicas: 1
    selector: {
      matchLabels: {
        app: frontName
      }
    }
    template: {
      metadata: {
        labels: {
          app: frontName
        }
      }
      spec: {
        nodeSelector: {
          'beta.kubernetes.io/os': 'linux'
        }
        containers: [
          {
            name: frontName
            image: 'mcr.microsoft.com/azuredocs/azure-vote-front:v1'
            resources: {
              requests: {
                cpu: '100m'
                memory: '128Mi'
              }
              limits: {
                cpu: '250m'
                memory: '256Mi'
              }
            }
            ports: [
              {
                containerPort: frontPort
              }
            ]
            env: [
              {
                name: 'REDIS'
                value: backName
              }
            ]
          }
        ]
      }
    }
  }
}

@description('Configure front-end service')
resource frontSvc 'core/Service@v1' = {
  metadata: {
    name: frontName
  }
  spec: {
    type: 'LoadBalancer'
    ports: [
      {
        port: frontPort
      }
    ]
    selector: {
      app: frontName
    }
  }
}
