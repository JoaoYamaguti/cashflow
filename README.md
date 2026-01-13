## Sobre o Projeto

Esta API, desenvolvida utilizando **.NET 8**, adota os princípios do **Domain-Driven Design (DDD)** para oferecer uma solução estruturada e eficaz no gerenciamento de despesas pessoais. O principal objetivo é permitir que os
usuários registrem suas despesas, detalhando informações como título, data e hora, descrição, valor e tipo de pagamento, com os dados sendo armazenados de forma segura em um banco de dados **MySQL**.

A arquitetura da **API** baseia-se em **REST**, utilizando métodos **HTTP** padrão para uma comunicação eficiente e simplificada. Além disso, é complementada por uma documentação **Swagger**. que proporciona uma interface gráfica
interativa para que os desenvolvedores possam explorar e testar os endpoints de maneira fácil.

Dentre os pacotes NuGet utilizados, o **AutoMapper** é o responsável pelo mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. O **FluentAssertions** é utilizado nos
testes de unidade para tornar as verificações mais legíveis, ajudando a escrever testes claros e compreensiveis. Para as validações, o **FluentValidation** é usado para implementar regras de validação de forma simples e intuitiva
nas classes de requisições, mantendo o codigo limpo e fácil de manter. Por fim, o **EntityFramework** atua como um ORM (Object-Relational Mapper) que simplifica as interações com o banco de dados, permitindo o uso de
objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.




### Features

- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do
domínio da aplicação.
- **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a
qualidade.
- **Geraçao de Relatórios**: Capacidade de exportar relatórios detalhados para **PDF** e **Excel**,
oferecendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentacao Swagger**: Interface documentada que facilita a integracao e o
teste por parte dos desenvolvedores.

### Construido com...
![badge-joao]
![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]

Gerar badges personalizadas em [shields.io](https://shields.io/badges)

Pegar padrões de badges em [badges.pages.dev](https://badges.pages.dev)

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Linux/MacOS com [.NET SDK][dot-net-sdk] instalado
* MySql Server

### Instalação

1. Clone o repositorio: 
    ```sh
    git clone https://github.com/JoaoYamaguti/cashflow.git
    ```
2. Preencha as informações no arquivo `appsettings.Development.json`;
3. Execute a API e aproveite o seu teste; :)



<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- images -->
[hero-image]: images/heroimage.png

<!-- Badges -->
[badge-joao]: https://img.shields.io/badge/Jo%C3%A3o-black
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo-dotnet&logoColor-fff&style-for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style-for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo-visualstudio&logoColor-fff&style-for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysq1&logoColor=fff&style-for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo-swagger&logoColor-000&style-for-the-badge

