// Função para enviar os dados para a API
document.getElementById('btn-cadastrar').addEventListener('click', function() {
    // Captura os valores dos campos
    const data = document.getElementById('data1').value; // Data de produção
    const quantidadeProduzida = document.getElementById('quantidade_produzida').value; // Quantidade produzida (Energia Gerada)
    
    // Captura o ID da usina do dropdown
    const usinaId = document.querySelector('.dropdown-item.active')?.getAttribute('data-id');
    
    // Valida se todos os campos necessários estão preenchidos
    if (!data || !quantidadeProduzida || !usinaId) {
        alert('Por favor, preencha todos os campos obrigatórios.');
        return;
    }

    // Exibe o overlay de carregamento
    document.getElementById('loading-overlay').style.display = 'flex';

    // Envia os dados para a API
    fetch('http://localhost:5181/api/v1/ProducaoDeEnergia', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            UsinaId: usinaId,               // UsinaId (ID da usina selecionada)
            DataProducao: data,             // Data de produção
            EnergiaGeradaKW: quantidadeProduzida, // Quantidade de energia gerada
            EficienciaOperacional: null    // Ignorando o campo fonte_energia
        })
    })
    .then(response => {
        console.log('Resposta da API recebida:', response);

        // Verifica se a resposta é bem-sucedida
        if (response.status === 201) {
            // Se a resposta for 201 (Created), considera como sucesso
            return response.json(); // Retorna os dados da resposta em JSON
        } else {
            // Se o status não for 201, lança um erro
            throw new Error('Erro ao adicionar o registro. Status: ' + response.status);
        }
    })
    .then(data => {
        console.log('Dados recebidos da API:', data);

        // Fecha o overlay de carregamento
        document.getElementById('loading-overlay').style.display = 'none';

        // Exibe a mensagem de sucesso
        alert('Registro adicionado com sucesso!');
    })
    .catch(error => {
        // Fecha o overlay de carregamento em caso de erro
        document.getElementById('loading-overlay').style.display = 'none';

        // Exibe a mensagem de erro
        alert('Erro na requisição: ' + error.message);
    });
});

// Função para o dropdown de Usina
document.querySelectorAll('.dropdown-item').forEach(function(item) {
    item.addEventListener('click', function(e) {
        var selectedValue = e.target.getAttribute('data-value');  // Nome da usina
        var selectedId = e.target.getAttribute('data-id');  // ID da usina
        
        // Atualiza o botão do dropdown com o nome da usina
        document.querySelector('.dropdown-toggle').textContent = selectedValue;

        // Armazena o ID da usina no campo oculto ou variável para uso posterior
        document.querySelector('.dropdown-toggle').setAttribute('data-id', selectedId);
    });
});
