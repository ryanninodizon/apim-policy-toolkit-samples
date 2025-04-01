az login
az account set --subscription <<YOUR_SUBSCRIPTION_ID>>

cd .\infra\
az deployment group create \
  --resource-group <<YOUR_RESOURCE_GROUP>> \
  --template-file .\deployment.bicep \
  --parameters servicename=<<YOUR_SERVICE_NAME>> \
  --name deploy-1