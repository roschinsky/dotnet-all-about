FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

# Copy everything
COPY . ./
# Restore and publish a release build
RUN dotnet restore && \
    dotnet build -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "dotnet-all-about.dll"]