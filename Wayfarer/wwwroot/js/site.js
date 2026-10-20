(function () {
  function setNav(open) {
    var nav = document.getElementById('site-nav');
    var toggle = document.querySelector('[data-nav-toggle]');
    if (!nav) return;
    nav.dataset.open = String(open);
    if (toggle) toggle.setAttribute('aria-expanded', String(open));
  }

  document.addEventListener('click', function (e) {
    var nav = document.getElementById('site-nav');
    if (!nav) return;

    if (e.target.closest('[data-nav-toggle]')) {
      setNav(nav.dataset.open !== 'true');
      return;
    }
    if (e.target.closest('#site-nav a')) {
      setNav(false);
    }
  });

  document.addEventListener('keydown', function (e) {
    if (e.key !== 'Escape') return;

    var modalClose = document.querySelector('[data-modal-close]');
    if (modalClose) {
      modalClose.click();
      return;
    }
    setNav(false);
  });
})();
