# ClinicPro - Sistema de Gestão de Clínica Médica

## Introdução

### Objetivo do Documento

Este documento especifica as necessidades operacionais da Clínica Médica X e tem como objetivo definir o sistema de gestão de clínica médica, ClinicPro, a ser desenvolvido para apoiar essas necessidades.

### Materiais de Referência

Abaixo estão listadas as fontes de informação consideradas na identificação dos requisitos do sistema:

- [DOC01] Entrevista inicial com Maria de Fátima e João Silva (recepcionistas da Clínica Médica X) realizada em 27/03/24. Ata da entrevista encontra-se disponível em “Lorean/ipsun/dolor/sit/aneat”
- [DOC02] Entrevista inicial com Thaís Santos e Bruno de Souza (profissionais médicos da Clínica Médica X) realizada em 28/03/24. Ata da entrevista encontra-se disponível em “Lorean/ipsun/dolor/sit/aneat”
- [DOC03] Planilhas de cadastro de pacientes e de consultas da Clínica Médica X. Recebida em 29/03/2024 de João Silva (recepcionista ). Disponível em “Lorean/ipsun/dolor/sit/aneat”.
- [DOC04] Registros de consultas de um paciente. Recebida em 29/03/2024 de Thaís Santos (profissional médica). Disponível em “Lorean/ipsun/dolor/sit/aneat”.

### Descrição Geral do Sistema

#### Visão Geral

O sistema trata do problema da gestão de uma clínica médica para a Clínica Médica X, que possui diversos profissionais da área médica e que realizam atendimentos aos pacientes. O produto de software ClinicPro é um software sob encomenda que será responsável por dar suporte à gestão de clínica onde trabalha uma equipe de médicos. Nosso produto facilitará o agendamento de consultas pelos recepcionistas e a gestão de registros de pacientes pelos profissionais médicos. Além disso, lidará com a recepção e distribuição de resultados de testes laboratoriais, dando aos médicos a opção de entregar os resultados aos pacientes ou armazená-los para referência futura. Além disso, os médicos podem autorizar o acesso online aos resultados dos testes para os respectivos pacientes, que usarão uma chave única para visualizar seus resultados.

#### Usuários

- **Recepcionistas**: Faixa etária de 18 a 65 anos, com formação completa de ensino médio, conhecimento de informática básico.
- **Médicos**: Faixa etária de 18 a 65 anos, com formação mínima de superior completo, conhecimento de informática básica.
- **Pacientes**: Faixa etária de 18 a 90 anos, com diversos graus de formação, conhecimento de informática básica.
- **Pacientes Menores de 18 anos**: Faixa etária de 0 a 17 anos. Neste caso, os responsáveis legais são responsáveis pelo acesso ao sistema em nome dos pacientes.

#### Benefícios

- Apoiar e simplificar o gerenciamento das consultas e de cadastros de pacientes pelos recepcionistas da clínica.
- Maior organização e precisão dos registros de pacientes, facilitando a recuperação de informações e reduzindo o risco de erros nos dados cadastrais.
- Acesso rápido e facilitado às informações relevantes, como horários disponíveis para consultas, registros de pacientes e resultados de exames, otimizando o atendimento ao paciente.

#### Limitações e Restrições

- O sistema não oferecerá suporte para pagamento e transações financeiras de consultas particulares.
- O sistema não oferecerá funcionalidades para gestão de Estoque de Medicamentos.
- O sistema não oferecerá funcionalidades relacionadas à gestão de recursos humanos.

## Requisitos

### Requisitos Funcionais

#### Módulo do Recepcionista

- **[RF101]** O sistema deve permitir que os recepcionistas façam login no sistema.
- **[RF102]** O sistema deve permitir que os recepcionistas agendem consultas para pacientes.
- **[RF103]** O sistema deve exibir os horários disponíveis e indisponíveis para agendamento de consulta.
- **[RF104]** O sistema deve permitir que os recepcionistas visualizem e modifiquem datas e horários de consultas existentes mediante solicitação.
- **[RF 105]** O sistema deve permitir que os recepcionistas possam cancelar consultas mediante solicitação.
- **[RF106]** O sistema deve permitir que os recepcionistas realizem o cadastro de um novo paciente.
- **[RF107]** O sistema deve permitir que os recepcionistas realizem buscas de consultas por data, CPF ou nome do paciente.
- **[RF108]** O sistema deve permitir que os recepcionistas atualizem os dados de cadastro de um paciente.
- **[RF109]** O sistema deve permitir que os recepcionistas apaguem o cadastro de um paciente mediante solicitação.
- **[RF110]** O sistema não deve permitir que os recepcionistas vejam o registro do histórico nem os resultados de exames dos pacientes.
- **[RF111]** O sistema deve retornar uma mensagem informando “data indisponível” caso os recepcionistas tentem agendar consultas em horários já marcados.

