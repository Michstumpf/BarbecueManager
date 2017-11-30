# BarbecueManager

Executar os scripts de banco para criar a base e as tabelas:
 - 01-Create_DataBase_BarbecueManager.sql
 - 02-Create_Table_Barbecue.sql
 - 03-Create_Table_Participant.sql
 
Criar uma variavel de ambiente com o nome "BARBECUE_MANAGER_CONNECTION_STRING" e colocar a ConnectionString correspondente ao banco de dados criado no passo anterior.
	* Esta variavel de ambiente também está disponível nas propriedades do projeto da API, no arquivo "docker-compose.lb.yml" correspondente ao microsserviço com a stack necessária (Redis e LoadBalance com haproxy).
	
Para executar:
 - Você pode utilizar o VisualStudio e rodar o projeto *BarbecueManager.Api*.
 - Você pode gerar uma nova imagem do docker com os seguintes comandos:
	1. - "docker-compose -f docker-compose.ci.build.yml up -d"
	2. - "docker-compose -f docker-compose.lb.yml build -d"
	3. - "docker-compose -f docker-compose.lb.yml up -d"
	
Let's make a barbecue!