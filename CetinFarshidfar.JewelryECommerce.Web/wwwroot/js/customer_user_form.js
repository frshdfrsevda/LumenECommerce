// Sayfa tamamen yüklendiğinde çalışacak
document.addEventListener('DOMContentLoaded', function () {
    // Form gönderim işlemi için event delegation kullanarak event listener ekleyelim
    document.body.addEventListener('submit', function (event) {
        // Sadece form öğelerine tıklanıldığında çalışacak
        if (event.target.tagName.toLowerCase() === 'form') {
            event.preventDefault(); // Formun varsayılan gönderimini engelle

            // Teşekkürler mesajını göster
            document.querySelector('.thanks').style.display = 'block';
            setTimeout(function () {
                // Formu gönder
                event.target.submit();
            }, 2000);
        }
    });
});