#### Módulo do Profissional Médico

- **[RF201]** O sistema deve permitir que os profissionais médicos acessem registros históricos e exames de pacientes.
- **[RF202]** O sistema deve permitir que os profissionais médicos façam login no sistema.
- **[RF203]** O sistema deve permitir que os profissionais médicos atualizem os registros de pacientes com notas de consulta e planos de tratamento.
- **[RF204]** O sistema deve permitir que os profissionais médicos realizem busca dos registros de pacientes com base no nome ou CPF.
- **[RF205]** O sistema deve permitir que os profissionais médicos recebam resultados de testes laboratoriais diretamente dos laboratórios.
- **[RF206]** O sistema deve permitir que os profissionais médicos armazenem resultados de exames laboratoriais no registro do paciente.
- **[RF207]** O sistema deve permitir que os profissionais médicos autorizem o acesso online aos resultados de exames para os respectivos pacientes.
- **[RF208]** O sistema não deve permitir que os profissionais médicos vejam dados de cadastro dos pacientes.

#### Módulo do Paciente

- **[RF301]** O sistema deve permitir que os pacientes acessem e visualizem os resultados de exames utilizando uma chave de acesso única.
- **[RF302]** O sistema deve exibir uma interface amigável e intuitiva para os pacientes acessarem seus resultados de exames.
- **[RF303]** O sistema deve apresentar ao paciente as informações de resultado de exames de forma de lista.
- **[RF304]** O sistema deve permitir que o paciente filtre os resultados de exames por médico requerente, data do exame ou tipo de exame.
- **[RF305]** O sistema deve permitir que o paciente busque os resultados de exames por data do exame, tipo de exame ou médico requerente.
- **[RF306]** O sistema deve permitir que pacientes imprimam ou baixem os resultados de exames.
- **[RF307]** O sistema deve permitir que os pacientes recebam notificações quando novos resultados de exames estiverem disponíveis para visualização.
- **[RF308]** O sistema deve permitir que os pacientes solicitem esclarecimentos adicionais sobre seus resultados de exames.
- **[RF309]** O sistema deve permitir que os pacientes realizem agendamento de consultas a partir da seleção de data disponível, médico e dados de cadastro.
- **[RF310]** O sistema deve permitir que os pacientes atualizem suas informações de contato.

### Requisitos Não Funcionais

#### Requisitos do Produto

- **[RNF101]** A interface do sistema ClinicPro deve ser intuitiva e de fácil utilização.
- **[RNF102]** O sistema ClinicPro deve ser capaz de lidar eficientemente com uma grande quantidade de dados e usuários simultâneos.
- **[RNF103]** O sistema ClinicPro deve estar disponível para acesso dos pacientes de forma contínua.
- **[RNF104]** O sistema ClinicPro deve ser confiável, minimizando a ocorrência de falhas ou erros.
- **[RNF105]** O sistema ClinicPro deve ser constantemente monitorado para identificar e corrigir possíveis vulnerabilidades de segurança e outros problemas operacionais.

#### Requisitos Organizacionais

- **[RNF201]** Cada recepcionista que utiliza o sistema ClinicPro é identificado por um número de funcionário único de oito dígitos.
- **[RNF202]** Cada profissional médico que utiliza o sistema ClinicPro é identificado por um número de funcionário único de oito dígitos.
- **[RNF203]** Cada paciente que acessa seus resultados de exames no sistema ClinicPro recebe um código de acesso único de 10 dígitos.

#### Requisitos Externos

- **[RNF301]** O sistema ClinicPro deve ser capaz de armazenar os exames realizados pelos pacientes por um período mínimo de 30 anos.
- **[RNF302]** O sistema ClinicPro deve garantir a segurança dos dados dos pacientes implementando medidas de criptografia para proteger as informações confidenciais.

## Lista Completa de Tarefas

### Recepcionista

#### RF101: Agendamento de Consultas

1. Criar uma interface para que os recepcionistas possam inserir os detalhes da consulta.
2. Desenvolver a lógica para salvar os detalhes da consulta no banco de dados.

