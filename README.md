# FullStackDemo

A comprehensive full-stack web application demonstrating modern software development practices, containerization, and cloud deployment capabilities. This project showcases a complete end-to-end solution built with .NET and Angular, designed to be easily deployable to any cloud platform using Docker.

## Overview

FullStackDemo is a production-ready full-stack application that combines a robust .NET backend API with a modern Angular frontend, all orchestrated through Docker containers. The application serves as a demonstration of full-stack development expertise, featuring RESTful API design, database integration, and containerized deployment strategies.

## Architecture

### Technology Stack

**Backend:**
- **.NET 8.0** - Modern, high-performance web framework
- **ASP.NET Core Web API** - RESTful API architecture
- **Entity Framework Core 9.0** - Object-Relational Mapping (ORM) for database operations
- **SQL Server** - Relational database management system (can be configured for MySQL)
- **Swagger/OpenAPI** - API documentation and testing interface

**Frontend:**
- **Angular 15** - Modern TypeScript-based web framework
- **RxJS** - Reactive programming for asynchronous operations
- **Angular Router** - Client-side routing and navigation
- **Angular Forms** - Form handling and validation

**Infrastructure:**
- **Docker** - Containerization platform
- **Docker Compose** - Multi-container orchestration
- **Nginx** - Web server and reverse proxy (for production frontend)

## Project Structure

```
FullStackDemo/
├── FullStackDemo.Server/          # .NET Backend API
│   ├── Controllers/                # API Controllers
│   │   ├── RealEstateController.cs
│   │   ├── UsersController.cs
│   │   └── WeatherForecastController.cs
│   ├── Models/                     # Data Models and DbContext
│   │   ├── RealEstate.cs
│   │   ├── RealEstateImage.cs
│   │   ├── Users.cs
│   │   └── UserTypes.cs
│   ├── Program.cs                  # Application entry point and configuration
│   ├── appsettings.json            # Application configuration
│   └── Dockerfile                  # Backend container definition
│
├── fullstackdemo.client/           # Angular Frontend
│   ├── src/
│   │   ├── app/                    # Angular application components
│   │   ├── assets/                 # Static assets
│   │   └── index.html              # Application entry point
│   ├── package.json                # Frontend dependencies
│   ├── angular.json                # Angular configuration
│   ├── Dockerfile                  # Frontend container definition
│   └── nginx.conf                  # Nginx configuration for production
│
└── docker-compose.yml              # Multi-container orchestration
```

## Features

### Backend API

The backend provides a RESTful API with the following endpoints:

**Users Management:**
- `POST /api/Users` - Create a new user
- `GET /api/Users` - Retrieve all users

**Real Estate Management:**
- `POST /api/RealEstate` - Add a new real estate listing
- `GET /api/RealEstate` - Retrieve all real estate listings

**Weather Forecast:**
- `GET /weatherforecast` - Sample weather forecast endpoint

### Database Schema

The application uses Entity Framework Core with Code-First migrations to manage the database schema:

- **Users Table**: Stores user information including username, email, password, and creation timestamp
- **RealEstate Table**: Manages real estate listings with address, value, and type information
- **RealEstateImage Table**: Stores images associated with real estate listings
- **UserTypes Table**: Defines different user type classifications

### Frontend Application

The Angular frontend provides a modern, responsive user interface that:
- Communicates with the backend API via HTTP requests
- Implements reactive programming patterns with RxJS
- Provides a single-page application (SPA) experience
- Supports development and production builds

## Docker Deployment

### Container Architecture

The application is fully containerized using Docker, enabling seamless deployment across different environments:

1. **Backend Container** (`backend`)
   - Runs the .NET 8.0 Web API
   - Exposes ports 8080 (HTTP) and 8081 (HTTPS)
   - Connects to the database container
   - Configured with environment variables for database connection

2. **Database Container** (`db`)
   - SQL Server 2022 instance
   - Exposes port 1433 for database connections
   - Pre-configured with database initialization
   - Persistent data storage

3. **Frontend Container** (`frontend`)
   - Serves the Angular application via Nginx
   - Exposes port 4200 for web access
   - Depends on the backend container
   - Production-optimized build

