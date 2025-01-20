// DOM değişikliklerini gözlemlemek için MutationObserver kullanıyoruz
const observer = new MutationObserver(function (mutationsList, observer) {
    mutationsList.forEach(function (mutation) {
        // Dinamik olarak tagsContainer eklendiğinde
        if (mutation.type === 'childList' && document.getElementById('tagsContainer')) {
            console.log('tagsContainer dinamik olarak eklendi!');

            // Ekleme işlemi tamamlandıktan sonra dinamik davranışı tanımlıyoruz
            $(document).off('click', '#submitProductTags').on('click', '#submitProductTags', function (e) {
                e.preventDefault();
                $('#ajaxResponseMessage').addClass('show'); // show sınıfını ekle
                $('#loadingSpinner').show();
                // Tüm checkbox'ları tara ve işaretli olanları topla
                var selectedTags = [];
                $('#tagsContainer .child-checkbox').each(function () {
                    selectedTags.push({
                        id: $(this).val(),             // Checkbox'ın ID'si (value değeri)
                        isChecked: $(this).is(':checked') // İşaretlenme durumu (true/false)
                    });
                });
                var productId = $(this).data('productid');
                // AJAX ile controller'a gönder
                let productTags = {
                    ProductId: productId,
                    Tags: selectedTags
                };
                var url = $(this).data('url');
                $.ajax({
                    type: 'POST',
                    url: url,
                    contentType: 'application/json', // JSON formatında gönderim
                    data: JSON.stringify(productTags), // Verileri JSON'a dönüştür
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
                        $('#loadingSpinner').hide();
                        $('#ajaxResponseMessage').removeClass('show').empty(); // show sınıfını kaldır ve içeriği temizle
                        alert('Bir hata oluştu: ' + error);
                    }
                });
            });

            // Artık observer'ı durdurabilirsiniz, çünkü tagsContainer yüklendi
            observer.disconnect();
        }
    });
});

// Gözlemlenecek root element ve ayarları tanımlıyoruz
const observerConfig = { childList: true, subtree: true };

// body üzerinde değişiklikleri izlemek için başlatıyoruz
observer.observe(document.body, observerConfig);