#### RF102: Exibição de Horários Disponíveis

1. Implementar uma função que verifica os horários disponíveis com base nas consultas já agendadas.
2. Criar uma interface para exibir esses horários disponíveis ao recepcionista durante o agendamento.

#### RF103: Visualização e Modificação de Consultas

1. Desenvolver uma página onde os recepcionistas possam visualizar as consultas existentes.
2. Permitir que os recepcionistas modifiquem datas e horários de consultas existentes mediante solicitação.

#### RF104: Cancelamento de Consultas

1. Implementar uma função para cancelar consultas no sistema.
2. Criar uma interface para que os recepcionistas possam selecionar consultas e cancelá-las mediante solicitação.

#### RF105: Cadastro de Novos Pacientes

1. Criar uma página de cadastro para que os recepcionistas possam inserir os detalhes do novo paciente.
2. Desenvolver a lógica para salvar os detalhes do paciente no banco de dados.

#### RF106: Busca de Consultas

1. Implementar uma função de busca que permita aos recepcionistas pesquisar consultas por data, CPF ou nome do paciente.
2. Criar uma interface amigável para que os recepcionistas possam realizar essas buscas facilmente.

#### RF107: Atualização de Dados de Pacientes

1. Desenvolver uma página para que os recepcionistas possam atualizar os dados de cadastro de um paciente.
2. Implementar a lógica para atualizar os dados do paciente no banco de dados.

#### RF108: Exclusão de Cadastro de Pacientes

1. Criar uma função para excluir o cadastro de um paciente do sistema.
2. Desenvolver uma interface para que os recepcionistas possam selecionar e excluir os cadastros mediante solicitação.

#### RF109: Restrição de Acesso a Histórico e Resultados de Exames

1. Implementar controle de acesso para garantir que os recepcionistas não tenham acesso ao histórico ou resultados de exames dos pacientes.
2. Configurar permissões adequadas no sistema para restringir o acesso apenas às informações necessárias para agendamento e gerenciamento de consultas.

### Profissional Médico

#### RF201: Acesso a Registros Históricos e Exames

1. Implementar uma função de busca que permita aos profissionais médicos pesquisar registros históricos e exames de pacientes por nome ou CPF.
2. Desenvolver uma interface para que os médicos possam visualizar esses registros de forma clara e organizada.

#### RF202: Atualização de Registros de Pacientes

1. Criar uma página para que os profissionais médicos possam adicionar notas de consulta e planos de tratamento aos registros dos pacientes.
2. Implementar a lógica para atualizar os registros de pacientes com as informações fornecidas pelos médicos.

#### RF203: Busca de Registros de Pacientes

1. Desenvolver uma função de busca que permita aos médicos pesquisar registros de pacientes por nome ou CPF.
2. Criar uma interface amigável para que os médicos possam realizar essas buscas de forma rápida e eficiente.

#### RF204: Recebimento de Resultados de Testes Laboratoriais

1. Estabelecer integração com os laboratórios para receber os resultados dos testes laboratoriais automaticamente.
2. Desenvolver uma função para processar e armazenar esses resultados no sistema de forma segura.

#### RF206: Armazenamento de Resultados de Exames

1. Implementar uma função para permitir que os médicos armazenem resultados de exames laboratoriais nos registros dos pacientes.
2. Desenvolver uma interface para facilitar o processo de inserção e visualização desses resultados.

#### RF207: Autorização de Acesso Online aos Resultados de Exames

1. Criar uma função para gerar chaves de acesso únicas para os resultados de exames dos pacientes.
2. Desenvolver uma interface para que os médicos possam autorizar o acesso online aos resultados de exames para os respectivos pacientes, utilizando essas chaves.

### Paciente

#### RF301: Acesso e Visualização de Resultados de Exames

1. Desenvolver uma página de login para pacientes utilizando uma chave de acesso única.
2. Implementar a função para que os pacientes acessem e visualizem os resultados de exames após autenticação.

#### RF302: Interface Amigável para Acesso aos Resultados

1. Projetar e desenvolver uma interface intuitiva e amigável para que os pacientes possam acessar facilmente seus resultados de exames.
2. Garantir que a interface seja responsiva para se adaptar a diferentes dispositivos.

#### RF303: Apresentação Organizada dos Resultados

1. Desenvolver uma função para apresentar os resultados de exames de forma clara e organizada, em formato de lista.
2. Implementar recursos de paginação para facilitar a navegação pelos resultados, especialmente em casos de grandes volumes de informações.

