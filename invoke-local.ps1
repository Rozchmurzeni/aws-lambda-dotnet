aws lambda invoke `
    --function-name calculate-student-grade-lambda `
    --payload file://payload.json `
    --endpoint-url "http://127.0.0.1:3001" `
    response-local.json