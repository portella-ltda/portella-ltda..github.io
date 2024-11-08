; (function blockquote() {
    const format = function (params) {
        params.p.style.display = 'flex'
        params.p.style.alignItems = 'center'
        params.p.style.columnGap = '0.4em'
        params.p.style.fontWeight = '500'
        params.p.textContent = params.p.textContent.replace(params.highlight.key, '')
        const span = document.createElement('span')
        span.style.color = params.highlight.color
        span.textContent = params.highlight.name;
        params.p.prepend(span)
        params.p.prepend(params.highlight.key)

    }
    document.querySelectorAll('blockquote').forEach(blockquote => {
        const p = blockquote.querySelector('p');
        if (!p)
            return;

        if (p.textContent.startsWith('[!NOTE]')) {
            const highlight = {
                key: '[!NOTE]',
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
        if (p.textContent.startsWith('[!TIP]')) {
            const highlight = {
                key: '[!TIP]',
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
        if (p.textContent.startsWith('[!IMPORTANT]')) {
            const highlight = {
                key: '[!IMPORTANT]',
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
        if (p.textContent.startsWith('[!WARNING]')) {
            const highlight = {
                key: '[!WARNING]',
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
        if (p.textContent.startsWith('[!CAUTION]')) {
            const highlight = {
                key: '[!CAUTION]',
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