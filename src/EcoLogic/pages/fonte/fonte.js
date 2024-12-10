
document.getElementById('btn-cadastrar').addEventListener('click', async function (event) {
    event.preventDefault();

    
    const nome = document.getElementById('nome').value.trim();
    const localidade = document.getElementById('localidade').value.trim();
    const eficienciaMedia = document.getElementById('eficiencia').value.trim();
    const tipoFonteId = document.getElementById('selectedFonteId').value.trim(); 
    const estado = document.getElementById('estado').value.trim();
    const capacidade = document.getElementById('capacidade').value.trim();
    const data = document.getElementById('data').value.trim();

    
    if (!nome || !localidade || !eficienciaMedia || !tipoFonteId || !estado || !capacidade || !data) {
        alert('Preencha todos os campos!');
        return;
    }

    
    const novaUsina = {
        nome,
        localidade,
        eficienciaMedia,
        tipoFonteId, 
        estado,
        capacidade,
        data
    };

    console.log("Dados enviados para a API:", JSON.stringify(novaUsina));

    try {
        
        const response = await fetch('http://localhost:5181/api/v1/Usinas', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(novaUsina)
        });

        if (!response.ok) {
            throw new Error(`Erro ao criar usina: ${response.statusText}`);
        }


        const usinaCriada = await response.json();
        listaCadastro.push(usinaCriada);
        // atualizarLista();

        // Reseta os campos do formulário
        document.querySelectorAll('input, textarea').forEach(element => element.value = '');

        alert('Usina cadastrada com sucesso!');
    } catch (error) {
        console.error(error);
        alert('Ocorreu um erro ao cadastrar a usina. Tente novamente.');
    }
});
