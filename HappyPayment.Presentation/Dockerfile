# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de proyecto y restaura dependencias
COPY ["HappyPayment.Presentation/HappyPayment.Presentation.csproj", "HappyPayment.Presentation/"]
COPY ["HappyPayment.Application/HappyPayment.Application.csproj", "HappyPayment.Application/"]
COPY ["HappyPayment.Domain/HappyPayment.Domain.csproj", "HappyPayment.Domain/"]
COPY ["HappyPayment.Infrastructure/HappyPayment.Infrastructure.csproj", "HappyPayment.Infrastructure/"]
RUN dotnet restore "HappyPayment.Presentation/HappyPayment.Presentation.csproj"

# Copia el resto del código y publica
COPY . .
WORKDIR /src/HappyPayment.Presentation
RUN dotnet publish -c Release -o /app/publish --no-restore --no-self-contained

# Etapa final: solo runtime, imagen ligera
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "HappyPayment.Presentation.dll"]
