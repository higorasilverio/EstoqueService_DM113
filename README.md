# EstoqueService_DM113

### Pós-graduação em Desenvolvimento de Aplicações para Dispositivos Móveis e Cloud Computing

### Trabalho referente à disciplina DM113 - Desenvolvimento de serviço SOAP com WCF em C#

#### Orientador: [Prof. Felipe Andery Reis](https://github.com/fandery)

#### Descrição

> O serviço desenvolvido é responsável por atualizar o estoque de determinado produto.
> Ele acessa um banco de dados constituído por uma única tabela. 
> Por fim, o funcionamento do sistema é comprovado através de clientes de testes, que acessam serviços distintos via endpoints HTTP

#### Instruções para teste

1. Clone do repositório: `git clone https://github.com/higorasilverio/EstoqueService_DM113.git`
2. Dentro da pasta clonada, abra o arquivo **_EstoqueService.sln_** com o Visual Code 2019
3. Na barra de tarefas do Visual Code 2019, selecione **_Build_** e então **_Build Solution_**, **_Rebuild Solution_** ou apenas **_Ctrl+Shift+B_**
4. Na aba de **_Solution Explorer_**, clique com o botão direito sobre a solução **_EstoqueService_** e vá na opção **_Set Startup Projects..._**
5. Na aba de **_Common Properties_**, em **_Startup Project_**, selecione **_Multiple startup projects_**
6. Marque com **_Start_** os projetos **_ClienteEstoqueDesktop_**, **_ProvedorEstoqueHost_** e **_ClienteEstoqueProvedor_**
7. Clique em **_Aplicar_** e depois **_OK_**
8. De volta a tela principal do Visual Studio 2019, na parte superior, clique no ícone de **_Start_** ou pressione **_F5_**
9. Três consoles devem aparecer, indicando os projetos executados: **_ClienteEstoqueDesktop_**, **_ProvedorEstoqueHost_** e **_ClienteEstoqueProvedor_**
10. Aguarde a tela do projeto **_ProvedorEstoqueHost_** indicar que o servidor está rodando
11. Aperte ENTER nas duas outras telas para iniciar os teste dos clientes e verificar as informações logadas
