# TechNation Dashboard

Este é um projeto de dashboard desenvolvido utilizando ASP.NET Core e Bootstrap, com foco em exibir informações de notas fiscais emitidas, incluindo gráficos de evolução da inadimplência e receita, além de filtros dinâmicos para pesquisa e paginação.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para desenvolvimento de aplicações web.
- **Bootstrap**: Framework CSS para estilização e responsividade.
- **Chart.js**: Biblioteca JavaScript para criação de gráficos.
- **Entity Framework Core**: ORM para manipulação de dados no banco de dados.

## Funcionalidades

- **Dashboard**: Exibição de indicadores financeiros em formato de círculo.
- **Gráficos**: Exibição da evolução da inadimplência e receita ao longo dos meses.
- **Filtros Dinâmicos**: Filtros para pesquisa por mês de emissão, ano de emissão e status das notas fiscais.
- **Paginação**: Paginação das notas fiscais emitidas.
- **Sidebar**: Menu lateral responsivo com opção de ocultar/exibir.
- **Barra Superior**: Barra de navegação com busca e ícone de usuário.

## Estrutura do Projeto

TechNationDashboard/
│
├── Controllers/
│ ├── DashboardController.cs
│ ├── HomeController.cs
│ └── NotasFiscaisController.cs
│
├── Data/
│ ├── ApplicationDbContext.cs
│ └── ApplicationDbInitializer.cs
│
├── Entities/
│ └── NotaFiscal.cs
│
├── Migrations/
│
├── Models/
│ └── NotaFiscalViewModel.cs
│
├── Repositories/
│ ├── INotaFiscalRepository.cs
│ └── NotaFiscalRepository.cs
│
├── Services/
│ ├── INotaFiscalService.cs
│ └── NotaFiscalService.cs
│
├── ViewModels/
│ └── DashboardViewModel.cs
│
├── Views/
│ ├── Dashboard/
│ │ └── Index.cshtml
│ ├── Home/
│ │ └── Index.cshtml
│ ├── NotasFiscais/
│ │ └── Index.cshtml
│ └── Shared/
│ └── _Layout.cshtml
│
├── wwwroot/
│ ├── css/
│ │ └── site.css
│ └── js/
│ └── site.js
│
└── TechNationDashboard.csproj


## Configuração e Execução do Projeto

1. **Clone o repositório:**
    ```sh
    git clone https://github.com/juniomatias01/TechNationDashboard.git
    ```

2. **Navegue até o diretório do projeto:**
    ```sh
    cd technation-dashboard
    ```

3. **Instale as dependências:**
    ```sh
    dotnet restore
    ```

4. **Configure o banco de dados:**
    - Certifique-se de que o SQL Server está rodando.
    - Atualize a string de conexão no arquivo `appsettings.json`.
    - Execute as migrações para criar o banco de dados:
      ```sh
      dotnet ef database update
      ```

5. **Execute o projeto:**
    ```sh
    dotnet run
    ```

6. **Acesse a aplicação:**
    - Abra o navegador e vá para `http://localhost:5000`.

## Executando com Docker

1. **Construir a imagem Docker:**
    ```sh
    docker-compose build
    ```

2. **Iniciar os containers:**
    ```sh
    docker-compose up
    ```

3. **Acesse a aplicação:**
    - Abra o navegador e vá para `http://localhost:8080`.

## Uso

### Filtros

- Utilize os filtros na parte superior da tela para filtrar as notas fiscais por mês de emissão, ano de emissão e status.

### Paginação

- Utilize os botões de paginação na parte inferior da tabela para navegar pelas notas fiscais emitidas.

### Ocultar/Exibir Menu Lateral

- Clique no ícone de hambúrguer na barra superior para ocultar ou exibir o menu lateral.

