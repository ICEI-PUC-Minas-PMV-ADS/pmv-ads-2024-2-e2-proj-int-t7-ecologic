let currentIndex = 0; // Inicializando com a página 1 (índice 0 no carrossel)
const itemsPerPage = 6;
let allUsinas = [];

// Atualiza o conteúdo do elemento h3 com o total de fontes de energia
async function updateFontesCount() {
    try {
        const response = await fetch('http://localhost:5181/api/v1/FontesDeEnergia');
        const fontes = await response.json();
        
        const totalFontes = fontes.length; // Número total de fontes de energia
        const fontesHeading = document.querySelector('#NTFE'); // Substitua "fontes-titulo" pela classe/ID do seu h3
        
        if (fontesHeading) {
            fontesHeading.textContent = `Número Total de Fontes de Energia: ${totalFontes}`;
        } else {
            console.error('Elemento h3 para fontes de energia não encontrado.');
        }
    } catch (error) {
        console.error('Erro ao carregar as fontes de energia:', error);
    }
}

async function loadCarouselData() {
    try {
        const response = await fetch('http://localhost:5181/api/v1/Usinas');
        const data = await response.json();
        allUsinas = data;

        const totalPages = Math.ceil(allUsinas.length / itemsPerPage);
        renderCarouselItems(totalPages);
        updateLegenda(currentIndex + 1, totalPages);
    } catch (error) {
        console.error('Erro ao carregar dados da API:', error);
    }
}

function renderCarouselItems(totalPages) {
    const carouselContainer = document.getElementById('ci');
    if (!carouselContainer) {
        console.error('Elemento com id "ci" não encontrado.');
        return;
    }

    carouselContainer.innerHTML = '';

    for (let pageIndex = 0; pageIndex < totalPages; pageIndex++) {
        const startIndex = pageIndex * itemsPerPage;
        const pageItems = allUsinas.slice(startIndex, startIndex + itemsPerPage);

        const carouselItem = document.createElement('div');
        carouselItem.classList.add('carousel-item');

        const row = document.createElement('div');
        row.classList.add('row');

        pageItems.forEach(usina => {
            const carouselItemContent = createCarouselItem(usina);
            row.appendChild(carouselItemContent);
        });

        carouselItem.appendChild(row);
        carouselContainer.appendChild(carouselItem);

        if (pageIndex === 0) {
            carouselItem.classList.add('active');
        }
    }

}

function createCarouselItem(usina) {
    const carouselItemContent = document.createElement('div');
    carouselItemContent.classList.add('col-4', 'componente-usinas-1', 'd-flex', 'flex-column', 'mb-5');

    const imagemUrl = usina.imagemUrl || './foto1.jpg';
    const nome = usina.nome || 'Nome não disponível';
    const tipo = usina.fonteDeEnergia?.tipo || 'Tipo não especificado';
    const descricao = usina.descricao || 'Descrição não fornecida';
    const eficiencia = usina.fonteDeEnergia?.eficienciaMedia || '0%';

    carouselItemContent.innerHTML = `
        <div class="componentes-usinas-icones d-flex align-items-end">
            <div class="icon-bar">
                <i class="fas fa-trash-alt"></i>
                <i class="fas fa-edit"></i>
            </div>
        </div>
        <div class="componentes-usinas-imagem">
            <img src="${imagemUrl}" width="290px" />
        </div>
        <div class="componentes-usinas-descricao" style="line-height: 1.4;">
            <strong>Nome da Usina:</strong> <span style="font-weight: 100;">${nome}</span>
            <br />
            <strong>Tipo:</strong> <span style="font-weight: 100;">${tipo}</span>
            <br />
            <strong>Descrição:</strong> <span style="font-weight: 100;">${descricao}</span>
            <br />
            <strong>Eficiência:</strong> <span style="font-weight: 100;">${eficiencia}</span>
        </div>
    `;
    return carouselItemContent;
}

function updateLegenda(currentPage, totalPages) {
    const legenda = document.querySelector('.legenda');
    if (legenda) {
        legenda.textContent = `${currentPage} de ${totalPages}`;
    } else {
        console.error('Elemento com a classe "legenda" não encontrado.');
    }
}

// Chama as funções para carregar os dados e atualizar o título
loadCarouselData();
updateFontesCount();
