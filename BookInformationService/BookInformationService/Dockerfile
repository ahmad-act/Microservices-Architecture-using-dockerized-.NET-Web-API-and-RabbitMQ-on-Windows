# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copy the build output from the build stage
COPY --from=build-env /App/out .

# Copy the SQLite database file
# Assuming your SQLite database file is named 'app.db' and located in the root of your project
COPY BookInformations.db /App/out/BookInformations.db

# Use a build argument to set the environment variable
ARG ENVIRONMENT=Production
ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT}

# Expose port
EXPOSE 80

ENTRYPOINT ["dotnet", "BookInformationService.dll"]
