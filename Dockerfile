FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /HelloWorldV2

# Copy everything and restore as distinct layers
COPY . ./
RUN dotnet restore

# Build and publish the application
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /HelloWorldV2/out

# Set the entry point for the application
ENTRYPOINT ["dotnet", "HelloWorldV2.dll"]