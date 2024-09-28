
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Descreva aqui a metodologia de trabalho do grupo para atacar o problema. Definições sobre os ambiente de trabalho utilizados pela  equipe para desenvolver o projeto. Abrange a relação de ambientes utilizados, a estrutura para gestão do código fonte, além da definição do processo e ferramenta através dos quais a equipe se organiza (Gestão de Times).

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

Discuta como a configuração do projeto foi feita na ferramenta de versionamento escolhida. Exponha como a gerência de tags, merges, commits e branchs é realizada. Discuta como a gerência de issues foi realizada.

> **Links Úteis**:
> - [Tutorial GitHub](https://guides.github.com/activities/hello-world/)
> - [Git e Github](https://www.youtube.com/playlist?list=PLHz_AreHm4dm7ZULPAmadvNhH6vk9oNZA)
>  - [Comparando fluxos de trabalho](https://www.atlassian.com/br/git/tutorials/comparing-workflows)
> - [Understanding the GitHub flow](https://guides.github.com/introduction/flow/)
> - [The gitflow workflow - in less than 5 mins](https://www.youtube.com/watch?v=1SXpE08hvGs)

## Gerenciamento de Projeto

A metodologia ágil escolhida para o desenvolvimento deste projeto foi o SCRUM. Nós optamos por este método devido à sua flexibilidade, que nos permite adaptar rapidamente às mudanças nos requisitos, uma situação comum em projetos. O SCRUM se baseia em princípios iterativos e incrementais, permitindo entregas contínuas e a adaptação ao longo do processo (SCHWABER; SUTHERLAND, 2017). Além disso, ele favorece a realização de ciclos curtos de trabalho, possibilitando entregas frequentes de funcionalidades.

### Divisão de Papéis

A divisão de papéis dentro de nossa equipe, que utilizará o método ágil SCRUM como base para definir os processos de desenvolvimento, é fundamental para garantir a eficiência e a clareza nas responsabilidades. Por isso, a equipe está organizada da seguinte forma:
• Scrum Master: [NOMES].
• Product Owner: [NOMES].
• Equipe de Desenvolvimento: [NOMES].
• Equipe de Design: [NOMES].

Essa estrutura assegura que cada membro tenha um papel claro, promovendo assim a colaboração e alinhamento com os objetivos do projeto. O Scrum Master será responsável por facilitar o processo e remover obstáculos, enquanto o Product Owner definirá as prioridades do backlog e irá assegurar que as entregas atendam às expectativas dos stakeholders (Clientes). As equipes de desenvolvimento e design trabalharão em conjunto para implementar as funcionalidades e criar soluções visuais que atendam às necessidades do projeto.

> **Links Úteis**:
> - [11 Passos Essenciais para Implantar Scrum no seu 
> Projeto](https://mindmaster.com.br/scrum-11-passos/)
> - [Scrum em 9 minutos](https://www.youtube.com/watch?v=XfvQWnRgxG0)

### Processo

Para a implementação do SCRUM, seguimos uma série de práticas que garantem a eficiência e a organização do nosso trabalho:
Cerimônias do SCRUM
•	Sprint Planning: No início de cada Sprint, a equipe realiza uma reunião estratégica. Durante essa reunião, definimos as atividades que serão priorizadas e planejadas para o ciclo de trabalho, assegurando que todos estejam alinhados com os objetivos a serem alcançados.
•	Daily Standup: Estas reuniões curtas, realizadas semanalmente, permitem que os membros da equipe compartilhem seu progresso, discutam obstáculos enfrentados e planejem as próximas tarefas. Isso faz com que fortaleça a comunicação e a transparência dentro da equipe.
•	Sprint Review: Ao final de cada Sprint, a equipe apresenta o trabalho concluído, obtendo o feedback necessário para a próxima iteração.
•	Sprint Retrospective: Realizamos uma reunião após a Sprint Review para refletir sobre o processo como um todo. Nessa cerimônia, a equipe discute o que funcionou bem, o que pode ser melhorado e identifica ações concretas para aumentar a eficiência e qualidade nas próximas iterações.

Para a organização e distribuição das tarefas do projeto, a equipe utiliza o Trello por meio de um quadro Kanban, estruturado da seguinte maneira:

•	Product Backlog: Esta lista contém todas as tarefas a serem trabalhadas, representando o Backlog do produto. Todas as atividades identificadas ao longo do projeto são incorporadas aqui, garantindo uma visão clara do trabalho a ser realizado.
•	To Do: Nesta lista, estão as tarefas que foram selecionadas para a Sprint atual e estão prontas para serem iniciadas.
•	In Progress: Aqui, são listadas as tarefas que já foram iniciadas, permitindo que a equipe visualize o que está em desenvolvimento.
•	Done: Nesta lista, são colocadas as tarefas finalizadas pelos membros da equipe, que passarão por testes e controle de qualidade. Após essa verificação, estarão prontas para entrega aos usuários.
<div align="center">
<img src="https://github.com/user-attachments/assets/e73385ad-5117-4bb7-a7d8-a0a747bd30c3" width="700px" />
</div>


 
> **Links Úteis**:
> - [Project management, made simple](https://github.com/features/project-management/)
> - [Sobre quadros de projeto](https://docs.github.com/pt/github/managing-your-work-on-github/about-project-boards)
> - [Como criar Backlogs no Github](https://www.youtube.com/watch?v=RXEy6CFu9Hk)
> - [Tutorial Slack](https://slack.com/intl/en-br/)

### Ferramentas

•	GitHub: É utilizado como plataforma de hospedagem de repositórios de código-fonte, o GitHub permite que a equipe mantenha todos os arquivos do projeto organizados. Através dele, os membros realizam commits regulares e criam branches para desenvolver novas funcionalidades ou corrigir bugs, e abrem pull requests para revisão de código, promovendo a colaboração e o controle de versão.

•	Trello: O Trello é utilizado para a organização e distribuição das tarefas do projeto por meio de um quadro Kanban. Essa ferramenta permite que a equipe visualize o progresso das atividades com mais clareza. Desde o Product Backlog até as tarefas concluídas, facilitando a gestão de trabalho.

•	Microsoft Teams: Foi adotado por nós como principal ferramenta de comunicação e colaboração, o Microsoft Teams facilita a realização de reuniões virtuais e o compartilhamento de arquivos e documentos importantes. Além disso, mantém uma comunicação eficaz entre todos os membros do grupo.

•	WhatsApp: Mesmo não sendo a ferramenta principal, o WhatsApp nos serve como um canal complementar para comunicação rápida e informal. É utilizado para comunicações urgentes, atualizações imediatas e para manter a equipe conectada, mesmo fora dos dias de reunião no teams.

•	Figma: O Figma é a ferramenta escolhida para o design de interfaces e prototipagem de telas. Com ele, os designers podem criar Wireframes e fluxogramas, permitindo uma colaboração eficiente e uma melhor compreensão das necessidades do projeto.

•	Ambiente de Trabalho: Cada membro da equipe utiliza seu próprio ambiente de trabalho, geralmente composto por computadores pessoais ou notebooks com sistemas operacionais compatíveis com as ferramentas de desenvolvimento adotadas.

•	Gestão Ágil: A equipe adota uma abordagem ágil para o gerenciamento de projetos, utilizando o SCRUM. Metodologia que orienta a divisão do trabalho em sprints, realização de reuniões regulares e a manutenção de um backlog priorizando tarefas, garantindo eficiência e adaptação contínua às necessidades do projeto.

•	Visual Studio Code (VS Code): O VS Code é utilizado como ambiente de desenvolvimento pela equipe. Ele oferece recursos avançados de edição de código, integração com o GitHub e da suporte a diversas linguagens de programação, facilitando o desenvolvimento e a colaboração entre os membros da equipe.
As ferramentas empregadas no projeto são:
