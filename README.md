# Chat History Aggregator

This project is a chat room interface in which user can view chat history at varying levels of time based aggregations. This project is a Web API and aggregation endpoints are described below. The project used a SQLite DB, data for which is seeded in the start of the application from a JSON file. 

## Technologies 
- .NET6 
- Entity Framework 
- SQLite 
- SwaggerGen
- Web API
- MOQ Unit Tests

## Pre-requisites
- Installation of .NET6 and any C# editor (preferably VSCode, Rider or Visual Studio)

## Endpoints
The endpoint exposed accepts two aggregation granularity levels, 'hourly' and 'minutes'. Any other value will return an exception. The endpoint can be used as follows: 

- /ChatHistory?granularity=minutes
- /ChatHistory?granularity=hourly

# Architecture
A high level archtecture diagram is as follows: 
![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)


