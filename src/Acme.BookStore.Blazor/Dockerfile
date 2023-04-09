#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 59518
EXPOSE 44364

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Acme.BookStore.Blazor/Acme.BookStore.Blazor.csproj", "src/Acme.BookStore.Blazor/"]
COPY ["src/Acme.BookStore.Application/Acme.BookStore.Application.csproj", "src/Acme.BookStore.Application/"]
COPY ["src/Acme.BookStore.Domain/Acme.BookStore.Domain.csproj", "src/Acme.BookStore.Domain/"]
COPY ["src/Acme.BookStore.Domain.Shared/Acme.BookStore.Domain.Shared.csproj", "src/Acme.BookStore.Domain.Shared/"]
COPY ["src/Acme.BookStore.Application.Contracts/Acme.BookStore.Application.Contracts.csproj", "src/Acme.BookStore.Application.Contracts/"]
COPY ["src/Acme.BookStore.HttpApi/Acme.BookStore.HttpApi.csproj", "src/Acme.BookStore.HttpApi/"]
COPY ["src/Acme.BookStore.EntityFrameworkCore/Acme.BookStore.EntityFrameworkCore.csproj", "src/Acme.BookStore.EntityFrameworkCore/"]
RUN dotnet restore "src/Acme.BookStore.Blazor/Acme.BookStore.Blazor.csproj"
COPY . .
WORKDIR "/src/src/Acme.BookStore.Blazor"
RUN dotnet build "Acme.BookStore.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acme.BookStore.Blazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acme.BookStore.Blazor.dll"]