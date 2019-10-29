Feature: ApiStarWars
Criando testes de api StarWars

@Cenario People deve retornar Luke Skywalker
Scenario: 01_Case test StarWars ApiPeople
When passo o id da pessoa '1'
Then recebo o nome da pessoa 'Luke Skywalker'

@Cenario People deve retornar C-3PO
Scenario: 02_Case test StarWars ApiPeoples
When passo o id da pessoa '2'
Then recebo o nome da pessoa 'C-3PO'

@Cenario Planets deve retornar Tatooine
Scenario: 03_Case test StarWars ApiPlanets
When passo o id do planeta '1'
Then recebo o nome do planeta 'Tatooine'

@Cenario Planets deve retornar Alderaan
Scenario: 04_Case test StarWars ApiPlanets
When passo o id do planeta '2'
Then recebo o nome do planeta 'Alderaan'

@Cenario Species deve retornar Human
Scenario: 05_Case test StarWars ApiSpecies
When passo o id da especie '1'
Then recebo o nome da especie 'Human'

@Cenario Species deve retornar Droid
Scenario: 06_Case test StarWars ApiSpecies
When passo o id da especie '2'
Then recebo o nome da especie 'Droid'

@Cenario Starships deve retornar CR90 corvette
Scenario: 07_Case test StarWars ApiStarships
When passo o id do starships '2'
Then recebo o nome do starships 'CR90 corvette'

@Cenario Starships deve retornar Star Destroyer
Scenario: 08_Case test StarWars ApiStarships
When passo o id do starships '3'
Then recebo o nome do starships 'Star Destroyer'