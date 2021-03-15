## Ews Tennis

Olá!
Esse é um jogo simples de Tênis de **apenas um set** mas é possível jogar, se divertir um pouco e identificar a regra básica do Tênis.

Como o jogo possui apenas 1 Set, o "Tie Break" é iniciado quando ambos jogadores atingem a pontuação 40.

Algumas imagens demonstrando o funcionamento do jogo podem ser encontradas na pasta "Files" da solução.
## Game Play

### Quadra
A quadra largura de 27 pontos, e cada jogador pode asumir uma dessas posições, conforme imagem no linke abaixo:
https://1drv.ms/u/s!AupYf4d-RUahoOEPdQC3yJhsFoZzwQ?e=wuBZQo
(ou dentro da pasta files no projeto EwsTenis)

### Jogadores
Os "robôs" jogadores do Ews Tennis tem inteligência limitada. Eles só conseguem mover-se para os lados e não conseguem definir a direção da bola quando saca ou quando rebate um ataque. No entanto, eles conseguem garantir que a bola **sempre** cai dentro da quadra. 
Cada jogador pode ter 3 níveis de habilidade, sendo eles "Beginner", "Experienced" ou "Expert", onde cada um desses níveis define um alcance para as mãos dos robôs.<br/><br/>
**Beginner:** Consegue alcançar 3 posições para a esquerda em em braço esquerdo e 3 posições para a direita em seu braço direito.<br/>
**Experienced:** Consegue alcançar 4 posições para a esquerda em em braço esquerdo e 4 posições para a direita em seu braço direito.direita em seu braço direito.<br/>
**Expert:** Consegue alcançar 5 posições para a esquerda em em braço esquerdo e 5 posições para a direita em seu braço direito.<br/><br/>
Na imagem da quadra contida no link acima,  ambos jogadores são do nível beginner e possuem alcança de 3 em cada braço, sendo assim seu alcance total de 7. O jogador X estando na posição 14, seu alcance total é de 11 a 17. E o jogador y, estando na posição 16, seu alcance total é de 13 a 19. Assim, caso o saque/ataque (com valor aleatório, porque eles não são tão inteligentes) do jogar X gerar um valor 12, o jogador Y será capaz de defender. Se o saque/ataque aleatório jo jogador Y gerar um valor menor que 13 ou maior que 19, então será ponto para o jogador X.
O início do jogo é feito pelo jogador que vence o par ou impar e a definição de qual jogador é par ou impar deve ser feita no arquivo de entrada explicado abaixo.<br/>
Para conseguir vencer o oponente então, o jogador deve inserir o valor para onde seu robô deve correr, e torcendo para que o robô oponente tenha sacado nessa direção escolhida.<br/>

## Iniciando o Jogo

Para iniciar o jogo, deve-se abrir o terminal, navegar até a pasta **{root}\tech-test-tennis\EwsTennis\EwsTennis** e digitar o comando `dotnet run` passando como argumento o caminho completo (fullpath [incluíndo nome do arquivo]) onde há a definiçaõ dos jogadores. Esse arquivo deve conter 8 linhas, sendo 4 linhas para cada jogador definindo:
- Nome
- Nivel (opções: beginner, experienced, expert)
- Opção ou impar (sendo par **even** e impar **odd**)
- Inteiro definindo posição inicial do jogador (entre **1** e **27**)

#### Exemplo do conteúdo do arquivo de entrada:
Ewerton<br/>
Beginner<br/>
Even<br/>
20<br/>
Guga<br/>
Expert<br/>
Odd<br/>
25<br/>

## IMPORTANTE
No jogo, está sendo revelado para onde o oponente está mandando a bola, sendo possível de sempre defender. Isso foi feito para facilitar o teste funcional do jogo. Caso queira deixar o jogo mais real, deve-se **comentar a linha 119 do arquivo GameController.cs**.
