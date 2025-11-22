(function () {
    const bar = document.getElementById('top-loading-bar');
    if (!bar) return;

    let active = false;
    let growTimeout;

    function startLoadingBar() {
        if (active) return;
        active = true;

        // Reset
        bar.style.transition = 'none';
        bar.style.width = '0';
        bar.style.opacity = '1';

        // Force reflow zodat transition werkt
        void bar.offsetWidth;

        // Begin met een klein stukje en laat hem daarna “groeien”
        bar.style.transition = 'width 0.3s ease-out, opacity 0.2s ease-out';
        bar.style.width = '20%';

        growTimeout = setTimeout(function () {
            // Langzaam richting ~80% totdat de pagina echt klaar is
            bar.style.transition = 'width 1.5s ease-out';
            bar.style.width = '80%';
        }, 150);
    }

    function finishLoadingBar() {
        if (!active) return;
        clearTimeout(growTimeout);

        bar.style.transition = 'width 0.2s ease-out, opacity 0.3s ease-out';
        bar.style.width = '100%';

        setTimeout(function () {
            bar.style.opacity = '0';
            setTimeout(function () {
                bar.style.width = '0';
                active = false;
            }, 200);
        }, 150);
    }

    // Start bij navigatie via links (binnen het portaal)
    document.addEventListener('click', function (e) {
        const link = e.target.closest('a');
        if (!link) return;

        const href = link.getAttribute('href');
        const target = link.getAttribute('target');

        // dingen die je níet wilt: anchors, nieuwe tab, externe links, of expliciet uitzetten
        if (!href ||
            href.startsWith('#') ||
            target === '_blank' ||
            link.dataset.noLoadingBar === 'true' ||
            href.startsWith('mailto:') ||
            href.startsWith('tel:')) {
            return;
        }

        // Alleen interne navigatie (optioneel: check op zelfde host)
        if (href.startsWith('http') && !href.startsWith(window.location.origin)) {
            return;
        }

        startLoadingBar();
    });

    // Start bij form submits (bijv. filters, zoekvelden)
    document.addEventListener('submit', function (e) {
        const form = e.target;
        if (form.dataset.noLoadingBar === 'true') {
            return;
        }
        startLoadingBar();
    });

    // Extra fallback: bij beforeunload (als iets anders de navigatie triggert)
    window.addEventListener('beforeunload', function () {
        startLoadingBar();
    });

    // Als de pagina klaar is (ook bij back/forward cache)
    window.addEventListener('pageshow', function (event) {
        // Alleen finishen als we daadwerkelijk via navigatie kwamen
        finishLoadingBar();
    });
})();