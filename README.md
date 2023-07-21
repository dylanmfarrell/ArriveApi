# Arrive Product Service

### Running the Arrive Product Service
1. Run the git clone command on this git repository: https://github.com/dylanmfarrell/ArriveApi.git or open in Visual Studio from git
2. If you have Docker Desktop installed and want to run this in Docker, select the "Docker" launch profile in Visual Studio.
3. To run this application in kestrel, select ArriveApi
4. If you see the Swagger home page you are ready to use the Arrive Product Service

### Using the Arrive Product Service
1. Depending on the profile you chose to run the Arrive Product Service your host will be different. Navigate to https://localhost:7110/swagger/index.html for Kestrel
2. Click on the /api/products endpoint and call the post method with this product info:

## Code
{
  "name": "Test1234",
  "quantity": 10
}


3. In the response body you should be given an id for the product you just inserted. You can use this value to test the PUT,DELETE and GET/{productId} endpoints

