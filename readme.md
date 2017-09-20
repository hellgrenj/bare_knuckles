# bare knuckles  
A demo of a simple zero-downtime-deployment strategy using docker compose and HAProxy. 
The example application in the demo is built with the following tech: .net core 2.0, entity framework core 2.0, postgresql/mssql-linux and docker. 

## prerequisites  
* docker (with docker-compose) (tested on 17.06.2-ce-win27 and 17.06.2-ce-mac27)  
* node 8.4.x or greater  
* .net core 2.0

## take it for a spin
 
in .\bare_knuckles\api  
* run ``` dotnet restore ```  
  
in .\bare_knuckles      
* run ```npm install```  
* open one terminal tab and run ``` docker-compose up ```   
* wait until docker-compose is running the system, then open another terminal tab and run 
``` node exercise.js ```    
(this is a script simulating users. it sends a request every second and prints the response)   
Now you can see the requests being handled by two instances of ./bare_knuckles/api (HAProxy balancing with round robin) in one terminal tab (docker-compose up)  
and the responses in the other tab (exercise.js)      
* Now change what DemoController (GET /demo) is returning! (see BloggingContext and ValuesController for some example data access code)
* Finally in a third tab run the deployment script ``` node zero-downtime-deployment.js ``` and see your changes reach "the users"  
(output from the running exercise.js script) without the system ever becoming unavailable.


## .....and if you want, try this demo with mssql-linux instead of postgres
First stop the demo system (docker-compose stop) and kill the exercise.js script, then:  

1. replace postgres in docker-compose with

```
 mssql:
    image: microsoft/mssql-server-linux
    ports:
      - "1433:1433"
    volumes:
    - sharedvol:/var/opt/mssql
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=BareKNuckles10
```
**and make sure you have a volume "sharedvol" ..   
see the postgresvol for an example in the same docker-compose file**  

2. change what driver is being used in api.csproj
```
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.0.0" />
  <!-- <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.0.0" /> -->
```

3. update the connection string and the driver being used in Startup.cs
```
  // postgres
  var sqlConnectionString = @"Server=postgres;Database=postgres;User Id=admin;Password=password";
  services.AddDbContext<BloggingContext>(options => options.UseNpgsql(sqlConnectionString));
    
  // sql server
  // var sqlConnectionString = @"Server=mssql;Database=Blogging;User Id=sa;Password=BareKNuckles10";
  // services.AddDbContext<BloggingContext>(options => options.UseSqlServer(sqlConnectionString));
```
4.  remove existing migrations  
```
 rm -r Migrations
```
5. create new init migration (for mssql)
```
dotnet ef migrations add init
```
6. Make sure docker has at least 4GB of RAM

## License

Released under the MIT license. Copyright (c) 2017 Johan Hellgren.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.