# Chat History Aggregator

This project is a chat room interface in which user can view chat history at varying levels of time based aggregations. This project is a Web API and aggregation endpoint is described below. The project uses a SQLite DB, data for which is seeded in the start of the application from a JSON file. 

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
The endpoint exposed accepts two aggregation granularity levels, 'hourly' and 'minutes'. The endpoint can be used as follows: 

- /ChatHistory?granularity=minutes
- /ChatHistory?granularity=hourly

## Exception Handling
Any other granularity level other than hourly or minutes will return an exception. **Exception handling is done by adding a middleware.** 

## Architecture
A layered architecture is designed for this application. The high level archtecture diagram is as follows: 
![alt text](https://github.com/SyedShahbaz/chat-history-aggregator/blob/master/Architecture.png?raw=true)
