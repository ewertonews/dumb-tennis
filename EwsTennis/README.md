## Ews Tennis

Ol�!
Esse � um jogo simples de T�nis de **apenas um set** mas � poss�vel jogar, se divertir um pouco e identificar a regra b�sica do T�nis.

Como o jogo possui apenas 1 Set, o "Tie Break" � iniciado quando ambos jogadores atingem a pontua��o 40.

Algumas imagens demonstrando o funcionamento do jogo podem ser encontradas na pasta "Files" da solu��o.
## Game Play

### Quadra
A quadra largura de 27 pontos, e cada jogador pode asumir uma dessas posi��es, conforme imagem no linke abaixo:
https://1drv.ms/u/s!AupYf4d-RUahoOEPdQC3yJhsFoZzwQ?e=wuBZQo
(ou dentro da pasta files no projeto EwsTenis)

### Jogadores
Os "rob�s" jogadores do Ews Tennis tem intelig�ncia limitada. Eles s� conseguem mover-se para os lados e n�o conseguem definir a dire��o da bola quando saca ou quando rebate um ataque. No entanto, eles conseguem garantir que a bola **sempre** cai dentro da quadra. 
Cada jogador pode ter 3 n�veis de habilidade, sendo eles "Beginner", "Experienced" ou "Expert", onde cada um desses n�veis define um alcance para as m�os dos rob�s.
**Beginner:** Consegue alcan�ar 3 posi��es para a esquerda em em bra�o esquerdo e 3 posi��es para a direita em seu bra�o direito.
**Experienced:** Consegue alcan�ar 4 posi��es para a esquerda em em bra�o esquerdo e 4 posi��es para a direita em seu bra�o direito.direita em seu bra�o direito.
**Expert:** Consegue alcan�ar 5 posi��es para a esquerda em em bra�o esquerdo e 5 posi��es para a direita em seu bra�o direito.
Na imagem da quadra contida no link acima,  ambos jogadores s�o do n�vel beginner e possuem alcan�a de 3 em cada bra�o, sendo assim seu alcance total de 7. O jogador X estando na posi��o 14, seu alcance total � de 11 a 17. E o jogador y, estando na posi��o 16, seu alcance total � de 13 a 19. Assim, caso o saque/ataque (com valor aleat�rio, porque eles n�o s�o t�o inteligentes) do jogar X gerar um valor 12, o jogador Y ser� capaz de defender. Se o saque/ataque aleat�rio jo jogador Y gerar um valor menor que 13 ou maior que 19, ent�o ser� ponto para o jogador X.
O in�cio do jogo � feito pelo jogador que vence o par ou impar e a defini��o de qual jogador � par ou impar deve ser feita no arquivo de entrada explicado abaixo.
Para conseguir vencer o oponente ent�o, o jogador deve inserir o valor para onde seu rob� deve correr, e torcendo para que o rob� oponente tenha sacado nessa dire��o escolhida.

## Iniciando o Jogo

Para iniciar o jogo, deve-se abrir o terminal, navegar at� a pasta **{root}\tech-test-tennis\EwsTennis\EwsTennis** e digitar o comando `dotnet run` passando como argumento o caminho completo (fullpath [inclu�ndo nome do arquivo]) onde h� a defini�a� dos jogadores. Esse arquivo deve conter 8 linhas, sendo 4 linhas para cada jogador definindo:
- Nome
- Nivel (op��es: beginner, experienced, expert)
- Op��o ou impar (sendo par **even** e impar **odd**)
- Inteiro definindo posi��o inicial do jogador (entre **1** e **27**)

#### Exemplo do conte�do do arquivo de entrada:
Ewerton
Beginner
Even
20
Guga
Expert
Odd
25

## IMPORTANTE
No jogo, est� sendo revelado para onde o oponente est� mandando a bola, sendo poss�vel de sempre defender. Isso foi feito para facilitar o teste funcional do jogo. Caso queira deixar o jogo mais real, deve-se **comentar a linha 119 do arquivo GameController.cs**.