#### RF304: Filtragem de Resultados de Exames

1. Criar opções de filtro para que os pacientes possam classificar os resultados de exames por médico requerente, data do exame ou tipo de exame.
2. Desenvolver a lógica para aplicar esses filtros aos resultados apresentados na interface do paciente.

#### RF305: Busca de Resultados de Exames

1. Implementar uma função de busca que permita aos pacientes pesquisar resultados de exames por data do exame, tipo de exame ou médico requerente.
2. Criar uma interface de busca intuitiva para que os pacientes possam encontrar facilmente os resultados desejados.

#### RF306: Impressão ou Download de Resultados de Exames

1. Desenvolver opções para que os pacientes possam imprimir ou baixar os resultados de exames em formatos de arquivo comuns, como PDF.
2. Garantir que os resultados baixados sejam apresentados de forma legível e organizada.

#### RF307: Notificações de Novos Resultados de Exames

1. Implementar um sistema de notificação para alertar os pacientes quando novos resultados de exames estiverem disponíveis.
2. Desenvolver opções para que os pacientes possam optar por receber notificações por e-mail, SMS ou outros meios de comunicação.

#### RF308: Solicitação de Esclarecimentos Adicionais

1. Criar uma função para que os pacientes possam solicitar esclarecimentos adicionais sobre seus resultados de exames.
2. Desenvolver uma interface para que os pacientes possam enviar mensagens aos seus médicos ou à equipe responsável pelo laboratório.

#### RF309: Agendamento de Consultas

1. Implementar uma função para que os pacientes possam agendar consultas diretamente pelo sistema.
2. Desenvolver uma interface para que os pacientes possam selecionar datas disponíveis, escolher o médico e fornecer seus dados de cadastro.

#### RF310: Atualização de Informações de Contato

1. Criar opções para que os pacientes possam atualizar suas informações de contato, como endereço, telefone e e-mail.
2. Desenvolver uma interface intuitiva para que os pacientes possam realizar essas atualizações facilmente.

## Cronograma de Desenvolvimento

### Fase 1: Planejamento e Análise (Duração: 2 semanas)

- **Atividade 1**: Revisão dos materiais de referência (DOC01 a DOC04).
- **Atividade 2**: Realização de reuniões de planejamento com a equipe de desenvolvimento.
- **Atividade 3**: Elaboração da lista completa de requisitos funcionais e não funcionais.
- **Atividade 4**: Definição do escopo do projeto e dos principais marcos de desenvolvimento.

### Fase 2: Projeto e Prototipagem (Duração: 4 semanas)

- **Atividade 1**: Design da arquitetura do sistema ClinicPro.
- **Atividade 2**: Desenvolvimento de protótipos de interface para os módulos do recepcionista, profissional médico e paciente.
- **Atividade 3**: Especificação técnica dos requisitos de software e hardware.
- **Atividade 4**: Revisão e validação dos protótipos com a equipe de desenvolvimento e os usuários finais.

### Fase 3: Implementação (Duração: 8 semanas)

- **Atividade 1**: Configuração do ambiente de desenvolvimento e do banco de dados.
- **Atividade 2**: Desenvolvimento dos módulos do recepcionista, profissional médico e paciente.
- **Atividade 3**: Implementação das funções de busca, filtro e ordenação de dados.
- **Atividade 4**: Testes de unidade e integração para garantir a qualidade do código e a integridade do sistema.

### Fase 4: Testes e Validação (Duração: 6 semanas)

- **Atividade 1**: Realização de testes de sistema e aceitação com a participação dos usuários finais.
- **Atividade 2**: Identificação e correção de defeitos e problemas de usabilidade.
- **Atividade 3**: Treinamento da equipe de recepcionistas, profissionais médicos e pacientes para uso do sistema.
- **Atividade 4**: Preparação da documentação final do projeto e entrega do sistema ClinicPro para produção.

## Conclusão

O sistema de gestão de clínica médica ClinicPro é uma solução abrangente e personalizada para a Clínica Médica X, que visa melhorar a eficiência e a qualidade dos serviços prestados. Com funcionalidades específicas para os recepcionistas, profissionais médicos e pacientes, o ClinicPro oferece uma experiência integrada e intuitiva que atende às necessidades de todas as partes envolvidas. O cumprimento dos requisitos funcionais e não funcionais, juntamente com um cronograma de desenvolvimento claro e detalhado, garantirá o sucesso deste projeto e a satisfação de todos os stakeholders envolvidos.
