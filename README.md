# Movies API with .NET 8, Docker Compose, Redis, and PostgreSQL

This project is a sample ASP.NET Core Web API that demonstrates a Movies API using Docker, Redis, and PostgreSQL for containerized development. The application utilizes PostgreSQL as its primary database and Redis for caching, providing a robust foundation for scalable web Apis.

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
1.  Add a Movie: Send a POST request to /api/movies.
    - Example: To create a new movie, use the following 
        ```sh
            curl --location 'https://localhost:7062/api/movies' \
            --header 'Content-Type: application/json' \
            --data '{
                "title": "Inception",
                "genre": "Sci-Fi",
                "releaseDate": "2024-07-18T00:00:00Z",
                "director": "Christopher Nolan",
                "rating": 8.8,
                "synopsis": "A thief who steals corporate secrets through the use of dream-sharing technology."
            }'
        ```
2. Get Movies: Send a GET request to /api/movies.
3. Update a Movie: Send a PUT request to /api/movies/{id}.
4. Delete a Movie: Send a DELETE request to /api/movies/{id}.

### Contributing
Contributions are welcome! Fork this repository and submit a pull request for any enhancements or bug fixes.

### License
This project is licensed under the MIT License. See the LICENSE file for details.        