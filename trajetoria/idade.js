(function age(params) {
    const calculate = (birthDate) => {
        const today = new Date()
        const birth = new Date(birthDate)
        let age = today.getFullYear() - birth.getFullYear()
        if (today.getMonth() < birth.getMonth() || (today.getMonth() === birth.getMonth() && today.getDate() < birth.getDate())) age--
        return age
    };
    const ewerton = calculate('1985-06-28')
    const portella = calculate('2016-06-24')
    const contato = calculate('1995-06-28')
    const profissionalExperiencia = calculate('2001-01-01')
    const tiExperiencia = calculate('2012-01-01')

    params.ewerton.textContent = ewerton
    params.portella.textContent = portella
    params.total.textContent = ewerton;
    params.contato.textContent = contato;
    params.experiencia.textContent = profissionalExperiencia;
    params.tiExperiencia.textContent = tiExperiencia;

})({
    ewerton: document.getElementById('ewerton-idade'),
    portella: document.getElementById('portella-idade'),
    total: document.getElementById('idade-total'),
    contato: document.getElementById('idade-contato'),
    experiencia: document.getElementById('idade-profissional-experiencia'),
    tiExperiencia: document.getElementById('idade-ti-experiencia'),
});