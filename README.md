# Lista de Exercícios de Programação Orientada a Objetos em C# 👨🏻‍💻




## Estrutura do Projeto
As aplicações foram desenvolvidas em C# com estrutura de destino para .NET 8.0



## Autor

- [@andreluiz1906](https://github.com/andreluiz1906)


## Exercício 01 - DesafiosOrientacaoObjetos
### InterfaceVsClasseAbstrata
Este projeto exemplifica a diferença entre a utilização de Interface e classe Abstrata. 
As interfaces vinculadas a esse projeto são:
- IConta: possui a declaração do método para abrir conta em uma instituição bancária;
- IMovimentacaoConta: Possui as declarações para depositar e sacar valores da conta;

A classe abstrata Conta, implementa as interfaces IConta e IMovimentacaoConta, além do método abstrato para consultar saldo

As classes ContaCorrente e ContaPoupança herdam da classe abstrata Conta e implementam o método de consultar saldo.


### HerancaVsDelegacao
Mostra a diferença na utilização entre Herança e Delegação.
Para o conceito de herança foi implementado:
- Classe Abstrata: Animal, com os atributos de nome e raça e os métodos de comer e dormir
- As classes Gato e Cachorro herdam de Animal e implementam métodos próprios (Gato: método Miar e Cachorro: método Latir)

O exemplo de utilização de delegação implementa:
- Classe Motor: Método Ligar e Desligar
- Classe Carro: atributo Motor e métodos AcelerarCarro e DesligarCarro


## Exercício 02 - CalculoFormulaMagica
Neste projeto, é apresentado o método para calcular o valor de venda de um item específico, utilizando uma biblioteca com uma função denominada formulaMagica. Essa função recebe os parâmetros de custo e dias de validade do item em questão.


## Exercício 03 - PlanejamentoEleitoral
Neste projeto, é desenvolvida uma rota de visitas para políticos com base no número de eleitores por rua cadastrada. Os resultados são apresentados em ordem decrescente de eleitores, proporcionando uma sugestão eficiente de roteiro.


## Exercício 04 - TratamentoDeExcecoes
Neste projeto, são apresentadas várias implementações de tipos específicos de exceções estendidas da classe Exception.


## Exercício 05 - EventoDeRecorrencia
Neste projeto, é implementado um modelo de evento de recorrência para um web service de movimentação de saldo em uma conta bancária, incluindo uma sugestão de bloqueio da conta durante a dedução do saldo.


## Exercício 06 - Banco de Dados - Montagem de Kit de vendas
Este projeto inclui os arquivos necessários para criar e popular os dados em um banco MySQL, juntamente com o modelo EER desse banco. Além disso, disponibiliza o comando SQL para retornar a lista de sugestões dos possíveis kits de venda.
