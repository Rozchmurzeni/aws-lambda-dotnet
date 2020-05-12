dotnet lambda deploy-serverless `
    --project-location $PSScriptRoot/AwsLambdaDotnet.Functions `
    --configuration Release `
    --region eu-west-1 `
    --stack-name aws-lambda-dotnet `
    --s3-bucket your-deploy-bucket `
    --s3-prefix AwsLambdaDotnet.Functions/ `
    --template $PSScriptRoot/AwsLambdaDotnet.Functions/serverless.yaml