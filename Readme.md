# Gestão RH - Projeto .NET

Este projeto é uma API para o sistema de gestão de recursos humanos, que utiliza a arquitetura limpa (Clean Architecture) e o banco de dados PostgreSQL. Ele foi desenvolvido utilizando .NET Core.

## Estrutura de Pastas

A estrutura de pastas do projeto segue a arquitetura limpa (Clean Architecture) para garantir a separação das responsabilidades e facilitar a manutenção e escalabilidade do código.


## /Api
- **Controllers**
  - `UsuarioController.cs`
  - `DocumentoController.cs`
- **Dtos**
  - `UsuarioDto.cs`
  - `EnderecoDto.cs`
  - `DocumentoDto.cs`

## /Application
- **Dtos**
  - `DocumentosDto.cs`
  - `EmpresaDto.cs`
  - `EnderecoDto.cs`
  - `PerfilUsuarioDto.cs`
  - `UsuarioDto.cs`
- **Interfaces**
  - `IUsuarioService.cs`
  - `IDocumentoService.cs`
- **Services**
  - `UsuarioService.cs`
  - `DocumentoService.cs`
- **Mappings**
  - `UsuarioMapping.cs`
  - `DocumentoMapping.cs`

## /Domain
- **Entities**
  - `Usuario.cs`
  - `Endereco.cs`
  - `Documento.cs`
- **Interfaces**
  - `IUsuarioRepository.cs`
  - `IDocumentoRepository.cs`

## /Infrastructure
- **Data**
  - `GestaoRhContext.cs`
- **Repositories**
  - `UsuarioRepository.cs`
  - `DocumentoRepository.cs`
 

## Pré-requisitos

Para rodar o projeto, você precisará dos seguintes pré-requisitos:

1. **.NET SDK 8.0 ou superior**: Certifique-se de ter o .NET SDK instalado em sua máquina. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download).
2. **PostgreSQL**: A aplicação utiliza o PostgreSQL como banco de dados. Você precisará ter o Docker instalado para rodar o banco de dados em um container.

### Ferramentas Necessárias

- **dotnet-ef**: Para rodar as migrations e interagir com o banco de dados. Instale a ferramenta globalmente com o seguinte comando:

    ```bash
    dotnet tool install --global dotnet-ef

- **PostgreSQL**: Abra o terminal e execute o seguinte comando para rodar o PostgreSQL em um container Docker, ele vai criar o banco e subir na sua maquina:

    ```bash
    docker run --name gestao-rh -e POSTGRES_USER=gestaorh -e POSTGRES_PASSWORD=gestaorh123 -e POSTGRES_DB=gestaorh -p 5432:5432 -d postgres:17

- **Rodar as migrações (aplicar as alterações no banco de dados):**: Para aplicar todas as migrações criadas, use o comando abaixo:

    ```bash
    dotnet ef database update --context GestaoRhContext
