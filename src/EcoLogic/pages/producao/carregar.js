// Função para carregar os registros do JSON e exibi-los na página
function carregarRegistros() {
    const container = document.querySelector('.container-registros'); // Contêiner onde os itens serão inseridos
    
    // Exibe o overlay de carregamento
    const loadingOverlay = document.getElementById('loading-overlay');
    loadingOverlay.style.display = 'flex';
    
    // Faz a requisição para o arquivo JSON ou API
    fetch('http://localhost:5181/api/v1/usinas')  // Substitua pelo caminho correto do seu JSON
        .then(response => response.json())
        .then(data => {
            // Limita aos 3 primeiros itens
            const primeirosItens = data.slice(0, 3); // Retorna os primeiros 3 itens

            // Limpa o conteúdo antigo (caso exista)
            container.innerHTML = '';

            // Itera sobre os primeiros 3 itens
            primeirosItens.forEach(item => {
                // Cria o HTML para o item de registro
                const itemLayout = document.createElement('div');
                itemLayout.classList.add('row', 'justify-content-around'); // Utiliza row para criar as 3 linhas
                itemLayout.style.fontSize = '1.2rem'
                itemLayout.style.marginBottom = '10rem'

                // Verifica se a imagem existe, caso contrário, usa o placeholder
                const imagemUrl = item.imagem || './foto1.jpg'; // Altere para o caminho do seu placeholder

                itemLayout.innerHTML = `
                    <!-- Coluna para a Imagem à esquerda -->
                    <div class="col-12 col-md-7">
                        <img src="${imagemUrl}" alt="Imagem da Usina" class="img-fluid" style="border-radius: 10px; width: 80%  ">
                    </div>

                    <!-- Coluna para o conteúdo textual à direita -->
                    <div class="col-12 col-md-5" style="font-size: 1.78rem">
                        <div class="icons mb-2">
                            <button class="btn btn-sm btn-usinas-delete">
                                <i class="fas fa-trash-alt"></i>
                            </button>
                            <button class="btn btn-sm btn-usinas-edit">
                                <i class="fas fa-edit"></i>
                            </button>
                        </div>
                        <div class="description">
                            <span><strong>Data: </strong>${item.dataInicio}</span><br/>
                            <span><strong>Quantidade produzida: </strong>${item.capacidadeKW} kWh</span><br/>
                            <span><strong>Usina: </strong>${item.nome}</span><br/>
                            <span><strong>Tipo de Fonte de Energia: </strong>${item.fonteDeEnergia.tipo}</span>
                        </div>
                    </div>
                `;

                // Adiciona o item ao contêiner
                container.appendChild(itemLayout);
            });
        })
        .catch(error => {
            console.error('Erro ao carregar os dados:', error);
        })
        .finally(() => {
            // Remove o overlay de carregamento após a requisição
            loadingOverlay.style.display = 'none';
        });
}

// Chama a função para carregar os registros quando a página carregar
document.addEventListener('DOMContentLoaded', carregarRegistros);
