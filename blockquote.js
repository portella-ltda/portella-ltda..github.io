; (function blockquote() {
    const format = function (params) {
        params.p.style.display = 'flex'
        params.p.style.alignItems = 'center'
        params.p.style.columnGap = '0.4em'
        params.p.style.fontWeight = '500'
        params.p.style.color = params.highlight.color
        params.p.prepend(params.highlight.name + ' ')

    }
    document.querySelectorAll('blockquote').forEach(blockquote => {
        const p = blockquote.querySelector('p');
        if (!p)
            return;

        if (p.textContent === '[!NOTE]') {
            const highlight = {
                color: '#1f6feb',
                name: 'Note',
            }
            blockquote.style.borderColor = highlight.color
            format({
                p: p,
                highlight: highlight
            })
            return;
        }
        if (p.textContent === '[!TIP]') {
            const highlight = {
                color: '#3fb950',
                name: 'Tip',
            }
            blockquote.style.borderColor = highlight.color
            format({
                p: p,
                highlight: highlight
            })
            return
        }
        if (p.textContent === '[!IMPORTANT]') {
            const highlight = {
                color: '#ab7df8',
                name: 'Important',
            }
            blockquote.style.borderColor = highlight.color
            format({
                p: p,
                highlight: highlight
            })
            return
        }
        if (p.textContent === '[!WARNING]') {
            const highlight = {
                color: '#d29922',
                name: 'Warning',
            }
            blockquote.style.borderColor = highlight.color
            format({
                p: p,
                highlight: highlight
            })
            return
        }
        if (p.textContent === '[!CAUTION]') {
            const highlight = {
                color: '#f85149',
                name: 'Caution',
            }
            blockquote.style.borderColor = highlight.color
            format({
                p: p,
                highlight: highlight
            })
            return
        }
    });
})()