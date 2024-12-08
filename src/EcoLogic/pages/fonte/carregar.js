async function carregarFontesEnergeticas() {
    document.addEventListener('DOMContentLoaded', async function () {
        const dropdownMenu = document.querySelector('#dropdownFonte + .dropdown-menu');
        const dropdownButton = document.querySelector('#dropdownFonte');
        const hiddenInput = document.getElementById('selectedFonteId');

        if (!dropdownMenu || !dropdownButton || !hiddenInput) {
            console.error('Elementos dropdownMenu, dropdownButton ou hiddenInput não encontrados');
            return;
        }

        try {
            const response = await fetch('http://localhost:5181/api/v1/FontesDeEnergia');
            const data = await response.json();

            dropdownMenu.innerHTML = '';

            const defaultOption = document.createElement('li');
            defaultOption.innerHTML = '<a class="dropdown-item" data-id="">Selecione uma Fonte Energética</a>';
            dropdownMenu.appendChild(defaultOption);

            data.forEach(fonte => {
                const option = document.createElement('li');
                option.innerHTML = `<a class="dropdown-item" data-id="${fonte.id}">${fonte.tipo}</a>`;
                dropdownMenu.appendChild(option);
            });

            const items = dropdownMenu.querySelectorAll('.dropdown-item');
            items.forEach(item => {
                item.addEventListener('click', function(event) {
                    items.forEach(i => i.classList.remove('active'));
                    event.target.classList.add('active');

                    dropdownButton.innerHTML = event.target.innerHTML;

                    const selectedFonteId = event.target.getAttribute('data-id');
                    hiddenInput.value = selectedFonteId;

                    console.log("Fonte selecionada - ID:", selectedFonteId, "Tipo:", event.target.innerHTML);
                });
            });

        } catch (error) {
            console.error('Erro ao carregar as fontes energéticas:', error);
        }
    });
}

carregarFontesEnergeticas();
