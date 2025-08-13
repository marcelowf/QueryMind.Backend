# QueryMind Backend

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/) [![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=for-the-badge&logo=mongodb&logoColor=white)](https://www.mongodb.com/) [![GraphQL](https://img.shields.io/badge/GraphQL-E10098?style=for-the-badge&logo=graphql&logoColor=white)](https://graphql.org/) [![Terraform](https://img.shields.io/badge/Terraform-623CE4?style=for-the-badge&logo=terraform&logoColor=white)](https://www.terraform.io/) [![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/) [![Redis](https://img.shields.io/badge/Redis-FF4438?style=for-the-badge&logo=redis&logoColor=white)](https://redis.io/) [![Azure](https://img.shields.io/badge/Azure-0078D4?style=for-the-badge&logo=&logoColor=white)](https://azure.microsoft.com/) [![Azure DevOps](https://img.shields.io/badge/Azure%20DevOps-0078D7?style=for-the-badge&logo=&logoColor=white)](https://azure.microsoft.com/services/devops/) [![Cucumber](https://img.shields.io/badge/Cucumber-23D96C?style=for-the-badge&logo=cucumber&logoColor=white)](https://cucumber.io/) [![SonarAnalyzer](https://img.shields.io/badge/SonarAnalyzer-c42423?style=for-the-badge&logo=sonarqubeserver&logoColor=white)](https://docs.sonarsource.com/sonaranalyzer/latest/) [![OpenTelemetry](https://img.shields.io/badge/OpenTelemetry-0072CE?style=for-the-badge&logo=opentelemetry&logoColor=white)](https://opentelemetry.io/) [![Prometheus](https://img.shields.io/badge/Prometheus-E6522C?style=for-the-badge&logo=prometheus&logoColor=white)](https://prometheus.io/) [![Grafana](https://img.shields.io/badge/Grafana-F46800?style=for-the-badge&logo=grafana&logoColor=white)](https://grafana.com/) [![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)](https://git-scm.com/)

### 🚀 **Sobre o Projeto**

---

#### 🔧 Pré-requisitos

- .NET SDK 8.0
- Docker e Docker Compose
- Azure CLI
- Acesso a uma assinatura Azure
- Git

---

## ⚙️ Configuração do Ambiente

Siga estes passos para configurar seu ambiente de desenvolvimento:

1. **Clonar repositório:**
    Clone este repositório em sua máquina local.
2. **Variáveis de Ambiente / Secrets:**
    No projeto QueryMind.Presentation, edite o arquivo appsettings.json para configurar as variáveis necessárias, como strings de conexão e chaves de serviços externos. Alternativamente, você pode modificar as referências ao Azure Key Vault.

---

#### 📌 **Como Rodar o Projeto**

##### ➡️ **Executando Localmente**

```bash
cd QueryMind.Presentation
dotnet run
```

##### 🐳 Executando com Docker

```bash
docker-compose up
```

##### 🧪 Executando os Testes

```bash
dotnet test
```

---

#### 🧰 CI/CD

O QueryMind utiliza Azure DevOps Pipelines para automatizar o processo de CI/CD usando os arquivos yml localizados em Configuration.AzureDevOps/

---

#### 📝 Licença

Este projeto está sob a licença MIT. Consulte o arquivo LICENSE para mais detalhes.

#### 👤 Autores e Contato

LinkedIn: [Marcelo Wzorek Filho](https://www.linkedin.com/in/marcelo-wzorek-filho-132228255/)
E-mail: <marcelo.projects.dev@gmail.com>
GitHub: [marcelowf](https://github.com/marcelowf)

#### 🏷️ Tags

`AI` `.NET` `MongoDB` `GraphQL` `Terraform` `Automação` `Azure` `DDD` `Docker` `Terraform` `Prometheus` `Grafana` `Swagger` `CI/CD` `xUnit` `Cucumber` `SonarAnalyzer` `OpenTelemetry`
