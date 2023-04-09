# ProcessadorTxtSqlserver
Monitoramento de pasta e processamento de arquivo txt para banco de dados sql server

Aplicação Console para Processamento de Arquivos de Texto
Este repositório contém uma aplicação console desenvolvida em C# com o intuito de processar dados de arquivos texto e inseri-los em um banco de dados SQL Server. A aplicação segue um padrão de layout de uma tabela específica, descrito abaixo.

tabela usado para desenvolvimento a tabela de produtos.

Exemplo:
Layout da Tabela
A tabela que será preenchida pela aplicação possui as seguintes colunas:

ID (int, identity, not null)
Nome (varchar(100), not null)
Sobrenome (varchar(100), not null)
Data de Nascimento (date, not null)
CPF (varchar(14), not null)
RG (varchar(20), not null)
Endereço (varchar(200), not null)
Funcionamento
A aplicação console processa arquivos de texto com o seguinte padrão:

Cada linha do arquivo representa uma pessoa com informações separadas por vírgulas.
As informações são organizadas na seguinte ordem: nome, sobrenome, data de nascimento, CPF, RG e endereço.
A aplicação lê o arquivo de texto e insere cada registro na tabela especificada, utilizando as informações contidas em cada linha do arquivo. O processo é realizado de forma transacional, garantindo que todos os registros sejam inseridos com sucesso ou nenhum seja inserido caso ocorra algum erro.

Tecnologias Utilizadas
As seguintes tecnologias foram utilizadas para desenvolver esta aplicação:

C# como linguagem de programação.
.NET Framework como plataforma de desenvolvimento.
SQL Server como banco de dados relacional.
Como Executar a Aplicação
Para executar a aplicação, siga os seguintes passos:

Clone este repositório em seu computador usando o comando git clone https://github.com/leandrosantos2018/ProcessadorTxtSqlserver.git.
Abra o arquivo App.config e altere a string de conexão do banco de dados para a sua própria conexão com o SQL Server.
Crie uma tabela com as colunas especificadas acima no banco de dados especificado na string de conexão.
Abra o arquivo Program.cs e altere o caminho do arquivo de texto para o caminho do arquivo que você deseja processar.
Abra o terminal e navegue até o diretório do projeto.
Execute o comando dotnet run para iniciar a aplicação.
Com a aplicação em execução, o arquivo de texto será processado e os registros serão inseridos na tabela especificada. Certifique-se de que o arquivo de texto segue o padrão descrito acima.

Conclusão
Este projeto é uma aplicação console desenvolvida em C# que permite processar arquivos de texto e inseri-los em um banco de dados SQL Server seguindo um padrão de layout de tabela específico. Utilizando tecnologias como C# e .NET Framework, a aplicação oferece um exemplo prático de como desenvolver soluções para processamento de dados em larga escala. Esperamos que este repositório seja útil para a sua aprendizagem em desenvolvimento de aplicações console com C#.
