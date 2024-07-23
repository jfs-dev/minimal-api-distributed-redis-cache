# minimal-api-distributed-redis-cache
Implementando cache distribuído usando Redis e Docker em uma Minimal API com C#

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![Redis](https://img.shields.io/badge/redis-%23DD0031.svg?style=for-the-badge&logo=redis&logoColor=white)

## Sobre o projeto
Este projeto mostra como implementar cache distribuído usando Redis e Docker em uma Minimal API com C#.

O cache distribuído permite que vários servidores compartilhem um cache comum, o que é útil em cenários de alta disponibilidade e escalabilidade.

O Redis é um armazenamento de dados em memória de código aberto, usado como banco de dados, cache e agente de mensagens.

O .NET fornece implementações para vários provedores de cache distribuído além do Redis, como SQL Server e NCache.

<div align="center">
    <img src="https://github.com/user-attachments/assets/97ff1815-ea35-42ce-8e24-9f6bbacd9935"</img>
    <img src="https://github.com/user-attachments/assets/4c84fdac-9165-4761-a23f-94672c5de3b2"</img>
</div>

Com o Docker Desktop instalado no Windows + WSL habilitado, siga os seguintes passos através do CLI:

1. Obter a imagem do Redis através do comando: <code>docker pull redis</code>

2. Configurar e executar o Redis através do comando: <code>docker run –-name redis -p 6379:6379 -d redis</code>

<div align="center">
    <img src="https://github.com/user-attachments/assets/0ab54f5d-276e-4b54-9a4e-3caf5cc369f9"</img>
</div>

## Referências
https://learn.microsoft.com/en-us/aspnet/core/performance/caching/overview?view=aspnetcore-9.0

https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-9.0

https://www.docker.com/

https://hub.docker.com/

## Licença
GPL-3.0 license
