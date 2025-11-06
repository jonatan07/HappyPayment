# HappyPayment 💳 
 
API de prueba para evaluar las capacidades del proveedor CyberSource usando buenas practica como arquitectura limpia, CQRS, DDD entre otras

## 📚 Tabla de Contenido
1. [Descripción](#-descripción)
2. [Arquitectura](#-arquitectura)
3. [Requisitos](#-requisitos)
4. [Instalación](#-instalación)
5. [Configuración](#-configuración)
6. [Uso](#-uso)
7. [Contribuciones](#-contribuciones)
8. [Licencia](#-licencia)

## 🧩 Descripción
HappyPayment es un API de pagos que permite realizar pagos con el proveedor CyberSource
mediante una arquitectura basada en microservicios, colas (RabbitMQ) y DDD.

## 🏗️ Arquitectura
- **Backend:** .NET 8, Clean Architecture, CQRS, Mediator, EF Core
- **Mensajería:** RabbitMQ
- **Infraestructura:** Docker, Azure Key Vault o Vault
- **Autenticación:** Keycloak + OAuth2
- **Base de datos:** PostgreSQL
- **Logs / Tracing:** Serilog + OpenTelemetry + Jaeger

## 📝 Licencia
Este proyecto está bajo la licencia MIT — ver [LICENSE](LICENSE) para más detalles.

## 👤 Autor
**Jonatan Delgado Valdez**  
💼 Solution Architect / .NET Specialist  
📧 jonatan.dev@example.com  
🌐 [LinkedIn](https://linkedin.com/in/jonatan-delgado-valdez) | [GitHub](https://github.com/jonatan07)

