async function carregarUsinas() {
    // Espera até que o DOM esteja totalmente carregado
    document.addEventListener('DOMContentLoaded', async function () {
        const dropdownMenu = document.querySelector('.dropdown .dropdown-menu'); // O menu do dropdown
        const dropdownButton = document.querySelector('.dropdown .dropdown-toggle'); // O botão do dropdown (onde o nome da usina será mostrado)

        // Verifica se o menu do dropdown e o botão existem
        if (!dropdownMenu || !dropdownButton) {
            console.error('Elemento dropdownMenu ou dropdownButton não encontrado');
            return;
        }

        // Exibe o overlay de carregamento
        const loadingOverlay = document.getElementById('loading-overlay');
        if (loadingOverlay) {
            loadingOverlay.style.display = 'flex';  // Exibe o overlay de carregamento
        }

        try {
            // Realiza a requisição para a API
            const response = await fetch('http://localhost:5181/api/v1/usinas'); // URL da API
            const data = await response.json();

            // Limpa o dropdown antes de adicionar os itens
            dropdownMenu.innerHTML = '';

            // Adiciona uma opção padrão
            const defaultOption = document.createElement('li');
            defaultOption.innerHTML = '<a class="dropdown-item" data-id="">Selecione a Fonte Energética</a>';
            dropdownMenu.appendChild(defaultOption);

            // Preenche o dropdown com as usinas carregadas
            data.forEach(usina => {
                const option = document.createElement('li');
                // Armazenando o ID da usina no atributo data-id
                option.innerHTML = `<a class="dropdown-item" data-id="${usina.id}">${usina.nome}</a>`;
                dropdownMenu.appendChild(option);
            });

            // Adiciona o evento de clique para cada item do dropdown
            const items = dropdownMenu.querySelectorAll('.dropdown-item');
            items.forEach(item => {
                item.addEventListener('click', function(event) {
                    // Remove a classe 'active' de todos os itens
                    items.forEach(i => i.classList.remove('active'));

                    // Adiciona a classe 'active' ao item selecionado
                    event.target.classList.add('active');

                    // Atualiza o texto do botão com o nome da usina selecionada
                    dropdownButton.innerHTML = event.target.innerHTML;

                    // Armazena o ID e o nome da usina selecionada
                    const selectedUsinaId = event.target.getAttribute('data-id');
                    const selectedUsinaName = event.target.innerHTML;

                    console.log("Usina selecionada - ID:", selectedUsinaId, "Nome:", selectedUsinaName);

                    // Opcional: Armazenar o ID selecionado em um campo oculto, para enviar ao servidor, se necessário
                    // Exemplo:
                    document.getElementById('selectedUsinaId').value = selectedUsinaId;
                });
            });

        } catch (error) {
            console.error('Erro ao carregar as usinas:', error);
        } finally {
            // Remove o overlay de carregamento
            if (loadingOverlay) {
                loadingOverlay.style.display = 'none';
            }
        }
    });
}

// Chama a função para carregar as usinas
carregarUsinas();
