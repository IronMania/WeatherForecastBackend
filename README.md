# WeatherForecastBackend

TestApp für AppsFactory

## Requirements
- Node.js
- .NET Core 2.1

## Development

### Configuration

please configure the Backend url //TODO. make backend url configurable

### Run frontend
``` 
cd src/Frontend 
npm run serve    
```

### Run backend
```
cd src/WebApi/WebApi
dotnet run
```

## Task
Your task, should you choose to accept it, is to create a small web frontend. On a simple ASP.NET Core website you should display a forecast of the next 5 days and the current weather data for any location. The desired location must be able to be changed by the user via an input mask either by means of postal code or place name. It is sufficient if only cities of the Federal Republic of Germany can be queried. Use metric information for illustration.
There are tons of methods on OpenWeathermap, please concentrate on the following scenario: 

- user enters a (german) city into a search field, or a zipCode

- if city is unknown, a proper error message should be shown

- create an api endpoint GET /api/weather/forecast?city=[cityName] with

- it should return your own json payload containing the data of aggregated results per day for today and the next 5 days, only containing temperature, humidity and windspeed

- show that data (temperature/humidity/windspeed) in a pleasant form

- persist the query history in the backend via EF Core, and let the user have access to this query history in the frontend

 If you need an API key to authenticate, use the following: ****

For the technical requirements: 

1. You should implement the frontend separately with Javascript (or Typescript). Please use Vue.js for the frontend, because it's our stack at APPSfactory, it's easy to get started, see https://cli.vuejs.org/guide/creating-a-project.html . Please use the new vue cli 3 for creating the project (important!). You should use VS code and the vetur extension for a productive experience with single file components. , but that's just a recommendation; make sure you read the SFC docs at https://vuejs.org/v2/guide/single-file-components.html

2. The javascript shouldn't query an external weather data provider directly, but instead query your own AspNet Core (MVC) JSON endpoint, which in turn should query from OpenWeathermap.

3. to be clear: Asp.Net Core should be used only for the API, not any significant serverside rendering (via Razor). We want you to create the frontend with vue.js completely, and Asp.Net Core just as an API. 

It is OK if you send us two separate folders, one with the vue.js frontend project and one with the C# backend project, you don't have to try and marry vue.js with Asp.Net Core in one VS project.

So in the end we would run two things in the end: the frontend project via npm run serve, and the backend C# Asp.Net Core project via dotnet run, and by browsing to the npm run serve address (probably localhost:8080) the site should work as described above.

Regarding visual quality: CSS frameworks like e.g. Bootstrap or Material-design focused frameworks can be used, but custom CSS is also allowed, even encouraged, if you think it adds to the quality.  