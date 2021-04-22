# Olá pessoas, tudo bem?👋

##### Desta vez eu trago para vocês meu segundo projeto utilizando C#.

Este é um dos projetos que fazem parte do **Bootcamp LocalizaLabs .NET** da **Digital Innovation One**, chamdo de **Criando um APP simples de cadastro de séries em .NET**

Trata-se de um programa simples em console que permite cadastrar, listar, visualizar, atualizar e excluir séries.

Este foi um projeto interessante pois usamos algumas camadas e uma interface para implementar os métodos e tornar o código mais organizado e com alta manutenibilidade.

A classe EntidadeBase é uma classe abstrata que possui o atributo identificador das séries.

A classe Série é uma subclasse da class EntidadeBase e contém os atributos das séries e alguns métodos para retorná-los.

O enum Genero contém os gêneros das séries.

A classe SerieRepositorio, como o nome já indica, serve como um repositório para armazenar as séries inseridas. Essa classe é formada por uma List<Serie> e implementa os métodos da interface IRepositorio, que possibilitam toda a manipulaçao de dados.

Por fim, mas não menos importante, a classe Program, que contém um menu com as funcionalidades que permitem o acesso aos métodos das outras classes.

Fiz algumas alterações em relação ao trabalho feito pelo instrutor [Eliézer Zarpelão](https://github.com/elizarp), à quem agradeço muito pelos ensinamentos, adicionado funcionalides para converter string em int, verificar se já há séries inseridas e confirmar a exclusão de séries

Agradeço muito à [**Digital Innovation One**](https://digitalinnovation.one/) pelo conteúdo e por esta oportunidade de aprendizado.

