# GraphQL Coffee Shop Demo

This repository contains a simple coffee shop application demonstrating GraphQL with a .NET backend and a React frontend.

## Technologies Used

### Backend

- .NET: Backend is built with .NET.
- HotChocolate: Used as the GraphQL server.
- Entity Framework Core
- SQL Server

### Frontend

- React + TypeScript + Vite: Frontend bootstrapped with the Vite template.
- GraphQL Code Generator: Generates TypeScript types and GraphQL operations.
- Apollo Client: Manages GraphQL queries and caching.
- Chakra UI: Component library for styling.

### Presentation

- Slidev: Used to create presentation slides about the project.

## Getting Started

### Backend Setup

1. In the root folder restore dependencies
```bash
dotnet restore
```
2. Update `appsettings.json` or project user secrets with your SQL Server connection string
3. Run the application
```bash
dotnet run
```
5. The GraphQL playground is available at `http://localhost:5266/graphql/`

### Frontend Setup

1. Navigate to the frontend folder and install dependencies
```bash
cd web
yarn
```
2. Start the frontend application
```bash
yarn dev
```
3. The frontend should be available at `http://localhost:3000`

> [!NOTE]
> GraphQL Codegen runs as a `predev`-script so this will throw an error if the backend is not running when starting the frontend application

### Slides Setup

1. Navigate to the `slidev` folder and install dependencies
```bash
cd slidev
yarn
```
2. To view the slides run `yarn dev`
