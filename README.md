# Movies API with Docker, Redis, and PostgreSQL

This project is a sample ASP.NET Core Web API that demonstrates a Movies API using Docker, Redis, and PostgreSQL for containerized development.

## Technologies Used
- **ASP.NET Core Web API**
- **Docker & Docker Compose**
- **Redis** (for caching)
- **PostgreSQL** (for database)
- **EF Core**

## Getting Started

### Prerequisites
To run this project locally, you'll need to have the following installed:
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Setup and Installation
1. Clone the repo
    ```bash
    git clone https://github.com/ajaybhalerao12/movies-api-docker-compose-redis-postgresql.git
    cd movies-api-docker-compose-redis-postgresql
2. Navigate to the project directory
   ```sh
   cd movies-api-docker-compose-redis-postgresql
   ```
3. Build and run the application:
   ```sh
   docker-compose up --build
4. Access the API:
    - The API will be available at http://localhost:5000/api/movies. 

### Usage
    - Add a Movie: Send a POST request to /api/movies.
    - Get Movies: Send a GET request to /api/movies.
    - Update a Movie: Send a PUT request to /api/movies/{id}.
    - Delete a Movie: Send a DELETE request to /api/movies/{id}.

### Contributing
Contributions are welcome! Fork this repository and submit a pull request for any enhancements or bug fixes.

### License
This project is licensed under the MIT License. See the LICENSE file for details.        