/*
 * Watch this tutorial on YouTube
 * https://youtu.be/fIR3isyFV8s
 */

const resizeBtn = document.querySelector("[data-resize-btn]");

resizeBtn.addEventListener("click", function (e) {
    e.preventDefault();
    document.body.classList.toggle("sb-expanded");
});
document.addEventListener("DOMContentLoaded", function () {
    // Geçerli URL'den controller'ı al
    var segments = window.location.pathname.split('/');
    var controllerName = segments[2]; // URL yapınıza göre segmenti ayarlayın
    // Tüm 'side-link' sınıfına sahip bağlantıları al
    var links = document.querySelectorAll('a.side-link');
    links.forEach(function (link) {
        // Her bağlantının controller değerini kontrol et
        if (link.getAttribute('data-controller').toLowerCase() === controllerName.toLowerCase()) {
            link.classList.add('active');
        } else {
            link.classList.remove('active');
        }
    });

    document.querySelectorAll('.bar-btn').forEach(button => {
        button.addEventListener('click', function () {
            // Bütün .bar-btn'lerden .selected kaldırılır
            document.querySelectorAll('.bar-btn').forEach(btn => btn.classList.remove('selected'));

            // Tıklanan butona .selected eklenir
            this.classList.add('selected');

            // Tıklanan butondaki URL'den gelen cevap resultContent id'li dive eklenir
            const url = this.getAttribute('data-url');
            fetch(url)
                .then(response => response.text())
                .then(data => {
                    document.getElementById('resultContent').innerHTML = '';
                    document.getElementById('resultContent').insertAdjacentHTML('beforeend', data);
                });
        });
    });


    // Kapat butonuna tıklama olayı ekleyin #closeAjaxResponseMessage button
    $(document).on('click', '#closeAjaxResponseMessage button', function () {
        $('#ajaxResponseMessage').removeClass('show').empty(); // show sınıfını kaldır ve içeriği temizle
    });
    $(document).on('click', '#sendFormBtn', function (e) {
        e.preventDefault();
        $('#ajaxResponseMessage').addClass('show'); // show sınıfını ekle
        $('#loadingSpinner').show();
        var url = $(this).data('url');
        var formData = $('#postForm').serialize();
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            success: function (response) {
                if (response.success) {
                    var errorList = $('<ul></ul>'); // ul elementi oluştur
                    errorList.append('<li>' + response.message + '</li>'); // Hata mesajını li olarak ekle

                    // Kapat butonunu oluştur ve ekle
                    var closeButton = $('<div id="closeAjaxResponseMessage"><button type="button">Kapat</button></div>');
                    errorList.append(closeButton);
                    $('#loadingSpinner').hide();
                    $('#ajaxResponseMessage').empty().html(errorList); // errorList'i ajaxResponseMessage içine yerleştir
                } else {

                    // Hata mesajlarını işleme
                    var messages = response.message.split('|');

                    var errorList = $('<ul></ul>'); // ul elementi oluştur
                    messages.forEach(function (message) {

                        errorList.append('<li>' + message + '</li>'); // li elementleri ekle
                    });
                    // Kapat butonunu oluştur ve ekle
                    var closeButton = $('<div id="closeAjaxResponseMessage"><button type="button">Kapat</button></div>');
                    errorList.append(closeButton);
                    $('#loadingSpinner').hide();
                    $('#ajaxResponseMessage').empty().html(errorList); // ul elementini div içine yerleştir
                }
            },
            error: function (xhr, status, error) {
                // AJAX isteği başarısızsa yapılacak işlemler
                $('#loadingSpinner').hide();
                $('#ajaxResponseMessage').removeClass('show').empty(); // show sınıfını kaldır ve içeriği temizle
                alert('Bir hata oluştu: ' + error);
            }
        });
    });




    $(document).on('click', '#sendFormDataBtn', function (e) {
        e.preventDefault();
        $('#ajaxResponseMessage').addClass('show'); // show sınıfını ekle
        $('#loadingSpinner').show();
        var url = $(this).data('url');
        console.log("uerl = " + url);
        var formData = new FormData($('#postFormData')[0]);
        console.log("form = " + formData);
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    var errorList = $('<ul></ul>'); // ul elementi oluştur
                    errorList.append('<li>' + response.message + '</li>'); // Hata mesajını li olarak ekle

                    // Kapat butonunu oluştur ve ekle
                    var closeButton = $('<div id="closeAjaxResponseMessage"><button type="button">Kapat</button></div>');
                    errorList.append(closeButton);
                    $('#loadingSpinner').hide();
                    $('#ajaxResponseMessage').empty().html(errorList); // errorList'i ajaxResponseMessage içine yerleştir
                } else {

                    // Hata mesajlarını işleme
                    var messages = response.message.split('|');

                    var errorList = $('<ul></ul>'); // ul elementi oluştur
                    messages.forEach(function (message) {

                        errorList.append('<li>' + message + '</li>'); // li elementleri ekle
                    });
                    // Kapat butonunu oluştur ve ekle
                    var closeButton = $('<div id="closeAjaxResponseMessage"><button type="button">Kapat</button></div>');
                    errorList.append(closeButton);
                    $('#loadingSpinner').hide();
                    $('#ajaxResponseMessage').empty().html(errorList); // ul elementini div içine yerleştir
                }
            },
            error: function (xhr, status, error) {
                // AJAX isteği başarısızsa yapılacak işlemler
                $('#loadingSpinner').hide();
                $('#ajaxResponseMessage').removeClass('show').empty(); // show sınıfını kaldır ve içeriği temizle
                alert('Bir hata oluştu: ' + error);
            }
        });
    });

});