### Docker Compose Network

All containers communicate through a custom bridge network (`fullstack-network`), ensuring:
- Secure inter-container communication
- Service discovery by container name
- Network isolation from other Docker networks

## Getting Started

### Prerequisites

- **Docker** (version 20.10 or later)
- **Docker Compose** (version 2.0 or later)
- **.NET 8.0 SDK** (for local development)
- **Node.js 18+** and **npm** (for local frontend development)

### Running with Docker Compose

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd FullStackDemo
   ```

2. **Start all services:**
   ```bash
   docker-compose up --build
   ```

   This command will:
   - Build all Docker images
   - Start the database container
   - Start the backend API container
   - Start the frontend container
   - Set up the network infrastructure

3. **Access the application:**
   - Frontend: http://localhost:4200
   - Backend API: http://localhost:8080
   - API Documentation (Swagger): http://localhost:8080/swagger
   - Database: localhost:1433

4. **Stop all services:**
   ```bash
   docker-compose down
   ```

### Local Development

**Backend Development:**
```bash
cd FullStackDemo.Server
dotnet restore
dotnet run
```

**Frontend Development:**
```bash
cd fullstackdemo.client
npm install
npm start
```

## Configuration

### Environment Variables

The application uses environment variables for configuration:

- **ConnectionStrings__DefaultConnection**: Database connection string
- **SA_PASSWORD**: SQL Server administrator password
- **ACCEPT_EULA**: SQL Server license acceptance

### Database Connection

The connection string is configured in `appsettings.json` and can be overridden via environment variables in `docker-compose.yml`. The default configuration connects to the SQL Server container using:
- Server: `db` (container name)
- Database: `FullStackDemoDB`
- Authentication: SQL Server Authentication

**Note:** For production deployments, ensure you:
- Change default passwords
- Use secure connection strings
- Enable SSL/TLS for database connections
- Configure proper firewall rules

## Cloud Deployment

This application is designed for seamless cloud deployment. The Docker containerization approach allows deployment to any cloud platform that supports Docker, including:

- **Azure Container Instances (ACI)**
- **Azure App Service**
- **AWS Elastic Container Service (ECS)**
- **AWS Fargate**
- **Google Cloud Run**
- **Kubernetes** (any cloud provider)
- **Docker Swarm**

### Deployment Considerations

1. **Database**: For production, consider using managed database services (Azure SQL Database, AWS RDS, etc.) instead of containerized databases
2. **Environment Variables**: Use cloud-specific secret management services
3. **Scaling**: Configure horizontal scaling based on traffic requirements
4. **Monitoring**: Integrate application monitoring and logging services
5. **SSL/TLS**: Configure HTTPS endpoints and certificates
6. **Load Balancing**: Set up load balancers for high availability

## Development Practices Demonstrated

- **Separation of Concerns**: Clear separation between frontend, backend, and database layers
- **RESTful API Design**: Standard HTTP methods and status codes
- **Entity Framework Core**: Code-First database migrations and ORM patterns
- **Dependency Injection**: Built-in .NET dependency injection container
- **Containerization**: Docker-based deployment for consistency across environments
- **API Documentation**: Swagger/OpenAPI integration for API exploration
- **Type Safety**: TypeScript in frontend, C# in backend
- **Modern Web Standards**: Angular framework with reactive programming

## API Documentation

When running in development mode, the API documentation is available via Swagger UI at:
```
http://localhost:8080/swagger
```

This interactive documentation allows you to:
- Explore all available endpoints
- Test API calls directly from the browser
- View request/response schemas
- Understand authentication requirements

## Future Enhancements

Potential areas for expansion:
- User authentication and authorization (JWT tokens)
- File upload functionality for real estate images
- Advanced search and filtering capabilities
- Pagination for large datasets
- Caching strategies for improved performance
- Unit and integration testing
- CI/CD pipeline integration
- Real-time updates using SignalR

## License

[Specify your license here]

## Contributing

[Add contribution guidelines if applicable]

## Contact

[Add contact information if desired]
