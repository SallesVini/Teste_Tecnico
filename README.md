# Teste Técnico Desenvolvimento de Sistemas

### Respostas às Perguntas do Exercício


### Como você armazenaria esses dados se fosse necessário

Se fosse necessário persistir os dados, eu criaria models para as entidades (Users e Posts) e depois conectaria essas models ao Entity Framework, criando um DbContext que representa a conexão com o banco de dados. Em seguida, geraria as migrations para criar as tabelas correspondentes, permitindo armazenar localmente os dados da API de forma organizada e consistente.

Observação: para este teste técnico não é necessário persistir dados, então os dados são consumidos apenas da API externa.


### Como a API externa é consumida

A API externa é consumida pelo backend (.NET) utilizando HttpClient.

O backend faz requisições para:

https://jsonplaceholder.typicode.com/users

https://jsonplaceholder.typicode.com/posts?userId={id}

As respostas são mapeadas para DTOs próprios, garantindo que o frontend receba apenas os dados necessários de forma estruturada.


### Onde o erro é tratado

O tratamento de erros acontece principalmente nos services, onde estão as lógicas de negócio e chamadas externas.

Erros esperados ou previsíveis (como API indisponível ou 404) são tratados nos services.

Erros inesperados (como 500) podem ser capturados no controller para retornar uma resposta HTTP padronizada ao frontend.

No Angular, qualquer mensagem de erro retornada é exibida ao usuário e o estado de loading é removido.


### O que faria diferente com mais tempo

Implementaria autenticação e autorização para controlar acesso aos dados.

Criaria migrations para gerar tabelas no banco de dados a partir das models.

Criaria um DataMap mais elaborado para mapear corretamente as entidades e suas relações.

Implementaria cache no backend para reduzir requisições desnecessárias.

Adicionaria paginação ou lazy loading para os posts.

Criaria testes unitários e de integração para backend e frontend.

Melhoraria o tratamento de erros, detalhando códigos específicos e mensagens mais informativas no frontend.


### Perguntas da Entrevista

### O que acontece se a API retornar erro 500?
O backend captura a exceção e retorna um erro controlado. Isso evita que a aplicação quebre e permite exibir uma mensagem amigável ao usuário.

### Por que não consumir a API diretamente no Angular?
Consumir diretamente no frontend expõe a URL da API externa e a lógica de tratamento de erros. Centralizar no backend permite:

Controle de acesso e segurança

Validação e mapeamento de DTOs

Redução da dependência do cliente em uma API externa

### Como você testaria essa funcionalidade?

Backend: testes unitários para os métodos que consomem a API e mapeamento DTO, além de testes de integração simulando respostas da API externa (mock).

Frontend: testes de componentes Angular para verificar exibição de usuários, posts, estados de loading e mensagens de erro.
